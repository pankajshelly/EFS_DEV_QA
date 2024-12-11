/*
 * ===========================================================================================================================================
 * PAGE NAME: COMMON GRID FOR 24-HOUR NOTICE NON-ITEMIZED TRANSACTIONS.
 * AUTHOR NAME: SATHEESH K BASIREDDY
 * CREATED DATE: 04/11/2018
 * UPDATED BY:
 * UPDATED DATE:
 * ===========================================================================================================================================
 * CHANGE HISTORY:
 * 
 * 
*/

#region Namespaces
using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Configuration;
#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_GridCommonNonItem24HourNoticeController : Controller
    {
        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Variables

        // GET: _UC_GridCommonNonItem24HourNotice
        public ActionResult _UC_GridCommonNonItem24HourNotice()
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
                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "NonItemized24HNotice");
                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();
                return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {                
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNonItem24HourNoticeController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                                             "NonItemized24HNotice",
                                             uniqueValue,
                                             "Admin");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNonItem24HourNoticeController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult Get24HourNoticeTransactions(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String txtReportPeriodDatesTo)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                objFilingTransDataModel.FilingDate = txtReportPeriodDatesTo;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTrans24HourNoticeDataResponse(objFilingTransDataModel);

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

                //lstFilingTransactionDataModel = lstFilingTransactionDataModel.OrderBy(x => x.CreatedDate).ToList();

                Session["24HNoticeTransactions"] = lstFilingTransactionDataModel;

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
                    x.CreatedDate,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNonItem24HourNoticeController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetCommEdit24HourNoticeTransDataResponse(strTransNumber, Session["FilerID"].ToString());

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        if (lstFilingTransactionDataModel[i].SubmissionDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SubmissionDate = "";
                    }
                }

                return Json(lstFilingTransactionDataModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNonItem24HourNoticeController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult GetColumnUpdatedValue24HN(String uniqudId)
        {
            try
            {
                IList<ViewableColumnModel> lstViewableColumn = new List<ViewableColumnModel>();

                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "NonItemized24HNotice");

                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();

                return Json(lstViewableColumn, JsonRequestBehavior.AllowGet);
                //return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNonItem24HourNoticeController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetColumnUpdatedValue24HN

        #region GetDeleteFlag
        /// <summary>
        /// GetDeleteFlag
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeleteFlag(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactions = new List<FilingTransactionDataModel>();
                IList<ScheduleIdModel> lstScheduleIdModel = new List<ScheduleIdModel>();

                String strIsDeleted = String.Empty;

                lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["24HNoticeTransactions"];

                if (lstFilingTransactionDataModel.Count() > 0)
                {
                    // GET THE SUBMISSION DATE IF NOT SUBMITTED
                    var strSubmissionDate = lstFilingTransactionDataModel.Where(x => x.TransNumber == strTransNumber).Select(x => x.SubmissionDate).FirstOrDefault();
                    if (strSubmissionDate != null && strSubmissionDate != "")
                    {
                        // USER SHOULD NOT DELETE SUBMITTED LAST TRANSACTION.
                        // IF THEY DELETE LAST TRANSACTION IT WILL SHOW THE WARNING MESSAGE....                                  
                        lstFilingTransactions = lstFilingTransactionDataModel.Where(x => x.SubmissionDate != null).ToList();

                        if (lstFilingTransactions.Count() > 0)
                        {
                            // IF SCHEDULES COUNT 1 THEN ITS LANST TRANSACTION THEN YOU SCHOULD NOT DELETE.
                            // IF SCHEDULES MORE THAN 1 THEN USER CAN DELETE UNTIL ITS LAST TRANSACTION.
                            if (lstFilingTransactions.Count() == 1)
                            {
                                strIsDeleted = "False";
                            }
                            else
                            {
                                strIsDeleted = "True";
                            }
                        }
                        else
                        {
                            strIsDeleted = "True";
                        }
                    }
                    else
                    {
                        strIsDeleted = "True";
                    }
                }

                return Json(strIsDeleted, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNonItem24HourNoticeController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetDeleteFlag


    }
}