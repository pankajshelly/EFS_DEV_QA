using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Text.RegularExpressions;
using System.Text;
using System.IO.Compression;
using System.IO;


namespace CAPASFIDAS_EFS.Controllers
{
    public class LogoutPageController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string DestinationUrl = ConfigurationManager.AppSettings["DestinationUrl"].ToString();
        public static string NameIDFormat = ConfigurationManager.AppSettings["NameIDFormat"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSignOutURL = ConfigurationManager.AppSettings["IdentityProviderLogoutURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        // GET: LogoutPage
        public ActionResult LogoutPage()
        {
            try
            {
                SAMLResponse samlResponse = new SAMLResponse();
                SAMLRequest request = new SAMLRequest();
                if (Session["UserNameDisplay"] != null)
                {
                    Response.Redirect(IdentityProviderSignOutURL + GetSAMLLogoutRequest(DestinationUrl, Issuer, NameIDFormat, Session["UserNameDisplay"].ToString()));
                }
                else
                {
                    Response.Redirect("~/RoleMap/RoleMap");
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LogoutPageController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }

            return View();
        }

        public static string GetSAMLLogoutRequest(string destinationUrl, string issuer, string nameIDFormat, string nameID)
        {
            string SAML20_LogoutRequest_FORMAT = "<samlp:LogoutRequest " + "xmlns:samlp=\"urn:oasis:names:tc:SAML:2.0:protocol\" " + "xmlns:saml=\"urn:oasis:names:tc:SAML:2.0:assertion\" " + "ID =\"_{0}\" " + "Version =\"2.0\" " + "IssueInstant =\"{1:yyyy-MM-ddTHH:mm:ss.000Z}\" " + "Destination =\"{2}\" " + "NotOnOrAfter=\"{3:yyyy-MM-ddTHH:mm:ss.000Z}\" " + "Reason=\"urn:oasis:names:tc:SAML:2.0:logout:user\" " + "Consent=\"urn:oasis:names:tc:SAML:2.0:consent:obtained\">" + "<saml:Issuer>" + "{4}" + "</saml:Issuer>" + "<saml:NameID " + "Format=\"{5}\">" + "{6}" + "</saml:NameID>" + "</samlp:LogoutRequest>";
            try
            {
                var logoutRequest = string.Format(SAML20_LogoutRequest_FORMAT,
                Guid.NewGuid().ToString(),
                DateTime.UtcNow,
                destinationUrl,
                DateTime.UtcNow + TimeSpan.FromHours(1), issuer, nameIDFormat, 
                nameID 
            );
            using (var ms1 = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms1, CompressionMode.Compress))
                {
                    var b = UTF8Encoding.UTF8.GetBytes(logoutRequest);
                    ds.Write(b, 0, b.Length);
                }

                logoutRequest = "?SAMLRequest=" + HttpUtility.UrlEncode(Convert.ToBase64String(ms1.ToArray()));
            }
            Console.WriteLine("Log Out Url for the is {0} ", logoutRequest); return logoutRequest;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Exception while getting LogOutUrl", ex);
                return null;
            }
        }
    }
}