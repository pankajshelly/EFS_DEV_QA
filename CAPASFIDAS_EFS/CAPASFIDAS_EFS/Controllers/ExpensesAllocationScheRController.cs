using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;


namespace CAPASFIDAS_EFS.Controllers
{
    public class ExpensesAllocationScheRController : Controller
    {
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /ExpensesAllocationScheR/
        public ActionResult ExpensesAllocationScheR()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        #region GetDefaultLookUpsValues
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
            ElectionYearModel objElectionYearModel;
            objElectionYearModel = new ElectionYearModel();
            objElectionYearModel.ElectionYearId = "0";
            objElectionYearModel.ElectionYearValue = "- Select -";
            lstElectionYearModel.Add(objElectionYearModel);
            var resultElectionYearModel = objItemizedReportsBroker.GetElectionYearDataResponse(Session["FilerID"].ToString());
            foreach (var item in resultElectionYearModel)
            {
                if (item != null)
                {
                    objElectionYearModel = new ElectionYearModel();
                    objElectionYearModel.ElectionYearId = item.ElectionYearId;
                    objElectionYearModel.ElectionYearValue = item.ElectionYearValue;
                    lstElectionYearModel.Add(objElectionYearModel);
                }
            }
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
            lstPaymentMethodModel = objItemizedReportsBroker.GetPaymentMethodDataResponse();
            // Payment Method
            ViewData["lstMethod"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");


            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
            lstContributorNameModel = objItemizedReportsBroker.GetContributionNameDataResponse();
            List<String> strIds = new List<String>() { "1", "2", "3", "5", "6", "8", "14" };
            lstContributorNameModel = lstContributorNameModel.Where(x => strIds.Contains(x.ContributorTypeId)).ToList();
            ViewData["lstContributionNameInKind"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc");

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
            CountyModel objCountyModel;
            objCountyModel = new CountyModel();
            objCountyModel.CountyId = "0";
            objCountyModel.CountyDesc = "- Select -";
            lstCountyModel.Add(objCountyModel);
            var resultlstCountyModel = objItemizedReportsBroker.GetCountyResponse();
            foreach (var item in resultlstCountyModel)
            {
                if (item != null)
                {
                    objCountyModel = new CountyModel();
                    objCountyModel.CountyId = item.CountyId;
                    objCountyModel.CountyDesc = item.CountyDesc;
                    lstCountyModel.Add(objCountyModel);
                }
            }
            // Bind County
            ViewData["lstUCCounty"] = new SelectList(lstCountyModel, "CountyId", "CountyDesc");

            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
            MunicipalityModel objMunicipalityModel;
            objMunicipalityModel = new MunicipalityModel();
            objMunicipalityModel.MunicipalityId = "0";
            objMunicipalityModel.MunicipalityDesc = "- Select -";
            lstMunicipalityModel.Add(objMunicipalityModel);
            var resultlstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(String.Empty);
            foreach (var item in resultlstMunicipalityModel)
            {
                if (item != null)
                {
                    objMunicipalityModel = new MunicipalityModel();
                    objMunicipalityModel.MunicipalityId = item.MunicipalityId;
                    objMunicipalityModel.MunicipalityDesc = item.MunicipalityDesc;
                    lstMunicipalityModel.Add(objMunicipalityModel);
                }
            }            
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

            // Bind Is Allocation Existing
            var lstAllocationExisting = new SelectList(new[]
                                          {
                                              new {ID="1",Name="No"},
                                              new {ID="2",Name="Yes"},                                              
                                          },
                            "ID", "Name", 1);
            ViewData["lstAllocationExisting"] = lstAllocationExisting;

            IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            //lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            //Session["SorList"] = lstSortColumnName;
            //Bind Column Name
            ViewData["lstSortColumnName"] = new SelectList(lstSortColumnName, "ViewableFieldID", "ColumnName");

            var lstSortColumnNameOrder = new SelectList(new[]
                                        {
                                            new {ID="asc",Name="Ascending "},
                                            new{ID="desc",Name="Descending"},
                                        },
                            "ID", "Name", 0);
            ViewData["lstSortColumnNameOrder"] = lstSortColumnNameOrder;

            IList<OfficeModel> lstOfficeModel = new List<OfficeModel>();
            OfficeModel objOfficeModel;
            objOfficeModel = new OfficeModel();
            objOfficeModel.OfficeId = "0";
            objOfficeModel.OfficeDesc = "- Select -";
            lstOfficeModel.Add(objOfficeModel);
            var resultlstOfficeModel = objItemizedReportsBroker.GetOfficesBroker("");
            foreach (var item in resultlstOfficeModel)
            {
                if (item != null)
                {
                    objOfficeModel = new OfficeModel();
                    objOfficeModel.OfficeId = item.OfficeId;
                    objOfficeModel.OfficeDesc = item.OfficeDesc;
                    lstOfficeModel.Add(objOfficeModel);
                }
            }            
            // Bind Office
            ViewData["lstOffice"] = new SelectList(lstOfficeModel, "OfficeId", "OfficeDesc");            

            ViewData["lstDistrict"] = lstAllocationExisting;
        }
        #endregion GetDefaultLookUpsValues
                

        /// <summary>
        /// Delete Filing Transaction
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult DeleteFilingTransactions(String transNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString();

                Boolean results = objItemizedReportsBroker.DeleteFilingTransactionsDataResponse(transNumber, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }       

        /// <summary>
        /// Add Amount Allocation Sched R
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strFilingSchedId"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="strFlngEntFirstName"></param>
        /// <param name="strFlngEntMiddleName"></param>
        /// <param name="strFlngEntLastName"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstElectYearId"></param>
        /// <param name="lstElectYear"></param>
        /// <param name="lstOfficeID"></param>
        /// <param name="lstDistrictID"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="lstFilingEntId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strFilingDate"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <param name="electionDateId"></param>
        /// <param name="lstResigTermType"></param>
        /// <param name="txtCuttOffDate"></param>
        /// <returns></returns>
        public JsonResult AddExpensesAllocationScheRData(String txtFilerId, String strFilingSchedId, String strFilingSchedDate,
            String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName, String lstOfficeTypeId, String lstFilingTypeId,
            String lstElectYearId, String lstElectYear, String lstOfficeID, String lstDistrictID,
            String strOrgAmt, String strTransExplanation, String lstFilingEntId, String strElectionTypeId, String strFilingDate, String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType,
            String txtCuttOffDate, String lstFilingDate, String lstUCMuncipality, String lstDiaSupportOppose, String parentTranID)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Select -")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                {
                    lstResigTermType = null;
                }
                if (lstDistrictID == "- Select -")
                {
                    lstDistrictID = "";
                }

                if (lstDiaSupportOppose == null)
                {
                    lstDiaSupportOppose = "";
                }

                if (parentTranID == null)
                {
                    parentTranID = "";
                }

                objFilingTransactionsModel.FilerId = txtFilerId;

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateAllocatedSchedR", "Date Allocated is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateAllocatedSchedR", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateAllocatedSchedR", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (strElectionTypeId == "6")
                {
                    if (strFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDateAllocatedSchedR", "Date Allocated cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, strFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDateAllocatedSchedR", "Date Allocated cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDateAllocatedSchedR", "Date Allocated cannot be later than Cut Off Date");
                }

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

                //if (strOrgAmt == "")
                //{
                //    ModelState.AddModelError("txtAmtExpensesAllocation", "Amount is required");
                //}
                //else if (!objCommonErrorsServerSide.AmountValidate(strOrgAmt))
                //{
                //    ModelState.AddModelError("txtAmtExpensesAllocation", "Enter valid Amount (999999999.99)");
                //}
                //else if (!objCommonErrorsServerSide.NumbersOnly(strOrgAmt))
                //{
                //    ModelState.AddModelError("txtAmtExpensesAllocation", "Enter valid Amount (999999999.99)");
                //}
                //else if (!objCommonErrorsServerSide.Amount12DigitVal(strOrgAmt))
                //{
                //    ModelState.AddModelError("txtAmtExpensesAllocation", "Enter valid Amount (999999999.99)");
                //}
                //else if (!objCommonErrorsServerSide.AmountZeroVal(strOrgAmt))
                //{
                //    ModelState.AddModelError("txtAmtExpensesAllocation", "Enter valid Amount (999999999.99)");
                //}

                if (strTransExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                    {
                        ModelState.AddModelError("txtExplanationCommonScheR", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                #endregion FormValidationScheduleA

                if (ModelState.IsValid)
                {
                    string results = string.Empty;
                    //Add Expenses Allocation Sched R                         
                    objFilingTransactionsModel.FilerId = txtFilerId;
                    objFilingTransactionsModel.FilingSchedId = "18";
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                    objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                    objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                    objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                    objFilingTransactionsModel.MunicipalityID = "";
                    objFilingTransactionsModel.ElectYearId = lstElectYearId;
                    objFilingTransactionsModel.ElectionYear = lstElectYear;
                    objFilingTransactionsModel.OfficeID = lstOfficeID;
                    objFilingTransactionsModel.DistrictID = lstDistrictID;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();

                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    //objFilingTransactionsModel.FilingDate = strFilingDate;
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
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;
                    objFilingTransactionsModel.SupportOppose = lstDiaSupportOppose;
                    objFilingTransactionsModel.TransNumber = parentTranID;

                    results = objItemizedReportsBroker.AddAmountAllocationSchedNBroker(objFilingTransactionsModel);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult UpdateExpensesAllocationScheRData(String transNumber, String strFilingSchedDate, String strOrgAmt,
            String strTransExplanation, String strSupportOppose)
        {
            try
            {
                var results = true;
                if (strFilingSchedDate == "")
                {
                    //lblErrFirstName.Text = "Error: Enter First Name";
                }
                else
                {
                    //Add Loan Received                
                    FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                    objFilingTransactionsModel.TransNumber = transNumber;
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();
                    objFilingTransactionsModel.SupportOppose = strSupportOppose;

                    results = objItemizedReportsBroker.UpdateAmountAllocationSchedNBroker(objFilingTransactionsModel);
                }
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

                IList<AutoCompleteSchedRModel> lstAutoCompleteSchedRModel = new List<AutoCompleteSchedRModel>();

                List<String> EntityNames;

                lstAutoCompleteSchedRModel = objItemizedReportsBroker.GetAutoCompleteSchedRBroker(term, strFilerId);

                Session["lstAutoCompleteSchedR"] = lstAutoCompleteSchedRModel;

                EntityNames = lstAutoCompleteSchedRModel.Select(x => x.EntityName).Distinct().ToList();

                return Json(EntityNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetAutoCompleteNameData(String strValue)
        {
            try
            {
                IList<AutoCompleteSchedRModel> lstAutoCompleteSchedRModel = new List<AutoCompleteSchedRModel>();

                lstAutoCompleteSchedRModel = (IList<AutoCompleteSchedRModel>)Session["lstAutoCompleteSchedR"];

                String strResult = "";
                String strElectYear = "";
                String strOfficeID = "";
                String strDistrict = "";
                if (lstAutoCompleteSchedRModel.Count > 0)
                {
                    strResult = lstAutoCompleteSchedRModel.Where(x => x.EntityName == strValue).Select(x => x.FilingEntityId).FirstOrDefault().ToString();
                    strElectYear = lstAutoCompleteSchedRModel.Where(x => x.EntityName == strValue).Select(x => x.ElectionYear).FirstOrDefault().ToString();
                    strOfficeID = lstAutoCompleteSchedRModel.Where(x => x.EntityName == strValue).Select(x => x.Office_ID).FirstOrDefault().ToString();
                    strDistrict = lstAutoCompleteSchedRModel.Where(x => x.EntityName == strValue).Select(x => x.Dist_ID).FirstOrDefault().ToString();
                    Session["FilingEntId"] = strResult;
                    lstAutoCompleteSchedRModel = lstAutoCompleteSchedRModel.Where(x => x.FilingEntityId == strResult && x.ElectionYear == strElectYear && x.Office_ID == strOfficeID && x.Dist_ID == strDistrict).ToList();
                }
                else
                {
                    Session["FilingEntId"] = strResult;
                }

                return Json(lstAutoCompleteSchedRModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult CaluclateAllAmount(String firstName, String middleName, String lastName, String electYear, String officeID, String distID)
        {
            try
            {
                double totalAmt=0;
                if (distID == "- Select -" || distID == null || distID =="None")
                    distID = "";
                String strFilerId = Session["FilerId"].ToString();         

                IList<AutoCompleteSchedRModel> lstAutoCompleteSchedRModel = new List<AutoCompleteSchedRModel>();

                lstAutoCompleteSchedRModel = objItemizedReportsBroker.GetAutoCompleteSchedRBroker(firstName, strFilerId);

                if (lstAutoCompleteSchedRModel.Count > 0)
                {
                    //totalAmt = lstAutoCompleteSchedRModel.Where(x => x.FirstName == firstName
                    //                                                 && x.MiddleName == middleName
                    //                                                 && x.LastName == lastName
                    //                                                 && x.ElectionYear == electYear
                    //                                                 && x.Office_ID == officeID).Select(x => x.Org_Amt).FirstOrDefault().ToString();

                    lstAutoCompleteSchedRModel = lstAutoCompleteSchedRModel.Where(x => x.FirstName == firstName
                                                                     && x.MiddleName == middleName
                                                                     && x.LastName == lastName
                                                                     && x.ElectionYear == electYear
                                                                     && x.Office_ID == officeID
                                                                     && x.Dist_ID == distID).ToList();

                    //if (distID != "")
                    //{
                    //    lstAutoCompleteSchedRModel = lstAutoCompleteSchedRModel.Where(x => x.FirstName == firstName
                    //                                                 && x.MiddleName == middleName
                    //                                                 && x.LastName == lastName
                    //                                                 && x.ElectionYear == electYear
                    //                                                 && x.Office_ID == officeID
                    //                                                 && x.Dist_ID == distID).ToList();
                    //}
                    //else
                    //{
                    //    lstAutoCompleteSchedRModel = lstAutoCompleteSchedRModel.Where(x => x.FirstName == firstName
                    //                                                 && x.MiddleName == middleName
                    //                                                 && x.LastName == lastName
                    //                                                 && x.ElectionYear == electYear
                    //                                                 && x.Office_ID == officeID
                    //                                                 && x.Dist_ID == distID).ToList();
                    //}

                    foreach (var item in lstAutoCompleteSchedRModel)
                    {
                        if (item != null)
                        {
                            //totalAmt = totalAmt + Convert.ToDouble(item.Org_Amt);
                            totalAmt = Convert.ToDouble(item.Org_Amt);
                        }
                    }
                }

                return Json(totalAmt.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Get District
        /// </summary>
        /// <param name="strOfficeID"></param>
        /// <returns></returns>
        public JsonResult GetDistrict(String strOfficeID)
        {
            try
            {
                IList<DistrictModel> lstDistrictModel = new List<DistrictModel>();
                lstDistrictModel = objItemizedReportsBroker.GetDistrictsForOfficeBroker(strOfficeID);
                if (lstDistrictModel.Count == 1)
                {
                    if (lstDistrictModel[0].District_ID == "")
                    {
                        lstDistrictModel = new List<DistrictModel>();
                    }
                }
                // Bind District
                return Json(new SelectList(lstDistrictModel, "District_ID", "District_ID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetScheduleRHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleRHelpPopUp()
        {
            return View("GetScheduleRHelpPopUp");
        }
        #endregion GetScheduleRHelpPopUp

        #region "AlreadyExists"
        // FUNCTION DETERMINES IF AN ELECTION ALREADY EXISTS FOR THE PARAMETERS
        public String ScheduleRAlreadyExists(String strFirstName,
                                             String strLastName, 
                                             String strMiddleName,
                                             String strElectionYearID,
                                             String strOfficeID, 
                                             String strDistrictID,
                                             String strAllocationExists,
                                             String validateCheck)
        {
            try
            {
                if (strDistrictID == "- Select -")
                {
                    strDistrictID = "";
                }
                else if (strDistrictID == "0")
                {
                    strDistrictID = "";
                }

                SchedR_ISExists_Model objSchedR_ISExists_Model = new SchedR_ISExists_Model();
                objSchedR_ISExists_Model.FilerId = Session["FilerID"].ToString();
                objSchedR_ISExists_Model.ReportYearId = strElectionYearID;
                objSchedR_ISExists_Model.Filing_Enty_First_Name = strFirstName;
                objSchedR_ISExists_Model.Filing_Enty_Middle_Name = strMiddleName;
                objSchedR_ISExists_Model.Filing_Enty_Last_Name = strLastName;
                objSchedR_ISExists_Model.Office_Id = strOfficeID;
                objSchedR_ISExists_Model.District_Id = strDistrictID;
                String results = objItemizedReportsBroker.GetSchedR_Exists_Broker(objSchedR_ISExists_Model);
                if (results == "YES" && strAllocationExists == "2" && validateCheck == "false")
                {   
                    results = "DUPLICATE";
                }
                else if (results == "YES" && strAllocationExists == "2")
                {
                    results = "NO";
                }
                else if (results == "NO" && strAllocationExists == "2")
                {
                    results = "EXISTS";
                }
                else if (results == "YES" && strAllocationExists == "1")
                {
                    results = "NO";
                }

                return results;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpensesAllocationScheRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

    }
}