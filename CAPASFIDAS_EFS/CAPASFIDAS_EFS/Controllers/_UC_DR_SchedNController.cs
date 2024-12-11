using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_DR_SchedNController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_DR_SchedN/
        public ActionResult _UC_DR_SchedN()
        {
            return View();
        }

        public JsonResult GetSchedNSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.CreditorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.PurposeCode = "CMAIL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.CreditorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.PurposeCode = "CONSL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.CreditorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.PurposeCode = "CONSV";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.CreditorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.PurposeCode = "CNTRB";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.CreditorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.PurposeCode = "FUNDR";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.CreditorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.PurposeCode = "LITR";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateForgiven,
                    x.CreditorName,
                    x.Street,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip5,
                    x.Zip4,
                    x.OriginalLiabilityDate,
                    x.OriginalLiabilityAmt,
                    x.PurposeCode,
                    x.Method,
                    x.Amount,
                    x.Explanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_SchedNController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }
	}
}