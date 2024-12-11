#region Namespaces
using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CAPASFIDAS_EFS.CommonErrors;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;

#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    public class NonCampaignHousekeepingExpensesSchedQController : Controller
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

        #region NonCampaignHousekeepingExpensesSchedQ
        /// <summary>
        /// NonCampaignHousekeepingExpensesSchedQ
        /// </summary>
        /// <returns></returns>
        //
        // GET: /NonCampaignHousekeepingExpensesSchedQ/
        public ActionResult NonCampaignHousekeepingExpensesSchedQ()
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
                return View("NonCampaignHousekeepingExpensesSchedQ");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion NonCampaignHousekeepingExpensesSchedQ

        #region SaveFlngTransNCHExpensesData
        /// <summary>
        /// SaveFlngTransNCHExpensesData
        /// </summary>
        /// <param name="lstContrInKindTranType"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="lstContributionNameInKind"></param>
        /// <param name="txtPartnerShipName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMI"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtStreet"></param>
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
        public JsonResult SaveFlngTransNCHExpensesData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType, String lstElectionDate,
            String lstTransactionType, String txtDateRcvd, String txtPayorName, String lstPurposeCode, String txtCountry,
            String txtStreetName, String txtCity, String txtState, String txtZipCode,
            String lstMethod, String txtCheck, String txtAmount, String txtExplanation, String lstItemized, String txtCuttOffDate, String chkCountry, String lstFilingDate, String txtReportPeriodDatesTo, String lstResigTermType, String lstElectionDateId, String lstUCMuncipality)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstMethod == "0")
                {
                    lstMethod = null;
                    txtCheck = null;
                }

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                if (lstPurposeCode == "0")
                {
                    lstPurposeCode = null;
                }

                if (lstItemized != "N")
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

                if (lstItemized == "N")
                {
                    lstPurposeCode = null;
                    objFilingTransactionsModel.FilingEntId = null;
                }

                #region FORM SERVER-SIDE VALIDATION SCHEDULE 'Q'                    

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
                    if (txtPayorName == "")
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Partnership Name is required");
                    }
                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtPayorName))
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                    }
                    else if (txtPayorName.Count() > 40)
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
                                    ModelState.AddModelError("lstContributionName", "Invalid Purpose Code");
                                }
                            }
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmount == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmount))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmount))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmount))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmount))
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

                #endregion FORM SERVER-SIDE VALIDATION SCHEDULE 'Q'

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
                    objFilingTransactionsModel.FlngEntName = txtPayorName;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.OrgAmt = txtAmount;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    if (lstMethod == "")
                        objFilingTransactionsModel.PaymentTypeId = null;
                    else
                        objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
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
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing Only...
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;

                    var results = objItemizedReportsBroker.AddFilingTransNonCompaignHKExpensesDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveFlngTransNCHExpensesData

        #region UpdateFilingTransData
        /// <summary>
        /// UpdateFilingTransData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="lstPurposeCode"></param>
        /// <param name="txtCurrentDate"></param>
        /// <param name="txtCheck"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtAmount"></param>
        /// <param name="txtExplanation"></param>
        /// <param name="txtPayorName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateFilingTransData(String strTransNumber, String strFilingEntId, String lstPurposeCode,
            String txtCurrentDate, String txtCheck, String lstMethod, String txtAmount, String txtExplanation, 
            String txtPayorName, String txtCountry, String txtStreetName, String txtCity, String txtState, String txtZipCode, String lstItemized, String txtCuttOffDate, String lstElectionType, String txtReportPeriodDatesTo, String lstFilingDate, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstMethod == "0")
                {
                    lstMethod = null;
                    txtCheck = null;
                }

                if (lstPurposeCode == "0")
                    lstPurposeCode = null;

                if (lstItemized == "N")
                {
                    lstMethod = null;
                    txtCheck = null;
                    lstPurposeCode = null;
                    strFilingEntId = null;
                }

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                #region  FORM SERVER-SIDE VALIDATION SCHEDULE 'Q'.

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(txtCurrentDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(txtCurrentDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(txtCurrentDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(txtCurrentDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }

                if (lstItemized == "Y") // Itemized Transaction
                {
                    if (txtPayorName == "")
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Contributor Name is required");
                    }
                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtPayorName))
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                    }
                    else if (txtPayorName.Count() > 40)
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
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", lstMethod.ToString());
                                if (!result)
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
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("PURPOSE_CODE", lstPurposeCode.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionName", "Invalid Purpose Code");
                                }
                            }
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmount == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmount))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmount))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmount))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmount))
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

                #endregion FORM SERVER-SIDE VALIDATION SCHEDULE 'Q'.

                if (ModelState.IsValid)
                {
                    if (strFilingEntId == "")
                        objFilingTransactionsModel.FilingEntId = null;
                    else
                        objFilingTransactionsModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.SchedDate = txtCurrentDate;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.OrgAmt = txtAmount;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.FlngEntName = txtPayorName;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.ModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only.            
                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();

                    Boolean results = objItemizedReportsBroker.UpdateNonCompaignHKExpensesSchedQDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateFilingTransData

        #region GetReimbursementData
        /// <summary>
        /// GetReimbursementData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetReimbursementData(String strTransNumber)
        {
            try
            {
                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

                lstFilingTransactionsModel = objItemizedReportsBroker.GetFlngTransExpReimbursementDataResponse(strTransNumber, strFilerId,"");

                String strOriginalPayeeName = String.Empty;

                if (lstFilingTransactionsModel.Count > 0)
                {
                    strOriginalPayeeName = lstFilingTransactionsModel.Where(x => x.TransNumber == strTransNumber).Select(x => x.FlngEntName).FirstOrDefault().ToString();
                    var itemRemove = lstFilingTransactionsModel.Single(x => x.TransNumber == strTransNumber);
                    lstFilingTransactionsModel.Remove(itemRemove);

                }

                for (int i = 0; i < lstFilingTransactionsModel.Count; i++)
                {
                    if (lstFilingTransactionsModel[i] != null)
                    {
                        if (lstFilingTransactionsModel[i].FilingEntId.ToString() == "0")
                            lstFilingTransactionsModel[i].FilingEntId = "";
                        lstFilingTransactionsModel[i].OriginalPayeeName = strOriginalPayeeName;
                    }
                }

                return Json(new
                {
                    aaData = lstFilingTransactionsModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingEntId,
                    x.PurposeCodeId,
                    "",
                    "",
                    x.SchedDate,
                    x.OriginalPayeeName,
                    x.FlngEntName,
                    x.FlngEntCountry,
                    x.FlngEntStrName,
                    x.FlngEntCity,
                    x.FlngEntState,
                    x.FlngEntZip,
                    x.PurposeCodeDesc,
                    x.OrgAmt,
                    x.TransExplanation,
                    x.RItemized,
                    x.TransNumber
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetReimbursementData

        #region GetReimbursementDetailsTotalAmt
        /// <summary>
        /// GetReimbursementDetailsTotalAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetReimbursementDetailsTotalAmt(String strTransNumber)
        {
            try
            {
                String strReimbursementDetailsAmt = String.Empty;

                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                strReimbursementDetailsAmt = objItemizedReportsBroker.GetReimbursementDetailsAmtResponse(strTransNumber, strFilerId, "");

                return Json(strReimbursementDetailsAmt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetReimbursementDetailsTotalAmt

        #region SaveFlngTransNCHKExpensesReimbursementData
        /// <summary>
        /// SaveFlngTransNCHKExpensesReimbursementData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingSchedId"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="txtAmtExpenditurePayments"></param>
        /// <param name="txtExplanationExpenditurePayments"></param>
        /// <param name="txtPayorName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveFlngTransNCHKExpensesReimbursementData(String strTransNumber, String strFilingSchedId,
            String txtDateRcvd, String txtAmount, String txtExplanation,
            String txtPayorName, String txtCountryReim, String txtStreetName, String txtCity, String txtState, String txtZipCode,
            String lstPurposeCodeReim, String strItemized, String lstElectionType, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                if (strItemized != "N")
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = null;
                }
                else
                {
                    objFilingTransactionsModel.FilingEntId = null;
                    txtZipCode = "";
                    lstPurposeCodeReim = null;
                }

                #region Form Server Side Validation Schedule Q - Reimbursement Details.

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

                if (strItemized == "Y")
                {
                    if (txtPayorName == "")
                    {
                        ModelState.AddModelError("txtPartnerName", "Partner Name is required");
                    }
                    else if (txtPayorName != "")
                    {
                        if (!objCommonErrorsServerSide.EntityNameValidate(txtPayorName))
                        {
                            ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                        }
                        else if (txtPayorName.Count() > 40)
                        {
                            ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                        }
                    }

                    if (chkCountry == "false") // UNITED STATES COUNTRY VALIDAITON.
                    {
                        if (txtCountryReim == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else if (txtCountryReim != "United States")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryReim))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                        }

                        if (txtCountryReim.Count() > 30)
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (txtCountryReim == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (txtCountryReim == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(txtState))
                                {
                                    ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                }
                                else
                                {
                                    if (txtState.Length != 2)
                                    {
                                        ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                    }
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                                {
                                    ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (txtCountryReim == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtZipCode))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }
                    else // OTHER COUNTRY VALIDATION.
                    {
                        if (txtCountryReim == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryReim))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                            if (txtCountryReim.Count() > 30)
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                            }
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                            {
                                ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                            {
                                ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtState.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartState", "State should be 30 characters");
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                            {
                                ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }

                    if (lstPurposeCodeReim != null)
                    {
                        if (lstPurposeCodeReim != "")
                        {
                            if (lstPurposeCodeReim != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("PURPOSE_CODE", lstPurposeCodeReim.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionName", "Invalid Purpose Code");
                                }
                            }
                        }
                    }

                }

                if (strItemized != "Y" && strItemized != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid is Transaction Itemized");
                }

                if (txtAmount == "")
                {
                    ModelState.AddModelError("txtPartAmt", "Amount Attributed is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanation))
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    if (txtExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Explanation should be 250 characters");
                    }
                }

                #endregion Form Server Side Validation Schedule Q - Reimbursement Details.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.FilingSchedId = strFilingSchedId;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.OrgAmt = txtAmount;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    objFilingTransactionsModel.FlngEntName = txtPayorName;
                    objFilingTransactionsModel.FlngEntCountry = txtCountryReim;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCodeReim;
                    objFilingTransactionsModel.RItemized = strItemized;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only....
                    if (Session["FilerId"] != null)
                        objFilingTransactionsModel.FilerId = Session["FilerId"].ToString();
                    else
                        objFilingTransactionsModel.FilerId = "";

                    Boolean results = objItemizedReportsBroker.AddFilingTransExpReimbursmentDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveFlngTransNCHKExpensesReimbursementData

        #region UpdateFlngTransNCHKExpensesReimbursementData
        /// <summary>
        /// UpdateFlngTransNCHKExpensesReimbursementData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strFilingSchedId"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="txtAmount"></param>
        /// <param name="txtExplanation"></param>
        /// <param name="txtPayorName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateFlngTransNCHKExpensesReimbursementData(String strTransNumber, String strFilingEntityId, String strFilingSchedId,
            String txtDateRcvd, String txtAmount, String txtExplanation,  String txtPayorName, String txtCountryReim, String txtStreetName, String txtCity, String txtState, String txtZipCode, String lstPurposeCode, String strItemized, String lstElectionType, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                if (lstPurposeCode == "- Select -")
                    lstPurposeCode = null;

                if (strItemized == "Y")
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = strFilingEntityId.Trim().ToString();
                }
                else
                {
                    objFilingTransactionsModel.FilingEntId = null;
                    txtZipCode = "";
                    lstPurposeCode = null;
                }

                #region Form Server Side Validation Schedule Q - Reimbursement Details.

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

                if (strItemized == "Y")
                {
                    if (txtPayorName == "")
                    {
                        ModelState.AddModelError("txtPartnerName", "Partner Name is required");
                    }
                    else if (txtPayorName != "")
                    {
                        if (!objCommonErrorsServerSide.EntityNameValidate(txtPayorName))
                        {
                            ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                        }
                        else if (txtPayorName.Count() > 40)
                        {
                            ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                        }
                    }

                    if (chkCountry == "false") // UNITED STATES COUNTRY VALIDAITON.
                    {
                        if (txtCountryReim == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else if (txtCountryReim != "United States")
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryReim))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                        }

                        if (txtCountryReim.Count() > 30)
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (txtCountryReim == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(txtCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                                {
                                    ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (txtCountryReim == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(txtState))
                                {
                                    ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                }
                                else
                                {
                                    if (txtState.Length != 2)
                                    {
                                        ModelState.AddModelError("txtPartState", "Two letters are allowed");
                                    }
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                                {
                                    ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (txtCountryReim == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(txtZipCode))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                                {
                                    ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                                }
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }
                    else // OTHER COUNTRY VALIDATION.
                    {
                        if (txtCountryReim == "")
                        {
                            ModelState.AddModelError("txtCountryPartnership", "Country is required");
                        }
                        else
                        {
                            if (!objCommonErrorsServerSide.AlphabetsVal(txtCountryReim))
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Letters are allowed");
                            }
                            if (txtCountryReim.Count() > 30)
                            {
                                ModelState.AddModelError("txtCountryPartnership", "Country should be 30 characters");
                            }
                        }

                        if (txtStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtStreetName))
                            {
                                ModelState.AddModelError("txtPartStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (txtStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtPartStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (txtStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtPartStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (txtCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(txtCity))
                            {
                                ModelState.AddModelError("txtPartCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartCity", "City should be 30 characters");
                            }
                        }

                        if (txtState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(txtState))
                            {
                                ModelState.AddModelError("txtPartState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (txtState.Count() > 30)
                            {
                                ModelState.AddModelError("txtPartState", "State should be 30 characters");
                            }
                        }

                        if (txtZipCode != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZipCode))
                            {
                                ModelState.AddModelError("txtPartZip5", "Letters, numbers and - are allowed");
                            }
                            if (txtZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtPartZip5", "Zip Code should be 10 characters");
                            }
                        }
                    }

                    if (lstPurposeCode != null)
                    {
                        if (lstPurposeCode != "")
                        {
                            if (lstPurposeCode != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("PURPOSE_CODE", lstPurposeCode.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionName", "Invalid Purpose Code");
                                }
                            }
                        }
                    }

                }

                if (strItemized != "Y" && strItemized != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid is Transaction Itemized");
                }

                if (txtAmount == "")
                {
                    ModelState.AddModelError("txtPartAmt", "Amount Attributed is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmount))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanation))
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    if (txtExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Explanation should be 250 characters");
                    }
                }

                #endregion Form Server Side Validation Schedule Q - Reimbursement Details.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.FilingSchedId = strFilingSchedId;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.OrgAmt = txtAmount;
                    objFilingTransactionsModel.TransExplanation = txtExplanation;
                    if (strItemized == "Y")
                        objFilingTransactionsModel.FlngEntName = txtPayorName;
                    else
                        objFilingTransactionsModel.FlngEntName = "";
                    objFilingTransactionsModel.FlngEntCountry = txtCountryReim;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only....
                    if (Session["FilerId"] != null)
                        objFilingTransactionsModel.FilerId = Session["FilerId"].ToString();
                    else
                        objFilingTransactionsModel.FilerId = "";

                    Boolean results = objItemizedReportsBroker.UpdateFilingTransExpReimbursmentDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateFlngTransNCHKExpensesReimbursementData

        #region DeleteReimbursementData
        /// <summary>
        /// DeleteReimbursementData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteReimbursementData(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; //Testing only

                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                Boolean results = objItemizedReportsBroker.DeleteFlngTransReimbursementDataSchedFResponse(strTransNumber,
                    strModifiedBy, strFilerId);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteReimbursementData

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AutoCompleteLastName

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetAutoCompleteNameData

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AutoCompleteEntityName

        #region DeleteFilingTransactions
        /// <summary>
        /// DeleteFilingTransactions
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteFilingTransactions(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.DeleteFilingTransactionsDataResponse(strTransNumber, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteFilingTransactions

        #region GetPurposeCodeData
        /// <summary>
        /// GetPurposeCodeData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeData()
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
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeData

        #region GetPurposeCodeReimData
        /// <summary>
        /// GetPurposeCodeReimData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeReimData()
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
                // REMOVE THE REIMBURSEMENT FOR DETAILS PURPOSE CODES.
                var itemToRemoveCCP = lstPurposeCodeModel.Single(x => x.PurposeCodeId.ToString() == "11");
                lstPurposeCodeModel.Remove(itemToRemoveCCP);
                var itemToRemoveREIM = lstPurposeCodeModel.Single(x => x.PurposeCodeId.ToString() == "29");
                lstPurposeCodeModel.Remove(itemToRemoveREIM);
                // Bind Purpose Code            
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeReimData

        #region GetPurposeCodeCCItemData
        /// <summary>
        /// GetPurposeCodeCCItemData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeCCItemData()
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
                // REMOVE THE CREDIT CARD PAYMENT FOR DETAILS PURPOSE CODES.
                var itemToRemoveReim = lstPurposeCodeModel.Single(x => x.PurposeCodeId.ToString() == "29");
                lstPurposeCodeModel.Remove(itemToRemoveReim);
                var itemToRemoveCCP = lstPurposeCodeModel.Single(x => x.PurposeCodeId.ToString() == "11");
                lstPurposeCodeModel.Remove(itemToRemoveCCP);
                // Bind Purpose Code            
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeCCItemData

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "NonCampaignHousekeepingExpensesSchedQController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPaymentMethodData

        #region GetScheduleQHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleQHelpPopUp()
        {
            return View("GetScheduleQHelpPopUp");
        }
        #endregion GetScheduleQHelpPopUp

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
            lstContributorNameModel = objItemizedReportsBroker.GetContributionNameDataResponse();
            List<String> strIds = new List<String>() { "1", "2", "3", "5", "6", "8", "14" };
            lstContributorNameModel = lstContributorNameModel.Where(x => strIds.Contains(x.ContributorTypeId)).ToList();
            ViewData["lstContributionNameInKind"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc");

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
            // REMOVE THE REIMBURSEMENT AND CREDIT CARD PAYMENT FOR DETAILS PURPOSE CODES.
            IList<PurposeCodeModel> lstPurposeCodeModelCCP = new List<PurposeCodeModel>();
            PurposeCodeModel objPurposeCodeModelCCP;
            objPurposeCodeModelCCP = new PurposeCodeModel();
            objPurposeCodeModelCCP.PurposeCodeId = "0";
            objPurposeCodeModelCCP.PurposeCodeDesc = "- Select -";
            objPurposeCodeModelCCP.PurposeCodeAbbrev = "SEL";
            lstPurposeCodeModelCCP.Add(objPurposeCodeModelCCP);
            var resPurposeCoedsCCP = objItemizedReportsBroker.GetPurposeCodeDataResponse();
            foreach (var item in resPurposeCoedsCCP)
            {
                if (item != null)
                {
                    objPurposeCodeModelCCP = new PurposeCodeModel();
                    objPurposeCodeModelCCP.PurposeCodeId = item.PurposeCodeId;
                    objPurposeCodeModelCCP.PurposeCodeDesc = item.PurposeCodeDesc;
                    objPurposeCodeModelCCP.PurposeCodeAbbrev = item.PurposeCodeAbbrev;
                    lstPurposeCodeModelCCP.Add(objPurposeCodeModelCCP);
                }
            }
            var itemToRemoveCCP = lstPurposeCodeModelCCP.Single(x => x.PurposeCodeId.ToString() == "11");
            lstPurposeCodeModelCCP.Remove(itemToRemoveCCP);
            var itemToRemoveReim = lstPurposeCodeModelCCP.Single(x => x.PurposeCodeId.ToString() == "29");
            lstPurposeCodeModelCCP.Remove(itemToRemoveReim);                       
            ViewData["lstPurposeCodeReim"] = new SelectList(lstPurposeCodeModelCCP, "PurposeCodeId", "PurposeCodeDesc");
            ViewData["lstPurposeCodeCCI"] = new SelectList(lstPurposeCodeModelCCP, "PurposeCodeId", "PurposeCodeDesc");            

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
            ViewData["lstItemizedReim"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
            ViewData["lstItemizedCCI"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);            

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

            // SORTING AND VIEABLE COLUMNS CODE ////////////////////////////////////////////////////
            // Sortable Columns.
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
            // SORTING AND VIEABLE COLUMNS CODE ////////////////////////////////////////////////////
        }
        #endregion GetDefaultLookUpsValues
    }
}