/*
 * =====================================================================
 * PAGE NAME: NOTICE OF NON-PARTICIPATION IN ELECTION(S) (NON-ITEMIZED TRANSACTIONS EFS)
 * AUTHOR NAME: SATHEESH K BASIREDDY
 * CREATED DATE: 04/18/2018
 * UPDATED BY: SATHEESH BASIREDDY
 * UPDATED DATE:
 * UPDATED BY: 
 * =========================================================================
 * 
*/

#region Namespaces
using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;
#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    public class NoticeOfNonParticipationController : Controller
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

        #region NoticeOfNonParticipation
        /// <summary>
        /// NoticeOfNonParticipation
        /// </summary>
        /// <returns></returns>
        // GET: NoticeOfNonParticipation
        public ActionResult NoticeOfNonParticipation()
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
                return View("NoticeOfNonParticipation");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NoticeOfNonParticipationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion NoticeOfNonParticipation

        #region GetNonParticipation
        /// <summary>
        /// GetNonParticipation
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <returns></returns>
        public JsonResult GetNonParticipation(String txtFilerID, String lstElectionDate, String lstElectionCycle, String lstElectionType,
            String strElectionYear, String lstUCOfficeType, String lstDisclosurePeriod, String lstUCCounty, String lstUCMuncipality)
        {
            try
            {
                IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

                lstInLieuOfStatementNonItemModel = objItemizedReportsBroker.GetNoticeOfNonParticipationtDataResponse(txtFilerID, lstElectionDate,
                    lstElectionCycle, strElectionYear, lstElectionType, lstUCOfficeType, lstDisclosurePeriod, lstUCCounty, lstUCMuncipality);

                return Json(new
                {
                    aaData = lstInLieuOfStatementNonItemModel.Select(x => new[] {
                    x.FilingsId,
                    "",
                    x.ElectionYear,
                    x.OfficeType,
                    x.ElectionType,
                    x.DisclosurePeriod,
                    x.ElectionDate,
                    x.DateSubmitted
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NoticeOfNonParticipationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetNonParticipation

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
            String strFilingTypeId, String strElectionType, String strFilingCatId)
        {
            try
            {
                Boolean results;
                String strPrimaryOrGeneral = String.Empty;

                if (strFilingTypeId != null)
                {
                    results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                    strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                }
                else
                {
                    // IF ELECTION TYPE 'PRIMARY AND GENERAL' THEN....
                    // CHECK BOTH PRIMARY AND GENERAL ITEMIZED FILED OR NOT....
                    // IF PRIMARY THEN CHECK ALL PRIMARY DISCLOSURE PERIODS....
                    // IF GENERAL THEN CHECK ALL GENERAL DISCLOSURE PERIODS...           

                    if (strElectionType == "8")
                    {
                        strFilingTypeId = "1"; // 32-DAY PRE-PRIMARY
                        results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                        strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                        strPrimaryOrGeneral = "Primary";
                        if (!results)
                        {
                            strFilingTypeId = "2"; // 11-DAY PRE-PRIMARY
                            results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                            strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                            strPrimaryOrGeneral = "Primary";
                            if (!results)
                            {
                                strFilingTypeId = "3"; // 10-DAY POST-PRIMARY
                                results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                strPrimaryOrGeneral = "Primary";
                                if (!results)
                                {
                                    strFilingTypeId = "4"; // 32-DAY PRE-GENERAL
                                    results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                    strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                    strPrimaryOrGeneral = "General";
                                    if (!results)
                                    {
                                        strFilingTypeId = "5"; // 11-DAY PRE-GENERAL
                                        results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                        strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                        strPrimaryOrGeneral = "General";
                                        if (!results)
                                        {
                                            strFilingTypeId = "6"; // 10-DAY POST-GENERAL
                                            results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                            strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                            strPrimaryOrGeneral = "General";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (strElectionType == "2")
                        {
                            strFilingTypeId = "1"; // 32-DAY PRE-PRIMARY
                            results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                            strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                            strPrimaryOrGeneral = "Primary";
                            if (!results)
                            {
                                strFilingTypeId = "2"; // 11-DAY PRE-PRIMARY
                                results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                strPrimaryOrGeneral = "Primary";
                                if (!results)
                                {
                                    strFilingTypeId = "3"; // 10-DAY POST-PRIMARY
                                    results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                    strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                    strPrimaryOrGeneral = "Primary";
                                }
                            }
                        }
                        else if (strElectionType == "3")
                        {
                            strFilingTypeId = "4"; // 32-DAY PRE-GENERAL
                            results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                            strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                            strPrimaryOrGeneral = "General";
                            if (!results)
                            {
                                strFilingTypeId = "5"; // 11-DAY PRE-GENERAL
                                results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                strPrimaryOrGeneral = "General";
                                if (!results)
                                {
                                    strFilingTypeId = "6"; // 10-DAY POST-GENERAL
                                    results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                    strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                    strPrimaryOrGeneral = "General";
                                }
                            }
                        }
                        if (strElectionType == "9")
                        {
                            strFilingTypeId = "1"; // 32-DAY PRE-PRIMARY
                            results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                            strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                            strPrimaryOrGeneral = "August Primary";
                            if (!results)
                            {
                                strFilingTypeId = "2"; // 11-DAY PRE-PRIMARY
                                results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                strPrimaryOrGeneral = "August Primary";
                                if (!results)
                                {
                                    strFilingTypeId = "3"; // 10-DAY POST-PRIMARY
                                    results = objItemizedReportsBroker.GetItemizedTransSubmittedResponse(strFilerId,
                                    strElectionYearId, strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectionType);
                                    strPrimaryOrGeneral = "August Primary";
                                }
                            }
                        }
                        else
                        {
                            results = false;
                        }
                    }
                }

                if (results != true)
                    strPrimaryOrGeneral = String.Empty;

                return Json(strPrimaryOrGeneral, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NoticeOfNonParticipationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemizedSubmitted

        #region AddNonParticipationData
        /// <summary>
        /// AddNonParticipationData
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
        [HttpPost]
        public JsonResult AddNonParticipationData(String txtFilerID, String lstElectionDate,
            String lstElectionType, String lstUCOfficeType, String lstDisclosurePeriod,
            String lstDisclosureType, String lstElectionCycle, String strElectionYear,
            String lstUCCounty, String lstUCMuncipality, String lstElectionDateId, String txtReportPeriodDatesTo)
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
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_CATEGORY", lstDisclosurePeriod.ToString());
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
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TYPE", lstDisclosureType.ToString());
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
                    objAddInLieuOfStatementModel.CreatedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing Only....
                    objAddInLieuOfStatementModel.ElectionDateId = lstElectionDateId;                    

                    var results = objItemizedReportsBroker.AddNoticeOfNonParticipationResponse(objAddInLieuOfStatementModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NoticeOfNonParticipationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AddNonParticipationData

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NoticeOfNonParticipationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPersonNameTreasureYN

        #region DeleteNonParticipationData
        /// <summary>
        /// DeleteNonParticipationData
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        public JsonResult DeleteNonParticipationData(String strFilingsId)
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NoticeOfNonParticipationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteNonParticipationData
        
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