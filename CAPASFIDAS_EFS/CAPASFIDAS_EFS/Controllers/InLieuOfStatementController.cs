/*
 * =====================================================================
 * PAGE NAME: IN-LIEU-OF STATEMENT (NON-ITEMIZED TRANSACTIONS EFS)
 * AUTHOR NAME: SATHEESH K BASIREDDY
 * CREATED DATE: 03/30/2018
 * UPDATED BY:
 * UPDATED DATE:
 * =========================================================================
 * 
*/

#region Namespaces
using Broker;
using CAPASFIDAS_EFS.CommonErrors;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;

#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    public class InLieuOfStatementController : Controller
    {

        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Variables

        #region InLieuOfStatement
        /// <summary>
        /// InLieuOfStatement
        /// </summary>
        /// <returns></returns>
        // GET: InLieuOfStatement
        public ActionResult InLieuOfStatement()
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
                    //Session["PersonId"] = "18099"; // Testing only replace with main Session (Login).
                    //Session["PersonId"] = "4929"; //"23161";
                    //Session["FilerId"] = "113070"; // Testing only replace with main Session (Login).

                    GetDefaultLookUpsValues();
                }
                return View("InLieuOfStatement");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "InLieuOfStatementController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion InLieuOfStatement

        #region GetInLieuOfStatement
        /// <summary>
        /// GetInLieuOfStatement
        /// </summary>
        /// <returns></returns>
        public JsonResult GetInLieuOfStatement(String txtFilerID, String lstElectionDate, String lstElectionCycle, String lstElectionType,
            String strElectionYear, String lstUCOfficeType, String lstDisclosurePeriod, String lstFilingDate, String txtFilingDate)
        {
            try
            {
                IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

                String strFilingDate = String.Empty;

                if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        strFilingDate = txtFilingDate;
                    else
                        strFilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    strFilingDate = txtFilingDate;
                }

                lstInLieuOfStatementNonItemModel = objItemizedReportsBroker.GetInLieuOfStatementDataResponse(txtFilerID, lstElectionDate,
                    lstElectionCycle, strElectionYear, lstElectionType, lstUCOfficeType, lstDisclosurePeriod, strFilingDate);

                return Json(new
                {
                    aaData = lstInLieuOfStatementNonItemModel.Select(x => new[] {
                    x.FilingsId,
                    "",
                    x.ElectionYear,
                    x.OfficeType,
                    x.ElectionType,
                    x.ElectionDate,
                    x.DisclosurePeriod,
                    x.DateSubmitted
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "InLieuOfStatementController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetInLieuOfStatement

        #region AddInLieuOfStatementData
        /// <summary>
        /// AddInLieuOfStatementData
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstDisclosureType"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="lstUCCounty"></param>
        /// <param name="lstUCMuncipality"></param>
        /// <returns></returns>
        public JsonResult AddInLieuOfStatementData(String txtFilerID, String lstElectionDate,
            String lstElectionType, String lstUCOfficeType, String lstDisclosurePeriod,
            String lstDisclosureType, String lstElectionCycle, String strElectionYear,
            String lstUCCounty, String lstUCMuncipality, String lstElectionDateId, String txtReportPeriodDatesTo, String lstFilingDate)
        {
            try
            {
                AddInLieuOfStatementModel objAddInLieuOfStatementModel;

                if (lstUCOfficeType != "2")
                {
                    lstUCCounty = null;
                    lstUCMuncipality = null;
                }

                #region Form Server-Side Validations In-Liue-Off Statement
                if (txtFilerID != null)
                {
                    if (txtFilerID != "")
                    {
                        if (txtFilerID != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("REQUIRED_FILER", txtFilerID.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("txtFilerID", "Invalid Filer Id");
                            }
                        }
                    }
                }
                if (lstElectionDate != null)
                {
                    if (lstElectionDate != "")
                    {
                        if (lstElectionDate != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_DATES_DATE", lstElectionDate.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstElectionDate", "Invalid Election Date");
                            }
                        }
                    }
                }
                if (lstElectionType != null)
                {
                    if (lstElectionType != "")
                    {
                        if (lstElectionType != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_TYPE", lstElectionType.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstElectionType", "Invalid Election Type");
                            }
                        }
                    }
                }
                if (lstUCOfficeType != null)
                {
                    if (lstUCOfficeType != "")
                    {
                        if (lstUCOfficeType != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("OFFICE_TYPE", lstUCOfficeType.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstUCOfficeType", "Invalid Office Type");
                            }
                        }
                    }
                }
                if (lstDisclosurePeriod != null)
                {
                    if (lstDisclosurePeriod != "")
                    {
                        if (lstDisclosurePeriod != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TYPE", lstDisclosurePeriod.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstDisclosurePeriod", "Invalid Disclosure Period");
                            }
                        }
                    }
                }
                if (lstDisclosureType != null)
                {
                    if (lstDisclosureType != "")
                    {
                        if (lstDisclosureType != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_CATEGORY", lstDisclosureType.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstDisclosureType", "Invalid Filing Type");
                            }
                        }
                    }
                }
                if (lstElectionCycle != null)
                {
                    if (lstElectionCycle != "")
                    {
                        if (lstElectionCycle != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_YEAR_YEAR", lstElectionCycle.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstElectionCycle", "Invalid Election Year");
                            }
                        }
                    }
                }
                if (strElectionYear != null)
                {
                    if (strElectionYear != "")
                    {
                        if (strElectionYear != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_YEAR", strElectionYear.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("strElectionYear", "Invalid Election Year Id");
                            }
                        }
                    }
                }
                if (lstUCCounty != null)
                {
                    if (lstUCCounty != "")
                    {
                        if (lstUCCounty != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("COUNTY", lstUCCounty.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstUCCounty", "Invalid County");
                            }
                        }
                    }
                }
                if (lstUCMuncipality != null)
                {
                    if (lstUCMuncipality != "")
                    {
                        if (lstUCMuncipality != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("MUNICIPALITY", lstUCMuncipality.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstUCMuncipality", "Invalid Municipality");
                            }
                        }
                    }
                }
                #endregion Form Server-Side Validations In-Liue-Off Statement

                if (ModelState.IsValid)
                {
                    objAddInLieuOfStatementModel = new AddInLieuOfStatementModel();
                    objAddInLieuOfStatementModel.FilerId = txtFilerID;
                    objAddInLieuOfStatementModel.ElectionDate = lstElectionDate;
                    objAddInLieuOfStatementModel.ElectionTypeId = lstElectionType;
                    objAddInLieuOfStatementModel.OfficeTypeId = lstUCOfficeType;
                    objAddInLieuOfStatementModel.FilingTypeId = lstDisclosurePeriod;
                    objAddInLieuOfStatementModel.FilingCategoryId = lstDisclosureType;
                    objAddInLieuOfStatementModel.ElectYearId = strElectionYear;
                    objAddInLieuOfStatementModel.ElectionYear = lstElectionCycle;
                    objAddInLieuOfStatementModel.CountyId = lstUCCounty;
                    objAddInLieuOfStatementModel.MunicipalityId = lstUCMuncipality;
                    objAddInLieuOfStatementModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing Only....
                    objAddInLieuOfStatementModel.ElectionDateId = lstElectionDateId;
                    if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            objAddInLieuOfStatementModel.FilingDate = txtReportPeriodDatesTo;
                        else
                            objAddInLieuOfStatementModel.FilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        objAddInLieuOfStatementModel.FilingDate = txtReportPeriodDatesTo;
                    }
                    /*objAddInLieuOfStatementModel.FilingDate = txtReportPeriodDatesTo;*/ // CHANGE LATER THIS.

                    var results = objItemizedReportsBroker.AddInLieuOfStatementResponse(objAddInLieuOfStatementModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "InLieuOfStatementController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AddInLieuOfStatementData

        #region DeleteInLieuOfStatementData
        /// <summary>
        /// DeleteInLieuOfStatementData
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        public JsonResult DeleteInLieuOfStatementData(String strFilingsId)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing ONly...

                var results = objItemizedReportsBroker.DeleteInLieuOfStatementResponse(strFilingsId, strModifiedBy);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "InLieuOfStatementController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteInLieuOfStatementData

        #region GetPersonNameTreasureYN
        /// <summary>
        /// GetPersonNameTreasureYN
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPersonNameTreasureYN()
        {
            try
            {
                String strPersonId = Session["PersonId"].ToString();

                var results = objItemizedReportsBroker.GetPersonNameAndTreasurerDataResponse(strPersonId);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "InLieuOfStatementController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPersonNameTreasureYN

        #region GetItemizedSubmitted
        /// <summary>
        /// GetItemizedSubmitted
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public JsonResult GetItemizedSubmitted(String strFilerId, String strElectionYearId, String strOfficeTypeId,
            String strFilingTypeId, String strFilingCatId, String strElectTypeID)
        {
            try
            {
                Boolean results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                    strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectTypeID);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "InLieuOfStatementController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemizedSubmitted

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

            IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
            // Bind Transaction Type
            ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");
                       
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
            lstPaymentMethodModel = objItemizedReportsBroker.GetPaymentMethodDataResponse();
            // Payment Method
            ViewData["lstMethod"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");

            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
            lstContributorNameModel = objItemizedReportsBroker.GetContributionNameDataResponse();
            // Bind Contribution Name
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
            if (Session["ElectionYearId"] != null && Session["FilerIdOffCycle"] != null && Session["OfficeTypeId"] != null && Session["DisclosureType"] != null)
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


            // Sortable Columns.
            IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            Session["SorList"] = lstSortColumnName;
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
        #endregion GetDefaultLookUpsValues

    }
}