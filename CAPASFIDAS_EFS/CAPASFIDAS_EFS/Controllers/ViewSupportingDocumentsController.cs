// Creighton Newsom
// ViewSupportingDocuments Page 11/2018
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broker;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class ViewSupportingDocumentsController : Controller
    {
        // Create Broker Objects
        ViewSupportingDocumentsBroker objViewSupportingDocumentsBroker = new ViewSupportingDocumentsBroker();
        // THIS BROKER IS CREATED TO ACCESS THE FILERID AND USERINFORMATION
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        // THIS BROKER IS CREATED TO ACCESS THE GetElectionYearForFilerID METHOD
        ViewAllDisclosuresBroker objViewAllDisclosuresBroker = new ViewAllDisclosuresBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        #region "GetFilerIdData"
        public JsonResult GetFilerIdData()
        {
            try
            {
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
                lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserName"].ToString());
                ViewBag.lstFilerID = Session["FilerID"].ToString();
                ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
                Session["AuthenticatedFilerID"] = lstValidateFilerInfo[0].FilerID.ToString();
                Session["AuthenticatedCommitteeName"] = lstValidateFilerInfo[0].Name.ToString();
                ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
                return Json(new SelectList(lstValidateFilerInfo, "FilerID", "FilerID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewSupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion

        #region "ViewSupportingDocuments"
        // FUNCTION ASSIGNS TESTING VALUES TO SESSION VARIABLES
        // AND CALLS FUNCTION GetDefaultValues AND RETURNS VIEW
        public ActionResult ViewSupportingDocuments()
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
                    GetDefaultValues();
                }
                
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewSupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region GetDefaultValues
        // FUNCTION ASSIGNS SESSION VARIABLES AND MAKES INITIAL CALLS TO POPULATE DATA CONTROLS
        public void GetDefaultValues()
        {
            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            Session["PersonFilerId"] = lstFilerCommitteeModel;
            String strCommId = "";
            // Filer ID
            if (Session["FILER_INFO"] != null)
            {
                IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
                listFilerInfo = (IList<FilerInfoModel>)Session["FILER_INFO"];
                ViewData["lstFilerID"] = new SelectList(listFilerInfo, "Filer_ID", "Filer_ID");
                //ViewData["lstCommitteeName"] = new SelectList(listFilerInfo, "Cand_Comm_ID", "Cand_Comm_Name");
                Session["CommitteeDataInLieuOf"] = listFilerInfo;
                strCommId = listFilerInfo[0].Cand_Comm_ID.ToString();
            }
            else
            {
                ViewData["lstFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");
                String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
                lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
                strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
                Session["CommitteeDataInLieuOf"] = lstFilerCommitteeModel;
                // Committee Name
                ViewData["lstCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");
            }
            ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
            ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
            // GET THE REPORT YEARS FOR THIS FILER ID. THIS IS ONLY DONE HERE.
            // THE ViewAllDisclosures BROKER METHOD IS CALLED
            IList<ElectionYearModel> lstReportYear = new List<ElectionYearModel>();          
            lstReportYear = objViewSupportingDocumentsBroker.GetElectionYearForFilerID_VSD(Session["FilerId"].ToString());
            ViewData["lstReportYear"] = new SelectList(lstReportYear, "ElectionYearId", "ElectionYearValue");

            // INITIALIZE THE DISCLOSUREPERIOD LIST BOX WITH "SELECT". THE CONTROL ALSO GETS 
            // REPOPULATED WHEN THE USER SELECTS A YEAR ON THE PAGE
            var lstDisclosurePeriod = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            ViewData["lstDisclosurePeriod"] = lstDisclosurePeriod;
         }
        #endregion GetDefaultLookUpsValues

        #region "ViewSupportingDocumentsGridData"
        // FUNCTION GETS DATA FOR THE SUPPORTINGDOCUMENTS GRID
        // FILERID IS REQUIRED, REPORTYEAR AND DISCLOSUREPERIOD ARE OPTIONAL
        public JsonResult ViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID)
        {
            try
            {
                IList<ViewSupportingDocumentsGridModel> lstViewSupportingDocumentsGridModel = new List<ViewSupportingDocumentsGridModel>();
                lstViewSupportingDocumentsGridModel = objViewSupportingDocumentsBroker.getViewSupportingDocumentsGridData(strFilerID, strReportYearID, strDisclosurePeriodID);

                // FOR UNIT TESTS, SESSION == NULL
                if (Session != null)
                    Session["SupportingDocumentsGrid"] = lstViewSupportingDocumentsGridModel;

                return Json(new
                {
                    aaData = lstViewSupportingDocumentsGridModel.Select(x => new[] {
                    x.SupportDocID,
                    x.ScanDocID,
                    x.OfficeTypeID,
                    x.ElectTypeID,
                    x.PolCalDateID,
                    "",
                    "",
                    x.DateReceived,
                    x.DocumentType,
                    x.Amended,
                    x.ReportYear,
                    x.OfficeType,
                    x.ElectionType,
                    x.ElectionDate,
                    x.DisclosurePeriod,
                    x.R_Status,
                    x.FileType,
                    x.Size,
                    x.FilingMethod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewSupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetDisclosurePeriodsForYearAndFilerID"
        // FUNCTION GETS THE DISCLOSURE PERIODS BASED ON THE YEAR AND FILER ID
        public JsonResult GetDisclosurePeriodsForYearAndFilerID(String strFilerID, String strElectionYearID)
        {
            try
            {
                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                lstDisclosurePreiodModel = objViewSupportingDocumentsBroker.GetDisclosurePeriodsForYearAndFilerIDDataResponse(strFilerID, strElectionYearID);
                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewSupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region DownloadSupportingDocument
        /// <summary>
        /// DownloadCampaignMaterial
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public JsonResult DownloadSupportingDocument(String strDocumentID)
        {
            try
            {
                CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
                CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();

                String fileName = String.Empty;

                IList<ViewSupportingDocumentsGridModel> supportingDocumentsList = new List<ViewSupportingDocumentsGridModel>();
                supportingDocumentsList = (IList<ViewSupportingDocumentsGridModel>)Session["SupportingDocumentsGrid"];

                String strFileType = supportingDocumentsList.Where(x => x.SupportDocID == strDocumentID.ToString()).Select(x => x.FileType).FirstOrDefault().ToString();
                String strScanDocID = supportingDocumentsList.Where(x => x.SupportDocID == strDocumentID.ToString()).Select(x => x.ScanDocID).FirstOrDefault().ToString();

                objCabinetReturnValModel = objItemizedReportsBroker.GetTokenIDBroker(strFileType, "SupportingDocuments");

                //objCabinetDownloadObjectModel = objItemizedReportsBroker.DocumentDownloadBroker(objCabinetReturnValModel.TokenID.ToString(), Int32.Parse(objCabinetReturnValModel.CabinetID.ToString()), Int32.Parse(strDocumentID), fileName);
                objCabinetDownloadObjectModel = objItemizedReportsBroker.DocumentDownloadBroker(objCabinetReturnValModel.TokenID.ToString(), Int32.Parse(objCabinetReturnValModel.CabinetID.ToString()), Int32.Parse(strScanDocID), fileName);
                fileName = objCabinetDownloadObjectModel.FileName;
                byte[] DocumentByteArray = objCabinetDownloadObjectModel.FileByte;
                //Write DocumentStream to browser
                HttpContext context = System.Web.HttpContext.Current;
                context.Response.Clear();
                Response.BufferOutput = false;  // for large files
                context.Response.AppendHeader("Pragma", "no-cache");

                //Make browser offer up a document download
                context.Response.ContentType = "application/force-download";

                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

                context.Response.AppendHeader("Content-Length", DocumentByteArray.Length.ToString());
                context.Response.AppendHeader("Connection", "close");

                context.Response.BinaryWrite(DocumentByteArray);
                context.Response.Close();

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewSupportingDocumentsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DownloadCampaignMaterial

        #region Grid Help
        /// <summary>
        /// ActiveDeactiveFilerGridHelp
        /// </summary>
        /// <returns></returns>
        //public ActionResult ActiveDeactiveFilerGridHelp()
        //{
        //    return View("ActiveDeactiveFilerGridHelp");
        //}
        #endregion Grid Help

        #region Filer Help
        /// <summary>
        /// ViewSupportingDocumentsSearchHelp
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewSupportingDocumentsSearchHelp()
        {
            return View("ViewSupportingDocumentsSearchHelp");
        }
        #endregion Filer Help    

    }
}