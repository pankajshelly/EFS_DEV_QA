using System;
using Broker;
using CAPASFIDAS_EFS.CommonErrors;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;
using System.IO;


namespace CAPASFIDAS_EFS.Controllers
{
    public class HelpMenuController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();

        #region HelpDisclosureRpt
        /// <summary>
        /// HelpDisclosureRpt
        /// </summary>
        /// <returns></returns>
        // GET: HelpMenu
        public ActionResult HelpDisclosureRpt(FormCollection collections, string Command)
        {
            try
            {
                if (Session["SAMLResponse"] == null)
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                //else
                //{
                //    if (Command == "btnDownloadHelpDocumentPDF")
                //    {
                //        DowloadHelpDocumentPDFFile();
                //    }
                //}
                return View("HelpDisclosureRpt");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "HelpMenuController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion HelpDisclosureRpt

        #region HelpViewDisclosureRpt
        /// <summary>
        /// HelpViewDisclosureRpt
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpViewDisclosureRpt()
        {
            return View("HelpViewDisclosureRpt");
        }
        #endregion HelpViewDisclosureRpt

        #region HelpEditDeleteTrans
        /// <summary>
        /// HelpEditDeleteTrans
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpEditDeleteTrans()
        {
            return View("HelpEditDeleteTrans");
        }
        #endregion HelpEditDeleteTrans

        #region HelpDeleteDisclosureRpt
        /// <summary>
        /// HelpDeleteDisclosureRpt
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpDeleteDisclosureRpt()
        {
            return View("HelpDeleteDisclosureRpt");
        }
        #endregion HelpDeleteDisclosureRpt

        #region HelpSubmitDisclosureRpt
        /// <summary>
        /// HelpSubmitDisclosureRpt
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpSubmitDisclosureRpt()
        {
            return View("HelpSubmitDisclosureRpt");
        }
        #endregion HelpSubmitDisclosureRpt

        #region HelpUploadSupportingDocs
        /// <summary>
        /// HelpUploadSupportingDocs
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpUploadSupportingDocs()
        {
            return View("HelpUploadSupportingDocs");
        }
        #endregion HelpUploadSupportingDocs

        #region HelpRptCampaignMatrls
        /// <summary>
        /// HelpRptCampaignMatrls
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpRptCampaignMatrls()
        {
            return View("HelpRptCampaignMatrls");
        }
        #endregion HelpRptCampaignMatrls

        #region HelpReconcileLoans
        /// <summary>
        /// HelpReconcileLoans
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpReconcileLoans()
        {
            return View("HelpReconcileLoans");
        }
        #endregion HelpReconcileLoans

        #region HelpImportDisclosureReports
        /// <summary>
        /// HelpImportDisclosureReports
        /// </summary>
        /// <returns></returns>
        public ActionResult HelpImportDisclosureReports()
        {
            return View("HelpImportDisclosureReports");
        }
        #endregion HelpImportDisclosureReports

        ///// <summary>
        ///// DowloadHelpDocumentPDFFile()
        ///// </summary>
        ///// <returns></returns>
        //public void DowloadHelpDocumentPDFFile()
        //{
        //    try
        //    {
        //        List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();
        //        objEFSPDFResponseModel = objItemizedReportsBroker.DowloadHelpDocumentPDFFileBroker();
        //        Response.Clear();
        //        MemoryStream ms = new MemoryStream(objEFSPDFResponseModel[0].fileByte);
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=BOE_SchedAImport_DataDictionary.pdf");
        //        Response.Buffer = true;
        //        ms.WriteTo(Response.OutputStream);
        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (Session["UserName"] != null)
        //        {
        //            objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
        //        }
        //        throw;
        //    }
        //}

    }
}