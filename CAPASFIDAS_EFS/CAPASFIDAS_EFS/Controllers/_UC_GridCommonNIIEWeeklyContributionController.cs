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
    public class _UC_GridCommonNIIEWeeklyContributionController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        // GET: _UC_GridCommonNIIEWeeklyContribution
        public ActionResult _UC_GridCommonNIIEWeeklyContribution()
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
                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "IE-WeeklyContribution");
                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();
                return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyContribution", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                                             "IE-WeeklyContribution",
                                             uniqueValue,
                                             "Admin");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyContribution", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion UpdateColumnValue

        #region Get24HourNoticeTransactions
        /// <summary>
        /// Get24HourNoticeTransactions
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetIEWeeklyContributionTransactions(String txtFilerID, String lstElectionCycle, String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String lstFilingDate, String txtNewFilingDate, String lstUCMuncipality)
        {
            try
            {
                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                if (lstFilingDate == "- New Filing Date -")
                {
                    objFilingTransDataModel.FilingDate = txtNewFilingDate;
                }
                else
                {
                    objFilingTransDataModel.FilingDate = lstFilingDate.Trim();
                }
                objFilingTransDataModel.MunicipalityID = lstUCMuncipality;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransIEWeeklyContributioneDataResponse(objFilingTransDataModel);

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
                    x.ContributorTypeId,
                    x.PaymentTypeId,
                    x.LoanerCodeID,
                    x.ContributionTypeId,
                    "",
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.ContributionTypeDesc,
                    x.LoanerCode,
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
                    x.ContributorOccupation,
                    x.ContributorEmployer,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.IESupported,
                    x.CreatedDate,
                    x.AddrId,
                    x.TreasId,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyContribution", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion Get24HourNoticeTransactions

        #region GetEditTransactionData
        /// <summary>
        /// GetEditTransactionData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetEditTransactionData(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                //lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["IEWeeklyContributionTransData"]; 
                lstFilingTransactionDataModel = objItemizedReportsBroker.GetCommEditIETransDataResponse(strTransNumber, Session["FilerID"].ToString());

                lstFilingTransactionDataModel = lstFilingTransactionDataModel.Where(x => x.TransNumber == strTransNumber).ToList();

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyContribution", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            

        }
        #endregion GetEditTransactionData

        #region GetColumnUpdatedValueIEWeeklyContribution
        /// <summary>
        /// GetColumnUpdatedValueIEWeeklyContribution
        /// </summary>
        /// <param name="uniqudId"></param>
        /// <returns></returns>
        public JsonResult GetColumnUpdatedValueIEWeeklyContribution(String uniqudId)
        {
            try
            {
                IList<ViewableColumnModel> lstViewableColumn = new List<ViewableColumnModel>();

                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "IE-WeeklyContribution");

                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();

                return Json(lstViewableColumn, JsonRequestBehavior.AllowGet);
                //return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyContribution", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetColumnUpdatedValueIEWeeklyContribution
    }
}