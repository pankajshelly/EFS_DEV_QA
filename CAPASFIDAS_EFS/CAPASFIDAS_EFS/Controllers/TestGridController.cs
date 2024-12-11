using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broker;
using System.Configuration;

namespace ImproveGrid.Controllers
{
    public class TestGridController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        // GET: TestGrid
        public ActionResult TestGrid()
        {
            return View();
        }

        public JsonResult GetAllTransactionTypesData(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstDisclosurePeriod)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsDataResponse(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("01/01/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
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
                        //lstFilingTransactionDataModel[i].OriginalAmount = "$" + lstFilingTransactionDataModel[i].OriginalAmount;// + ".00";
                        lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                        else if (lstFilingTransactionDataModel[i].OwedAmount != null && lstFilingTransactionDataModel[i].OwedAmount != "")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
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
                    x.RItemized,
                    x.CountyDesc,
                    x.MunicipalityDesc,
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TestGridController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
    }
}