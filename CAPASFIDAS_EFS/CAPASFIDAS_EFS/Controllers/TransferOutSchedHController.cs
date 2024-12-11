using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class TransferOutSchedHController : Controller
    {
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /TransferOutSchedH/
        [HttpGet]
        public ActionResult TransferOutSchedH()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferOutSchedHController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        #region GetDefaultLookUpsValues
        public void GetDefaultLookUpsValues()
        {
            try
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
                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(),"");
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
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferOutSchedHController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
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
        public JsonResult AddTransferOutScheduledData(String txtFilerId, String strFilingSchedId, String strTransferTypeId, String strFilingSchedDate,
            String strPayNumber, String strOrgAmt, String strTransExplanation, String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId,
            String lstElectYearId, String lstFilingEntId, String strFlngEntName, String strFlngEntStrName, String txtPartCity, String txtPartState,
            String txtPartZip, String txtCountry, String chkCountry, String PaymentTypeId, String strFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate, String lstFilingDate, String lstElectionType, String lstUCMuncipality)
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

                if (lstFilingDate != null)
                    lstFilingDate = lstFilingDate.Trim();

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (txtPartZip == "00000-0000")
                    txtPartZip = "";

                objFilingTransactionsModel.FilerId = txtFilerId;

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (strElectionTypeId == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred cannot be later than Cut Off Date");
                }

                if (strFlngEntName == "")
                {
                    ModelState.AddModelError("txtTransfereeName", "Transferor Name is required");
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
                        ModelState.AddModelError("txtExplanationCommon", "Explanation is required");
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
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.FilingSchedId = "8";
                    if (strTransferTypeId == "0")
                    {
                        objFilingTransactionsModel.TransferTypeId = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.TransferTypeId = strTransferTypeId;
                    }
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
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    if (PaymentTypeId == "0")
                    {
                        objFilingTransactionsModel.PaymentTypeId = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    }

                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (strFilingDate == "- New Filing Date -")
                            objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                        else
                            objFilingTransactionsModel.FilingDate = strFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    }

                    //objFilingTransactionsModel.FilingDate = strFilingDate;
                    objFilingTransactionsModel.ElectionDateId = electionDateId;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    if (lstElectionType == "6") // OFF-CYCLE FILING DATE
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
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;

                    results = objItemizedReportsBroker.AddFilingTransaction_TransferOut_Broker(objFilingTransactionsModel);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferOutSchedHController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult UpdateTransferOutScheduledData(String txtFilerId, String strTransferTypeId, String strFilingSchedDate,
            String strPayNumber, String strOrgAmt, String strTransExplanation, String strElectionTypeId, String lstFilingEntId,
            String strFlngEntName, String strFlngEntStrName, String txtPartCity, String txtPartState,
            String txtPartZip, String txtCountry, String chkCountry, String transNumber, String PaymentTypeId, String strFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate)
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

                objFilingTransactionsModel.FilerId = txtFilerId;

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (strElectionTypeId == "6")
                {
                    if (strFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, strFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDateTransferred", "Date Transferred cannot be later than Cut Off Date");
                }

                if (strFlngEntName == "")
                {
                    ModelState.AddModelError("txtTransfereeName", "Transferor Name is required");
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
                        ModelState.AddModelError("txtExplanationCommon", "Explanation is required");
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
                if (ModelState.IsValid)
                {
                    if (strTransferTypeId == "0")
                    {
                        objFilingTransactionsModel.TransferTypeId = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.TransferTypeId = strTransferTypeId;
                    }
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    objFilingTransactionsModel.FilingEntId = lstFilingEntId;
                    objFilingTransactionsModel.FlngEntName = strFlngEntName;
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.TransNumber = transNumber;
                    if (PaymentTypeId == "0")
                    {
                        objFilingTransactionsModel.PaymentTypeId = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    }

                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();

                    var results = objItemizedReportsBroker.UpdateFilingTransaction_TransferOut_Broker(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferOutSchedHController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }


        /// <summary>
        /// AutoCompleteEntityName
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteEntityName(String term)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString(); // Testing only
                String strFLName = "EName";

                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                List<String> EntityNames;

                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);

                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;

                EntityNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                return Json(EntityNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferOutSchedHController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetScheduleHHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleHHelpPopUp()
        {
            try
            {
                return View("GetScheduleHHelpPopUp");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferOutSchedHController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetScheduleHHelpPopUp
    }
}