using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_J_LoanRepaymentsController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_J_LoanRepayments/
        public ActionResult _UC_J_LoanRepayments()
        {
            return View();
        }

        public JsonResult GetLoanRepaymentsSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
                objContributionsMonetaryModel.LoanerCode = "Candidate";
                objContributionsMonetaryModel.LenderName = "";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "M";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLoanDate = "2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "12/02/2015";
                objContributionsMonetaryModel.LoanerCode = "Individual";
                objContributionsMonetaryModel.LenderName = "";
                objContributionsMonetaryModel.FirstName = "Jone";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLoanDate = "2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "2015";
                objContributionsMonetaryModel.LoanerCode = "Family";
                objContributionsMonetaryModel.LenderName = "";
                objContributionsMonetaryModel.FirstName = "Carol";
                objContributionsMonetaryModel.MI = "A";
                objContributionsMonetaryModel.LastName = "Franklin";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLoanDate = "2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "2015";
                objContributionsMonetaryModel.LoanerCode = "Partnership";
                objContributionsMonetaryModel.LenderName = "Test Partnership Name";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "Main Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLoanDate = "2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "2015";
                objContributionsMonetaryModel.LoanerCode = "Unitemized";
                objContributionsMonetaryModel.LenderName = "";
                objContributionsMonetaryModel.FirstName = "";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "";
                objContributionsMonetaryModel.Street = "";
                objContributionsMonetaryModel.StreetName = "";
                objContributionsMonetaryModel.City = "";
                objContributionsMonetaryModel.State = "";
                objContributionsMonetaryModel.Zip5 = "";
                objContributionsMonetaryModel.Zip4 = "";
                objContributionsMonetaryModel.OriginalLoanDate = "2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "";
                objContributionsMonetaryModel.Check = "";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateRefundReceived,
                    x.LoanerCode,
                    x.LenderName,
                    x.FirstName,
                    x.MI,
                    x.LastName,
                    x.Street,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip5,
                    x.Zip4,
                    x.OriginalLoanDate,
                    x.OriginalLoan,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_J_LoanRepaymentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        //public JsonResult GetPartnerSearchData()
        //{
        //    IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
        //    ContributionsMonetaryModel objContributionsMonetaryModel;

        //    //Bind 1st row
        //    objContributionsMonetaryModel = new ContributionsMonetaryModel();
        //    objContributionsMonetaryModel.ContributorName = "Partners";
        //    objContributionsMonetaryModel.FirstName = "JESSICA";
        //    objContributionsMonetaryModel.MI = "";
        //    objContributionsMonetaryModel.LastName = "LOESER";
        //    objContributionsMonetaryModel.Street = "Street";
        //    objContributionsMonetaryModel.StreetName = "North Pearl Street";
        //    objContributionsMonetaryModel.City = "Albany";
        //    objContributionsMonetaryModel.State = "NY";
        //    objContributionsMonetaryModel.Zip5 = "12206";
        //    objContributionsMonetaryModel.Zip4 = "1234";
        //    objContributionsMonetaryModel.Amount = "$50";
        //    objContributionsMonetaryModel.Explanation = "Test";
        //    lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

        //    return Json(new
        //    {
        //        aaData = lstContributionsMonetaryModel.Select(x => new[] {                     
        //            x.ContributorName,                    
        //            x.FirstName, 
        //            x.MI,
        //            x.LastName,                    
        //            x.Street,
        //            x.StreetName,
        //            x.City,
        //            x.State, 
        //            x.Zip5,
        //            x.Zip4,                                        
        //            x.Amount,
        //            x.Explanation
        //        })
        //    }, JsonRequestBehavior.AllowGet);
        //}

	}
}