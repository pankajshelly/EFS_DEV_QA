// Creighton Newsom
// ViewAllDisclosures Page
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broker;
using System.IO;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;
using System.Diagnostics;

namespace CAPASFIDAS_EFS.Controllers
{
    public class ViewAllDisclosuresController : Controller
    {
        // CREATE BROKER OBJECTS
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ViewAllDisclosuresBroker objViewAllDisclosuresBroker = new ViewAllDisclosuresBroker();
        ViewSupportingDocumentsBroker objViewSupportingDocsBroker = new ViewSupportingDocumentsBroker();        
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        // CREATE COMMON ERROR OBJECT
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();

        #region "ViewAllDisclosures"
        // FUNCTION ASSIGNS TESTING VALUES TO SESSION VARIABLES
        // AND CALLS FUNCTION GetDefaultValues AND RETURNS VIEW
        public ActionResult ViewAllDisclosures()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion

        #region "GetOfficeTypeDataForFilerID"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWN
        public JsonResult GetOfficeTypeData(String strElectYearID)
        {
            try
            {
                String FilerId = string.Empty;
                FilerId = Session["FilerId"].ToString();
                Session["Elect_Year_Id_VAD_PCFB"] = strElectYearID;
                IList<OfficeType> listOfficeType = new List<OfficeType>();
                // DropDown Office Type Data
                if (strElectYearID == "")
                {
                    listOfficeType = objViewAllDisclosuresBroker.GetOfficeTypeForFilerIDResponse("0", FilerId).ToList();
                }
                else
                {
                    listOfficeType = objViewAllDisclosuresBroker.GetOfficeTypeForFilerIDResponse(strElectYearID, FilerId).ToList();
                }

                return Json(new SelectList(listOfficeType, "OfficeTypeID", "OfficeTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetElectionTypeDataForFilerID"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN	
        /// <returns></returns>
        public JsonResult GetElectionTypeData(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID)
        {
            try
            {
                if (strMunicipalityID == "- Select -" || strMunicipalityID == null)
                    strMunicipalityID = "";

                // FOR UNIT TESTS SESSION == NULL
                String FilerId = string.Empty;
                //if (Session == null || Session["Filer_Id"] == null)
                //    FilerId = "113070";
                //else
                FilerId = Session["FilerId"].ToString();

                // DropDown Election Type Data
                IList<ElectionType> listElectionType = new List<ElectionType>();
                if ((strElectYearID == "- Select -") || (String.IsNullOrEmpty(strElectYearID)))
                    strElectYearID = "";
                if ((strOfficeTypeID == "- Select -") || (String.IsNullOrEmpty(strOfficeTypeID)))
                    strOfficeTypeID = "";
                if ((strCountyID == "- Select -") || (String.IsNullOrEmpty(strCountyID)))
                    strCountyID = "";
                if ((strMunicipalityID == "- Select -") || (String.IsNullOrEmpty(strMunicipalityID)))
                    strMunicipalityID = "";
                listElectionType = objViewAllDisclosuresBroker.GetElectionTypeForFilerIDResponse(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, FilerId).ToList();
                return Json(new SelectList(listElectionType, "ElectionTypeID", "ElectionTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetElectionDateData"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN	
        public JsonResult GetElectionDateData(String strElectionYearID, String strElectionTypeID, String strOfficeTypeID, String countyID, String municipalityID)
        {
            try
            {
                if (countyID == null)
                {
                    countyID = "";
                }
                if (municipalityID == null)
                {
                    municipalityID = "";
                }
                Session["ElectionCycleVal_VAD"] = strElectionYearID.ToString();
                Session["CountyVal"] = countyID;
                Session["MunicipalityVal"] = municipalityID;
                // DropDown Election Type Data
                IList<Election_Date> listElectionDate = new List<Election_Date>();
                listElectionDate = objViewAllDisclosuresBroker.GetElectionDateResponse(strElectionYearID, strElectionTypeID, strOfficeTypeID, Session["FilerId"].ToString(), countyID, municipalityID).ToList();
                return Json(new SelectList(listElectionDate, "ElectionDateId", "ElectionDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetCountyData"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        public JsonResult GetCountyData(String strOfficeType)
        {
            try
            {
                // DropDown County Data
                IList<County> listCounty = new List<County>();
                if (strOfficeType == "")
                {
                    listCounty = objViewAllDisclosuresBroker.GetCountyResponse(0).ToList();
                }
                else
                {
                    listCounty = objViewAllDisclosuresBroker.GetCountyResponse(Convert.ToInt32(strOfficeType)).ToList();
                }
                return Json(new SelectList(listCounty, "CountyID", "CountyBoard"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetMunicipalityData"
        // THIS FUNCTION GETS THE DATA FOR THE MUNICIPALITY FILTER DROPDOWN
        public JsonResult GetMunicipalityData(String strCountyID)
        {
            try
            {
                // DropDown Municipality Data
                IList<Municipality> listMunicipality = new List<Municipality>();
                if (strCountyID == "")
                {
                    listMunicipality = objViewAllDisclosuresBroker.GetMunicipalityResponse(0).ToList();
                }
                else
                {
                    listMunicipality = objViewAllDisclosuresBroker.GetMunicipalityResponse(Convert.ToInt32(strCountyID)).ToList();
                }

                return Json(new SelectList(listMunicipality, "MunicipalityID", "MunicipalityDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetDefaultValues"
        // FUNCTION MAKES CALLS TO DATABASE AND POPULATES VIEWDATA ITEMS FOR VIEW
        public void GetDefaultValues()
        {
            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            Session["PersonFilerId"] = lstFilerCommitteeModel;
            String strCommId = "";
            ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
            ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
            //// Filer ID
            //if (Session["FILER_INFO"] != null)
            //{
            //    IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
            //    listFilerInfo = (IList<FilerInfoModel>)Session["FILER_INFO"];
            //    ViewData["lstFilerID"] = new SelectList(listFilerInfo, "Filer_ID", "Filer_ID");
            //    ViewData["lstCommitteeName"] = new SelectList(listFilerInfo, "Cand_Comm_ID", "Cand_Comm_Name");
            //    Session["CommitteeDataInLieuOf"] = listFilerInfo;
            //    strCommId = listFilerInfo[0].Cand_Comm_ID.ToString();
            //}
            //else
            //{
            //    ViewData["lstFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");
            //    String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            //    lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //    strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            //    Session["CommitteeDataInLieuOf"] = lstFilerCommitteeModel;
            //    // Committee Name
            //    ViewData["lstCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");
            //}

            ////////////////////// FILTER DROP DOWN LISTS ////////////////////////////
            // REPORT YEAR
            IList<ElectionYearModel> lstReportYear = new List<ElectionYearModel>();
            lstReportYear = objViewAllDisclosuresBroker.GetElectionYearForFilerID(Session["FilerId"].ToString());
            ViewData["lstReportYear"] = new SelectList(lstReportYear, "ElectionYearId", "ElectionYearValue");

            // OFFICE TYPE
            var lstOfficeType = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            ViewData["lstOfficeType"] = lstOfficeType;

            //// COUNTY
            //var lstCounty = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            //ViewData["lstCounty"] = lstCounty;

            //// MUNICIPALITY
            //var lstMunicipality = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            //ViewData["lstMunicipality"] = lstMunicipality;

            IList<CountyModel> lstCountyModel = new List<CountyModel>();
            lstCountyModel = objItemizedReportsBroker.GetCountyResponse();
            // Bind County
            ViewData["lstCounty"] = new SelectList(lstCountyModel, "CountyId", "CountyDesc");

            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
            lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(String.Empty);
            // Bind Municipality
            ViewData["lstMunicipality"] = new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc");

            // ELECTION TYPE
            var lstElectionType = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            ViewData["lstElectionType"] = lstElectionType;

            // ELECTION DATE
            var lstElectionDate = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            ViewData["lstElectionDate"] = lstElectionDate;

            // DISCLOSURE TYPE
            var lstDisclosureType = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            ViewData["lstDisclosureType"] = lstDisclosureType;

            // DISCLOSURE PERIOD
            var lstDisclosurePeriod = new SelectList(new[] { new {ID="",Name="-Select-"},}, "ID", "Name", 1);
            ViewData["lstDisclosurePeriod"] = lstDisclosurePeriod;

            // FILING DATE
            var lstFilingDate = new SelectList(new[] { new { ID = "", Name = "-Select-" }, }, "ID", "Name", 1);
            ViewData["lstFilingDate"] = lstFilingDate;

            /////////////////////////////////// DIALOG DROPDOWN //////////////////////////////////
            // DOCUMENT TYPE    
            IList<DocumentTypeModel> lstDocumentTypeModel = new List<DocumentTypeModel>();
            IList<DocumentTypeModel> lstDocumentTypeModelPCF = new List<DocumentTypeModel>();
            DocumentTypeModel objDocumentTypeModel;
            lstDocumentTypeModel = objViewAllDisclosuresBroker.GetDocumentTypesDataResponse("1");
            ViewData["lstDocumentType"] = new SelectList(lstDocumentTypeModel, "DocumentTypeID", "DocumentTypeDesc");
            foreach (var item in lstDocumentTypeModel)
            {               
                if (item.DocumentTypeId == "3")
                {
                    objDocumentTypeModel = new DocumentTypeModel();
                    objDocumentTypeModel.DocumentTypeId = item.DocumentTypeId;
                    objDocumentTypeModel.DocumentTypeDesc = item.DocumentTypeDesc;
                    lstDocumentTypeModelPCF.Add(objDocumentTypeModel);
                }
                else if (item.DocumentTypeId == "4")
                {
                    objDocumentTypeModel = new DocumentTypeModel();
                    objDocumentTypeModel.DocumentTypeId = item.DocumentTypeId;
                    objDocumentTypeModel.DocumentTypeDesc = item.DocumentTypeDesc;
                    lstDocumentTypeModelPCF.Add(objDocumentTypeModel);
                }
            }
            ViewData["lstDocumentTypePCF"] = new SelectList(lstDocumentTypeModelPCF, "DocumentTypeID", "DocumentTypeDesc");

            // COMMUNICATION TYPE
            IList<CommunicationTypeModel> lstCommunicationTypeModel = new List<CommunicationTypeModel>();
            lstCommunicationTypeModel = objViewAllDisclosuresBroker.GetCommunicationTypes();
            ViewData["lstCommunicationTypes"] = new SelectList(lstCommunicationTypeModel, "CommunicationTypeID", "CommunicationTypeDesc");

        }

        #endregion "GetDefaultValues"

        #region "GetReportYears"
        public JsonResult GetReportYears()
        {
            try
            {
                IList<ElectionYearModel> lstReportYear = new List<ElectionYearModel>();
                lstReportYear = objViewAllDisclosuresBroker.GetElectionYearForFilerID(Session["FilerId"].ToString());
                return Json(new SelectList(lstReportYear, "ElectionYearId", "ElectionYearValue"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetDisclosurePeriodsForYearAndFilerID"
        // THIS FUNCTION GETS DISCLOSURE PERIODS FOR FILTER DROPDOWN	
        public JsonResult GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strElectionYearID, String strElectionTypeID, String strFilingCatID, String strOfficeTypeID)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String strFilerID = string.Empty;
                //if (Session == null || Session["Filer_Id"] == null)
                //    strFilerID = "113070";
                //else
                strFilerID = Session["FilerId"].ToString();

                IList<DisclosurePreiodModel> lstDisclosurePeriodModel = new List<DisclosurePreiodModel>();

                //lstDisclosurePeriodModel = objViewAllDisclosuresBroker.GetDisclosurePeriodDataResponse(strElectionTypeID, strDisclosureTypeID, FilerId);
                //lstDisclosurePeriodModel = objViewSupportingDocsBroker.GetDisclosurePeriodsForYearAndFilerIDDataResponse(strFilerID, strElectionYearID);
                lstDisclosurePeriodModel = objViewAllDisclosuresBroker.GetDisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID, strFilingCatID, strOfficeTypeID);

                return Json(new SelectList(lstDisclosurePeriodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetDisclosureTypesForYearAndFilerID"
        // THIS FUNCTION GETS THE DISCLOSURETYPES FOR FILTER DROPDOWN
        public JsonResult GetDisclosureTypesForYearAndFilerID(String strElectionYearID, String strElectionTypeID, String strElectionDateID)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String strFilerID = string.Empty;
                //if (Session == null || Session["Filer_Id"] == null)
                //    strFilerID = "113070";
                //else
                strFilerID = Session["FilerId"].ToString();

                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                lstDisclosureTypeModel = objViewAllDisclosuresBroker.GetDisclosureTypesForYearAndFilerIDDataResponse(strFilerID, strElectionYearID, strElectionTypeID, strElectionDateID);
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetDisclosuresGridData"
        // FUNCTION GETS THE DATA FOR THE DISCLOSURE GRID
        public JsonResult GetDisclosuresGridData(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDisclosureTypeID, String strDisclosurePeriodID, String strReportYear)
        {
            try
            {
                // SET THE SESSION VARIABLE HERE
                if (Session != null)
                    Session["ElectionYear"] = strReportYear;
                
                if (strCountyID == "- Select -"  || strCountyID == "All" || strCountyID == "0")
                {
                    strCountyID = "";
                }

                if (strMunicipalityID == "- Select -" || strMunicipalityID == "All" || strMunicipalityID == "0")
                {
                    strMunicipalityID = "";
                }

                IList<DisclosureGridModel> lstDisclosureGrid = new List<DisclosureGridModel>();
                IList<DisclosureGridModel> lstDisclosureGrid1 = new List<DisclosureGridModel>();
                DisclosureGridModel objDisclosureGrid;
                lstDisclosureGrid = objViewAllDisclosuresBroker.GetDisclosureGridDataResponse(strFilerID, strReportYearID, strOfficeTypeID, strCountyID, strMunicipalityID, strElectionTypeID, strElectionDateID, strDisclosureTypeID, strDisclosurePeriodID);

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                    foreach (var item in lstDisclosureGrid)
                    {
                        objDisclosureGrid = new DisclosureGridModel();
                        objDisclosureGrid.FilingsID = item.FilingsID;
                        objDisclosureGrid.PolCalDateID = item.PolCalDateID;
                        objDisclosureGrid.ReportYearID = item.ReportYearID;
                        objDisclosureGrid.OfficeTypeID = item.OfficeTypeID;
                        objDisclosureGrid.ElectTypeID = item.ElectTypeID;
                        objDisclosureGrid.DisclosureTypeID = item.DisclosureTypeID;
                        objDisclosureGrid.DisclosurePeriodID = item.DisclosurePeriodID;

                        objDisclosureGrid.Amended = item.Amended;
                        objDisclosureGrid.ReportYear = item.ReportYear;
                        objDisclosureGrid.OfficeType = item.OfficeType;
                        objDisclosureGrid.ElectionType = item.ElectionType;
                        objDisclosureGrid.ElectionDate = item.ElectionDate;
                        objDisclosureGrid.FilingDate = item.FilingDate;
                        objDisclosureGrid.DisclosureType = item.DisclosureType;
                        objDisclosureGrid.DateSubmitted = item.DateSubmitted;
                        objDisclosureGrid.DisclosurePeriod = item.DisclosurePeriod;
                        objDisclosureGrid.R_Status = item.R_Status;
                        objDisclosureGrid.TransNumber = item.TransNumber;
                        objDisclosureGrid.FilingAbbrev = item.FilingAbbrev;
                        objDisclosureGrid.ResigTermTypeID = item.ResigTermTypeID;
                        objDisclosureGrid.LoanLibNumber = item.LoanLibNumber;
                        objDisclosureGrid.County = item.County;
                        objDisclosureGrid.Municipality = item.Municipality;
                        objDisclosureGrid.CCDocType = item.CCDocType;                        
                        objDisclosureGrid.PCFBMonthlyFilingCheck = GetEditFlagPCFDueDate(item.ReportYearID, item.ElectTypeID, item.OfficeTypeID, item.DisclosurePeriodID, item.FilingDate, item.FilingDate, item.PolCalDateID);
                        lstDisclosureGrid1.Add(objDisclosureGrid);
                    }

                    lstDisclosureGrid = (IList<DisclosureGridModel>)lstDisclosureGrid1;
                }

                return Json(new
                {
                    aaData = lstDisclosureGrid.Select(x => new[] {
                    x.FilingsID,
                    x.PolCalDateID,
                    x.ReportYearID,
                    x.OfficeTypeID,
                    x.ElectTypeID,
                    x.DisclosureTypeID,
                    x.DisclosurePeriodID,
                    "",
                    "",
                    x.DateSubmitted,
                    x.ReportYear,
                    x.OfficeType,
                    x.ElectionType,
                    x.ElectionDate,
                    x.FilingDate,
                    x.DisclosureType,
                    x.DisclosurePeriod,
                    x.Amended,
                    x.R_Status,
                    x.TransNumber,
                    x.FilingAbbrev,
                    x.ResigTermTypeID,
                    x.LoanLibNumber,
                    x.CCDocType,
                    x.PCFBMonthlyFilingCheck
                    //x.County,
                    //x.Municipality
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetTransactionsGridData"
        // FUNCTION GETS THE DATA FOR THE TRANSACTION GRID
        public JsonResult GetTransactionsGridData(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted, String strFilingCatID, String strTransNumber, String strElectionTypeID, String strOfficeTypeID, String strElectionYearID)
        {
            try
            {

                // 6/15/2020
                // THESE THREE PARAMETERS ADDED AND SESSION VARIABLES ASSIGNED FOR NON WEEKLY
                // 24 HOUR ETC 
                //Session["ElectionTypeVal_VAD"] = strElectionTypeID;
                // condition added 4/9/2020
                //if (strElectionTypeID == "4" || strElectionTypeID == "11")
                if (strElectionTypeID == "4")
                    Session["ElectionTypeVal_VAD"] = "2";
                else
                    Session["ElectionTypeVal_VAD"] = strElectionTypeID;
                Session["OfficeTypeVal_VAD"] = strOfficeTypeID;
                Session["ElectionCycleVal_VAD"] = strElectionYearID;

                // THESE ARE NECESSARY BECAUSE GRID IS NOW DISPLAYING 'Amended' INSTEAD OF 'A'
                // AND 'Active' INSTEAD OF 'A' ETC....BUT STORED PROC IS ONLY EXPECTING 'A'
                if (!String.IsNullOrEmpty(strAmended))
                    strAmended = strAmended.Substring(0, 1);
                if (!String.IsNullOrEmpty(strR_Status))
                    strR_Status = strR_Status.Substring(0, 1);

                IList<TransactionGridModel> lstTransactionsGrid = new List<TransactionGridModel>();
                lstTransactionsGrid = objViewAllDisclosuresBroker.GetTransactionsGridDataBrokerResponse(strFilingsID, strPolCalDateID, strAmended, strR_Status, strDateSubmitted, strFilingCatID, strTransNumber, Session["COMM_TYPE_ID"].ToString());

                JsonResult result = Json(new
                {
                    aaData = lstTransactionsGrid.Select(x => new[] {
                    x.TransNumber,
                    x.FilingSchedID,
                    "",
                    "",
                    x.DateSubmitted,
                    x.TransactionDate,
                    x.TransactionType,
                    x.ContributorCode,
                    x.EntityName,
                    x.FirstName,
                    x.MiddleName,
                    x.LastName,
                    x.Country,
                    x.StreetAddress,
                    x.City,
                    x.State,
                    x.ZipCode,
                    x.Method,
                    x.CheckNum,
                    x.Amount,
                    x.OutStandingAmount,
                    x.ReceiptType,
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.ReceiptCode,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.Explanation,
                    x.Itemized,
                    //x.County,
                    //x.Municipality,
                    x.Status,
                    x.Amended,
                    x.PurposeCodeID,
                    x.TransMapping,
                    x.R_Subcontractor,
                    x.CreatedDate,
                    x.ContributorTypeID,
                    x.LoanOtherID,
                    x.ReceiptCodeID,
                    x.R_Liability,
                    x.LoanLibNumber,                    
                    x.TreasurerOccupation,
                    x.TreasurerEmployer,
                    x.TreasurerStreetAddress,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.TreasurerZipCode,
                    x.ContributionType,
                    x.ContributorName,
                    x.ContributorOccupation,
                    x.ContributorEmployer,
                    x.IEDescription,
                    x.CandidateNameBallotPropReference,
                    x.Supported,
                    x.RClaim,
                    x.InDistrict,
                    x.RMinor,
                    x.RVendor,
                    x.RLobbyist,
                    x.RContributions,
                    x.EmployerName,
                    x.EmployerOccupation,
                    x.TreaAddress
                }) 
                }, JsonRequestBehavior.AllowGet);
                result.MaxJsonLength = int.MaxValue;
                return result;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetSupportingDocumentsGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public JsonResult GetSupportingDocumentsGridData(String strTransNumber, String strFilingID)
        {
            try
            {
                IList<SupportingDocumentsGridModel> lstSupportingDocumentsGrid = new List<SupportingDocumentsGridModel>();
                lstSupportingDocumentsGrid = objViewAllDisclosuresBroker.GetSupportingDocumentsGridDataBrokerResponse(strTransNumber, strFilingID);
                // FOR UNIT TESTS, SESSION == NULL
                if (Session != null)
                    Session["SupportingDocumentsGrid"] = lstSupportingDocumentsGrid;

                return Json(new
                {
                    aaData = lstSupportingDocumentsGrid.Select(x => new[] {
                    x.SupportingDocID,
                    x.ScanDocID,
                    x.DocumentType,
                    x.FileSize,
                    x.FileType,
                    //"",
                    "",
                    "",
                    x.DateReceived,
                    x.FilingMethod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetPIDAGridData"
        // FUNCTION GETS THE DATA FOR THE PIDA GRID
        public JsonResult GetPIDAGridData(String strTransNumber)
        {
            try
            {
                IList<PIDAGridModel> lstPIDAGrid = new List<PIDAGridModel>();
                lstPIDAGrid = objViewAllDisclosuresBroker.GetPIDAGridData(strTransNumber);
                // FOR UNIT TESTS, SESSION == NULL
                if (Session != null)
                    Session["SupportingDocumentsGrid"] = lstPIDAGrid;

                return Json(new
                {
                    aaData = lstPIDAGrid.Select(x => new[] {
                    x.SupportingDocID,
                    x.ScanDocID,
                    x.CommunicationTypeID,
                    x.FileSize,
                    x.FileType,
                    "",
                    "",
                    "",
                    x.DateSubmitted,
                    x.CommunicationType,
                    x.Description,
                    x.SubmittedBy
                    })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "TransactionHasSupportingDocuments"
        // FUNCTION RETURNS TRUE IF THERE ARE DOCUMENTS ASSOCIATED WITH THE TRANSNUMBER
        public JsonResult TransactionHasSupportingDocuments(String strTransNumber)
        {
            try
            {
                IList<SupportingDocumentsGridModel> lstSupportingDocumentsGrid = new List<SupportingDocumentsGridModel>();
                lstSupportingDocumentsGrid = objViewAllDisclosuresBroker.GetSupportingDocumentsGridDataBrokerResponse(strTransNumber,"");
                if (lstSupportingDocumentsGrid.Count > 0)
                    return Json("True", JsonRequestBehavior.AllowGet);
                else
                    return Json("False", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "TransactionHasDetails"
        // FUNCTION RETURNS TRUE IF THERE ARE DOCUMENTS ASSOCIATED WITH THE TRANSNUMBER
        public JsonResult TransactionHasDetails(String strTransNumber)
        {
            try
            {
                String temp = objViewAllDisclosuresBroker.TransactionHasDetails(strTransNumber, Session["FilerID"].ToString());
                return Json(temp, JsonRequestBehavior.AllowGet);
                //return Json(objViewAllDisclosuresBroker.TransactionHasDetails(strTransNumber), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "DoesTransNumberExistInTemp"
        // FUNCTION RETURNS TRUE IF THERE ARE DOCUMENTS ASSOCIATED WITH THE TRANSNUMBER
        public JsonResult DoesTransNumberExistInTemp(String strTransNumber)
        {
            try
            {
                String temp = objViewAllDisclosuresBroker.DoesTransNumberExistInTemp(strTransNumber, Session["FilerID"].ToString());
                return Json(temp, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "InsertSupportingDocument"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET
        public JsonResult InsertSupportingDocument(
            String strTransNumber,
            String strDocTypeID,
            String strFilerID,
            String strFilingsID)
        {
            try
            {
                String strScanDocID = string.Empty;
                String strFileType = string.Empty;
                String strFileSize = string.Empty;
                String strCreatedBy = string.Empty;

                // THIS IS THE VALUE FOR UPLOAD
                String strFilingMethodID = "2";

                // FOR UNIT TESTS SESSION WILL BE NULL
                // IF IT'S NOT NULL ASSIGN THE SESSION VALUES
                if (Session != null)
                {
                    strScanDocID = Session["DocumentID"].ToString();
                    strFileType = Session["ExtensionName"].ToString().ToUpper();
                    strFileSize = Session["FileSize"].ToString();
                    strCreatedBy = Session["UserName"].ToString();

                    Boolean results = false;

                    // MAKE SURE THE DOCTYPE IS A VALID VALUE
                    results = objItemizedReportsBroker.GetDropdownValueExistsResponse("DOCUMENT_TYPE", strDocTypeID);
                    if (!results)
                    {
                        ModelState.AddModelError("DOC_TYPE", "Invalid Document Type");
                    }

                    //// MAKE SURE THAT THE TRANS_NUMBER EXISTS IN THE FILING_TRANSACTION
                    //// TABLE (STORED PROC CHECKS BOTH TEMP AND MAIN DATABASES)
                    //results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TRANSACTIONS", strTransNumber);
                    //if (!results)
                    //{
                    //    ModelState.AddModelError("FILING_TRANSACTIONS", "Invalid Trans Number");
                    //}

                    // MAKE SURE THAT THE FILE IS LESS THAN OR EQUAL TO 5MB
                    //if (!objCommonErrorsServerSide.IsFileSizeLessThan5MB(strFileSize))
                    //    ModelState.AddModelError("FileSize", "File cannot be larger than 5MB.");

                    // MAKE SURE THAT THE FILE TYPE IS ONE OF THE ACCEPTABLE TYPES
                    if (!objCommonErrorsServerSide.IsFileTypeAcceptable(strFileType))
                        ModelState.AddModelError("FileType", "File must be PDF, JPEG, JPG, or PNG.");

                }
                else
                {
                    strScanDocID = "143";
                    strFileType = "PDF";
                    strFileSize = "5";
                    strCreatedBy = "Admin";
                }

                // IF MODELSTATE IS VALID, MAKE THE CALL TO STORED PROC, OTHERWISE
                // RETURN THE ERRORS
                if (ModelState.IsValid)
                    return Json(objViewAllDisclosuresBroker.InsertSupportingDocument(strTransNumber, strFilingMethodID, strDocTypeID, strScanDocID, strFileType, strFileSize, strCreatedBy, strFilerID, strFilingsID));
                else
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "InsertSupportingDocumentPIDA"
        // FUNCTION DOES AN INSERT INTO THE SUPPORTINGDOCUMENTS TABLE
        // THIS GETS CALLED AFTER THE DOCUMENT IS UPLOADED TO CABINET
        // SCANDOCID IS THE NUMBER RETURNED FROM CABINET, FUNCTIONALITY
        // FOR PIDA INCLUDES ADDITIONAL FIELDS
        public JsonResult InsertSupportingDocumentPIDA(
            String strTransNumber,
            String strCommunicationTypeID,
            String strDateSubmitted,
            String strComments,
            String strFilerID,
            String strFilingsID)
        {
            try
            {
                String strScanDocID = string.Empty;
                String strFileType = string.Empty;
                String strFileSize = string.Empty;
                String strCreatedBy = string.Empty;

                // THIS IS THE VALUE FOR UPLOAD
                String strFilingMethodID = "2";

                // FOR UNIT TESTS SESSION WILL BE NULL
                // IF IT'S NOT NULL ASSIGN THE SESSION VALUES
                if (Session != null)
                {
                    strScanDocID = Session["DocumentID"].ToString();
                    strFileType = Session["ExtensionName"].ToString().ToUpper();
                    strFileSize = Session["FileSize"].ToString();
                    strCreatedBy = Session["UserName"].ToString();

                    Boolean results = false;

                    // MAKE SURE THE DOCTYPE IS A VALID VALUE
                    results = objItemizedReportsBroker.GetDropdownValueExistsResponse("COMMUNICATION_TYPE", strCommunicationTypeID);
                    if (!results)
                    {
                        ModelState.AddModelError("DOC_TYPE", "Invalid Document Type");
                    }

                    // MAKE SURE THAT THE TRANS_NUMBER EXISTS IN THE FILING_TRANSACTION
                    // TABLE (STORED PROC CHECKS BOTH TEMP AND MAIN DATABASES)
                    results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TRANSACTIONS", strTransNumber);
                    if (!results)
                    {
                        ModelState.AddModelError("FILING_TRANSACTIONS", "Invalid Trans Number");
                    }

                    // MAKE SURE THAT THE FILE TYPE IS ONE OF THE ACCEPTABLE TYPES
                    if (!objCommonErrorsServerSide.IsFileTypeAcceptable(strFileType))
                        ModelState.AddModelError("FileType", "File must be PDF, JPEG, JPG, or PNG.");

                }


                // IF MODELSTATE IS VALID, MAKE THE CALL TO STORED PROC, OTHERWISE
                // RETURN THE ERRORS
                if (ModelState.IsValid)
                    return Json(objViewAllDisclosuresBroker.InsertSupportingDocumentPIDA(strTransNumber, strFilingMethodID, strCommunicationTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strCreatedBy, strFilerID, strFilingsID));
                else
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "UpdateSupportingDocumentPIDA"
        // FUNCTION UPDATES THE SUPPORTINGDOCUMENTS TABLE       
        public JsonResult UpdateSupportingDocumentPIDA(
            String strSupportingDocID,
            String strCommunicationTypeID,
            String strDateSubmitted,
            String strComments)
        {
            try
            {
                String strScanDocID = string.Empty;
                String strFileType = string.Empty;
                String strFileSize = string.Empty;
                String strCreatedBy = string.Empty;

                // THIS IS THE VALUE FOR UPLOAD
                String strFilingMethodID = "2";

                // FOR UNIT TESTS SESSION WILL BE NULL
                // IF IT'S NOT NULL ASSIGN THE SESSION VALUES
                if (Session != null)
                {
                    strScanDocID = Session["DocumentID"].ToString();
                    strFileType = Session["ExtensionName"].ToString().ToUpper();
                    strFileSize = Session["FileSize"].ToString();
                    strCreatedBy = Session["UserName"].ToString();

                    Boolean results = false;

                    // MAKE SURE THE DOCTYPE IS A VALID VALUE
                    results = objItemizedReportsBroker.GetDropdownValueExistsResponse("COMMUNICATION_TYPE", strCommunicationTypeID);
                    if (!results)
                    {
                        ModelState.AddModelError("DOC_TYPE", "Invalid Document Type");
                    }

                    // MAKE SURE THAT THE FILE TYPE IS ONE OF THE ACCEPTABLE TYPES
                    if (!objCommonErrorsServerSide.IsFileTypeAcceptable(strFileType))
                        ModelState.AddModelError("FileType", "File must be PDF, JPEG, JPG, or PNG.");
                }
                else
                {
                    strScanDocID = "920";
                    strFileType = "PDF";
                    strFileSize = "5 MB";
                    strCreatedBy = "Admin";
                }


                // IF MODELSTATE IS VALID, MAKE THE CALL TO STORED PROC, OTHERWISE
                // RETURN THE ERRORS
                if (ModelState.IsValid)
                    return Json(objViewAllDisclosuresBroker.UpdateSupportingDocumentPIDA(strSupportingDocID, strFilingMethodID, strCommunicationTypeID, strScanDocID, strFileType, strFileSize, strDateSubmitted, strComments, strCreatedBy));
                else
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "DeleteDisclosure"
        // IF IN PROD, SOFT DELETES A DISCLOSURE BY UPDATING FILING AND FILING TRANSACTION TABLES
        // IF IN TEMPORARY DATABASE, DOES A HARD DELETE
        [HttpPost]
        public JsonResult DeleteDisclosure(String strFilingID, String strIsSubmitted, String strTransNumber)
        {
            try
            {
                String strUserName = string.Empty;

                // FOR UNIT TESTS SESSION IS NULL
                if (Session != null)
                    strUserName = Session["UserName"].ToString();
                else
                    strUserName = "Admin";

                var returnText = objViewAllDisclosuresBroker.DeleteDisclosure(strFilingID, strIsSubmitted, strUserName, strTransNumber);
                return Json(returnText, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "DeleteSupportingDocument"
        // SOFT DELETES A SUPPORTING DOCUMENT BY UPDATING R_STATUS
        [HttpPost]
        public JsonResult DeleteSupportingDocument(String strSupportingDocumentID)
        {
            try
            {
                String strUserName = string.Empty;
                // FOR UNIT TESTS SESSION WILL BE NULL
                if (Session != null)
                    strUserName = Session["UserName"].ToString();
                else
                    strUserName = "Admin";

                var result = objViewAllDisclosuresBroker.DeleteSupportingDocument(strSupportingDocumentID, strUserName);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetTransactionDetailsGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public JsonResult GetTransactionDetailsGridData(String strTransNumber, String strSubmitDate, String strFilerID)
        {
            try
            {
                IList<TransactionDetailsGridModel> lstTransactionDetailsGrid = new List<TransactionDetailsGridModel>();
                lstTransactionDetailsGrid = objViewAllDisclosuresBroker.mapGetTransactionDetailsGridDataBrokerResponse(strTransNumber, strSubmitDate, strFilerID);

                return Json(new
                {
                    aaData = lstTransactionDetailsGrid.Select(x => new[] {
                    x.FilingEntityID,
                    x.CreatedDate,
                    "",
                    x.FilingEntityName,
                    x.FilingEntityFirstName,
                    x.FilingEntityMiddleName,
                    x.FilingEntityLastName,
                    x.FilingEntityCountry,
                    x.FilingEntityStreetAddress,
                    x.FilingEntityCity,
                    x.FilingEntityState,
                    x.FilingEntityZip,
                    x.PurposeCode,
                    x.PayDate,
                    x.Amount,
                    x.Explanation,
                    x.Itemized,
                    x.RContributions,
                    x.TreasurerEmployer,
                    x.TreasurerOccupation,
                    x.TreaAddress
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetCampaignMaterialsGridData"
        // FUNCTION GETS THE DATA FOR THE SUPPORTING DOCUMENTS GRID
        public JsonResult GetCampaignMaterialsGridData(String strFilingsID, String strAmended)
        {
            try
            {
                IList<CampaignMaterialsGridModel> lstCampaignMaterialsGrid = new List<CampaignMaterialsGridModel>();
                lstCampaignMaterialsGrid = objViewAllDisclosuresBroker.GetCampaignMaterialsGridData(strFilingsID, strAmended);

                // CREATE AN OBJECT AND LIST OF TYPE NonItemCampaignMaterialDataModel
                // AS THIS IS WHAT THE SESSION OBJECT REQUIRES
                // LOOP THROUGH THE lstCampaignMaterialsGrid AND MAP THE ITEMS
                // AND THEN ASSIGN THE SESSION
                List<NonItemCampaignMaterialDataModel> sessionList = new List<NonItemCampaignMaterialDataModel>();
                NonItemCampaignMaterialDataModel sessionObject;
                foreach (var item in lstCampaignMaterialsGrid)
                {
                    if (item != null)
                    {
                        sessionObject = new NonItemCampaignMaterialDataModel();
                        sessionObject.CampaignMaterialId = item.CampaignMaterialID;
                        sessionObject.DateSubmitted = item.DateSubmitted;
                        sessionObject.FilingMethodId = item.FilingMethodID;
                        sessionObject.FilingMethodDesc = item.FilingMethodDesc;
                        sessionObject.CampaignMaterialDesc = item.CampaignMaterialDesc;
                        sessionObject.CampMatrFileSize = item.FileSize;
                        sessionObject.CampMatrFileType = item.FileType;
                        sessionObject.ScanDocId = item.ScanDocID;
                        sessionObject.RCampMatr = item.CampaignMaterialAvailable;
                        sessionObject.CreatedDate = item.CreatedDate;
                        sessionObject.CamapaignMaterialCount = lstCampaignMaterialsGrid.Count.ToString();

                        sessionList.Add(sessionObject);
                    }
                }

                if (Session != null)
                    // SET THE SESSION VARIABLE REQUIRED BY
                    Session["lstCampaignMaterialModel"] = sessionList;

                return Json(new
                {
                    aaData = lstCampaignMaterialsGrid.Select(x => new[] {
                    x.CampaignMaterialID,
                    x.FilingMethodID,
                    x.ScanDocID,
                    x.FileType,
                    x.FileSize,
                    "",
                    "",
                    x.DateSubmitted,
                    x.CampaignMaterialDesc,
                    "",
                    x.FilingMethodDesc,
                    x.CampaignMaterialAvailable,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "SetSessionVariables"
        public JsonResult SetSessionVariables(String strDocumentType, String strElectionYear, String strFilingAbbrev)
        {
            try
            {
                Session["DocumentType"] = strDocumentType;
                Session["ElectionYear"] = strElectionYear;
                Session["FilingAbbrev"] = strFilingAbbrev;
                return Json("True");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                return Json("False");
            }            
        }
        #endregion

        #region "SetSessionVariablesPIDA"
        public JsonResult SetSessionVariablesPIDA(String strCommunicationType, String strElectionYear, String strFilingAbbrev, String strScanDocID, String strExtensionName, String strFileSize)
        {
            try
            {
                Session["CommunicationType"] = strCommunicationType;
                Session["ElectionYear"] = strElectionYear;
                Session["FilingAbbrev"] = strFilingAbbrev;

                // THESE SESSION VARIABLES ARE USED BY THE UPDATEPIDADOCUMENT FUNCTION FOR BOTH
                // INSERT AND UPDATE PIDA DOCUMENTS. HOWEVER, WHEN WE ARE UPDATING, WE DON'T WANT TO 
                // REASSIGN THEM IF THE USER HAS NOT CHANGED THE FILE. IN THIS CASE, THESE VALUES WILL BE BLANK
                Session["DocumentID"] = strScanDocID;
                Session["ExtensionName"] = strExtensionName;
                Session["FileSize"] = strFileSize;

                return Json("True");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                return Json("False");
            }            
        }
        #endregion

        #region "GetFilingDateIEWeekly"
        public JsonResult GetFilingDateIEWeekly(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strElectionTypeId, String strFilingCatId, String strElectionDateId, String strMunicipalityID)
        {
            try
            {
                if (strMunicipalityID == "- Select -" || strMunicipalityID == null)
                    strMunicipalityID = "";

                String strFilingType = String.Empty;

                Session["ElectionYearId"] = strElectionYearId;
                if (strOfficeTypeId == "4")
                    Session["OfficeTypeId"] = "1"; // STATE/LOCAL USING 1 IN FILE A DICLOSURE PAGE.
                else
                    Session["OfficeTypeId"] = strOfficeTypeId;
                Session["MunicipalityID"] = "";

                if (strFilerId != null)
                {
                    Session["FilerIdIEWeekly"] = strFilerId;
                }
                else
                {
                    if (Session["FilerIdIEWeekly"] != null)
                        strFilerId = Session["FilerIdIEWeekly"].ToString();
                }                
                
                Session["ElectionTypeId"] = strElectionTypeId;
                Session["FilingType"] = strFilingType;
                Session["FilingCatId"] = strFilingCatId;
                Session["ElectionDateId"] = strElectionDateId;
                Session["ElectionCycleVal_VAD"] = strElectionYearId;
                // condition added 4/9/2020
                //if (strElectionTypeId == "4" || strElectionTypeId == "11")
                if (strElectionTypeId == "4")
                    Session["ElectionTypeVal_VAD"] = "2";
                else
                    Session["ElectionTypeVal_VAD"] = strElectionTypeId;
                Session["OfficeTypeVal_VAD"] = strOfficeTypeId;

                // START - CODE - START
                // ADDED THIS FOR OFF CYCLE THESE SESSIONS REQUIRED.
                // ADDED SB - 02.05.2021
                Session["FilerIdOffCycle"] = Session["FilerId"].ToString();
                Session["DisclosureType"] = strFilingCatId;
                // END - CODE - END

                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                lstFilingDatesOffCycleModel = objItemizedReportsBroker.GetFilingDateIEWeeklyeDataResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId, strMunicipalityID);

                for (int i = 0; i < lstFilingDatesOffCycleModel.Count; i++)
                {
                    if (lstFilingDatesOffCycleModel[i] != null)
                    {
                        lstFilingDatesOffCycleModel[i].FilingDate = lstFilingDatesOffCycleModel[i].FilingDate.Trim();
                    }
                }

                // Bind Filing Date for Off Cycle.
                return Json(lstFilingDatesOffCycleModel, JsonRequestBehavior.AllowGet);
                //return Json(new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetFilingDateIEWeeklyForList"
        public JsonResult GetFilingDateIEWeeklyForList(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strElectionTypeId, String strFilingCatId, String strElectionDateId, String strMunicipalityID)
        {
            
            try
            {
                if (strMunicipalityID == "- Select -" || strMunicipalityID == null)
                    strMunicipalityID = "";

                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();

                lstFilingDatesOffCycleModel = objItemizedReportsBroker.GetFilingDateIEWeeklyeDataResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, "", strFilingCatId, strElectionDateId, strMunicipalityID);
                  
                return Json(new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetFilingDatesOffCycle"
        public JsonResult GetFilingDatesOffCycle(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strFilingCatId)
        {
            try
            {
                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                lstFilingDatesOffCycleModel = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(strElectionYearId, strOfficeTypeId, strFilerId, strFilingCatId);
                return Json(new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region GetMunicipality
        /// <summary>
        /// GetMunicipality
        /// </summary>
        /// <param name="lstUCCounty"></param>
        /// <returns></returns>
        public JsonResult GetMunicipalityForOffices(String lstUCCounty, String lstOfficeType)
        {
            try
            {
                if (lstUCCounty == "- Select -" || lstUCCounty == "All" || lstUCCounty == "0")
                {
                    lstUCCounty = "";
                }
                IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
                //lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(lstUCCounty);
                // LOADIG MUNICIPALITY BASED ON COUNTY ID AND OFFICE TYPE ID - 06/03/2020.
                lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityByOfficeType(lstUCCounty, lstOfficeType);
                // Bind Municipality
                return Json(new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetMunicipality   


        #region "GetDisclosurePeriodCampMaterial"
        public JsonResult GetDisclosurePeriodCampMaterial(String strElectionTypeID)
        {
            try
            {
                if (strElectionTypeID == "- Select -")
                    strElectionTypeID = "";
                if (strElectionTypeID == null)
                    strElectionTypeID = "";
                string ElectionYearID_PCFB = string.Empty;
                if (Session["Elect_Year_Id_VAD_PCFB"] != null)
                {
                    ElectionYearID_PCFB = Session["Elect_Year_Id_VAD_PCFB"].ToString();
                }

                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(strElectionTypeID, Session["FilerID"].ToString(), "");

                if (strElectionTypeID == "2")
                    lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => x.FilingTypeId.ToString() == "3").ToList();
                if (strElectionTypeID == "3")
                    lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => x.FilingTypeId.ToString() == "6").ToList();
                if (strElectionTypeID == "1")
                    lstDisclosurePreiodModel = lstDisclosurePreiodModel.Where(x => x.FilingTypeId.ToString() == "9").ToList();

                Session["DisclosurePeriods"] = lstDisclosurePreiodModel;

                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion


        #region "Cabinet Code"

        #region UploadSupportingDocument
        /// <summary>
        /// UploadCampaignMaterialData
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadSupportingDocument(HttpPostedFileBase data)
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
                        var mStreamer = new MemoryStream();
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

                //String strFilingTypeAbbrev = lstDisclosurePreiodModel.Where(x => x.FilingDesc == Session["DisclosurePeriodDesc"].ToString()).Select(x => x.FilingAbbrev).FirstOrDefault().ToString();

                //Get File Extension
                FileInfo ObjfileInfo = new FileInfo(Session["FileName"].ToString());
                //String getExtension = ObjfileInfo.Extension.Substring(1).ToString().ToUpper();
                String getExtension = ObjfileInfo.Extension.Substring(1).ToString().ToLower();
                Session["ExtensionName"] = getExtension;

                String filerName = Session["FilerId"].ToString();  //"A12345"; // Get Filer Id.
                String fileName = Session["fileName"].ToString();
                //fileName = Session["ElectionYear"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + Session["ExtensionName"].ToString();
                fileName = Session["DocumentType"].ToString() + "_" + Session["ElectionYear"].ToString() + "_" + Session["FilingAbbrev"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + Session["ExtensionName"].ToString();


                objUploadFileNTDriveModel.CampMatrFileName = fileName;
                objUploadFileNTDriveModel.FilerIdNTDrive = Session["FilerId"].ToString();
                objUploadFileNTDriveModel.ElectionYearNTDrive = Session["ElectionYear"].ToString();
                //objUploadFileNTDriveModel.DisclosurePeriodNTDrive = Session["DisclosurePeriodDesc"].ToString();

                //Boolean returnValue = objItemizedReportsBroker.UploadFileInNetworkDriveResponse(objUploadFileNTDriveModel);

                objCampMatrDocumentIdModel.strCampMatrFileName = fileName;
                objCampMatrDocumentIdModel.strCampMatrFilerId = filerName;
                //Folder Creation Path
                objCampMatrDocumentIdModel.FolderFilerId = Session["FilerId"].ToString();
                objCampMatrDocumentIdModel.FolderElectionYear = Session["ElectionYear"].ToString();
                objCampMatrDocumentIdModel.FolderDisclosurePeriod = "";// Session["DisclosurePeriodDesc"].ToString();
                objCampMatrDocumentIdModel.FileExtension = Session["ExtensionName"].ToString().ToUpper();

                objCampMatrDocumentIdModel.PageName = "SupportingDocuments";

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UploadCampaignMaterialData

        #region DownloadSupportingDocument
        /// <summary>
        /// DownloadCampaignMaterial
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        //public JsonResult DownloadSupportingDocument(String documentID)
        public void DownloadSupportingDocument(String documentID)
        {
            try
            {
                CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
                CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();

                String fileName = String.Empty;

                IList<SupportingDocumentsGridModel> supportingDocumentsList = new List<SupportingDocumentsGridModel>();
                supportingDocumentsList = (IList<SupportingDocumentsGridModel>)Session["SupportingDocumentsGrid"];

                String strFileType = supportingDocumentsList.Where(x => x.ScanDocID == documentID.ToString()).Select(x => x.FileType).FirstOrDefault().ToString();


                objCabinetReturnValModel = objItemizedReportsBroker.GetTokenIDBroker(strFileType, "SupportingDocuments");

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
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DownloadCampaignMaterial

        #region "UploadPIDADocument"
        /// <summary>
        /// UploadCampaignMaterialData
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadPIDADocument(HttpPostedFileBase data)
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
                        var mStreamer = new MemoryStream();
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

                //String strFilingTypeAbbrev = lstDisclosurePreiodModel.Where(x => x.FilingDesc == Session["DisclosurePeriodDesc"].ToString()).Select(x => x.FilingAbbrev).FirstOrDefault().ToString();

                //Get File Extension
                FileInfo ObjfileInfo = new FileInfo(Session["FileName"].ToString());
                //String getExtension = ObjfileInfo.Extension.Substring(1).ToString().ToUpper();
                String getExtension = ObjfileInfo.Extension.Substring(1).ToString().ToLower();
                Session["ExtensionName"] = getExtension;

                String filerName = Session["FilerId"].ToString();  //"A12345"; // Get Filer Id.
                String fileName = Session["fileName"].ToString();
                //fileName = Session["ElectionYear"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + Session["ExtensionName"].ToString();
                fileName = filerName + "_" + Session["CommunicationType"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + Session["ExtensionName"].ToString();


                objUploadFileNTDriveModel.CampMatrFileName = fileName;
                objUploadFileNTDriveModel.FilerIdNTDrive = Session["FilerId"].ToString();
                objUploadFileNTDriveModel.ElectionYearNTDrive = Session["ElectionYear"].ToString();
                //objUploadFileNTDriveModel.DisclosurePeriodNTDrive = Session["DisclosurePeriodDesc"].ToString();

                //Boolean returnValue = objItemizedReportsBroker.UploadFileInNetworkDriveResponse(objUploadFileNTDriveModel);

                objCampMatrDocumentIdModel.strCampMatrFileName = fileName;
                objCampMatrDocumentIdModel.strCampMatrFilerId = filerName;
                //Folder Creation Path
                objCampMatrDocumentIdModel.FolderFilerId = Session["FilerId"].ToString();
                objCampMatrDocumentIdModel.FolderElectionYear = Session["ElectionYear"].ToString();
                objCampMatrDocumentIdModel.FolderDisclosurePeriod = "";// Session["DisclosurePeriodDesc"].ToString();
                objCampMatrDocumentIdModel.FileExtension = Session["ExtensionName"].ToString().ToUpper();

                objCampMatrDocumentIdModel.PageName = "SupportingDocuments";

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UploadCampaignMaterialData

        #region DownloadPIDADocument
        /// <summary>
        /// DownloadCampaignMaterial
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        //public JsonResult DownloadPIDADocument(String documentID)
        public void DownloadPIDADocument(String documentID)
        {
            CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
            CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();

            String fileName = String.Empty;

            IList<PIDAGridModel> supportingDocumentsList = new List<PIDAGridModel>();
            supportingDocumentsList = (IList<PIDAGridModel>)Session["SupportingDocumentsGrid"];

            String strFileType = supportingDocumentsList.Where(x => x.ScanDocID == documentID.ToString()).Select(x => x.FileType).FirstOrDefault().ToString();


            objCabinetReturnValModel = objItemizedReportsBroker.GetTokenIDBroker(strFileType, "SupportingDocuments");

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
        }
        #endregion

        #region "GetFilingCutoffData"
        public JsonResult GetFilingCutoffData(String strReportYearID, String strElectionTypeID, String strOfficeTypeID, String strDisclosurePeriodID, String lstElectionDateId, String strDisclosureTypeID)
        {
            try
            {
                String strFilingDateId = String.Empty;
                String strCutOffDateId = String.Empty;

                if (strOfficeTypeID == "1")
                    strOfficeTypeID = "4";

                Session["ElectionCycleVal_VAD"] = strReportYearID;
                Session["OfficeTypeVal_VAD"] = strOfficeTypeID;
                // condition added 4/9/2020
                //if (strElectionTypeID == "4" || strElectionTypeID == "11")
                if (strElectionTypeID == "4")
                    Session["ElectionTypeVal_VAD"] = "2";
                else
                    Session["ElectionTypeVal_VAD"] = strElectionTypeID;



                if (strDisclosureTypeID != "4" && strDisclosureTypeID != "8" && strDisclosureTypeID != "11" && strDisclosureTypeID != "13")
                {
                    if (strDisclosurePeriodID == "1") // 32 Day Pre-Primary
                    {
                        strFilingDateId = "59";
                        strCutOffDateId = "60";
                    }
                    else if (strDisclosurePeriodID == "2") // 11 Day Pre-Primary
                    {
                        strFilingDateId = "61";
                        strCutOffDateId = "62";
                    }
                    else if (strDisclosurePeriodID == "3") // 10 Day Post-Primary
                    {
                        strFilingDateId = "65";
                        strCutOffDateId = "66";
                    }
                    else if (strDisclosurePeriodID == "4") // 32 Day Pre-General
                    {
                        strFilingDateId = "104";
                        strCutOffDateId = "105";
                    }
                    else if (strDisclosurePeriodID == "5") // 11 Day Pre-General
                    {
                        strFilingDateId = "106";
                        strCutOffDateId = "107";
                    }
                    else if (strDisclosurePeriodID == "6") // 27 Day Post-General
                    {
                        strFilingDateId = "108";
                        strCutOffDateId = "109";
                    }
                    else if (strDisclosurePeriodID == "7") // 32 Day Pre-Speceial
                    {
                        strFilingDateId = "122";
                        strCutOffDateId = "123";
                    }
                    else if (strDisclosurePeriodID == "8") // 11 Day Pre-Special
                    {
                        strFilingDateId = "124";
                        strCutOffDateId = "125";
                    }
                    else if (strDisclosurePeriodID == "9") // 27 Day Post-Special
                    {
                        strFilingDateId = "126";
                        strCutOffDateId = "127";
                    }
                    else if (strDisclosurePeriodID == "10") // January Periodic
                    {
                        strFilingDateId = "69";
                        strCutOffDateId = "70";
                    }
                    else if (strDisclosurePeriodID == "11") // July Periodic
                    {
                        strFilingDateId = "71";
                        strCutOffDateId = "72";
                    }
                    else if (strDisclosurePeriodID == "12") // Off Cycle
                    {
                        //strFilingDateId = "108";
                        //strCuttOffDateId = "109";
                    }
                    //else if (strDisclosurePeriodID == "14") // January
                    //{
                    //    strFilingDateId = "144";
                    //    strCutOffDateId = "145";
                    //}
                    //else if (strDisclosurePeriodID == "15") // February
                    //{
                    //    strFilingDateId = "146";
                    //    strCutOffDateId = "147";
                    //}
                    //else if (strDisclosurePeriodID == "16") // March
                    //{
                    //    strFilingDateId = "148";
                    //    strCutOffDateId = "149";
                    //}
                    //else if (strDisclosurePeriodID == "17") // April
                    //{
                    //    strFilingDateId = "150";
                    //    strCutOffDateId = "151";
                    //}
                    //else if (strDisclosurePeriodID == "18") // July
                    //{
                    //    strFilingDateId = "152";
                    //    strCutOffDateId = "153";
                    //}
                    //else if (strDisclosurePeriodID == "19") // December
                    //{
                    //    strFilingDateId = "142";
                    //    strCutOffDateId = "143";
                    //}

                    IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();
                    lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateDataResponse(strReportYearID, strElectionTypeID, strOfficeTypeID, strFilingDateId, strCutOffDateId, lstElectionDateId);
                    return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    if (strDisclosureTypeID == "4")
                    {
                        strFilingDateId = "63";
                        strCutOffDateId = "64";
                    }
                    else if (strDisclosureTypeID == "8" || strDisclosureTypeID == "11" || strDisclosureTypeID == "13")
                    {
                        strFilingDateId = "67";
                        strCutOffDateId = "68";
                    }

                    IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

                    lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateDataResponse(strReportYearID, strElectionTypeID, strOfficeTypeID, strFilingDateId, strCutOffDateId, lstElectionDateId);

                    return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #endregion

        #region "GetCountyData"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        /// <summary>
        /// GetCountyDataForFilings
        /// </summary>
        /// <param name="elect_Year_ID"></param>
        /// <param name="filer_ID"></param>
        /// <returns></returns>
        public JsonResult GetCountyDataForFilings(string elect_Year_ID, string filer_ID)
        {
            try
            {
                // DropDown County Data
                IList<County> listCounty = new List<County>();
                listCounty = objItemizedReportsBroker.GetCountyForFilingsBroker(elect_Year_ID, filer_ID).ToList();
                return Json(new SelectList(listCounty, "CountyID", "CountyBoard"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

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
        /// ViewAllDisclosuresSearchHelp
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAllDisclosuresSearchHelp()
        {
            return View("ViewAllDisclosuresSearchHelp");
        }
        #endregion Filer Help    


        #region GetFullPeriodReportPDF
        /// <summary>
        /// GetFullPeriodReportPDF
        /// </summary>
        public void GetFullPeriodReportPDF()
        {
            EFSPDFRequestModel objEFSPDFRequestModel = new EFSPDFRequestModel();
            EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();

            objEFSPDFRequestModel.ReportName = Session["ReportName_FP"].ToString();
            objEFSPDFRequestModel.FilerId = Session["FilerID_FP"].ToString();
            objEFSPDFRequestModel.ElectionYearId = Session["ElectionYearID_FP"].ToString();
            objEFSPDFRequestModel.OfficeTypeId = Session["OfficeTypeID_FP"].ToString();
            objEFSPDFRequestModel.FilingTypeId = Session["FilingTypeID_FP"].ToString();
            objEFSPDFRequestModel.FilingDate = Session["FilingDate_FP"].ToString();
            objEFSPDFRequestModel.ElectionTypeID = Session["ElectionTypeID_FP"].ToString();
            objEFSPDFRequestModel.ElectionDateID = Session["ElectionDateID_FP"].ToString();
            objEFSPDFRequestModel.SubmitDate = Session["SubmitDate_FP"].ToString();
            //objEFSPDFRequestModel.ComplianceType = null;
            //objEFSPDFRequestModel.ComplianceTypeDesc = null;
            //objEFSPDFRequestModel.CommTypeId = null;
            //objEFSPDFRequestModel.FilerStatus = null;
            //objEFSPDFRequestModel.FilerTypeId = null;
            //objEFSPDFRequestModel.MunicipalityId = null;
            //objEFSPDFRequestModel.BestContact = null;
            //objEFSPDFRequestModel.AddressType = null;
            //objEFSPDFRequestModel.CandCommTreasurer = null;
            //objEFSPDFRequestModel.CommitteeTypeDesc = null;
            //objEFSPDFRequestModel.CountyDesc = null;
            //objEFSPDFRequestModel.FilerTypeDesc = null;
            //objEFSPDFRequestModel.MunicipalityDesc = null;
            //objEFSPDFRequestModel.TreasPersonId = null;


            //string author = "Satheesh Basireddy";
            //// Convert a C# string to a byte array  
            //objCandCommPDFResponseModel.fileByte = Encoding.ASCII.GetBytes(author);

            //// CALL PDF METHOD TO GET PDFS
            objEFSPDFResponseModel = objItemizedReportsBroker.GetEFSPDFBytesResponse(objEFSPDFRequestModel);

            //Open PDF using Bytes
            if (objEFSPDFResponseModel.fileByte != null)
            {
                // GENERATE PDF.
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", objEFSPDFResponseModel.fileByte.Length.ToString());
                Response.BinaryWrite(objEFSPDFResponseModel.fileByte);
            }
            else
            {
                //Open PDF using File URL
                Process.Start(objEFSPDFResponseModel.fileURL);
            }
        }
        #endregion GetFullPeriodReportPDF

        #region "SetSessionsForFullPeriod"

        //report with 2 subreports: EFS_VADfp_Report.rdl has two SPs 
        //one to get the opening bal SP_S_Get_Opening_Balance 
        //and the one for the main grids, SP_S_Filing_Transactions_Data_Reports_VAD 
        //and the grids could have subreports reports coming in, 
        //EFS_fullperParSubconAttribDetail_subReport.rdl which uses 
        //SP_S_Filing_Transactions_Data_Reports_VAD 
        //or EFS_fullperCCpaymentReimbDetail_subReport.rdl which uses 
        //SP_S_Filing_Transactions_Data_Reports_FIDAS
        public JsonResult SetSessionsForFullPeriod(String strFilerID,
                                             String strReportName,
                                             String strElectionYearID,
                                             String strOfficeTypeID,
                                             String strFilingTypeID,
                                             String strFilingDate,
                                             String strElectionTypeID,
                                             String strElectionDateID,
                                             String strSubmitDate)
        {
            if (strOfficeTypeID == "4") strOfficeTypeID = "1";

            Session["FilerID_FP"] = strFilerID;
            Session["ReportName_FP"] = strReportName;
            Session["ElectionYearID_FP"] = strElectionYearID;
            Session["OfficeTypeID_FP"] = strOfficeTypeID;
            Session["FilingTypeID_FP"] = strFilingTypeID;
            Session["FilingDate_FP"] = strFilingDate;
            Session["ElectionTypeID_FP"] = strElectionTypeID;
            Session["ElectionDateID_FP"] = strElectionDateID;
            Session["SubmitDate_FP"] = strSubmitDate;
            return Json("", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region "SetSessionFilerID_NotForFP"
        public JsonResult SetSessionFilerID_NotForFP(String strFilerID)
        {
            Session["FilerID_NotForFP"] = strFilerID;

            return Json("", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region "FilerReportPDF"
        public void FilerReportPDF()
        {
            EFSPDFRequestModel objEFSPDFRequestModel = new EFSPDFRequestModel();
            EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();

            // procedure is SP_S_F_ViewAllDisclosures_rpt 
            // and SP_S_F_GetCandidateOrCommitteeNameForFilerID_rpt
            objEFSPDFRequestModel.ReportName = "DisclosureRepInventory_Report";
            objEFSPDFRequestModel.FilerId = Session["FilerID_NotForFP"].ToString();

            //string author = "Satheesh Basireddy";
            //// Convert a C# string to a byte array  
            //objCandCommPDFResponseModel.fileByte = Encoding.ASCII.GetBytes(author);

            //// CALL PDF METHOD TO GET PDFS
            objEFSPDFResponseModel = objItemizedReportsBroker.GetEFSPDFBytesResponse(objEFSPDFRequestModel);

            //Open PDF using Bytes
            if (objEFSPDFResponseModel.fileByte != null)
            {
                // GENERATE PDF.
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", objEFSPDFResponseModel.fileByte.Length.ToString());
                Response.BinaryWrite(objEFSPDFResponseModel.fileByte);
            }
            else
            {
                //Open PDF using File URL
                Process.Start(objEFSPDFResponseModel.fileURL);
            }
        }
        #endregion


        #region "BalanceReportPDF"
        public void BalanceReportPDF()
        {
            EFSPDFRequestModel objEFSPDFRequestModel = new EFSPDFRequestModel();
            EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();

            // procedure is SP_S_F_BALANCE_REPORT
            objEFSPDFRequestModel.ReportName = "FidasBalances_Report";            
            objEFSPDFRequestModel.FilerId = Session["FilerID_NotForFP"].ToString();

            //string author = "Satheesh Basireddy";
            //// Convert a C# string to a byte array  
            //objCandCommPDFResponseModel.fileByte = Encoding.ASCII.GetBytes(author);

            //// CALL PDF METHOD TO GET PDFS
            objEFSPDFResponseModel = objItemizedReportsBroker.GetEFSPDFBytesResponse(objEFSPDFRequestModel);

            //Open PDF using Bytes
            if (objEFSPDFResponseModel.fileByte != null)
            {
                // GENERATE PDF.
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", objEFSPDFResponseModel.fileByte.Length.ToString());
                Response.BinaryWrite(objEFSPDFResponseModel.fileByte);
            }
            else
            {
                //Open PDF using File URL
                Process.Start(objEFSPDFResponseModel.fileURL);
            }
        }
        #endregion

        /// <summary>
        /// Set Global Session
        /// </summary>
        /// <param name="strReportYearID"></param>
        /// <param name="strElectionTypeID"></param>
        /// <param name="strOfficeTypeID"></param>
        /// <returns></returns>
        public JsonResult SetSession(String strReportYearID, String strElectionTypeID, String strOfficeTypeID)
        {
            try
            {
                //if (strElectionTypeID == "4" || strElectionTypeID == "11")
                if (strElectionTypeID == "4")
                    Session["ElectionTypeVal"] = "2";
                else
                    Session["ElectionTypeVal"] = strElectionTypeID;
                Session["OfficeTypeVal"] = strOfficeTypeID;
                Session["ElectionCycleVal"] = strReportYearID;
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetEditFlagPCFDueDate
        /// </summary>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        public String GetEditFlagPCFDueDate(String lstElectYearId,
            String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId,
            String lstFilingDate, String txtFilingDate, String electionDateId)
        {
            try
            {
                String strLabelId = String.Empty;
                IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();

                if (lstFilingTypeId == "1") // 32 Day Pre-Primary
                {
                    strLabelId = "59";
                }
                else if (lstFilingTypeId == "2") // 11 Day Pre-Primary
                {
                    strLabelId = "61";
                }
                else if (lstFilingTypeId == "3") // 10 Day Post-Primary
                {
                    strLabelId = "65";
                }
                else if (lstFilingTypeId == "4") // 32 Day Pre-General
                {
                    strLabelId = "104";
                }
                else if (lstFilingTypeId == "5") // 11 Day Pre-General
                {
                    strLabelId = "106";
                }
                else if (lstFilingTypeId == "6") // 27 Day Post-General
                {
                    strLabelId = "108";
                }
                else if (lstFilingTypeId == "7") // 32 Day Pre-Speceial
                {
                    strLabelId = "122";
                }
                else if (lstFilingTypeId == "8") // 11 Day Pre-Special
                {
                    strLabelId = "124";
                }
                else if (lstFilingTypeId == "9") // 27 Day Post-Special
                {
                    strLabelId = "126";
                }
                else if (lstFilingTypeId == "10") // January Periodic
                {
                    strLabelId = "69";
                }
                else if (lstFilingTypeId == "11") // July Periodic
                {
                    strLabelId = "71";
                }
                else if (lstFilingTypeId == "12") // Off Cycle
                {
                    //strFilingDateId = "108";
                }
                else if (lstFilingTypeId == "13") // March Periodic
                {
                    strLabelId = "140";
                }
                else if (lstFilingTypeId == "14") // January
                {
                    strLabelId = "144";
                }
                else if (lstFilingTypeId == "15") // February
                {
                    strLabelId = "146";
                }
                else if (lstFilingTypeId == "16") // March
                {
                    strLabelId = "148";
                }
                else if (lstFilingTypeId == "17") // April
                {
                    strLabelId = "150";
                }
                else if (lstFilingTypeId == "18") // July
                {
                    strLabelId = "152";
                }
                else if (lstFilingTypeId == "19") // December
                {
                    strLabelId = "142";
                }

                if (lstOfficeTypeId == "4") lstOfficeTypeId = "1";



                objFilingTransDataModel.FilerId = Session["FilerID"].ToString();
                objFilingTransDataModel.ReportYearId = lstElectYearId;
                objFilingTransDataModel.ElectionType = strElectionTypeId;
                objFilingTransDataModel.OfficeTypeId = lstOfficeTypeId;
                objFilingTransDataModel.DisclosurePeriod = lstFilingTypeId;
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                objFilingTransDataModel.ElectionDateId = electionDateId;
                objFilingTransDataModel.Created_By = Session["UserName"].ToString();
                objFilingTransDataModel.CommTypeId = Session["COMM_TYPE_ID"].ToString();
                objFilingTransDataModel.LabelId = strLabelId;

                lstGetEditFlagDataModel = objItemizedReportsBroker.GetEditFlagPCFDueDateBroker(objFilingTransDataModel);
                return lstGetEditFlagDataModel[0].Is_Edit.ToString();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetEditFlagPCFDueDate", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
    }

}