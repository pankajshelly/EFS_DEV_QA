using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class divUC_IndependentExpenditureController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /divUC_IndependentExpenditure/
        public ActionResult divUC_IndependentExpenditure()
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
                    ViewData["lstContributionName"] = lstLoanerCode;
                }
                
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "divUC_IndependentExpenditureController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }
	}
}