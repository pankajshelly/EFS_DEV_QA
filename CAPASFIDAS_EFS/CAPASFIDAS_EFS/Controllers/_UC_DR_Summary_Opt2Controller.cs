using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_DR_Summary_Opt2Controller : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_DR_Summary_Opt2/
        public ActionResult _UC_DR_Summary_Opt2()
        {
            return View();
        }

        public JsonResult GetTotalContributionsData()
        {
            try
            {
                IList<TotalContributionsModel> lstContributionsMonetaryModel = new List<TotalContributionsModel>();
                TotalContributionsModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ContributorName = "Candidate";
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
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "12/02/2015";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ContributorName = "Candidate";
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
                objContributionsMonetaryModel.ContributionType = "Services/Facilities Provided";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "12/02/2015";
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
                objContributionsMonetaryModel.ContributionType = "Property Given";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new TotalContributionsModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                objContributionsMonetaryModel.Method = "";
                objContributionsMonetaryModel.Check = "";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateReceived,
                    x.Explanation,
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
                    x.Balance
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_Summary_Opt2Controller", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }

        public JsonResult GetTotalMiscellaneousData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptSource = "Test Soruce";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.ReceiptType = "Interest/Dividends";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptSource = "Test Soruce";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.ReceiptType = "Proceeds Sales/Lease";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ReceiptSource = "Test Soruce";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.ReceiptType = "Other";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.TransferorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.TransferType = "Type 1";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.TransferorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.TransferType = "Type 2";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "01/07/2016";
                objContributionsMonetaryModel.LoanerCode = "Candidate";
                objContributionsMonetaryModel.LenderGuarantorSingerName = "";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "12/02/2015";
                objContributionsMonetaryModel.LoanerCode = "Individual";
                objContributionsMonetaryModel.LenderGuarantorSingerName = "";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "01/07/2016";
                objContributionsMonetaryModel.LoanerCode = "Family";
                objContributionsMonetaryModel.LenderGuarantorSingerName = "";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "01/07/2016";
                objContributionsMonetaryModel.LoanerCode = "Partnership";
                objContributionsMonetaryModel.LenderGuarantorSingerName = "Test Partnership Name";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.LoanDate = "01/07/2016";
                objContributionsMonetaryModel.LoanerCode = "Unitemized";
                objContributionsMonetaryModel.LenderGuarantorSingerName = "";
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
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
                objContributionsMonetaryModel.PayorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalExpenseDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalAmt = "$100";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.RefundAmt = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
                objContributionsMonetaryModel.PayorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalExpenseDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalAmt = "$120";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.RefundAmt = "$120.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);


                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateReceived,
                    x.DateRefundReceived,
                    x.LoanDate,
                    x.Explanation,
                    x.ReceiptSource,
                    x.TransferorName,
                    x.LoanerCode,
                    x.LenderGuarantorSingerName,
                    x.PayeeName,
                    x.ReceiptCode,
                    x.ContractorName,
                    x.FirstName,
                    x.MI,
                    x.LastName,
                    x.Street,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip5,
                    x.Zip4,
                    x.ReceiptType,
                    x.TransferType,
                    x.OriginalExpenseDate,
                    x.OriginalAmt,
                    x.Method,
                    x.Check,
                    x.Amount,
                    x.RefundAmt,
                    x.Balance
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_Summary_Opt2Controller", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        public JsonResult GetTotalExpensesData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test Payeename";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CMAIL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test Payeename";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CONSL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test Payeename";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CONSV";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test Payeename";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CNTRB";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test Payeename";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "FUNDR";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test Payeename";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "LITR";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
                objContributionsMonetaryModel.ContributorName = "Candidate";
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
                objContributionsMonetaryModel.ContributionType = "Services/Facilities Provided";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "12/02/2015";
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
                objContributionsMonetaryModel.ContributionType = "Property Given";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "01/07/2016";
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
                objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
                objContributionsMonetaryModel.Method = "";
                objContributionsMonetaryModel.Check = "";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.TransfereeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.TransferType = "Type 1";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.TransfereeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.TransferType = "Type 2";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

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
                objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.AmtRepaid = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.AmtRepaid = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 3st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
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
                objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.AmtRepaid = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
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
                objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.AmtRepaid = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 4st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
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
                objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLoan = "$100.00";
                objContributionsMonetaryModel.Method = "";
                objContributionsMonetaryModel.AmtRepaid = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefunded = "01/07/2016";
                objContributionsMonetaryModel.ContributorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalCntrbDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalCntrbAmt = "$100";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.RefundAmt = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateRefunded = "01/07/2016";
                objContributionsMonetaryModel.ContributorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalCntrbDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalCntrbAmt = "$120";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.RefundAmt = "$120.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CMAIL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CONSL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CONSV";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "CNTRB";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "FUNDR";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DatePaid = "01/07/2016";
                objContributionsMonetaryModel.PayeeName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.PurposeCode = "LITR";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Balance = "$0.00";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateReceived,
                    x.DateRefundReceived,
                    x.DateRefunded,
                    x.ContributorName,
                    x.ContributionType,
                    x.PartnershipName,
                    x.DatePaid,
                    x.PayeeName,
                    x.TransferorName,
                    x.Explanation,
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
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.OriginalLoanDate,
                    x.OriginalLoan,
                    x.OriginalCntrbDate,
                    x.OriginalCntrbAmt,
                    x.Method,
                    x.Check,
                    x.Amount,
                    x.AmtRepaid,
                    x.RefundAmt,
                    x.Balance
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_Summary_Opt2Controller", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        public JsonResult GetTotalNotEffBalanceData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.LenderName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.Balance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateForgiven = "01/07/2016";
                objContributionsMonetaryModel.LenderName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
                objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$200.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.PurposeCode = "CMAIL";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.PartnershipName = "Partners";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "M";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.Balance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.PartnershipName = "SubContractors";
                objContributionsMonetaryModel.FirstName = "John";
                objContributionsMonetaryModel.MI = "";
                objContributionsMonetaryModel.LastName = "Smith";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.Amount = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.OriginalAmtAllocated = "$100.00";
                objContributionsMonetaryModel.AmtAllocatedThisReport = "$50.00";
                objContributionsMonetaryModel.AmtAllocatedAllReport = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.Balance = "$0.00";
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
                objContributionsMonetaryModel.Balance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);


                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateForgiven,
                    x.DateAllocated,
                    x.ElectionYearAllocated,
                    x.Explanation,
                    x.LenderName,
                    x.CreditorName,
                    x.PartnershipName,
                    x.FirstName,
                    x.MI,
                    x.LastName,
                    x.Office,
                    x.District,
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
                    x.OriginalAllocationDate,
                    x.OriginalAmtAllocated,
                    x.AmtAllocatedThisReport,
                    x.AmtAllocatedAllReport,
                    x.AmtForgiven,
                    x.AmountAttributed,
                    x.Amount,
                    x.Balance
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_Summary_Opt2Controller", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
    }
}