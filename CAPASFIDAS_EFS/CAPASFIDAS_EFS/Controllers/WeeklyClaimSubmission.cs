/*
 * =====================================================================
 * PAGE NAME: 24-HOUR NOTICE (SCHEDULE A TRANSACTIONS).
 * AUTHOR NAME: SATHEESH K BASIREDDY
 * CREATED DATE: 04/11/2018
 * UPDATED BY:
 * UPDATED DATE:
 * =========================================================================
 * 
*/
#region Namespaces
using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;

#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    public class WeeklyClaimSubmissionController : Controller
    {
        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Variables

        #region NonItemIEWeeklyContributionSchedA
        /// <summary>
        /// /NonItemIEWeeklyContributionSchedA
        /// </summary>
        /// <returns></returns>
        // GET: NonItemIEWeeklyContributionSchedA
        public ActionResult WeeklyClaimSubmission()
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
                return View("WeeklyClaimSubmission");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion NonItemIEWeeklyContributionSchedA

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
            String txtState, String txtZipCode, String lstMethod, String txtCheck, String txtAmt, 
            String txtExplanation, String lstItemized, String txtCountry, 
            String txtCuttOffDate, String chkCountry, String validateSchedCCTC, String lstFilingDate, 
            String txtReportPeriodDatesTo, String lstResigTermType, String lstUCMuncipality,
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
                    ModelState.AddModelError("txtCurrentDateWCS", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtDateRcvd))
                {
                    ModelState.AddModelError("txtCurrentDateWCS", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtDateRcvd, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateWCS", "Enter valid date format (MM/DD/YYYY)");
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
                        if (lstContributionName == "0" || lstContributionName == null || lstContributionName == "")
                        {
                            ModelState.AddModelError("lstContributionName", "Contributor Type Code is required");
                        }
                    }
                    else // Schedule A Contributor Code Validation.
                    {
                        if (lstContributionName == "0" || lstContributionName == null || lstContributionName == "")
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
                    objFilingTransactionsModel.FilingTypeId = "";
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
                    objFilingTransactionsModel.RItemized = "Y";
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.ElectionDateId = lstElectionDateId;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    //if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                    //{
                    //    if (lstFilingDate == "- New Filing Date -")
                    //        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    //    else
                    //        objFilingTransactionsModel.FilingDate = lstFilingDate;
                    //}
                    //else // OTHER THAN OFF-CYCLE FILING DATE
                    //{
                    //    objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    //}

                    if (Session["FilingDateWCS"] != null)
                    {
                        objFilingTransactionsModel.FilingDate = Session["FilingDateWCS"].ToString();
                    }
                    else
                    {
                        objFilingTransactionsModel.FilingDate = lstFilingDate;
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

                    var results = objItemizedReportsBroker.AddWeeklyClaimSubSchedABroker(objFilingTransactionsModel);

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
            String lstContributorName, String strSubmissionDate, String txtDateRcvd, String txtCheck, String lstMethod,
            String txtAmt, String txtExplanation, String txtPartnerShipName, String txtFirstName,
            String txtMI, String txtLastName, String txtStreetName, String txtCity, String txtState,
            String txtZipCode, String txtCountry, String chkCountry, String txtFilerId,
            String lstIsClaim, String lstInDistrict, String lstMinor, String lstVendor,
            String lstLobbyist, String txtEmployerPCFB, String txtOccupationPCFB, String txtContStreetName, String txtContCity,
            String txtContState, String txtContZipCode, String lstRContributions)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                String strModifiedBy = Session["UserName"].ToString(); 

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
                    ModelState.AddModelError("txtCurrentDateWCS", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtDateRcvd))
                {
                    ModelState.AddModelError("txtCurrentDateWCS", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtDateRcvd, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateWCS", "Enter valid date format (MM/DD/YYYY)");
                }

                    if (lstContributorName == "0")
                    {
                        ModelState.AddModelError("lstContributionName", "Contributor Code is required");
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

                String strOutstandingDetailsAmount = String.Empty;

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
                    objFilingTransactionsModel.OfficeTypeId = "";
                    objFilingTransactionsModel.FilingTypeId = "";
                    objFilingTransactionsModel.ElectYearId = "";
                    objFilingTransactionsModel.ElectionTypeId = "";
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
                    objFilingTransactionsModel.SubmissionDate = strSubmissionDate;

                    Boolean results = objItemizedReportsBroker.UpdateWeeklyClaimSubSchedABroker(objFilingTransactionsModel);

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

        #region SubmitNonItemIEWeeklyContrSchedAData
        /// <summary>
        /// SubmitNonItemIEWeeklyContrSchedAData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult SubmitNonItemIEWeeklyContrSchedAData(FilingTransactionsTransID[] strTransNumber)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                IList<FilingTransactionsTransID> lstFilingTransactionsTransID = new List<FilingTransactionsTransID>();
                FilingTransactionsTransID objFilingTransactionsTransID;

                if (strTransNumber != null)
                {
                    foreach (var item in strTransNumber)
                    {
                        Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TRANSACTIONS", item.TransID.ToString());
                        if (!results)
                        {
                            ModelState.AddModelError("strTransNumber", "Invalid Trans Number");
                        }
                    }
                }

                if (ModelState.IsValid)
                {
                    String strModifiedBy = Session["UserName"].ToString();

                    foreach (var item in strTransNumber)
                    {
                        objFilingTransactionsTransID = new FilingTransactionsTransID();
                        objFilingTransactionsTransID.TransID = item.TransID.ToString();
                        lstFilingTransactionsTransID.Add(objFilingTransactionsTransID);
                    }

                    Boolean results = objItemizedReportsBroker.WeeklyClaimSubSubmitTransBroker(lstFilingTransactionsTransID, Session["FilerID"].ToString(), strModifiedBy);

                    //List<SubmitModel> lstSubmitModel = new List<SubmitModel>();
                    //SubmitModel objSubmitModel = new SubmitModel();

                    //if (results)
                    //{
                    //    objSubmitModel.ReturnValue = true;
                    //    //Boolean childExists = objItemizedReportsBroker.GetNonItemParentTransExistsResponse(strTransNumber, Session["FilerID"].ToString());
                    //    //if (childExists)
                    //    //{
                    //    //    objSubmitModel.ChildExists = "True";
                    //    //    lstSubmitModel.Add(objSubmitModel);
                    //    //}
                    //    //else
                    //    //{
                    //    //    objSubmitModel.ChildExists = "False";
                    //    //    lstSubmitModel.Add(objSubmitModel);
                    //    //}
                    //}
                    //else
                    //{
                    //    objSubmitModel.ReturnValue = false;
                    //    objSubmitModel.ChildExists = "False";
                    //    lstSubmitModel.Add(objSubmitModel);
                    //}

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SubmitNonItemIEWeeklyContrSchedAData

        #region DeleteNonItemIEWeeklyContrSchedA
        /// <summary>
        /// DeleteNonItemIEWeeklyContrSchedA
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteNonItemIEWeeklyContrSchedA(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); 

                Boolean results = objItemizedReportsBroker.Delete24HNoticeFlngTransResponse(strTransNumber, strModifiedBy, Session["FilerID"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteNonItemIEWeeklyContrSchedA

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                //itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "2");
                //if (itemToRemove != null)
                //    resContributorNames.Remove(itemToRemove);
                //itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "1");
                //if (itemToRemove != null)
                //    resContributorNames.Remove(itemToRemove);
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
                itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "13");
                if (itemToRemovePLLCLLC != null)
                    resContributorNames.Remove(itemToRemovePLLCLLC);
                itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "14");
                if (itemToRemovePLLCLLC != null)
                    resContributorNames.Remove(itemToRemovePLLCLLC);

                itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "4");
                if (itemToRemovePLLCLLC != null)
                    resContributorNames.Remove(itemToRemovePLLCLLC);

                itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "5");
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetContributorCodeSchedA

        #region GetChildTransExists
        /// <summary>
        /// GetChildTransExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetChildTransExists(String strTransNumber)
        {
            try
            {
                Boolean results = objItemizedReportsBroker.GetNonItemChildTransExistsResponse(strTransNumber, Session["FilerID"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetChildTransExists

        #region SubmitModel
        /// <summary>
        /// SubmitModel
        /// </summary>
        public class SubmitModel
        {
            public Boolean ReturnValue { get; set; }
            public String ChildExists { get; set; }
        }
        #endregion SubmitModel

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetAutoCompleteNameData

        #region GetIEWeeklyContrbutionTreasurerData
        /// <summary>
        /// GetIEWeeklyContrbutionTreasurerData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetIEWeeklyContrbutionTreasurerData()
        {
            try
            {
                IList<NonItemIETreasurerModel> lstNonItemIETreasurerModel = new List<NonItemIETreasurerModel>();

                String strTreasurerId = Session["TreasurerId"].ToString();

                lstNonItemIETreasurerModel = objItemizedReportsBroker.GetIEWeeklyContrbutionTreasurerDataResponse(strTreasurerId);

                for (int i = 0; i < lstNonItemIETreasurerModel.Count; i++)
                {
                    if (lstNonItemIETreasurerModel[i] != null)
                    {
                        lstNonItemIETreasurerModel[i].TreasurerName = lstNonItemIETreasurerModel[i].TreasurerName.Trim();
                        lstNonItemIETreasurerModel[i].TreasurerOccupation = lstNonItemIETreasurerModel[i].TreasurerOccupation.Trim();
                        lstNonItemIETreasurerModel[i].TreasurerEmployer = lstNonItemIETreasurerModel[i].TreasurerEmployer.Trim();
                        lstNonItemIETreasurerModel[i].TreasurerStreetAddress = lstNonItemIETreasurerModel[i].TreasurerStreetAddress.Trim();
                        lstNonItemIETreasurerModel[i].TreasurerCity = lstNonItemIETreasurerModel[i].TreasurerCity.Trim();
                        lstNonItemIETreasurerModel[i].TreasurerState = lstNonItemIETreasurerModel[i].TreasurerState.Trim();
                        lstNonItemIETreasurerModel[i].TreasurerZip = lstNonItemIETreasurerModel[i].TreasurerZip.Trim();
                    }
                }

                foreach (var item in lstNonItemIETreasurerModel)
                {
                    if (item != null)
                    {
                        Session["AddrId"] = item.AddressId.ToString();
                    }
                    else
                    {
                        Session["AddrId"] = "";
                    }
                }

                return Json(lstNonItemIETreasurerModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetIEWeeklyContrbutionTreasurerData

        #region GetFilingWeeklyClaimSubmissionData
        /// <summary>
        /// GetFilingWeeklyClaimSubmissionData
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetFilingWeeklyClaimSubmissionData(String txtFilerID, String lstElectionCycle, 
            String lstUCOfficeType, String lstElectionType, String lstElectionDateId, String lstFilingDate,
            String txtNewFilingDate, String lstUCMuncipality)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                IList<FilingCutOffDateModel> lstFilingDatesOffCycleModelResults = new List<FilingCutOffDateModel>();
                lstFilingDatesOffCycleModelResults = (IList<FilingCutOffDateModel>)Session["lstFilingDatesOffCycleModelResults"];

                foreach (var item in lstFilingDatesOffCycleModelResults)
                {
                    if (item.PriGenDate == lstFilingDate)
                    {
                        txtNewFilingDate = item.FilingDueDate;
                        break;
                    }
                }

                Session["FilingDateWCS"] = txtNewFilingDate;
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                objFilingTransDataModel.FilingDate = txtNewFilingDate;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingWeeklyClaimSubmissionDataDALBroker(objFilingTransDataModel);

                if (lstFilingTransactionDataModel.Count > 0)
                {
                    for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                    {
                        if (lstFilingTransactionDataModel[i] != null)
                        {
                            if (lstFilingTransactionDataModel[i].SchedDate.Contains("01/01/1900"))
                            {
                                lstFilingTransactionDataModel[i].SchedDate = "";
                            }
                            else if (lstFilingTransactionDataModel[i].SchedDate == "")
                            {
                                lstFilingTransactionDataModel[i].SchedDate = "";
                            }
                            else
                            {
                                lstFilingTransactionDataModel[i].SchedDate = Convert.ToDateTime(lstFilingTransactionDataModel[i].SchedDate).ToString("MM/dd/yyyy");
                            }

                            lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                            lstFilingTransactionDataModel[i].CreatedDate24Hours = Convert.ToDateTime(lstFilingTransactionDataModel[i].CreatedDate).ToString("MM/dd/yyyy HH:mm:ss");
                            if (lstFilingTransactionDataModel[i].SubmissionDate == null)
                                lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                    }
                }

                Session["IEWeeklyContributionTransData"] = lstFilingTransactionDataModel;

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingEntityId,
                    x.TransNumber,
                    x.TransMapping,
                    x.FilingsId,
                    x.PaymentTypeId,
                    "",
                    "",
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.CreatedDate,
                    x.InDistrict,
                    x.RMinor,
                    x.RVendor,
                    x.RLobbyist,
                    x.RContributions,
                    x.TreasurerEmployer,
                    x.TreasurerOccuptaion,
                    x.TreaAddress,
                    x.TreaAddr1,
                    x.TreaCity,
                    x.TreaState,
                    x.TreaZipCode,
                    x.RecordType
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "WeeklyClaimSubmission", "GetFilingWeeklyClaimSubmissionData", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetFilingWeeklyClaimSubmissionData

        #region GetIETransactionsHistory
        /// <summary>
        /// GetIETransactionsHistory
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetWeeklyClaimSubTransHistory(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetWeeklyClaimSubmissionHistoryDataBroker(strTransNumber);

                if (lstFilingTransactionDataModel.Count > 0)
                {
                    for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                    {
                        if (lstFilingTransactionDataModel[i] != null)
                        {
                            if (lstFilingTransactionDataModel[i].SchedDate.Contains("01/01/1900"))
                            {
                                lstFilingTransactionDataModel[i].SchedDate = "";
                            }
                            else if (lstFilingTransactionDataModel[i].SchedDate == "")
                            {
                                lstFilingTransactionDataModel[i].SchedDate = "";
                            }
                            else
                            {
                                lstFilingTransactionDataModel[i].SchedDate = Convert.ToDateTime(lstFilingTransactionDataModel[i].SchedDate).ToString("MM/dd/yyyy");
                            }

                            lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                            lstFilingTransactionDataModel[i].CreatedDate24Hours = Convert.ToDateTime(lstFilingTransactionDataModel[i].CreatedDate).ToString("MM/dd/yyyy HH:mm:ss");
                        }
                    }
                }

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingEntityId,
                    x.TransNumber,
                    x.TransMapping,
                    x.FilingsId,
                    x.PaymentTypeId,
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.CreatedDate,
                    x.InDistrict,
                    x.RMinor,
                    x.RVendor,
                    x.RLobbyist,
                    x.RContributions,
                    x.TreasurerEmployer,
                    x.TreasurerOccuptaion,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyContributionSchedAController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetIETransactionsHistory

        #region DeleteWeeklyClaimSubSchedA
        /// <summary>
        /// DeleteWeeklyClaimSubSchedA
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteWeeklyClaimSubSchedA(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString();

                Boolean results = objItemizedReportsBroker.DeleteWeeklyClaimSubSchedABroker(strTransNumber, strModifiedBy, Session["FilerID"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DeleteWeeklyClaimSubSchedA", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteWeeklyClaimSubSchedA

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
                    //if (!String.IsNullOrEmpty(item.DisclosureSubTypeDesc))
                    //    objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " " + item.DisclosureSubTypeDesc;
                    //else
                    objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
                    lstDisclosureTypeModel.Add(objDisclosureTypesModel);
                }
            }

            // Bind listIsClaim
            var listIsClaim = new SelectList(new[]
                                          {
                                              new{ID="0",Name="Yes"},
                                              new {ID="1",Name="No"},
                                          },
                            "ID", "Name", 0);
            ViewData["lstIsClaim"] = listIsClaim;
            ViewData["lstInDistrict"] = listIsClaim;
            ViewData["lstMinor"] = listIsClaim;
            ViewData["lstVendor"] = listIsClaim;
            ViewData["lstLobbyist"] = listIsClaim;
            ViewData["lstRContributions"] = listIsClaim;

            // Bind Disclosure Type
            ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypes24HNoticeDataResponse(); //GetTransactionTypeData();
            // Bind Transaction Type
            ViewData["lstTransactionTypeNonItem"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

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
            // Disclosure Period
            ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
            PaymentMethodModel objPaymentMethodModel;
            objPaymentMethodModel = new PaymentMethodModel();
            objPaymentMethodModel.PaymentTypeId = "0";
            objPaymentMethodModel.PaymentTypeDesc = "- Select -";
            objPaymentMethodModel.PaymentTypeAbbrev = "SEL";
            lstPaymentMethodModel.Add(objPaymentMethodModel);
            //var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataResponse();
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
            var resContributorNames = objItemizedReportsBroker.GetContributionNameDataResponse();
            var itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "6");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "7");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            //itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "2");
            //if (itemToRemove != null)
            //    resContributorNames.Remove(itemToRemove);
            //itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "1");
            //if (itemToRemove != null)
            //    resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "9");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);
            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "10");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);

            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "4");
            if (itemToRemove != null)
                resContributorNames.Remove(itemToRemove);

            itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "5");
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
            itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "13");
            if (itemToRemovePLLCLLC != null)
                resContributorNames.Remove(itemToRemovePLLCLLC);
            itemToRemovePLLCLLC = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "14");
            if (itemToRemovePLLCLLC != null)
                resContributorNames.Remove(itemToRemovePLLCLLC);
            ContributorNameModel objContributorNameModel;
            foreach (var item in resContributorNames)
            {
                if (item != null)
                {
                    objContributorNameModel = new ContributorNameModel();
                    objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
                    objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
                    objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
                    if (objContributorNameModel.ContributorTypeId == "1")
                    {
                        objContributorNameModel.ContributorTypeSort = "2";
                    }
                    else if (objContributorNameModel.ContributorTypeId == "2")
                    {
                        objContributorNameModel.ContributorTypeSort = "3";
                    }
                    else if (objContributorNameModel.ContributorTypeId == "3")
                    {
                        objContributorNameModel.ContributorTypeSort = "1";
                    }
                    lstContributorNameModel.Add(objContributorNameModel);
                }
            }
            
            lstContributorNameModel = lstContributorNameModel.OrderBy(x => x.ContributorTypeSort).ToList();
            ViewData["lstContributionName"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc",1);

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

            // BINDING FILING DATE
            IList<FilingCutOffDateModel> lstFilingDatesOffCycleModel = new List<FilingCutOffDateModel>();
            IList<FilingCutOffDateModel> lstFilingDatesOffCycleModelResults = new List<FilingCutOffDateModel>();
            FilingCutOffDateModel objFilingDatesOffCycleModel;

            lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingCutOffDateData_PCF_WCS_Broker(Session["ElectionYearId"].ToString(), Session["ElectionTypeId"].ToString(), Session["OfficeTypeId"].ToString());

            objFilingDatesOffCycleModel = new FilingCutOffDateModel();
            objFilingDatesOffCycleModel.FilingDueDate = "- Select -";
            objFilingDatesOffCycleModel.PriGenDate = "- Select -";
            lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);            
            if (lstFilingDatesOffCycleModelResults.Count() > 0)
            {
                foreach (var item in lstFilingDatesOffCycleModelResults)
                {
                    if (item != null)
                    {
                        objFilingDatesOffCycleModel = new FilingCutOffDateModel();
                        objFilingDatesOffCycleModel.FilingDueDate = item.FilingDueDate;
                        objFilingDatesOffCycleModel.PriGenDate = item.PriGenDate;
                        lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                    }
                }
            }
            // Bind Filing Date for Off Cycle.
            ViewData["lstFilingDate"] = new SelectList(lstFilingDatesOffCycleModel, "FilingDueDate", "PriGenDate");
            Session["lstFilingDatesOffCycleModelResults"] = lstFilingDatesOffCycleModelResults;

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
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "IE-WeeklyContribution");
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

        #region GetEditTransactionData_WCS
        /// <summary>
        /// GetEditTransactionData_WCS
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetEditTransactionData_WCS(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                //lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["IEWeeklyContributionTransData"]; 
                lstFilingTransactionDataModel = objItemizedReportsBroker.GetCommEditIETransDataResponse_WCS(strTransNumber, Session["FilerID"].ToString());

                lstFilingTransactionDataModel = lstFilingTransactionDataModel.Where(x => x.TransNumber == strTransNumber).ToList();

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        if (lstFilingTransactionDataModel[i].SubmissionDate != null)
                        {
                            if (lstFilingTransactionDataModel[i].SubmissionDate.Contains("1/1/1900"))
                                lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].SubmissionDate = "";
                        }
                    }
                }

                return Json(lstFilingTransactionDataModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonNIIEWeeklyContribution", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }


        }
        #endregion GetEditTransactionData_WCS
    }
}