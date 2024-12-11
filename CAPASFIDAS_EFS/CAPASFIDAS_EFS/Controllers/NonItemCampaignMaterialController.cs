using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Web;
using SAML_Interface;
using System.Configuration;


namespace CAPASFIDAS_EFS.Controllers
{
    public class NonItemCampaignMaterialController : Controller
    {
        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Variables

        #region NonItemCampaignMaterial
        /// <summary>
        /// NonItemCampaignMaterial
        /// </summary>
        /// <returns></returns>
        // GET: NonItemCampaignMaterial
        public ActionResult NonItemCampaignMaterial()
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
                    //Session["PersonId"] = "18099"; // Testing only replace with main Session (Login).
                    //Session["PersonId"] = "4929"; //"23161";
                    //Session["FilerId"] = "113070"; // Testing only replace with main Session (Login).
                    //Session["TreasurerId"] = "204649"; // Testing only replace with main Session (Login).                        

                    GetDefaultLookUpsValues();
                }
                return View("NonItemCampaignMaterial");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion NonItemCampaignMaterial

        #region GetCampaignMaterialData
        /// <summary>
        /// GetCampaignMaterialData
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionYear"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstDisclosureType"></param>
        /// <returns></returns>
        public JsonResult GetCampaignMaterialData(String txtFilerID, String lstElectionCycle, String lstElectionYear, String lstUCOfficeType, String lstElectionType, String lstElectionDate, String lstDisclosurePeriod, String strDisclosurePeriodDesc, String lstElectionDateId, String txtCuttOffDate, String lstFilingDate, String txtReportPeriodDatesTo)
        {
            try
            {
                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModel = new List<NonItemCampaignMaterialDataModel>();
                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModelResults = new List<NonItemCampaignMaterialDataModel>();
                NonItemCampaignMaterialDataModel objNonItemCampaignMaterialDataModel;
                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModelResult = new List<NonItemCampaignMaterialDataModel>();

                if (lstDisclosurePeriod == null)
                    lstDisclosurePeriod = "";

                NonItemCampaignMaterialModel objNonItemCampaignMaterialModel = new NonItemCampaignMaterialModel();
                objNonItemCampaignMaterialModel.FilerId = txtFilerID;
                objNonItemCampaignMaterialModel.ElectionDate = lstElectionDate;
                objNonItemCampaignMaterialModel.ElectYearId = lstElectionCycle;
                objNonItemCampaignMaterialModel.ElectionYear = lstElectionYear;
                objNonItemCampaignMaterialModel.ElectionTypeId = lstElectionType;
                objNonItemCampaignMaterialModel.OfficeTypeId = lstUCOfficeType;
                objNonItemCampaignMaterialModel.FilingTypeId = lstDisclosurePeriod;
                objNonItemCampaignMaterialModel.ElectionDateId = lstElectionDateId;
                if (txtCuttOffDate != "")
                {
                    objNonItemCampaignMaterialModel.FilingDate = txtCuttOffDate;
                }
                else
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objNonItemCampaignMaterialModel.FilingDate = txtReportPeriodDatesTo;
                    else
                        objNonItemCampaignMaterialModel.FilingDate = lstFilingDate.Trim();
                }

                // Use Session for FilerID, Report Year, Disclouser Period
                Session["FilerId"] = txtFilerID;
                Session["ElectionYear"] = lstElectionYear;
                Session["DisclosurePeriodDesc"] = strDisclosurePeriodDesc;

                lstCampaignMaterialModelResults = objItemizedReportsBroker.GetCampaignMaterialDataResponse(objNonItemCampaignMaterialModel);
                Session["lstCampaignMaterialModel"] = lstCampaignMaterialModelResults;


                foreach (var item in lstCampaignMaterialModelResults)
                {
                    if (item != null)
                    {
                        objNonItemCampaignMaterialDataModel = new NonItemCampaignMaterialDataModel();
                        objNonItemCampaignMaterialDataModel.CampaignMaterialId = item.CampaignMaterialId;
                        objNonItemCampaignMaterialDataModel.FilingMethodId = item.FilingMethodId;
                        objNonItemCampaignMaterialDataModel.ScanDocId = item.ScanDocId;
                        objNonItemCampaignMaterialDataModel.DateSubmitted = item.DateSubmitted;
                        objNonItemCampaignMaterialDataModel.CampaignMaterialDesc = item.CampaignMaterialDesc;
                        objNonItemCampaignMaterialDataModel.FilingMethodDesc = item.FilingMethodDesc;
                        objNonItemCampaignMaterialDataModel.RCampMatr = item.RCampMatr;
                        objNonItemCampaignMaterialDataModel.CampMatrFileType = item.CampMatrFileType;
                        objNonItemCampaignMaterialDataModel.CampMatrFileSize = item.CampMatrFileSize;
                        if (item.RCampMatr == "Yes")
                        {
                            if (item.CampMatrFileType != null)
                                objNonItemCampaignMaterialDataModel.CampMatrFileType = objNonItemCampaignMaterialDataModel.CampMatrFileType + " (" + objNonItemCampaignMaterialDataModel.CampMatrFileSize + ")";
                            else
                                objNonItemCampaignMaterialDataModel.CampMatrFileType = "";
                        }
                        else
                        {
                            objNonItemCampaignMaterialDataModel.CampMatrFileType = "";
                        }
                        objNonItemCampaignMaterialDataModel.RAmended = item.RAmended;

                        lstCampaignMaterialModel.Add(objNonItemCampaignMaterialDataModel);
                    }
                }

                return Json(new
                {
                    aaData = lstCampaignMaterialModel.Select(x => new[] {
                    x.CampaignMaterialId,
                    x.FilingMethodId,
                    x.ScanDocId,
                    "",
                    "",
                    x.DateSubmitted,
                    x.CampaignMaterialDesc,
                    x.CampMatrFileType,
                    x.FilingMethodDesc,
                    x.RCampMatr,
                    x.RAmended
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetCampaignMaterialData

        #region GetCampaignMaterialDataCheckNoYesCM
        /// <summary>
        /// GetCampaignMaterialDataCheckNoYesCM
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionYear"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="strDisclosurePeriodDesc"></param>
        /// <param name="lstElectionDateId"></param>
        /// <param name="txtCuttOffDate"></param>
        /// <returns></returns>
        public JsonResult GetCampaignMaterialDataCheckNoYesCM(String txtFilerID, String lstElectionCycle, String lstElectionYear, String lstUCOfficeType, String lstElectionType, String lstElectionDate, String lstDisclosurePeriod, String strDisclosurePeriodDesc, String lstElectionDateId, String txtCuttOffDate, String lstFilingDate, String txtReportPeriodDatesTo)
        {
            try
            {
                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModel = new List<NonItemCampaignMaterialDataModel>();
                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModelResults = new List<NonItemCampaignMaterialDataModel>();
                NonItemCampaignMaterialDataModel objNonItemCampaignMaterialDataModel;
                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModelResult = new List<NonItemCampaignMaterialDataModel>();

                NonItemCampaignMaterialModel objNonItemCampaignMaterialModel = new NonItemCampaignMaterialModel();
                objNonItemCampaignMaterialModel.FilerId = txtFilerID;
                objNonItemCampaignMaterialModel.ElectionDate = lstElectionDate;
                objNonItemCampaignMaterialModel.ElectYearId = lstElectionCycle;
                objNonItemCampaignMaterialModel.ElectionYear = lstElectionYear;
                objNonItemCampaignMaterialModel.ElectionTypeId = lstElectionType;
                objNonItemCampaignMaterialModel.OfficeTypeId = lstUCOfficeType;
                objNonItemCampaignMaterialModel.FilingTypeId = lstDisclosurePeriod;
                objNonItemCampaignMaterialModel.ElectionDateId = lstElectionDateId;
                //objNonItemCampaignMaterialModel.FilingDate = txtCuttOffDate;
                if (txtCuttOffDate != "")
                {
                    objNonItemCampaignMaterialModel.FilingDate = txtCuttOffDate;
                }
                else
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objNonItemCampaignMaterialModel.FilingDate = txtReportPeriodDatesTo;
                    else
                        objNonItemCampaignMaterialModel.FilingDate = lstFilingDate.Trim();
                }

                // Use Session for FilerID, Report Year, Disclouser Period
                Session["FilerId"] = txtFilerID;
                Session["ElectionYear"] = lstElectionYear;
                Session["DisclosurePeriodDesc"] = strDisclosurePeriodDesc;

                lstCampaignMaterialModelResults = objItemizedReportsBroker.GetCampaignMaterialDataResponse(objNonItemCampaignMaterialModel);
                Session["lstCampaignMaterialModel"] = lstCampaignMaterialModelResults;

                String strCount = lstCampaignMaterialModelResults.Count().ToString();

                if (lstCampaignMaterialModelResults.Count() > 0)
                {
                    foreach (var item in lstCampaignMaterialModelResults)
                    {
                        if (item != null)
                        {
                            objNonItemCampaignMaterialDataModel = new NonItemCampaignMaterialDataModel();
                            objNonItemCampaignMaterialDataModel.RCampMatr = item.RCampMatr;
                            objNonItemCampaignMaterialDataModel.CamapaignMaterialCount = strCount;
                            lstCampaignMaterialModel.Add(objNonItemCampaignMaterialDataModel);
                            break;
                        }
                    }
                }
                else
                {
                    objNonItemCampaignMaterialDataModel = new NonItemCampaignMaterialDataModel();
                    objNonItemCampaignMaterialDataModel.RCampMatr = "";
                    objNonItemCampaignMaterialDataModel.CamapaignMaterialCount = "0";
                    lstCampaignMaterialModel.Add(objNonItemCampaignMaterialDataModel);
                }

                return Json(lstCampaignMaterialModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetCampaignMaterialDataCheckNoYesCM

        #region SaveNonItemCampMaterialData
        /// <summary>
        /// SaveNonItemCampMaterialData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstElectionDateId"></param>
        /// <param name="txtDateSubmittedCampMater"></param>
        /// <param name="lstFilingMethod"></param>
        /// <param name="txtDescription"></param>
        /// <param name="txtFileUpload"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveNonItemCampMaterialData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId, String lstUCOfficeType, String lstElectionType, String lstElectionDate, String lstElectionDateId, String lstDisclosureType, String lstDisclosurePeriod, String txtDescription, String txtFileUpload, String strCampMatrYN, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate)
        {
            try
            {
                if (strCampMatrYN == "true")
                    strCampMatrYN = "N";
                else
                    strCampMatrYN = "Y";

                if (strCampMatrYN == "N")
                    txtFileUpload = null;

                NonItemCampaignMaterialModel objNonItemCampaignMaterialModel = new NonItemCampaignMaterialModel();
                String lstFilingMethod = String.Empty;
                if (strCampMatrYN == "Y")
                    lstFilingMethod = "2"; // Uploading Electronically.
                else
                    lstFilingMethod = null; // Uploading Electronically.

                if (lstDisclosurePeriod == null)
                    lstDisclosurePeriod = "";

                objNonItemCampaignMaterialModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                objNonItemCampaignMaterialModel.ElectionDate = lstElectionDate;
                objNonItemCampaignMaterialModel.ElectionDateId = lstElectionDateId;
                objNonItemCampaignMaterialModel.ElectionTypeId = lstElectionType; //"P"; // lstElectionType; Testing Only...            
                objNonItemCampaignMaterialModel.ElectYearId = lstElectionCycleId;
                objNonItemCampaignMaterialModel.OfficeTypeId = lstUCOfficeType;
                objNonItemCampaignMaterialModel.ElectionYear = lstElectionCycle;
                objNonItemCampaignMaterialModel.FilingCategoryId = lstDisclosureType;
                objNonItemCampaignMaterialModel.FilingTypeId = lstDisclosurePeriod;
                objNonItemCampaignMaterialModel.DateSubmitted = "";
                if (strCampMatrYN == "N")
                {
                    objNonItemCampaignMaterialModel.CampMatrFileType = null;
                    objNonItemCampaignMaterialModel.CampMatrFileSize = null;
                    objNonItemCampaignMaterialModel.SacnDocId = null;
                }
                else
                {
                    objNonItemCampaignMaterialModel.CampMatrFileType = Session["FileType"].ToString();
                    objNonItemCampaignMaterialModel.CampMatrFileSize = Session["FileSize"].ToString();
                    objNonItemCampaignMaterialModel.SacnDocId = Session["DocumentId"].ToString();
                }
                objNonItemCampaignMaterialModel.RCampMatr = strCampMatrYN;
                objNonItemCampaignMaterialModel.FilingMethodId = lstFilingMethod;
                objNonItemCampaignMaterialModel.CampaignMaterialDesc = txtDescription;
                if (txtCuttOffDate != "")
                {
                    objNonItemCampaignMaterialModel.FilingDate = txtCuttOffDate;
                }
                else
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objNonItemCampaignMaterialModel.FilingDate = txtReportPeriodDatesTo;
                    else
                        objNonItemCampaignMaterialModel.FilingDate = lstFilingDate;
                }
                //objNonItemCampaignMaterialModel.FilingDate = DateTime.Now.ToShortDateString();            

                objNonItemCampaignMaterialModel.CreatedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing Only...

                var results = objItemizedReportsBroker.AddNonItemCampaignMaterialResponse(objNonItemCampaignMaterialModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveNonItemCampMaterialData

        #region DeleteNonItemCampMaterialData
        /// <summary>
        /// DeleteNonItemCampMaterialData
        /// </summary>
        /// <param name="strCampaignMaterialId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteNonItemCampMaterialData(String strCampaignMaterialId)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.DeleteCampaignMaterialResponse(strCampaignMaterialId, strModifiedBy);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteNonItemCampMaterialData
                
        #region UploadCampaignMaterialData
        /// <summary>
        /// UploadCampaignMaterialData
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadCampaignMaterialData(HttpPostedFileBase data)
        {
            try
            {
                CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();

                CampMatrDocumentIdModel objCampMatrDocumentIdModel = new CampMatrDocumentIdModel();
                UploadFileNTDriveModel objUploadFileNTDriveModel = new UploadFileNTDriveModel();

                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].FileName != "")
                    {
                        Stream varStream = Request.Files[upload].InputStream;

                        String strFileSize = varStream.Length.ToString();
                        // Convert file size to KB or MB.
                        String[] sizes = { "B", "KB", "MB", "GB", "TB" };
                        Double len = Convert.ToDouble(strFileSize);
                        int order = 0;
                        while (len >= 1024 && order < sizes.Length - 1)
                        {
                            order++;
                            len = len / 1024;
                        }

                        len = Math.Round(len);

                        // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
                        // show a single decimal place, and no space.                    
                        String resultFileSize = String.Format("{0:0.##} {1}", len, sizes[order]);
                        Session["FileSize"] = resultFileSize;

                        // Convert Stream to Bytes.
                        //var mStreamer = new MemoryStream();
                        MemoryStream mStreamer = new MemoryStream();
                        mStreamer.SetLength(varStream.Length);
                        varStream.Read(mStreamer.GetBuffer(), 0, (int)varStream.Length);
                        mStreamer.Seek(0, SeekOrigin.Begin);
                        objUploadFileNTDriveModel.FileBytes = mStreamer.GetBuffer();


                        objCampMatrDocumentIdModel.varStream = varStream;
                        objCampMatrDocumentIdModel.fileBytes = objUploadFileNTDriveModel.FileBytes;

                        Session["FileName"] = Request.Files[upload].FileName;
                    }
                }

                // Filing Type Abbrevations.
                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
                lstDisclosurePreiodModel = (IList<DisclosurePreiodModel>)Session["DisclosurePeriod"];

                // NEW LOGIC CHANGE ON 10-DAY POST PRIMARY ON PRIMARY ELECTION
                // WE ARE NOT SHOWING FOR YEAR 2021 AND ABOVE THE 10-DAY POST PRIMARY IN DISCLOSURE PERIOD DROPDOWN.
                // WE ARE NOT CHANGING FOR YEAR 2020 AND BELOW NO CHANGES.
                String strFilingTypeAbbrev = String.Empty;
                if (Session["DisclosurePeriodDesc"] != null)
                {
                    if (Session["DisclosurePeriodDesc"].ToString() != "")
                        strFilingTypeAbbrev = lstDisclosurePreiodModel.Where(x => x.FilingDesc == Session["DisclosurePeriodDesc"].ToString()).Select(x => x.FilingAbbrev).FirstOrDefault().ToString();
                    else
                        strFilingTypeAbbrev = "Primary";
                }

                //Get File Extension
                FileInfo ObjfileInfo = new FileInfo(Session["FileName"].ToString());
                //String getExtension = ObjfileInfo.Extension.Substring(1).ToString().ToUpper();
                String getExtension = ObjfileInfo.Extension.Substring(1).ToString().ToLower();
                Session["ExtensionName"] = getExtension;

                String filerName = Session["FilerId"].ToString();  //"A12345"; // Get Filer Id.
                String fileName = Session["fileName"].ToString();
                if (strFilingTypeAbbrev != "")
                    fileName = Session["ElectionYear"].ToString() + "_" + strFilingTypeAbbrev + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + Session["ExtensionName"].ToString();
                else
                    fileName = Session["ElectionYear"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + Session["ExtensionName"].ToString();

                objUploadFileNTDriveModel.CampMatrFileName = fileName;
                objUploadFileNTDriveModel.FilerIdNTDrive = Session["FilerId"].ToString();
                objUploadFileNTDriveModel.ElectionYearNTDrive = Session["ElectionYear"].ToString();
                objUploadFileNTDriveModel.DisclosurePeriodNTDrive = Session["DisclosurePeriodDesc"].ToString();

                //Boolean returnValue = objItemizedReportsBroker.UploadFileInNetworkDriveResponse(objUploadFileNTDriveModel);

                objCampMatrDocumentIdModel.strCampMatrFileName = fileName;
                objCampMatrDocumentIdModel.strCampMatrFilerId = filerName;
                //Folder Creation Path
                objCampMatrDocumentIdModel.FolderFilerId = Session["FilerId"].ToString();
                objCampMatrDocumentIdModel.FolderElectionYear = Session["ElectionYear"].ToString();
                objCampMatrDocumentIdModel.FolderDisclosurePeriod = Session["DisclosurePeriodDesc"].ToString();
                objCampMatrDocumentIdModel.FileExtension = Session["ExtensionName"].ToString().ToUpper();
                objCampMatrDocumentIdModel.PageName = "CampaignMaterials";

                // CALLED GETTOKENID() METHOD HERE.
                objCabinetReturnValModel = objItemizedReportsBroker.GetTokenIdResponse(objCampMatrDocumentIdModel);

                if (objCabinetReturnValModel.Extension != null)
                    Session["FileType"] = objCabinetReturnValModel.Extension;
                else
                    Session["FileType"] = getExtension.ToUpper();
                Session["DocumentId"] = objCabinetReturnValModel.DocumentID;

                //Write your own SQL server Add logic

                return Json("", JsonRequestBehavior.AllowGet);
                //return Json(returnValue, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UploadCampaignMaterialData

        #region DownloadCampaignMaterial
        // AFTER JQUERY FILES UPDATE ITS NOT WORKING WITH JSONRESULT WITH EMPTY STRING RETURN.
        // SO CHANGED TO VOID AND NO RETURN AND ITS WORKING FINE 
        // WE HAVE TO CHANGE THIS CODE IN EVERY WHERE DOWNLOAD DOCUMENT FROM CABINET.
        /// <summary>
        /// DownloadCampaignMaterial
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public void DownloadCampaignMaterial(String documentID)
        {
            try
            {
                CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
                CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();

                String fileName = String.Empty;

                IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModel = new List<NonItemCampaignMaterialDataModel>();
                lstCampaignMaterialModel = (IList<NonItemCampaignMaterialDataModel>)Session["lstCampaignMaterialModel"];

                String strFileType = lstCampaignMaterialModel.Where(x => x.ScanDocId == documentID.ToString()).Select(x => x.CampMatrFileType).FirstOrDefault().ToString();

                objCabinetReturnValModel = objItemizedReportsBroker.GetTokenIDBroker(strFileType, "CampaignMaterials");

                objCabinetDownloadObjectModel = objItemizedReportsBroker.DocumentDownloadBroker(objCabinetReturnValModel.TokenID.ToString(), Int32.Parse(objCabinetReturnValModel.CabinetID.ToString()), Int32.Parse(documentID), fileName);
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

                //return Json("", JsonRequestBehavior.AllowGet);
                // AFTER JQUERY FILES UPDATE ITS NOT WORKING WITH JSONRESULT WITH EMPTY STRING RETURN.
                // SO CHANGED TO VOID AND NO RETURN AND ITS WORKING FINE 
                // WE HAVE TO CHANGE THIS CODE IN EVERY WHERE DOWNLOAD DOCUMENT FROM CABINET.
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DownloadCampaignMaterial

        #region GetDefaultLookUpsValues
        /// <summary>
        /// GetDefaultLookUpsValues
        /// </summary>
        public void GetDefaultLookUpsValues()
        {
            // CHECKING SESSION VALUES.
            // ELECTION YEAR ID.
            if (Session["ElectionCycleVal"] == null)
            {
                Session["ElectionCycleVal"] = Session["ElectionCycleVal_Dup"];
            }
            else if (Session["ElectionCycleVal"].ToString() == "")
            {
                Session["ElectionCycleVal"] = Session["ElectionCycleVal_Dup"];
            }
            // ELECTION TYPE ID.
            if (Session["ElectionTypeVal"] == null)
            {
                Session["ElectionTypeVal"] = Session["ElectionTypeVal_Dup"];
            }
            else if (Session["ElectionTypeVal"].ToString() == "")
            {
                Session["ElectionTypeVal"] = Session["ElectionTypeVal_Dup"];
            }
            // OFFICE TYPE ID.
            if (Session["OfficeTypeVal"] == null)
            {
                Session["OfficeTypeVal"] = Session["OfficeTypeVal_Dup"];
            }
            else if (Session["OfficeTypeVal"].ToString() == "")
            {
                Session["OfficeTypeVal"] = Session["OfficeTypeVal_Dup"];
            }
            // COUNTY ID.
            if (Session["CountyVal"] == null)
            {
                Session["CountyVal"] = Session["CountyVal_Dup"];
            }
            else if (Session["CountyVal"].ToString() == "")
            {
                Session["CountyVal"] = Session["CountyVal_Dup"];
            }
            // MUNICIPALITY ID.
            if (Session["MunicipalityVal"] == null)
            {
                Session["MunicipalityVal"] = Session["MunicipalityVal_Dup"];
            }
            else if (Session["MunicipalityVal"].ToString() == "")
            {
                Session["MunicipalityVal"] = Session["MunicipalityVal_Dup"];
            }

            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            //lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["FilerID"].ToString());
            // Filer ID
            ViewData["txtFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");

            String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //String strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            String strCommId = lstFilerCommitteeModel.Select(x => x.FilerId).FirstOrDefault().ToString();
            // Committee Name
            ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeName", "CommitteeName");

            IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
            DisclosureTypesModel objDisclosureTypesModel;
            var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCommId); //GetDisclosureTypeData();
            objDisclosureTypesModel = new DisclosureTypesModel();
            objDisclosureTypesModel.DisclosureTypeId = "0";
            objDisclosureTypesModel.DisclosureTypeDesc = "- Select -";
            lstDisclosureTypeModel.Add(objDisclosureTypesModel);
            foreach (var item in results)
            {
                if (item != null)
                {
                    objDisclosureTypesModel = new DisclosureTypesModel();
                    objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
                    if (!String.IsNullOrEmpty(item.DisclosureSubTypeDesc))
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " " + item.DisclosureSubTypeDesc;
                    else
                        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                    lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                }
            }
            // Bind Disclosure Type
            ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            lstTransactionTypeModel = objItemizedReportsBroker.GetIEWeeklyExpTransactionTypesResponse(); ; //GetTransactionTypeData();
            // Bind Transaction Type
            ViewData["lstTransTypeNonItemWeeklyExp"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

            IList<PartnerModel> lstPartnerModel = new List<PartnerModel>();
            lstPartnerModel = objContributionsMonetaryController.GetPartnerData();
            // Bind Partner Data
            ViewData["lstPartner"] = new SelectList(lstPartnerModel, "PartnerId", "PartnerDesc");

            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
            lstElectionYearModel = objItemizedReportsBroker.GetElectionYearDataResponse(Session["FilerID"].ToString());
            // Report Year
            ViewData["lstElectionCycle"] = new SelectList(lstElectionYearModel, "ElectionYearId", "ElectionYearValue");

            IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
            lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(String.Empty,
                String.Empty, String.Empty, String.Empty, String.Empty);
            // Election Type
            ViewData["lstElectionType"] = new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc");

            IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
            lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(Session["ElectionCycleVal"].ToString(), Session["ElectionTypeVal"].ToString(), Session["OfficeTypeVal"].ToString(), Session["CountyVal"].ToString(), Session["MunicipalityVal"].ToString());
            // Electin Date
            ViewData["lstElectionDate"] = new SelectList(lstElectionDateModel, "ElectId", "ElectDate");

            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(), "");
            Session["DisclosurePeriod"] = lstDisclosurePreiodModel;
            // Disclosure Period
            ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

            IList<FilingMthodModel> lstFilingMthodModel = new List<FilingMthodModel>();
            FilingMthodModel objFilingMthodModel;
            objFilingMthodModel = new FilingMthodModel();
            objFilingMthodModel.FilingMethodId = "0";
            objFilingMthodModel.FilingMethodDesc = "- Select -";
            lstFilingMthodModel.Add(objFilingMthodModel);

            var resFilingMethods = objItemizedReportsBroker.GetFilingMethodDataResponse();
            foreach (var item in resFilingMethods)
            {
                if (item != null)
                {
                    objFilingMthodModel = new FilingMthodModel();
                    objFilingMthodModel.FilingMethodId = item.FilingMethodId;
                    objFilingMthodModel.FilingMethodDesc = item.FilingMethodDesc;
                    lstFilingMthodModel.Add(objFilingMthodModel);
                }
            }
            // Filing Method
            ViewData["lstFilingMethod"] = new SelectList(lstFilingMthodModel, "FilingMethodId", "FilingMethodDesc");

            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
            ContributorNameModel objContributorNameModel;
            objContributorNameModel = new ContributorNameModel();
            objContributorNameModel.ContributorTypeId = "0";
            objContributorNameModel.ContributorTypeDesc = "- Select -";
            objContributorNameModel.ContributorTypeAbbrev = "SEL";
            lstContributorNameModel.Add(objContributorNameModel);
            var resContributorNames = objItemizedReportsBroker.GetContributionNameDataResponse();
            var itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "6");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "7");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "2");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "1");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            foreach (var item in resContributorNames)
            {
                if (item != null)
                {
                    objContributorNameModel = new ContributorNameModel();
                    objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                    objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                    objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                    lstContributorNameModel.Add(objContributorNameModel);
                }
            }
            ViewData["lstContributionName"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc");

            IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();
            lstContributionTypeModel = objItemizedReportsBroker.GetContributionTypeDataResponse();
            // Bind Contribution Type
            ViewData["lstContributionType"] = new SelectList(lstContributionTypeModel, "ContributionTypeId", "ContributionTypeDesc");

            IList<TransferTypeModel> lstTransferTypeModel = new List<TransferTypeModel>();
            lstTransferTypeModel = objItemizedReportsBroker.GetTransferTypeDataResponse();
            // Bind Transfer Type
            ViewData["lstTransferType"] = new SelectList(lstTransferTypeModel, "TransferTypeId", "TransferTypeDesc");

            IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();
            lstReceiptTypeModel = objItemizedReportsBroker.GetReceiptTypeDataResponse();
            // Bind Receipt Code
            ViewData["lstReceiptType"] = new SelectList(lstReceiptTypeModel, "ReceiptTypeId", "ReceiptTypeDesc");

            IList<ReceiptCodeModel> lstReceiptCodeModel = new List<ReceiptCodeModel>();
            lstReceiptCodeModel = objItemizedReportsBroker.GetReceiptCodeDataResponse();
            // Bind Receipt Code            
            ViewData["lstReceiptCode"] = new SelectList(lstReceiptCodeModel, "ReceiptCodeId", "ReceiptCodeDesc");

            // PurposeCodeModel
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
            PurposeCodeModel objPurposeCodeModel;
            objPurposeCodeModel = new PurposeCodeModel();
            objPurposeCodeModel.PurposeCodeId = "0";
            objPurposeCodeModel.PurposeCodeDesc = "- Select -";
            objPurposeCodeModel.PurposeCodeAbbrev = "SEL";
            lstPurposeCodeModel.Add(objPurposeCodeModel);
            var resPurposeCoeds = objItemizedReportsBroker.GetPurposeCodeDataResponse();
            foreach (var item in resPurposeCoeds)
            {
                if (item != null)
                {
                    objPurposeCodeModel = new PurposeCodeModel();
                    objPurposeCodeModel.PurposeCodeId = item.PurposeCodeId;
                    objPurposeCodeModel.PurposeCodeDesc = item.PurposeCodeDesc;
                    objPurposeCodeModel.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                    lstPurposeCodeModel.Add(objPurposeCodeModel);
                }
            }
            // Bind Purpose Code            
            ViewData["lstPurposeCode"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");

            IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
            lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeResponse();
            // Bind Office Type
            ViewData["lstUCOfficeType"] = new SelectList(lstOfficeTypeModel, "OfficeTypeId", "OfficeTypeDesc");

            IList<CountyModel> lstCountyModel = new List<CountyModel>();
            lstCountyModel = objItemizedReportsBroker.GetCountyResponse();
            // Bind County
            ViewData["lstUCCounty"] = new SelectList(lstCountyModel, "CountyId", "CountyDesc");

            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
            lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(String.Empty);
            // Bind Municipality
            ViewData["lstUCMuncipality"] = new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc");

            // BINDING FILING DATE
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModelResults = new List<FilingDatesOffCycleModel>();
            FilingDatesOffCycleModel objFilingDatesOffCycleModel;

            if (Session["ElectionYearId"] != null)
                lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateIEWeeklyeDataResponse(Session["ElectionYearId"].ToString(), Session["ElectionTypeId"].ToString(), Session["OfficeTypeId"].ToString(), Session["FilerIdIEWeekly"].ToString(), Session["FilingType"].ToString(), Session["FilingCatId"].ToString(), Session["ElectionDateId"].ToString(), Session["MunicipalityID"].ToString());

            objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            objFilingDatesOffCycleModel.FilingDateId = "- Select -";
            objFilingDatesOffCycleModel.FilingDate = "- Select -";
            lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
            objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
            lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            if (lstFilingDatesOffCycleModelResults.Count() > 0)
            {
                foreach (var item in lstFilingDatesOffCycleModelResults)
                {
                    if (item != null)
                    {
                        objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                        objFilingDatesOffCycleModel.FilingDateId = item.FilingDateId;
                        objFilingDatesOffCycleModel.FilingDate = item.FilingDate;
                        lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    }
                }
            }
            // Bind Filing Date for Off Cycle.
            ViewData["lstFilingDate"] = new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate");

            // LIABILITY 
            List<LiabilityModel> lstLiability = new List<LiabilityModel>();
            LiabilityModel objLiability;
            objLiability = new LiabilityModel();
            objLiability.strLiabilityId = "N";
            objLiability.strLiabilityName = "No";
            lstLiability.Add(objLiability);
            objLiability = new LiabilityModel();
            objLiability.strLiabilityId = "Y";
            objLiability.strLiabilityName = "Yes";
            lstLiability.Add(objLiability);
            // Bind Liability
            ViewData["lstLiability"] = new SelectList(lstLiability, "strLiabilityId", "strLiabilityName", 1);
            ViewData["lstLiabilityExists"] = new SelectList(lstLiability, "strLiabilityId", "strLiabilityName", 1);

            // SUBCONTRACTOR
            List<SubcontractorModel> lstSubcontractor = new List<SubcontractorModel>();
            SubcontractorModel objSubcontractor;
            objSubcontractor = new SubcontractorModel();
            objSubcontractor.strSubcontractorId = "N";
            objSubcontractor.strSubcontractorName = "No";
            lstSubcontractor.Add(objSubcontractor);
            objSubcontractor = new SubcontractorModel();
            objSubcontractor.strSubcontractorId = "Y";
            objSubcontractor.strSubcontractorName = "Yes";
            lstSubcontractor.Add(objSubcontractor);
            // Bind Subcontractor
            ViewData["lstSubContractor"] = new SelectList(lstSubcontractor, "strSubcontractorId", "strSubcontractorName", 1);

            // DATE INCURRED
            List<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
            DateIncurredModel objDateIncurredModel;
            objDateIncurredModel = new DateIncurredModel();
            objDateIncurredModel.DateIncurredId = "0";
            objDateIncurredModel.DateIncurredValue = "- Select -";
            lstDateIncurredModel.Add(objDateIncurredModel);
            // Bind Date Incurred
            ViewData["lstDateIncurred"] = new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue");

            List<SupportedIEModel> lstSupportedIEModel = new List<SupportedIEModel>();
            SupportedIEModel objSupportedIEModel;
            objSupportedIEModel = new SupportedIEModel();
            objSupportedIEModel.strSupportedId = "Y";
            objSupportedIEModel.strSupportedName = "Yes";
            lstSupportedIEModel.Add(objSupportedIEModel);
            objSupportedIEModel = new SupportedIEModel();
            objSupportedIEModel.strSupportedId = "N";
            objSupportedIEModel.strSupportedName = "No";
            lstSupportedIEModel.Add(objSupportedIEModel);
            // Bind Subcontractor
            ViewData["lstSupported"] = new SelectList(lstSupportedIEModel, "strSupportedId", "strSupportedName", 1);
            List<ItemizedModel> lstItemizedModelIndPart = new List<ItemizedModel>();
            ItemizedModel objItemizedModelIndPart;
            objItemizedModelIndPart = new ItemizedModel();
            objItemizedModelIndPart.strItemizedId = "Y";
            objItemizedModelIndPart.strItemizedName = "Yes";
            lstItemizedModelIndPart.Add(objItemizedModelIndPart);
            objItemizedModelIndPart = new ItemizedModel();
            objItemizedModelIndPart.strItemizedId = "N";
            objItemizedModelIndPart.strItemizedName = "No";
            lstItemizedModelIndPart.Add(objItemizedModelIndPart);
            ViewData["lstIndividualPart"] = new SelectList(lstItemizedModelIndPart, "strItemizedId", "strItemizedName", 1);

            // Sortable Columns.
            IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "IE-WeeklyExpenditure");
            Session["SorList"] = lstSortColumnName;
            //Bind Column Name
            ViewData["lstSortColumnName"] = new SelectList(lstSortColumnName, "ViewableFieldID", "ColumnName");

            var lstSortColumnNameOrder = new SelectList(new[]
                                        {
                                            new {ID="asc",Name="Ascending "},
                                            new{ID="desc",Name="Descending"},
                                        },
                            "ID", "Name", 0);
            ViewData["lstSortColumnNameOrder"] = lstSortColumnNameOrder;
        }
        #endregion GetDefaultLookUpsValues

        #region DownloadCampaignMaterialNTDrive
        /// <summary>
        /// DownloadCampaignMaterialNTDrive
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadCampaignMaterialNTDrive()
        {
            try
            {
                //DOWNLOAD FILE FOR TESTING // TESTIN CODE......
                String strFolderPath = Session["FilerId"].ToString() + "//" + Session["ElectionYear"].ToString() + "//" + Session["DisclosurePeriodDesc"].ToString() + "//";

                String fileName = "CampaignMaterial20180918155838.pdf";

                String strFileFolderPath = strFolderPath + "CampaignMaterial20180918155838.pdf";

                // Call
                Byte[] byteFilePath = objItemizedReportsBroker.DownloadFileInNetworkDriveResponse(strFolderPath, fileName);

                //Write DocumentStream to browser
                HttpContext context = System.Web.HttpContext.Current;
                context.Response.Clear();
                Response.BufferOutput = false;  // for large files
                context.Response.AppendHeader("Pragma", "no-cache");

                //Make browser offer up a document download
                context.Response.ContentType = "application/force-download";

                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

                context.Response.AppendHeader("Content-Length", byteFilePath.Length.ToString());
                context.Response.AppendHeader("Connection", "close");

                context.Response.BinaryWrite(byteFilePath);
                context.Response.Close();

                //if (strFilePath != "")
                //{
                //    var response = System.Web.HttpContext.Current.Response;
                //    response.Clear();
                //    response.ClearContent();
                //    response.ClearHeaders();
                //    response.Buffer = true;
                //    response.AddHeader("Content -Description", "attachment;filename=" + strFilePath);
                //    response.WriteFile(strFilePath);
                //    response.Flush();
                //    response.End();
                //}

                //return Json("", JsonRequestBehavior.AllowGet);
                return File(byteFilePath, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemCampaignMaterialController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DownloadCampaignMaterialNTDrive        
    }
}