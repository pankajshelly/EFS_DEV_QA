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
    public class _UC_JQueryGridController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        // GET: _UC_JQueryGrid
        public ActionResult _UC_JQueryGrid()
        {
            return View();
        }

        #region Get Filing Transaction
        /// <summary>
        /// Get Filing Transaction
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <returns></returns>
        public JsonResult GetAllTransactionTypesData(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstDisclosurePeriod, String fiingTransID)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
                objFilingTransDataModel.FilingTransID = fiingTransID;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsDataResponse(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        lstFilingTransactionDataModel[i].OriginalAmount = "$" + lstFilingTransactionDataModel[i].OriginalAmount + ".00";
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
                    x.TransExplanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {                
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_JQueryGridController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion
    }
}