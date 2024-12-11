using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_D_ContributionInKindController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /_UC_D_ContributionInKind/
        public ActionResult _UC_D_ContributionInKind()
        {
            return View();
        }

        public JsonResult GetContributionsInKindSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2016";
                objContributionsMonetaryModel.ContributorName = "Candidate";
                objContributionsMonetaryModel.PartnershipName = "";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "M";
                objContributionsMonetaryModel.LastName = "Cuomo";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.ContributionType = "Service Provided";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2015";
                objContributionsMonetaryModel.ContributorName = "Individual";
                objContributionsMonetaryModel.PartnershipName = "";
                objContributionsMonetaryModel.FirstName = "Jone";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.ContributionType = "Property Given";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2015";
                objContributionsMonetaryModel.ContributorName = "Family";
                objContributionsMonetaryModel.PartnershipName = "";
                objContributionsMonetaryModel.FirstName = "Carol";
                objContributionsMonetaryModel.MI = "A";
                objContributionsMonetaryModel.LastName = "Franklin";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2015";
                objContributionsMonetaryModel.ContributorName = "Partnership";
                objContributionsMonetaryModel.PartnershipName = "Test Partnership Name";
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
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.ContributionType = "TEST";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2015";
                objContributionsMonetaryModel.ContributorName = "Unitemized";
                objContributionsMonetaryModel.PartnershipName = "";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "";
                objContributionsMonetaryModel.StreetName = "";
                objContributionsMonetaryModel.City = "";
                objContributionsMonetaryModel.State = "";
                objContributionsMonetaryModel.Zip5 = "";
                objContributionsMonetaryModel.Zip4 = "";
                objContributionsMonetaryModel.Method = "";
                objContributionsMonetaryModel.Check = "";
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.ContributionType = "TEST1";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateReceived,
                    x.ContributorName,
                    x.PartnershipName,
                    x.FirstName,
                    x.MI,
                    x.LastName,
                    x.Street,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip5,
                    x.Zip4,
                    x.ContributionType,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_D_ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }
	}
}