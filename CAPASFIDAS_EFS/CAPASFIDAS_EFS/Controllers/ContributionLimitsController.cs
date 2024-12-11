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
    public class ContributionLimitsController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /ContributionLimits/
        public ActionResult ContributionLimits()
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

                    // Bind Status
                    var lstParty = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                              new {ID="All",Name="All"},
                                              new{ID="Conservative",Name="Conservative"},
                                              new{ID="Democrat",Name="Democrat"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstParty"] = lstParty;
                }
                

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionLimitsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }

        public JsonResult GetContributionSearchData()
        {
            try
            {
                IList<ContributionLimitsModel> lstContributionLimitsModel = new List<ContributionLimitsModel>();
                ContributionLimitsModel objContributionLimitsModel;

                //Bind 1st row
                objContributionLimitsModel = new ContributionLimitsModel();
                objContributionLimitsModel.ElectionCycle = "2016";
                objContributionLimitsModel.OfficeType = "State";
                objContributionLimitsModel.ElectionType = "Primary";
                objContributionLimitsModel.Party = "Conservative";
                objContributionLimitsModel.NonFamilyLimit = "";
                objContributionLimitsModel.FamilyLimit = "";
                lstContributionLimitsModel.Add(objContributionLimitsModel);

                //Bind 2st row
                objContributionLimitsModel = new ContributionLimitsModel();
                objContributionLimitsModel.ElectionCycle = "2016";
                objContributionLimitsModel.OfficeType = "State";
                objContributionLimitsModel.ElectionType = "General";
                objContributionLimitsModel.Party = "Democrate";
                objContributionLimitsModel.NonFamilyLimit = "";
                objContributionLimitsModel.FamilyLimit = "";
                lstContributionLimitsModel.Add(objContributionLimitsModel);

                return Json(new
                {
                    aaData = lstContributionLimitsModel.Select(x => new[] {
                    x.ElectionCycle,
                    x.OfficeType,
                    x.ElectionType,
                    x.Party,
                    x.NonFamilyLimit,
                    x.FamilyLimit
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionLimitsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}