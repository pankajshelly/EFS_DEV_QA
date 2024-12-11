using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class SupportingDocumentsController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /SupportingDocuments/
        public ActionResult SupportingDocuments()
        {
            try
            {
                if (Session["SAMLResponse"] == null)
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                else
                {
                    // Bind Filer ID
                    var txtFilerID = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="A00191",Name="A00191"},
                                              new{ID="A00193",Name="A00193"},
                                              new{ID="A00880",Name="A00880"},
                                              new{ID="A00975",Name="A00975"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["txtFilerID"] = txtFilerID;

                    // Bind Committee Name
                    var txtCommitteeName = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="1",Name="NEW YORK REPUBLICAN STATE COMMITTEE - REPORTING"},
                                              new{ID="2",Name="NYS SENATE REPUBLICAN CAMPAIGN COMMITTEE"},
                                              new{ID="3",Name="LAWPAC OF NEW YORK"},
                                              new{ID="4",Name="EMPIRE STATE ASSOC OF ADULT HOMES, INC. PAC"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["txtCommitteeName"] = txtCommitteeName;

                    // Bind Status
                    var lstElectionCycle = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="2016",Name="2016"},
                                              new{ID="2015",Name="2015"},
                                              new{ID="2014",Name="2014"},
                                              new{ID="2013",Name="2013"},
                                              new{ID="2012",Name="2012"},
                                              new{ID="2011",Name="2011"},
                                              new{ID="2010",Name="2010"},
                                              new{ID="2009",Name="2009"},
                                              new{ID="2008",Name="2008"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstElectionCycle"] = lstElectionCycle;

                    // Bind Status
                    var lstElectionType = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="Primary",Name="Primary"},
                                              new{ID="General",Name="General"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstElectionType"] = lstElectionType;

                    // Bind Election Date
                    var lstElectionDate = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="11/30/2015",Name="11/30/2015"},
                                              new{ID="11/30/2016",Name="11/30/2016"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstElectionDate"] = lstElectionDate;

                    // Bind Disclosure Type
                    var lstDisclosureType = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="ItemizedReport",Name="Itemized Report"},
                                              new{ID="InLieuOfStatement",Name="In-Lieu-Of Statement"},
                                              new{ID="NoActivityReport",Name="No-Activity Report"},
                                              new{ID="24HourNotice",Name="24-Hour Notice"},
                                              new{ID="NoticeofNonParticipation",Name="Notice of Non-Participation"},
                                              new{ID="IndependentExpenditure",Name="Independent Expenditure"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstDisclosureType"] = lstDisclosureType;

                    // Bind Disclosure Period
                    var lstDisclosurePeriod = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="JanuaryPeriodic",Name="January Periodic"},
                                              new{ID="32DayPrePrimary",Name="32 Day Pre-Primary"},
                                              new{ID="10DayPostPrimary",Name="10-Day Post-Primary"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstDisclosurePeriod"] = lstDisclosurePeriod;

                    // Bind Transaction Type
                    var lstTransactionType = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="ContributionMonetary",Name="Contribution - Monetary"},
                                              new{ID="ContributionInKind",Name="Contribution – In Kind"},
                                              new{ID="TransferIn",Name="Transfer In"},
                                              new{ID="LoanReceived",Name="Loan Received"},
                                              new{ID="ExpenditureRefund",Name="Expenditure Refund"},
                                              new{ID="NonCampaignHouseKeeping",Name="Non-Campaign HouseKeeping Receipts"},
                                              new{ID="OtherReceipts",Name="Other Receipts"},
                                              new{ID="Expenditure",Name="Expenditure"},
                                              new{ID="TransferOut",Name="Transfer Out"},
                                              new{ID="LoanRepayments",Name="Loan Repayments"},
                                              new{ID="LiabilitiesLoansForgiven",Name="Liabilities/Loans Forgiven"},
                                              new{ID="ContributionsRefunded",Name="Contributions Refunded"},
                                              new{ID="OutstandingLiabilities",Name="Outstanding Liabilities/Loans"},
                                              new{ID="AmountAllocated",Name="Amount Allocated"},
                                              new{ID="NonCampaignHouseKeepingExpenses",Name="Non-Campaign HouseKeeping Expenses"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstTransactionType"] = lstTransactionType;

                    // Bind Filer Name
                    var lstContributionName = new SelectList(new[]
                                                  {
                                              new {ID="Candidate",Name="Candidate"},
                                              new{ID="Individual",Name="Individual"},
                                              new{ID="Family",Name="Family"},
                                              new{ID="Partnership",Name="Partnership"},
                                              new{ID="Unitemized",Name="Unitemized"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstContributionName"] = lstContributionName;

                    // Bind Method
                    var lstMethod = new SelectList(new[]
                                                  {
                                              new {ID="Cash",Name="Cash"},
                                              new{ID="Check",Name="Check"},
                                              new{ID="Credit Card",Name="Credit Card"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstMethod"] = lstMethod;

                    // Bind Method
                    var lstPartner = new SelectList(new[]
                                                  {
                                              new {ID="Partners",Name="Partners"},
                                              new{ID="SubContractors",Name="SubContractors"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstPartner"] = lstPartner;

                    // Bind Method
                    var lstContributionType = new SelectList(new[]
                                                  {
                                              new {ID="ServicesFacilitiesProvided",Name="Services/Facilities Provided"},
                                              new{ID="PropertyGiven",Name="Property Given"},
                                              new{ID="CampaignExpensesPaid",Name="Campaign Expenses Paid"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstContributionType"] = lstContributionType;

                    // Bind Method
                    var lstTransferType = new SelectList(new[]
                                                  {
                                              new {ID="Type1",Name="Type 1"},
                                              new{ID="Type2",Name="Type 2"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstTransferType"] = lstTransferType;

                    // Bind Method
                    var lstReceiptCode = new SelectList(new[]
                                                  {
                                              new {ID="IND",Name="IND"},
                                              new{ID="CORP",Name="CORP"},
                                              new{ID="PART",Name="PART"},
                                              new{ID="COMM",Name="COMM"},
                                              new{ID="OTH",Name="OTH"},
                                              new{ID="UNIT",Name="UNIT"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstReceiptCode"] = lstReceiptCode;

                    // Bind Method
                    var lstReceiptType = new SelectList(new[]
                                                  {
                                              new {ID="InterestDividends",Name="Interest/Dividends"},
                                              new{ID="ProceedsSalesLease",Name="Proceeds Sales/Lease"},
                                              new{ID="Other",Name="Other"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstReceiptType"] = lstReceiptType;

                    // Bind Method
                    var lstPurposeCode = new SelectList(new[]
                                                  {
                                              new {ID="CMAIL",Name="CMAIL"},
                                              new{ID="CONSL",Name="CONSL"},
                                              new{ID="CONSV",Name="CONSV"},
                                              new{ID="CNTRB",Name="CNTRB"},
                                              new{ID="FUNDR",Name="FUNDR"},
                                              new{ID="LITR",Name="LITR"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstPurposeCode"] = lstPurposeCode;

                    var lstDocumentType = new SelectList(new[]
                                                  {
                                              new {ID="0",Name="- Select -"},
                                              new {ID="1",Name="Campaign Material"},
                                              new{ID="2",Name="Letter of Forgiveness"},
                                          },
                                   "Id", "Name", 0);
                    ViewData["lstDocumentType"] = lstDocumentType;
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "SupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        public JsonResult GetSupportingDocumentsData()
        {
            try
            {
                IList<SuppDocumentsModel> lstSuppDocumentsModel = new List<SuppDocumentsModel>();
                SuppDocumentsModel objSuppDocumentsModel;

                // Row1
                objSuppDocumentsModel = new SuppDocumentsModel();
                objSuppDocumentsModel.Received = "07/05/2016";
                objSuppDocumentsModel.DocumentType = "Campaign Meterial";
                objSuppDocumentsModel.Status = "Uploaded";
                objSuppDocumentsModel.StatusDate = "07/08/2016";
                objSuppDocumentsModel.Pages = "8";
                objSuppDocumentsModel.DeliveryType = "Normal";
                objSuppDocumentsModel.DateFiled = "07/11/2016";
                lstSuppDocumentsModel.Add(objSuppDocumentsModel);

                // Row2
                objSuppDocumentsModel = new SuppDocumentsModel();
                objSuppDocumentsModel.Received = "06/06/2016";
                objSuppDocumentsModel.DocumentType = "Letter of Forgiveness";
                objSuppDocumentsModel.Status = "Uploaded";
                objSuppDocumentsModel.StatusDate = "06/08/2016";
                objSuppDocumentsModel.Pages = "6";
                objSuppDocumentsModel.DeliveryType = "Priority";
                objSuppDocumentsModel.DateFiled = "07/13/2016";
                lstSuppDocumentsModel.Add(objSuppDocumentsModel);

                return Json(new
                {
                    aaData = lstSuppDocumentsModel.Select(x => new[] {
                    x.Received,
                    x.DocumentType,
                    x.Status,
                    x.StatusDate,
                    x.Pages,
                    x.DeliveryType,
                    x.DateFiled
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "SupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }

        public JsonResult OpenPDFDocFileFromPath()
        {
            try
            {
                String filePath = "C:\\SupportDocuments\\EnforcementReferralListReport.pdf";
                Process.Start(filePath);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "SupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
	}
}