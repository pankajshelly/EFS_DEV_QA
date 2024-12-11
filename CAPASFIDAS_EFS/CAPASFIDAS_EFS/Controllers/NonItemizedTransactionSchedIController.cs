/*
 * =====================================================================
 * PAGE NAME: 24-HOUR NOTICE (SCHEDULE I TRANSACTIONS).
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
    public class NonItemizedTransactionSchedIController : Controller
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

        #region NonItemizedTransactionSchedI
        /// <summary>
        /// NonItemizedTransactionSchedI
        /// </summary>
        /// <returns></returns>
        // GET: NonItemizedTransactionSchedI
        public ActionResult NonItemizedTransactionSchedI()
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
                return View("NonItemizedTransactionSchedI");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion NonItemizedTransactionSchedI

        #region SaveNonItem24HourNoticeSchedAData
        /// <summary>
        /// SaveNonItem24HourNoticeSchedAData
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
        public JsonResult SaveNonItem24HourNoticeSchedAData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstElectionType, String lstElectionDate,
            String lstTransactionTypeNonItem, String txtCurrentDate24HNotice, String lstContributionName, String txtPartnerShipName,
            String txtFirstName, String txtMI, String txtLastName, String txtCountry, String txtStreetName, String txtCity,
            String txtState, String txtZipCode, String lstMethod, String txtCheck, String txtAmt24HNotice, String txtExplanation, String lstItemized, String lstElectionDateId, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstContributionName == "0")
                    lstContributionName = null;

                if (lstMethod == "0")
                    lstMethod = null;
                if (lstMethod == "- Select -")
                    lstMethod = null;

                #region Form Server Side Validation Non-Itemized 24 Hour Noticie.                       

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
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidationNonItem(txtCurrentDate24HNotice, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }


                if (lstItemized == "Y") // Itemized Transaction
                {
                    if (lstContributionName == "10" || lstContributionName == "11" || lstContributionName == "12" || lstContributionName == "13")
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

                    if (lstContributionName != null)
                    {
                        if (lstContributionName != "")
                        {
                            if (lstContributionName != "0")
                            {
                                Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("LOAN_OTHER", lstContributionName.ToString());
                                if (!results)
                                {
                                    ModelState.AddModelError("lstContributionName", "Invalid Contributor Code");
                                }
                            }
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmt24HNotice == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmt24HNotice))
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

                #endregion Form Server Side Validation Non-Itemized 24 Hour Noticie.

                if (ModelState.IsValid)
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType; //"P"; // lstElectionType; Testing Only...
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionTypeNonItem;
                    objFilingTransactionsModel.SchedDate = txtCurrentDate24HNotice;
                    objFilingTransactionsModel.FlngEntName = txtPartnerShipName;
                    objFilingTransactionsModel.FlngEntFirstName = txtFirstName;
                    objFilingTransactionsModel.FlngEntLastName = txtLastName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtMI;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.OrgAmt = txtAmt24HNotice;
                    objFilingTransactionsModel.ContributorTypeId = lstContributionName;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.RItemized = lstItemized;
                    objFilingTransactionsModel.ElectionDateId = lstElectionDateId;
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

                    var results = objItemizedReportsBroker.AddNonItem24HourNoticeFlngTransResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveNonItem24HourNoticeSchedAData

        #region UpdateNonItem24HourNoticeSchedAData
        /// <summary>
        /// UpdateNonItem24HourNoticeSchedAData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="lstTransactionTypeNonItem"></param>
        /// <param name="strSubmissionDate"></param>
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
        /// <param name="txtCountry"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateNonItem24HourNoticeSchedAData(String strTransNumber,
            String strFilingEntId, String lstContributorName, String strSubmissionDate, String lstTransactionTypeNonItem,
             String txtCurrentDate24HNotice, String txtCheck, String lstMethod,
            String txtAmt24HNotice, String txtExplanation, String txtPartnerShipName, String txtFirstName,
            String txtMI, String txtLastName, String txtCountry, String txtStreetName, String txtCity, String txtState,
            String txtZipCode, String lstElectionType, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry)
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

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                if (lstContributorName == "0" || lstContributorName == "")
                    lstContributorName = null;

                #region Form Server Side Validation Non-Itemized 24 Hour Noticie.

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
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidationNonItem(txtCurrentDate24HNotice, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }



                if (lstContributorName == "10" || lstContributorName == "11" || lstContributorName == "12" || lstContributorName == "13")
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

                if (lstContributorName != null)
                {
                    if (lstContributorName != "")
                    {
                        if (lstContributorName != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("LOAN_OTHER", lstContributorName.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstContributionName", "Invalid Contributor Code");
                            }
                        }
                    }
                }


                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmt24HNotice == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmt24HNotice))
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

                #endregion Form Server Side Validation Non-Itemized 24 Hour Noticie.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    if (strFilingEntId == "")
                        objFilingTransactionsModel.FilingEntId = null;
                    else
                        objFilingTransactionsModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionTypeNonItem;
                    objFilingTransactionsModel.ContributorTypeId = lstContributorName;
                    objFilingTransactionsModel.SubmissionDate = strSubmissionDate;
                    objFilingTransactionsModel.SchedDate = txtCurrentDate24HNotice;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.OrgAmt = txtAmt24HNotice;
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
                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();

                    Boolean results = objItemizedReportsBroker.Update24HNoticeFlngTransResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateNonItem24HourNoticeSchedAData

        #region SubmitNonItem24HourNoticeSchedAData
        /// <summary>
        /// SubmitNonItem24HourNoticeSchedAData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="lstTransactionTypeNonItem"></param>
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
        /// <param name="txtCountry"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionCycleId"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstElectionType"></param>
        /// <param name="lstElectionDate"></param>
        /// <returns></returns>
        public JsonResult SubmitNonItem24HourNoticeSchedAData(String txtFilerId, String strTransNumber,
            String strFilingEntId, String lstTransactionTypeNonItem,
            String lstContributorName, String txtCurrentDate24HNotice, String txtCheck, String lstMethod,
            String txtAmt24HNotice, String txtExplanation, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType, String lstElectionDate, String lstElectionDateId, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate)
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
                if (lstMethod == null)
                {
                    lstMethod = null;
                    txtCheck = null;
                }
                if (lstMethod == "")
                {
                    lstMethod = null;
                    txtCheck = null;
                }

                if (lstContributorName == "0" || lstContributorName == "")
                    lstContributorName = null;

                #region Form Server Side Validation Non-Itemized 24 Hour Noticie.

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
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate24HNotice, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidationNonItem(txtCurrentDate24HNotice, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
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

                if (lstContributorName != null)
                {
                    if (lstContributorName != "")
                    {
                        if (lstContributorName != "0")
                        {
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("LOAN_OTHER", lstContributorName.ToString());
                            if (!results)
                            {
                                ModelState.AddModelError("lstContributionName", "Invalid Contributor Code");
                            }
                        }
                    }
                }


                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmt24HNotice == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmt24HNotice))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmt24HNotice))
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

                #endregion Form Server Side Validation Non-Itemized 24 Hour Noticie.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.FilerId = txtFilerId;
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    if (strFilingEntId == "")
                        objFilingTransactionsModel.FilingEntId = null;
                    else
                        objFilingTransactionsModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionTypeNonItem;
                    objFilingTransactionsModel.ContributorTypeId = lstContributorName;
                    objFilingTransactionsModel.SchedDate = txtCurrentDate24HNotice;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.OrgAmt = txtAmt24HNotice;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    objFilingTransactionsModel.ElectionDateId = lstElectionDateId;
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
                    objFilingTransactionsModel.ModifiedBy = strModifiedBy;

                    Boolean results = objItemizedReportsBroker.Submit24HNoticeFlngTransResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SubmitNonItem24HourNoticeSchedAData

        #region DeleteNonItem24HourNoticeSchedA
        /// <summary>
        /// DeleteNonItem24HourNoticeSchedA
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteNonItem24HourNoticeSchedA(String strTransNumber)
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteNonItem24HourNoticeSchedA

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                lstContributorNameModel.Add(objContributorNameModel);
                var resContributorNames = objItemizedReportsBroker.GetLoanerCodeBroker();
                foreach (var item in resContributorNames)
                {
                    if (item != null)
                    {
                        objContributorNameModel = new ContributorNameModel();
                        objContributorNameModel.ContributorTypeId = item.LoanerID;
                        objContributorNameModel.ContributorTypeDesc = item.LoanerDesc;
                        lstContributorNameModel.Add(objContributorNameModel);
                    }
                }
                return Json(new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetAutoCompleteNameData

        #region Get24HourNoticeTransactionsHistory
        /// <summary>
        /// Get24HourNoticeTransactionsHistory
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult Get24HourNoticeTransactionsHistory(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTrans24HourNoticeHistoryDataResponse(strTransNumber, Session["FilerID"].ToString());

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
                    x.ContributorTypeId,
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
                    x.ContributionTypeDesc,
                    x.LoanerCode,
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonItemizedTransactionSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion Get24HourNoticeTransactionsHistory

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

            // Sortable Columns.
            IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "NonItemized24HNotice");
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