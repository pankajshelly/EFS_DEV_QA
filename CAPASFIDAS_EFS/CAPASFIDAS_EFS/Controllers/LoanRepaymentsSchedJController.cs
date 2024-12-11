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
    public class LoanRepaymentsSchedJController : Controller
    {
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();


        //
        // GET: /LoanRepaymentsSchedJ/
        public ActionResult LoanRepaymentsSchedJ()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

            //Bind Original Date
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
            GetSearchForScheduledIModel objGetSearchForScheduledIModel = new GetSearchForScheduledIModel();
            objGetSearchForScheduledIModel.FILING_TRANS_ID = "0";
            objGetSearchForScheduledIModel.Name = "- Select -";
            lstGetSearchForScheduledIModel.Add(objGetSearchForScheduledIModel);
            var rsName = objItemizedReportsBroker.GetName_SchedueledJBroker(Session["FilerID"].ToString());

            foreach (var item in rsName)
            {
                if (item != null)
                {
                    objGetSearchForScheduledIModel = new GetSearchForScheduledIModel();
                    objGetSearchForScheduledIModel.FILING_TRANS_ID = item.FILING_TRANS_ID;
                    objGetSearchForScheduledIModel.Name = item.Name;
                    objGetSearchForScheduledIModel.flng_Ent_FirstName = item.flng_Ent_FirstName;
                    objGetSearchForScheduledIModel.flng_Ent_MiddleName = item.flng_Ent_MiddleName;
                    objGetSearchForScheduledIModel.flng_Ent_LastName = item.flng_Ent_LastName;
                    lstGetSearchForScheduledIModel.Add(objGetSearchForScheduledIModel);
                }
            }

            Session["EntityName"] = lstGetSearchForScheduledIModel;

            ViewData["lstSearchName"] = new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name");
            ViewData["lstSearchDate"] = new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name");
            ViewData["lstSearchAmount"] = new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name");
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
        public JsonResult AddLoanRepaymentsScheduledData(String txtFilerId, String strFilingSchedId, String strFilingSchedDate,
            String strPayNumber, String strAmt, String strAmtOrg, String strTransExplanation, String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId,
            String lstElectYearId, String lstFilingEntId, String strFlngEntName, String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName,
            String strFlngEntStrName, String txtPartCity, String txtPartState,
            String txtPartZip5, String txtCountry, String chkCountry, String PaymentTypeId, String LoanerCodeID, String lstFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate, String trans_Nubmer, String lstUCMuncipality)
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

                if (txtPartZip5 == "00000-0000")
                    txtPartZip5 = "";

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

                    if (txtPartZip5 != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.FomatZipcode(txtPartZip5))
                            {
                                ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                        }
                        if (txtPartZip5.Count() > 10)
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

                    if (txtPartZip5 != "")
                    {
                        if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                        {
                            ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                        }
                        if (txtPartZip5.Count() > 10)
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


                if (strAmtOrg == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(strAmtOrg))
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
                    objFilingTransactionsModel.FilerId = txtFilerId;
                    objFilingTransactionsModel.FilingSchedId = "10";
                    objFilingTransactionsModel.OtherFilingSchedId = "14";
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OrgAmt = strAmt;
                    //objFilingTransactionsModel.OrgAmt = Session["RepayAmount"].ToString();
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                    objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                    objFilingTransactionsModel.ElectYearId = lstElectYearId;
                    if (Session["FilingEntityID"] != null)
                    {
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntityID"].ToString();
                    }
                    else
                    {
                        objFilingTransactionsModel.FilingEntId = "";
                    }

                    objFilingTransactionsModel.FlngEntName = strFlngEntName;
                    objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                    objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    objFilingTransactionsModel.LoanOtherId = LoanerCodeID;
                    objFilingTransactionsModel.OtherAmount = strAmtOrg;
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
                    objFilingTransactionsModel.Loan_Lib_Number = "";
                    objFilingTransactionsModel.TransNumber = trans_Nubmer;
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;

                    results = objItemizedReportsBroker.AddFilingTransaction_LoanRepayment_Broker(objFilingTransactionsModel);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult UpdateLoanRepaymentsScheduledData(String txtFilerId, String strFilingSchedDate, String PaymentTypeId,
            String strPayNumber, String strAmt, String strAmtOrg, String strTransExplanation, String lstFilingEntId, String strFlngEntName, String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName,
            String strFlngEntStrName, String txtPartCity, String txtPartState,
            String txtPartZip5, String txtCountry, String chkCountry, String LoanerCodeID, String lstFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate, String loan_Lib_Number, String trans_Nubmer,String strElectionTypeId, string amountCheck)
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

                if (txtPartZip5 == "00000-0000")
                    txtPartZip5 = "";

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

                    if (txtPartZip5 != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.FomatZipcode(txtPartZip5))
                            {
                                ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                        }
                        if (txtPartZip5.Count() > 10)
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

                    if (txtPartZip5 != "")
                    {
                        if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                        {
                            ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                        }
                        if (txtPartZip5.Count() > 10)
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


                if (strAmtOrg == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(strAmtOrg))
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
                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OtherAmount = strAmtOrg;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ModifiedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.FilingSchedId = "10";
                    if (Session["FilingEntityID"] != null)
                    {
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntityID"].ToString();
                    }
                    else
                    {
                        objFilingTransactionsModel.FilingEntId = "";
                    }

                    objFilingTransactionsModel.FlngEntName = strFlngEntName;
                    objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                    objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.LoanOtherId = LoanerCodeID;

                    objFilingTransactionsModel.Loan_Lib_Number = loan_Lib_Number;
                    objFilingTransactionsModel.TransNumber = trans_Nubmer;
                    if (float.Parse(amountCheck) == float.Parse(strAmtOrg))
                    {
                        objFilingTransactionsModel.IsAmtChanged = "NO";
                    }
                    else
                    {
                        objFilingTransactionsModel.IsAmtChanged = "YES";
                    }

                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();
                    var results = objItemizedReportsBroker.UpdateLoanRepaymentDataBroker(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetSearchAmount(string FILING_ENTITY_NAME)
        {
            try
            {
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModelTemp = new List<GetSearchForScheduledIModel>();
                lstGetSearchForScheduledIModelTemp = (IList<GetSearchForScheduledIModel>)Session["EntityName"];
                lstGetSearchForScheduledIModelTemp = lstGetSearchForScheduledIModelTemp.Where(a => a.Name == FILING_ENTITY_NAME).ToList();
                lstGetSearchForScheduledIModel = objItemizedReportsBroker.GetAmount_SchedueledJBroker(FILING_ENTITY_NAME, lstGetSearchForScheduledIModelTemp[0].flng_Ent_FirstName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_MiddleName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_LastName,
                                                                                                        Session["FilerID"].ToString());
                return Json(new SelectList(lstGetSearchForScheduledIModel, "Amount", "Amount"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetSearchName()
        {
            try
            {
                //Bind Original Date
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                GetSearchForScheduledIModel objGetSearchForScheduledIModel = new GetSearchForScheduledIModel();
                //objGetSearchForScheduledIModel.FILING_TRANS_ID = "0";
                //objGetSearchForScheduledIModel.Name = "- Select -";
                //lstGetSearchForScheduledIModel.Add(objGetSearchForScheduledIModel);
                var rsName = objItemizedReportsBroker.GetName_SchedueledJBroker(Session["FilerID"].ToString());

                foreach (var item in rsName)
                {
                    if (item != null)
                    {
                        objGetSearchForScheduledIModel = new GetSearchForScheduledIModel();
                        objGetSearchForScheduledIModel.FILING_TRANS_ID = item.FILING_TRANS_ID;
                        objGetSearchForScheduledIModel.Name = item.Name;
                        objGetSearchForScheduledIModel.flng_Ent_FirstName = item.flng_Ent_FirstName;
                        objGetSearchForScheduledIModel.flng_Ent_MiddleName = item.flng_Ent_MiddleName;
                        objGetSearchForScheduledIModel.flng_Ent_LastName = item.flng_Ent_LastName;
                        lstGetSearchForScheduledIModel.Add(objGetSearchForScheduledIModel);
                    }
                }
                return Json(new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetSearchDate(string FILING_ENTITY_NAME, string ORG_AMT)
        {
            try
            {
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModelTemp = new List<GetSearchForScheduledIModel>();
                lstGetSearchForScheduledIModelTemp = (IList<GetSearchForScheduledIModel>)Session["EntityName"];
                lstGetSearchForScheduledIModelTemp = lstGetSearchForScheduledIModelTemp.Where(a => a.Name == FILING_ENTITY_NAME).ToList();
                lstGetSearchForScheduledIModel = objItemizedReportsBroker.GetDate_SchedueledJBroker(FILING_ENTITY_NAME, ORG_AMT, lstGetSearchForScheduledIModelTemp[0].flng_Ent_FirstName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_MiddleName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_LastName,
                                                                                                        Session["FilerID"].ToString());
                return Json(new SelectList(lstGetSearchForScheduledIModel, "Trans_Number", "Date"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetScheduleJ_EntityData(String trans_Number)
        {
            try
            {
                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                lstFilingTransactionsModel = objItemizedReportsBroker.GetScheduleJ_EntityDataBroker(trans_Number, Session["FilerID"].ToString());
                if (lstFilingTransactionsModel.Count > 0)
                {
                    Session["FilingEntityID"] = lstFilingTransactionsModel[0].FilingEntId.ToString();
                }
                else
                {
                    Session["FilingEntityID"] = "";
                }
                
                return Json(lstFilingTransactionsModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult ValidateSchedJ_Amount(String trans_Nubmer, String repayAmount, String OriginalAmount, String State)
        {
            try
            {
                decimal amtValidate, totalAmount = 0;

                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();

                if (State == "ADD")
                {
                    lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateSchedJ_AmountBroker(trans_Nubmer, "", Session["FilerID"].ToString());
                    amtValidate = decimal.Parse(lstGetSearchForScheduledIModel[0].Amount) + decimal.Parse(repayAmount);
                    if (amtValidate > decimal.Parse(OriginalAmount))
                    {
                        if (decimal.Parse(lstGetSearchForScheduledIModel[0].Amount) == decimal.Parse(OriginalAmount))
                        {
                            totalAmount = 1;
                        }
                        else
                        {
                            totalAmount = 0;
                        }
                    }
                    else
                    {
                        //totalAmount = amtValidate;
                        totalAmount = 1;
                        Session["RepayAmount"] = decimal.Parse(OriginalAmount) - amtValidate;
                    }
                }
                else if (State == "UPDATED")
                {
                    lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateSchedJ_AmountBroker(trans_Nubmer, "EDIT", Session["FilerID"].ToString());
                    if (repayAmount.ToString() == "")
                        repayAmount = "0";
                    amtValidate = decimal.Parse(lstGetSearchForScheduledIModel[0].Amount) + decimal.Parse(repayAmount);
                    if (amtValidate > decimal.Parse(OriginalAmount))
                    {
                        if (decimal.Parse(lstGetSearchForScheduledIModel[0].Amount) == decimal.Parse(OriginalAmount))
                        {
                            totalAmount = 1;
                        }
                        else
                        {
                            totalAmount = 0;
                        }
                    }
                    else
                    {
                        //totalAmount = amtValidate;
                        totalAmount = 1;
                        Session["RepayAmount"] = decimal.Parse(OriginalAmount) - amtValidate;
                    }

                    ////lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateForUpdateScheJBroker(trans_Nubmer);
                    //lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateSchedJ_AmountBroker(trans_Nubmer, "EDIT");
                    //amtValidate = Double.Parse(lstGetSearchForScheduledIModel[0].Amount) + Double.Parse(repayAmount);
                    //if (amtValidate > Double.Parse(lstGetSearchForScheduledIModel[0].Original_Amt))
                    //{                    
                    //    totalAmount = 0;
                    //}
                    //else
                    //{
                    //    totalAmount = amtValidate;
                    //    Session["RepayAmount"] = Double.Parse(lstGetSearchForScheduledIModel[0].Original_Amt) - amtValidate;
                    //}
                }


                return Json(totalAmount.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Get Outstanding amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public JsonResult GetOutstanding_Amount(String trans_Number, String status)
        {
            try
            {
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateSchedJ_AmountBroker(trans_Number, status, Session["FilerId"].ToString());
                //var outStandingAmt = Double.Parse(OriginalAmount) - Double.Parse(lstGetSearchForScheduledIModel[0].Amount);
                return Json(lstGetSearchForScheduledIModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        //public JsonResult GetEditOutstanding_Amount(String filing_Trans_ID)
        //{
        //    IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
        //    lstGetSearchForScheduledIModel = objItemizedReportsBroker.ValidateForUpdateScheJBroker(filing_Trans_ID);                        
        //    return Json(lstGetSearchForScheduledIModel, JsonRequestBehavior.AllowGet);
        //}


        /// <summary>
        /// Delete Filing Transaction
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult DeleteLoanRepayment(String strLoanLiabNumberOrg, String strTransNumber, String strRLiability)
        {
            try
            {
                Boolean results = objItemizedReportsBroker.DeleteLoanRepaymentBroker(strLoanLiabNumberOrg, strTransNumber, Session["UserName"].ToString(), Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult BindLoanerCode()
        {
            try
            {
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

                return Json(new SelectList(lstLoanerCodeModel, "LoanerID", "LoanerDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

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
                        //lstFilingTransactionDataModel[i].OriginalAmount = "$" + lstFilingTransactionDataModel[i].OriginalAmount + ".00";
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanRepaymentsSchedJController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetScheduleJHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleJHelpPopUp()
        {
            return View("GetScheduleJHelpPopUp");
        }
        #endregion GetScheduleJHelpPopUp
    }
}