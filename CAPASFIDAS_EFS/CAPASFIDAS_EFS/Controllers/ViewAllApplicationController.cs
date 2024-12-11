using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broker;
using Models;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class ViewAllApplicationController : Controller
    {
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        // GET: ViewAllApplication
        public ActionResult ViewAllApplication()
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
                    IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
                    IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
                    lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse("107772");
                    listFilerInfo = objItemizedReportsBroker.GetFilerInforamationBroker("107772", lstFilerCommitteeModel[0].personID.ToString());
                    Session["PersonId"] = lstFilerCommitteeModel[0].personID.ToString();
                    Session["FilerID"] = lstFilerCommitteeModel[0].FilerId.ToString();
                    Session["CommID"] = lstFilerCommitteeModel[0].CommitteeId.ToString();
                    Session["FILER_INFO"] = listFilerInfo;
                    Session["FILER_Data"] = listFilerInfo[0].Filer_ID.ToString() + ' ' + listFilerInfo[0].Cand_Comm_Name.ToString();
                    Session["FILER_NAME"] = listFilerInfo[0].Name.ToString();
                    Session["FilerId"] = listFilerInfo[0].Filer_ID.ToString();
                    Session["Cand_Comm_Name"] = listFilerInfo[0].Cand_Comm_Name.ToString();
                    Session["Cand_Comm_ID"] = listFilerInfo[0].Cand_Comm_ID.ToString();
                    // TESTING ONLY AFTER AUTHENTICATION FILL IT.
                    Session["UserName"] = "Static_Name_SBasireddy";
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllApplicationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
    }
}