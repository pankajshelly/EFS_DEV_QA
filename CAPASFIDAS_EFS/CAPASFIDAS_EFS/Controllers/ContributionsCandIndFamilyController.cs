// ============================================================
// AUTHOR       : SATHEESH BASIREDDY
// CREATE DATE  : 08/10/2017
// PURPOSE      : CONTRIBUTIONS MONETARY SCHEDULE A,B,C, AND SCHEDULE O (PARTNERSHIP)
// SPECIAL NOTES: 
// ============================================================
// Change History: 
//
// ============================================================

#region Namespaces
using Broker;
using CAPASFIDAS_EFS.CommonErrors;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    /// <summary>
    /// Test Controller - Pankaj Agarwal
    /// </summary>
    public class ContributionsCandIndFamilyController : Controller
    {
        #region Global Declaration
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        IList<ImportErrorMessageModel> lstImportErrorMessageModel = new List<ImportErrorMessageModel>();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Declaration

        #region ContributionsCandIndFamily
        // GET: /ContributionsCandIndFamily/
        /// <summary>
        /// ContributionsCandIndFamily
        /// </summary>
        /// <returns></returns>
        public ActionResult ContributionsCandIndFamily(FormCollection collections, string Command)
        {
            try
            {
                // COMMENTED WHILE TESTING UAT DATABASE HISTORICAL DATA.
                // UN-COMMENT IF ITS COMMENTED WHILE WORKING ON DEV DATBASE.
                if (Session["SAMLResponse"] == null)
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                else
                {                
                    GetDefaultLookUpsValues();

                    if (Command == "btnCSVAsEntered")
                    {
                        IList<ImportErrorMessageModel> lstImportErrorMessageModel = new List<ImportErrorMessageModel>();
                        lstImportErrorMessageModel = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
                        btnExportCSV_Click(lstImportErrorMessageModel, "Validation_Errors");
                    }
                    if (Command == "btnDownloadHelpDocumentPDF")
                    {
                        DowloadHelpDocumentPDFFile();
                    }
                    // DAVE ADDED 4/9/2024
                    if (Command == "btnDownloadPCFHelpDocumentPDF")
                    {
                        DownloadPCFHelpDocumentPDF();
                    }
                    // DAVE ADDED 4/9/2024
                    if (Command == "btnDownloadSchedAImportTemplate")
                    {
                        DownloadSchedAImportTemplate();
                    }
                    // DAVE ADDED 4/9/2024
                    if (Command == "btnDownloadSchedAImportPCFTemplate")
                    {
                        DownloadSchedAImportPCFTemplate();
                    }
                }

                Session["Import_PCF_ShowWarning"] = "N";

                return View("ContributionsCandIndFamily");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion  ContributionsCandIndFamily                               

        #region AutoCompleteFirstName
        /// <summary>
        /// AutoCompleteFirstName
        /// </summary>
        /// <param name="term"></param>
        /// <param name="txtFilerId"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteFirstName(String term)
        {
            try
            {
                String strFilerId = string.Empty;
                strFilerId = Session["FilerId"].ToString();

                String strFLName = "FName";

                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                List<String> FirstNames;
                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);

                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;
                FirstNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();
                return Json(FirstNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion AutoCompleteFirstName

        #region AutoCompleteLastName
        /// <summary>
        /// AutoCompleteLastName
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteLastName(String term)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString(); // Testing only
                String strFLName = "LName";

                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                List<String> FirstNames;

                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);

                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;

                FirstNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                return Json(FirstNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion AutoCompleteLastName

        #region AutoCompleteEntityName
        /// <summary>
        /// AutoCompleteEntityName
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteEntityName(String term)
        {
            try
            {
                String strFilerId = string.Empty;
                strFilerId = Session["FilerId"].ToString();
                String strFLName = "EName";
                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();
                List<String> EntityNames;
                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);
                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;
                EntityNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();
                return Json(EntityNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion AutoCompleteEntityName

        #region GetAutoCompleteNameData
        /// <summary>
        /// GetAutoCompleteNameData
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public JsonResult GetAutoCompleteNameData(String strValue)
        {
            try
            {
                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();
                lstAutoCompFLNameAddressModel = (IList<AutoCompFLNameAddressModel>)Session["lstAutoCompFLNameAddressModel"];
                String strResult = string.Empty;
                strResult = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityId ?? "").FirstOrDefault().ToString();
                Session["FilingEntId"] = strResult;

                lstAutoCompFLNameAddressModel = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstAutoCompFLNameAddressModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetAutoCompleteNameData

        #region DeleteFilingTransactions
        /// <summary>
        /// DeleteFilingTransactions
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult DeleteFilingTransactions(String strLoanLiabNumberOrg, String strTransNumber, String strRLiability)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.DeleteFilingTransactionsDataResponse(strTransNumber, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion DeleteFilingTransactions

        #region SaveFilingTransContrMonetaryData
        /// <summary>
        /// SaveFilingTransContrMonetaryData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstTransactionType"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="lstContributionName"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtCheck"></param>
        /// <param name="txtAmt"></param>
        /// <param name="txtExplanation"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveFilingTransContrMonetaryData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType, String lstElectionDate, String lstElectionDateId,
            String lstTransactionType, String txtDateRcvd, String lstContributionName, String txtPartnerShipName,
            String txtFirstName, String txtMI, String txtLastName, String txtStreetName, String txtCity,
            String txtState, String txtZipCode, String lstMethod, String txtCheck, String txtAmt, String txtExplanation,
            String lstItemized, String txtCountry, String txtCuttOffDate, String chkCountry, String validateSchedCCTC, String lstFilingDate, String txtReportPeriodDatesTo, String lstResigTermType, String lstUCMuncipality,
            String lstIsClaim, String lstInDistrict, String lstMinor, String lstVendor,
            String lstLobbyist, String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstMethod == "0")
                {
                    lstMethod = "";
                    txtCheck = "";
                }

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (lstContributionName == "" || lstContributionName == "- Select -" || lstContributionName == null)
                    lstContributionName = null;

                if (lstItemized == "N")
                    lstMethod = null;

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                if (lstItemized != "N")
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                }
                else
                {
                    objFilingTransactionsModel.FilingEntId = null;
                }

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    if (lstIsClaim == "No")
                    {
                        lstIsClaim = "N";
                        lstInDistrict = null;
                        lstMinor = null;
                        lstVendor = null;
                        lstLobbyist = null;
                    }
                    else
                    {
                        if (lstIsClaim == "Yes")
                        {
                            lstIsClaim = "Y";
                        }
                        else if (lstIsClaim == "No")
                        {
                            lstIsClaim = "N";
                        }
                        else
                        {
                            lstIsClaim = null;
                        }

                        if (lstInDistrict == "Yes")
                        {
                            lstInDistrict = "Y";
                        }
                        else if (lstInDistrict == "No")
                        {
                            lstInDistrict = "N";
                        }
                        else
                        {
                            lstInDistrict = null;
                        }

                        if (lstMinor == "Yes")
                        {
                            lstMinor = "Y";
                        }
                        else if (lstMinor == "No")
                        {
                            lstMinor = "N";
                        }
                        else
                        {
                            lstMinor = null;
                        }

                        if (lstVendor == "Yes")
                        {
                            lstVendor = "Y";
                        }
                        else if (lstVendor == "No")
                        {
                            lstVendor = "N";
                        }
                        else
                        {
                            lstVendor = null;
                        }

                        if (lstLobbyist == "Yes")
                        {
                            lstLobbyist = "Y";
                        }
                        else if (lstLobbyist == "No")
                        {
                            lstLobbyist = "N";
                        }
                        else
                        {
                            lstLobbyist = null;
                        }
                    }

                    if (lstRContributions == "Yes")
                    {
                        lstRContributions = "Y";
                    }
                    else if (lstRContributions == "No")
                    {
                        lstRContributions = "N";
                    }
                    else
                    {
                        lstRContributions = null;
                    }

                    if (lstRContributions == "N" || lstRContributions == null)
                    {
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }

                    if (lstContributionName == "5")
                    {
                        lstRContributions = null;
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }

                    if (lstTransactionType == "2" || lstTransactionType == "3")
                    {
                        lstIsClaim = null;
                        lstInDistrict = null;
                        lstMinor = null;
                        lstVendor = null;
                        lstLobbyist = null;
                        lstRContributions = null;
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                }
                else
                {
                    lstIsClaim = null;
                    lstInDistrict = null;
                    lstMinor = null;
                    lstVendor = null;
                    lstLobbyist = null;
                    lstRContributions = null;
                    txtEmployerPCFB = "";
                    txtOccupationPCFB = "";
                    txtContStreetName = "";
                    txtContCity = "";
                    txtContState = "";
                    txtContZipCode = "";
                }

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(txtDateRcvd))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtDateRcvd))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtDateRcvd, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }


                if (lstItemized == "Y") // Itemized Transaction
                {
                    if (validateSchedCCTC == "Yes") // Schedule C Contributor Type Code Validation.
                    {
                        if (lstContributionName == "0")
                        {
                            ModelState.AddModelError("lstContributionName", "Contributor Type Code is required");
                        }
                    }
                    else // Schedule A Contributor Code Validation.
                    {
                        if (lstContributionName == "0")
                        {
                            ModelState.AddModelError("lstContributionName", "Contributor Code is required");
                        }
                    }


                    if (lstContributionName == "5")
                    {
                        if (txtPartnerShipName == "")
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Partnership Name is required");
                        }
                        else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                        }
                        else if (txtPartnerShipName.Count() > 40)
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Partnership Name should be 40 characters");
                        }
                    }
                    else
                    {
                        if (validateSchedCCTC != "Yes")
                        {
                            if (lstContributionName != null)
                            {
                                if (txtFirstName == "")
                                {
                                    ModelState.AddModelError("txtFirstName", "First Name is required");
                                }
                                else if (!objCommonErrorsServerSide.NameValidate(txtFirstName))
                                {
                                    ModelState.AddModelError("txtFirstName", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtFirstName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtFirstName", "First Name should be 30 characters");
                                }

                                if (txtMI != "")
                                {
                                    if (!objCommonErrorsServerSide.NameValidate(txtMI))
                                    {
                                        ModelState.AddModelError("txtMI", "Letters, numbers and characters '# -., are allowed");
                                    }
                                    else if (txtMI.Count() > 30)
                                    {
                                        ModelState.AddModelError("txtMI", "Middle Name should be 30 characters");
                                    }
                                }

                                if (txtLastName == "")
                                {
                                    ModelState.AddModelError("txtLastName", "Last Name is required");
                                }
                                else if (!objCommonErrorsServerSide.NameValidate(txtLastName))
                                {
                                    ModelState.AddModelError("txtLastName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtLastName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtLastName", "Last Name should be 30 characters");
                                }
                            }

                            if (lstContributionName == null) // Schedule 'B' Check the Contributor Name.
                            {
                                if (txtPartnerShipName == "")
                                {
                                    ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                                }
                                else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                                {
                                    ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartnerShipName.Count() > 40)
                                {
                                    ModelState.AddModelError("txtPartnerShipName", "Partnership Name should be 40 characters");
                                }
                            }
                        }
                    }

                    if (validateSchedCCTC == "Yes") // Schedule C Contributor Name Validation
                    {
                        if (txtPartnerShipName == "")
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                        }
                        else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                        }
                        else if (txtPartnerShipName.Count() > 40)
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Contributor Name should be 40 characters");
                        }
                    }

                    if (chkCountry == "false") // United States Country.
                    {
                        if (txtCountry != "United States")
                        {
                            if (txtCountry != "")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                                {
                                    ModelState.AddModelError("txtCountry", "Letters are allowed");
                                }
                                else if (txtCountry.Count() > 30)
                                {
                                    ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                                }
                            }
                        }

                        if (txtCountry == "")
                        {
                            ModelState.AddModelError("txtCountry", "Country is required");
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                                }
                            }

                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtCity))
                                {
                                    ModelState.AddModelError("txtCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                                {
                                    ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }

                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(txtState))
                                {
                                    ModelState.AddModelError("txtState", "Two letters are allowed");
                                }
                                if (txtState.Length != 2)
                                {
                                    ModelState.AddModelError("txtState", "Two letters are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                                {
                                    ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtZipCode))
                                {
                                    ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                                {
                                    ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                            }
                        }
                    }
                    else // Other Country
                    {
                        if (txtCountry != "")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                            {
                                ModelState.AddModelError("txtCountry", "Letters are allowed");
                            }
                        }

                        if (txtCountry == "")
                        {
                            ModelState.AddModelError("txtCountry", "Country is required");
                        }

                        if (txtCountry.Count() > 30)
                        {
                            ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                            }
                        }


                        if (txtCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                            {
                                ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtState.Count() > 30)
                            {
                                ModelState.AddModelError("txtState", "State should be 30 characters");
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                            }
                        }

                    }

                    if (lstMethod == "1")
                    {
                        if (txtCheck == "")
                        {
                            ModelState.AddModelError("txtCheck", "Check # is required");
                        }
                        else if (!objCommonErrorsServerSide.AlphaNumeric(txtCheck))
                        {
                            ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                        }
                        else if (txtCheck.Count() > 30)
                        {
                            ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                        }
                    }
                    else if (lstMethod == "7")
                    {
                        if (txtExplanation == "")
                        {
                            ModelState.AddModelError("txtExplanation", "Explanation is required");
                        }
                        else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtCheck))
                        {
                            ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                        }
                        else if (txtExplanation.Count() > 250)
                        {
                            ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                        }
                    }

                    if (lstMethod != "")
                    {
                        if (lstMethod != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", lstMethod.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstMethod", "Invalid Method");
                            }
                        }
                    }

                    if (lstContributionName != null)
                    {
                        if (lstContributionName != "")
                        {
                            if (lstContributionName != "0")
                            {
                                Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("CONTRIBUTOR_TYPE", lstContributionName.ToString());
                                if (!results)
                                {
                                    ModelState.AddModelError("lstContributionName", "Invalid Contributor Code");
                                }
                            }
                        }
                    }
                    if (txtContStreetName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtContStreetName))
                        {
                            ModelState.AddModelError("txtContStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (txtContStreetName.Length < 4)
                            {
                                ModelState.AddModelError("txtContStreetName", "Street Address must contain at least four characters");
                            }
                        }

                        if (txtContStreetName.Count() > 60)
                        {
                            ModelState.AddModelError("txtContStreetName", "Street Address should be 60 characters");
                        }
                    }

                    if (txtContCity != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtContCity))
                        {
                            ModelState.AddModelError("txtContCity", "Letters and characters '# -., are allowed");
                        }

                        if (txtContCity.Count() > 30)
                        {
                            ModelState.AddModelError("txtContCity", "City should be 30 characters");
                        }
                    }

                    if (txtContState != "")
                    {
                        if (!objCommonErrorsServerSide.AlphabetsValState(txtContState))
                        {
                            ModelState.AddModelError("txtContState", "Two letters are allowed");
                        }
                        if (txtContState.Length != 2)
                        {
                            ModelState.AddModelError("txtContState", "Two letters are allowed");
                        }
                    }

                    if (txtContZipCode != "")
                    {
                        if (!objCommonErrorsServerSide.FomatZipcode(txtContZipCode))
                        {
                            ModelState.AddModelError("txtContZipCode", "Numbers and - are allowed");
                        }

                        if (txtContZipCode.Count() > 10)
                        {
                            ModelState.AddModelError("txtContZipCode", "Zip Code should be 10 characters");
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmt == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanation))
                    {
                        ModelState.AddModelError("txtExplanation", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }



                #endregion FormValidationScheduleA

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType; // "P"; // lstElectionType; Testing Only...
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.FilingTypeId = lstDisclosurePeriod;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionType;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.FlngEntName = txtPartnerShipName;
                    objFilingTransactionsModel.FlngEntFirstName = txtFirstName;
                    objFilingTransactionsModel.FlngEntLastName = txtLastName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtMI;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.OrgAmt = txtAmt;
                    objFilingTransactionsModel.ContributorTypeId = lstContributionName;
                    if (lstMethod == "")
                        objFilingTransactionsModel.PaymentTypeId = null;
                    else
                        objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.RItemized = lstItemized;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.ElectionDateId = lstElectionDateId;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                    {
                        if (lstFilingDate == "- New Filing Date -")
                            objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                        else
                            objFilingTransactionsModel.FilingDate = lstFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    }
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing Only...
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;
                    objFilingTransactionsModel.IsClaim = lstIsClaim;
                    objFilingTransactionsModel.InDistrict = lstInDistrict;
                    objFilingTransactionsModel.Minor = lstMinor;
                    objFilingTransactionsModel.Vendor = lstVendor;
                    objFilingTransactionsModel.Lobbyist = lstLobbyist;
                    objFilingTransactionsModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionsModel.TreasurerOccupation = txtOccupationPCFB;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionsModel.TreasurerCity = txtContCity;
                    objFilingTransactionsModel.TreasurerState = txtContState;
                    objFilingTransactionsModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionsModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }
                    objFilingTransactionsModel.RContributions = lstRContributions;

                    var results = objItemizedReportsBroker.AddFlngTransContrMonetaryDataResponse(objFilingTransactionsModel);

                    return Json(results, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion SaveFilingTransContrMonetaryData                        

        #region UpdateFlngTransMonetaryContrData
        /// <summary>
        /// UpdateFlngTransMonetaryContrData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="lstContributorName"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="txtCheck"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtAmt"></param>
        /// <param name="txtExplanation"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <param name="lstItemized"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateFlngTransMonetaryContrData(String strTransNumber, String strFilingEntId,
            String lstContributorName, String txtDateRcvd, String txtCheck, String lstMethod,
            String txtAmt, String txtExplanation, String txtPartnerShipName, String txtFirstName,
            String txtMI, String txtLastName, String txtStreetName, String txtCity, String txtState,
            String txtZipCode, String txtCountry, String chkCountry, String txtCuttOffDate, String strFilingDate, String lstItemized, String outOrginalAmount, String validateSchedCCTC, String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionCycle, String lstElectionType, String txtFilerId, String txtReportPeriodDatesTo, String lstFilingDate,
            String lstIsClaim, String lstInDistrict, String lstMinor, String lstVendor,
            String lstLobbyist, String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions, String lstTransactionType)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.

                if (lstMethod == "0")
                {
                    lstMethod = null;
                    txtCheck = null;
                }

                if (lstContributorName == "")
                    lstContributorName = null;

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    if (lstIsClaim == "No")
                    {
                        lstIsClaim = "N";
                        lstInDistrict = null;
                        lstMinor = null;
                        lstVendor = null;
                        lstLobbyist = null;
                    }
                    else
                    {
                        if (lstIsClaim == "Yes")
                        {
                            lstIsClaim = "Y";
                        }
                        else if (lstIsClaim == "No")
                        {
                            lstIsClaim = "N";
                        }
                        else
                        {
                            lstIsClaim = null;
                        }

                        if (lstInDistrict == "Yes")
                        {
                            lstInDistrict = "Y";
                        }
                        else if (lstInDistrict == "No")
                        {
                            lstInDistrict = "N";
                        }
                        else
                        {
                            lstInDistrict = null;
                        }

                        if (lstMinor == "Yes")
                        {
                            lstMinor = "Y";
                        }
                        else if (lstMinor == "No")
                        {
                            lstMinor = "N";
                        }
                        else
                        {
                            lstMinor = null;
                        }

                        if (lstVendor == "Yes")
                        {
                            lstVendor = "Y";
                        }
                        else if (lstVendor == "No")
                        {
                            lstVendor = "N";
                        }
                        else
                        {
                            lstVendor = null;
                        }

                        if (lstLobbyist == "Yes")
                        {
                            lstLobbyist = "Y";
                        }
                        else if (lstLobbyist == "No")
                        {
                            lstLobbyist = "N";
                        }
                        else
                        {
                            lstLobbyist = null;
                        }
                    }

                    if (lstRContributions == "Yes")
                    {
                        lstRContributions = "Y";
                    }
                    else if (lstRContributions == "No")
                    {
                        lstRContributions = "N";
                    }
                    else
                    {
                        lstRContributions = null;
                    }

                    if (lstRContributions == "N" || lstRContributions == null)
                    {
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                    if (lstContributorName == "5")
                    {
                        lstRContributions = null;
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }

                    if (lstTransactionType == "2" || lstTransactionType == "3")
                    {
                        lstIsClaim = null;
                        lstInDistrict = null;
                        lstMinor = null;
                        lstVendor = null;
                        lstLobbyist = null;
                        lstRContributions = null;
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                }
                else
                {
                    lstIsClaim = null;
                    lstInDistrict = null;
                    lstMinor = null;
                    lstVendor = null;
                    lstLobbyist = null;
                    lstRContributions = null;
                    txtEmployerPCFB = "";
                    txtOccupationPCFB = "";
                    txtContStreetName = "";
                    txtContCity = "";
                    txtContState = "";
                    txtContZipCode = "";
                }

                // SERVER SIDE VALIDATIONS.
                //========================================================================
                #region  FORM SERVER-SIDE VALIDATION SCHEDULE 'A','B','C'.

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(txtDateRcvd))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtDateRcvd))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtDateRcvd, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }


                if (lstItemized == "Y") // Itemized Transaction
                {
                    if (validateSchedCCTC == "Yes") // Schedule C Contributor Type Code Validation.
                    {
                        if (lstContributorName == "0")
                        {
                            ModelState.AddModelError("lstContributionName", "Contributor Type Code is required");
                        }
                    }
                    else // Schedule A contributor Code Validation.
                    {
                        if (lstContributorName == "0")
                        {
                            ModelState.AddModelError("lstContributionName", "Contributor Code is required");
                        }
                    }


                    if (lstContributorName == "5")
                    {
                        if (txtPartnerShipName == "")
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                        }
                        else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                        }
                        else if (txtPartnerShipName.Count() > 40)
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Partnership Name should be 40 characters");
                        }
                    }
                    else
                    {
                        if (validateSchedCCTC != "Yes")
                        {
                            if (lstContributorName != null)
                            {
                                if (txtPartnerShipName == "")
                                {
                                    if (txtFirstName == "")
                                    {
                                        ModelState.AddModelError("txtFirstName", "First Name is required");
                                    }
                                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtFirstName))
                                    {
                                        ModelState.AddModelError("txtFirstName", "Letters, numbers and characters '# -.,& are allowed");
                                    }
                                    else if (txtFirstName.Count() > 30)
                                    {
                                        ModelState.AddModelError("txtFirstName", "First Name should be 30 characters");
                                    }

                                    if (txtMI != "")
                                    {
                                        if (!objCommonErrorsServerSide.NameValidate(txtMI))
                                        {
                                            ModelState.AddModelError("txtMI", "Letters, numbers and characters '# -., are allowed");
                                        }
                                    }

                                    if (txtLastName == "")
                                    {
                                        ModelState.AddModelError("txtLastName", "Last Name is required");
                                    }
                                    else if (!objCommonErrorsServerSide.NameValidate(txtLastName))
                                    {
                                        ModelState.AddModelError("txtLastName", "Letters, numbers and characters '# -., are allowed");
                                    }
                                }
                                else
                                {
                                    if (txtPartnerShipName == "")
                                    {
                                        ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                                    }
                                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                                    {
                                        ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                                    }
                                    else if (txtPartnerShipName.Count() > 40)
                                    {
                                        ModelState.AddModelError("txtPartnerShipName", "Contributor Name should be 40 characters");
                                    }
                                }
                            }

                            if (lstContributorName == null) // Schedule 'B' Check the Contributor Name.
                            {
                                if (txtPartnerShipName == "")
                                {
                                    ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                                }
                                else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                                {
                                    ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartnerShipName.Count() > 40)
                                {
                                    ModelState.AddModelError("txtPartnerShipName", "Contributor Name should be 40 characters");
                                }
                            }
                        }
                    }

                    if (validateSchedCCTC == "Yes") // Schedule C Contributor Name Validation
                    {
                        if (txtPartnerShipName == "")
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                        }
                        else if (!objCommonErrorsServerSide.EntityNameValidate(txtPartnerShipName))
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                        }
                        else if (txtPartnerShipName.Count() > 40)
                        {
                            ModelState.AddModelError("txtPartnerShipName", "Contributor Name should be 40 characters");
                        }
                    }

                    if (chkCountry == "false") // United States Country.
                    {
                        if (txtCountry != "United States")
                        {
                            if (txtCountry != "")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                                {
                                    ModelState.AddModelError("txtCountry", "Letters are allowed");
                                }
                                else if (txtCountry.Count() > 30)
                                {
                                    ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                                }
                            }
                        }

                        if (txtCountry == "")
                        {
                            ModelState.AddModelError("txtCountry", "Country is required");
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                                }
                            }

                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtCity))
                                {
                                    ModelState.AddModelError("txtCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                                {
                                    ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }

                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(txtState))
                                {
                                    ModelState.AddModelError("txtState", "Two letters are allowed");
                                }
                                if (txtState.Length != 2)
                                {
                                    ModelState.AddModelError("txtState", "Two letters are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                                {
                                    ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtZipCode))
                                {
                                    ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                                {
                                    ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                            }
                        }
                    }
                    else // Other Country
                    {
                        if (txtCountry != "")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountry))
                            {
                                ModelState.AddModelError("txtCountry", "Letters are allowed");
                            }
                        }

                        if (txtCountry == "")
                        {
                            ModelState.AddModelError("txtCountry", "Country is required");
                        }

                        if (txtCountry.Count() > 30)
                        {
                            ModelState.AddModelError("txtCountry", "Country should be 30 characters");
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                            {
                                ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtState.Count() > 30)
                            {
                                ModelState.AddModelError("txtState", "State should be 30 characters");
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                            }
                        }

                    }

                    if (lstMethod == "1")
                    {
                        if (txtCheck == "")
                        {
                            ModelState.AddModelError("txtCheck", "Check # is required");
                        }
                        else if (!objCommonErrorsServerSide.AlphaNumeric(txtCheck))
                        {
                            ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                        }
                        else if (txtCheck.Count() > 30)
                        {
                            ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                        }
                    }
                    else if (lstMethod == "7")
                    {
                        if (txtExplanation == "")
                        {
                            ModelState.AddModelError("txtExplanation", "Explanation is required");
                        }
                        else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtCheck))
                        {
                            ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                        }
                        else if (txtExplanation.Count() > 250)
                        {
                            ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                        }
                    }

                    if (lstMethod != null)
                    {
                        if (lstMethod != "")
                        {
                            if (lstMethod != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", lstMethod.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstMethod", "Invalid Method");
                                }
                            }
                        }
                    }

                    if (lstContributorName != null)
                    {
                        if (lstContributorName != "")
                        {
                            if (lstContributorName != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("CONTRIBUTOR_TYPE", lstContributorName.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionName", "Invalid Contributor Code");
                                }
                            }
                        }
                    }
                }

                String strOutstandingDetailsAmount = String.Empty;
                Double outstandingOrgAmt = 0;

                if (lstContributorName == "5")
                {
                    outstandingOrgAmt = Convert.ToDouble(String.Format("{0:0.00}", outOrginalAmount));

                    if (Session["OutstandingAmountDetails"].ToString() != "")
                    {
                        strOutstandingDetailsAmount = Session["OutstandingAmountDetails"].ToString();
                    }
                    else
                    {
                        strOutstandingDetailsAmount = "";
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmt == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (lstContributorName == "5")
                {
                    if (txtAmt != "")
                    {
                        Double outstandingAmount = 0;
                        Double partnershipAmount = Convert.ToDouble(String.Format("{0:0.00}", txtAmt));
                        if (strOutstandingDetailsAmount != "")
                            outstandingAmount = Convert.ToDouble(String.Format("{0:0.00}", strOutstandingDetailsAmount));

                        if (strOutstandingDetailsAmount != "")
                        {
                            if (partnershipAmount < outstandingAmount)
                            {
                                ModelState.AddModelError("AmountError", "Partnership amount should not be more than outstanding amount");
                            }
                        }
                    }
                }

                if (txtExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanation))
                    {
                        ModelState.AddModelError("txtExplanation", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                #endregion FORM SERVER-SIDE VALIDATION SCHEDULE 'A','B','C'.
                // SERVER SIDE VALIDATIONS.
                //========================================================================

                if (ModelState.IsValid)
                {

                    if (lstContributorName == "0" || lstContributorName == "")
                        lstContributorName = null;

                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    if (strFilingEntId == "")
                        objFilingTransactionsModel.FilingEntId = null;
                    else
                        objFilingTransactionsModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsModel.ContributorTypeId = lstContributorName;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.OrgAmt = txtAmt;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.FlngEntName = txtPartnerShipName;
                    objFilingTransactionsModel.FlngEntFirstName = txtFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtMI;
                    objFilingTransactionsModel.FlngEntLastName = txtLastName;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.ModifiedBy = strModifiedBy;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.FilingTypeId = lstDisclosurePeriod;
                    objFilingTransactionsModel.ElectYearId = lstElectionCycle;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType;
                    objFilingTransactionsModel.FilerId = txtFilerId;

                    objFilingTransactionsModel.IsClaim = lstIsClaim;
                    objFilingTransactionsModel.InDistrict = lstInDistrict;
                    objFilingTransactionsModel.Minor = lstMinor;
                    objFilingTransactionsModel.Vendor = lstVendor;
                    objFilingTransactionsModel.Lobbyist = lstLobbyist;
                    objFilingTransactionsModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionsModel.TreasurerOccupation = txtOccupationPCFB;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionsModel.TreasurerCity = txtContCity;
                    objFilingTransactionsModel.TreasurerState = txtContState;
                    objFilingTransactionsModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionsModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }
                    objFilingTransactionsModel.RContributions = lstRContributions;

                    Boolean results = objItemizedReportsBroker.UpdateFlngTransMonetaryContrDataResponse(objFilingTransactionsModel);

                    return Json(results, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion UpdateFlngTransMonetaryContrData

        #region GetSchedAPartnersData
        /// <summary>
        /// GetSchedAPartnersData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetSchedAPartnersData(String strTransNumber, String strFilerId)
        {
            try
            {
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModelResults = new List<ContrInKindPartnersModel>();
                ContrInKindPartnersModel objContrInKindPartnersModel;

                lstContrInKindPartnersModel = objItemizedReportsBroker.GetContrInKindPartnersDataResponse(strTransNumber, strFilerId);

                String strPartnershipName = lstContrInKindPartnersModel.Where(x => x.TransNumber == strTransNumber).Select(x => x.PartnershipName).FirstOrDefault().ToString();

                String strDateReceivedPrimary = lstContrInKindPartnersModel.Where(x => x.TransNumber == strTransNumber).Select(x => x.PartnerStreetNo).FirstOrDefault().ToString();

                var itemRemove = lstContrInKindPartnersModel.Single(x => x.TransNumber == strTransNumber);

                lstContrInKindPartnersModel.Remove(itemRemove);

                foreach (var item in lstContrInKindPartnersModel)
                {
                    if (item != null)
                    {
                        objContrInKindPartnersModel = new ContrInKindPartnersModel();
                        objContrInKindPartnersModel.FilingTransId = item.FilingTransId;
                        objContrInKindPartnersModel.FilingEntityId = item.FilingEntityId;
                        objContrInKindPartnersModel.PartnershipName = strPartnershipName;
                        objContrInKindPartnersModel.DateReceivedPrimary = strDateReceivedPrimary;
                        objContrInKindPartnersModel.PartnerName = item.PartnershipName;
                        objContrInKindPartnersModel.PartnerFirstName = item.PartnerFirstName;
                        objContrInKindPartnersModel.PartnerMiddleName = item.PartnerMiddleName;
                        objContrInKindPartnersModel.PartnerLastName = item.PartnerLastName;
                        objContrInKindPartnersModel.PartnerStreetName = item.PartnerStreetName;
                        objContrInKindPartnersModel.PartnerCity = item.PartnerCity;
                        objContrInKindPartnersModel.PartnerState = item.PartnerState;
                        objContrInKindPartnersModel.PartnerZip5 = item.PartnerZip5;
                        objContrInKindPartnersModel.PartnershipCountry = item.PartnershipCountry;
                        if (item.PartnerAmountAttributed != "")
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        else
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        objContrInKindPartnersModel.PartnerExplanation = item.PartnerExplanation;
                        objContrInKindPartnersModel.RItemized = item.RItemized;
                        objContrInKindPartnersModel.TransNumber = item.TransNumber;
                        objContrInKindPartnersModel.TransMapping = item.TransMapping;
                        objContrInKindPartnersModel.TreasurerEmployer = item.TreasurerEmployer;
                        objContrInKindPartnersModel.TreasurerOccupation = item.TreasurerOccupation;
                        objContrInKindPartnersModel.TreaAddress = item.TreaAddress;
                        objContrInKindPartnersModel.TreaAddr1 = item.TreaAddr1;
                        objContrInKindPartnersModel.TreaCity = item.TreaCity;
                        objContrInKindPartnersModel.TreaState = item.TreaState;
                        objContrInKindPartnersModel.TreaZipCode = item.TreaZipCode;
                        objContrInKindPartnersModel.RContributions = item.RContributions;
                        lstContrInKindPartnersModelResults.Add(objContrInKindPartnersModel);
                    }
                }

                //lstContrInKindPartnersModelResults = lstContrInKindPartnersModelResults.OrderBy(x => x.FilingTransId).ToList();

                return Json(new
                {
                    aaData = lstContrInKindPartnersModelResults.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingEntityId,
                    "",
                    "",
                    x.PartnershipName,
                    x.PartnerName,
                    x.PartnerFirstName,
                    x.PartnerMiddleName,
                    x.PartnerLastName,
                    x.PartnershipCountry,
                    x.PartnerStreetName,
                    x.PartnerCity,
                    x.PartnerState,
                    x.PartnerZip5,
                    x.PartnerAmountAttributed,
                    x.PartnerExplanation,
                    x.RItemized,
                    x.TransNumber,
                    x.TransMapping,
                    x.DateReceivedPrimary,
                    x.RContributions,
                    x.TreasurerEmployer,
                    x.TreasurerOccupation,
                    x.TreaAddress,
                    x.TreaAddr1,
                    x.TreaCity,
                    x.TreaState,
                    x.TreaZipCode
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetSchedAPartnersData

        #region SaveSchedAPartnersData
        /// <summary>
        /// SaveSchedAPartnersData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingSchedId"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="txtFilerId"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="txtPartFirstName"></param>
        /// <param name="txtPartMI"></param>
        /// <param name="txtPartLastName"></param>
        /// <param name="txtPartStreetName"></param>
        /// <param name="txtPartCity"></param>
        /// <param name="txtPartState"></param>
        /// <param name="txtPartZip5"></param>
        /// <param name="txtPartZip4"></param>
        /// <param name="txtPartAmt"></param>
        /// <param name="txtPartExplanationInKind"></param>
        /// <returns></returns>
        //[HttpPost]
        public JsonResult SaveSchedAPartnersData(String strTransNumber, String strFilingSchedId, String strFilingSchedDate, String txtFilerId,
            String lstElectionCycle, String lstElectionCycleId, String lstUCOfficeType, String lstDisclosurePeriod,
            String lstElectionType, String lstElectionDate, String txtPartnerName, String txtPartFirstName,
            String txtPartMI, String txtPartLastName, String txtPartStreetName,
            String txtPartCity, String txtPartState, String txtPartZip5, String txtPartAmt,
            String txtPartExplanationInKind, String lstItemizedPart, String txtCountryPartnership, String lstIndividualPart, String chkCountryPartnership, String outOrginalAmount, String recordCount,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (strFilingSchedDate == "")
                    strFilingSchedDate = null;

                if (txtPartZip5 == "00000-0000")
                    txtPartZip5 = "";

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    if (lstRContributions == "Yes")
                    {
                        lstRContributions = "Y";
                    }
                    else if (lstRContributions == "No")
                    {
                        lstRContributions = "N";
                    }
                    else
                    {
                        lstRContributions = null;
                    }

                    if (lstRContributions == "N" || lstRContributions == null)
                    {
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }

                    if (lstItemizedPart == "N" || lstIndividualPart == "N")
                    {
                        lstRContributions = null;
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                }
                else
                {
                    lstRContributions = null;
                    txtEmployerPCFB = "";
                    txtOccupationPCFB = "";
                    txtContStreetName = "";
                    txtContCity = "";
                    txtContState = "";
                    txtContZipCode = "";
                }

                #region FormValidationSchedAPartners

                if (lstItemizedPart == "Y")
                {
                    if (lstIndividualPart == "N")
                    {
                        txtPartFirstName = "";
                        txtPartMI = "";
                        txtPartLastName = "";

                        if (txtPartnerName == "")
                        {
                            ModelState.AddModelError("txtPartnerName", "Partner Name is required");
                        }
                        else if (txtPartnerName != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartnerName))
                                {
                                    ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartnerName.Count() > 40)
                                {
                                    ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartnerName))
                                {
                                    ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartnerName.Count() > 40)
                                {
                                    ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                                }
                            }
                        }
                    }
                    else
                    {
                        txtPartnerName = "";

                        if (txtPartFirstName == "")
                        {
                            ModelState.AddModelError("txtPartFirstName", "First Name is required");
                        }
                        else if (txtPartFirstName != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartFirstName))
                                {
                                    ModelState.AddModelError("txtPartFirstName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartFirstName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartFirstName", "First Name should be 30 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidate(txtPartFirstName))
                                {
                                    ModelState.AddModelError("txtPartFirstName", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtPartFirstName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartFirstName", "First Name should be 30 characters");
                                }
                            }
                        }

                        if (txtPartMI != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartMI))
                                {
                                    ModelState.AddModelError("txtPartMI", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartMI.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartMI", "Middle Name should be 30 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidate(txtPartMI))
                                {
                                    ModelState.AddModelError("txtPartMI", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtPartMI.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartMI", "Middle Name should be 30 characters");
                                }
                            }
                        }

                        if (txtPartLastName == "")
                        {
                            ModelState.AddModelError("txtPartLastName", "Last Name is required");
                        }
                        else if (txtPartLastName != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartLastName))
                                {
                                    ModelState.AddModelError("txtPartLastName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartLastName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartLastName", "Last Name should be 30 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidate(txtPartLastName))
                                {
                                    ModelState.AddModelError("txtPartLastName", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtPartLastName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartLastName", "Last Name should be 30 characters");
                                }
                            }
                        }
                    }

                    if (chkCountryPartnership == "false") // UNITED STATES COUNTRY VALIDAITON.
                    {
                        if (txtCountryPartnership == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else if (txtCountryPartnership != "United States")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryPartnership))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                        }

                        if (txtCountryPartnership.Count() > 30)
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                        }

                        if (txtPartStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtPartStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtPartStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtPartStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtPartCity != "")
                        {
                            if (txtCountryPartnership == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtPartCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                            if (txtPartCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtPartState != "")
                        {
                            if (txtCountryPartnership == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(txtPartState))
                                {
                                    ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                }
                                else
                                {
                                    if (txtPartState.Length != 2)
                                    {
                                        ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                    }
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                                {
                                    ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (txtPartZip5 != "")
                        {
                            if (txtCountryPartnership == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtPartZip5))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtPartZip5.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }
                    else // OTHER COUNTRY VALIDATION.
                    {
                        if (txtCountryPartnership == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryPartnership))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                            if (txtCountryPartnership.Count() > 30)
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                            }
                        }

                        if (txtPartStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtPartStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtPartStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtPartStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtPartCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                            {
                                ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtPartCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtPartState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                            {
                                ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtPartState.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartState", "State should be 30 characters");
                            }
                        }

                        if (txtPartZip5 != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                            {
                                ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                            }
                            if (txtPartZip5.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }
                }
                else
                {
                    if (lstItemizedPart != "N")
                    {
                        ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                    }
                }

                if (lstItemizedPart != "Y" && lstItemizedPart != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                }

                if (lstIndividualPart != "Y" && lstIndividualPart != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                }

                Double outstandingOrgAmt = Convert.ToDouble(String.Format("{0:0.00}", outOrginalAmount));

                String strOutstandingDetailsAmount;
                if (Session["OutstandingAmountDetails"].ToString() != "")
                {
                    strOutstandingDetailsAmount = Session["OutstandingAmountDetails"].ToString();
                }
                else
                {
                    strOutstandingDetailsAmount = outOrginalAmount;
                }

                if (txtPartAmt == "")
                {
                    ModelState.AddModelError("txtPartAmt", "Amount Attributed is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (txtPartAmt != "")
                {
                    Double partnershipAmount = Convert.ToDouble(String.Format("{0:0.00}", txtPartAmt));
                    Double outstandingAmount = Convert.ToDouble(String.Format("{0:0.00}", strOutstandingDetailsAmount));

                    Double pendingAmount;
                    if (outstandingOrgAmt == outstandingAmount)
                    {
                        if (recordCount == "1")
                        {
                            pendingAmount = outstandingAmount;
                        }
                        else
                        {
                            if (Convert.ToInt32(recordCount) > 1)
                                pendingAmount = outstandingOrgAmt - outstandingAmount;
                            else
                                pendingAmount = outstandingOrgAmt;
                        }
                    }
                    else
                    {
                        pendingAmount = outstandingOrgAmt - outstandingAmount;
                    }

                    if (partnershipAmount > Math.Round(pendingAmount, 2))
                    {
                        ModelState.AddModelError("AmountError", "Partnership amount should not be more than outstanding amount");
                    }
                }

                if (txtPartExplanationInKind != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtPartExplanationInKind))
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    if (txtPartExplanationInKind.Count() > 250)
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Explanation should be 250 characters");
                    }
                }

                //if (txtPartAmt != "")
                //{
                //    Double partnershipAmount = Convert.ToDouble(String.Format("{0:0.00}", txtPartAmt));
                //    Double outstandingAmount = Convert.ToDouble(String.Format("{0:0.00}", strOutstandingDetailsAmount));

                //    Double pendingAmount;
                //    if (outstandingOrgAmt == outstandingAmount)
                //        pendingAmount = outstandingAmount;
                //    else
                //        pendingAmount = outstandingOrgAmt - outstandingAmount;               


                //    if (partnershipAmount > pendingAmount)
                //    {
                //        ModelState.AddModelError("AmountError", "Partnership amount should not be more than outstanding amount");
                //    }
                //}                          

                #endregion FormValidationSchedAPartners

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.FilingSchedId = ""; // Partnership/SubContractor.... strFilingSchedId;
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.OrgAmt = txtPartAmt;
                    if (lstItemizedPart == "Y")
                    {
                        if (Session["FilingEntId"] != null)
                            objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                        else
                            objFilingTransactionsModel.FilingEntId = null;
                    }
                    else
                    {
                        objFilingTransactionsModel.FilingEntId = null;
                    }
                    objFilingTransactionsModel.FlngEntName = txtPartnerName;
                    objFilingTransactionsModel.FlngEntFirstName = txtPartFirstName;
                    objFilingTransactionsModel.FlngEntLastName = txtPartLastName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtPartMI;
                    objFilingTransactionsModel.FlngEntStrNum = "";
                    objFilingTransactionsModel.FlngEntStrName = txtPartStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.FlngEntCountry = txtCountryPartnership;
                    objFilingTransactionsModel.TransExplanation = txtPartExplanationInKind;
                    objFilingTransactionsModel.RItemized = lstItemizedPart;
                    objFilingTransactionsModel.FlngEntCountry = txtCountryPartnership;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing Only...

                    objFilingTransactionsModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionsModel.TreasurerOccupation = txtOccupationPCFB;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionsModel.TreasurerCity = txtContCity;
                    objFilingTransactionsModel.TreasurerState = txtContState;
                    objFilingTransactionsModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionsModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }
                    objFilingTransactionsModel.RContributions = lstRContributions;

                    var results = objItemizedReportsBroker.AddContrInKindPartnersDataResponse(objFilingTransactionsModel);

                    //if (txtPartFirstName != "" || txtPartLastName != "")
                    //    results = objItemizedReportsBroker.AddContrInKindPartnersDataResponse(objFilingTransactionsModel);
                    //else
                    //    results = false;

                    return Json(results, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion SaveSchedAPartnersData

        #region UpdateSchedAPartnersData
        /// <summary>
        /// UpdateSchedAPartnersData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingEntityId"></param>
        /// <param name="txtPartshiptName"></param>
        /// <param name="txtPartFirstName"></param>
        /// <param name="txtPartMI"></param>
        /// <param name="txtPartLastName"></param>
        /// <param name="txtPartStreetName"></param>
        /// <param name="txtPartCity"></param>
        /// <param name="txtPartState"></param>
        /// <param name="txtPartZip5"></param>
        /// <param name="txtPartZip4"></param>
        /// <param name="txtPartAmt"></param>
        /// <param name="txtPartExplanationInKind"></param>
        /// <returns></returns>
        //[HttpPost]
        public JsonResult UpdateSchedAPartnersData(String strTransNumber, String strFilingEntityId,
            String txtPartshiptName, String txtPartFirstName, String txtPartMI, String txtPartLastName, String txtPartStreetName, String txtPartCity,
            String txtPartState, String txtPartZip5, String txtPartAmt, String txtPartExplanationInKind, String txtCountryPartnership, String lstItemizedPart, String lstIndividualPart, String chkCountryPartnership, String outOrginalAmount, String recordCount, String existingAmount, String strFilingSchedId,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (txtPartFirstName == "" && txtPartshiptName == "")
                {
                    strFilingEntityId = null;
                }

                if (txtPartZip5 == "00000-0000")
                    txtPartZip5 = "";

                if (Session["COMM_TYPE_ID"].ToString() == "23")
                {
                    if (lstRContributions == "Yes")
                    {
                        lstRContributions = "Y";
                    }
                    else if (lstRContributions == "No")
                    {
                        lstRContributions = "N";
                    }
                    else
                    {
                        lstRContributions = null;
                    }

                    if (lstRContributions == "N" || lstRContributions == null)
                    {
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }

                    if (lstItemizedPart == "N" || lstIndividualPart == "N")
                    {
                        lstRContributions = null;
                        txtEmployerPCFB = "";
                        txtOccupationPCFB = "";
                        txtContStreetName = "";
                        txtContCity = "";
                        txtContState = "";
                        txtContZipCode = "";
                    }
                }
                else
                {
                    lstRContributions = null;
                    txtEmployerPCFB = "";
                    txtOccupationPCFB = "";
                    txtContStreetName = "";
                    txtContCity = "";
                    txtContState = "";
                    txtContZipCode = "";
                }

                #region Server Side Validation Schedule D Partnership

                if (lstItemizedPart == "Y")
                {
                    if (lstIndividualPart == "N")
                    {
                        if (txtPartshiptName == "")
                        {
                            ModelState.AddModelError("txtPartnerName", "Partner Name is required");
                        }
                        else if (txtPartshiptName != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartshiptName))
                                {
                                    ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartshiptName.Count() > 40)
                                {
                                    ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartshiptName))
                                {
                                    ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartshiptName.Count() > 40)
                                {
                                    ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txtPartFirstName == "")
                        {
                            ModelState.AddModelError("txtPartFirstName", "First Name is required");
                        }
                        else if (txtPartFirstName != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartFirstName))
                                {
                                    ModelState.AddModelError("txtPartFirstName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartFirstName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartFirstName", "First Name should be 30 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidate(txtPartFirstName))
                                {
                                    ModelState.AddModelError("txtPartFirstName", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtPartFirstName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartFirstName", "First Name should be 30 characters");
                                }
                            }
                        }

                        if (txtPartMI != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartMI))
                                {
                                    ModelState.AddModelError("txtPartMI", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartMI.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartMI", "Middle Name should be 30 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidate(txtPartMI))
                                {
                                    ModelState.AddModelError("txtPartMI", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtPartMI.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartMI", "Middle Name should be 30 characters");
                                }
                            }
                        }

                        if (txtPartLastName == "")
                        {
                            ModelState.AddModelError("txtPartLastName", "Last Name is required");
                        }
                        else if (txtPartLastName != "")
                        {
                            if (strFilingSchedId == "1" || strFilingSchedId == "4" || strFilingSchedId == "16" || strFilingSchedId == "9")
                            {
                                if (!objCommonErrorsServerSide.NameValidatePartnerDetails(txtPartLastName))
                                {
                                    ModelState.AddModelError("txtPartLastName", "Letters, numbers and characters '# -.,& are allowed");
                                }
                                else if (txtPartLastName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartLastName", "Last Name should be 30 characters");
                                }
                            }
                            else
                            {
                                if (!objCommonErrorsServerSide.NameValidate(txtPartLastName))
                                {
                                    ModelState.AddModelError("txtPartLastName", "Letters, numbers and characters '# -., are allowed");
                                }
                                else if (txtPartLastName.Count() > 30)
                                {
                                    ModelState.AddModelError("txtPartLastName", "Last Name should be 30 characters");
                                }
                            }
                        }
                    }

                    if (chkCountryPartnership == "false") // UNITED STATES COUNTRY VALIDAITON.
                    {
                        if (txtCountryPartnership == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else if (txtCountryPartnership != "United States")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryPartnership))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                        }

                        if (txtCountryPartnership.Count() > 30)
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                        }

                        if (txtPartStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtPartStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtPartStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtPartStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtPartCity != "")
                        {
                            if (txtCountryPartnership == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtPartCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                            if (txtPartCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtPartState != "")
                        {
                            if (txtCountryPartnership == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(txtPartState))
                                {
                                    ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                }
                                else
                                {
                                    if (txtPartState.Length != 2)
                                    {
                                        ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                    }
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                                {
                                    ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (txtPartZip5 != "")
                        {
                            if (txtCountryPartnership == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtPartZip5))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtPartZip5.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }
                    else // OTHER COUNTRY VALIDATION.
                    {
                        if (txtCountryPartnership == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryPartnership))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                            if (txtCountryPartnership.Count() > 30)
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                            }
                        }

                        if (txtPartStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtPartStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtPartStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtPartStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtPartCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtPartCity))
                            {
                                ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtPartCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }

                        }

                        if (txtPartState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtPartState))
                            {
                                ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtPartState.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartState", "State should be 30 characters");
                            }
                        }

                        if (txtPartZip5 != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtPartZip5))
                            {
                                ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                            }
                            if (txtPartZip5.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }

                        }
                    }
                }
                else
                {
                    if (lstItemizedPart != "N")
                    {
                        ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                    }
                }

                if (lstItemizedPart != "Y" && lstItemizedPart != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                }

                if (lstIndividualPart != "Y" && lstIndividualPart != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                }

                Double outstandingOrgAmt = Convert.ToDouble(String.Format("{0:0.00}", outOrginalAmount));

                String strOutstandingDetailsAmount;
                if (Session["OutstandingAmountDetails"].ToString() != "")
                {
                    strOutstandingDetailsAmount = Session["OutstandingAmountDetails"].ToString();
                }
                else
                {
                    strOutstandingDetailsAmount = outOrginalAmount;
                }

                if (txtPartAmt == "")
                {
                    ModelState.AddModelError("txtPartAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtPartAmt))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (txtPartAmt != "")
                {
                    Double partnershipAmount = Convert.ToDouble(String.Format("{0:0.00}", txtPartAmt));
                    Double outstandingAmount = Convert.ToDouble(String.Format("{0:0.00}", strOutstandingDetailsAmount));

                    Double pendingAmount;
                    if (outstandingOrgAmt == outstandingAmount)
                    {
                        pendingAmount = outstandingAmount;
                    }
                    else
                    {
                        if (recordCount.ToString() == "1")
                        {
                            pendingAmount = outstandingOrgAmt;
                        }
                        else
                        {
                            Double outstandingAmountEdit = outstandingAmount - Convert.ToDouble(existingAmount);
                            pendingAmount = outstandingOrgAmt - outstandingAmountEdit;
                        }
                    }

                    if (partnershipAmount > Math.Round(pendingAmount, 2))
                    {
                        ModelState.AddModelError("AmountError", "Partnership amount should not be more than outstanding amount");
                    }
                }

                if (txtPartExplanationInKind != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtPartExplanationInKind))
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    if (txtPartExplanationInKind.Count() > 250)
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Explanation should be 250 characters");
                    }
                }

                #endregion Server Side Validation Schedule D Partnership

                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    //if (strFilingEntityId == "0")
                    //    objFilingTransactionsModel.FilingEntId = null;
                    //else
                    objFilingTransactionsModel.FilingEntId = strFilingEntityId;
                    objFilingTransactionsModel.FlngEntName = txtPartshiptName;
                    objFilingTransactionsModel.FlngEntFirstName = txtPartFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtPartMI;
                    objFilingTransactionsModel.FlngEntLastName = txtPartLastName;
                    objFilingTransactionsModel.FlngEntStrName = txtPartStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.OrgAmt = txtPartAmt;
                    objFilingTransactionsModel.TransExplanation = txtPartExplanationInKind;
                    objFilingTransactionsModel.FlngEntCountry = txtCountryPartnership;
                    objFilingTransactionsModel.ModifiedBy = strModifiedBy;
                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();
                    objFilingTransactionsModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionsModel.TreasurerOccupation = txtOccupationPCFB;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionsModel.TreasurerCity = txtContCity;
                    objFilingTransactionsModel.TreasurerState = txtContState;
                    objFilingTransactionsModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionsModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }
                    objFilingTransactionsModel.RContributions = lstRContributions;

                    Boolean results = objItemizedReportsBroker.UpdateContrInKindPartnersDataResponse(objFilingTransactionsModel);

                    return Json(results, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion UpdateSchedAPartnersData

        #region DeleteSchedAPartnersData
        /// <summary>
        /// DeleteSchedAPartnersData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <returns></returns>
        public JsonResult DeleteSchedAPartnersData(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.DeleteContrInKindPartnersDataResponse(strTransNumber, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion DeleteSchedAPartnersData

        #region GetContributorTypeCodeSchedC
        /// <summary>
        /// GetContributorTypeCode
        /// </summary>
        /// <returns></returns>
        public JsonResult GetContributorTypeCodeSchedC()
        {
            try
            {
                IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

                ContributorNameModel objContributorNameModel;
                objContributorNameModel = new ContributorNameModel();
                objContributorNameModel.ContributorTypeId = "0";
                objContributorNameModel.ContributorTypeDesc = "- Select -";
                objContributorNameModel.ContributorTypeAbbrev = "SEL";
                lstContributorNameModel.Add(objContributorNameModel);
                var resContributorNames = objItemizedReportsBroker.GetContributorTypesSchedCResponse();
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

                return Json(new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetContributorTypeCodeSchedC

        #region GetPaymentMethodData
        /// <summary>
        /// GetPaymentMethodData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPaymentMethodData()
        {
            try
            {
                IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
                PaymentMethodModel objPaymentMethodModel;
                objPaymentMethodModel = new PaymentMethodModel();
                objPaymentMethodModel.PaymentTypeId = "0";
                objPaymentMethodModel.PaymentTypeDesc = "- Select -";
                objPaymentMethodModel.PaymentTypeAbbrev = "SEL";
                lstPaymentMethodModel.Add(objPaymentMethodModel);
                var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataSchedA();
                foreach (var item in resPayMethods)
                {
                    if (item != null)
                    {
                        objPaymentMethodModel = new PaymentMethodModel();
                        objPaymentMethodModel.PaymentTypeId = item.PaymentTypeId;
                        objPaymentMethodModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objPaymentMethodModel.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                        lstPaymentMethodModel.Add(objPaymentMethodModel);
                    }
                }

                return Json(new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetPaymentMethodData

        #region GetContributorCodeSchedA
        /// <summary>
        /// GetContributorCodeSchedA
        /// </summary>
        /// <returns></returns>
        public JsonResult GetContributorCodeSchedA()
        {
            try
            {
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
                itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "9");
                if (itemToRemove != null)
                    resContributorNames.Remove(itemToRemove);
                itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "10");
                if (itemToRemove != null)
                    resContributorNames.Remove(itemToRemove);
                // REMOVE PAC FROM SCHEDULE A DIALOG BOX DISCCUSSED ON 02.09.2021
                // AS PER DISCUSSION IT IS REMOVED FROM CONTIBUTOR TYPE LIST ON SCHEDULE A.
                var itemToRemovePAC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "12");
                if (itemToRemovePAC != null)
                    resContributorNames.Remove(itemToRemovePAC);
                // REMOVE PLLC/LLC FROM SCHEDULE A DIALOG BOX IT SHOULD NOT BE.
                var itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "11");
                if (itemToRemovePLLCLLC != null)
                    resContributorNames.Remove(itemToRemovePLLCLLC);
                // REMOVE POLITICAL COMMITTEE SHOULD SHOW IN SCHEDULE D NOT SCHEDULE A.
                itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "13");
                if (itemToRemovePLLCLLC != null)
                    resContributorNames.Remove(itemToRemovePLLCLLC);
                // REMOVE OTHER SHOULD SHOW IN SCHEDULE D NOT IN SCHEDULE A. REMOVED.
                itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "14");
                if (itemToRemovePLLCLLC != null)
                    resContributorNames.Remove(itemToRemovePLLCLLC);

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

                return Json(new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetContributorCodeSchedA

        #region GetPartnershipTotAmt
        /// <summary>
        /// GetPartnershipTotAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetPartnershipTotAmt(String strTransNumber)
        {
            try
            {
                String strExpSubContrTotAmt = String.Empty;

                String strFilerId = Session["FilerID"].ToString();

                strExpSubContrTotAmt = objItemizedReportsBroker.GetExpSubContrTotAmtResponse(strTransNumber, strFilerId);
                Session["OutstandingAmountDetails"] = strExpSubContrTotAmt;

                return strExpSubContrTotAmt;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetPartnershipTotAmt

        #region GetCommitteeTypeId
        /// <summary>
        /// GetCommitteeTypeId
        /// </summary>
        /// <returns></returns>
        public String GetCommitteeTypeId()
        {
            try
            {
                String strCommTypeId = String.Empty;

                strCommTypeId = Convert.ToString(Session["COMM_TYPE_ID"]);

                return strCommTypeId;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetCommitteeTypeId

        #region GetScheduleAHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleAHelpPopUp()
        {
            return View("GetScheduleAHelpPopUp");
        }
        #endregion GetScheduleAHelpPopUp

        #region GetScheduleBHelpPopUp
        /// <summary>
        /// GetScheduleBHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleBHelpPopUp()
        {
            return View("GetScheduleBHelpPopUp");
        }
        #endregion GetScheduleBHelpPopUp

        #region GetScheduleCHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleCHelpPopUp()
        {
            return View("GetScheduleCHelpPopUp");
        }
        #endregion GetScheduleAHelpPopUp

        #region GetScheduleAHelpPopUp_Import
        /// <summary>
        /// GetScheduleAHelpPopUp_Import
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleAHelpPopUp_Import()
        {
            return View("GetScheduleAHelpPopUp_Import");
        }
        #endregion GetScheduleAHelpPopUp_Import

        #region GetContrRefundedTotalAmt
        /// <summary>
        /// GetContrRefundedTotalAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetContrRefundedTotalAmt(String strTransNumber, String filerID)
        {
            try
            {
                String results = objItemizedReportsBroker.GetContrRefundedSchedABCTotalAmtResponse(strTransNumber, filerID);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetContrRefundedTotalAmt

        #region ContributionsRefundSchedMExists
        /// <summary>
        /// ContributionsRefundSchedMExists
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult ContributionsRefundSchedMExists(String strTransNumber, String filerID)
        {
            try
            {
                // FILER ID ADDED BUT VALUE NOT PASSING IT IS GOING ALWAYS NULL.
                // THE RESULT SHOWING ALWAYS FALSE HAS BEEN FIXED. 11.17.2021.
                if (Session["FilerId"] != null)
                    filerID = Session["FilerId"].ToString();

                String results = objItemizedReportsBroker.GetContributionsExistsSchedMResponse(strTransNumber, filerID);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion ContributionsRefundSchedMExists

        #region GetDefaultLookUpsValues
        /// <summary>
        /// GetDefaultLookUpsValues
        /// </summary>
        public void GetDefaultLookUpsValues()
        {
            try
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

                // GET FILER TYPE
                ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();

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

                // Bind listIsClaim
                var listIsClaim = new SelectList(new[]
                                              {
                                              new{ID="0",Name="- Select -"},
                                              new{ID="1",Name="Yes"},
                                              new {ID="2",Name="No"},
                                              },
                                "ID", "Name", 0);

                // Bind listIsClaim
                var listIsClaimVal = new SelectList(new[]
                                              {
                                              new{ID="0",Name="Yes"},
                                              new {ID="1",Name="No"},
                                              },
                                "ID", "Name", 0);

                ViewData["lstIsClaim"] = listIsClaim;
                ViewData["lstInDistrict"] = listIsClaimVal;
                ViewData["lstMinor"] = listIsClaimVal;
                ViewData["lstVendor"] = listIsClaimVal;
                ViewData["lstLobbyist"] = listIsClaimVal;
                ViewData["lstRContributions"] = listIsClaimVal;

                // Bind Disclosure Type
                ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

                // BIND TRANSACTIONS TYPE.
                IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
                if (Session["FilerId"] != null)
                {
                    String strCandCommId = Session["FilerId"].ToString();
                    lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(strCandCommId);
                }
                else
                {
                    lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); //GetTransactionTypeData();
                }
                // Bind Transaction Type
                ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

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
                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(),"");
                // Disclosure Period
                ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

                IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
                PaymentMethodModel objPaymentMethodModel;
                objPaymentMethodModel = new PaymentMethodModel();
                objPaymentMethodModel.PaymentTypeId = "0";
                objPaymentMethodModel.PaymentTypeDesc = "- Select -";
                objPaymentMethodModel.PaymentTypeAbbrev = "SEL";
                lstPaymentMethodModel.Add(objPaymentMethodModel);
                var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataSchedA();
                foreach (var item in resPayMethods)
                {
                    if (item != null)
                    {
                        objPaymentMethodModel = new PaymentMethodModel();
                        objPaymentMethodModel.PaymentTypeId = item.PaymentTypeId;
                        objPaymentMethodModel.PaymentTypeDesc = item.PaymentTypeDesc;
                        objPaymentMethodModel.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
                        lstPaymentMethodModel.Add(objPaymentMethodModel);
                    }
                }
                // Payment Method
                ViewData["lstMethod"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");


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

                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeDataResponse();
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

                // ===================================================================================================================================
                // THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
                // ===================================================================================================================================
                // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
                // Bind Filing Date for Off Cycle.
                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModelResults = new List<FilingDatesOffCycleModel>();
                FilingDatesOffCycleModel objFilingDatesOffCycleModel;
                if (Session["ElectionYearId"] != null && Session["OfficeTypeId"] != null && Session["FilerIdOffCycle"] != null && Session["DisclosureType"] != null)
                    lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(Session["ElectionYearId"].ToString(), Session["OfficeTypeId"].ToString(), Session["FilerIdOffCycle"].ToString(), Session["DisclosureType"].ToString());
                else
                    lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(String.Empty, String.Empty, String.Empty, String.Empty);
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

                // GET REASON FOR FILING DATA.
                IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
                IList<ResigTermTypeModel> lstResigTermTypeModelResults = new List<ResigTermTypeModel>();
                ResigTermTypeModel objResigTermTypeModel;
                lstResigTermTypeModelResults = objItemizedReportsBroker.GeResigTermTypeDataResponse();
                objResigTermTypeModel = new ResigTermTypeModel();
                objResigTermTypeModel.ResigTermTypeId = "- Not Applicable -";
                objResigTermTypeModel.ResigTermTypeDesc = "- Not Applicable -";
                lstResigTermTypeModel.Add(objResigTermTypeModel);
                foreach (var item in lstResigTermTypeModelResults)
                {
                    if (item != null)
                    {
                        objResigTermTypeModel = new ResigTermTypeModel();
                        objResigTermTypeModel.ResigTermTypeId = item.ResigTermTypeId;
                        objResigTermTypeModel.ResigTermTypeDesc = item.ResigTermTypeDesc;
                        lstResigTermTypeModel.Add(objResigTermTypeModel);
                    }
                }
                // Bind Partner Data
                ViewData["lstResigTermType"] = new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc");
                // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
                // ===================================================================================================================================
                // THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
                // ===================================================================================================================================

                List<ItemizedModel> lstItemizedModel = new List<ItemizedModel>();
                ItemizedModel objItemizedModel;
                objItemizedModel = new ItemizedModel();
                objItemizedModel.strItemizedId = "Y";
                objItemizedModel.strItemizedName = "Yes";
                lstItemizedModel.Add(objItemizedModel);
                objItemizedModel = new ItemizedModel();
                objItemizedModel.strItemizedId = "N";
                objItemizedModel.strItemizedName = "No";
                lstItemizedModel.Add(objItemizedModel);
                // Bind Subcontractor
                ViewData["lstItemized"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
                ViewData["lstItemizedPart"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
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

                // ===================================================================================================================================
                // ADD THIS ONE ITS NEW CODE
                // Viewable Columns Default Values            
                IList<ViewableColumnModel> lstViewableColumns = new List<ViewableColumnModel>();
                lstViewableColumns = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
                Session["SorList"] = lstViewableColumns;
                //Bind Column Name
                ViewData["lstViewableColumns"] = new SelectList(lstViewableColumns, "ViewableFieldID", "ColumnName");
                // ADD THIS ONE ITS NEW CODE
                // ===================================================================================================================================

                // Sortable Columns.
                IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
                lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
                // Session["SorList"] = lstSortColumnName; // REMOVE SESSION HERE.....///===//===///
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
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDefaultLookUpsValues

        public JsonResult setSessionForFilings(String strElectionCycle, String strOfficeType, String strElectionType,
                                                String strElectionDate,
                                               String strDisclosureType, String strDisclosurePeriod, String strTransactionType,
                                               String strlstResigTermType, String strFilingDate, String strCutoffDate)
        {
            String strResult = "TRUE";
            Session["Import_ElectYearID"] = strElectionCycle;
            Session["Import_OfficeTypeID"] = strOfficeType;
            Session["Import_Election_Type_ID"] = strElectionType;
            Session["Import_Election_Date"] = strElectionDate;
            Session["Import_Disclosure_Type"] = strDisclosureType;
            Session["Import_Disclosure_Period"] = strDisclosurePeriod;
            Session["Import_Transaction_Type"] = strTransactionType;
            Session["Import_ResigTermType"] = strlstResigTermType;
            Session["Import_FilingDate"] = strFilingDate;
            Session["Import_CutoffDate"] = strCutoffDate;
            Session["Import_PCF_ShowWarning"] = "N";
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckFilingsData()
        {
            try
            {
                IList<ImportErrorMessageModel> lstImportErrorMessageModel = new List<ImportErrorMessageModel>();
                lstImportErrorMessageModel = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
                return Json(new
                {
                    aaData = lstImportErrorMessageModel.Select(x => new[] {
                    "",
                    x.RowNumber,
                    x.ColumnName,
                    x.ErrorMessages
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }

        public JsonResult CheckValidaion()
        {
            string resultsExistsValidation = string.Empty;

            IList<ImportErrorMessageModel> lstImportErrorMessageModel = new List<ImportErrorMessageModel>();
            lstImportErrorMessageModel = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
            if (lstImportErrorMessageModel.Any())
            {
                resultsExistsValidation = "YES";
            }
            else
            {
                Session["ErrorMessageGridData"] = null;
                resultsExistsValidation = "NO";
            }
            return Json(resultsExistsValidation, JsonRequestBehavior.AllowGet);
        }

        #region UploadImportDisclosureRptsData
        /// <summary>
        /// UploadImportDisclosureRptsData
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadImportDisclosureRptsData(HttpPostedFileBase data)
        {
            try
            {
                ImportDisclsoureRptsFilings objImportDisclsoureRptsFilings = new ImportDisclsoureRptsFilings();
                ImportErrorMessageModel objImportErrorMessageModel;
                Session["ErrorMessageGridData"] = null;
                Session["FilingTransactionDataUploadForSchedA"] = null;
                Session["IsPartnershipRecord"] = null;
                Session["Import_PCF_ShowWarning"] = "N";
                IList<ImportErrorMessageModel> lstErrorMessageGridData = new List<ImportErrorMessageModel>();

                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                FilingTransactionsModel objFilingTransactionsModel;

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
                        Session["FileSizeSchedA"] = resultFileSize;
                        Session["FileNameSchedA"] = Request.Files[upload].FileName;
                        // GET THE FILE NAME FROM FULL PATH.
                        FileInfo info = new FileInfo(Request.Files[upload].FileName);
                        Session["ImportFileNameSchedA"] = info.Name;
                        String csvPath = Session["FileNameSchedA"].ToString();


                        // TO CHECK EACH AND EVERY ROW THE COLUMN COUNT 58 OR NOT
                        // IF NOT THEN IT IS INSERTING RECORDS WHICH IF EXISTS COUNT = 58.
                        // SO IT SHOULE NOT INSERT ANY TRANSACTIONS IF ANY ONE ROW LESS OR MORE THAN 58 IN CSV.
                        // IT WILL BE ROLLBACK ALL THE TRANSACTIONS AND IT WILL NOT INSERT ANY.

                        if (info.Extension == ".csv")
                        {
                            StreamReader csvreader = new StreamReader(varStream);
                            int rowsCountCSV = 0;
                            while (!csvreader.EndOfStream)
                            {
                                // READ LINE
                                var line = csvreader.ReadLine();
                                if (line != null && line != "")
                                {
                                    // ROWS COUNT CSV.
                                    rowsCountCSV = rowsCountCSV + 1;

                                    // READ DATA.
                                    var values = line.Split(',');

                                    var count = values.Count();

                                    if (rowsCountCSV == 1 && (count == 15 || count == 27))
                                        ValidateImportHeaders(values); // DAVE ADDED VALIDATION FOR HEADERS

                                    if (Session["COMM_TYPE_ID"].ToString() != "23") // IS NOT A PCF FILER
                                    {
                                        if (count == 15) // IF CSV HAS TO SEND FULL 15 COLUMNS IF NO DATA THEN PUT NULL OR EMPTY. NOT LESS NOT MORE.
                                        {
                                            #region Get The Uploaded Data.
                                            // PUT CSV DATA INTO LIST.
                                            objFilingTransactionsModel = new FilingTransactionsModel();

                                            //Date Received - Start
                                            SetValidationMessage("SCHED_DATE", values[0], rowsCountCSV.ToString(), "SCHED_DATE", "");
                                            objFilingTransactionsModel.SchedDate = Convert.ToString(values[0]);
                                            if (objFilingTransactionsModel.SchedDate.ToUpper() == "NULL" || objFilingTransactionsModel.SchedDate == "")
                                                objFilingTransactionsModel.SchedDate = "";
                                            //Date Received - End

                                            //ContributorType - Start
                                            SetValidationMessage("CNTRBR_TYPE_DESC", values[1], rowsCountCSV.ToString(), "CNTRBR_TYPE_DESC", "");

                                            objFilingTransactionsModel.ContributorTypeDesc = Convert.ToString(values[1]);
                                            if (objFilingTransactionsModel.ContributorTypeDesc.ToUpper() == "NULL" || objFilingTransactionsModel.ContributorTypeDesc == "")
                                                objFilingTransactionsModel.ContributorTypeDesc = "";
                                            //ContributorType - END

                                            //First Name - Start
                                            SetValidationMessage("FLNG_ENT_FIRST_NAME", values[2], rowsCountCSV.ToString(), "FLNG_ENT_FIRST_NAME", values[1]);

                                            values[2] = values[2].Replace("%", ","); // First Name
                                            objFilingTransactionsModel.FlngEntFirstName = Convert.ToString(values[2]).Trim();
                                            if (objFilingTransactionsModel.FlngEntFirstName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntFirstName == "")
                                                objFilingTransactionsModel.FlngEntFirstName = "";
                                            //First Name - End

                                            //Middle Name - Start
                                            SetValidationMessage("FLNG_ENT_MIDDLE_NAME", values[3], rowsCountCSV.ToString(), "FLNG_ENT_MIDDLE_NAME", values[1]);
                                            values[3] = values[3].Replace("%", ","); // Middle Name
                                            objFilingTransactionsModel.FlngEntMiddleName = Convert.ToString(values[3]).Trim();
                                            if (objFilingTransactionsModel.FlngEntMiddleName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntMiddleName == "")
                                                objFilingTransactionsModel.FlngEntMiddleName = "";
                                            //Middle Name - End

                                            //Last Name - Start
                                            SetValidationMessage("FLNG_ENT_LAST_NAME", values[4], rowsCountCSV.ToString(), "FLNG_ENT_LAST_NAME", values[1]);
                                            values[4] = values[4].Replace("%", ","); // Last Name
                                            objFilingTransactionsModel.FlngEntLastName = Convert.ToString(values[4]).Trim();
                                            if (objFilingTransactionsModel.FlngEntLastName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntLastName == "")
                                                objFilingTransactionsModel.FlngEntLastName = "";
                                            //Last Name - End

                                            //Partnership Name - Start
                                            SetValidationMessage("FLNG_ENT_NAME", values[5], rowsCountCSV.ToString(), "FLNG_ENT_NAME", values[1]);
                                            values[5] = values[5].Replace("%", ","); // Partnership Name
                                            objFilingTransactionsModel.FlngEntName = Convert.ToString(values[5]).Trim();
                                            if (objFilingTransactionsModel.FlngEntName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntName == "")
                                                objFilingTransactionsModel.FlngEntName = "";
                                            //Partnership Name - End

                                            //Country Name - Start
                                            SetValidationMessage("FLNG_ENT_COUNTRY", values[6], rowsCountCSV.ToString(), "FLNG_ENT_COUNTRY", "");
                                            objFilingTransactionsModel.FlngEntCountry = Convert.ToString(values[6]).Trim();
                                            if (objFilingTransactionsModel.FlngEntCountry.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntCountry == "")
                                                objFilingTransactionsModel.FlngEntCountry = "";
                                            //Country Name - End

                                            //StreetAddress Name - Start
                                            SetValidationMessage("FLNG_ENT_ADD1", values[7], rowsCountCSV.ToString(), "FLNG_ENT_ADD1", "");
                                            values[7] = values[7].Replace("%", ","); // StreetAddress Name
                                            objFilingTransactionsModel.FlngEntStrName = Convert.ToString(values[7]).Trim();
                                            if (objFilingTransactionsModel.FlngEntStrName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntStrName == "")
                                                objFilingTransactionsModel.FlngEntStrName = "";
                                            //StreetAddress Name - End

                                            //City Name - Start
                                            SetValidationMessage("FLNG_ENT_CITY", values[8], rowsCountCSV.ToString(), "FLNG_ENT_CITY", values[6]);
                                            values[8] = values[8].Replace("%", ","); // City Name
                                            objFilingTransactionsModel.FlngEntCity = Convert.ToString(values[8]).Trim();
                                            if (objFilingTransactionsModel.FlngEntCity.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntCity == "")
                                                objFilingTransactionsModel.FlngEntCity = "";
                                            //City Name - End

                                            //State Name - Start
                                            SetValidationMessage("FLNG_ENT_STATE", values[9], rowsCountCSV.ToString(), "FLNG_ENT_STATE", values[6]);
                                            objFilingTransactionsModel.FlngEntState = Convert.ToString(values[9]).Trim();
                                            if (objFilingTransactionsModel.FlngEntState.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntState == "")
                                                objFilingTransactionsModel.FlngEntState = "";
                                            //State Name - End

                                            //ZipCode Name - Start
                                            SetValidationMessage("FLNG_ENT_ZIP", values[10], rowsCountCSV.ToString(), "FLNG_ENT_ZIP", values[6]);
                                            objFilingTransactionsModel.FlngEntZip = Convert.ToString(values[10]).Trim();
                                            if (objFilingTransactionsModel.FlngEntZip.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntZip == "")
                                                objFilingTransactionsModel.FlngEntZip = "";
                                            //ZipCode Name - End

                                            //Method Name - Start
                                            SetValidationMessage("PAYMENT_TYPE_DESC", values[11], rowsCountCSV.ToString(), "PAYMENT_TYPE_DESC", "");
                                            objFilingTransactionsModel.PaymentTypeDesc = Convert.ToString(values[11]);
                                            if (objFilingTransactionsModel.PaymentTypeDesc.ToUpper() == "NULL" || objFilingTransactionsModel.PaymentTypeDesc == "")
                                                objFilingTransactionsModel.PaymentTypeDesc = "";
                                            //Method Name - End

                                            //CHECKNUMBER Name - Start
                                            SetValidationMessage("PAY_NUMBER", values[12], rowsCountCSV.ToString(), "PAY_NUMBER", values[11]);
                                            objFilingTransactionsModel.PayNumber = Convert.ToString(values[12]);
                                            if (objFilingTransactionsModel.PayNumber.ToUpper() == "NULL" || objFilingTransactionsModel.PayNumber == "")
                                                objFilingTransactionsModel.PayNumber = "";
                                            //CHECKNUMBER Name - End

                                            //AMOUNT Name - Start
                                            SetValidationMessage("OWED_AMT", values[13], rowsCountCSV.ToString(), "OWED_AMT", "");
                                            objFilingTransactionsModel.OrgAmt = Convert.ToString(values[13]);
                                            if (objFilingTransactionsModel.OrgAmt.ToUpper() == "NULL" || objFilingTransactionsModel.OrgAmt == "")
                                                objFilingTransactionsModel.OrgAmt = "";
                                            //AMOUNT Name - End

                                            //Explanation Name - Start
                                            SetValidationMessage("TRANS_EXPLNTN", values[14], rowsCountCSV.ToString(), "TRANS_EXPLNTN", values[12]);
                                            values[14] = values[14].Replace("%", ","); // Explanation Name
                                            objFilingTransactionsModel.TransExplanation = Convert.ToString(values[14]);
                                            if (objFilingTransactionsModel.TransExplanation.ToUpper() == "NULL" || objFilingTransactionsModel.TransExplanation == "")
                                                objFilingTransactionsModel.TransExplanation = "";
                                            //Explanation Name - End                                            

                                            objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();
                                            objFilingTransactionsModel.ElectYearId = Session["Import_ElectYearID"].ToString();
                                            objFilingTransactionsModel.OfficeTypeId = Session["Import_OfficeTypeID"].ToString();
                                            objFilingTransactionsModel.ElectionTypeId = Session["Import_Election_Type_ID"].ToString();
                                            objFilingTransactionsModel.ElectionDateId = Session["Import_Election_Date"].ToString();
                                            objFilingTransactionsModel.FilingTypeId = Session["Import_Disclosure_Period"].ToString();
                                            // Dave added models below for PCFB enhancement
                                            objFilingTransactionsModel.IsClaim = "N"; // LOGIC FROM SP
                                            objFilingTransactionsModel.InDistrict = "";
                                            objFilingTransactionsModel.Minor = "";
                                            objFilingTransactionsModel.Vendor = "";
                                            objFilingTransactionsModel.Lobbyist = "";
                                            objFilingTransactionsModel.RContributions = "N"; // LOGIC FROM SP
                                            objFilingTransactionsModel.TreasurerEmployer = "";
                                            objFilingTransactionsModel.TreasurerOccupation = "";
                                            objFilingTransactionsModel.TreasurerStreetAddress = "";
                                            objFilingTransactionsModel.TreasurerCity = "";
                                            objFilingTransactionsModel.TreasurerState = "";
                                            objFilingTransactionsModel.TreasurerZip = "";

                                            if (Session["Import_ResigTermType"].ToString() == "- Not Applicable -")
                                            {
                                                objFilingTransactionsModel.ResigTermTypeId = "";
                                            }
                                            else
                                            {
                                                objFilingTransactionsModel.ResigTermTypeId = Session["Import_ResigTermType"].ToString();
                                            }

                                            objFilingTransactionsModel.FilingDate = Session["Import_FilingDate"].ToString();
                                            objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                                            objFilingTransactionsModel.Unique_Num = rowsCountCSV.ToString();

                                            if (rowsCountCSV != 1)
                                                lstFilingTransactionsModel.Add(objFilingTransactionsModel);

                                            #endregion Get The Uploaded Data.                                                        
                                        }
                                        else
                                        {
                                            lstErrorMessageGridData = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
                                            Session["RowCountMissingPositionForSchedA"] = rowsCountCSV.ToString();
                                            objImportErrorMessageModel = new ImportErrorMessageModel();
                                            objImportErrorMessageModel.RowNumber = "";
                                            objImportErrorMessageModel.ColumnName = "";
                                            objImportErrorMessageModel.ErrorMessages = "CSV requires 15 columns separated by 14 commas.";
                                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                                            if (lstErrorMessageGridData != null)
                                            {
                                                if (lstErrorMessageGridData.Any())
                                                {
                                                    Session["ErrorMessageGridData"] = lstErrorMessageGridData;
                                                }
                                                else
                                                {
                                                    Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                                }
                                            }
                                            else
                                            {
                                                Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                            }
                                            break;
                                        }
                                        lstErrorMessageGridData = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
                                        if (lstErrorMessageGridData != null)
                                        {
                                            if (lstErrorMessageGridData.Any())
                                            {
                                                Session["ErrorMessageGridData"] = lstErrorMessageGridData;
                                            }
                                            else
                                            {
                                                Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                            }
                                        }
                                        else
                                        {
                                            Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                        }
                                    } // DAVE ADDED PCF CASE BELOW
                                    else // IS A PCF COMMITTEE
                                    {
                                        if (count == 27) // IF CSV HAS TO SEND FULL 27 COLUMNS IF NO DATA THEN PUT NULL OR EMPTY. NOT LESS NOT MORE.
                                        {
                                            #region Get The Uploaded Data.
                                            // PUT CSV DATA INTO LIST.
                                            objFilingTransactionsModel = new FilingTransactionsModel();

                                            //Date Received - Start
                                            SetValidationMessage("SCHED_DATE", values[0].Trim(), rowsCountCSV.ToString(), "SCHED_DATE", "");
                                            objFilingTransactionsModel.SchedDate = Convert.ToString(values[0]).Trim();
                                            if (objFilingTransactionsModel.SchedDate.ToUpper() == "NULL" || objFilingTransactionsModel.SchedDate == "")
                                                objFilingTransactionsModel.SchedDate = "";
                                            //Date Received - End

                                            //ContributorType - Start
                                            SetValidationMessage("CNTRBR_TYPE_DESC", values[1].Trim(), rowsCountCSV.ToString(), "CNTRBR_TYPE_DESC", "");
                                            objFilingTransactionsModel.ContributorTypeDesc = Convert.ToString(values[1]).Trim();
                                            if (objFilingTransactionsModel.ContributorTypeDesc.ToUpper() == "NULL" || objFilingTransactionsModel.ContributorTypeDesc == "")
                                                objFilingTransactionsModel.ContributorTypeDesc = "";

                                            // Partnerships and Sole Proprietorships invalid if TransClaim is Y
                                            if (values[15].ToUpper().Trim() == "Y" || values[15].ToUpper().Trim() == "YES")
                                            {
                                                if (values[1].ToUpper().Trim() == "PARTNERSHIP INCLUDING LLPS" || values[1].ToUpper().Trim() == "SOLE PROPRIETORSHIP")
                                                {
                                                    objImportErrorMessageModel = new ImportErrorMessageModel();
                                                    objImportErrorMessageModel.RowNumber = rowsCountCSV.ToString();
                                                    objImportErrorMessageModel.ColumnName = "CNTRBR_TYPE_DESC";
                                                    objImportErrorMessageModel.ErrorMessages = "Contributor Type is incorrect. Refer the specification file for the allowable types";
                                                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                                                }
                                            }
                                            //ContributorType - END

                                            //First Name - Start
                                            SetValidationMessage("FLNG_ENT_FIRST_NAME", values[2].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_FIRST_NAME", values[1].Trim());
                                            values[2] = values[2].Replace("%", ","); // First Name
                                            objFilingTransactionsModel.FlngEntFirstName = Convert.ToString(values[2]).Trim();
                                            if (objFilingTransactionsModel.FlngEntFirstName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntFirstName == "")
                                                objFilingTransactionsModel.FlngEntFirstName = "";
                                            //First Name - End

                                            //Middle Name - Start
                                            SetValidationMessage("FLNG_ENT_MIDDLE_NAME", values[3].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_MIDDLE_NAME", values[1].Trim());
                                            values[3] = values[3].Replace("%", ","); // Middle Name
                                            objFilingTransactionsModel.FlngEntMiddleName = Convert.ToString(values[3]).Trim();
                                            if (objFilingTransactionsModel.FlngEntMiddleName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntMiddleName == "")
                                                objFilingTransactionsModel.FlngEntMiddleName = "";
                                            //Middle Name - End

                                            //Last Name - Start
                                            SetValidationMessage("FLNG_ENT_LAST_NAME", values[4].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_LAST_NAME", values[1].Trim());
                                            values[4] = values[4].Replace("%", ","); // Last Name
                                            objFilingTransactionsModel.FlngEntLastName = Convert.ToString(values[4]).Trim();
                                            if (objFilingTransactionsModel.FlngEntLastName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntLastName == "")
                                                objFilingTransactionsModel.FlngEntLastName = "";
                                            //Last Name - End

                                            //Partnership Name - Start
                                            SetValidationMessage("FLNG_ENT_NAME", values[5].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_NAME", values[1].Trim());
                                            values[5] = values[5].Replace("%", ","); // Partnership Name
                                            objFilingTransactionsModel.FlngEntName = Convert.ToString(values[5]).Trim();
                                            if (objFilingTransactionsModel.FlngEntName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntName == "")
                                                objFilingTransactionsModel.FlngEntName = "";
                                            //Partnership Name - End

                                            //Country Name - Start
                                            SetValidationMessage("FLNG_ENT_COUNTRY", values[6].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_COUNTRY", "");
                                            objFilingTransactionsModel.FlngEntCountry = Convert.ToString(values[6]).Trim();
                                            if (objFilingTransactionsModel.FlngEntCountry.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntCountry == "")
                                                objFilingTransactionsModel.FlngEntCountry = "";
                                            //Country Name - End

                                            //StreetAddress Name - Start
                                            SetValidationMessage("FLNG_ENT_ADD1", values[7].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_ADD1", "");
                                            values[7] = values[7].Replace("%", ","); // StreetAddress Name
                                            objFilingTransactionsModel.FlngEntStrName = Convert.ToString(values[7]).Trim();
                                            if (objFilingTransactionsModel.FlngEntStrName.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntStrName == "")
                                                objFilingTransactionsModel.FlngEntStrName = "";
                                            //StreetAddress Name - End

                                            //City Name - Start
                                            SetValidationMessage("FLNG_ENT_CITY", values[8].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_CITY", values[6].Trim());
                                            values[8] = values[8].Replace("%", ","); // City Name
                                            objFilingTransactionsModel.FlngEntCity = Convert.ToString(values[8]).Trim();
                                            if (objFilingTransactionsModel.FlngEntCity.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntCity == "")
                                                objFilingTransactionsModel.FlngEntCity = "";
                                            //City Name - End

                                            //State Name - Start
                                            SetValidationMessage("FLNG_ENT_STATE", values[9].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_STATE", values[6].Trim());
                                            objFilingTransactionsModel.FlngEntState = Convert.ToString(values[9]).Trim();
                                            if (objFilingTransactionsModel.FlngEntState.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntState == "")
                                                objFilingTransactionsModel.FlngEntState = "";
                                            //State Name - End

                                            //ZipCode Name - Start
                                            SetValidationMessage("FLNG_ENT_ZIP", values[10].Trim(), rowsCountCSV.ToString(), "FLNG_ENT_ZIP", values[6].Trim());
                                            objFilingTransactionsModel.FlngEntZip = Convert.ToString(values[10]).Trim();
                                            if (objFilingTransactionsModel.FlngEntZip.ToUpper() == "NULL" || objFilingTransactionsModel.FlngEntZip == "")
                                                objFilingTransactionsModel.FlngEntZip = "";
                                            //ZipCode Name - End

                                            //Method Name - Start
                                            SetValidationMessage("PAYMENT_TYPE_DESC", values[11].Trim(), rowsCountCSV.ToString(), "PAYMENT_TYPE_DESC", "");
                                            objFilingTransactionsModel.PaymentTypeDesc = Convert.ToString(values[11]).Trim();
                                            if (objFilingTransactionsModel.PaymentTypeDesc.ToUpper() == "NULL" || objFilingTransactionsModel.PaymentTypeDesc == "")
                                                objFilingTransactionsModel.PaymentTypeDesc = "";
                                            //Method Name - End

                                            //CHECKNUMBER Name - Start
                                            SetValidationMessage("PAY_NUMBER", values[12].Trim(), rowsCountCSV.ToString(), "PAY_NUMBER", values[11].Trim());
                                            objFilingTransactionsModel.PayNumber = Convert.ToString(values[12]).Trim();
                                            if (objFilingTransactionsModel.PayNumber.ToUpper() == "NULL" || objFilingTransactionsModel.PayNumber == "")
                                                objFilingTransactionsModel.PayNumber = "";
                                            //CHECKNUMBER Name - End

                                            //AMOUNT Name - Start
                                            SetValidationMessage("OWED_AMT", values[13].Trim(), rowsCountCSV.ToString(), "OWED_AMT", "");
                                            objFilingTransactionsModel.OrgAmt = Convert.ToString(values[13]).Trim();
                                            if (objFilingTransactionsModel.OrgAmt.ToUpper() == "NULL" || objFilingTransactionsModel.OrgAmt == "")
                                                objFilingTransactionsModel.OrgAmt = "";
                                            //AMOUNT Name - End

                                            //Explanation Name - Start
                                            SetValidationMessage("TRANS_EXPLNTN", values[14].Trim(), rowsCountCSV.ToString(), "TRANS_EXPLNTN", values[12].Trim());
                                            values[14] = values[14].Replace("%", ","); // Explanation Name
                                            objFilingTransactionsModel.TransExplanation = Convert.ToString(values[14]).Trim();
                                            if (objFilingTransactionsModel.TransExplanation.ToUpper() == "NULL" || objFilingTransactionsModel.TransExplanation == "")
                                                objFilingTransactionsModel.TransExplanation = "";
                                            //Explanation Name - End

                                            //Is transaction Being Submitted for Claim? - Start
                                            SetValidationMessage("R_CLAIM", values[15].Trim(), rowsCountCSV.ToString(), "R_CLAIM", "");
                                            values[15] = values[15].Replace("%", ",");
                                            objFilingTransactionsModel.IsClaim = Convert.ToString(values[15]).Trim();
                                            if (objFilingTransactionsModel.IsClaim.ToUpper() == "NULL" || objFilingTransactionsModel.IsClaim == "")
                                                objFilingTransactionsModel.IsClaim = "";
                                            else if (objFilingTransactionsModel.IsClaim.ToUpper() == "YES")
                                                objFilingTransactionsModel.IsClaim = "Y";                                            
                                            else if (objFilingTransactionsModel.IsClaim.ToUpper() == "NO")
                                                objFilingTransactionsModel.IsClaim = "N";
                                            else if (objFilingTransactionsModel.IsClaim.ToUpper() == "Y")
                                                objFilingTransactionsModel.IsClaim = "Y";
                                            else if (objFilingTransactionsModel.IsClaim.ToUpper() == "N")
                                                objFilingTransactionsModel.IsClaim = "N";
                                            //Is transaction Being Submitted for Claim? - End

                                            //In District? - Start
                                            SetValidationMessage("R_IN_DISTRICT", values[16].Trim(), rowsCountCSV.ToString(), "R_IN_DISTRICT", values[15].Trim());
                                            values[16] = values[16].Replace("%", ",");
                                            objFilingTransactionsModel.InDistrict = Convert.ToString(values[16]).Trim();
                                            if (values[15].Trim() == "N" || values[15].Trim() == "NO") // only available when R_CLAIM is 'Y'
                                                objFilingTransactionsModel.InDistrict = "";
                                            else if (objFilingTransactionsModel.InDistrict.ToUpper() == "NULL" || objFilingTransactionsModel.InDistrict == "")
                                                objFilingTransactionsModel.InDistrict = "";
                                            else if (objFilingTransactionsModel.InDistrict.ToUpper() == "YES")
                                                objFilingTransactionsModel.InDistrict = "Y";
                                            else if (objFilingTransactionsModel.InDistrict.ToUpper() == "NO")
                                                objFilingTransactionsModel.InDistrict = "N";
                                            else if (objFilingTransactionsModel.InDistrict.ToUpper() == "Y")
                                                objFilingTransactionsModel.InDistrict = "Y";
                                            else if (objFilingTransactionsModel.InDistrict.ToUpper() == "N")
                                                objFilingTransactionsModel.InDistrict = "N";
                                            //In District? - End

                                            //Minor? - Start
                                            SetValidationMessage("R_MINOR", values[17].Trim(), rowsCountCSV.ToString(), "R_MINOR", values[15].Trim());
                                            values[17] = values[17].Replace("%", ",");
                                            objFilingTransactionsModel.Minor = Convert.ToString(values[17]).Trim();
                                            if (values[15].Trim() == "N" || values[15].Trim() == "NO") // only available when R_CLAIM is 'Y'
                                                objFilingTransactionsModel.Minor = "";
                                            else if (objFilingTransactionsModel.Minor.ToUpper() == "NULL")
                                                objFilingTransactionsModel.Minor = "";
                                            else if (objFilingTransactionsModel.Minor.ToUpper() == "YES")
                                                objFilingTransactionsModel.Minor = "Y";
                                            else if (objFilingTransactionsModel.Minor.ToUpper() == "NO")
                                                objFilingTransactionsModel.Minor = "N";
                                            else if (objFilingTransactionsModel.Minor.ToUpper() == "Y")
                                                objFilingTransactionsModel.Minor = "Y";
                                            else if (objFilingTransactionsModel.Minor.ToUpper() == "N")
                                                objFilingTransactionsModel.Minor = "N";
                                            //Minor? - End

                                            //Vendor? - Start
                                            SetValidationMessage("R_VENDOR", values[18].Trim(), rowsCountCSV.ToString(), "R_VENDOR", values[15].Trim());
                                            values[18] = values[18].Replace("%", ",");
                                            objFilingTransactionsModel.Vendor = Convert.ToString(values[18]).Trim();
                                            if (values[15].Trim() == "N" || values[15].Trim() == "NO") // only available when R_CLAIM is 'Y'
                                                objFilingTransactionsModel.Vendor = "";
                                            else if (objFilingTransactionsModel.Vendor.ToUpper() == "NULL")
                                                objFilingTransactionsModel.Vendor = "";
                                            else if (objFilingTransactionsModel.Vendor.ToUpper() == "YES")
                                                objFilingTransactionsModel.Vendor = "Y";
                                            else if (objFilingTransactionsModel.Vendor.ToUpper() == "NO")
                                                objFilingTransactionsModel.Vendor = "N";
                                            else if (objFilingTransactionsModel.Vendor.ToUpper() == "Y")
                                                objFilingTransactionsModel.Vendor = "Y";
                                            else if (objFilingTransactionsModel.Vendor.ToUpper() == "N")
                                                objFilingTransactionsModel.Vendor = "N";
                                            //Vendor? - End

                                            //Lobbyist? - Start
                                            SetValidationMessage("R_LOBBYIST", values[19].Trim(), rowsCountCSV.ToString(), "R_LOBBYIST", values[15].Trim());
                                            values[19] = values[19].Replace("%", ",");
                                            objFilingTransactionsModel.Lobbyist = Convert.ToString(values[19]).Trim();
                                            if (values[15].Trim() == "N" || values[15].Trim() == "NO") // only available when R_CLAIM is 'Y'
                                                objFilingTransactionsModel.Lobbyist = "";
                                            if (objFilingTransactionsModel.Lobbyist.ToUpper() == "NULL" || objFilingTransactionsModel.Lobbyist == "")
                                                objFilingTransactionsModel.Lobbyist = "";
                                            else if (objFilingTransactionsModel.Lobbyist.ToUpper() == "YES")
                                                objFilingTransactionsModel.Lobbyist = "Y";
                                            else if (objFilingTransactionsModel.Lobbyist.ToUpper() == "NO")
                                                objFilingTransactionsModel.Lobbyist = "N";
                                            else if (objFilingTransactionsModel.Lobbyist.ToUpper() == "Y")
                                                objFilingTransactionsModel.Lobbyist = "Y";
                                            else if (objFilingTransactionsModel.Lobbyist.ToUpper() == "N")
                                                objFilingTransactionsModel.Lobbyist = "N";
                                            //Lobbyist? - End

                                            //Is Contribution greater than or equal to $100 in the aggregate? - Start
                                            SetValidationMessage("R_CONTRIBUTIONS", values[20].Trim(), rowsCountCSV.ToString(), "R_CONTRIBUTIONS", "");
                                            values[20] = values[20].Replace("%", ",");
                                            objFilingTransactionsModel.RContributions = Convert.ToString(values[20]).Trim();
                                            if (objFilingTransactionsModel.RContributions.ToUpper() == "NULL" || objFilingTransactionsModel.RContributions == "")
                                                objFilingTransactionsModel.RContributions = "";
                                            else if (objFilingTransactionsModel.RContributions.ToUpper() == "YES")
                                                objFilingTransactionsModel.RContributions = "Y";
                                            else if (objFilingTransactionsModel.RContributions.ToUpper() == "NO")
                                                objFilingTransactionsModel.RContributions = "N";
                                            else if (objFilingTransactionsModel.RContributions.ToUpper() == "Y")
                                                objFilingTransactionsModel.RContributions = "Y";
                                            else if (objFilingTransactionsModel.RContributions.ToUpper() == "N")
                                                objFilingTransactionsModel.RContributions = "N";

                                            //Is Contribution greater than or equal to $100 in the aggregate? - End

                                            //Employer - Start
                                            SetValidationMessage("TREAS_EMPLOYER", values[21].Trim(), rowsCountCSV.ToString(), "TREAS_EMPLOYER", values[20].Trim());
                                            values[21] = values[21].Replace("%", ",");
                                            objFilingTransactionsModel.TreasurerEmployer = Convert.ToString(values[21]).Trim();
                                            if (values[20].Trim() == "N" || values[20].Trim() == "NO") // only available when R_CONTRIBUTION is 'Y'
                                                objFilingTransactionsModel.TreasurerEmployer = "";
                                            else if (objFilingTransactionsModel.TreasurerEmployer.ToUpper() == "NULL" || objFilingTransactionsModel.TreasurerEmployer == "")
                                                objFilingTransactionsModel.TreasurerEmployer = "";
                                            //Employer - End

                                            //Occupation - Start
                                            SetValidationMessage("TREAS_OCCUPATION", values[22].Trim(), rowsCountCSV.ToString(), "TREAS_OCCUPATION", values[20].Trim());
                                            values[22] = values[22].Replace("%", ",");
                                            objFilingTransactionsModel.TreasurerOccupation = Convert.ToString(values[22]).Trim();
                                            if (values[20].Trim() == "N" || values[20].Trim() == "NO") // only available when R_CONTRIBUTION is 'Y'
                                                objFilingTransactionsModel.TreasurerOccupation = "";
                                            else if (objFilingTransactionsModel.TreasurerOccupation.ToUpper() == "NULL" || objFilingTransactionsModel.TreasurerOccupation == "")
                                                objFilingTransactionsModel.TreasurerOccupation = "";
                                            //Occupation - End

                                            //Employer Street Address - Start
                                            SetValidationMessage("ADDR_ADDR1", values[23].Trim(), rowsCountCSV.ToString(), "ADDR_ADDR1", values[20].Trim());
                                            values[23] = values[23].Replace("%", ",");
                                            objFilingTransactionsModel.TreasurerStreetAddress = Convert.ToString(values[23]).Trim();
                                            if (values[20].Trim() == "N" || values[20].Trim() == "NO") // only available when R_CONTRIBUTION is 'Y'
                                                objFilingTransactionsModel.TreasurerStreetAddress = "";
                                            else if (objFilingTransactionsModel.TreasurerStreetAddress.ToUpper() == "NULL" || objFilingTransactionsModel.TreasurerStreetAddress == "")
                                                objFilingTransactionsModel.TreasurerStreetAddress = "";
                                            //Employer Street Address - End

                                            //Employer City - Start
                                            SetValidationMessage("ADDR_CITY", values[24].Trim(), rowsCountCSV.ToString(), "ADDR_CITY", values[20].Trim());
                                            values[24] = values[24].Replace("%", ",");
                                            objFilingTransactionsModel.TreasurerCity = Convert.ToString(values[24]).Trim();
                                            if (values[20].Trim() == "N" || values[20].Trim() == "NO") // only available when R_CONTRIBUTION is 'Y'
                                                objFilingTransactionsModel.TreasurerCity = "";
                                            else if (objFilingTransactionsModel.TreasurerCity.ToUpper() == "NULL" || objFilingTransactionsModel.TreasurerCity == "")
                                                objFilingTransactionsModel.TreasurerCity = "";
                                            //Employer City - End

                                            //Employer State - Start
                                            SetValidationMessage("ADDR_STATE", values[25].Trim(), rowsCountCSV.ToString(), "ADDR_STATE", values[20].Trim());
                                            values[25] = values[25].Replace("%", ",");
                                            objFilingTransactionsModel.TreasurerState = Convert.ToString(values[25]).Trim();
                                            if (values[20].Trim() == "N" || values[20].Trim() == "NO") // only available when R_CONTRIBUTION is 'Y'
                                                objFilingTransactionsModel.TreasurerState = "";
                                            else if (objFilingTransactionsModel.TreasurerState.ToUpper() == "NULL" || objFilingTransactionsModel.TreasurerState == "")
                                                objFilingTransactionsModel.TreasurerState = "";
                                            //Employer State - End

                                            //Employer Zip - Start
                                            SetValidationMessage("ADDR_ZIP", values[26].Trim(), rowsCountCSV.ToString(), "ADDR_ZIP", values[20].Trim());
                                            values[26] = values[26].Replace("%", ",");
                                            objFilingTransactionsModel.TreasurerZip = Convert.ToString(values[26]).Trim();
                                            if (values[20].Trim() == "N" || values[20].Trim() == "NO") // only available when R_CONTRIBUTION is 'Y'
                                                objFilingTransactionsModel.TreasurerZip = "";
                                            else if (objFilingTransactionsModel.TreasurerZip.ToUpper() == "NULL" || objFilingTransactionsModel.TreasurerZip == "")
                                                objFilingTransactionsModel.TreasurerZip = "";
                                            //Employer Zip - End

                                            objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();
                                            objFilingTransactionsModel.ElectYearId = Session["Import_ElectYearID"].ToString();
                                            objFilingTransactionsModel.OfficeTypeId = Session["Import_OfficeTypeID"].ToString();
                                            objFilingTransactionsModel.ElectionTypeId = Session["Import_Election_Type_ID"].ToString();
                                            objFilingTransactionsModel.ElectionDateId = Session["Import_Election_Date"].ToString();
                                            objFilingTransactionsModel.FilingTypeId = Session["Import_Disclosure_Period"].ToString();
                                            if (Session["Import_ResigTermType"].ToString() == "- Not Applicable -")
                                            {
                                                objFilingTransactionsModel.ResigTermTypeId = "";
                                            }
                                            else
                                            {
                                                objFilingTransactionsModel.ResigTermTypeId = Session["Import_ResigTermType"].ToString();
                                            }

                                            objFilingTransactionsModel.FilingDate = Session["Import_FilingDate"].ToString();
                                            objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                                            objFilingTransactionsModel.Unique_Num = rowsCountCSV.ToString();

                                            if (rowsCountCSV != 1)
                                                lstFilingTransactionsModel.Add(objFilingTransactionsModel);

                                            #endregion Get The Uploaded Data.                                                        
                                        }
                                        else
                                        {
                                            Session["RowCountMissingPositionForSchedA"] = rowsCountCSV.ToString();
                                            objImportErrorMessageModel = new ImportErrorMessageModel();
                                            objImportErrorMessageModel.RowNumber = "";
                                            objImportErrorMessageModel.ColumnName = "";
                                            objImportErrorMessageModel.ErrorMessages = "CSV requires 27 columns separated by 26 commas.";
                                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                                            lstErrorMessageGridData = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
                                            if (lstErrorMessageGridData != null)
                                            {
                                                if (lstErrorMessageGridData.Any())
                                                {
                                                    Session["ErrorMessageGridData"] = lstErrorMessageGridData;
                                                }
                                                else
                                                {
                                                    Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                                }
                                            }
                                            else
                                            {
                                                Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                            }
                                            break;
                                        }
                                        lstErrorMessageGridData = (IList<ImportErrorMessageModel>)Session["ErrorMessageGridData"];
                                        if (lstErrorMessageGridData != null)
                                        {
                                            if (lstErrorMessageGridData.Any())
                                            {
                                                Session["ErrorMessageGridData"] = lstErrorMessageGridData;
                                            }
                                            else
                                            {
                                                Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                            }
                                        }
                                        else
                                        {
                                            Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                        }
                                    }
                                }
                                else
                                {
                                    objImportErrorMessageModel = new ImportErrorMessageModel();
                                    objImportErrorMessageModel.RowNumber = "";
                                    objImportErrorMessageModel.ColumnName = "";
                                    objImportErrorMessageModel.ErrorMessages = "Only CSV files are allowed.";
                                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                                    Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = "";
                            objImportErrorMessageModel.ColumnName = "";
                            objImportErrorMessageModel.ErrorMessages = "Only CSV files are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                            Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                            break;
                        }                                                                    
                        Session["FilingTransactionDataUploadForSchedA"] = lstFilingTransactionsModel;
                    }
                    else
                    {
                        Session["FilingTransactionDataUploadForSchedA"] = null;
                    }
                }

                bool notNull = lstFilingTransactionsModel != null && lstErrorMessageGridData != null && lstImportErrorMessageModel != null;
                bool allNull = lstFilingTransactionsModel == null && lstErrorMessageGridData == null && lstImportErrorMessageModel == null;

                if (notNull)
                {
                    if (!lstFilingTransactionsModel.Any() && !lstErrorMessageGridData.Any() && !lstImportErrorMessageModel.Any())
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = "2+";
                        objImportErrorMessageModel.ColumnName = "All";
                        objImportErrorMessageModel.ErrorMessages = "CSV file does not contain data";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                    }
                }
                else if (allNull)
                {

                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "2+";
                    objImportErrorMessageModel.ColumnName = "All";
                    objImportErrorMessageModel.ErrorMessages = "CSV file does not contain data";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                }

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ImportDisclosureReportController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UploadImportDisclosureRptsData

        public void SetValidationMessage(string varColumnName, string varColumnValue, string rowNumber, string ColumnName, string ddlVal)
        {

            ImportErrorMessageModel objImportErrorMessageModel;
            var regexItem = new Regex("^[a-zA-Z0-9 #'.,&()%-]*$");
            var regexItemCheckNumber = new Regex("^[a-zA-Z0-9]*$");
            var regexItemCity = new Regex("^[a-zA-Z #'.,%-]*$");
            string[] arrYesNo = { "YES", "NO", "Y", "N" };

            if (rowNumber == "1")
                return;
            
            //Date Received Validation
            if (varColumnName == "SCHED_DATE")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Date Received is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    Regex re = new Regex(@"^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$");
                    Match match = re.Match(varColumnValue);

                    //Verify whether entered date is Valid date.
                    DateTime dt;
                    
                    if (!match.Success)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Enter valid date format (MM/DD/YYYY)";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else if (!DateTime.TryParse(varColumnValue, out dt))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Enter valid date format (MM/DD/YYYY)";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(varColumnValue, Session["Import_CutoffDate"].ToString()))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Date Received cannot be later than Cut Off Date";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
            }

            //Contributor Type Validation
            if (varColumnName == "CNTRBR_TYPE_DESC")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Contributor Type is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (varColumnValue.ToUpper() == "CANDIDATE FAMILY MEMBER" ||
                        varColumnValue.ToUpper() == "CANDIDATE/CANDIDATE SPOUSE" ||
                        varColumnValue.ToUpper() == "INDIVIDUAL" ||
                        varColumnValue.ToUpper() == "PARTNERSHIP INCLUDING LLPS" ||
                        varColumnValue.ToUpper() == "SOLE PROPRIETORSHIP")
                    {

                    }
                    else
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Contributor Type is incorrect. Refer the specification file for the allowable types";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //First Name Validation
            if (varColumnName == "FLNG_ENT_FIRST_NAME")
            {
                if (ddlVal.ToUpper() == "CANDIDATE FAMILY MEMBER" ||
                        ddlVal.ToUpper() == "CANDIDATE/CANDIDATE SPOUSE" ||
                        ddlVal.ToUpper() == "INDIVIDUAL" ||
                        ddlVal.ToUpper() == "SOLE PROPRIETORSHIP")
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "First Name is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!regexItem.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -.,&() are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }

                        if (varColumnValue.Length > 30)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "First Name should be 30 characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (ddlVal.ToUpper() == "PARTNERSHIP INCLUDING LLPS")
                {
                    if (varColumnValue != "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "First Name is not required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Middle Name Validation
            if (varColumnName == "FLNG_ENT_MIDDLE_NAME")
            {
                if (ddlVal.ToUpper() == "CANDIDATE FAMILY MEMBER" ||
                        ddlVal.ToUpper() == "CANDIDATE/CANDIDATE SPOUSE" ||
                        ddlVal.ToUpper() == "INDIVIDUAL" ||
                        ddlVal.ToUpper() == "SOLE PROPRIETORSHIP")
                {
                    if (!regexItem.IsMatch(varColumnValue))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -.,&() are allowed";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }

                    if (varColumnValue.Length > 30)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Middle Name should be 30 characters or less";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
                else if (ddlVal.ToUpper() == "PARTNERSHIP INCLUDING LLPS")
                {
                    if (varColumnValue != "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Middle Name is not required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Last Name Validation
            if (varColumnName == "FLNG_ENT_LAST_NAME")
            {
                if (ddlVal.ToUpper() == "CANDIDATE FAMILY MEMBER" ||
                        ddlVal.ToUpper() == "CANDIDATE/CANDIDATE SPOUSE" ||
                        ddlVal.ToUpper() == "INDIVIDUAL" ||
                        ddlVal.ToUpper() == "SOLE PROPRIETORSHIP")
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Last Name is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!regexItem.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -.,&() are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }

                        if (varColumnValue.Length > 30)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Last Name should be 30 characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (ddlVal.ToUpper() == "PARTNERSHIP INCLUDING LLPS")
                {
                    if (varColumnValue != "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Last Name is not required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }

            }

            //Partnership Name Validation
            if (varColumnName == "FLNG_ENT_NAME")
            {
                if (ddlVal.ToUpper() == "PARTNERSHIP INCLUDING LLPS")
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Partnership Name is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!regexItem.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -.,&() are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }

                        if (varColumnValue.Length > 40)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Partnership Name should be 40 characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (ddlVal.ToUpper() == "CANDIDATE FAMILY MEMBER" ||
                        ddlVal.ToUpper() == "CANDIDATE/CANDIDATE SPOUSE" ||
                        ddlVal.ToUpper() == "INDIVIDUAL" ||
                        ddlVal.ToUpper() == "SOLE PROPRIETORSHIP")
                {
                    if (varColumnValue != "" && varColumnValue.ToUpper() != "NULL")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Partnership Name is not required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Country Validation
            if (varColumnName == "FLNG_ENT_COUNTRY")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Country is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    var regexItemCountry = new Regex("^[a-zA-Z ]+$");
                    if (!regexItemCountry.IsMatch(varColumnValue))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Letters are allowed";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }

                    if (varColumnValue.Length > 30)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Country should be 30 characters or less";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Street Address Validation
            if (varColumnName == "FLNG_ENT_ADD1")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Street Address is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (!regexItem.IsMatch(varColumnValue))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -., are allowed";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }

                    if (varColumnValue.Length > 60)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Street Address should be 60 characters or less";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //City Validation
            if (varColumnName == "FLNG_ENT_CITY")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "City is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (ddlVal.ToUpper() == "UNITED STATES")
                    {
                        if (!regexItemCity.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Letters and characters '# -., are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        if (!regexItem.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -., are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }

                    if (varColumnValue.Length > 30)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "City should be 30 characters or less";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //State Validation
            if (varColumnName == "FLNG_ENT_STATE")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "State is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (ddlVal.ToUpper() == "UNITED STATES")
                    {
                        if (varColumnValue.Length > 2)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Two letters are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        if (varColumnValue.Length > 30)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "State should be 30 characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
            }

            //Zip Code Validation
            if (varColumnName == "FLNG_ENT_ZIP")
            {
                var regexItemUSZip = new Regex("^[0-9]{5}(?:-[0-9]{4})?$");
                var regexItemOtherZip = new Regex("^[a-zA-Z0-9 -]*$");
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Zip Code is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (ddlVal.ToUpper() == "UNITED STATES")
                    {
                        if (!regexItemUSZip.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Numbers and - are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        if (!regexItemOtherZip.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Letters, numbers and - are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }

                    if (varColumnValue.Length > 10)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Zip Code should be 10 characters or less";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Method Validation
            if (varColumnName == "PAYMENT_TYPE_DESC")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Method is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (varColumnValue.ToUpper() == "CHECK" ||
                        varColumnValue.ToUpper() == "CREDIT CARD" ||
                        varColumnValue.ToUpper() == "DEBIT CARD" ||
                        varColumnValue.ToUpper() == "ONLINE PROCESSOR" ||
                        varColumnValue.ToUpper() == "WIRE TRANSFER" ||
                        varColumnValue.ToUpper() == "CASH" ||
                        varColumnValue.ToUpper() == "OTHER" ||
                        varColumnValue.ToUpper() == "MONEY ORDER")
                    {

                    }
                    else
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Method entered is not valid. Refer specification file for proper value";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Check Number Validation
            if (varColumnName == "PAY_NUMBER")
            {
                if (ddlVal.ToUpper() == "CHECK")
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                        objImportErrorMessageModel.ErrorMessages = "Check # is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!regexItemCheckNumber.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                            objImportErrorMessageModel.ErrorMessages = "Letters and numbers are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }

                        if (varColumnValue.Length > 30)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                            objImportErrorMessageModel.ErrorMessages = "Check# should be 30 characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (ddlVal.ToUpper() == "MONEY ORDER")
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                        objImportErrorMessageModel.ErrorMessages = "Money Order # is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!regexItemCheckNumber.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                            objImportErrorMessageModel.ErrorMessages = "Letters and numbers are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }

                        if (varColumnValue.Length > 30)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                            objImportErrorMessageModel.ErrorMessages = "Money Order # should be 30 characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else
                {
                    if (varColumnValue != "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                        objImportErrorMessageModel.ErrorMessages = "Check/Money Order # is not required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Amount Validation
            if (varColumnName == "OWED_AMT")
            {

                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Amount is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    var regexItemAmount = new Regex(@"^\d{0,9}\.\d{0,2}$|^\d{0,12}$");
                    string valAmount = "9";

                    if (!regexItemAmount.IsMatch(varColumnValue))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Enter valid Amount (999999999.99)";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        return;
                    }

                    if (Int32.Parse(varColumnValue.Length.ToString()) > Int32.Parse(valAmount))
                    {
                        if (varColumnValue.IndexOf('.') > -1)
                        {

                        }
                        else
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Enter valid Amount (999999999.99)";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                            return;
                        }
                    }

                    if (varColumnValue == "0.00" || varColumnValue == "0.0" ||
                        varColumnValue == "0" || varColumnValue == ".0" || varColumnValue == ".00")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Enter valid Amount (999999999.99)";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        return;
                    }

                    if (varColumnValue.Length > 12)
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Amount should be 12 characters or less";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //Explanation Validation
            if (varColumnName == "TRANS_EXPLNTN")
            {
                if (ddlVal.ToUpper() == "OTHER")
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Explanation is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }

                if (!regexItem.IsMatch(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Letters, numbers and characters '# -., are allowed";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }

                if (varColumnValue.Length > 250)
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Explanation should be 250 characters or less";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            // DAVE ADDED PCF FIELDS BELOW
            //Is Transaction Being Submitted for Claim Validation
            if (varColumnName == "R_CLAIM")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Is Transaction Being Submitted for Claim is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (!arrYesNo.Contains(varColumnValue.ToUpper()))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Is Transaction Being Submitted for Claim entered is not valid. Refer specification file for proper value";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            //In District Validation
            if (varColumnName == "R_IN_DISTRICT")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES") // only required when yes is selected for R_CLAIM
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "In District is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!arrYesNo.Contains(varColumnValue.ToUpper()))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "In District entered is not valid. Refer specification file for proper value";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "In District must be null if transaction is not being submitted for claim";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Minor Validation
            if (varColumnName == "R_MINOR")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES") // only required when yes is selected for R_CLAIM
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Minor is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!arrYesNo.Contains(varColumnValue.ToUpper()))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Minor entered is not valid. Refer specification file for proper value";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Minor must be null if transaction is not being submitted for claim";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Vendor Validation
            if (varColumnName == "R_VENDOR")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only required when yes is selected for R_CLAIM
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Vendor is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!arrYesNo.Contains(varColumnValue.ToUpper()))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Vendor entered is not valid. Refer specification file for proper value";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Vendor must be null if transaction is not being submitted for claim";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Lobbyist Validation
            if (varColumnName == "R_LOBBYIST")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only required when yes is selected for R_CLAIM
                {
                    if (varColumnValue == null || varColumnValue == "")
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Lobbyist is required";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                    else
                    {
                        if (!arrYesNo.Contains(varColumnValue.ToUpper()))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Lobbyist entered is not valid. Refer specification file for proper value";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Lobbyist must be null if transaction is not being submitted for claim";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //RContributions Validation
            if (varColumnName == "R_CONTRIBUTIONS")
            {
                if (varColumnValue == null || varColumnValue == "")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Is Contribution greater than or equal to $100 in the aggregate is required";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                else
                {
                    if (!arrYesNo.Contains(varColumnValue.ToUpper()))
                    {
                        objImportErrorMessageModel = new ImportErrorMessageModel();
                        objImportErrorMessageModel.RowNumber = rowNumber;
                        objImportErrorMessageModel.ColumnName = ColumnName;
                        objImportErrorMessageModel.ErrorMessages = "Is Contribution greater than or equal to $100 in the aggregate entered is not valid. Refer specification file for proper value";
                        lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                    }
                }
            }

            const int treasEmployerLength = 200;

            //TreasEmployer Validation
            if (varColumnName == "TREAS_EMPLOYER")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only read when yes is selected for R_CONTRIBUTIONS
                {
                    if (!string.IsNullOrEmpty(varColumnValue)) // not required, but validate if data entered
                    {
                        if (varColumnValue.Length > byte.MaxValue)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = $"Employer should be {treasEmployerLength} characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        Session["Import_PCF_ShowWarning"] = "Y"; // show warning message dialog
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Employer must be null if contribution is not greater than or equal to $100 in the aggregate";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Occupation Validation
            const int treasOccupationLength = 50;
            
            if (varColumnName == "TREAS_OCCUPATION")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only read when yes is selected for R_CONTRIBUTIONS
                {
                    if (!string.IsNullOrEmpty(varColumnValue)) // field not required, but validate if entered
                    {
                        if (varColumnValue.Length > treasOccupationLength)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = $"Occupation should be {treasOccupationLength} characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        Session["Import_PCF_ShowWarning"] = "Y"; // show warning message dialog
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Occupation must be null if contribution is not greater than or equal to $100 in the aggregate";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Employer Street Address Validation
            const int addr1Length = 60;
            
            if (varColumnName == "ADDR_ADDR1")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only required when yes is selected for R_CONTRIBUTIONS
                {
                    if (!string.IsNullOrEmpty(varColumnValue)) // field not required, but validate if entered
                    {
                        if (varColumnValue.Length > addr1Length)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = $"Employer Street Address should be {addr1Length} characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        Session["Import_PCF_ShowWarning"] = "Y"; // show warning message dialog
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Employer Street Address must be null if contribution is not greater than or equal to $100 in the aggregate";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Employer City Validation
            const int cityLength = 30;
            
            if (varColumnName == "ADDR_CITY")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only read when yes is selected for R_CONTRIBUTIONS
                {
                    if (!string.IsNullOrEmpty(varColumnValue)) // field not required, but validate if entered
                    {
                        if (varColumnValue.Length > cityLength)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = $"Employer City should be {cityLength} characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        Session["Import_PCF_ShowWarning"] = "Y"; // show warning message dialog
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Employer City must be null if contribution is not greater than or equal to $100 in the aggregate";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Employer State Validation
            const int stateCodeLength = 2;
  
            if (varColumnName == "ADDR_STATE")
            {
                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES") // only read when yes is selected for R_CONTRIBUTIONS
                {
                    if (!string.IsNullOrEmpty(varColumnValue)) // field not required, but validate if entered
                    {
                        if (varColumnValue.Length > stateCodeLength)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = $"Employer State should be {stateCodeLength} characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        Session["Import_PCF_ShowWarning"] = "Y"; // show warning message dialog
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Employer State must be null if contribution is not greater than or equal to $100 in the aggregate";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            //Employer Zip Validation
            const int zipLength = 10;
            
            if (varColumnName == "ADDR_ZIP")
            {
                var regexItemZip = new Regex("^[0-9]{5}(?:-[0-9]{4})?$");

                if (ddlVal.ToUpper() == "Y" || ddlVal.ToUpper() == "YES")  // only read when yes is selected for R_CONTRIBUTIONS
                {
                    if (!string.IsNullOrEmpty(varColumnValue)) // field not required, but validate if entered
                    {
                        if (varColumnValue.Length > zipLength)
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = $"Employer Zip should be {zipLength} characters or less";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                        else if (!regexItemZip.IsMatch(varColumnValue))
                        {
                            objImportErrorMessageModel = new ImportErrorMessageModel();
                            objImportErrorMessageModel.RowNumber = rowNumber;
                            objImportErrorMessageModel.ColumnName = ColumnName;
                            objImportErrorMessageModel.ErrorMessages = "Numbers and - are allowed";
                            lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                        }
                    }
                    else
                    {
                        Session["Import_PCF_ShowWarning"] = "Y"; // show warning message dialog
                    }
                }
                else if (!string.IsNullOrEmpty(varColumnValue))
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = rowNumber;
                    objImportErrorMessageModel.ColumnName = ColumnName;
                    objImportErrorMessageModel.ErrorMessages = "Employer Zip must be null if contribution is not greater than or equal to $100 in the aggregate";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }
        }

        /// <summary>
        /// SaveSchedAImportData()
        /// </summary>
        /// <returns></returns>
        public JsonResult SaveSchedAImportData()
        {
            try
            {
                bool results = true;
                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                lstFilingTransactionsModel = (IList<FilingTransactionsModel>)Session["FilingTransactionDataUploadForSchedA"];
                Session["FilingTransactionPartnership"] = Session["FilingTransactionDataUploadForSchedA"];
                results = objItemizedReportsBroker.AddVendorImportFileForSchedABroker(lstFilingTransactionsModel);
                Session["FilingTransactionDataUploadForSchedA"] = null;
                lstFilingTransactionsModel = null;
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        // DAVE 4/2024
        #region "Validate Import Headers"
        /// <summary>
        /// VALIDATES HEADER CELLS IN IMPORT CSV FILE
        /// </summary>
        /// <param name="values"></param>
        /// <returns>bool</returns>
        private bool ValidateImportHeaders(string[] values)
        {
            var lstImportErrorMessageModel = new List<ImportErrorMessageModel>();
            ImportErrorMessageModel objImportErrorMessageModel;

            if (Session["COMM_TYPE_ID"].ToString() != "23" && values.Count() == 15) // NOT PCF FILER
            {
                if (values[0].ToUpper().Trim() == "SCHED_DATE" &&
                    values[1].ToUpper().Trim() == "CNTRBR_TYPE_DESC" &&
                    values[2].ToUpper().Trim() == "FLNG_ENT_FIRST_NAME" &&
                    values[3].ToUpper().Trim() == "FLNG_ENT_MIDDLE_NAME" &&
                    values[4].ToUpper().Trim() == "FLNG_ENT_LAST_NAME" &&
                    values[5].ToUpper().Trim() == "FLNG_ENT_NAME" &&
                    values[6].ToUpper().Trim() == "FLNG_ENT_COUNTRY" &&
                    values[7].ToUpper().Trim() == "FLNG_ENT_ADD1" &&
                    values[8].ToUpper().Trim() == "FLNG_ENT_CITY" &&
                    values[9].ToUpper().Trim() == "FLNG_ENT_STATE" &&
                    values[10].ToUpper().Trim() == "FLNG_ENT_ZIP" &&
                    values[11].ToUpper().Trim() == "PAYMENT_TYPE_DESC" &&
                    values[12].ToUpper().Trim() == "PAY_NUMBER" &&
                    values[13].ToUpper().Trim() == "OWED_AMT" &&
                    values[14].ToUpper().Trim() == "TRANS_EXPLNTN")
                {
                    Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                    return true;
                }
            }

            if ((Session["COMM_TYPE_ID"].ToString() != "23" && values.Count() == 15) || (Session["COMM_TYPE_ID"].ToString() == "23" && values.Count() == 27))
            {
                if (values[0].ToUpper().Trim() != "SCHED_DATE")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "SCHED_DATE";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[1].ToUpper().Trim() != "CNTRBR_TYPE_DESC")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "CNTRBR_TYPE_DESC";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[2].ToUpper().Trim() != "FLNG_ENT_FIRST_NAME")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_FIRST_NAME";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[3].ToUpper().Trim() != "FLNG_ENT_MIDDLE_NAME")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_MIDDLE_NAME";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[4].ToUpper().Trim() != "FLNG_ENT_LAST_NAME")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_LAST_NAME";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[5].ToUpper().Trim() != "FLNG_ENT_NAME")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_NAME";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[6].ToUpper().Trim() != "FLNG_ENT_COUNTRY")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_COUNTRY";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[7].ToUpper().Trim() != "FLNG_ENT_ADD1")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_ADD1";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[8].ToUpper().Trim() != "FLNG_ENT_CITY")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_CITY";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[9].ToUpper().Trim() != "FLNG_ENT_STATE")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_STATE";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[10].ToUpper().Trim() != "FLNG_ENT_ZIP")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "FLNG_ENT_ZIP";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[11].ToUpper().Trim() != "PAYMENT_TYPE_DESC")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "PAYMENT_TYPE_DESC";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[12].ToUpper().Trim() != "PAY_NUMBER")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "PAY_NUMBER";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[13].ToUpper().Trim() != "OWED_AMT")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "OWED_AMT";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[14].ToUpper().Trim() != "TRANS_EXPLNTN")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "TRANS_EXPLNTN";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            if (Session["COMM_TYPE_ID"].ToString() == "23" && values.Count() == 27) { // PCF FILER
                if (values[0].ToUpper().Trim() == "SCHED_DATE" &&
                    values[1].ToUpper().Trim() == "CNTRBR_TYPE_DESC" &&
                    values[2].ToUpper().Trim() == "FLNG_ENT_FIRST_NAME" &&
                    values[3].ToUpper().Trim() == "FLNG_ENT_MIDDLE_NAME" &&
                    values[4].ToUpper().Trim() == "FLNG_ENT_LAST_NAME" &&
                    values[5].ToUpper().Trim() == "FLNG_ENT_NAME" &&
                    values[6].ToUpper().Trim() == "FLNG_ENT_COUNTRY" &&
                    values[7].ToUpper().Trim() == "FLNG_ENT_ADD1" &&
                    values[8].ToUpper().Trim() == "FLNG_ENT_CITY" &&
                    values[9].ToUpper().Trim() == "FLNG_ENT_STATE" &&
                    values[10].ToUpper().Trim() == "FLNG_ENT_ZIP" &&
                    values[11].ToUpper().Trim() == "PAYMENT_TYPE_DESC" &&
                    values[12].ToUpper().Trim() == "PAY_NUMBER" &&
                    values[13].ToUpper().Trim() == "OWED_AMT" &&
                    values[14].ToUpper().Trim() == "TRANS_EXPLNTN" &&
                    values[15].ToUpper().Trim() == "R_CLAIM" &&
                    values[16].ToUpper().Trim() == "R_IN_DISTRICT" &&
                    values[17].ToUpper().Trim() == "R_MINOR" &&
                    values[18].ToUpper().Trim() == "R_VENDOR" &&
                    values[19].ToUpper().Trim() == "R_LOBBYIST" &&
                    values[20].ToUpper().Trim() == "R_CONTRIBUTIONS" &&
                    values[21].ToUpper().Trim() == "TREAS_EMPLOYER" &&
                    values[22].ToUpper().Trim() == "TREAS_OCCUPATION" &&
                    values[23].ToUpper().Trim() == "ADDR_ADDR1" &&
                    values[24].ToUpper().Trim() == "ADDR_CITY" &&
                    values[25].ToUpper().Trim() == "ADDR_STATE" &&
                    values[26].ToUpper().Trim() == "ADDR_ZIP")
                {
                    Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                    return true;
                }

                if (values[15].ToUpper().Trim() != "R_CLAIM")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "R_CLAIM";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[16].ToUpper().Trim() != "R_IN_DISTRICT")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "R_IN_DISTRICT";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[17].ToUpper().Trim() != "R_MINOR")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "R_MINOR";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[18].ToUpper().Trim() != "R_VENDOR")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "R_VENDOR";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[19].ToUpper().Trim() != "R_LOBBYIST")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "R_LOBBYIST";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[20].ToUpper().Trim() != "R_CONTRIBUTIONS")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "R_CONTRIBUTIONS";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[21].ToUpper().Trim() != "TREAS_EMPLOYER")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "TREAS_EMPLOYER";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[22].ToUpper().Trim() != "TREAS_OCCUPATION")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "TREAS_OCCUPATION";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[23].ToUpper().Trim() != "ADDR_ADDR1")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "ADDR_ADDR1";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[24].ToUpper().Trim() != "ADDR_CITY")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "ADDR_CITY";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[25].ToUpper().Trim() != "ADDR_STATE")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "ADDR_STATE";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
                if (values[26].ToUpper().Trim() != "ADDR_ZIP")
                {
                    objImportErrorMessageModel = new ImportErrorMessageModel();
                    objImportErrorMessageModel.RowNumber = "1";
                    objImportErrorMessageModel.ColumnName = "ADDR_ZIP";
                    objImportErrorMessageModel.ErrorMessages = "Invalid column header.";
                    lstImportErrorMessageModel.Add(objImportErrorMessageModel);
                }
            }

            if (lstImportErrorMessageModel != null)
            {
                Session["ErrorMessageGridData"] = lstImportErrorMessageModel;
                if (lstImportErrorMessageModel.Any())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Session["ErrorMessageGridData"] = new List<ImportErrorMessageModel>();
                return true;
            }            
        }
        #endregion

        #region Export To CSV
        /// <summary>
        /// Export To CSV
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        protected void btnExportCSV_Click(IEnumerable data, string fileName)
        {
            GridView GridView1 = new GridView();
            GridView1.DataSource = data;
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".csv");
            System.Web.HttpContext.Current.Response.Charset = "";
            System.Web.HttpContext.Current.Response.ContentType = "application/csv";
            GridView1.AllowPaging = false;
            GridView1.DataBind();
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < GridView1.HeaderRow.Cells.Count; k++)
            {
                //add separator      
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RowNumber")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Row Number";
                }

                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ColumnName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Column Name";
                }

                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ErrorMessages")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Error Messages";
                }

                sb.Append(GridView1.HeaderRow.Cells[k].Text + ',');
            }
            var index = sb.ToString().LastIndexOf(',');
            if (index >= 0)
                sb.Remove(index, 1);

            //append new line 
            sb.Append("\r\n");

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int k = 0; k < GridView1.HeaderRow.Cells.Count; k++)
                {
                    //add separator 
                    if (GridView1.Rows[i].Cells[k].Text.ToString() == "&nbsp;")
                    {
                        GridView1.Rows[i].Cells[k].Text = "";
                    }

                    // Start - Special Characters
                    var result = GridView1.Rows[i].Cells[k].Text.ToString();

                    if (result.Contains("&#39;"))
                        result = result.Replace("&#39;", "'");

                    if (result.Contains("&amp;"))
                        result = result.Replace("&amp;", "&");

                    if (result.Contains("â€˜"))
                        result = result.Replace("â€˜", "'");

                    if (result.Contains("‘"))
                        result = result.Replace("‘", "'");

                    sb.Append("\"" + result + "\"" + ',');
                    // End
                }

                //append new line 
                sb.Append("\r\n");
            }
            System.Web.HttpContext.Current.Response.Output.Write(sb.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion


        /// <summary>
        /// DowloadHelpDocumentPDFFile()
        /// </summary>
        /// <returns></returns>
        private void DowloadHelpDocumentPDFFile()
        {
            try
            {
                List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                objEFSPDFResponseModel = objItemizedReportsBroker.DowloadHelpDocumentPDFFileBroker();
                Response.Clear();
                MemoryStream ms = new MemoryStream(objEFSPDFResponseModel[0].fileByte);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=BOE_SchedAImport_DataDictionary.pdf");
                Response.Buffer = true;
                ms.WriteTo(Response.OutputStream);
                Response.End();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// DownloadPCFHelpDocumentPDF()
        /// </summary>
        /// <returns></returns>
        private void DownloadPCFHelpDocumentPDF()
        {
            try
            {
                List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                objEFSPDFResponseModel = objItemizedReportsBroker.DownloadPCFHelpDocumentPDF();
                Response.Clear();
                MemoryStream ms = new MemoryStream(objEFSPDFResponseModel[0].fileByte);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=BOE_SchedAImportPCF_DataDictionary.pdf");
                Response.Buffer = true;
                ms.WriteTo(Response.OutputStream);
                Response.End();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// DownloadSchedAImportTemplate()
        /// </summary>
        /// <returns></returns>
        private void DownloadSchedAImportTemplate()
        {
            try
            {
                List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                objEFSPDFResponseModel = objItemizedReportsBroker.DownloadSchedAImportTemplate();
                Response.Clear();
                MemoryStream ms = new MemoryStream(objEFSPDFResponseModel[0].fileByte);
                Response.ContentType = "text/csv";
                Response.AddHeader("content-disposition", "attachment;filename=BOE_SchedAImport_Template.csv");
                Response.Buffer = true;
                ms.WriteTo(Response.OutputStream);
                Response.End();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// DownloadSchedAImportPCFTemplate()
        /// </summary>
        /// <returns></returns>
        private void DownloadSchedAImportPCFTemplate()
        {
            try
            {
                List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();
                objEFSPDFResponseModel = objItemizedReportsBroker.DownloadSchedAImportPCFTemplate();
                Response.Clear();
                MemoryStream ms = new MemoryStream(objEFSPDFResponseModel[0].fileByte);
                Response.ContentType = "text/csv";
                Response.AddHeader("content-disposition", "attachment;filename=PCF_BOE_SchedAImport_Template.csv");
                Response.Buffer = true;
                ms.WriteTo(Response.OutputStream);
                Response.End();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetPartnershipFlag()
        {
            try
            {
                String strPartnershipFlag = String.Empty;

                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                lstFilingTransactionsModel = (IList<FilingTransactionsModel>)Session["FilingTransactionPartnership"];
                foreach (var item in lstFilingTransactionsModel)
                {
                    if (item.FlngEntName != "")
                    {
                        strPartnershipFlag = "YES";
                        break;
                    }
                }
                Session["FilingTransactionPartnership"] = null;
                return strPartnershipFlag;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsCandIndFamilyController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
    }

    

    #region ModelStateHelper
            /// <summary>
            /// ModelStateHelper
            /// </summary>
    public static class ModelStateHelper
    {
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(kvp => kvp.Key,
                    kvp => kvp.Value.Errors
                                    .Select(e => e.ErrorMessage).ToArray())
                                    .Where(m => m.Value.Count() > 0);
            }
            return null;
        }
    }
    #endregion ModelStateHelper
}