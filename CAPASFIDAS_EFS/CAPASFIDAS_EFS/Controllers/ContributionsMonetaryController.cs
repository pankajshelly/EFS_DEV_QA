using Broker;
using CAPASFIDAS_EFS.CommonErrors;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Net;
using System.Web.UI;

namespace CAPASFIDAS_EFS.Controllers
{
    public class ContributionsMonetaryController : Controller
    {
        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        #endregion Global Variables


        #region ContributionsMonetary
        /// <summary>
        /// ContributionsMonetary
        /// </summary>
        /// <returns></returns>
        //
        // GET: /ContributionsMonetary/
        public ActionResult ContributionsMonetary()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion ContributionsMonetary                

        #region GetFilerIdData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFilerIdData()
        {
            IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
            try
            {   
                lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserName"].ToString());
                ViewBag.lstFilerID = Session["FilerID"].ToString();
                ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
                ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
                Session["AuthenticatedFilerID"] = lstValidateFilerInfo[0].FilerID.ToString();
                Session["AuthenticatedCommitteeName"] = lstValidateFilerInfo[0].Name.ToString();
                return Json(new SelectList(lstValidateFilerInfo, "FilerID", "FilerID"), JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilerIdData

        #region GetTransactionTypeBind
        /// <summary>
        /// GetTransactionTypeBind
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTransactionTypeBind()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
                String strCandCommId = Session["FilerId"].ToString();
                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(strCandCommId); ; //GetTransactionTypeData();
                                                                                                                     // Bind Transaction Type Itemized Transactions.
                return Json(new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetTransactionTypeBind

        #region BindTransactionTypes24HNotice
        /// <summary>
        /// BindTransactionTypes24HNotice
        /// </summary>
        /// <returns></returns>
        public JsonResult BindTransactionTypes24HNotice()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();

                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypes24HNoticeDataResponse();

                return Json(new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion BindTransactionTypes24HNotice

        #region BindTransactionTypes24HContribution
        /// <summary>
        /// BindTransactionTypes24HContribution
        /// </summary>
        /// <returns></returns>
        public JsonResult BindTransactionTypes24HContribution()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();

                lstTransactionTypeModel = objItemizedReportsBroker.GetIE24HContrTransactionTypesResponse();

                return Json(new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion BindTransactionTypes24HContribution

        #region BindTransactionTypesIEWeeklyContr
        /// <summary>
        /// BindTransactionTypesIEWeeklyContr
        /// </summary>
        /// <returns></returns>
        public JsonResult BindTransactionTypesIEWeeklyContr()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();

                lstTransactionTypeModel = objItemizedReportsBroker.GetIEWeeklyExpTransactionTypesResponse();

                return Json(new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion BindTransactionTypesIEWeeklyContr

        #region BindTransactionTypesIEWeeklyLiabIncur
        /// <summary>
        /// BindTransactionTypesIEWeeklyLiabIncur
        /// </summary>
        /// <returns></returns>
        public JsonResult BindTransactionTypesIEWeeklyLiabIncur()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();

                lstTransactionTypeModel = objItemizedReportsBroker.GetIEWeeklyLiabInccrTransactionTypesResponse();

                return Json(new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion BindTransactionTypesIEWeeklyLiabIncur

        #region GetFilerCommitteeData
        /// <summary>
        /// GetFilerCommitteeData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFilerCommitteeData(String txtFilerID)
        {
            try
            {
                IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();

                lstFilerCommitteeModel = (IList<FilerCommitteeModel>)Session["PersonFilerId"];

                lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == txtFilerID).ToList();

                Session["CommitteeDataInLieuOf"] = lstFilerCommitteeModel;

                // Candidate/Committee Name            
                return Json(new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilerCommitteeData

        #region GetItemizedIETransactionsData
        /// <summary>
        /// GetItemizedIETransactionsData
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetItemizedIETransactionsData(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String lstUCMuncipality, String txtReportPeriodDatesTo, String lstFilingDate, String txtNewFilingDate)
        {

            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                if (strElectionDateId != "- Select -")
                {
                    String strFilingDate = String.Empty;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            strFilingDate = txtNewFilingDate;
                        else
                            strFilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        strFilingDate = txtReportPeriodDatesTo;
                    }

                    lstFilingTransactionDataModel = objItemizedReportsBroker.GetItemizedNonItemIETransactionsResponse(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, lstUCMuncipality, strFilingDate);

                    if (lstFilingTransactionDataModel.Count > 0)
                    {
                        for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                        {
                            if (lstFilingTransactionDataModel[i] != null)
                            {
                                if (lstFilingTransactionDataModel[i].SchedDate.Contains("01/01/1900"))
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = "";
                                }
                                else if (lstFilingTransactionDataModel[i].SchedDate == "")
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = "";
                                }
                                else
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = Convert.ToDateTime(lstFilingTransactionDataModel[i].SchedDate).ToString("MM/dd/yyyy");
                                }

                                lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                            }
                        }
                    }

                    Session["ItemizedIETransactions"] = lstFilingTransactionDataModel;
                }

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    "",
                    x.IEType,
                    x.TreasurerName,
                    x.ContributorName,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.SchedDate,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.OriginalAmount,
                    x.TransExplanation,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemizedIETransactionsData

        #region GetItemized24HoursTransactionsData
        /// <summary>
        /// GetItemized24HoursTransactionsData
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetItemized24HoursTransactionsData(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String lstUCMuncipality, String txtReportPeriodDatesTo, String lstFilingDate, String txtNewFilingDate)
        {

            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                if (strElectionDateId != "- Select -")
                {
                    String strFilingDate = String.Empty;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            strFilingDate = txtNewFilingDate;
                        else
                            strFilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        strFilingDate = txtReportPeriodDatesTo;
                    }

                    lstFilingTransactionDataModel = objItemizedReportsBroker.GetItemizedNonItemIETransactionsResponse(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, lstUCMuncipality, strFilingDate);
                    lstFilingTransactionDataModel = lstFilingTransactionDataModel.Where(x => x.IEType.ToString() == "24-Hour Notice").ToList();
                    if (lstFilingTransactionDataModel.Count > 0)
                    {
                        for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                        {
                            if (lstFilingTransactionDataModel[i] != null)
                            {
                                if (lstFilingTransactionDataModel[i].SchedDate.Contains("01/01/1900"))
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = "";
                                }
                                else if (lstFilingTransactionDataModel[i].SchedDate == "")
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = "";
                                }
                                else
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = Convert.ToDateTime(lstFilingTransactionDataModel[i].SchedDate).ToString("MM/dd/yyyy");
                                }

                                lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                            }
                        }
                    }

                    Session["Itemized24HoursTransactions"] = lstFilingTransactionDataModel;
                }

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    "",
                    x.IEType,                    
                    x.ContributorName,                    
                    x.SchedDate,                    
                    x.OriginalAmount,
                    x.TransExplanation,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemized24HoursTransactionsData

        #region GetItemizedWeeklyClaimSubData
        /// <summary>
        /// GetItemizedWeeklyClaimSubData
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetItemizedWeeklyClaimSubData(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String lstUCMuncipality)
        {

            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                //if (strElectionDateId != "- Select -")
                //{
                    //lstFilingTransactionDataModel = objItemizedReportsBroker.GetItemizedWCSTransBroker(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, lstUCMuncipality);

                    lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["ItemizedWCSTrans"];

                    if (lstFilingTransactionDataModel.Count > 0)
                    {
                        for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                        {
                            if (lstFilingTransactionDataModel[i] != null)
                            {
                                if (lstFilingTransactionDataModel[i].SchedDate.Contains("01/01/1900"))
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = "";
                                }
                                else if (lstFilingTransactionDataModel[i].SchedDate == "")
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = "";
                                }
                                else
                                {
                                    lstFilingTransactionDataModel[i].SchedDate = Convert.ToDateTime(lstFilingTransactionDataModel[i].SchedDate).ToString("MM/dd/yyyy");
                                }

                                lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                            }
                        }
                    }

                    Session["ItemizedIETransactionsWCS"] = lstFilingTransactionDataModel;
                //}

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    "",
                    x.IEType,
                    x.TreasurerName,
                    x.ContributorName,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.SchedDate,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.OriginalAmount,
                    x.TransExplanation,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemizedWeeklyClaimSubData

        #region GetItemizedIETransactionsExists
        /// <summary>
        /// GetItemizedIETransactionsExists
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetItemizedIETransactionsExists(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String lstUCMuncipality, String txtReportPeriodDatesTo, String lstFilingDate, String txtNewFilingDate)
        {
            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                Boolean results = false;

                if (strElectionDateId != "- Select -")
                {
                    String strFilingDate = String.Empty;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            strFilingDate = txtNewFilingDate;
                        else
                            strFilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        strFilingDate = txtReportPeriodDatesTo;
                    }
                    lstFilingTransactionDataModel = objItemizedReportsBroker.GetItemizedNonItemIETransactionsResponse(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, lstUCMuncipality, strFilingDate);
                }

                if (lstFilingTransactionDataModel.Count > 0)
                    results = true;
                else
                    results = false;

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemizedIETransactionsExists

        #region GetItemized24HoursTransactionsExists
        /// <summary>
        /// GetItemized24HoursTransactionsExists
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetItemized24HoursTransactionsExists(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String lstUCMuncipality, String txtReportPeriodDatesTo, String lstFilingDate, String txtNewFilingDate)
        {
            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                Boolean results = false;

                if (strElectionDateId != "- Select -")
                {
                    String strFilingDate = String.Empty;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            strFilingDate = txtNewFilingDate;
                        else
                            strFilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        strFilingDate = txtReportPeriodDatesTo;
                    }

                    lstFilingTransactionDataModel = objItemizedReportsBroker.GetItemizedNonItemIETransactionsResponse(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, lstUCMuncipality, strFilingDate);
                    lstFilingTransactionDataModel = lstFilingTransactionDataModel.Where(x => x.IEType.ToString() == "24-Hour Notice").ToList();
                }

                if (lstFilingTransactionDataModel.Count > 0)
                    results = true;
                else
                    results = false;

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemized24HoursTransactionsExists

        #region GetItemizedWCSTrans
        /// <summary>
        /// GetItemizedWCSTrans
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetItemizedWCSTrans(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String lstUCMuncipality,
                                             String txtCuttOffDate, String txtNewFilingDate, String lstResigTermType)
        {
            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();                

                Boolean results = false;

                if (strElectionDateId == "- Select -")
                {
                    strElectionDateId = "";
                }

                if (txtCuttOffDate == "")
                {
                    txtCuttOffDate = txtNewFilingDate;
                }

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetItemizedWCSTransBroker(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, lstUCMuncipality, txtCuttOffDate);
                Session["ItemizedWCSTrans"] = lstFilingTransactionDataModel;

                if (lstFilingTransactionDataModel.Count > 0)
                    results = true;
                else
                    results = false;

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetItemizedWCSTrans

        #region AddItemizedIETransactions
        /// <summary>
        /// AddItemizedIETransactions
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddItemizedIETransactions(String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString();
                String strCreatedBy = Session["UserName"].ToString(); 

                String strFilingDate = String.Empty;

                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["ItemizedIETransactions"];

                IList<String> strFilingTransId = new List<String>();                

                foreach (var item in lstFilingTransactionDataModel)
                {
                    if (item != null)
                    {
                        strFilingTransId.Add(item.TransNumber);
                    }
                }
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        strFilingDate = txtReportPeriodDatesTo;
                    else
                        strFilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    strFilingDate = txtReportPeriodDatesTo;
                }

                var results = objItemizedReportsBroker.AddItemizedIETransactionsDataResponse(strFilingTransId, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AddItemizedIETransactions

        #region AddItemized24HoursTransactions
        /// <summary>
        /// AddItemized24HoursTransactions
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddItemized24HoursTransactions(String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString();
                String strCreatedBy = Session["UserName"].ToString();

                String strFilingDate = String.Empty;

                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["Itemized24HoursTransactions"];

                IList<String> strFilingTransId = new List<String>();

                foreach (var item in lstFilingTransactionDataModel)
                {
                    if (item != null)
                    {
                        strFilingTransId.Add(item.TransNumber);
                    }
                }
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        strFilingDate = txtReportPeriodDatesTo;
                    else
                        strFilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    strFilingDate = txtReportPeriodDatesTo;
                }

                var results = objItemizedReportsBroker.AddItemizedIETransactionsDataResponse(strFilingTransId, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AddItemized24HoursTransactions

        #region GetOfficeTypes
        /// <summary>
        /// GetOfficeTypes
        /// </summary>
        /// <param name="strElectionYear"></param>
        /// <returns></returns>
        public JsonResult GetOfficeTypes(String lstElectionCycle)
        {
            try
            {
                IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
                if (lstElectionCycle != "")
                    lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeEFSResponse(lstElectionCycle);
                else
                    lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeResponse();

                Session["ElectionYearID_PCFB"] = lstElectionCycle;
                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    lstOfficeTypeModel = lstOfficeTypeModel.Where(x => Convert.ToInt32(x.OfficeTypeId) == 1).ToList();
                }
                else
                {
                    Session["OfficeTypes"] = lstOfficeTypeModel;
                }

                // Bind Office Type            
                return Json(new SelectList(lstOfficeTypeModel, "OfficeTypeId", "OfficeTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOfficeTypes        

        #region GetMunicipality
        /// <summary>
        /// GetMunicipality
        /// </summary>
        /// <param name="lstUCCounty"></param>
        /// <returns></returns>
        public JsonResult GetMunicipality(String lstUCCounty, String lstOfficeType)
        {
            try
            {
                IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
                //lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(lstUCCounty);
                // LOADIG MUNICIPALITY BASED ON COUNTY ID AND OFFICE TYPE ID - 06/03/2020.
                lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityByOfficeType(lstUCCounty, lstOfficeType);
                // Bind Municipality
                return Json(new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetMunicipality                

        #region GetElectionType
        /// <summary>
        /// GetElectionType
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstOfficeType"></param>
        /// <param name="lstCounty"></param>
        /// <param name="lstMunicipality"></param>
        /// <returns></returns>
        public JsonResult GetElectionType(String lstElectionCycle, String lstOfficeType, String lstCounty, String lstMunicipality)
        {
            try
            {
                //var hostname = Dns.GetHostEntry(Dns.GetHostName()).HostName;

                IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();

                if ((lstCounty == "- Select -") || (String.IsNullOrEmpty(lstCounty)))
                    lstCounty = "";
                if ((lstMunicipality == "- Select -") || (String.IsNullOrEmpty(lstMunicipality)))
                    lstMunicipality = "";

                String strCandCommId = Session["FilerId"].ToString();
                String strCommittee = String.Empty;
                lstDisclosureTypeModel = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId);
                if (lstDisclosureTypeModel.Count() == 1)
                    strCommittee = lstDisclosureTypeModel.Where(x => x.DisclosureTypeId == "3").Select(x => x.DisclosureTypeDesc).FirstOrDefault().ToString();

                lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(lstElectionCycle,
                    lstOfficeType, lstCounty, lstMunicipality, Session["COMM_TYPE_ID"].ToString());

                if (strCommittee != "")
                {
                    var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "6");
                    lstElectionTypeModel.Remove(itemToRemove);
                }

                //=============================================================================================================
                // CHECKING IF DISCLOSURE TYPE 'NOTICE OF NON-PARTICIPATION THEN WILL SHOW PRIMARY AND GENERAL ELECTION TYPE...
                // OTHER WISE IT WILL HIDE THE 'PRIMARY AND GENERAL' ELECTION...
                // 'PRIMARY AND GENERAL' ELECTION TYPE ONLY FOR 'NOTICE OF NON-PARTICIPATION'.
                String strPrimaryAndGeneral = lstDisclosureTypeModel.Where(x => x.DisclosureTypeId == "5").Select(x => x.DisclosureTypeId).FirstOrDefault();
                if (strPrimaryAndGeneral != null)
                {
                    if (strPrimaryAndGeneral != "5")
                    {
                        var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                        lstElectionTypeModel.Remove(itemToRemove);
                    }
                }
                else // IF ITS NULL THEN NOTICE-OF NON PARTICIPATION NOT EXISTS.
                {
                    // THEN NOT NEED TO SHOW PRIMAR AND GENERAL OPTION.
                    var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                    lstElectionTypeModel.Remove(itemToRemove);
                }
                // CHECKING IF DISCLOSURE TYPE 'NOTICE OF NON-PARTICIPATION THEN WILL SHOW PRIMARY AND GENERAL ELECTION TYPE...
                // OTHER WISE IT WILL HIDE THE 'PRIMARY AND GENERAL' ELECTION...
                // 'PRIMARY AND GENERAL' ELECTION TYPE ONLY FOR 'NOTICE OF NON-PARTICIPATION'.
                //=============================================================================================================

                // IF ELECTION NOT EXISTS FOR 'PRIMARY' AND 'GENERAL' THEN YOU SHOULD NOT SHOW 'PRIMARY AND GENERAL' ELECTION TYPE.
                // IF BOTH EXISTS 'PRIMARY' AND 'GENERAL' THEN ONLY YOU HAVE TO SHOW 'PRIMARY AND GENERAL' FOR ELECTION TYPE....
                String strPrimaryGeneralExists = String.Empty;
                strPrimaryGeneralExists = lstElectionTypeModel.Where(x => x.ElectionTypeId == "2").Select(x => x.ElectionTypeId).FirstOrDefault();
                //if (strPrimaryGeneralExists != null)
                //{
                if (strPrimaryGeneralExists != "2")
                {
                    // NO PRIMARY THEN NO NEED TO SHOW 'PRIMARY AND GENERAL' ELECTION TYPE...
                    // THEN WILL REMOVE ELECTION TYPE...
                    if (lstElectionTypeModel.Where(x => x.ElectionTypeId.ToString() == "8").Select(x => x.ElectionTypeId).FirstOrDefault() != null)
                    {
                        var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                        lstElectionTypeModel.Remove(itemToRemove);
                    }
                }
                else
                {
                    // IF PRIMARY EXISTS THEN CHECK WITH GENERAL EXISTS OR NOT...
                    // IF GENERAL NOT EXISTS THEN NO NEED TO SHOW 'PRIMARY AND GENERAL' ELECTION TYPE....
                    strPrimaryGeneralExists = lstElectionTypeModel.Where(x => x.ElectionTypeId == "3").Select(x => x.ElectionTypeId).FirstOrDefault();
                    //if (strPrimaryGeneralExists == null)
                    //{
                    if (strPrimaryGeneralExists != "3")
                    {
                        if (lstElectionTypeModel.Where(x => x.ElectionTypeId.ToString() == "8").Select(x => x.ElectionTypeId).FirstOrDefault() != null)
                        {
                            var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                            lstElectionTypeModel.Remove(itemToRemove);
                        }
                    }
                    //}
                }
                //}


                // CHECK IF ANY PRIMARY OR GENERAL THEY FILED THEN NO NEED TO SHOW 'PRIMARY AND GENERAL' ELECTION TYPE...
                // IF THEY DIDN'T FILE ANY PRIMARY OR GENERAL THEN...
                // THEN WILL GIVE ALL 3 OPTIONS.... 'PRIMARY', 'GENERAL', AND 'PRIMARY AND GENERAL'.
                IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();
                lstInLieuOfStatementNonItemModel = objItemizedReportsBroker.GetNoticeOfNonParticipationtDataResponse(Session["FilerId"].ToString(), "", lstElectionCycle, "", "8", lstOfficeType, "", lstCounty, lstMunicipality);
                if (lstInLieuOfStatementNonItemModel != null)
                {
                    if (lstInLieuOfStatementNonItemModel.Count() != 0)
                    {
                        if (lstElectionTypeModel.Where(x => x.ElectionTypeId.ToString() == "8").Select(x => x.ElectionTypeId).FirstOrDefault() != null)
                        {
                            var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                            lstElectionTypeModel.Remove(itemToRemove);
                        }   
                    }
                }

                // CHECK ITEMIZED SUBMITED OR NOT FOR PRIMARY & GENERAL
                // IF SUBMITED EITHER PRIMARY OR GENERAL THEN DON'T SHOW THE VALUE "PRIMARY & GENERAL".
                NoticeOfNonParticipationController objNoticeOfNonParticipationController = new NoticeOfNonParticipationController();
                // CHECK FOR PARIMARY.
                JsonResult rItemizedSubmittedP = objNoticeOfNonParticipationController.GetItemizedSubmitted(Session["FilerId"].ToString(), lstElectionCycle, lstOfficeType, null, "2", "1");
                // CHECK FOR GENERAL.
                JsonResult rItemizedSubmittedG = objNoticeOfNonParticipationController.GetItemizedSubmitted(Session["FilerId"].ToString(), lstElectionCycle, lstOfficeType, null, "3", "1");
                // EITHER PRIMARY OR GENERAL SUBMITED THEN...
                // HIDE THE "PRIMARY AND GENERAL" FROM ELECTION TYPE.
                if (rItemizedSubmittedP.Data.ToString() == "Primary")
                {
                    var strPGExists = lstElectionTypeModel.Where(x => x.ElectionTypeId.ToString() == "8").FirstOrDefault();
                    if (strPGExists != null)
                    {
                        var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                        lstElectionTypeModel.Remove(itemToRemove);
                    }
                }
                else if (rItemizedSubmittedG.Data.ToString() == "General")
                {
                    var strPGExists = lstElectionTypeModel.Where(x => x.ElectionTypeId.ToString() == "8").FirstOrDefault();
                    if (strPGExists != null)
                    {
                        var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "8");
                        lstElectionTypeModel.Remove(itemToRemove);
                    }
                }

                // CHECK THAT IF EITHER STATE OR COUNTY CALENDAR CREATED EITHER PRIMARY, GENERAL, SPECIAL....
                // ANY ONE OF CALENDAR CREATED THEN SHOW THE OFF-CYCLE OTHER WISE DON'T SHOW OFF-CYCLE.
                // ADDED THIS FOR DEFECT - 3210 ON 12.28.2020 - SB.

                if (lstElectionTypeModel.Count() == 1)
                {
                    // THEN NO CALENDAR CREATED FOR THIS COUNTY.
                    // NO NEED TO SHOW OFF-CYCLE FOR THIS COUNTY.
                    // NO CALENDAR - COUNTY.
                    String strElectionTypeText = lstElectionTypeModel.Select(x => x.ElectionTypeDesc).FirstOrDefault();
                    if (strElectionTypeText == "Off-Cycle")
                    {
                        var itemToRemove = lstElectionTypeModel.Single(x => x.ElectionTypeId.ToString() == "6");
                        lstElectionTypeModel.Remove(itemToRemove);
                    }
                }

                Session["ElectionTypes"] = lstElectionTypeModel;

                return Json(new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetElectionType

        #region GetElectionDate
        /// <summary>
        /// GetElectionDate
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetElectionDate(String lstElectionCycle, String lstElectionType, String lstOfficeType, String strCounty, String strMunicipality)
        {
            if ((strMunicipality == "- Select -") || (String.IsNullOrEmpty(strMunicipality)))
                strMunicipality = "";
            if ((strCounty == "- Select -") || (String.IsNullOrEmpty(strCounty)))
                strCounty = "";

            try
            {
                IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();

                if (strCounty == null)
                {
                    strCounty = "";
                }
                if (strMunicipality == null)
                {
                    strMunicipality = "";
                }
                if (lstElectionCycle == "- Select -")
                    lstElectionCycle = "";
                if (lstElectionType == "- Select -")
                    lstElectionType = "";
                if (lstOfficeType == "- Select -")
                    lstOfficeType = "";

                if (lstOfficeType == "1")
                    lstOfficeType = "4";

                //if (lstElectionType == "4" || lstElectionType == "11") // PERIODIC - EITHER JANURARY OR JULY WE HAVE TO SEND STATE PRIMARY ELECTION DATE ID.
                if (lstElectionType == "4") // PERIODIC - EITHER JANURARY OR JULY WE HAVE TO SEND STATE PRIMARY ELECTION DATE ID.
                {
                    lstElectionType = "2";

                    Session["ElectionCycleVal"] = lstElectionCycle.ToString();
                    Session["ElectionTypeVal"] = lstElectionType.ToString();
                    Session["OfficeTypeVal"] = lstOfficeType.ToString();
                    Session["CountyVal"] = strCounty.ToString();
                    Session["MunicipalityVal"] = strMunicipality.ToString();

                    Session["ElectionCycleVal_Dup"] = lstElectionCycle.ToString();
                    Session["ElectionTypeVal_Dup"] = lstElectionType.ToString();
                    Session["OfficeTypeVal_Dup"] = lstOfficeType.ToString();
                    Session["CountyVal_Dup"] = strCounty.ToString();
                    Session["MunicipalityVal_Dup"] = strMunicipality.ToString();
                    

                    lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(lstElectionCycle, lstElectionType, lstOfficeType, strCounty, strMunicipality);
                    return Json(new SelectList(lstElectionDateModel, "ElectId", "ElectDate"), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["ElectionCycleVal"] = lstElectionCycle.ToString();
                    Session["ElectionTypeVal"] = lstElectionType.ToString();
                    Session["OfficeTypeVal"] = lstOfficeType.ToString();
                    Session["CountyVal"] = strCounty.ToString();
                    Session["MunicipalityVal"] = strMunicipality.ToString();

                    Session["ElectionCycleVal_Dup"] = lstElectionCycle.ToString();
                    Session["ElectionTypeVal_Dup"] = lstElectionType.ToString();
                    Session["OfficeTypeVal_Dup"] = lstOfficeType.ToString();
                    Session["CountyVal_Dup"] = strCounty.ToString();
                    Session["MunicipalityVal_Dup"] = strMunicipality.ToString();

                    lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(lstElectionCycle, lstElectionType, lstOfficeType, strCounty, strMunicipality);
                    return Json(new SelectList(lstElectionDateModel, "ElectId", "ElectDate"), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetElectionDate

        #region GetDisclosurePeriod
        /// <summary>
        /// GetDisclosurePeriod
        /// </summary>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetDisclosurePeriod(String lstElectionType, String lstElectionDate)
        {
            try
            {
                string ElectionYearID_PCFB = string.Empty;
                if (lstElectionType == "- Select -")
                    lstElectionType = "";
                if (lstElectionType == null)
                    lstElectionType = "";
                if (Session["ElectionYearID_PCFB"] != null)
                {
                    ElectionYearID_PCFB = Session["ElectionYearID_PCFB"].ToString();
                }

                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(lstElectionType, Session["FilerID"].ToString(), ElectionYearID_PCFB);

                if (Session["ElectionCycleVal"] != null)
                {
                    if (Session["ElectionCycleVal"].ToString() == "44" &&
                        Session["ElectionTypeVal"].ToString() == "3" &&
                        Session["OfficeTypeVal"].ToString() == "5" &&
                        lstElectionDate == "06/20/2023")
                    {
                        lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => Convert.ToInt32(x.FilingTypeId) >= 4
                                                && Convert.ToInt32(x.FilingTypeId) <= 5).ToList();
                        Session["DisclosurePeriods"] = lstDisclosurePreiodModel;
                    }
                    else
                    {
                        Session["DisclosurePeriods"] = lstDisclosurePreiodModel;
                    }                    
                }
                else
                {
                    Session["DisclosurePeriods"] = lstDisclosurePreiodModel;
                }                

                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDisclosurePeriod

        #region GetDisclosurePeriodCampMaterial
        /// <summary>
        /// GetDisclosurePeriod
        /// </summary>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetDisclosurePeriodCampMaterial(String lstElectionType)
        {
            try
            {
                if (lstElectionType == "- Select -")
                    lstElectionType = "";
                if (lstElectionType == null)
                    lstElectionType = "";

                string ElectionYearID_PCFB = string.Empty;
                if (Session["ElectionYearID_PCFB"] != null)
                {
                    ElectionYearID_PCFB = Session["ElectionYearID_PCFB"].ToString();
                }
                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(lstElectionType, Session["FilerID"].ToString(), ElectionYearID_PCFB);

                if (lstElectionType == "2" || lstElectionType == "9")
                {
                    lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => x.FilingTypeId.ToString() == "3").ToList();
                }   
                if (lstElectionType == "3")
                    lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => x.FilingTypeId.ToString() == "6").ToList();
                if (lstElectionType == "1")
                    lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => x.FilingTypeId.ToString() == "9").ToList();

                Session["DisclosurePeriods"] = lstDisclosurePreiodModel;

                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDisclosurePeriodCampMaterial

        #region GetDisclosureTypesData
        /// <summary>
        /// GetDisclosureTypesData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDisclosureTypesData(String lstElectionType)
        {
            // THIS METHOD EXECUTING ONLY WHEN REPORT TYPE SELECT PERIODIC AND OFF-CYCLE.
            try
            {
                String strCandCommId = Session["FilerId"].ToString();
                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                DisclosureTypesModel objDisclosureTypesModel;
                var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId);                
                String strCommitteeTypeId = objItemizedReportsBroker.GetFilerCommitteeTypeId(strCandCommId);
                foreach (var item in results)
                {
                    if (item != null)
                    {
                        if (strCommitteeTypeId == "19") // FIXED ON 03.04.2020 IF IE COMMITTEE WE HAVE TO SHOW WEEKLY IN DISCLOSURE TYPES FOR ALL REPORT TYPE.
                        {
                            // REMOVED FOR OFF-CYCLE WHICH ADDED FOR IE - WEEKLY DISCLOSURE TYPES.
                            // ENABLING OFF-CYCLE AND PERIODIC FOR IE - WEEKLY DISCLOSURE TYPES. DISCUSSION HAPPEN 07/06/2020.
                            if (item.DisclosureTypeId.ToString() == "1" || item.DisclosureTypeId.ToString() == "2" || item.DisclosureTypeId.ToString() == "7" || item.DisclosureTypeId.ToString() == "9" || item.DisclosureTypeId.ToString() == "10" || item.DisclosureTypeId.ToString() == "12")
                            {
                                objDisclosureTypesModel = new DisclosureTypesModel();
                                objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                                objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                                lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                            }

                            //// HOLDING OFF-CYCLE IF REQUIRED ADD COMMENTED CODE TO IF CONDITION.
                            //if (item.DisclosureTypeId.ToString() == "1" || item.DisclosureTypeId.ToString() == "2")
                            //{
                            //    objDisclosureTypesModel = new DisclosureTypesModel();
                            //    objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                            //    objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                            //    lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                            //}
                        }
                        else
                        {
                            // HOLDING OFF-CYCLE IF REQUIRED ADD COMMENTED CODE TO IF CONDITION.
                            if (item.DisclosureTypeId.ToString() == "1" || item.DisclosureTypeId.ToString() == "2" || item.DisclosureTypeId.ToString() == "3")
                            {
                                //if (lstElectionType == "11")
                                //{
                                //    if (item.DisclosureTypeId.ToString() == "1")
                                //    {
                                //        objDisclosureTypesModel = new DisclosureTypesModel();
                                //        objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                                //        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                                //        lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                                //    }
                                //}
                                //else
                                //{
                                //    objDisclosureTypesModel = new DisclosureTypesModel();
                                //    objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                                //    objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                                //    lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                                //}
                                objDisclosureTypesModel = new DisclosureTypesModel();
                                objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                                objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                                lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                            }
                        }
                    }
                }
                // Bind Disclosure Type            
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDisclosureTypesData

        #region DisclosureTypesSpecialNoticeOfNP
        /// <summary>
        /// DisclosureTypesSpecialNoticeOfNP
        /// </summary>
        /// <returns></returns>
        public JsonResult DisclosureTypesSpecialNoticeOfNP()
        {
            try
            {
                String strCandCommId = Session["FilerId"].ToString();
                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                DisclosureTypesModel objDisclosureTypesModel;
                var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId);
                foreach (var item in results)
                {
                    if (item != null)
                    {
                        if (item.DisclosureTypeId.ToString() != "5")
                        {
                            objDisclosureTypesModel = new DisclosureTypesModel();
                            objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                            objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                            lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                        }
                    }
                }
                // Bind Disclosure Type            
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DisclosureTypesSpecialNoticeOfNP

        #region DisclosureTypesPrimAndGenNoticeOfNP
        /// <summary>
        /// DisclosureTypesPrimAndGenNoticeOfNP
        /// </summary>
        /// <returns></returns>
        public JsonResult DisclosureTypesPrimAndGenNoticeOfNP()
        {
            try
            {
                String strCandCommId = Session["FilerId"].ToString();
                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                DisclosureTypesModel objDisclosureTypesModel;
                var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId);
                foreach (var item in results)
                {
                    if (item != null)
                    {
                        if (item.DisclosureTypeId.ToString() == "5")
                        {
                            objDisclosureTypesModel = new DisclosureTypesModel();
                            objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                            objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                            lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                        }
                    }
                }
                // Bind Disclosure Type            
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DisclosureTypesPrimAndGenNoticeOfNP

        #region GetDisclosureTypeSpecial
        /// <summary>
        /// GetDisclosureTypeSpecial
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDisclosureTypeSpecial()
        {
            try
            {
                String strCandCommId = Session["FilerId"].ToString();
                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                DisclosureTypesModel objDisclosureTypesModel;
                var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId);
                foreach (var item in results)
                {
                    if (item != null)
                    {
                        if (item.DisclosureTypeId.ToString() != "5")
                        {
                            objDisclosureTypesModel = new DisclosureTypesModel();
                            objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                            objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                            lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                        }
                    }
                }
                // Bind Disclosure Type            
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDisclosureTypeSpecial

        #region GetDisclosureTypesDefault
        /// <summary>
        /// GetDisclosureTypesDefault
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDisclosureTypesDefault(String lstElectionType, String lstElectionCycle)
        {
            try
            {
                bool checkEvenOddElectionYear = false;
                String strCandCommId = Session["FilerId"].ToString();
                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                DisclosureTypesModel objDisclosureTypesModel;
                //var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId);
                if (lstElectionType == "- Select -")
                {
                    lstElectionType = "";
                }

                if (Int32.Parse(lstElectionCycle) >= 2024)
                {
                    checkEvenOddElectionYear = lstElectionCycle.All(x => x % 2 == 0);
                }

                var results = objItemizedReportsBroker.GetDisclosureTypesDataForPCFBBroker(strCandCommId, lstElectionType);
                foreach (var item in results)
                {
                    if (item != null)
                    {                                        
                        objDisclosureTypesModel = new DisclosureTypesModel();
                        objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                        lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                    }
                }

                if (checkEvenOddElectionYear == false)
                {
                    lstDisclosureTypeModel = lstDisclosureTypeModel.Where(x => x.DisclosureTypeId.Trim().ToString() != "14").ToList();                    
                }

                // Bind Disclosure Type            
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDisclosureTypesDefault

        #region GetFilingDateOffCycle
        /// <summary>
        /// GetFilingDateOffCycle
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public JsonResult GetFilingDateOffCycle(String strElectionYearId, String strOfficeTypeId, String strFilerId, String lstDisclosureType)
        {
            try
            {
                Session["ElectionYearId"] = strElectionYearId;
                Session["OfficeTypeId"] = strOfficeTypeId;
                Session["FilerIdOffCycle"] = strFilerId;
                Session["DisclosureType"] = lstDisclosureType;

                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                lstFilingDatesOffCycleModel = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(strElectionYearId, strOfficeTypeId, strFilerId, lstDisclosureType);

                Session["lstFilingDatesOffCycleModel"] = lstFilingDatesOffCycleModel;
                // Bind Filing Date for Off Cycle.
                return Json(new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilingDateOffCycle

        #region GetFilingDateExists
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strNewFilingDate"></param>
        /// <returns></returns>
        public JsonResult GetFilingDateExists(String strNewFilingDate)
        {
            try
            {
                String strReturnValue = String.Empty;

                if (Session["lstFilingDatesOffCycleModel"] != null)
                {
                    IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                    lstFilingDatesOffCycleModel = (IList<FilingDatesOffCycleModel>)Session["lstFilingDatesOffCycleModel"];

                    lstFilingDatesOffCycleModel = lstFilingDatesOffCycleModel.Where(x => x.FilingDate.Trim().ToString() == strNewFilingDate).ToList();

                    if (lstFilingDatesOffCycleModel.Count == 1)
                        strReturnValue = "True";
                    else
                        strReturnValue = "False";

                    return Json(strReturnValue, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    strReturnValue = "False";

                    return Json(strReturnValue, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilingDateExists

        #region GetFilingDateIEWeekly
        /// <summary>
        /// GetFilingDateOffCycle
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public JsonResult GetFilingDateIEWeekly(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strElectionTypeId, String strFilingCatId, String strElectionDateId, String lstUCMuncipality)
        {
            try
            {
                String strFilingType = String.Empty;

                if (strElectionDateId == "- Select -")
                    strElectionDateId = "";
                else if (strElectionDateId == null)
                    strElectionDateId = "";
                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                Session["ElectionYearId"] = strElectionYearId;
                Session["OfficeTypeId"] = strOfficeTypeId;
                if (strFilerId != null)
                {
                    Session["FilerIdIEWeekly"] = strFilerId;
                }
                else
                {
                    if (Session["FilerIdIEWeekly"] != null)
                        strFilerId = Session["FilerIdIEWeekly"].ToString();
                }
                Session["ElectionTypeId"] = strElectionTypeId;
                Session["FilingType"] = strFilingType;
                Session["FilingCatId"] = strFilingCatId;
                Session["ElectionDateId"] = strElectionDateId;
                Session["MunicipalityID"] = lstUCMuncipality;

                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                lstFilingDatesOffCycleModel = objItemizedReportsBroker.GetFilingDateIEWeeklyeDataResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId, lstUCMuncipality);

                for (int i = 0; i < lstFilingDatesOffCycleModel.Count; i++)
                {
                    if (lstFilingDatesOffCycleModel[i] != null)
                    {
                        lstFilingDatesOffCycleModel[i].FilingDate = lstFilingDatesOffCycleModel[i].FilingDate.Trim();
                    }
                }

                Session["lstFilingDatesOffCycleModel"] = lstFilingDatesOffCycleModel;

                // Bind Filing Date for Off Cycle.
                return Json(new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilingDateIEWeekly

        #region GetFilingCutOffDate
        /// <summary>
        /// GetFilingCutOffDate
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <returns></returns>
        public JsonResult GetFilingCutOffDate(String lstElectionCycle, String lstElectionType, String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionDateId)
        {
            try
            {
                String strFilingDateId = String.Empty;
                String strCuttOffDateId = String.Empty;

                if (lstUCOfficeType == "1")
                    lstUCOfficeType = "4";

                if (lstDisclosurePeriod == "1") // 32 Day Pre-Primary
                {
                    strFilingDateId = "59";
                    strCuttOffDateId = "60";
                }
                else if (lstDisclosurePeriod == "2") // 11 Day Pre-Primary
                {
                    strFilingDateId = "61";
                    strCuttOffDateId = "62";
                }
                else if (lstDisclosurePeriod == "3") // 10 Day Post-Primary
                {
                    strFilingDateId = "65";
                    strCuttOffDateId = "66";
                }
                else if (lstDisclosurePeriod == "4") // 32 Day Pre-General
                {
                    strFilingDateId = "104";
                    strCuttOffDateId = "105";
                }
                else if (lstDisclosurePeriod == "5") // 11 Day Pre-General
                {
                    strFilingDateId = "106";
                    strCuttOffDateId = "107";
                }
                else if (lstDisclosurePeriod == "6") // 27 Day Post-General
                {
                    strFilingDateId = "108";
                    strCuttOffDateId = "109";
                }
                else if (lstDisclosurePeriod == "7") // 32 Day Pre-Speceial
                {
                    strFilingDateId = "122";
                    strCuttOffDateId = "123";
                }
                else if (lstDisclosurePeriod == "8") // 11 Day Pre-Special
                {
                    strFilingDateId = "124";
                    strCuttOffDateId = "125";
                }
                else if (lstDisclosurePeriod == "9") // 27 Day Post-Special
                {
                    strFilingDateId = "126";
                    strCuttOffDateId = "127";
                }
                else if (lstDisclosurePeriod == "10") // January Periodic
                {
                    strFilingDateId = "69";
                    strCuttOffDateId = "70";
                }
                else if (lstDisclosurePeriod == "11") // July Periodic
                {
                    strFilingDateId = "71";
                    strCuttOffDateId = "72";
                }
                else if (lstDisclosurePeriod == "12") // Off Cycle
                {
                    //strFilingDateId = "108";
                    //strCuttOffDateId = "109";
                }
                else if (lstDisclosurePeriod == "13") // March Periodic
                {
                    strFilingDateId = "140";
                    strCuttOffDateId = "141";
                }
                //else if (lstDisclosurePeriod == "14") // January
                //{
                //    strFilingDateId = "144";
                //    strCuttOffDateId = "145";
                //}
                //else if (lstDisclosurePeriod == "15") // February
                //{
                //    strFilingDateId = "146";
                //    strCuttOffDateId = "147";
                //}
                //else if (lstDisclosurePeriod == "16") // March
                //{
                //    strFilingDateId = "148";
                //    strCuttOffDateId = "149";
                //}
                //else if (lstDisclosurePeriod == "17") // April
                //{
                //    strFilingDateId = "150";
                //    strCuttOffDateId = "151";
                //}
                //else if (lstDisclosurePeriod == "18") // July
                //{
                //    strFilingDateId = "152";
                //    strCuttOffDateId = "153";
                //}
                //else if (lstDisclosurePeriod == "19") // December
                //{
                //    strFilingDateId = "142";
                //    strCuttOffDateId = "143";
                //}

                IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

                lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateDataResponse(lstElectionCycle, lstElectionType, lstUCOfficeType,
                    strFilingDateId, strCuttOffDateId, lstElectionDateId);

                Session["FilingAndCutOffDate"] = lstFilingCutOffDateModel;

                return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilingCutOffDate

        #region GetFilingCutOffDateNonItemizedTrans
        /// <summary>
        /// GetFilingCutOffDateNonItemizedTrans
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosureType"></param>
        /// <returns></returns>
        public JsonResult GetFilingCutOffDateNonItemizedTrans(String lstElectionCycle, String lstElectionType, String lstUCOfficeType, String lstDisclosureType, String lstElectionDateId)
        {
            try
            {
                String strFilingDateId = String.Empty;
                String strCuttOffDateId = String.Empty;

                if (lstUCOfficeType == "1")
                    lstUCOfficeType = "4";

                if (lstDisclosureType == "4")
                {
                    strFilingDateId = "63";
                    strCuttOffDateId = "64";
                }
                else if (lstDisclosureType == "8" || lstDisclosureType == "11" || lstDisclosureType == "13")
                {
                    strFilingDateId = "67";
                    strCuttOffDateId = "68";
                }

                IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

                lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateDataResponse(lstElectionCycle, lstElectionType, lstUCOfficeType,
                    strFilingDateId, strCuttOffDateId, lstElectionDateId);

                Session["FilingAndCutOffDate"] = lstFilingCutOffDateModel;

                return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetFilingCutOffDateNonItemizedTrans

        #region GetTransactionTypeData
        /// <summary>
        /// GetTransactionTypeData
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetTransactionTypeData()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
                                                                                                        // Bind Transaction Type
                                                                                                        //ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

                return lstTransactionTypeModel;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetTransactionTypeData

        #region GetPartnerData
        /// <summary>
        /// GetPartnerData
        /// </summary>
        /// <returns></returns>
        public IList<PartnerModel> GetPartnerData()
        {
            try
            {
                IList<PartnerModel> lstPartnerModel = new List<PartnerModel>();
                PartnerModel objPartnerModel;

                objPartnerModel = new PartnerModel();
                objPartnerModel.PartnerId = "1";
                objPartnerModel.PartnerDesc = "Partners";
                lstPartnerModel.Add(objPartnerModel);

                objPartnerModel = new PartnerModel();
                objPartnerModel.PartnerId = "2";
                objPartnerModel.PartnerDesc = "SubContractors";
                lstPartnerModel.Add(objPartnerModel);

                return lstPartnerModel;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPartnerData

        #region TransferOutStandingBalance
        /// <summary>
        /// Transfer OutStanding Balance
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="lstDisclosureType"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <param name="lstResigTermType"></param>
        /// <param name="lstFilingDate"></param>
        /// <returns></returns>
        public JsonResult TransferOutStandingBalance(String strFilerId, String strElectionYearId,
                                                     String strOfficeTypeId, String strElectionTypeId, String strElectionDateId,
                                                     String lstDisclosureType, String txtReportPeriodDatesTo, String lstResigTermType,
                                                     String lstFilingDate, String txtNewFilingDate, String lstUCMuncipality)
        {
            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";

            try
            {
                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;
                if (strElectionDateId == "- Select -")
                {
                    strElectionDateId = "";
                }
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                objFilingTransactionsModel.FilerId = strFilerId;
                objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                objFilingTransactionsModel.OfficeTypeId = strOfficeTypeId;
                objFilingTransactionsModel.FilingTypeId = lstDisclosureType;
                objFilingTransactionsModel.ElectYearId = strElectionYearId;
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransactionsModel.FilingDate = txtNewFilingDate;
                    else
                        objFilingTransactionsModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                }
                objFilingTransactionsModel.ElectionDateId = strElectionDateId;
                objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;
                objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                // CHECKING FOR LOANS AND LIABILITY BOTH IN ONE PROCEDURE. // CHECKING FOR LIABILITY
                // TESTING UAT REMOVED AFTER THAT ENABLE......
                // IF YOU ARE CONNECTING DEV-DATABASE CALL AUTO CREATED LOANS/LIABILITY TRANSACTIONS...
                // IF YOU ARE CONNECTING UAT-DATABASE HISTORICAL DATA THEN DON'T CALL THIS ONE...
                // IT WILL FAIL BEFORE RUNNING RECONCILIATION...FIRST RUN RECONCILATION LOAN/LIABILITY THEN..
                // YOU CAN CALL BELOW METHOD IT WILL AUTO CREATE IF ANY PENDING 
                //var resultData = "0";
                var resultData = objItemizedReportsBroker.TransferOutStandingBalanceBroker(objFilingTransactionsModel);
                //// CHECKING FOR LIABILITY
                //var resultDataLiab = objItemizedReportsBroker.TransferOutStandingLiabilityBalanceResponse(objFilingTransactionsModel);

                String strResultsData = String.Empty;

                if (resultData == "1")
                    strResultsData = "1";
                //else if (resultDataLiab == "1")
                //    strResultsData = "1";`
                else
                    strResultsData = "0";

                return Json(strResultsData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion TransferOutStandingBalance

        #region GetValidateFilter
        /// <summary>
        /// GetValidateFilter
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="txtCommitteeName"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="lstUCCounty"></param>
        /// <param name="lstUCMuncipality"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="lstDisclosureType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="txtReportPeriodDatesFrom"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetValidateFilter(String strFilerId, String txtCommitteeName, String strElectionYearId, String strElectionYear, String strOfficeTypeId, String lstUCCounty, String lstUCMuncipality, String strElectionTypeId, String strElectionDateId, String lstDisclosureType, String lstDisclosurePeriod, String txtReportPeriodDatesFrom, String txtReportPeriodDatesTo, String lstResigTermType, String lstFilingDate, String txtNewFilingDate)
        {
            if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                lstUCMuncipality = "";
            if ((lstUCCounty == "- Select -") || (String.IsNullOrEmpty(lstUCCounty)))
                lstUCCounty = "";
            try
            {
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = "";
                if (lstDisclosurePeriod == "- Select -")
                    lstDisclosurePeriod = "";

                if (lstDisclosureType == "- Select -")
                    lstDisclosureType = "";

                if (strOfficeTypeId == "- Select -")
                    strOfficeTypeId = "";

                if (strElectionTypeId == "- Select -")
                    strElectionTypeId = "";

                if (strElectionYearId == "- Select -")
                    strElectionYearId = "";

                if (lstResigTermType == "- Select -")
                    lstResigTermType = "";

                if (txtCommitteeName != "")
                    txtCommitteeName = Session["CommID"].ToString();

                if (strFilerId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("REQUIRED_FILER", strFilerId.ToString());
                    if (!results)
                        ModelState.AddModelError("txtFilerID", "Invalid Filer Id");
                }
                else
                {
                    ModelState.AddModelError("txtFilerID", "Filer Id is required");
                }
                if (txtCommitteeName != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("CANDIDATE_COMMITTEE", txtCommitteeName.ToString());
                    if (!results)
                        ModelState.AddModelError("txtCommitteeName", "Invalid Candidate/Committee Name");
                }
                else
                {
                    ModelState.AddModelError("txtCommitteeName", "Candidate/Committee Name is required");
                }
                if (strElectionYearId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_YEAR", strElectionYearId.ToString());
                    if (!results)
                        ModelState.AddModelError("lstElectionCycle", "Invalid Report Year");
                }
                else
                {
                    ModelState.AddModelError("lstElectionCycle", "Report Year is required");
                }
                if (strOfficeTypeId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("OFFICE_TYPE", strOfficeTypeId.ToString());
                    if (!results)
                        ModelState.AddModelError("lstUCOfficeType", "Invalid Filer Type");
                }
                else
                {
                    ModelState.AddModelError("lstUCOfficeType", "Filer Type is required");
                }
                if (strOfficeTypeId != "")
                {
                    if (strOfficeTypeId == "2")
                    {
                        if (lstUCCounty != "")
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("COUNTY", lstUCCounty.ToString());
                            if (!results)
                                ModelState.AddModelError("lstUCCounty", "Invalid County");
                        }
                        else
                        {
                            ModelState.AddModelError("lstUCCounty", "County is required");
                        }
                        if (lstUCMuncipality != "")
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("MUNICIPALITY", lstUCMuncipality.ToString());
                            if (!results)
                                ModelState.AddModelError("lstUCMuncipality", "Invalid Municipality");
                        }
                        else
                        {
                            ModelState.AddModelError("lstUCCounty", "Municipality is required");
                        }
                    }
                }
                if (strElectionTypeId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_TYPE", strElectionTypeId.ToString());
                    if (!results)
                        ModelState.AddModelError("lstElectionType", "Invalid Election Type");
                }
                else
                {
                    ModelState.AddModelError("lstElectionType", "Election Type is required");
                }
                if (strElectionTypeId.ToString() != "6")
                {
                    if (strElectionTypeId.ToString() != "8")
                    {
                        if (strElectionDateId != "- Select -")
                        {
                            if (strElectionDateId != "")
                            {
                                if (strElectionDateId != null)
                                {
                                    // Call Procedure
                                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_DATES", strElectionDateId.ToString());
                                    if (!results)
                                        ModelState.AddModelError("lstElectionDate", "Invalid Election Date");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("lstElectionDate", "Election Date is required");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("lstElectionDate", "Election Date is required");
                        }
                    }
                }

                if (lstDisclosureType != "0")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_CATEGORY", lstDisclosureType.ToString());
                    if (!results)
                        ModelState.AddModelError("lstDisclosureType", "Invalid Disclosure Type");
                }
                else
                {
                    ModelState.AddModelError("lstDisclosureType", "Disclosure Type is required");
                }
                if (lstDisclosureType == "1")
                {
                    if (lstDisclosurePeriod != "")
                    {
                        // Call Procedure
                        Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TYPE", lstDisclosurePeriod.ToString());
                        if (!results)
                            ModelState.AddModelError("lstDisclosurePeriod", "Invalid Disclosure Period");
                    }
                    else
                    {
                        ModelState.AddModelError("lstDisclosurePeriod", "Disclosure Period is required");
                    }
                }
                if (strElectionTypeId.ToString() != "6")
                {
                    if (lstDisclosureType.ToString() != "5")
                    {
                        if (lstDisclosureType.ToString() != "7" && lstDisclosureType.ToString() != "10" && lstDisclosureType.ToString() != "9" && lstDisclosureType.ToString() != "12")
                        {
                            // NEW LOGIC CHANGE ON 10-DAY POST PRIMARY ON PRIMARY ELECTION
                            // WE ARE NOT SHOWING FOR YEAR 2021 AND ABOVE THE 10-DAY POST PRIMARY IN DISCLOSURE PERIOD DROPDOWN.
                            // WE ARE NOT CHANGING FOR YEAR 2020 AND BELOW NO CHANGES.
                            String checkFilingDateOrNot = String.Empty;
                            if (strElectionTypeId.ToString() == "2")
                            {
                                int eleYear = Convert.ToInt32(strElectionYear.ToString());
                                int valYear = 2021;
                                if (eleYear >= valYear)
                                    checkFilingDateOrNot = "True";
                                else
                                    checkFilingDateOrNot = "False";
                            }
                            else
                            {
                                checkFilingDateOrNot = "False";
                            }

                            if (checkFilingDateOrNot == "False")
                            {
                                IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();
                                lstFilingCutOffDateModel = (IList<FilingCutOffDateModel>)Session["FilingAndCutOffDate"];

                                String cutOffDateLabelId = String.Empty;
                                String filingDateLabelId = String.Empty;

                                if (txtReportPeriodDatesFrom != "" && txtReportPeriodDatesTo != "")
                                {
                                    foreach (var item in lstFilingCutOffDateModel)
                                    {
                                        if (item != null)
                                        {
                                            if (item.FilingDueDate != null)
                                                filingDateLabelId = item.PoliticalCalLabelId;
                                            else if (item.CutOffDate != null)
                                                cutOffDateLabelId = item.PoliticalCalLabelId;
                                        }
                                    }
                                }

                                if (txtNewFilingDate == "")
                                {
                                    if (txtReportPeriodDatesFrom != "")
                                    {
                                        // Call Procedure
                                        Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_LABEL", filingDateLabelId);
                                        if (!results)
                                            ModelState.AddModelError("txtReportPeriodDatesFrom", "Invalid Cut off Date");
                                    }
                                    //else
                                    //{
                                    //    ModelState.AddModelError("txtReportPeriodDatesFrom", "Cut off Date is required");
                                    //}
                                    if (txtReportPeriodDatesTo != "")
                                    {
                                        // Call Procedure
                                        Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_LABEL", cutOffDateLabelId);
                                        if (!results)
                                            ModelState.AddModelError("txtReportPeriodDatesTo", "Invalid Filing Date");
                                    }
                                    //else
                                    //{
                                    //    ModelState.AddModelError("txtReportPeriodDatesTo", "Filing Date is required");
                                    //}
                                }
                            }
                            else
                            {
                                // NEW LOGIC CHANGE ON 10-DAY POST PRIMARY ON PRIMARY ELECTION
                                // WE ARE NOT SHOWING FOR YEAR 2021 AND ABOVE THE 10-DAY POST PRIMARY IN DISCLOSURE PERIOD DROPDOWN.
                                // WE ARE NOT CHANGING FOR YEAR 2020 AND BELOW NO CHANGES.

                                if (lstFilingDate != "- Select -")
                                {
                                    if (lstFilingDate == "- New Filing Date -")
                                    {
                                        DateTime dDate;
                                        // Current Date.
                                        if (String.IsNullOrEmpty(txtNewFilingDate))
                                        {
                                            ModelState.AddModelError("txtNewFilingDate", "Filing Date is required");
                                        }
                                        else if (!objCommonErrorsServerSide.DateUS(txtNewFilingDate))
                                        {
                                            ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                                        }
                                        else if (!DateTime.TryParse(txtNewFilingDate, out dDate))
                                        {
                                            ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                                        }
                                        else if (!objCommonErrorsServerSide.FilingDateValidation(txtNewFilingDate, strElectionYear))
                                        {
                                            ModelState.AddModelError("txtNewFilingDate", "Filing Date within the Election Year");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (lstFilingDate != "- Select -")
                            {
                                if (lstFilingDate == "- New Filing Date -")
                                {
                                    DateTime dDate;
                                    // Current Date.
                                    if (String.IsNullOrEmpty(txtNewFilingDate))
                                    {
                                        ModelState.AddModelError("txtNewFilingDate", "Filing Date is required");
                                    }
                                    else if (!objCommonErrorsServerSide.DateUS(txtNewFilingDate))
                                    {
                                        ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                                    }
                                    else if (!DateTime.TryParse(txtNewFilingDate, out dDate))
                                    {
                                        ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                                    }
                                    else if (!objCommonErrorsServerSide.FilingDateValidation(txtNewFilingDate, strElectionYear))
                                    {
                                        ModelState.AddModelError("txtNewFilingDate", "Filing Date within the Election Year");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (lstFilingDate != "- Select -")
                    {
                        if (lstFilingDate == "- New Filing Date -")
                        {
                            DateTime dDate;
                            // Current Date.
                            if (String.IsNullOrEmpty(txtNewFilingDate))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Filing Date is required");
                            }
                            else if (!objCommonErrorsServerSide.DateUS(txtNewFilingDate))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                            }
                            else if (!DateTime.TryParse(txtNewFilingDate, out dDate))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                            }
                            else if (!objCommonErrorsServerSide.FilingDateValidation(txtNewFilingDate, strElectionYear))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Filing Date within the Election Year");
                            }
                        }
                    }
                }
                if (lstResigTermType != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("RESIGNATION_TERMINATION_TYPE", lstResigTermType);
                    if (!results)
                        ModelState.AddModelError("lstResigTermType", "Invalid Resignation/Termination");
                }

                if (ModelState.IsValid)
                {
                    var results = true;
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetValidateFilter

        #region GetResgTermTypeData
        /// <summary>
        /// GetResgTermTypeData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetResgTermTypeData()
        {
            try
            {
                IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();

                lstResigTermTypeModel = objItemizedReportsBroker.GeResigTermTypeDataResponse();

                //// Bind Partner Data
                //ViewData["lstResigTermType"] = new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc");

                return Json(new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetResgTermTypeData

        #region GetResgTermTypeExists
        /// <summary>
        /// GetResgTermTypeExists
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <returns></returns>
        public JsonResult GetResgTermTypeExists(String txtFilerId, String lstElectionType, String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionCycleId, String strElectionDateId, String strFilingDateOffCycle, String strFilingDate, String strFilingCategoryId, String lstFilingDate, String lstUCMuncipality)
        {            

            try
            {
                IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();

                if (strFilingDateOffCycle == "- Select -")
                    strFilingDateOffCycle = "";
                if (strFilingCategoryId == null)
                    strFilingCategoryId = "";
                if (strFilingCategoryId == "- Select -")
                    strFilingCategoryId = "";
                if (strElectionDateId == "- Select -")
                    strElectionDateId = "";

                if (lstElectionType == "6")
                    lstDisclosurePeriod = "12";

                if ((lstUCMuncipality == "- Select -") || (String.IsNullOrEmpty(lstUCMuncipality)))
                    lstUCMuncipality = "";

                if (lstElectionType == "6")
                {
                    // ONLY FOR OFF-CYCLE.
                    Session["ElectionCycleVal"] = "0";
                    Session["ElectionTypeVal"] = "0";
                    Session["OfficeTypeVal"] = "0";
                    Session["CountyVal"] = "0";
                    Session["MunicipalityVal"] = "0";

                    Session["ElectionCycleVal_Dup"] = "0";
                    Session["ElectionTypeVal_Dup"] = "0";
                    Session["OfficeTypeVal_Dup"] = "0";
                    Session["CountyVal_Dup"] = "0";
                    Session["MunicipalityVal_Dup"] = "0";

                    if (lstFilingDate != null)
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            lstResigTermTypeModel = objItemizedReportsBroker.GetResgTermTypeExistsValueResponse(txtFilerId, lstElectionType, lstUCOfficeType, lstDisclosurePeriod, lstElectionCycleId, strElectionDateId, strFilingDateOffCycle.Trim(), strFilingCategoryId, lstUCMuncipality);
                        else
                            lstResigTermTypeModel = objItemizedReportsBroker.GetResgTermTypeExistsValueResponse(txtFilerId, lstElectionType, lstUCOfficeType, lstDisclosurePeriod, lstElectionCycleId, strElectionDateId, lstFilingDate.Trim(), strFilingCategoryId, lstUCMuncipality);
                    }
                    else
                    {
                        lstResigTermTypeModel = objItemizedReportsBroker.GetResgTermTypeExistsValueResponse(txtFilerId, lstElectionType, lstUCOfficeType, lstDisclosurePeriod, lstElectionCycleId, strElectionDateId, strFilingDateOffCycle.Trim(), strFilingCategoryId, lstUCMuncipality);
                    }
                }
                else
                {
                    lstResigTermTypeModel = objItemizedReportsBroker.GetResgTermTypeExistsValueResponse(txtFilerId, lstElectionType, lstUCOfficeType, lstDisclosurePeriod, lstElectionCycleId, strElectionDateId, strFilingDate, strFilingCategoryId, lstUCMuncipality);
                }

                if (lstResigTermTypeModel.Count() == 1)
                {
                    Session["ResgTermTypeFilings"] = lstResigTermTypeModel;

                    return Json(lstResigTermTypeModel, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    lstResigTermTypeModel = lstResigTermTypeModel.Where(x => x.ResigTermTypeId == "1").ToList();

                    Session["ResgTermTypeFilings"] = lstResigTermTypeModel;

                    return Json(lstResigTermTypeModel, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetResgTermTypeExists

        #region UpdateResgTermTypeValue
        /// <summary>
        /// UpdateResgTermTypeValue
        /// </summary>
        /// <param name="lstResigTermType"></param>
        /// <returns></returns>
        public JsonResult UpdateResgTermTypeValue(String lstResigTermType)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.            

                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;
                if (lstResigTermType == "")
                    lstResigTermType = null;

                IList<ResigTermTypeModel> lstResigTermTypeFilingsModel = new List<ResigTermTypeModel>();

                lstResigTermTypeFilingsModel = (IList<ResigTermTypeModel>)Session["ResgTermTypeFilings"];

                String strFilingsId = lstResigTermTypeFilingsModel.Select(x => x.FilingsId).First().ToString();

                Boolean results = objItemizedReportsBroker.UpdateResgTermTypeFilingsResponse(strFilingsId, lstResigTermType, strModifiedBy);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateResgTermTypeValue

        #region AddNonItemizedSetPrefPerFilerId
        /// <summary>
        /// AddNonItemizedSetPrefPerFilerId
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public JsonResult AddNonItemizedSetPrefPerFilerId(String strFilerId, String strFilingTypeId)
        {
            try
            {
                String strCreatedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.                                   

                Boolean results = objItemizedReportsBroker.AddNonItemSetPrefPerFilerResponse(strFilerId, strFilingTypeId, strCreatedBy);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AddNonItemizedSetPrefPerFilerId

        #region GetElectionExists
        /// <summary>
        /// GetElectionExists
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetElectionExists(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId, String strCounty, String strMunicipality)
        {
            if ((strMunicipality == "- Select -") || (String.IsNullOrEmpty(strMunicipality)))
                strMunicipality = "";
            if ((strCounty == "- Select -") || (String.IsNullOrEmpty(strCounty)))
                strCounty = "";

            try
            {
                Boolean results;

                if (strCounty == null)
                {
                    strCounty = "";
                }
                if (strMunicipality == null)
                {
                    strMunicipality = "";
                }

                if (strElectionTypeId != "6" && strElectionTypeId != "4")
                {
                    if (strElectionTypeId != "8")
                    {
                        results = objItemizedReportsBroker.GetEelectionExistsEFSResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strElectionDateId, strMunicipality);
                    }
                    else
                    {
                        // GET ELECTION DATE FOR PRIMARY AND GENERAL ELECTION TYPE.
                        String strElectionDatePrimary = String.Empty;
                        String strElectionDateGeneral = String.Empty;
                        IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
                        lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(strElectionYearId, "2", strOfficeTypeId, strCounty, strMunicipality);
                        strElectionDatePrimary = lstElectionDateModel.Select(x => x.ElectId).FirstOrDefault();
                        lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(strElectionYearId, "3", strOfficeTypeId, strCounty, strMunicipality);
                        strElectionDateGeneral = lstElectionDateModel.Select(x => x.ElectId).FirstOrDefault();

                        // CHECK IF ITS 'PRIMARY AND GENERAL' ELECTION FOR NOTICE OF NON-PARTICIPATION 
                        // CHECK THE 'PRIMARY' AND 'GENERAL' ELECTION CREATED OR NOT...
                        // IF BOTH CREATED THEN ONLY IT WILL ALLOW TO CREATE 'PRIMARY AND GENERAL' ELECTION.
                        // FOR NOTICE OF NON-PARTICIAPTION....
                        // CHECK PRIMARY...
                        results = objItemizedReportsBroker.GetEelectionExistsEFSResponse(strElectionYearId, "2", strOfficeTypeId, strElectionDatePrimary, strMunicipality);
                        if (results)
                        {
                            // CHECK GENERAL....
                            results = objItemizedReportsBroker.GetEelectionExistsEFSResponse(strElectionYearId, "3", strOfficeTypeId, strElectionDateGeneral, strMunicipality);
                        }
                    }
                }
                else
                {
                    results = true;
                }

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetElectionExists       
        
        #region GetDefaultLookUpsValues
        /// <summary>
        /// GetDefaultLookUpsValues
        /// </summary>
        public void GetDefaultLookUpsValues()
        {
            try
            {

                IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
                if (Session["PersonId"] != null)
                    lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
                Session["PersonFilerId"] = lstFilerCommitteeModel;
                String strCandCommId = "";

                if (Session["Cand_Comm_Name"] != null)
                {
                    ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
                    ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
                }
                else
                {
                    Response.Redirect("~/RoleMap/RoleMap");
                }

                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                DisclosureTypesModel objDisclosureTypesModel;
                var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId); //GetDisclosureTypeData();
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
                        //if (!String.IsNullOrEmpty(item.DisclosureSubTypeDesc))
                        //    objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " " + item.DisclosureSubTypeDesc;
                        //else
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                        lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                    }
                }
                // Bind Disclosure Type
                ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
                                                                                                        // Bind Transaction Type - Itemized.
                ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");
                // Bind Transaction Type for Non-Itemized - 24-Hour Notice.            
                ViewData["lstTransactionTypeNonItem"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");
                // IE Weekly Expenditure Transaction Types
                IList<TransactionTypesModel> lstTransactionTypeModelWeeklyExp = new List<TransactionTypesModel>();
                lstTransactionTypeModelWeeklyExp = objItemizedReportsBroker.GetIEWeeklyExpTransactionTypesResponse(); ; //GetTransactionTypeData();
                                                                                                                        // Bind Transaction Type - Itemized.
                ViewData["lstTransTypeNonItemWeeklyExp"] = new SelectList(lstTransactionTypeModelWeeklyExp, "FilingSchedId", "FilingSchedDesc");

                // =====================================================================================================================================
                // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
                // Bind Filing Date for Off Cycle.
                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModelResults = new List<FilingDatesOffCycleModel>();
                FilingDatesOffCycleModel objFilingDatesOffCycleModel;
                if (Session["ElectionYearId"] != null && Session["OfficeTypeId"] != null && Session["FilerIdOffCycle"] != null && Session["DisclosureType"] != null && Session["DisclosureType"] != null)
                {
                    lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(Session["ElectionYearId"].ToString(), Session["OfficeTypeId"].ToString(), Session["FilerIdOffCycle"].ToString(), Session["DisclosureType"].ToString());
                    objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                    objFilingDatesOffCycleModel.FilingDateId = "- Select -";
                    objFilingDatesOffCycleModel.FilingDate = "- Select -";
                    lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                    objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
                    objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
                    lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                }
                else
                {
                    lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(String.Empty, String.Empty, String.Empty, String.Empty);
                    objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                    objFilingDatesOffCycleModel.FilingDateId = "- Not Applicable -";
                    objFilingDatesOffCycleModel.FilingDate = "- Not Applicable -";
                    lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                    objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
                    objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
                    lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                }
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
                lstResigTermTypeModel = objItemizedReportsBroker.GeResigTermTypeDataResponse();
                // Bind Partner Data
                ViewData["lstResigTermType"] = new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc");
                // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
                // ====================================================================================================================================

                IList<PartnerModel> lstPartnerModel = new List<PartnerModel>();
                lstPartnerModel = GetPartnerData();
                // Bind Partner Data
                ViewData["lstPartner"] = new SelectList(lstPartnerModel, "PartnerId", "PartnerDesc");

                IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
                lstElectionYearModel = objItemizedReportsBroker.GetElectionYearDataResponse(Session["FilerID"].ToString());
                // Report Year
                ViewData["lstElectionCycle"] = new SelectList(lstElectionYearModel, "ElectionYearId", "ElectionYearValue");

                IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
                if (Session["ElectionTypes"] != null)
                {
                    lstElectionTypeModel = (IList<ElectionTypeModel>)Session["ElectionTypes"];
                }
                else
                {
                    lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
                }
                // Election Type
                ViewData["lstElectionType"] = new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc");

                IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
                if (Session["ElectionCycleVal"] != null)
                {
                    String strElectionCycle = Session["ElectionCycleVal"].ToString();
                    String strElectionType = Session["ElectionTypeVal"].ToString();
                    String strOffictType = Session["OfficeTypeVal"].ToString();
                    String strCounty = Session["CountyVal"].ToString();
                    String strMunicipality = Session["MunicipalityVal"].ToString();

                    lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(strElectionCycle, strElectionType, strOffictType, strCounty, strMunicipality);
                }
                else
                {
                    Session["ElectionCycleVal"] = String.Empty;
                    Session["ElectionTypeVal"] = String.Empty;
                    Session["OfficeTypeVal"] = String.Empty;
                    Session["CountyVal"] = String.Empty;
                    Session["MunicipalityVal"] = String.Empty;

                    Session["ElectionCycleVal_Dup"] = String.Empty;
                    Session["ElectionTypeVal_Dup"] = String.Empty;
                    Session["OfficeTypeVal_Dup"] = String.Empty;
                    Session["CountyVal_Dup"] = String.Empty;
                    Session["MunicipalityVal_Dup"] = String.Empty;

                    lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(String.Empty, String.Empty, String.Empty, "", "");
                }
                // Electin Date
                ViewData["lstElectionDate"] = new SelectList(lstElectionDateModel, "ElectId", "ElectDate");

                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                if (Session["DisclosurePeriods"] != null)
                {
                    lstDisclosurePreiodModel = (IList<DisclosurePreiodModel>)Session["DisclosurePeriods"];
                }
                else
                {
                    lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(), "");
                }
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
                if (Session["OfficeTypes"] != null)
                {
                    lstOfficeTypeModel = (IList<OfficeTypeModel>)Session["OfficeTypes"];
                }
                else
                {
                    lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeResponse();
                }
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
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDefaultLookUpsValues                

        #region AuthenticateFilerID
        /// <summary>
        /// Get Filer ID
        /// </summary>
        /// <returns></returns>
        public JsonResult AuthenticateFilerID()
        {
            try
            {
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
                lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserName"].ToString());
                Session["lstValidateFilerInfo"] = lstValidateFilerInfo;
                //Session["UserName"] = txtLoginID;            
                return Json(new SelectList(lstValidateFilerInfo, "FilerID", "Name"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AuthenticateFilerID

        #region Grid Help
        /// <summary>
        /// ActiveDeactiveFilerGridHelp
        /// </summary>
        /// <returns></returns>
        //public ActionResult ActiveDeactiveFilerGridHelp()
        //{
        //    return View("ActiveDeactiveFilerGridHelp");
        //}
        #endregion Grid Help

        #region Filer Help
        /// <summary>
        /// ContributionsMonetarySearchHelp
        /// </summary>
        /// <returns></returns>
        public ActionResult ContributionsMonetarySearchHelp()
        {
            return View("ContributionsMonetarySearchHelp");
        }
        #endregion Filer Help    

        #region CheckSessionValues
        // COMMON CODE FOR CHECK SESSION VALUES.
        /// <summary>
        /// CheckSessionValues
        /// </summary>
        public void CheckSessionValues()
        {
            if (Session["ElectionCycleVal"] == null)
            {
                Session["ElectionCycleVal"] = Session["ElectionCycleVal_Dup"];
            }
            else if (Session["ElectionCycleVal"].ToString() == "")
            {
                Session["ElectionCycleVal"] = Session["ElectionCycleVal_Dup"];
            }

            if (Session["ElectionTypeVal"] == null)
            {
                Session["ElectionTypeVal"] = Session["ElectionTypeVal_Dup"];
            }
            else if (Session["ElectionTypeVal"].ToString() == "")
            {
                Session["ElectionTypeVal"] = Session["ElectionTypeVal_Dup"];
            }

            if (Session["OfficeTypeVal"] == null)
            {
                Session["OfficeTypeVal"] = Session["OfficeTypeVal_Dup"];
            }
            else if (Session["OfficeTypeVal"].ToString() == "")
            {
                Session["OfficeTypeVal"] = Session["OfficeTypeVal_Dup"];
            }

            if (Session["CountyVal"] == null)
            {
                Session["CountyVal"] = Session["CountyVal_Dup"];
            }
            else if (Session["CountyVal"].ToString() == "")
            {
                Session["CountyVal"] = Session["CountyVal_Dup"];
            }

            if (Session["MunicipalityVal"] == null)
            {
                Session["MunicipalityVal"] = Session["MunicipalityVal_Dup"];
            }
            else if (Session["MunicipalityVal"].ToString() == "")
            {
                Session["MunicipalityVal"] = Session["MunicipalityVal_Dup"];
            }
        }
        #endregion CheckSessionValues

        #region GetTransactionTypesForWeeklyClaim
        /// <summary>
        /// GetTransactionTypesForWeeklyClaim
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTransactionTypesForWeeklyClaim()
        {
            try
            {
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();

                lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesForWeeklyClaimBroker();

                return Json(new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetTransactionTypesForWeeklyClaim

        #region MyRegion
        /// <summary>
        /// AddWeeklyClaimSubItemizedTrans
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="lstFilingDate"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <param name="txtCuttOffDate"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddWeeklyClaimSubItemizedTrans(String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, 
                                                         String strElectionTypeId, String strElectionDateId, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                IList<FilingTransactionsModel> lstFilingTransactionsModelNew = new List<FilingTransactionsModel>();
                lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["ItemizedWCSTrans"];
                FilingTransactionsModel objFilingTransactionsModel;

                foreach (var item in lstFilingTransactionDataModel)
                {
                    objFilingTransactionsModel = new FilingTransactionsModel();
                    objFilingTransactionsModel.TransNumber = item.TransNumber;
                    lstFilingTransactionsModelNew.Add(objFilingTransactionsModel);
                }                
                String strFilerId = Session["FilerId"].ToString();
                String strCreatedBy = Session["UserName"].ToString();

                String strFilingDate = String.Empty;
                                
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        strFilingDate = txtReportPeriodDatesTo;
                    else
                        strFilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    strFilingDate = txtReportPeriodDatesTo;
                }

                var results = objItemizedReportsBroker.AddWeeklyClaimSubItemizedTransBroker(lstFilingTransactionsModelNew, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion


        /// <summary>
        /// GetFilingCutOffDateData_PCF_WCS
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <returns></returns>
        public JsonResult GetFilingCutOffDateData_PCF_WCS(String lstElectionCycle, String lstElectionType, String lstUCOfficeType)
        {
            try
            {
                Session["ElectionYearId"] = lstElectionCycle;
                Session["OfficeTypeId"] = lstUCOfficeType;
                Session["ElectionTypeId"] = lstElectionType;


                if (lstUCOfficeType == "1")
                    lstUCOfficeType = "4";

                IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

                lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateData_PCF_WCS_Broker(lstElectionCycle, lstElectionType, lstUCOfficeType);

                Session["FilingAndCutOffDate_PCF_WCS"] = lstFilingCutOffDateModel;

                return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}

