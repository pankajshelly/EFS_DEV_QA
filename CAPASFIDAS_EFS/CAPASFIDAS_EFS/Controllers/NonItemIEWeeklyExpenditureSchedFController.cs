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
    public class NonItemIEWeeklyExpenditureSchedFController : Controller
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

        #region NonItemIEWeeklyExpenditureSchedF
        /// <summary>
        /// NonItemIEWeeklyExpenditureSchedF
        /// </summary>
        /// <returns></returns>
        // GET: NonItemIEWeeklyExpenditureSchedF
        public ActionResult NonItemIEWeeklyExpenditureSchedF()
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
                return View("NonItemIEWeeklyExpenditureSchedF");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion NonItemIEWeeklyExpenditureSchedF

        #region SaveNonItemIEWeeklyContrSchedFData
        /// <summary>
        /// SaveNonItemIEWeeklyContrSchedFData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <param name="lstTransactionTypeNonItem"></param>
        /// <param name="txtCurrentDate24HNotice"></param>
        /// <param name="lstContributionName"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtCountry"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip5"></param>
        /// <param name="lstContributionType"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtCheck"></param>
        /// <param name="txtAmt24HNotice"></param>
        /// <param name="txtExplanation"></param>
        /// <param name="lstItemized"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveNonItemIEWeeklyContrSchedFData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId, String lstUCOfficeType, String lstElectionType, String lstElectionDate, String lstElectionDateId, String lstTransactionTypeNonItem, String txtCurrentDate24HNotice, String lstPurposeCode, String txtPayeeName, String txtCountry, String txtStreetName, String txtCity, String txtState, String txtZipCode, String lstMethod, String txtCheck, String txtAmtIEWeeklyExpenditure, String txtOutstandingAmt, String txtExplanation, String txtTreasurerOccupation, String txtTreasurerEmployer, String txtStreetNameTreasurer, String txtCityTreasurer, String txtStateTreasurer, String txtZipCodeTreasurer, String txtIndependentExpenditureDescription, String txtCandidateNameBPReference, String lstSupported, String lstLiability, String lstLiabilityExists, String lstSubcontractor, String lstDateIncurred, String lstFilingDate, String txtReportPeriodDatesTo, String chkCountry, String lstUCMuncipality)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstDateIncurred == "0")
                    lstDateIncurred = null;

                if (txtOutstandingAmt == "")
                    txtOutstandingAmt = null;

                if (lstMethod == "0")
                    lstMethod = null;

                if (Session["PersonId"] != null)
                    objFilingTransactionsModel.PersonId = Session["PersonId"].ToString();

                if (Session["AddrId"] != null)
                    objFilingTransactionsModel.AddrId = Session["AddrId"].ToString();

                if (Session["TreasurerId"] != null)
                    objFilingTransactionsModel.TreasId = Session["TreasurerId"].ToString();

                #region Form Server Side Validation Non-Itemized Independent Expenditure Weekly Expenditure Sched 'F'.

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(txtCurrentDate24HNotice))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtCurrentDate24HNotice))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtCurrentDate24HNotice, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (lstFilingDate == "- New Filing Date -")
                {
                    if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, txtReportPeriodDatesTo))
                    {
                        ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, lstFilingDate.Trim()))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }

                // TREASURER SERVER-SIDE VALIDATION.
                if (txtTreasurerOccupation != "")
                {
                    if (!objCommonErrorsServerSide.NameValidate(txtTreasurerOccupation))
                    {
                        ModelState.AddModelError("txtTreasurerOccupation", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (txtTreasurerEmployer != "")
                {
                    if (!objCommonErrorsServerSide.NameValidate(txtTreasurerEmployer))
                    {
                        ModelState.AddModelError("txtTreasurerEmployer", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (txtStreetNameTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetNameTreasurer))
                    {
                        ModelState.AddModelError("txtStreetNameTreasurer", "Letters, numbers and characters '# -., are allowed");
                    }
                    else
                    {
                        if (txtStreetNameTreasurer.Length < 4)
                        {
                            ModelState.AddModelError("txtStreetNameTreasurer", "Street Address must contain at least four characters");
                        }
                    }

                    if (txtStreetNameTreasurer.Count() > 60)
                    {
                        ModelState.AddModelError("txtStreetNameTreasurer", "Street Address should be 60 characters");
                    }
                }
                if (txtCityTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtCityTreasurer))
                    {
                        ModelState.AddModelError("txtCityTreasurer", "Letters and characters '# -., are allowed");
                    }

                    if (txtCityTreasurer.Count() > 30)
                    {
                        ModelState.AddModelError("txtCityTreasurer", "City should be 30 characters");
                    }
                }
                if (txtStateTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.AlphabetsValState(txtStateTreasurer))
                    {
                        ModelState.AddModelError("txtStateTreasurer", "Two letters are allowed");
                    }
                    if (txtStateTreasurer.Length != 2)
                    {
                        ModelState.AddModelError("txtStateTreasurer", "Two letters are allowed");
                    }
                }
                if (txtZipCodeTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.FomatZipcode(txtZipCodeTreasurer))
                    {
                        ModelState.AddModelError("txtZipCodeTreasurer", "Numbers and - are allowed");
                    }
                }
                if (txtIndependentExpenditureDescription != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtIndependentExpenditureDescription))
                    {
                        ModelState.AddModelError("txtIndependentExpenditureDescription", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (txtCandidateNameBPReference != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtCandidateNameBPReference))
                    {
                        ModelState.AddModelError("txtCandidateNameBPReference", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (lstSupported != "Y" && lstSupported != "N")
                {
                    ModelState.AddModelError("lstSupported", "Invalid Is Supoorted");
                }
                if (lstLiability != "Y" && lstLiability != "N")
                {
                    ModelState.AddModelError("lstLiability", "Invalid Is Liability");
                }
                if (lstLiabilityExists != "Y" && lstLiabilityExists != "N")
                {
                    ModelState.AddModelError("lstLiabilityExists", "Invalid Is Existing Liability");
                }
                if (lstSubcontractor != "Y" && lstSubcontractor != "N")
                {
                    ModelState.AddModelError("lstSubcontractor", "Invalid Is Subcontractor");
                }

                if (txtPayeeName == "")
                {
                    ModelState.AddModelError("txtPartnerShipName", "Partnership Name is required");
                }
                else if (!objCommonErrorsServerSide.NameValidate(txtPayeeName))
                {
                    ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -., are allowed");
                }
                else if (txtPayeeName.Count() > 40)
                {
                    ModelState.AddModelError("txtPartnerShipName", "Partnership Name should be 40 characters");
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
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", lstMethod.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstMethod", "Invalid Method");
                            }
                        }
                    }
                }

                if (lstPurposeCode != null)
                {
                    if (lstPurposeCode != "")
                    {
                        if (lstPurposeCode != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("PURPOSE_CODE", lstPurposeCode.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstPurposeCode", "Invalid Purpose Code");
                            }
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                // ORIGINAL AMOUNT.
                if (txtAmtIEWeeklyExpenditure == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                // OUTSTANDING AMOUNT
                if (txtOutstandingAmt != null)
                {
                    if (txtOutstandingAmt != "")
                    {
                        if (txtOutstandingAmt == "")
                        {
                            ModelState.AddModelError("txtAmtOut", "Amount is required");
                        }
                        else if (!objCommonErrorsServerSide.AmountValidate(txtOutstandingAmt))
                        {
                            ModelState.AddModelError("txtAmtOut", "Enter valid Amount (999999999.99)");
                        }
                        else if (!objCommonErrorsServerSide.NumbersOnly(txtOutstandingAmt))
                        {
                            ModelState.AddModelError("txtAmtOut", "Enter valid Amount (999999999.99)");
                        }
                        else if (!objCommonErrorsServerSide.Amount12DigitVal(txtOutstandingAmt))
                        {
                            ModelState.AddModelError("txtAmtOut", "Enter valid Amount (999999999.99)");
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

                #endregion Form Server Side Validation Non-Itemized Independent Expenditure Weekly Expenditure Sched 'F'.

                if (ModelState.IsValid)
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionDateId = lstElectionDateId;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType; //"P"; // lstElectionType; Testing Only...            
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionTypeNonItem;
                    objFilingTransactionsModel.SchedDate = txtCurrentDate24HNotice;
                    objFilingTransactionsModel.FlngEntName = txtPayeeName;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.OrgAmt = txtAmtIEWeeklyExpenditure;
                    objFilingTransactionsModel.OwedAmt = txtOutstandingAmt;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.TreasurerOccupation = txtTreasurerOccupation;
                    objFilingTransactionsModel.TreasurerEmployer = txtTreasurerEmployer;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtStreetNameTreasurer;
                    objFilingTransactionsModel.TreasurerCity = txtCityTreasurer;
                    objFilingTransactionsModel.TreasurerState = txtStateTreasurer;
                    objFilingTransactionsModel.TreasurerZip = txtZipCodeTreasurer;
                    objFilingTransactionsModel.IEDescription = txtIndependentExpenditureDescription;
                    objFilingTransactionsModel.CandBallotPropReference = txtCandidateNameBPReference;
                    objFilingTransactionsModel.R_Supported = lstSupported;
                    objFilingTransactionsModel.RLiability = lstLiability;
                    objFilingTransactionsModel.RLiabilityExists = lstLiabilityExists;
                    objFilingTransactionsModel.RSubcontractor = lstSubcontractor;
                    objFilingTransactionsModel.DateIncurredOrgAmtId = lstDateIncurred;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing Only...
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    else
                        objFilingTransactionsModel.FilingDate = lstFilingDate.Trim();
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;

                    var results = objItemizedReportsBroker.AddNonItemIEWeeklyExpFlngTransResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveNonItemIEWeeklyContrSchedFData                

        #region UpdateNonItemIEWeeklyContrSchedFData
        /// <summary>
        /// UpdateNonItemIEWeeklyContrSchedFData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="lstContributorName"></param>
        /// <param name="strSubmissionDate"></param>
        /// <param name="lstTransactionTypeNonItem"></param>
        /// <param name="txtCurrentDate24HNotice"></param>
        /// <param name="txtCheck"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtAmt24HNotice"></param>
        /// <param name="txtExplanation"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtCountry"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <param name="strTreasId"></param>
        /// <param name="strAddrId"></param>
        /// <param name="txtStreetNameTreasurer"></param>
        /// <param name="txtCityTreasurer"></param>
        /// <param name="txtStateTreasurer"></param>
        /// <param name="txtZipCodeTreasurer"></param>
        /// <param name="txtContributorOccupation"></param>
        /// <param name="txtContributorEmployer"></param>
        /// <param name="txtIndependentExpenditureDescription"></param>
        /// <param name="txtTreasurerOccupation"></param>
        /// <param name="txtTreasurerEmployer"></param>
        /// <param name="lstSupported"></param>
        /// <param name="txtCandidateNameBPReference"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateNonItemIEWeeklyContrSchedFData(String strTransNumber, String strFilingEntId, String lstPurposeCode, String strSubmissionDate, String lstTransactionTypeNonItem, String txtCurrentDate24HNotice, String txtCheck, String lstMethod, String txtAmtIEWeeklyExpenditure, String txtOutstandingAmt, String txtExplanation, String txtPayeeName, String txtCountry, String txtStreetName, String txtCity, String txtState, String txtZipCode, String strTreasId, String strAddrId, String txtStreetNameTreasurer, String txtCityTreasurer, String txtStateTreasurer, String txtZipCodeTreasurer, String txtIndependentExpenditureDescription, String txtTreasurerOccupation, String txtTreasurerEmployer, String lstSupported, String txtCandidateNameBPReference, String lstSubcontractor, String lstLiability, String lstDateIncurred, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                String strPersonId = Session["PersonId"].ToString();
                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.                              

                if (lstDateIncurred == "0")
                    lstDateIncurred = null;

                if (lstMethod == "0")
                {
                    lstMethod = null;
                    txtCheck = null;
                }

                if (txtOutstandingAmt == "")
                    txtOutstandingAmt = null;

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                #region Form Server Side Validation Non-Itemized Independent Expenditure Weekly Expenditure Sched 'F'.

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(txtCurrentDate24HNotice))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtCurrentDate24HNotice))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtCurrentDate24HNotice, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }

                // TREASURER SERVER-SIDE VALIDATION.
                if (txtTreasurerOccupation != "")
                {
                    if (!objCommonErrorsServerSide.NameValidate(txtTreasurerOccupation))
                    {
                        ModelState.AddModelError("txtTreasurerOccupation", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (txtTreasurerEmployer != "")
                {
                    if (!objCommonErrorsServerSide.NameValidate(txtTreasurerEmployer))
                    {
                        ModelState.AddModelError("txtTreasurerEmployer", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (txtStreetNameTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetNameTreasurer))
                    {
                        ModelState.AddModelError("txtStreetNameTreasurer", "Letters, numbers and characters '# -., are allowed");
                    }
                    else
                    {
                        if (txtStreetNameTreasurer.Length < 4)
                        {
                            ModelState.AddModelError("txtStreetNameTreasurer", "Street Address must contain at least four characters");
                        }
                    }

                    if (txtStreetNameTreasurer.Count() > 60)
                    {
                        ModelState.AddModelError("txtStreetNameTreasurer", "Street Address should be 60 characters");
                    }
                }
                if (txtCityTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtCityTreasurer))
                    {
                        ModelState.AddModelError("txtCityTreasurer", "Letters and characters '# -., are allowed");
                    }

                    if (txtCityTreasurer.Count() > 30)
                    {
                        ModelState.AddModelError("txtCityTreasurer", "City should be 30 characters");
                    }
                }
                if (txtStateTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.AlphabetsValState(txtStateTreasurer))
                    {
                        ModelState.AddModelError("txtStateTreasurer", "Two letters are allowed");
                    }
                    if (txtStateTreasurer.Length != 2)
                    {
                        ModelState.AddModelError("txtStateTreasurer", "Two letters are allowed");
                    }
                }
                if (txtZipCodeTreasurer != "")
                {
                    if (!objCommonErrorsServerSide.FomatZipcode(txtZipCodeTreasurer))
                    {
                        ModelState.AddModelError("txtZipCodeTreasurer", "Numbers and - are allowed");
                    }
                }
                if (txtIndependentExpenditureDescription != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtIndependentExpenditureDescription))
                    {
                        ModelState.AddModelError("txtIndependentExpenditureDescription", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (txtCandidateNameBPReference != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtCandidateNameBPReference))
                    {
                        ModelState.AddModelError("txtCandidateNameBPReference", "Letters, numbers and characters '# -., are allowed");
                    }
                }
                if (lstSupported != "Y" && lstSupported != "N")
                {
                    ModelState.AddModelError("lstSupported", "Invalid Is Supoorted");
                }
                if (lstLiability != "Y" && lstLiability != "N")
                {
                    ModelState.AddModelError("lstLiability", "Invalid Is Liability");
                }
                if (lstSubcontractor != "Y" && lstSubcontractor != "N")
                {
                    ModelState.AddModelError("lstSubcontractor", "Invalid Is Subcontractor");
                }

                if (txtPayeeName == "")
                {
                    ModelState.AddModelError("txtPartnerShipName", "Partnership Name is required");
                }
                else if (!objCommonErrorsServerSide.NameValidate(txtPayeeName))
                {
                    ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -., are allowed");
                }
                else if (txtPayeeName.Count() > 40)
                {
                    ModelState.AddModelError("txtPartnerShipName", "Partnership Name should be 40 characters");
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
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", lstMethod.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstMethod", "Invalid Method");
                            }
                        }
                    }
                }

                if (lstPurposeCode != null)
                {
                    if (lstPurposeCode != "")
                    {
                        if (lstPurposeCode != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("PURPOSE_CODE", lstPurposeCode.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstPurposeCode", "Invalid Purpose Code");
                            }
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                // ORIGINAL AMOUNT.
                if (txtAmtIEWeeklyExpenditure == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmtIEWeeklyExpenditure))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                // OUTSTANDING AMOUNT
                if (txtOutstandingAmt != null)
                {
                    if (txtOutstandingAmt != "")
                    {
                        if (txtOutstandingAmt == "")
                        {
                            ModelState.AddModelError("txtAmt", "Amount is required");
                        }
                        else if (!objCommonErrorsServerSide.AmountValidate(txtOutstandingAmt))
                        {
                            ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                        }
                        else if (!objCommonErrorsServerSide.NumbersOnly(txtOutstandingAmt))
                        {
                            ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                        }
                        else if (!objCommonErrorsServerSide.Amount12DigitVal(txtOutstandingAmt))
                        {
                            ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
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

                #endregion Form Server Side Validation Non-Itemized Independent Expenditure Weekly Expenditure Sched 'F'.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    if (strFilingEntId == "")
                        objFilingTransactionsModel.FilingEntId = null;
                    else
                        objFilingTransactionsModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionTypeNonItem;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.SubmissionDate = strSubmissionDate;
                    objFilingTransactionsModel.SchedDate = txtCurrentDate24HNotice;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.OrgAmt = txtAmtIEWeeklyExpenditure;
                    objFilingTransactionsModel.OwedAmt = txtOutstandingAmt;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.FlngEntName = txtPayeeName;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.AddrId = strAddrId;
                    objFilingTransactionsModel.TreasId = strTreasId;
                    objFilingTransactionsModel.PersonId = strPersonId;
                    objFilingTransactionsModel.TreasurerStreetAddress = txtStreetNameTreasurer;
                    objFilingTransactionsModel.TreasurerCity = txtCityTreasurer;
                    objFilingTransactionsModel.TreasurerState = txtStateTreasurer;
                    objFilingTransactionsModel.TreasurerZip = txtZipCodeTreasurer;
                    objFilingTransactionsModel.IEDescription = txtIndependentExpenditureDescription;
                    objFilingTransactionsModel.TreasurerOccupation = txtTreasurerOccupation;
                    objFilingTransactionsModel.TreasurerEmployer = txtTreasurerEmployer;
                    objFilingTransactionsModel.R_Supported = lstSupported;
                    objFilingTransactionsModel.CandBallotPropReference = txtCandidateNameBPReference;
                    objFilingTransactionsModel.RSubcontractor = lstSubcontractor;
                    objFilingTransactionsModel.RLiability = lstLiability;
                    objFilingTransactionsModel.DateIncurredOrgAmtId = lstDateIncurred;
                    objFilingTransactionsModel.ModifiedBy = strModifiedBy;

                    Boolean results = objItemizedReportsBroker.UpdateIEWeeklyExpenditureFlngTransResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateNonItemIEWeeklyContrSchedFData        

        #region SubmitNonItemIEWeeklyContrSchedFData
        /// <summary>
        /// SubmitNonItemIEWeeklyContrSchedFData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult SubmitNonItemIEWeeklyContrSchedFData(String strTransNumber)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (strTransNumber != null)
                {
                    if (strTransNumber != "")
                    {
                        Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TRANSACTIONS", strTransNumber);
                        if (!results)
                        {
                            ModelState.AddModelError("strTransNumber", "Invalid Trans Number");
                        }
                    }
                }

                if (ModelState.IsValid)
                {

                    String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.            

                    Boolean results = objItemizedReportsBroker.SubmitIEWeeklyContrFlngTransResponse(strTransNumber, strModifiedBy);

                    List<SubmitModel> lstSubmitModel = new List<SubmitModel>();
                    SubmitModel objSubmitModel = new SubmitModel();

                    if (results)
                    {
                        objSubmitModel.ReturnValue = true;
                        Boolean childExists = objItemizedReportsBroker.GetNonItemParentTransExistsResponse(strTransNumber, Session["FilerID"].ToString());
                        if (childExists)
                        {
                            objSubmitModel.ChildExists = "True";
                            lstSubmitModel.Add(objSubmitModel);
                        }
                        else
                        {
                            objSubmitModel.ChildExists = "False";
                            lstSubmitModel.Add(objSubmitModel);
                        }
                    }
                    else
                    {
                        objSubmitModel.ReturnValue = false;
                        objSubmitModel.ChildExists = "False";
                        lstSubmitModel.Add(objSubmitModel);
                    }

                    return Json(lstSubmitModel, JsonRequestBehavior.AllowGet);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SubmitNonItemIEWeeklyContrSchedFData

        #region DeleteNonItemIEWeeklyContrSchedF
        /// <summary>
        /// DeleteNonItemIEWeeklyContrSchedF
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteNonItemIEWeeklyContrSchedF(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.Delete24HNoticeFlngTransResponse(strTransNumber, strModifiedBy, Session["FilerID"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteNonItemIEWeeklyContrSchedF

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPaymentMethodData

        #region GetPurposeCodeSchedF
        /// <summary>
        /// GetPurposeCodeSchedF
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeSchedF()
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

                return Json(new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeSchedF

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

                if (lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityName).FirstOrDefault() != null)
                    Session["EntityNameLiability"] = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityName).FirstOrDefault().ToString();                                

                Session["FilingEntId"] = strResult;

                lstAutoCompFLNameAddressModel = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstAutoCompFLNameAddressModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetAutoCompleteNameData

        #region GetPayeeNameExistsLiability
        /// <summary>
        /// GetPayeeNameExistsLiability
        /// </summary>
        /// <param name="strPayeeName"></param>
        /// <returns></returns>
        public JsonResult GetPayeeNameExistsLiability(String strPayeeName)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString();

                String strNameFlag = "Yes";

                String strReturnValue = String.Empty;

                if (Session["EntityNameLiability"] != null)
                {
                    strPayeeName = Session["EntityNameLiability"].ToString();
                    Session.Remove("EntityNameLiability");
                }

                IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();
                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                lstOutstandingLiabilityModel = objItemizedReportsBroker.GetAutoCompleteCreditorNameLiabResponse(strPayeeName, strFilerId, strNameFlag);

                if (lstOutstandingLiabilityModel.Count() > 0)
                {
                    Session["FilingEntId"] = lstOutstandingLiabilityModel.Where(x => x.PayeeName.ToLower() == strPayeeName.ToLower()).Select(x => x.FilingEntityId).FirstOrDefault().ToString();
                }

                return Json(lstOutstandingLiabilityModel, JsonRequestBehavior.AllowGet);

                //if (Session["LiabilityNameFound"] == null)
                //    Session["LiabilityNameFound"] = "No";
                //if (Session["LiabilityNameFound"].ToString() != "Yes")
                //{
                //}
                //else
                //{
                //    IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();
                //    OutstandingLiabilityModel objOutstandingLiabilityModel = new OutstandingLiabilityModel();

                //    objOutstandingLiabilityModel.CreditorName = "Yes";
                //    objOutstandingLiabilityModel.FilingEntityId = "1";
                //    lstOutstandingLiabilityModel.Add(objOutstandingLiabilityModel);

                //    return Json(lstOutstandingLiabilityModel, JsonRequestBehavior.AllowGet);
                //}
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPayeeNameExistsLiability

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }
        #endregion GetIEWeeklyContrbutionTreasurerData

        #region GetIETransactionsHistory
        /// <summary>
        /// GetIETransactionsHistory
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetIETransactionsHistory(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransIEWeeklyExpenditureHistoryDataResponse(strTransNumber);

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
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.PurposeCodeId,
                    x.PaymentTypeId,
                    x.AddrId,
                    x.TreasId,
                    "",
                    x.SubmissionDate,
                    x.FilingEntityName,
                    x.OriginalAmount,
                    x.Status,
                    x.RAmend,
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.PurposeCodeDesc,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.TransExplanation,
                    x.RItemized,
                    x.TreasurerFirstName,
                    x.TreasurerLastName,
                    x.TreasurerMiddleName,
                    x.TreasurerOccuptaion,
                    x.TreasurerEmployer,
                    x.TreasurerStreetAddress,
                    x.TreasurerCity,
                    x.TreasurerState,
                    x.TreasurerZip,
                    x.IEDescription,
                    x.CandBallotPropReference,
                    x.IESupported,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.CreatedDate24Hours
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetIETransactionsHistory

        #region GetDateIncurredIdValue
        /// <summary>
        /// GetDateIncurredIdValue
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public JsonResult GetDateIncurredIdValue(String strFilingEntityId, String strFilerId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                lstDateIncurredModel = objItemizedReportsBroker.GetDateIncurredLiabDataResponse(strFilingEntityId, strFilerId);

                return Json(lstDateIncurredModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDateIncurredIdValue

        #region GetDateIncurred
        /// <summary>
        /// GetDateIncurred
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public JsonResult GetDateIncurred(String strFilingEntityId, String strFilerId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                if (strFilingEntityId == null || strFilingEntityId == "")
                    if (Session["FilingEntId"] != null)
                        strFilingEntityId = Session["FilingEntId"].ToString();

                lstDateIncurredModel = objItemizedReportsBroker.GetDateIncurredLiabDataResponse(strFilingEntityId, strFilerId);

                foreach (var item in lstDateIncurredModel)
                {
                    if (item != null)
                    {
                        item.OrginalDate = item.DateIncurredValue;
                        item.DateIncurredValue = item.DateIncurredValue + " - " + "$" + item.AmountLiability;
                    }
                }

                Session["DateIncurredOrgAmount"] = lstDateIncurredModel;

                return Json(new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDateIncurred

        #region GetDateIncurredUpdate
        /// <summary>
        /// GetDateIncurredUpdate
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetDateIncurredUpdate(String strFilingTransId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                lstDateIncurredModel = objItemizedReportsBroker.GetNonItemIEDateIncrdLiabUpdateDataResponse(strFilingTransId);

                Session["DateIncurredOrgAmountUpdate"] = lstDateIncurredModel;

                foreach (var item in lstDateIncurredModel)
                {
                    if (item != null)
                    {
                        item.OrginalDate = item.DateIncurredValue;
                        item.DateIncurredValue = item.DateIncurredValue + " - " + "$" + item.AmountLiability;
                    }
                }

                //Session["DateIncurredOrgAmountUpdate"] = lstDateIncurredModel;

                return Json(new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDateIncurredUpdate

        #region GetDateIncurredNew
        /// <summary>
        /// GetDateIncurredNew
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDateIncurredNew()
        {
            try
            {
                // DATE INCURRED
                List<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                DateIncurredModel objDateIncurredModel;
                objDateIncurredModel = new DateIncurredModel();
                objDateIncurredModel.DateIncurredId = "0";
                objDateIncurredModel.DateIncurredValue = "- Select -";
                lstDateIncurredModel.Add(objDateIncurredModel);
                // Bind Date Incurred
                //ViewData["lstDateIncurred"] = new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue");
                return Json(new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDateIncurredNew

        #region GetPurposeCodesSubcontractor
        public JsonResult GetPurposeCodesSubcontractor()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                PurposeCodeModel objPurposeCodeModel;
                var resPurposeCoeds = objItemizedReportsBroker.GetNonItemIEPurposeCodesSubContrResponse();

                // REMOVE PIDA FROM LIST FOR WEEKLY AND 24 HOUR EXPENDITURE AND LIABILITY INCCURRED.
                // ADDED DEFECT: 4112 ON 06.28.2021
                var itemToRemove = resPurposeCoeds.SingleOrDefault(x => x.PurposeCodeId == "50");
                if (itemToRemove != null)
                    resPurposeCoeds.Remove(itemToRemove);

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
                //ViewData["lstPurposeCode"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodesSubcontractor

        #region GetPurposeCodeExpenditure
        /// <summary>
        /// GetPurposeCodeExpenditure
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeExpenditure()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                PurposeCodeModel objPurposeCodeModel;
                objPurposeCodeModel = new PurposeCodeModel();
                objPurposeCodeModel.PurposeCodeId = "0";
                objPurposeCodeModel.PurposeCodeDesc = "- Select -";
                objPurposeCodeModel.PurposeCodeAbbrev = "SEL";
                lstPurposeCodeModel.Add(objPurposeCodeModel);
                var resPurposeCoeds = objItemizedReportsBroker.GetNonItemIEPurposeCodesResponse();

                // REMOVE PIDA FROM LIST FOR WEEKLY AND 24 HOUR EXPENDITURE AND LIABILITY INCCURRED.
                // ADDED DEFECT: 4112 ON 06.28.2021
                var itemToRemove = resPurposeCoeds.SingleOrDefault(x => x.PurposeCodeId == "50");
                if (itemToRemove != null)
                    resPurposeCoeds.Remove(itemToRemove);

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
                //ViewData["lstPurposeCode"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeExpenditure

        #region GetAutoCompleteCreditorName
        /// <summary>
        /// GetAutoCompleteCreditorName(String term)
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult GetAutoCompleteCreditorName(String term)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString(); // Testing only

                String strNameFlag = "No";

                IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();
                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();
                AutoCompFLNameAddressModel objAutoCompFLNameAddressModel;

                List<String> EntityNames;

                lstOutstandingLiabilityModel = objItemizedReportsBroker.GetAutoCompleteCreditorNameLiabResponse(term, strFilerId, strNameFlag);

                foreach (var item in lstOutstandingLiabilityModel)
                {
                    if (item != null)
                    {
                        objAutoCompFLNameAddressModel = new AutoCompFLNameAddressModel();
                        objAutoCompFLNameAddressModel.FilingEntityId = item.FilingEntityId;
                        objAutoCompFLNameAddressModel.FilingEntityName = item.PayeeName;
                        objAutoCompFLNameAddressModel.FilingEntityCountry = item.FlngEntCountry;
                        objAutoCompFLNameAddressModel.FilingEntityStreetName = item.LiabilityStreetName;
                        objAutoCompFLNameAddressModel.FilingEntityCity = item.LiabilityCity;
                        objAutoCompFLNameAddressModel.FilingEntityState = item.LiabilityState;
                        objAutoCompFLNameAddressModel.FilingEntityZip = item.LiabilityZipCode;
                        objAutoCompFLNameAddressModel.FilingEntityNameAndAddress = item.FilingEntityNameAndAddress;
                        lstAutoCompFLNameAddressModel.Add(objAutoCompFLNameAddressModel);
                    }
                }

                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;

                EntityNames = lstOutstandingLiabilityModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                return Json(EntityNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetAutoCompleteCreditorName

        #region GetOutstandingAmount
        /// <summary>
        /// GetOriginalAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public JsonResult GetOutstandingAmount(String strFlngEntityId, String strUpdateStatusVal, String strSchedFAmt, String strFilingTransId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                if (strSchedFAmt.Contains("$"))
                {
                    var indexOrgAmt = strSchedFAmt.IndexOf(".");
                    strSchedFAmt = strSchedFAmt.Substring(1, indexOrgAmt - 1);
                }
                IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

                // FILINGS ID
                String strFilingsId = Session["FilerID"].ToString();

                lstOriginalAmountModel = objItemizedReportsBroker.GetOutstandingAmountLiabDataResponse(strFlngEntityId, strUpdateStatusVal, strFilingTransId, strFilingsId);

                String strOutstandingAmount = String.Empty;
                if (lstOriginalAmountModel.Count > 0)
                {
                    foreach (var item in lstOriginalAmountModel)
                    {
                        if (item != null)
                        {
                            strOutstandingAmount = item.OutstandingAmount.ToString();
                        }
                    }
                }
                else
                {
                    if (Session["DateIncurredOrgAmount"] != null)
                    {
                        lstDateIncurredModel = (IList<DateIncurredModel>)Session["DateIncurredOrgAmount"];
                        strOutstandingAmount = lstDateIncurredModel.Where(x => x.DateIncurredId == strFilingTransId).Select(x => x.AmountLiability).First().ToString();
                    }
                }

                return Json(strOutstandingAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemIEWeeklyExpenditureSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOutstandingAmount

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
            ViewData["lstMethodIE24HExpPayF"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");

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

    }
}