// ============================================================
// AUTHOR       : SATHEESH BASIREDDY
// CREATE DATE  : 08/10/2017
// PURPOSE      : CONTRIBUTIONS MONETARY SCHEDULE D AND SCHEDULE O (PARTNERSHIP)
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
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;
#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    public class ContributionInKindController : Controller
    {
        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Variables

        #region ContributionInKind
        /// <summary>
        /// ContributionInKind
        /// </summary>
        /// <returns></returns>
        // GET: /ContributionInKind/
        public ActionResult ContributionInKind()
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

                    GetDefaultLookUpsValues();
                }

                return View("ContributionInKind");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }
        #endregion ContributionInKind        

        #region SaveFilingTransInKindData
        /// <summary>
        /// SaveFilingTransInKindData
        /// </summary>
        /// <param name="lstContrInKindTranType"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="lstContributionNameInKind"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>        
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip5"></param>
        /// <param name="txtZip4"></param>
        /// <param name="lstContributionType"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtCheck"></param>
        /// <param name="txtAmtInKind"></param>
        /// <param name="txtExplanationInKind"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveFilingTransInKindData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType, String lstElectionDate, String lstElectionDateId,
            String lstTransactionType, String txtDateRcvd, String lstContributionNameInKind, String txtPartnerShipName,
            String txtFirstName, String txtMI, String txtLastName, String txtCountry, String txtStreetName, String txtCity,
            String txtState, String txtZip5, String lstContributionType, String lstMethod, String txtCheck,
            String txtAmtInKind, String txtExplanationInKind, String lstItemized, String txtCuttOffDate, String chkCountry, String lstFilingDate, String txtReportPeriodDatesTo, String lstResigTermType, String lstUCMuncipality,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstContributionNameInKind == "0")
                    lstContributionNameInKind = null;

                if (lstContributionType == "0")
                    lstContributionType = null;
                if (lstContributionType == "")
                    lstContributionType = null;

                if (lstMethod == "0")
                    lstMethod = null;

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (lstItemized == "N")
                {
                    lstContributionNameInKind = null;
                    //lstContributionType = null;
                    lstMethod = null;
                    objFilingTransactionsModel.FilingEntId = null;
                }
                else
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                }

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

                    if (lstContributionNameInKind == "5" ||
                        lstContributionNameInKind == "6" ||
                        lstContributionNameInKind == "9" ||
                        lstContributionNameInKind == "10" ||                        
                        lstContributionNameInKind == "11" ||
                        lstContributionNameInKind == "12" ||
                        lstContributionNameInKind == "13" ||
                        lstContributionNameInKind == "14")
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

                #region Server Side Valiation Schedule D Form Data
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
                    if (lstContributionNameInKind != null)
                    {
                        if (lstContributionNameInKind == "0")
                        {
                            ModelState.AddModelError("lstContributionNameInKind", "Contributor Code is required");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("lstContributionNameInKind", "Contributor Code is required");
                    }

                    if (lstContributionNameInKind == "5" || lstContributionNameInKind == "6" || lstContributionNameInKind == "7" || lstContributionNameInKind == "9" || lstContributionNameInKind == "10" || lstContributionNameInKind == "12" || lstContributionNameInKind == "11" || lstContributionNameInKind == "13" || lstContributionNameInKind == "14")
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
                            ModelState.AddModelError("txtLastName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else if (txtLastName.Count() > 30)
                        {
                            ModelState.AddModelError("txtLastName", "Last Name should be 30 characters");
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

                        if (txtZip5 != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtZip5))
                                {
                                    ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZip5))
                                {
                                    ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtZip5.Count() > 10)
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

                        if (txtZip5 != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZip5))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                            if (txtZip5.Count() > 10)
                            {
                                ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                            }
                        }
                    }

                    if (lstMethod != null)
                    {
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
                            if (txtExplanationInKind == "")
                            {
                                ModelState.AddModelError("txtExplanationInKind", "Explanation is required");
                            }
                            else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationInKind))
                            {
                                ModelState.AddModelError("txtExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                            }
                            else if (txtExplanationInKind.Count() > 250)
                            {
                                ModelState.AddModelError("txtExplanationInKind", "Explanation should be 250 characters");
                            }
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

                    if (lstContributionNameInKind != null)
                    {
                        if (lstContributionNameInKind != "")
                        {
                            if (lstContributionNameInKind != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("CONTRIBUTOR_TYPE", lstContributionNameInKind.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionNameInKind", "Invalid Contributor Code");
                                }
                            }
                        }
                    }

                    if (lstContributionType != null)
                    {
                        if (lstContributionType != "")
                        {
                            if (lstContributionType != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("CONTRIBUTION_TYPE", lstContributionType.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionType", "Invalid Contributor Code");
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (lstItemized != "N")
                    {
                        ModelState.AddModelError("lstItemized", "Invalid Is Transaction Itemized");
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmtInKind == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanationInKind != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationInKind))
                    {
                        ModelState.AddModelError("txtExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanationInKind.Count() > 250)
                    {
                        ModelState.AddModelError("txtExplanationInKind", "Explanation should be 250 characters");
                    }
                }
                #endregion Server Side Valiation Schedule D Form Data

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
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
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZip5;
                    objFilingTransactionsModel.OrgAmt = txtAmtInKind;
                    objFilingTransactionsModel.ContributorTypeId = lstContributionNameInKind;
                    objFilingTransactionsModel.ContributionTypeId = lstContributionType;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.TransExplanation = txtExplanationInKind;
                    objFilingTransactionsModel.RItemized = lstItemized;
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

                    var results = objItemizedReportsBroker.AddFlngTransContrInKindDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
            
        }
        #endregion SaveFilingTransInKindData

        #region UpdateFilingTransContrInKindData
        /// <summary>
        /// UpdateFilingTransContrInKindData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="lstContributionType"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="txtCheck"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtAmtInKind"></param>
        /// <param name="txtExplanationInKind"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip5"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateFilingTransContrInKindData(String strFilingTransId, String strFilingEntId,
            String lstContributionNameInKind, String txtDateRcvd, String txtCheck, String lstMethod,
            String txtAmtInKind, String txtExplanationInKind, String txtPartnerShipName, String txtFirstName,
            String txtMI, String txtLastName, String txtCountry, String txtStreetName, String txtCity,
            String txtState, String txtZipCode, String lstContributionType, String chkCountry, String txtCuttOffDate, String strFilingDate, String lstItemized,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionDataModel objFilingTransactionDataModel = new FilingTransactionDataModel();

                if (lstMethod == "0")
                {
                    lstMethod = null;
                    txtCheck = null;
                }

                if (txtZipCode == "00000-0000" || txtZipCode == "")
                    txtZipCode = "";

                if (txtFirstName == "" || txtPartnerShipName == "")
                    strFilingEntId = null;

                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.

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
                    if (lstContributionNameInKind == "5" ||
                        lstContributionNameInKind == "6" ||
                        lstContributionNameInKind == "9" ||
                        lstContributionNameInKind == "10" ||
                        lstContributionNameInKind == "11" ||
                        lstContributionNameInKind == "12" ||
                        lstContributionNameInKind == "13" ||
                        lstContributionNameInKind == "14")
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

                #region Server Side Valiation Schedule D Form Data
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
                else if (strFilingDate != "")
                {
                    if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, strFilingDate))
                    {
                        ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                    }
                }
                else if (txtCuttOffDate != "")
                {
                    if (!objCommonErrorsServerSide.CuttOffDateValidation(txtDateRcvd, txtCuttOffDate))
                    {
                        ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                    }
                }

                if (lstItemized == "Y") // Itemized Transaction
                {
                    if (lstContributionNameInKind != null)
                    {
                        if (lstContributionNameInKind == "0")
                        {
                            ModelState.AddModelError("lstContributionNameInKind", "Contributor Code is required");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("lstContributionNameInKind", "Contributor Code is required");
                    }

                    if (lstContributionNameInKind == "5" || lstContributionNameInKind == "6" || lstContributionNameInKind == "7" || lstContributionNameInKind == "9" || lstContributionNameInKind == "10" || lstContributionNameInKind == "12" || lstContributionNameInKind == "11" || lstContributionNameInKind == "13" || lstContributionNameInKind == "14")
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
                            ModelState.AddModelError("txtLastName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else if (txtLastName.Count() > 30)
                        {
                            ModelState.AddModelError("txtLastName", "Last Name should be 30 characters");
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

                    if (lstMethod != null)
                    {
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
                            if (txtExplanationInKind == "")
                            {
                                ModelState.AddModelError("txtExplanationInKind", "Explanation is required");
                            }
                            else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationInKind))
                            {
                                ModelState.AddModelError("txtExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                            }
                            else if (txtExplanationInKind.Count() > 250)
                            {
                                ModelState.AddModelError("txtExplanationInKind", "Explanation should be 250 characters");
                            }
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

                    if (lstContributionNameInKind != null)
                    {
                        if (lstContributionNameInKind != "")
                        {
                            if (lstContributionNameInKind != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("CONTRIBUTOR_TYPE", lstContributionNameInKind.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionNameInKind", "Invalid Contributor Code");
                                }
                            }
                        }
                    }

                    if (lstContributionType != null)
                    {
                        if (lstContributionType != "")
                        {
                            if (lstContributionType != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("CONTRIBUTION_TYPE", lstContributionType.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionType", "Invalid Contributor Code");
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (lstItemized != "N")
                    {
                        ModelState.AddModelError("lstItemized", "Invalid Is Transaction Itemized");
                    }
                }

                String strOutstandingDetailsAmount = String.Empty;

                if (lstContributionNameInKind == "5")
                {
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

                if (txtAmtInKind == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmtInKind))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (lstContributionNameInKind == "5")
                {
                    if (txtAmtInKind != "")
                    {
                        Double outstandingAmount = 0;
                        Double partnershipAmount = Convert.ToDouble(String.Format("{0:0.00}", txtAmtInKind));
                        if (strOutstandingDetailsAmount != "")
                            outstandingAmount = Convert.ToDouble(String.Format("{0:0.00}", strOutstandingDetailsAmount));

                        if (strOutstandingDetailsAmount != "")
                        {
                            if (partnershipAmount < outstandingAmount)
                            {
                                ModelState.AddModelError("AmountError", "Amount should not be less than Partnership outstanding amount");
                            }
                        }
                    }
                }

                if (txtExplanationInKind != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationInKind))
                    {
                        ModelState.AddModelError("txtExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanationInKind.Count() > 250)
                    {
                        ModelState.AddModelError("txtExplanationInKind", "Explanation should be 250 characters");
                    }
                }
                #endregion Server Side Valiation Schedule D Form Data

                if (ModelState.IsValid)
                {
                    objFilingTransactionDataModel.FilingTransId = strFilingTransId;
                    objFilingTransactionDataModel.FilingEntityId = strFilingEntId;
                    objFilingTransactionDataModel.ContributionTypeId = lstContributionType;
                    objFilingTransactionDataModel.SchedDate = txtDateRcvd;
                    objFilingTransactionDataModel.PayNumber = txtCheck;
                    objFilingTransactionDataModel.PaymentTypeId = lstMethod;
                    objFilingTransactionDataModel.OriginalAmount = txtAmtInKind;
                    objFilingTransactionDataModel.TransExplanation = txtExplanationInKind;
                    objFilingTransactionDataModel.FilingEntityName = txtPartnerShipName;
                    objFilingTransactionDataModel.FilingFirstName = txtFirstName;
                    objFilingTransactionDataModel.FilingMiddleName = txtMI;
                    objFilingTransactionDataModel.FilingLastName = txtLastName;
                    objFilingTransactionDataModel.FilingCountry = txtCountry;
                    objFilingTransactionDataModel.FilingStreetName = txtStreetName;
                    objFilingTransactionDataModel.FilingCity = txtCity;
                    objFilingTransactionDataModel.FilingState = txtState;
                    objFilingTransactionDataModel.FilingZip = txtZipCode;
                    objFilingTransactionDataModel.ModifiedBy = strModifiedBy;
                    objFilingTransactionDataModel.FilerId = Session["FilerID"].ToString();
                    objFilingTransactionDataModel.TreasurerEmployer = txtEmployerPCFB;
                    objFilingTransactionDataModel.TreasurerOccuptaion = txtOccupationPCFB;
                    objFilingTransactionDataModel.TreasurerStreetAddress = txtContStreetName;
                    objFilingTransactionDataModel.TreasurerCity = txtContCity;
                    objFilingTransactionDataModel.TreasurerState = txtContState;
                    objFilingTransactionDataModel.TreasurerZip = txtContZipCode;
                    if (Session["COMM_TYPE_ID"] == null || Session["COMM_TYPE_ID"].ToString() == "")
                    {
                        objFilingTransactionDataModel.CommTypeID = "";
                    }
                    else
                    {
                        objFilingTransactionDataModel.CommTypeID = Session["COMM_TYPE_ID"].ToString();
                    }
                    objFilingTransactionDataModel.RContributions = lstRContributions;

                    Boolean results = objItemizedReportsBroker.UpdateFilingTransContrInKindDataResponse(objFilingTransactionDataModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion UpdateFilingTransContrInKindData

        #region UpdatePartnersInKindData
        /// <summary>
        /// UpdatePartnersInKindData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="txtPartnerShipName"></param>
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
        public JsonResult UpdatePartnersInKindData(String strFilingTransId, String strFilingEntityId,
            String txtPartshiptName, String txtPartFirstName, String txtPartMI, String txtPartLastName, String txtPartStreetName, String txtPartCity,
            String txtPartState, String txtPartZip5, String txtPartZip4, String txtPartAmt, String txtPartExplanationInKind)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only.

                objFilingTransactionsModel.FilingTransId = strFilingTransId;
                objFilingTransactionsModel.FilingEntId = strFilingEntityId;
                objFilingTransactionsModel.FlngEntName = txtPartshiptName;
                objFilingTransactionsModel.FlngEntFirstName = txtPartFirstName;
                objFilingTransactionsModel.FlngEntMiddleName = txtPartMI;
                objFilingTransactionsModel.FlngEntLastName = txtPartLastName;
                objFilingTransactionsModel.FlngEntStrNum = "";
                objFilingTransactionsModel.FlngEntStrName = txtPartStreetName;
                objFilingTransactionsModel.FlngEntCity = txtPartCity;
                objFilingTransactionsModel.FlngEntState = txtPartState;
                objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                objFilingTransactionsModel.FlngEntZip4 = "";
                objFilingTransactionsModel.OrgAmt = txtPartAmt;
                objFilingTransactionsModel.TransExplanation = txtPartExplanationInKind;
                objFilingTransactionsModel.ModifiedBy = strModifiedBy;
                objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();

                Boolean results = objItemizedReportsBroker.UpdateContrInKindPartnersDataResponse(objFilingTransactionsModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion UpdatePartnersInKindData

        #region GetSchedDPartnersData
        /// <summary>
        /// GetSchedDPartnersData
        /// 
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetSchedDPartnersData(String strFilingTransId, String strFilerId)
        {
            try
            {
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModelResults = new List<ContrInKindPartnersModel>();
                ContrInKindPartnersModel objContrInKindPartnersModel;

                lstContrInKindPartnersModel = objItemizedReportsBroker.GetContrInKindPartnersDataResponse(strFilingTransId, strFilerId);

                String strPartnershipName = lstContrInKindPartnersModel.Where(x => x.FilingTransId == strFilingTransId).Select(x => x.PartnershipName).FirstOrDefault().ToString();

                var itemRemove = lstContrInKindPartnersModel.Single(x => x.FilingTransId == strFilingTransId);

                lstContrInKindPartnersModel.Remove(itemRemove);

                foreach (var item in lstContrInKindPartnersModel)
                {
                    if (item != null)
                    {
                        objContrInKindPartnersModel = new ContrInKindPartnersModel();
                        objContrInKindPartnersModel.FilingTransId = item.FilingTransId;
                        objContrInKindPartnersModel.FilingEntityId = item.FilingEntityId;
                        objContrInKindPartnersModel.PartnershipName = strPartnershipName;
                        objContrInKindPartnersModel.PartnerName = item.PartnershipName;
                        objContrInKindPartnersModel.PartnerFirstName = item.PartnerFirstName;
                        objContrInKindPartnersModel.PartnerMiddleName = item.PartnerMiddleName;
                        objContrInKindPartnersModel.PartnerLastName = item.PartnerLastName;
                        objContrInKindPartnersModel.PartnerStreetName = item.PartnerStreetName;
                        objContrInKindPartnersModel.PartnerCity = item.PartnerCity;
                        objContrInKindPartnersModel.PartnerState = item.PartnerState;
                        objContrInKindPartnersModel.PartnerZip5 = item.PartnerZip5;
                        if (item.PartnerAmountAttributed != "")
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        else
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        objContrInKindPartnersModel.PartnerExplanation = item.PartnerExplanation;
                        objContrInKindPartnersModel.RItemized = item.RItemized;
                        lstContrInKindPartnersModelResults.Add(objContrInKindPartnersModel);
                    }
                }

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
                    x.PartnerStreetName,
                    x.PartnerCity,
                    x.PartnerState,
                    x.PartnerZip5,
                    x.PartnerAmountAttributed,
                    x.PartnerExplanation,
                    x.RItemized
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetSchedDPartnersData

        #region SaveSchedAPartnersData
        /// <summary>
        /// SaveSchedAPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
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
        [HttpPost]
        public JsonResult SaveSchedDPartnersData(String strTransNumber, String strFilingSchedId, String strFilingSchedDate, String txtFilerId,
            String lstElectionCycle, String lstElectionCycleId, String lstUCOfficeType, String lstDisclosurePeriod,
            String lstElectionType, String lstElectionDate, String txtPartnerName, String txtPartFirstName,
            String txtPartMI, String txtPartLastName, String txtCountryPartnership, String txtPartStreetName,
            String txtPartCity, String txtPartState, String txtPartZip5, String txtPartZip4, String txtPartAmt,
            String txtPartExplanationInKind, String lstItemizedPart, String lstIndividualPart, String chkCountryPartnership, String outOrginalAmount, String recordCount,
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
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionTypeId = "P"; // lstElectionType; Testing Only...
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.FilingTypeId = lstDisclosurePeriod;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    if (lstItemizedPart != "N")
                    {
                        if (Session["FilingEntId"] != null)
                            objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                        else
                            objFilingTransactionsModel.FilingEntId = "";
                    }
                    else
                    {
                        objFilingTransactionsModel.FilingEntId = "";
                    }

                    objFilingTransactionsModel.FlngEntName = txtPartnerName;
                    objFilingTransactionsModel.FlngEntFirstName = txtPartFirstName;
                    objFilingTransactionsModel.FlngEntLastName = txtPartLastName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtPartMI;
                    objFilingTransactionsModel.FlngEntStrNum = "";
                    objFilingTransactionsModel.FlngEntCountry = txtCountryPartnership;
                    objFilingTransactionsModel.FlngEntStrName = txtPartStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.FlngEntZip4 = txtPartZip4;
                    objFilingTransactionsModel.TransExplanation = txtPartExplanationInKind;
                    objFilingTransactionsModel.RItemized = lstItemizedPart;
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            

        }
        #endregion SaveSchedAPartnersData

        #region UpdateSchedDPartnersData
        /// <summary>
        /// UpdateSchedDPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntityId"></param>
        /// <param name="txtPartshiptName"></param>
        /// <param name="txtPartFirstName"></param>
        /// <param name="txtPartMI"></param>
        /// <param name="txtPartLastName"></param>
        /// <param name="txtCountryPartnership"></param>
        /// <param name="txtPartStreetName"></param>
        /// <param name="txtPartCity"></param>
        /// <param name="txtPartState"></param>
        /// <param name="txtPartZip5"></param>
        /// <param name="txtPartZip4"></param>
        /// <param name="txtPartAmt"></param>
        /// <param name="txtPartExplanationInKind"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateSchedDPartnersData(String strTransNumber, String strFilingEntityId,
            String txtPartshiptName, String txtPartFirstName, String txtPartMI, String txtPartLastName,
            String txtCountryPartnership, String txtPartStreetName, String txtPartCity,
            String txtPartState, String txtPartZip5, String txtPartZip4, String txtPartAmt, String txtPartExplanationInKind, String lstItemizedPart, String lstIndividualPart, String chkCountryPartnership, String outOrginalAmount, String recordCount, String existingAmount,
            String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (txtPartFirstName == "" && txtPartStreetName == "")
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
                    else
                    {
                        if (txtPartFirstName == "")
                        {
                            ModelState.AddModelError("txtPartFirstName", "First Name is required");
                        }
                        else if (txtPartFirstName != "")
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

                        if (txtPartMI != "")
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

                        if (txtPartLastName == "")
                        {
                            ModelState.AddModelError("txtPartLastName", "Last Name is required");
                        }
                        else if (txtPartLastName != "")
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
                    objFilingTransactionsModel.FilingEntId = strFilingEntityId;
                    objFilingTransactionsModel.FlngEntName = txtPartshiptName;
                    objFilingTransactionsModel.FlngEntFirstName = txtPartFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtPartMI;
                    objFilingTransactionsModel.FlngEntLastName = txtPartLastName;
                    objFilingTransactionsModel.FlngEntStrNum = "";
                    objFilingTransactionsModel.FlngEntCountry = txtCountryPartnership;
                    objFilingTransactionsModel.FlngEntStrName = txtPartStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.FlngEntZip4 = "";
                    objFilingTransactionsModel.OrgAmt = txtPartAmt;
                    objFilingTransactionsModel.TransExplanation = txtPartExplanationInKind;
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion UpdateSchedDPartnersData

        #region DeleteSchedAPartnersData
        /// <summary>
        /// DeleteSchedAPartnersData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <returns></returns>
        public JsonResult DeleteSchedDPartnersData(String strTransNumber)
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion DeleteSchedAPartnersData

        #region GetPartnershipTotAmt
        /// <summary>
        /// GetPartnershipTotAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetPartnershipTotAmt

        #region GetErrorsFromModelState
        /// <summary>
        /// GetErrorsFromModelState
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetErrorsFromModelState()
        {
            try
            {
                var errors = new Dictionary<string, object>();
                foreach (var key in ModelState.Keys)
                {
                    if (key != null)
                    {
                        // Only send the errors to the client.
                        if (ModelState[key].Errors.Count > 0)
                        {
                            errors[key] = ModelState[key].Errors;
                        }
                    }
                }

                return errors;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetErrorsFromModelState

        #region AutoCompleteFirsttName
        /// <summary>
        /// AutoCompleteFirstName
        /// </summary>
        /// <param name="term"></param>
        /// <param name="txtFilerId"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteFirsttName(String term)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString(); // Testing only
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion AutoCompleteFirsttName

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                String strFilerId = Session["FilerId"].ToString(); // Testing only
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

                String strResult = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityId).FirstOrDefault().ToString();

                Session["FilingEntId"] = strResult;

                lstAutoCompFLNameAddressModel = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstAutoCompFLNameAddressModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetAutoCompleteNameData

        #region DeleteFilingTransactions
        /// <summary>
        /// DeleteFilingTransactions
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult DeleteFilingTransactions(String strTransNumber)
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion DeleteFilingTransactions     

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
                var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataResponse();
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetPaymentMethodData

        #region GetContributionNameData
        /// <summary>
        /// GetContributionNameData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetContributionNameData()
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
                var resContributorType = objItemizedReportsBroker.GetContributionNameDataResponse();
                foreach (var item in resContributorType)
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetContributionNameData

        #region GetContributionTypeData
        /// <summary>
        /// GetContributionTypeData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetContributionTypeData()
        {
            try
            {
                IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();
                ContributionTypeModel objContributionTypeModel;
                objContributionTypeModel = new ContributionTypeModel();
                objContributionTypeModel.ContributionTypeId = "0";
                objContributionTypeModel.ContributionTypeDesc = "- Select -";
                objContributionTypeModel.ContributionTypeAbbrev = "SEL";
                lstContributionTypeModel.Add(objContributionTypeModel);
                var resContributionType = objItemizedReportsBroker.GetContributionTypeDataResponse();
                foreach (var item in resContributionType)
                {
                    if (item != null)
                    {
                        objContributionTypeModel = new ContributionTypeModel();
                        objContributionTypeModel.ContributionTypeId = item.ContributionTypeId;
                        objContributionTypeModel.ContributionTypeDesc = item.ContributionTypeDesc;
                        objContributionTypeModel.ContributionTypeAbbrev = item.ContributionTypeAbbrev;
                        lstContributionTypeModel.Add(objContributionTypeModel);
                    }
                }
                // Bind Contribution Type
                return Json(new SelectList(lstContributionTypeModel, "ContributionTypeId", "ContributionTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionInKindController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetContributionTypeData

        #region GetScheduleDHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleDHelpPopUp()
        {
            return View("GetScheduleDHelpPopUp");
        }
        #endregion GetScheduleDHelpPopUp


        #region GetDefaultLookUpsValues
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
            // Bind Disclosure Type
            ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            // Bind lstRContributions
            var lstRContributions = new SelectList(new[]
                                          {
                                              new{ID="0",Name="Yes"},
                                              new {ID="1",Name="No"},
                                              },
                            "ID", "Name", 0);
            ViewData["lstRContributions"] = lstRContributions;

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

            IList<ContributorNameModel> lstPartnersModel = new List<ContributorNameModel>();
            lstPartnersModel = objItemizedReportsBroker.GetPartnerSubContractorDataResponse();
            // Bind Partner Data
            ViewData["lstPartner"] = new SelectList(lstPartnersModel, "ContributorTypeId", "ContributorTypeDesc");

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
            // Disclosure Period
            ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
            PaymentMethodModel objPaymentMethodModel;
            objPaymentMethodModel = new PaymentMethodModel();
            objPaymentMethodModel.PaymentTypeId = "0";
            objPaymentMethodModel.PaymentTypeDesc = "- Select -";
            objPaymentMethodModel.PaymentTypeAbbrev = "SEL";
            lstPaymentMethodModel.Add(objPaymentMethodModel);
            var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataResponse();
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
            var resContributorType = objItemizedReportsBroker.GetContributionNameDataResponse();
            foreach (var item in resContributorType)
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
            ViewData["lstContributionNameInKind"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc");

            IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();
            ContributionTypeModel objContributionTypeModel;
            objContributionTypeModel = new ContributionTypeModel();
            objContributionTypeModel.ContributionTypeId = "0";
            objContributionTypeModel.ContributionTypeDesc = "- Select -";
            objContributionTypeModel.ContributionTypeAbbrev = "SEL";
            lstContributionTypeModel.Add(objContributionTypeModel);
            var resContributionType = objItemizedReportsBroker.GetContributionTypeDataResponse();
            foreach (var item in resContributionType)
            {
                if (item != null)
                {
                    objContributionTypeModel = new ContributionTypeModel();
                    objContributionTypeModel.ContributionTypeId = item.ContributionTypeId;
                    objContributionTypeModel.ContributionTypeDesc = item.ContributionTypeDesc;
                    objContributionTypeModel.ContributionTypeAbbrev = item.ContributionTypeAbbrev;
                    lstContributionTypeModel.Add(objContributionTypeModel);
                }
            }
            // Bind Contribution Type
            ViewData["lstContributionTypeInKind"] = new SelectList(lstContributionTypeModel, "ContributionTypeId", "ContributionTypeDesc");

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
            List<ItemizedModel> lstItemizedModelIndv = new List<ItemizedModel>();
            ItemizedModel objItemizedModelIndv;
            objItemizedModelIndv = new ItemizedModel();
            objItemizedModelIndv.strItemizedId = "Y";
            objItemizedModelIndv.strItemizedName = "Yes";
            lstItemizedModelIndv.Add(objItemizedModelIndv);
            objItemizedModelIndv = new ItemizedModel();
            objItemizedModelIndv.strItemizedId = "N";
            objItemizedModelIndv.strItemizedName = "No";
            lstItemizedModelIndv.Add(objItemizedModelIndv);
            ViewData["lstIndividualPart"] = new SelectList(lstItemizedModelIndv, "strItemizedId", "strItemizedName", 1);

            // =====================================================================================================================================
            // THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
            // =====================================================================================================================================
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
            // =====================================================================================================================================
            // THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
            // =====================================================================================================================================

            // =====================================================================================================================================
            // ADD THIS ONE ITS NEW CODE
            // Viewable Columns Default Values            
            IList<ViewableColumnModel> lstViewableColumns = new List<ViewableColumnModel>();
            lstViewableColumns = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            Session["SorList"] = lstViewableColumns;
            //Bind Column Name
            ViewData["lstViewableColumns"] = new SelectList(lstViewableColumns, "ViewableFieldID", "ColumnName");
            // ADD THIS ONE ITS NEW CODE
            // =====================================================================================================================================

            // Sortable Columns.
            IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            //lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            //Session["SorList"] = lstSortColumnName;
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

    }
}