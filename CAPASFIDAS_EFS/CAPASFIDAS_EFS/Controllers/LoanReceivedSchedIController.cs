using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class LoanReceivedSchedIController : Controller
    {
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();


        //
        // GET: /LoanReceivedSchedI/
        public ActionResult LoanReceivedSchedI()
        {
            try
            {
                if (Session["SAMLResponse"] == null)
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                else
                {
                    GetDefaultLookUpsValues();
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        #region GetDefaultLookUpsValues
        /// <summary>
        /// GetDefaultLookUpsValues
        /// </summary>
        public void GetDefaultLookUpsValues()
        {
            // CHECKING SESSION VALUES.
            // ELECTION YEAR ID.
            if (Session["ElectionCycleVal"] == null)
            {
                Session["ElectionCycleVal"] = Session["ElectionCycleVal_Dup"];
            }
            else if (Session["ElectionCycleVal"].ToString() == "")
            {
                Session["ElectionCycleVal"] = Session["ElectionCycleVal_Dup"];
            }
            // ELECTION TYPE ID.
            if (Session["ElectionTypeVal"] == null)
            {
                Session["ElectionTypeVal"] = Session["ElectionTypeVal_Dup"];
            }
            else if (Session["ElectionTypeVal"].ToString() == "")
            {
                Session["ElectionTypeVal"] = Session["ElectionTypeVal_Dup"];
            }
            // OFFICE TYPE ID.
            if (Session["OfficeTypeVal"] == null)
            {
                Session["OfficeTypeVal"] = Session["OfficeTypeVal_Dup"];
            }
            else if (Session["OfficeTypeVal"].ToString() == "")
            {
                Session["OfficeTypeVal"] = Session["OfficeTypeVal_Dup"];
            }
            // COUNTY ID.
            if (Session["CountyVal"] == null)
            {
                Session["CountyVal"] = Session["CountyVal_Dup"];
            }
            else if (Session["CountyVal"].ToString() == "")
            {
                Session["CountyVal"] = Session["CountyVal_Dup"];
            }
            // MUNICIPALITY ID.
            if (Session["MunicipalityVal"] == null)
            {
                Session["MunicipalityVal"] = Session["MunicipalityVal_Dup"];
            }
            else if (Session["MunicipalityVal"].ToString() == "")
            {
                Session["MunicipalityVal"] = Session["MunicipalityVal_Dup"];
            }

            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            //lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["FilerID"].ToString());
            // Filer ID
            ViewData["txtFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");

            // GET FILER TYPE
            ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();

            String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //String strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            String strCommId = lstFilerCommitteeModel.Select(x => x.FilerId).FirstOrDefault().ToString();
            // Committee Name
            ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeName", "CommitteeName");

            IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
            DisclosureTypesModel objDisclosureTypesModel;
            var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCommId); //GetDisclosureTypeData();
            objDisclosureTypesModel = new DisclosureTypesModel();
            objDisclosureTypesModel.DisclosureTypeId = "0";
            objDisclosureTypesModel.DisclosureTypeDesc = "- Select -";
            lstDisclosureTypeModel.Add(objDisclosureTypesModel);
            foreach (var item in results)
            {
                if (item != null)
                {
                    objDisclosureTypesModel = new DisclosureTypesModel();
                    objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                    if (!String.IsNullOrEmpty(item.DisclosureSubTypeDesc))
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " " + item.DisclosureSubTypeDesc;
                    else
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                    lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                }
            }

            // Bind listIsClaim
            var lstRContributions = new SelectList(new[]
                                          {
                                              new{ID="0",Name="Yes"},
                                              new {ID="1",Name="No"},
                                              },
                            "ID", "Name", 0);
            ViewData["lstRContributions"] = lstRContributions;

            // Bind Disclosure Type
            ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            //IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            //lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
            //// Bind Transaction Type
            //ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

            // BIND TRANSACTIONS TYPE.
            IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            if (Session["FilerId"] != null)
            {
                String strCandCommId = Session["FilerId"].ToString();
                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(strCandCommId);
            }
            else
            {
                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); //GetTransactionTypeData();
            }
            // Bind Transaction Type
            ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

            IList<PartnerModel> lstPartnerModel = new List<PartnerModel>();
            lstPartnerModel = objContributionsMonetaryController.GetPartnerData();
            // Bind Partner Data
            ViewData["lstPartner"] = new SelectList(lstPartnerModel, "PartnerId", "PartnerDesc");

            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
            lstElectionYearModel = objItemizedReportsBroker.GetElectionYearDataResponse(Session["FilerID"].ToString());
            // Report Year
            ViewData["lstElectionCycle"] = new SelectList(lstElectionYearModel, "ElectionYearId", "ElectionYearValue");

            IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
            lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(String.Empty,
                String.Empty, String.Empty, String.Empty, String.Empty);
            // Election Type
            ViewData["lstElectionType"] = new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc");

            IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
            lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(Session["ElectionCycleVal"].ToString(), Session["ElectionTypeVal"].ToString(), Session["OfficeTypeVal"].ToString(), Session["CountyVal"].ToString(), Session["MunicipalityVal"].ToString());
            // Electin Date
            ViewData["lstElectionDate"] = new SelectList(lstElectionDateModel, "ElectId", "ElectDate");

            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(), "");
            // Disclosure Period
            ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
            PaymentMethodModel objPaymentMethodModel;
            objPaymentMethodModel = new PaymentMethodModel();
            objPaymentMethodModel.PaymentTypeId = "0";
            objPaymentMethodModel.PaymentTypeDesc = "- Select -";
            objPaymentMethodModel.PaymentTypeAbbrev = "SEL";
            lstPaymentMethodModel.Add(objPaymentMethodModel);
            var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataResponse();
            foreach (var item in resPayMethods)
            {
                if (item != null)
                {
                    objPaymentMethodModel = new PaymentMethodModel();
                    objPaymentMethodModel.PaymentTypeId = item.PaymentTypeId;
                    objPaymentMethodModel.PaymentTypeDesc = item.PaymentTypeDesc;
                    objPaymentMethodModel.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                    lstPaymentMethodModel.Add(objPaymentMethodModel);
                }
            }
            // Payment Method
            ViewData["lstMethod"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");            

            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
            ContributorNameModel objContributorNameModel;
            objContributorNameModel = new ContributorNameModel();
            objContributorNameModel.ContributorTypeId = "0";
            objContributorNameModel.ContributorTypeDesc = "- Select -";
            objContributorNameModel.ContributorTypeAbbrev = "SEL";
            lstContributorNameModel.Add(objContributorNameModel);
            var resContributorNames = objItemizedReportsBroker.GetContributionNameDataResponse();
            var itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "6");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "7");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            foreach (var item in resContributorNames)
            {
                if (item != null)
                {
                    objContributorNameModel = new ContributorNameModel();
                    objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                    objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                    objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                    lstContributorNameModel.Add(objContributorNameModel);
                }
            }
            ViewData["lstContributionName"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc");

            IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();
            lstContributionTypeModel = objItemizedReportsBroker.GetContributionTypeDataResponse();
            // Bind Contribution Type
            ViewData["lstContributionType"] = new SelectList(lstContributionTypeModel, "ContributionTypeId", "ContributionTypeDesc");

            IList<TransferTypeModel> lstTransferTypeModel = new List<TransferTypeModel>();
            lstTransferTypeModel = objItemizedReportsBroker.GetTransferTypeDataResponse();
            // Bind Transfer Type
            ViewData["lstTransferType"] = new SelectList(lstTransferTypeModel, "TransferTypeId", "TransferTypeDesc");

            IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();
            lstReceiptTypeModel = objItemizedReportsBroker.GetReceiptTypeDataResponse();
            // Bind Receipt Code
            ViewData["lstReceiptType"] = new SelectList(lstReceiptTypeModel, "ReceiptTypeId", "ReceiptTypeDesc");

            IList<ReceiptCodeModel> lstReceiptCodeModel = new List<ReceiptCodeModel>();
            lstReceiptCodeModel = objItemizedReportsBroker.GetReceiptCodeDataResponse();
            // Bind Receipt Code            
            ViewData["lstReceiptCode"] = new SelectList(lstReceiptCodeModel, "ReceiptCodeId", "ReceiptCodeDesc");

            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
            lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeDataResponse();
            // Bind Purpose Code            
            ViewData["lstPurposeCode"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");

            IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
            lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeResponse();
            // Bind Office Type
            ViewData["lstUCOfficeType"] = new SelectList(lstOfficeTypeModel, "OfficeTypeId", "OfficeTypeDesc");

            IList<CountyModel> lstCountyModel = new List<CountyModel>();
            lstCountyModel = objItemizedReportsBroker.GetCountyResponse();
            // Bind County
            ViewData["lstUCCounty"] = new SelectList(lstCountyModel, "CountyId", "CountyDesc");

            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
            lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(String.Empty);
            // Bind Municipality
            ViewData["lstUCMuncipality"] = new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc");

            // ===================================================================================================================================
            // THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
            // ===================================================================================================================================
            // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
            // Bind Filing Date for Off Cycle.
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModelResults = new List<FilingDatesOffCycleModel>();
            FilingDatesOffCycleModel objFilingDatesOffCycleModel;
            if (Session["ElectionYearId"] != null && Session["OfficeTypeId"] != null && Session["FilerIdOffCycle"] != null && Session["DisclosureType"] != null)
                lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(Session["ElectionYearId"].ToString(), Session["OfficeTypeId"].ToString(), Session["FilerIdOffCycle"].ToString(), Session["DisclosureType"].ToString());
            else
                lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(String.Empty, String.Empty, String.Empty, String.Empty);
            objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            objFilingDatesOffCycleModel.FilingDateId = "- Select -";
            objFilingDatesOffCycleModel.FilingDate = "- Select -";
            lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
            objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
            lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            if (lstFilingDatesOffCycleModelResults.Count() > 0)
            {
                foreach (var item in lstFilingDatesOffCycleModelResults)
                {
                    if (item != null)
                    {
                        objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                        objFilingDatesOffCycleModel.FilingDateId = item.FilingDateId;
                        objFilingDatesOffCycleModel.FilingDate = item.FilingDate;
                        lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    }
                }
            }
            // Bind Filing Date for Off Cycle.
            ViewData["lstFilingDate"] = new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate");

            // GET REASON FOR FILING DATA.
            IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
            IList<ResigTermTypeModel> lstResigTermTypeModelResults = new List<ResigTermTypeModel>();
            ResigTermTypeModel objResigTermTypeModel;
            lstResigTermTypeModelResults = objItemizedReportsBroker.GeResigTermTypeDataResponse();
            objResigTermTypeModel = new ResigTermTypeModel();
            objResigTermTypeModel.ResigTermTypeId = "- Not Applicable -";
            objResigTermTypeModel.ResigTermTypeDesc = "- Not Applicable -";
            lstResigTermTypeModel.Add(objResigTermTypeModel);
            foreach (var item in lstResigTermTypeModelResults)
            {
                if (item != null)
                {
                    objResigTermTypeModel = new ResigTermTypeModel();
                    objResigTermTypeModel.ResigTermTypeId = item.ResigTermTypeId;
                    objResigTermTypeModel.ResigTermTypeDesc = item.ResigTermTypeDesc;
                    lstResigTermTypeModel.Add(objResigTermTypeModel);
                }
            }
            // Bind Partner Data
            ViewData["lstResigTermType"] = new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc");
            // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
            // ===================================================================================================================================
            // THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
            // ===================================================================================================================================

            List<ItemizedModel> lstItemizedModel = new List<ItemizedModel>();
            ItemizedModel objItemizedModel;
            objItemizedModel = new ItemizedModel();
            objItemizedModel.strItemizedId = "Y";
            objItemizedModel.strItemizedName = "Yes";
            lstItemizedModel.Add(objItemizedModel);
            objItemizedModel = new ItemizedModel();
            objItemizedModel.strItemizedId = "N";
            objItemizedModel.strItemizedName = "No";
            lstItemizedModel.Add(objItemizedModel);
            // Bind Subcontractor
            ViewData["lstItemized"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
            ViewData["lstItemizedPart"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
            List<ItemizedModel> lstItemizedModelIndPart = new List<ItemizedModel>();
            ItemizedModel objItemizedModelIndPart;
            objItemizedModelIndPart = new ItemizedModel();
            objItemizedModelIndPart.strItemizedId = "Y";
            objItemizedModelIndPart.strItemizedName = "Yes";
            lstItemizedModelIndPart.Add(objItemizedModelIndPart);
            objItemizedModelIndPart = new ItemizedModel();
            objItemizedModelIndPart.strItemizedId = "N";
            objItemizedModelIndPart.strItemizedName = "No";
            lstItemizedModelIndPart.Add(objItemizedModelIndPart);
            ViewData["lstIndividualPart"] = new SelectList(lstItemizedModelIndPart, "strItemizedId", "strItemizedName", 1);

            // ===================================================================================================================================
            // ADD THIS ONE ITS NEW CODE
            // Viewable Columns Default Values            
            IList<ViewableColumnModel> lstViewableColumns = new List<ViewableColumnModel>();
            lstViewableColumns = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            Session["SorList"] = lstViewableColumns;
            //Bind Column Name
            ViewData["lstViewableColumns"] = new SelectList(lstViewableColumns, "ViewableFieldID", "ColumnName");
            // ADD THIS ONE ITS NEW CODE
            // ===================================================================================================================================

            // Sortable Columns.
            IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            // Session["SorList"] = lstSortColumnName; // REMOVE SESSION HERE.....///===//===///
            //Bind Column Name
            ViewData["lstSortColumnName"] = new SelectList(lstSortColumnName, "ViewableFieldID", "ColumnName");
            var lstSortColumnNameOrder = new SelectList(new[]
                                        {
                                            new {ID="asc",Name="Ascending "},
                                            new{ID="desc",Name="Descending"},
                                        },
                            "ID", "Name", 0);
            ViewData["lstSortColumnNameOrder"] = lstSortColumnNameOrder;

            //Bind Loaner Code
            IList<LoanerCodeModel> lstLoanerCodeModel = new List<LoanerCodeModel>();
            LoanerCodeModel objLoanerCodeModel;
            objLoanerCodeModel = new LoanerCodeModel();
            objLoanerCodeModel.LoanerID = "0";
            objLoanerCodeModel.LoanerDesc = "- Select -";
            lstLoanerCodeModel.Add(objLoanerCodeModel);
            var reslstLoanerCodeModel = objItemizedReportsBroker.GetLoanerCodeBroker();
            foreach (var item in reslstLoanerCodeModel)
            {
                if (item != null)
                {
                    objLoanerCodeModel = new LoanerCodeModel();
                    objLoanerCodeModel.LoanerID = item.LoanerID;
                    objLoanerCodeModel.LoanerDesc = item.LoanerDesc;
                    lstLoanerCodeModel.Add(objLoanerCodeModel);
                }
            }
            ViewData["lstLoanerCode"] = new SelectList(lstLoanerCodeModel, "LoanerID", "LoanerDesc");
        }
        #endregion GetDefaultLookUpsValues

        /// <summary>
        /// Add Transfer In Scheduled data
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strFilingSchedId"></param>
        /// <param name="strTransferTypeId"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstElectYearId"></param>
        /// <param name="lstFilingEntId"></param>
        /// <param name="strFlngEntName"></param>
        /// <param name="strFlngEntStrName"></param>
        /// <param name="txtPartCity"></param>
        /// <param name="txtPartState"></param>
        /// <param name="txtPartZip5"></param>
        /// <param name="txtPartZip4"></param>
        /// <param name="PaymentTypeId"></param>
        /// <returns></returns>
        public JsonResult AddLoanReceivedScheduledData(String txtFilerId, String strFilingSchedId, String strFilingSchedDate,
            String strPayNumber, String strOrgAmt, String strTransExplanation, String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId, 
            String lstElectYearId, String lstFilingEntId, String strFlngEntName, String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName,
            String strFlngEntStrName, String txtPartCity, String txtPartState,
            String txtPartZip, String txtCountry,String chkCountry, String PaymentTypeId, String LoanerCodeID, String lstFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate, String lstUCMuncipality,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (PaymentTypeId == "0")
                {
                    PaymentTypeId = "";
                    strPayNumber = "";
                }

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (txtPartZip == "00000-0000")
                    txtPartZip = "";

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    if (LoanerCodeID == "10")
                    {
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                }
                else
                {
                    txtEmployerPCFB = "";
                    txtOccupationPCFB = "";
                    txtContStreetName = "";
                    txtContCity = "";
                    txtContState = "";
                    txtContZipCode = "";
                }

                objFilingTransactionsModel.FilerId = txtFilerId;

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (strElectionTypeId == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                }

                if (LoanerCodeID == "1" || LoanerCodeID == "2" || LoanerCodeID == "3" || LoanerCodeID == "4" || LoanerCodeID == "6"
                    || LoanerCodeID == "7" || LoanerCodeID == "8" || LoanerCodeID == "9")
                {
                    if (strFlngEntFirstName == "")
                    {
                        ModelState.AddModelError("txtLenderFirstName", "First Name is required");
                    }
                    else if (!objCommonErrorsServerSide.NameValidate(strFlngEntFirstName))
                    {
                        ModelState.AddModelError("txtLenderFirstName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntFirstName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderFirstName", "First Name should be 30 characters");
                    }


                    //if (strFlngEntMiddleName == "")
                    //{
                    //    ModelState.AddModelError("txtLenderMIName", "Middle Name is required");
                    //}
                    if (!objCommonErrorsServerSide.NameValidate(strFlngEntMiddleName))
                    {
                        ModelState.AddModelError("txtLenderMIName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntMiddleName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderMIName", "Middle Name should be 30 characters");
                    }


                    if (strFlngEntLastName == "")
                    {
                        ModelState.AddModelError("txtLenderLastName", "Last Name is required");
                    }
                    else if (!objCommonErrorsServerSide.NameValidate(strFlngEntLastName))
                    {
                        ModelState.AddModelError("txtLenderLastName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntLastName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderLastName", "Last Name should be 30 characters");
                    }
                }
                else if (LoanerCodeID == "10" || LoanerCodeID == "11" || LoanerCodeID == "12" || LoanerCodeID == "13")
                {
                    if (strFlngEntName == "")
                    {
                        ModelState.AddModelError("txtLenderName", "Lender Name is required");
                    }
                }

                if (chkCountry == "false") // United States Country.
                {
                    if (txtCountry != "United States")
                    {
                        if (txtCountry != "")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                            {
                                ModelState.AddModelError("txtCountry", "Letters are allowed");
                            }
                            else if (txtCountry.Count() > 30)
                            {
                                ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                            }
                        }
                    }

                    if (txtCountry == "")
                    {
                        ModelState.AddModelError("txtCountry", "Country is required");
                    }

                    if (strFlngEntStrName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngEntStrName))
                        {
                            ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (strFlngEntStrName.Length < 4)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                            }
                        }

                        if (strFlngEntStrName.Count() > 60)
                        {
                            ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                        }
                    }

                    if (txtPartCity != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtPartCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters and characters '# -., are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                            }
                        }

                        if (txtPartCity.Count() > 30)
                        {
                            ModelState.AddModelError("txtCity", "City should be 30 characters");
                        }
                    }

                    if (txtPartState != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsValState(txtPartState))
                            {
                                ModelState.AddModelError("txtState", "Two letters are allowed");
                            }
                            if (txtPartState.Length != 2)
                            {
                                ModelState.AddModelError("txtState", "Two letters are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                            {
                                ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                            }
                        }
                    }

                    if (txtPartZip != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.FomatZipcode(txtPartZip))
                            {
                                ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                        }
                        if (txtPartZip.Count() > 10)
                        {
                            ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                        }
                    }
                }
                else // Other Country
                {
                    if (txtCountry != "")
                    {
                        if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                        {
                            ModelState.AddModelError("txtCountry", "Letters are allowed");
                        }
                    }

                    if (txtCountry == "")
                    {
                        ModelState.AddModelError("txtCountry", "Country is required");
                    }

                    if (txtCountry.Count() > 30)
                    {
                        ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                    }

                    if (strFlngEntStrName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngEntStrName))
                        {
                            ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (strFlngEntStrName.Length < 4)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                            }
                        }
                        if (strFlngEntStrName.Count() > 60)
                        {
                            ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                        }
                    }


                    if (txtPartCity != "")
                    {
                        if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                        {
                            ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                        }
                        if (txtPartCity.Count() > 30)
                        {
                            ModelState.AddModelError("txtCity", "City should be 30 characters");
                        }
                    }

                    if (txtPartState != "")
                    {
                        if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                        {
                            ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                        }
                        if (txtPartState.Count() > 30)
                        {
                            ModelState.AddModelError("txtState", "State should be 30 characters");
                        }
                    }

                    if (txtPartZip != "")
                    {
                        if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip))
                        {
                            ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                        }
                        if (txtPartZip.Count() > 10)
                        {
                            ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                        }
                    }

                }

                if (PaymentTypeId == "1")
                {
                    if (strPayNumber == "")
                    {
                        ModelState.AddModelError("txtCheck", "Check # is required");
                    }
                    else if (!objCommonErrorsServerSide.AlphaNumeric(strPayNumber))
                    {
                        ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                    }
                    else if (strPayNumber.Count() > 30)
                    {
                        ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                    }
                }
                else if (PaymentTypeId == "7")
                {
                    if (strTransExplanation == "")
                    {
                        ModelState.AddModelError("txtExplanation", "Explanation is required");
                    }
                    else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strPayNumber))
                    {
                        ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                if (PaymentTypeId != "")
                {
                    if (PaymentTypeId != "0")
                    {
                        Boolean resultsData = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", PaymentTypeId.ToString());
                        if (!resultsData)
                        {
                            ModelState.AddModelError("lstMethod", "Invalid Method");
                        }
                    }
                }


                if (strOrgAmt == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (strTransExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                    {
                        ModelState.AddModelError("txtExplanationCommon", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                #endregion FormValidationScheduleA

                string results = string.Empty;
                if (ModelState.IsValid)
                {
                    //Add Loan Received                                
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.FilingSchedId = "9";
                    objFilingTransactionsModel.OtherFilingSchedId = "14";
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                    objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                    objFilingTransactionsModel.ElectYearId = lstElectYearId;
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                    objFilingTransactionsModel.FlngEntName = strFlngEntName;
                    objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                    objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    objFilingTransactionsModel.LoanOtherId = LoanerCodeID;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                        else
                            objFilingTransactionsModel.FilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    }
                    objFilingTransactionsModel.ElectionDateId = electionDateId;
                    if (lstResigTermType == "")
                        lstResigTermType = null;
                    if (lstResigTermType == "- Not Applicable -")
                        lstResigTermType = null;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;
                    objFilingTransactionsModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionsModel.TreasurerOccupation = txtOccupationPCFB;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionsModel.TreasurerCity = txtContCity;
                    objFilingTransactionsModel.TreasurerState = txtContState;
                    objFilingTransactionsModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionsModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }

                    results = objItemizedReportsBroker.AddFilingTransaction_LoanReceived_Broker(objFilingTransactionsModel);
                    return Json(results, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Update Transfer In scheduled data
        /// </summary>
        /// <param name="strTransferTypeId"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="lstFilingEntId"></param>
        /// <param name="strFlngEntName"></param>
        /// <param name="strFlngEntStrName"></param>
        /// <param name="txtPartCity"></param>
        /// <param name="txtPartState"></param>
        /// <param name="txtPartZip5"></param>
        /// <param name="txtPartZip4"></param>
        /// <param name="filingTransID"></param>
        /// <param name="PaymentTypeId"></param>
        /// <returns></returns>
        //public JsonResult UpdateLoanReceivedScheduledData(String strPayNumber, String strOrgAmt, String strTransExplanation,
        //     String lstFilingEntId, String strFlngEntName, String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName,
        //     String strFlngEntStrName, String txtPartCity, String txtPartState,
        //    String txtPartZip, String txtCountry, String PaymentTypeId, String LoanerCodeID, String filingTransID)
        //{
        public JsonResult UpdateLoanReceivedScheduledData(String txtFilerId, String strFilingSchedId, String strFilingSchedDate,
            String strPayNumber, String strOrgAmt, String strTransExplanation, String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId,
            String lstElectYearId, String lstFilingEntId, String strFlngEntName, String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName,
            String strFlngEntStrName, String txtPartCity, String txtPartState,
            String txtPartZip, String txtCountry, String chkCountry, String PaymentTypeId, String LoanerCodeID, String lstFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate, String transNumber, String loan_Lib_Number, String amountCheck,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (PaymentTypeId == "0")
                {
                    PaymentTypeId = "";
                    strPayNumber = "";
                }

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (txtPartZip == "00000-0000")
                    txtPartZip = "";

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {

                    if (LoanerCodeID == "10")
                    {
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                }
                else
                {
                    txtEmployerPCFB = "";
                    txtOccupationPCFB = "";
                    txtContStreetName = "";
                    txtContCity = "";
                    txtContState = "";
                    txtContZipCode = "";
                }

                objFilingTransactionsModel.FilerId = txtFilerId;

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (strElectionTypeId == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                }

                if (LoanerCodeID == "1" || LoanerCodeID == "2" || LoanerCodeID == "3" || LoanerCodeID == "4" || LoanerCodeID == "6"
                    || LoanerCodeID == "7" || LoanerCodeID == "8" || LoanerCodeID == "9")
                {
                    if (strFlngEntFirstName == "")
                    {
                        ModelState.AddModelError("txtLenderFirstName", "First Name is required");
                    }
                    else if (!objCommonErrorsServerSide.NameValidate(strFlngEntFirstName))
                    {
                        ModelState.AddModelError("txtLenderFirstName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntFirstName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderFirstName", "First Name should be 30 characters");
                    }


                    //if (strFlngEntMiddleName == "")
                    //{
                    //    ModelState.AddModelError("txtLenderMIName", "Middle Name is required");
                    //}
                    if (!objCommonErrorsServerSide.NameValidate(strFlngEntMiddleName))
                    {
                        ModelState.AddModelError("txtLenderMIName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntMiddleName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderMIName", "Middle Name should be 30 characters");
                    }


                    if (strFlngEntLastName == "")
                    {
                        ModelState.AddModelError("txtLenderLastName", "Last Name is required");
                    }
                    else if (!objCommonErrorsServerSide.NameValidate(strFlngEntLastName))
                    {
                        ModelState.AddModelError("txtLenderLastName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntLastName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderLastName", "Last Name should be 30 characters");
                    }
                }
                else if (LoanerCodeID == "10" || LoanerCodeID == "11" || LoanerCodeID == "12" || LoanerCodeID == "13")
                {
                    if (strFlngEntName == "")
                    {
                        ModelState.AddModelError("txtLenderName", "Lender Name is required");
                    }
                }

                if (chkCountry == "false") // United States Country.
                {
                    if (txtCountry != "United States")
                    {
                        if (txtCountry != "")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                            {
                                ModelState.AddModelError("txtCountry", "Letters are allowed");
                            }
                            else if (txtCountry.Count() > 30)
                            {
                                ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                            }
                        }
                    }

                    if (txtCountry == "")
                    {
                        ModelState.AddModelError("txtCountry", "Country is required");
                    }

                    if (strFlngEntStrName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngEntStrName))
                        {
                            ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (strFlngEntStrName.Length < 4)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                            }
                        }

                        if (strFlngEntStrName.Count() > 60)
                        {
                            ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                        }
                    }

                    if (txtPartCity != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtPartCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters and characters '# -., are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                            }
                        }

                        if (txtPartCity.Count() > 30)
                        {
                            ModelState.AddModelError("txtCity", "City should be 30 characters");
                        }
                    }

                    if (txtPartState != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsValState(txtPartState))
                            {
                                ModelState.AddModelError("txtState", "Two letters are allowed");
                            }
                            if (txtPartState.Length != 2)
                            {
                                ModelState.AddModelError("txtState", "Two letters are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                            {
                                ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                            }
                        }
                    }

                    if (txtPartZip != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.FomatZipcode(txtPartZip))
                            {
                                ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                        }
                        if (txtPartZip.Count() > 10)
                        {
                            ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                        }
                    }
                }
                else // Other Country
                {
                    if (txtCountry != "")
                    {
                        if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                        {
                            ModelState.AddModelError("txtCountry", "Letters are allowed");
                        }
                    }

                    if (txtCountry == "")
                    {
                        ModelState.AddModelError("txtCountry", "Country is required");
                    }

                    if (txtCountry.Count() > 30)
                    {
                        ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                    }

                    if (strFlngEntStrName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngEntStrName))
                        {
                            ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (strFlngEntStrName.Length < 4)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                            }
                        }
                        if (strFlngEntStrName.Count() > 60)
                        {
                            ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                        }
                    }


                    if (txtPartCity != "")
                    {
                        if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                        {
                            ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                        }
                        if (txtPartCity.Count() > 30)
                        {
                            ModelState.AddModelError("txtCity", "City should be 30 characters");
                        }
                    }

                    if (txtPartState != "")
                    {
                        if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                        {
                            ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                        }
                        if (txtPartState.Count() > 30)
                        {
                            ModelState.AddModelError("txtState", "State should be 30 characters");
                        }
                    }

                    if (txtPartZip != "")
                    {
                        if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip))
                        {
                            ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                        }
                        if (txtPartZip.Count() > 10)
                        {
                            ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                        }
                    }

                }

                if (PaymentTypeId == "1")
                {
                    if (strPayNumber == "")
                    {
                        ModelState.AddModelError("txtCheck", "Check # is required");
                    }
                    else if (!objCommonErrorsServerSide.AlphaNumeric(strPayNumber))
                    {
                        ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                    }
                    else if (strPayNumber.Count() > 30)
                    {
                        ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                    }
                }
                else if (PaymentTypeId == "7")
                {
                    if (strTransExplanation == "")
                    {
                        ModelState.AddModelError("txtExplanation", "Explanation is required");
                    }
                    else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strPayNumber))
                    {
                        ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                if (PaymentTypeId != "")
                {
                    if (PaymentTypeId != "0")
                    {
                        Boolean resultsData = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", PaymentTypeId.ToString());
                        if (!resultsData)
                        {
                            ModelState.AddModelError("lstMethod", "Invalid Method");
                        }
                    }
                }


                if (strOrgAmt == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (strTransExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                    {
                        ModelState.AddModelError("txtExplanationCommon", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }
                #endregion FormValidationScheduleA

                var results = true;
                if (ModelState.IsValid)
                {
                    //Add Loan Received                                
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.FilingSchedId = "9";
                    objFilingTransactionsModel.OtherFilingSchedId = "14";
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                    objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                    objFilingTransactionsModel.ElectYearId = lstElectYearId;
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                    objFilingTransactionsModel.FlngEntName = strFlngEntName;
                    objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                    objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.ModifiedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    objFilingTransactionsModel.LoanOtherId = LoanerCodeID;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                        else
                            objFilingTransactionsModel.FilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    }
                    objFilingTransactionsModel.ElectionDateId = electionDateId;
                    if (lstResigTermType == "")
                        lstResigTermType = null;
                    if (lstResigTermType == "- Not Applicable -")
                        lstResigTermType = null;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    objFilingTransactionsModel.TransNumber = transNumber;
                    objFilingTransactionsModel.Loan_Lib_Number = loan_Lib_Number;

                    if (float.Parse(amountCheck) == float.Parse(strOrgAmt))
                    {
                        objFilingTransactionsModel.IsAmtChanged = "NO";
                    }
                    else
                    {
                        objFilingTransactionsModel.IsAmtChanged = "YES";
                    }
                    objFilingTransactionsModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionsModel.TreasurerOccupation = txtOccupationPCFB;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionsModel.TreasurerCity = txtContCity;
                    objFilingTransactionsModel.TreasurerState = txtContState;
                    objFilingTransactionsModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionsModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }

                    results = objItemizedReportsBroker.UpdateFilingTransaction_LoanReceived_Broker(objFilingTransactionsModel);

                    return Json(results, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                //objFilingTransactionsModel.PayNumber = strPayNumber;
                //objFilingTransactionsModel.OrgAmt = strOrgAmt;
                //objFilingTransactionsModel.TransExplanation = strTransExplanation;            
                //objFilingTransactionsModel.FilingEntId = lstFilingEntId;
                //objFilingTransactionsModel.FlngEntName = strFlngEntName;
                //objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                //objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                //objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                //objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                //objFilingTransactionsModel.FlngEntCity = txtPartCity;
                //objFilingTransactionsModel.FlngEntState = txtPartState;
                //objFilingTransactionsModel.FlngEntZip = txtPartZip;
                //objFilingTransactionsModel.FlngEntCountry = txtCountry;
                //objFilingTransactionsModel.ModifiedBy = "Admin"; // Testing Only...            
                //objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                //objFilingTransactionsModel.LoanOtherId = LoanerCodeID;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Delete Filing Transaction
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult DeleteLoanReceived(String strLoanLiabNumberOrg, String strTransNumber, String strRLiability)
        {
            try
            {
                Boolean results = objItemizedReportsBroker.DeleteLoanReceivedBroker(strTransNumber, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult ValidateSchedI_UpdateAmount(String trans_Number, String org_Amt)
        {
            try
            {
                decimal amtValidate, totalAmount = 0;

                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateSchedI_UpdateAmountBroker(trans_Number, Session["FilerID"].ToString());
                amtValidate = decimal.Parse(lstGetSearchForScheduledIModel[0].Amount);

                if (amtValidate > decimal.Parse(org_Amt))
                {
                    totalAmount = 1;
                }
                else
                {
                    String strExpSubContrTotAmt = String.Empty;
                    strExpSubContrTotAmt = objItemizedReportsBroker.GetExpSubContrTotAmtBroker(trans_Number, Session["FilerID"].ToString());
                    if (strExpSubContrTotAmt != "")
                    {
                        if (decimal.Parse(org_Amt) < decimal.Parse(strExpSubContrTotAmt))
                        {
                            totalAmount = 2;
                        }
                        else
                        {
                            totalAmount = 0;
                        }
                    }
                    else
                    {
                        totalAmount = 0;
                    }
                }
                return Json(totalAmount.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region Get Filing Transaction

        public JsonResult GetLoanReceived_LoanRepaymentData(String loan_Lib_Num, String SchedName)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.Loan_Lib_Num = loan_Lib_Num;
                objFilingTransDataModel.SchedName = SchedName;
                objFilingTransDataModel.FilerId = Session["FilerID"].ToString(); 

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsForScheduledIJNBroker(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                    }
                }


                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.ContributorTypeId,
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.OwedAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.ReceiptCodeDesc,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    //x.RItemized,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        public JsonResult GetLoanReceived_LoanForgivenData(String loan_Lib_Num, String SchedName)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.Loan_Lib_Num = loan_Lib_Num;
                objFilingTransDataModel.SchedName = SchedName;
                objFilingTransDataModel.FilerId = Session["FilerID"].ToString();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsForScheduledIJNBroker(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10" || lstFilingTransactionDataModel[i].FilingSchedId == "11")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                    }
                }
                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.ContributorTypeId,
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.OwedAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.ReceiptCodeDesc,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    //x.RItemized,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region DeleteFilingTransactions
        /// <summary>
        /// DeleteFilingTransactions
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult DeleteFilingTransactions(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString();

                Boolean results = objItemizedReportsBroker.DeleteFilingTransactionsDataResponse(strTransNumber, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteFilingTransactions

        public JsonResult GetSortName()
        {
            try
            {
                string results = string.Empty;
                IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
                lstSortColumnName = (IList<ViewableColumnModel>)Session["SorList"];
                lstSortColumnName = lstSortColumnName.Where(x => x.Viewable == "Y").ToList();
                foreach (var item in lstSortColumnName)
                {
                    if (item != null)
                    {
                        results = results + item.ColumnName + ",";
                    }
                }
                results = results.Substring(0, (results.Length - 1));
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetPartnershipTotAmt
        /// <summary>
        /// GetPartnershipTotAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetPartnershipTotAmt(String strTransNumber)
        {
            try
            {
                String strExpSubContrTotAmt = String.Empty;                
                strExpSubContrTotAmt = objItemizedReportsBroker.GetExpSubContrTotAmtBroker(strTransNumber, Session["FilerID"].ToString());
                Session["OutstandingAmountDetails"] = strExpSubContrTotAmt;

                return strExpSubContrTotAmt;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPartnershipTotAmt   

        #region GetSchedAPartnersData
        /// <summary>
        /// GetSchedAPartnersData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetLoanReceivedPartnersData(String strTransNumber, String strPartnershipName, String strFilerId)
        {
            try
            {
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModelResults = new List<ContrInKindPartnersModel>();
                ContrInKindPartnersModel objContrInKindPartnersModel;

                lstContrInKindPartnersModel = objItemizedReportsBroker.GetLoanReceviedPartnersDataBroker(strTransNumber, strFilerId);

                foreach (var item in lstContrInKindPartnersModel)
                {
                    if (item != null)
                    {
                        objContrInKindPartnersModel = new ContrInKindPartnersModel();
                        objContrInKindPartnersModel.FilingTransId = item.FilingTransId;
                        objContrInKindPartnersModel.FilingEntityId = item.FilingEntityId;
                        objContrInKindPartnersModel.PartnershipName = strPartnershipName;
                        //objContrInKindPartnersModel.PartnershipName = item.PartnershipName;
                        objContrInKindPartnersModel.PartnerName = item.PartnershipName;
                        objContrInKindPartnersModel.PartnerFirstName = item.PartnerFirstName;
                        objContrInKindPartnersModel.PartnerMiddleName = item.PartnerMiddleName;
                        objContrInKindPartnersModel.PartnerLastName = item.PartnerLastName;
                        objContrInKindPartnersModel.PartnerStreetName = item.PartnerStreetName;
                        objContrInKindPartnersModel.PartnerCity = item.PartnerCity;
                        objContrInKindPartnersModel.PartnerState = item.PartnerState;
                        objContrInKindPartnersModel.PartnerZip5 = item.PartnerZip5;
                        objContrInKindPartnersModel.PartnershipCountry = item.PartnershipCountry;
                        if (item.PartnerAmountAttributed != "")
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        else
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        objContrInKindPartnersModel.PartnerExplanation = item.PartnerExplanation;
                        objContrInKindPartnersModel.RItemized = item.RItemized;
                        objContrInKindPartnersModel.TransNumber = item.TransNumber;
                        objContrInKindPartnersModel.TransMapping = item.TransMapping;
                        objContrInKindPartnersModel.TreasurerEmployer = item.TreasurerEmployer;
                        objContrInKindPartnersModel.TreasurerOccupation = item.TreasurerOccupation;
                        objContrInKindPartnersModel.TreaAddress = item.TreaAddress;
                        objContrInKindPartnersModel.TreaAddr1 = item.TreaAddr1;
                        objContrInKindPartnersModel.TreaCity = item.TreaCity;
                        objContrInKindPartnersModel.TreaState = item.TreaState;
                        objContrInKindPartnersModel.TreaZipCode = item.TreaZipCode;
                        objContrInKindPartnersModel.RContributions = item.RContributions;
                        lstContrInKindPartnersModelResults.Add(objContrInKindPartnersModel);
                    }
                }

                return Json(new
                {
                    aaData = lstContrInKindPartnersModelResults.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingEntityId,
                    "",
                    "",
                    x.PartnershipName,
                    x.PartnerName,
                    x.PartnerFirstName,
                    x.PartnerMiddleName,
                    x.PartnerLastName,
                    x.PartnershipCountry,
                    x.PartnerStreetName,
                    x.PartnerCity,
                    x.PartnerState,
                    x.PartnerZip5,
                    x.PartnerAmountAttributed,
                    x.PartnerExplanation,
                    x.RItemized,
                    x.TransNumber,
                    x.TransMapping,
                    x.RContributions,
                    x.TreasurerEmployer,
                    x.TreasurerOccupation,
                    x.TreaAddress,
                    x.TreaAddr1,
                    x.TreaCity,
                    x.TreaState,
                    x.TreaZipCode
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetSchedAPartnersData

        /// <summary>
        /// Validate Loan Received Delete functionality
        /// </summary>
        /// <param name="loan_Lib_Number"></param>
        /// <returns></returns>
        public JsonResult ValidateDelete_LoanReceived(String loan_Lib_Number)
        {
            try
            {
                IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.Loan_Lib_Num = loan_Lib_Number;
                objFilingTransDataModel.FilerId = Session["FilerId"].ToString();
                lstGetEditFlagDataModel = objItemizedReportsBroker.ValidateLoanReceived_Delete_Broker(objFilingTransDataModel);
                return Json(lstGetEditFlagDataModel[0].VALIDATE_FILINGS.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetScheduleIHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleIHelpPopUp()
        {
            return View("GetScheduleIHelpPopUp");
        }
        #endregion GetScheduleIHelpPopUp

        /// <summary>
        /// Get Loan Outstanding balance
        /// </summary>
        /// <param name="loan_Lib_Number"></param>
        /// <returns></returns>
        public JsonResult GetLoanOutstandingBalance(String loan_Lib_Number)
        {
            try
            {                
                String outStandingBalance = objItemizedReportsBroker.FilingTransactionOutStandingBalanceBroker(loan_Lib_Number, Session["FilerId"].ToString());
                return Json(outStandingBalance, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}