using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_DR_Summary_Opt3Controller : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_DR_Summary_Opt3/
        public ActionResult _UC_DR_Summary_Opt3()
        {
            return View();
        }

        public JsonResult GetOpeningBalanceData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
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
                objContributionsMonetaryModel.Balance = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$0.00";
                objContributionsMonetaryModel.PosBalance = "$100.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                // Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Contribution – In Kind";
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
                objContributionsMonetaryModel.Balance = "$200.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$0.00";
                objContributionsMonetaryModel.PosBalance = "$100.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Transfer In";
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
                objContributionsMonetaryModel.Amount = "$0.00";
                objContributionsMonetaryModel.Balance = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$300.00";
                objContributionsMonetaryModel.PosBalance = "$100.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Loan Received";
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
                objContributionsMonetaryModel.Balance = "$400.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$0.00";
                objContributionsMonetaryModel.PosBalance = "$100.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Expenditure Refund";
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
                objContributionsMonetaryModel.Balance = "$300.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$100.00";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
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
                objContributionsMonetaryModel.Balance = "$400.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$0.00";
                objContributionsMonetaryModel.PosBalance = "$100.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Other Receipts";
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
                objContributionsMonetaryModel.Balance = "$500.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$0.00";
                objContributionsMonetaryModel.PosBalance = "$100.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Expenditure";
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
                objContributionsMonetaryModel.Balance = "$400.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$100.00";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Transfer Out";
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
                objContributionsMonetaryModel.Balance = "$300.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$100.00";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Loan Repayments";
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
                objContributionsMonetaryModel.OriginalLoan = "$0.00";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.AmtRepaid = "$100.00";
                objContributionsMonetaryModel.Balance = "$200.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$100.00";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Liabilities/Loans Forgiven";
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
                objContributionsMonetaryModel.Balance = "";
                objContributionsMonetaryModel.NegBalance = "";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Contributions Refunded";
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
                objContributionsMonetaryModel.Balance = "$100.00";
                objContributionsMonetaryModel.Explanation = "Test";
                objContributionsMonetaryModel.NegBalance = "$100.00";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
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
                objContributionsMonetaryModel.NegBalance = "";
                objContributionsMonetaryModel.PosBalance = "";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Amount Allocated";
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
                objContributionsMonetaryModel.NegBalance = "";
                objContributionsMonetaryModel.PosBalance = "";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
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
                objContributionsMonetaryModel.NegBalance = "";
                objContributionsMonetaryModel.PosBalance = "";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.TransactionType = "Expenditure – In Kind";
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
                objContributionsMonetaryModel.NegBalance = "$100.00";
                objContributionsMonetaryModel.PosBalance = "$0.00";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.TransactionType,
                    x.DateReceived,
                    x.Explanation,
                    x.PartnershipName,
                    x.ReceiptSource,
                    x.TransferorName,
                    x.LoanDate,
                    x.LoanerCode,
                    x.LenderGuarantorSingerName,
                    x.DateRefundReceived,
                    x.PayorName,
                    x.ReceiptCode,
                    x.ContributorName,
                    x.DatePaid,
                    x.PayeeName,
                    x.TransfereeName,
                    x.DateRefundReceived,
                    x.DateRefunded,
                    x.DateForgiven,
                    x.LenderName,
                    x.CreditorName,
                    x.PartnershipName,
                    x.DateAllocated,
                    x.ElectionYearAllocated,
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
                    x.ReceiptType,
                    x.TransferType,
                    x.OriginalExpenseDate,
                    x.OriginalAmt,
                    x.ContributionType,
                    x.PurposeCode,
                    x.OriginalLoanDate,
                    x.OriginalLoan,
                    x.OriginalCntrbDate,
                    x.OriginalCntrbAmt,
                    x.OriginalLiabilityDate,
                    x.OriginalLiabilityAmt,
                    x.Method,
                    x.Check,
                    x.AmtRepaid,
                    x.RefundAmt,
                    x.AmtForgiven,
                    x.AmountAttributed,
                    x.OriginalAllocationDate,
                    x.OriginalAmtAllocated,
                    x.AmtAllocatedThisReport,
                    x.AmtAllocatedAllReport,
                    x.Amount,
                    x.NegBalance,
                    x.PosBalance,
                    x.Balance
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_Summary_Opt3Controller", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            

            #region Comments Code
            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
            //objContributionsMonetaryModel.DateReceived = "12/02/2015";
            //objContributionsMonetaryModel.ContributorName = "Individual";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "Jone";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Family";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "Carol";
            //objContributionsMonetaryModel.MI = "A";
            //objContributionsMonetaryModel.LastName = "Franklin";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Partnership";
            //objContributionsMonetaryModel.PartnershipName = "Test Partnership Name";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Unitemized";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "";
            //objContributionsMonetaryModel.StreetName = "";
            //objContributionsMonetaryModel.City = "";
            //objContributionsMonetaryModel.State = "";
            //objContributionsMonetaryModel.Zip5 = "";
            //objContributionsMonetaryModel.Zip4 = "";
            //objContributionsMonetaryModel.Method = "";
            //objContributionsMonetaryModel.Check = "";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            //// Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution – In Kind";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ContributorName = "Candidate";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "M";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Services/Facilities Provided";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution – In Kind";
            //objContributionsMonetaryModel.DateReceived = "12/02/2015";
            //objContributionsMonetaryModel.ContributorName = "Individual";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "Jone";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Property Given";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution – In Kind";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Family";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "Carol";
            //objContributionsMonetaryModel.MI = "A";
            //objContributionsMonetaryModel.LastName = "Franklin";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution – In Kind";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Partnership";
            //objContributionsMonetaryModel.PartnershipName = "Test Partnership Name";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution – In Kind";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Unitemized";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "";
            //objContributionsMonetaryModel.StreetName = "";
            //objContributionsMonetaryModel.City = "";
            //objContributionsMonetaryModel.State = "";
            //objContributionsMonetaryModel.Zip5 = "";
            //objContributionsMonetaryModel.Zip4 = "";
            //objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
            //objContributionsMonetaryModel.Method = "";
            //objContributionsMonetaryModel.Check = "";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ///////////////////////
            ///////////////////////
            //////////////////////
            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Other Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptSource = "Test Soruce";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ReceiptType = "Interest/Dividends";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Other Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptSource = "Test Soruce";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ReceiptType = "Proceeds Sales/Lease";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Other Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptSource = "Test Soruce";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ReceiptType = "Other";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Transfer In";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.TransferorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.TransferType = "Type 1";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Transfer In";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.TransferorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.TransferType = "Type 2";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Received";
            //objContributionsMonetaryModel.LoanDate = "01/07/2016";
            //objContributionsMonetaryModel.LoanerCode = "Candidate";
            //objContributionsMonetaryModel.LenderGuarantorSingerName = "";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "M";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Received";
            //objContributionsMonetaryModel.LoanDate = "12/02/2015";
            //objContributionsMonetaryModel.LoanerCode = "Individual";
            //objContributionsMonetaryModel.LenderGuarantorSingerName = "";
            //objContributionsMonetaryModel.FirstName = "Jone";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Received";
            //objContributionsMonetaryModel.LoanDate = "2015";
            //objContributionsMonetaryModel.LoanerCode = "Family";
            //objContributionsMonetaryModel.LenderGuarantorSingerName = "";
            //objContributionsMonetaryModel.FirstName = "Carol";
            //objContributionsMonetaryModel.MI = "A";
            //objContributionsMonetaryModel.LastName = "Franklin";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Received";
            //objContributionsMonetaryModel.LoanDate = "2015";
            //objContributionsMonetaryModel.LoanerCode = "Partnership";
            //objContributionsMonetaryModel.LenderGuarantorSingerName = "Test Partnership Name";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Received";
            //objContributionsMonetaryModel.LoanDate = "2015";
            //objContributionsMonetaryModel.LoanerCode = "Unitemized";
            //objContributionsMonetaryModel.LenderGuarantorSingerName = "";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "";
            //objContributionsMonetaryModel.StreetName = "";
            //objContributionsMonetaryModel.City = "";
            //objContributionsMonetaryModel.State = "";
            //objContributionsMonetaryModel.Zip5 = "";
            //objContributionsMonetaryModel.Zip4 = "";
            //objContributionsMonetaryModel.Method = "";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$100.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure Refund";
            //objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
            //objContributionsMonetaryModel.PayorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalExpenseDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalAmt = "$100";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.RefundAmt = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure Refund";
            //objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
            //objContributionsMonetaryModel.PayorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalExpenseDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalAmt = "$120";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.RefundAmt = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$120.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptCode = "IND";
            //objContributionsMonetaryModel.ContributorName = "";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "M";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
            //objContributionsMonetaryModel.DateReceived = "12/02/2015";
            //objContributionsMonetaryModel.ReceiptCode = "CORP";
            //objContributionsMonetaryModel.ContributorName = "Corp Test";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptCode = "PART";
            //objContributionsMonetaryModel.ContributorName = "Part Test";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptCode = "COMM";
            //objContributionsMonetaryModel.ContributorName = "Comm Test";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptCode = "OTH";
            //objContributionsMonetaryModel.ContributorName = "Oth Test";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Receipts";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ReceiptCode = "UNIT";
            //objContributionsMonetaryModel.ContributorName = "";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "";
            //objContributionsMonetaryModel.StreetName = "";
            //objContributionsMonetaryModel.City = "";
            //objContributionsMonetaryModel.State = "";
            //objContributionsMonetaryModel.Zip5 = "";
            //objContributionsMonetaryModel.Zip4 = "";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ///////////////////////////////////////////////
            ////////////////////////////////////////
            ///////////////////////////////////////////////
            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test Payeename";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CMAIL";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test Payeename";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CONSL";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test Payeename";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CONSV";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test Payeename";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CNTRB";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test Payeename";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "FUNDR";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test Payeename";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "LITR";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row //////////////////////////////////////////////////////////////////////// Check here below 5 records.
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure – In Kind";
            //objContributionsMonetaryModel.DateReceived = "01/07/2016";
            //objContributionsMonetaryModel.ContributorName = "Candidate";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "M";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Services/Facilities Provided";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure – In Kind";
            //objContributionsMonetaryModel.DateReceived = "12/02/2015";
            //objContributionsMonetaryModel.ContributorName = "Individual";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "Jone";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Property Given";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure – In Kind";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Family";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "Carol";
            //objContributionsMonetaryModel.MI = "A";
            //objContributionsMonetaryModel.LastName = "Franklin";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure – In Kind";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Partnership";
            //objContributionsMonetaryModel.PartnershipName = "Test Partnership Name";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Expenditure – In Kind";
            //objContributionsMonetaryModel.DateReceived = "2015";
            //objContributionsMonetaryModel.ContributorName = "Unitemized";
            //objContributionsMonetaryModel.PartnershipName = "";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "";
            //objContributionsMonetaryModel.StreetName = "";
            //objContributionsMonetaryModel.City = "";
            //objContributionsMonetaryModel.State = "";
            //objContributionsMonetaryModel.Zip5 = "";
            //objContributionsMonetaryModel.Zip4 = "";
            //objContributionsMonetaryModel.ContributionType = "Campaign Expenses Paid";
            //objContributionsMonetaryModel.Method = "";
            //objContributionsMonetaryModel.Check = "";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);



            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Transfer Out";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.TransfereeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.TransferType = "Type 1";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Transfer Out";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.TransfereeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.TransferType = "Type 2";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Repayments";
            //objContributionsMonetaryModel.DateRefundReceived = "01/07/2016";
            //objContributionsMonetaryModel.LoanerCode = "Candidate";
            //objContributionsMonetaryModel.LenderName = "";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "M";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLoan = "$0.00";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.AmtRepaid = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Repayments";
            //objContributionsMonetaryModel.DateRefundReceived = "12/02/2015";
            //objContributionsMonetaryModel.LoanerCode = "Individual";
            //objContributionsMonetaryModel.LenderName = "";
            //objContributionsMonetaryModel.FirstName = "Jone";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLoan = "$100.00";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.AmtRepaid = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 3st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Repayments";
            //objContributionsMonetaryModel.DateRefundReceived = "2015";
            //objContributionsMonetaryModel.LoanerCode = "Family";
            //objContributionsMonetaryModel.LenderName = "";
            //objContributionsMonetaryModel.FirstName = "Carol";
            //objContributionsMonetaryModel.MI = "A";
            //objContributionsMonetaryModel.LastName = "Franklin";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLoan = "$0.00";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.AmtRepaid = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Repayments";
            //objContributionsMonetaryModel.DateRefundReceived = "2015";
            //objContributionsMonetaryModel.LoanerCode = "Partnership";
            //objContributionsMonetaryModel.LenderName = "Test Partnership Name";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "Main Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLoan = "$100.00";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.AmtRepaid = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 4st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Loan Repayments";
            //objContributionsMonetaryModel.DateRefundReceived = "2015";
            //objContributionsMonetaryModel.LoanerCode = "Unitemized";
            //objContributionsMonetaryModel.LenderName = "";
            //objContributionsMonetaryModel.FirstName = "";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "";
            //objContributionsMonetaryModel.Street = "";
            //objContributionsMonetaryModel.StreetName = "";
            //objContributionsMonetaryModel.City = "";
            //objContributionsMonetaryModel.State = "";
            //objContributionsMonetaryModel.Zip5 = "";
            //objContributionsMonetaryModel.Zip4 = "";
            //objContributionsMonetaryModel.OriginalLoanDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLoan = "$100.00";
            //objContributionsMonetaryModel.Method = "";
            //objContributionsMonetaryModel.AmtRepaid = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contributions Refunded";
            //objContributionsMonetaryModel.DateRefunded = "01/07/2016";
            //objContributionsMonetaryModel.ContributorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalCntrbDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalCntrbAmt = "$100";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.RefundAmt = "$0.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$100.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 2st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contributions Refunded";
            //objContributionsMonetaryModel.DateRefunded = "01/07/2016";
            //objContributionsMonetaryModel.ContributorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalCntrbDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalCntrbAmt = "$120";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.RefundAmt = "$120.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$120.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CMAIL";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CONSL";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CONSV";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "CNTRB";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "FUNDR";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Non-Campaign HouseKeeping Expenses";
            //objContributionsMonetaryModel.DatePaid = "01/07/2016";
            //objContributionsMonetaryModel.PayeeName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.PurposeCode = "LITR";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Check = "123456";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////////////////////////////////////////
            ////////////////////////////////////////
            ////////////////////////////////////////
            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Liabilities/Loans Forgiven";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.LenderName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Liabilities/Loans Forgiven";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.LenderName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$200.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);


            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.CreditorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.PurposeCode = "CMAIL";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.CreditorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.PurposeCode = "CONSL";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.CreditorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.PurposeCode = "CONSV";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.CreditorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.PurposeCode = "CNTRB";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.CreditorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.PurposeCode = "FUNDR";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Outstanding Liabilities/Loans";
            //objContributionsMonetaryModel.DateForgiven = "01/07/2016";
            //objContributionsMonetaryModel.CreditorName = "Test";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.OriginalLiabilityDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalLiabilityAmt = "$100.00";
            //objContributionsMonetaryModel.PurposeCode = "LITR";
            //objContributionsMonetaryModel.Method = "Check";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
            //objContributionsMonetaryModel.PartnershipName = "Partners";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "M";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Contribution - Monetary";
            //objContributionsMonetaryModel.PartnershipName = "SubContractors";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.Street = "Street";
            //objContributionsMonetaryModel.StreetName = "North Pearl Street";
            //objContributionsMonetaryModel.City = "Albany";
            //objContributionsMonetaryModel.State = "NY";
            //objContributionsMonetaryModel.Zip5 = "12206";
            //objContributionsMonetaryModel.Zip4 = "1234";
            //objContributionsMonetaryModel.Amount = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Amount Allocated";
            //objContributionsMonetaryModel.DateAllocated = "01/07/2016";
            //objContributionsMonetaryModel.ElectionYearAllocated = "2016";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.District = "Albany";
            //objContributionsMonetaryModel.Office = "Albany";
            //objContributionsMonetaryModel.OriginalAllocationDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalAmtAllocated = "$100.00";
            //objContributionsMonetaryModel.AmtAllocatedThisReport = "$50.00";
            //objContributionsMonetaryModel.AmtAllocatedAllReport = "$100.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

            ////Bind 1st row
            //objContributionsMonetaryModel = new ContributionsMonetaryModel();
            //objContributionsMonetaryModel.TransactionType = "Amount Allocated";
            //objContributionsMonetaryModel.DateAllocated = "01/07/2016";
            //objContributionsMonetaryModel.ElectionYearAllocated = "2016";
            //objContributionsMonetaryModel.FirstName = "John";
            //objContributionsMonetaryModel.MI = "";
            //objContributionsMonetaryModel.LastName = "Smith";
            //objContributionsMonetaryModel.District = "Albany";
            //objContributionsMonetaryModel.Office = "Albany";
            //objContributionsMonetaryModel.OriginalAllocationDate = "01/01/2016";
            //objContributionsMonetaryModel.OriginalAmtAllocated = "$200.00";
            //objContributionsMonetaryModel.AmtAllocatedThisReport = "$75.00";
            //objContributionsMonetaryModel.AmtAllocatedAllReport = "$200.00";
            //objContributionsMonetaryModel.Explanation = "Test";
            //objContributionsMonetaryModel.Balance = "$0.00";
            //objContributionsMonetaryModel.NegBalance = "$0.00";
            //objContributionsMonetaryModel.PosBalance = "$0.00";
            //lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);   

            #endregion Comments Code
        }

        public JsonResult GetAllTransactionTypesData()
        {
            try
            {
                IList<TransactionTypesSummeryDataModel> lstTransactionTypesSummeryDataModel = new List<TransactionTypesSummeryDataModel>();
                TransactionTypesSummeryDataModel objTransactionTypesSummeryDataModel;

                //Bind 1st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Contribution - Monetary";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Candidate";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "John";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "M";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "Smith";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$100.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$0.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$100.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 2st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Contribution – In Kind";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Candidate";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "John";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "M";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "Smith";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.ContributionTypeDesc = "Services/Facilities Provided";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$200.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$0.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$100.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 3st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Transfer In";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$100.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$300.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$100.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 4st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Loan Received";
                objTransactionTypesSummeryDataModel.OrginalDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.RBankCode = "Candidate";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "John";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "M";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "Smith";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$400.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$0.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$100.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 5st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Expenditure Refund";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$300.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$100.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 6st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Non-Campaign HouseKeeping Receipts";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.ReceiptTypeDesc = "IND";
                objTransactionTypesSummeryDataModel.FilingEntityName = "";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "John";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "M";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "Smith";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$400.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$0.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$100.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 7st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Other Receipts";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test Soruce";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.ReceiptTypeDesc = "Interest/Dividends";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$500.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$0.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$100.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 8st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Expenditure";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test Payeename";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$400.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$100.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 9st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Transfer Out";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$300.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$100.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 10st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Loan Repayments";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.RBankCode = "Candidate";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "John";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "M";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "Smith";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$200.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$100.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 11st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Liabilities/Loans Forgiven";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "";
                objTransactionTypesSummeryDataModel.NegBalance = "";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 12st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Contributions Refunded";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.OrginalDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$100.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$100.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 13st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Outstanding Liabilities/Loans";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.OrginalDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$0.00";
                objTransactionTypesSummeryDataModel.NegBalance = "";
                objTransactionTypesSummeryDataModel.PosBalance = "";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 13st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Amount Allocated";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.ElectionYear = "2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityFirstName = "John";
                objTransactionTypesSummeryDataModel.FilingEntityMiddleName = "";
                objTransactionTypesSummeryDataModel.FilingEntityLastName = "Smith";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.OrginalDate = "01/01/2016";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$0.00";
                objTransactionTypesSummeryDataModel.NegBalance = "";
                objTransactionTypesSummeryDataModel.PosBalance = "";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 14st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Non-Campaign HouseKeeping Expenses";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Test";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.TransferTypeDesc = "Type 1";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$0.00";
                objTransactionTypesSummeryDataModel.NegBalance = "";
                objTransactionTypesSummeryDataModel.PosBalance = "";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                //Bind 15st row
                objTransactionTypesSummeryDataModel = new TransactionTypesSummeryDataModel();
                objTransactionTypesSummeryDataModel.FilingScheduleDesc = "Expenditure – In Kind";
                objTransactionTypesSummeryDataModel.ScheduleDate = "01/07/2016";
                objTransactionTypesSummeryDataModel.FilingEntityName = "Candidate";
                objTransactionTypesSummeryDataModel.FilingEntityStreetNo = "Street";
                objTransactionTypesSummeryDataModel.FilingEntityStreetName = "North Pearl Street";
                objTransactionTypesSummeryDataModel.FilingEntityCity = "Albany";
                objTransactionTypesSummeryDataModel.FilingEntityState = "NY";
                objTransactionTypesSummeryDataModel.FilingEntityZip5 = "12206";
                objTransactionTypesSummeryDataModel.FilingEntityZip4 = "1234";
                objTransactionTypesSummeryDataModel.ContributionTypeDesc = "Services/Facilities Provided";
                objTransactionTypesSummeryDataModel.PaymentTypeDesc = "Check";
                objTransactionTypesSummeryDataModel.PayNumber = "123456";
                objTransactionTypesSummeryDataModel.OriginalAmount = "$100.00";
                objTransactionTypesSummeryDataModel.TransactionExplanation = "Test";
                objTransactionTypesSummeryDataModel.Balance = "$0.00";
                objTransactionTypesSummeryDataModel.NegBalance = "$100.00";
                objTransactionTypesSummeryDataModel.PosBalance = "$0.00";
                lstTransactionTypesSummeryDataModel.Add(objTransactionTypesSummeryDataModel);

                return Json(new
                {
                    aaData = lstTransactionTypesSummeryDataModel.Select(x => new[] {
                    x.ScheduleDate,
                    x.PosBalance,
                    x.NegBalance,
                    x.Balance,
                    x.FilingScheduleDesc,
                    x.FilingEntityName,
                    x.FilingEntityFirstName,
                    x.FilingEntityMiddleName,
                    x.FilingEntityLastName,
                    x.FilingEntityStreetNo,
                    x.FilingEntityStreetName,
                    x.FilingEntityCity,
                    x.FilingEntityState,
                    x.FilingEntityZip5,
                    x.FilingEntityZip4,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.OrginalDate,
                    x.RBankCode,
                    x.ElectionYear,
                    x.DistOffCandBalProp,
                    x.DistOffCandBalProp,
                    x.TransactionExplanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_DR_Summary_Opt3Controller", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}