using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_DR_SchedPController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_DR_SchedP/
        public ActionResult _UC_DR_SchedP()
        {
            return View();
        }

        public JsonResult GetSchedPSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptCode = "IND";
                objContributionsMonetaryModel.ContributorName = "";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "M";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "12/02/2015";
                objContributionsMonetaryModel.ReceiptCode = "CORP";
                objContributionsMonetaryModel.ContributorName = "Corp Test";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptCode = "PART";
                objContributionsMonetaryModel.ContributorName = "Part Test";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptCode = "COMM";
                objContributionsMonetaryModel.ContributorName = "Comm Test";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptCode = "OTH";
                objContributionsMonetaryModel.ContributorName = "Oth Test";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptCode = "UNIT";
                objContributionsMonetaryModel.ContributorName = "";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "";
                objContributionsMonetaryModel.StreetName = "";
                objContributionsMonetaryModel.City = "";
                objContributionsMonetaryModel.State = "";
                objContributionsMonetaryModel.Zip5 = "";
                objContributionsMonetaryModel.Zip4 = "";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateReceived,
                    x.ReceiptCode,
                    x.ContributorName,
                    x.FirstName,
                    x.MI,
                    x.LastName,
                    x.Street,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip5,
                    x.Zip4,
                    x.Method,
                    x.Check,
                    x.Amount,
                    x.Explanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_SchedPController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }
	}
}