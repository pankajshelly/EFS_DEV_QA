using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class AmendDisclosureReportController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /AmendDisclosureReport/
        public ActionResult AmendDisclosureReport()
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
                                              new {ID="2016",Name="2016"},
                                              new{ID="2015",Name="2015"},
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

                    //// Bind Transaction Type
                    //var lstTransactionType = new SelectList(new[]
                    //                              {
                    //                                  new {ID="-Select-",Name="-Select-"},
                    //                                  new {ID="ContributionMonetary",Name="Contribution - Monetary"},
                    //                                  new{ID="ContributionInKind",Name="Contribution – In Kind"},                                                                                                                                          
                    //                                  new{ID="TransferIn",Name="Transfer In"},                                                                                                                                          
                    //                                  new{ID="LoanReceived",Name="Loan Received"},                                                                                                                                          
                    //                                  new{ID="ExpenditureRefund",Name="Expenditure Refund"},                                                                                                                                          
                    //                              },
                    //                "ID", "Name", 1);
                    //ViewData["lstTransactionType"] = lstTransactionType;
                }


                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AmendDisclosureReportController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }

        public JsonResult GetAmendDisclosureReportSearchData()
        {
            try
            {
                IList<AmendDisclosureModel> lstAmendDisclosureModel = new List<AmendDisclosureModel>();
                AmendDisclosureModel objAmendDisclosureModel;

                //Bind 1st row
                objAmendDisclosureModel = new AmendDisclosureModel();
                objAmendDisclosureModel.Cycle = "2016";
                objAmendDisclosureModel.DisclosureType = "Itemized";
                objAmendDisclosureModel.ReportingCycle = "Periodic";
                objAmendDisclosureModel.ReportPeriod = "January Periodic";
                objAmendDisclosureModel.DateSubmitted = "";
                objAmendDisclosureModel.Status = "Pending";
                objAmendDisclosureModel.OpeningBalance = "$50";
                objAmendDisclosureModel.ClosingBalance = "$50";
                lstAmendDisclosureModel.Add(objAmendDisclosureModel);

                //Bind 2st row
                objAmendDisclosureModel = new AmendDisclosureModel();
                objAmendDisclosureModel.Cycle = "2015";
                objAmendDisclosureModel.DisclosureType = "Itemized";
                objAmendDisclosureModel.ReportingCycle = "General";
                objAmendDisclosureModel.ReportPeriod = "32 Day Pre-General";
                objAmendDisclosureModel.DateSubmitted = "01/01/2016";
                objAmendDisclosureModel.Status = "Submitted";
                objAmendDisclosureModel.OpeningBalance = "$100";
                objAmendDisclosureModel.ClosingBalance = "$50";
                lstAmendDisclosureModel.Add(objAmendDisclosureModel);

                return Json(new
                {
                    aaData = lstAmendDisclosureModel.Select(x => new[] {
                    x.Cycle,
                    x.DisclosureType,
                    x.ReportingCycle,
                    x.ReportPeriod,
                    x.Status,
                    x.DateSubmitted,
                    "",
                    x.OpeningBalance,
                    x.ClosingBalance
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AmendDisclosureReportController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}