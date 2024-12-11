using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_I_LoanReceivedController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_LoanReceived/
        public ActionResult _UC_I_LoanReceived()
        {
            try
            {
                // Bind Filer Name
                var lstLoanerCode = new SelectList(new[]
                                              {
                                              new {ID="Candidate",Name="Candidate"},
                                              new{ID="Individual",Name="Individual"},
                                              new{ID="Family",Name="Family"},
                                              new{ID="Partnership",Name="Partnership"},
                                              new{ID="Unitemized",Name="Unitemized"},
                                          },
                                "ID", "Name", 1);
                ViewData["lstLoanerCode"] = lstLoanerCode;
                return View();
            }
            catch (Exception ex)
            {                
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_I_LoanReceivedController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        public JsonResult GetLoanReceivedSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "01/01/2016";
                objContributionsMonetaryModel.LoanerCode = "Candidate";
                objContributionsMonetaryModel.PartnershipName = "";
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
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "2015";
                objContributionsMonetaryModel.LoanerCode = "Individual";
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
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "2015";
                objContributionsMonetaryModel.LoanerCode = "Family";
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
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "2015";
                objContributionsMonetaryModel.LoanerCode = "Partnership";
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
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "2015";
                objContributionsMonetaryModel.LoanerCode = "Unitemized";
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
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.LoanDate,
                    x.LoanerCode,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_I_LoanReceivedController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}