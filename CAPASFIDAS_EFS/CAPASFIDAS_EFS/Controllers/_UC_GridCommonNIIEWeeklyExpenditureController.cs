using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_GridCommonNIIEWeeklyExpenditureController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        // GET: _UC_GridCommonNIIEWeeklyExpenditure
        public ActionResult _UC_GridCommonNIIEWeeklyExpenditure()
        {
            return View();
        }

        #region GetColumns
        /// <summary>
        /// GetColumns
        /// </summary>
        /// <param name="uniqudId"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public JsonResult GetColumns(string uniqudId, string applicationName, string pageName)
        {
            try
            {
                IList<ViewableColumnModel> lstViewableColumn = new List<ViewableColumnModel>();
                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "IE-WeeklyExpenditure");
                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();
                return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetColumns

        #region UpdateColumnValue
        /// <summary>
        /// Update Column Value
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="modifyBy"></param>
        /// <returns></returns>
        public JsonResult UpdateColumnValue(String uniqueValue)
        {
            try
            {
                //Update Column data
                bool result = true;
                result = objItemizedReportsBroker.UpdateColumnValueBroker(Session["FilerID"].ToString(),
                                             "EFS",
                                             "IE-WeeklyExpenditure",
                                             uniqueValue,
                                             "Admin");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion UpdateColumnValue

        #region GetIEWeeklyExpenditureTransactions
        /// <summary>
        /// GetIEWeeklyExpenditureTransactions
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetIEWeeklyExpenditureTransactions(String txtFilerID, String lstElectionCycle,
                String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String lstFilingDate, String txtNewFilingDate,
                String lstUCMuncipality)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;                
                if (lstFilingDate != "")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        objFilingTransDataModel.FilingDate = txtNewFilingDate;
                    }
                    else
                    {
                        objFilingTransDataModel.FilingDate = lstFilingDate.Trim();
                    }
                }
                else
                {
                    objFilingTransDataModel.FilingDate = txtNewFilingDate;
                }
                objFilingTransDataModel.MunicipalityID = lstUCMuncipality;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransIEWeeklyExpenditureDataResponse(objFilingTransDataModel);

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

                            if (lstFilingTransactionDataModel[i].SubmissionDate == null)
                                lstFilingTransactionDataModel[i].SubmissionDate = "";

                            lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                            lstFilingTransactionDataModel[i].CreatedDate24Hours = Convert.ToDateTime(lstFilingTransactionDataModel[i].CreatedDate).ToString("MM/dd/yyyy HH:mm:ss");
                        }
                    }
                }

                Session["IEWeeklyContributionTransData"] = lstFilingTransactionDataModel;

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.PurposeCodeId,
                    x.PaymentTypeId,
                    x.AddrId,
                    x.TreasId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.PurposeCodeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.TreasurerFirstName,
                    x.TreasurerLastName,
                    x.TreasurerMiddleName,
                    x.TreasurerOccuptaion,
                    x.TreasurerEmployer,
                    x.TreasurerStreetAddress,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.TreasurerZip,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.IESupported,
                    x.CreatedDate,
                    x.OwedAmount,
                    x.DateIncurredOrgAmtId,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.CreatedDate24Hours
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetIEWeeklyExpenditureTransactions

        #region GetIE24HourExpenditureTransactions
        /// <summary>
        /// GetIE24HourExpenditureTransactions
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetIE24HourExpenditureTransactions(String txtFilerID, String lstElectionCycle,
              String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String lstFilingDate, String txtNewFilingDate)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                Session["IEWeeklyContributionTransData"] = null;

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                objFilingTransDataModel.FilingDate = txtNewFilingDate;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransIE24HourExpenditureDataResponse(objFilingTransDataModel);

                //// GET THE FILINGS ID.
                //if (lstFilingTransactionDataModel.Count() > 0)
                //    Session["FilingsIdOutLiabAmount"] = lstFilingTransactionDataModel.Select(x => x.FilingsId).FirstOrDefault().ToString();

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
                            lstFilingTransactionDataModel[i].CreatedDate24Hours = Convert.ToDateTime(lstFilingTransactionDataModel[i].CreatedDate).ToString("MM/dd/yyyy HH:mm:ss");
                            if (lstFilingTransactionDataModel[i].SubmissionDate == null)
                                lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                    }
                }

                Session["IEWeeklyContributionTransData"] = lstFilingTransactionDataModel;

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.PurposeCodeId,
                    x.PaymentTypeId,
                    x.AddrId,
                    x.TreasId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.PurposeCodeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.TreasurerFirstName,
                    x.TreasurerLastName,
                    x.TreasurerMiddleName,
                    x.TreasurerOccuptaion,
                    x.TreasurerEmployer,
                    x.TreasurerStreetAddress,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.TreasurerZip,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.IESupported,
                    x.CreatedDate,
                    x.OwedAmount,
                    x.DateIncurredOrgAmtId,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.CreatedDate24Hours
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetIE24HourExpenditureTransactions

        #region GetIE24HourPIDAExpenditureTransactions
        /// <summary>
        /// GetIE24HourPIDAExpenditureTransactions
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetIE24HourPIDAExpenditureTransactions(String txtFilerID, String lstElectionCycle,
              String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String lstFilingDate, String txtNewFilingDate)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                Session["IEWeeklyContributionTransData"] = null;

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                objFilingTransDataModel.FilingDate = txtNewFilingDate;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransIE24HourPIDAExpenditureDataResponse(objFilingTransDataModel);

                //// GET THE FILINGS ID.
                //if (lstFilingTransactionDataModel.Count() > 0)
                //    Session["FilingsIdOutLiabAmount"] = lstFilingTransactionDataModel.Select(x => x.FilingsId).FirstOrDefault().ToString();

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
                            lstFilingTransactionDataModel[i].CreatedDate24Hours = Convert.ToDateTime(lstFilingTransactionDataModel[i].CreatedDate).ToString("MM/dd/yyyy HH:mm:ss");
                            if (lstFilingTransactionDataModel[i].SubmissionDate == null)
                                lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                    }
                }

                Session["IEWeeklyContributionTransData"] = lstFilingTransactionDataModel;

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.PurposeCodeId,
                    x.PaymentTypeId,
                    x.AddrId,
                    x.TreasId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.PurposeCodeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.TreasurerFirstName,
                    x.TreasurerLastName,
                    x.TreasurerMiddleName,
                    x.TreasurerOccuptaion,
                    x.TreasurerEmployer,
                    x.TreasurerStreetAddress,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.TreasurerZip,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.IESupported,
                    x.CreatedDate,
                    x.OwedAmount,
                    x.DateIncurredOrgAmtId,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.CreatedDate24Hours
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetIE24HourPIDAExpenditureTransactions

        #region GetIEWeelyPIDAExpenditureTransactions
        /// <summary>
        /// GetIEWeelyPIDAExpenditureTransactions
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDateId"></param>
        /// <returns></returns>
        public JsonResult GetIEWeelyPIDAExpenditureTransactions(String txtFilerID, String lstElectionCycle,
                   String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String lstFilingDate, String txtNewFilingDate,
                   String lstUCMuncipality)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                if (lstFilingDate != "")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        objFilingTransDataModel.FilingDate = txtNewFilingDate;
                    }
                    else
                    {
                        objFilingTransDataModel.FilingDate = lstFilingDate.Trim();
                    }
                }
                else
                {
                    objFilingTransDataModel.FilingDate = txtNewFilingDate;
                }
                objFilingTransDataModel.MunicipalityID = lstUCMuncipality;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransIEWeeklyPIDAExpenditureDataResponse(objFilingTransDataModel);

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
                            lstFilingTransactionDataModel[i].CreatedDate24Hours = Convert.ToDateTime(lstFilingTransactionDataModel[i].CreatedDate).ToString("MM/dd/yyyy HH:mm:ss");
                        }
                    }
                }

                Session["IEWeeklyContributionTransData"] = lstFilingTransactionDataModel;

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.PurposeCodeId,
                    x.PaymentTypeId,
                    x.AddrId,
                    x.TreasId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.PurposeCodeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.TreasurerFirstName,
                    x.TreasurerLastName,
                    x.TreasurerMiddleName,
                    x.TreasurerOccuptaion,
                    x.TreasurerEmployer,
                    x.TreasurerStreetAddress,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.TreasurerZip,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.IESupported,
                    x.CreatedDate,
                    x.OwedAmount,
                    x.DateIncurredOrgAmtId,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.CreatedDate24Hours
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetIEWeelyPIDAExpenditureTransactions

        #region GetEditTransactionData
        /// <summary>
        /// GetEditTransactionData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetEditTransactionData(String strFilingTransId)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                //lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["IEWeeklyContributionTransData"]; 
                lstFilingTransactionDataModel = objItemizedReportsBroker.GetCommEditIETransDataResponse(strFilingTransId, Session["FilerID"].ToString());

                //lstFilingTransactionDataModel = lstFilingTransactionDataModel.Where(x => x.TransNumber == strFilingTransId).ToList();

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        if (lstFilingTransactionDataModel[i].SubmissionDate != null)
                        {
                            if (lstFilingTransactionDataModel[i].SubmissionDate.Contains("1/1/1900"))
                                lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                    }
                }

                return Json(lstFilingTransactionDataModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            

        }
        #endregion GetEditTransactionData

        #region GetColumnUpdatedValue24HN
        /// <summary>
        /// GetColumnUpdatedValue
        /// </summary>
        /// <param name="uniqudId"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public JsonResult GetColumnUpdatedValueIEExpenditure(String uniqudId)
        {
            try
            {
                IList<ViewableColumnModel> lstViewableColumn = new List<ViewableColumnModel>();

                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "IE-WeeklyExpenditure");

                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();

                return Json(lstViewableColumn, JsonRequestBehavior.AllowGet);
                //return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyExpenditure", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetColumnUpdatedValue24HN


    }
}