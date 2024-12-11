using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_DR_SchedRController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_DR_SchedR/
        public ActionResult _UC_DR_SchedR()
        {
            return View();
        }

        public JsonResult GetSchedRSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateAllocated = "01/07/2016";
                objContributionsMonetaryModel.ElectionYearAllocated = "2016";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.District = "Albany";
                objContributionsMonetaryModel.Office = "Albany";
                objContributionsMonetaryModel.OriginalAllocationDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalAmtAllocated = "$100.00";
                objContributionsMonetaryModel.AmtAllocatedThisReport = "$50.00";
                objContributionsMonetaryModel.AmtAllocatedAllReport = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateAllocated = "01/07/2016";
                objContributionsMonetaryModel.ElectionYearAllocated = "2016";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.District = "Albany";
                objContributionsMonetaryModel.Office = "Albany";
                objContributionsMonetaryModel.OriginalAllocationDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalAmtAllocated = "$200.00";
                objContributionsMonetaryModel.AmtAllocatedThisReport = "$75.00";
                objContributionsMonetaryModel.AmtAllocatedAllReport = "$200.00";
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
                    x.AmtAllocatedAllReport,
                    x.AmtAllocatedAllReport,
                    x.Explanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_SchedRController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }
	}
}