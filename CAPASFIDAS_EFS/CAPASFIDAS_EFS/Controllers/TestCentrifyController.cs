using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class TestCentrifyController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        // GET: TestCentrify
        public ActionResult TestCentrify()
        {
            try
            {
                SAMLResponse samlResponse = new SAMLResponse();
                if (Request.Form["SAMLResponse"] != null)
                {
                    XmlDocument xDoc = samlResponse.ParseSAMLResponse(Request.Form["SAMLResponse"]);

                    if (samlResponse.IsResponseValid(xDoc))
                    {
                        Response.Write("SAML Response from IDP Was Accepted. Authenticated user is " + samlResponse.ParseSAMLNameID(xDoc));
                    }
                    else
                    {
                        Response.Write("SAML Response from IDP Was Not Accepted");
                    }
                }
                else
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TestCentrifyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}