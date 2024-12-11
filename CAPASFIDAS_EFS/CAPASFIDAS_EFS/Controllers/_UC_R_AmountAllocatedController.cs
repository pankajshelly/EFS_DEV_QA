using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_R_AmountAllocatedController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_R_AmountAllocated/
        public ActionResult _UC_R_AmountAllocated()
        {
            return View();
        }

        public JsonResult GetAmountAllocatedSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateAllocated = "2016";
                objContributionsMonetaryModel.ElectionYearAllocated = "Test";
                objContributionsMonetaryModel.FirstName = "JESSICA";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "LOESER";
                objContributionsMonetaryModel.District = "Albany";
                objContributionsMonetaryModel.Office = "NYSBOE";
                objContributionsMonetaryModel.OriginalAllocationDate = "2016";
                objContributionsMonetaryModel.OriginalAmtAllocated = "$100.00";
                objContributionsMonetaryModel.AmtAllocatedThisReport = "$50.00";
                objContributionsMonetaryModel.AmtAllocatedAllReport = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateAllocated = "2015";
                objContributionsMonetaryModel.ElectionYearAllocated = "Test";
                objContributionsMonetaryModel.FirstName = "JESSICA";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "LOESER";
                objContributionsMonetaryModel.District = "Albany";
                objContributionsMonetaryModel.Office = "NYSBOE";
                objContributionsMonetaryModel.OriginalAllocationDate = "2016";
                objContributionsMonetaryModel.OriginalAmtAllocated = "$100.00";
                objContributionsMonetaryModel.AmtAllocatedThisReport = "$50.00";
                objContributionsMonetaryModel.AmtAllocatedAllReport = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateAllocated,
                    x.ElectionYearAllocated,
                    x.FirstName,
                    x.MI,
                    x.LastName,
                    x.District,
                    x.Office,
                    x.OriginalAllocationDate,
                    x.OriginalAmtAllocated,
                    x.AmtAllocatedThisReport,
                    x.AmtAllocatedAllReport,
                    x.Explanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {                
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_R_AmountAllocatedController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}