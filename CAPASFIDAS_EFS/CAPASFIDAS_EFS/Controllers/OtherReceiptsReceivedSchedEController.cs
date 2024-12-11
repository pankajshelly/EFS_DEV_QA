// ============================================================
// AUTHOR       : SATHEESH BASIREDDY
// CREATE DATE  : 08/10/2017
// PURPOSE      : CONTRIBUTIONS MONETARY SCHEDULE E
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
    public class OtherReceiptsReceivedSchedEController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        #region OtherReceiptsReceivedSchedE
        /// <summary>
        /// OtherReceiptsReceivedSchedE
        /// </summary>
        /// <returns></returns>
        //
        // GET: /OtherReceiptsReceivedSchedE/
        public ActionResult OtherReceiptsReceivedSchedE()
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
                

                return View("OtherReceiptsReceivedSchedE");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion OtherReceiptsReceivedSchedE

        #region SaveFlngTransOtherReceiptsReceived
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
        public JsonResult SaveFlngTransOtherReceiptsReceived(String txtFilerId, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType, String lstElectionDate, String lstElectionDateId,
            String lstTransactionType, String txtDateRcvd, String txtReceiptSource, String txtCountry, String txtStreetName, String txtCity,
            String txtState, String txtZipCode, String lstReceiptType, String lstMethod, String txtCheck,
            String txtAmtReceiptSourceScheE, String txtExplanationSchedE, String lstItemized, String txtCuttOffDate, String chkCountry, String lstFilingDate, String txtReportPeriodDatesTo, String lstResigTermType, String lstUCMuncipality)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstReceiptType == "0")
                    lstReceiptType = null;

                if (lstMethod == "")
                    lstMethod = null;

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (lstItemized == "Y")
                {
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = null;

                    objFilingTransactionsModel.ReceiptTypeId = lstReceiptType;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                }
                else
                {
                    objFilingTransactionsModel.FilingEntId = null;
                    objFilingTransactionsModel.ReceiptTypeId = null;
                    objFilingTransactionsModel.PaymentTypeId = null;
                }

                #region Server Side Valiation Schedule E Form Data
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
                    if (txtReceiptSource == "")
                    {
                        ModelState.AddModelError("txtReceiptSource", "Receipt Name is required");
                    }
                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtReceiptSource))
                    {
                        ModelState.AddModelError("txtReceiptSource", "Letters, numbers and characters '# -.,& are allowed");
                    }
                    else if (txtReceiptSource.Count() > 40)
                    {
                        ModelState.AddModelError("txtReceiptSource", "Receipt Name should be 40 characters");
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
                            if (txtExplanationSchedE == "")
                            {
                                ModelState.AddModelError("txtExplanationSchedE", "Explanation is required");
                            }
                            else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationSchedE))
                            {
                                ModelState.AddModelError("txtExplanationSchedE", "Letters, numbers and characters '# -., are allowed");
                            }
                            else if (txtExplanationSchedE.Count() > 250)
                            {
                                ModelState.AddModelError("txtExplanationSchedE", "Explanation should be 250 characters");
                            }
                        }
                    }

                    if (lstReceiptType != null)
                    {
                        if (lstReceiptType != "")
                        {
                            if (lstReceiptType != "0")
                            {
                                if (lstReceiptType == "3")
                                {
                                    if (txtExplanationSchedE == "")
                                    {
                                        ModelState.AddModelError("txtExplanationSchedE", "Explanation is required");
                                    }
                                    else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationSchedE))
                                    {
                                        ModelState.AddModelError("txtExplanationSchedE", "Letters, numbers and characters '# -., are allowed");
                                    }
                                    else if (txtExplanationSchedE.Count() > 250)
                                    {
                                        ModelState.AddModelError("txtExplanationSchedE", "Explanation should be 250 characters");
                                    }
                                }
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

                    if (lstReceiptType != null)
                    {
                        if (lstReceiptType != "")
                        {
                            if (lstReceiptType != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("RECEIPT_TYPE", lstReceiptType.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionType", "Invalid Receipt Type");
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

                if (txtAmtReceiptSourceScheE == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtReceiptSourceScheE))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtReceiptSourceScheE))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtReceiptSourceScheE))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                //else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmtReceiptSourceScheE))
                //{
                //    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                //}

                if (txtExplanationSchedE != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationSchedE))
                    {
                        ModelState.AddModelError("txtExplanationSchedE", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanationSchedE.Count() > 250)
                    {
                        ModelState.AddModelError("txtExplanationSchedE", "Explanation should be 250 characters");
                    }
                }
                #endregion Server Side Valiation Schedule E Form Data

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
                    objFilingTransactionsModel.FlngEntName = txtReceiptSource;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.PayNumber = txtCheck;
                    objFilingTransactionsModel.OrgAmt = txtAmtReceiptSourceScheE;
                    objFilingTransactionsModel.TransExplanation = txtExplanationSchedE;
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

                    var results = objItemizedReportsBroker.AddOtherReceivedReceiptsSchedEResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveFlngTransOtherReceiptsReceived

        #region UpdateOtherReceiptsReceived
        /// <summary>
        /// UpdateOtherReceiptsReceived
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="txtDateRcvd"></param>
        /// <param name="txtReceiptSource"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <param name="lstReceiptType"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtCheck"></param>
        /// <param name="txtAmtReceiptSourceScheE"></param>
        /// <param name="txtExplanationReceiptSourceScheE"></param>
        /// <param name="lstItemized"></param>
        /// <returns></returns>
        public JsonResult UpdateOtherReceiptsReceived(String strTransNumber, String strFilingEntId,
            String txtDateRcvd, String txtReceiptSource, String txtCountry, String txtStreetName, String txtCity,
            String txtState, String txtZipCode, String lstReceiptType, String lstMethod, String txtCheck,
            String txtAmtReceiptSourceScheE, String txtExplanationSchedE, String lstItemized, String chkCountry, String txtCuttOffDate, String strFilingDate)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsDataModel = new FilingTransactionsModel();

                String strModifiedBy = Session["UserName"].ToString(); // "SBasireddy"; // Testing only.

                #region Server Side Valiation Schedule E Form Data
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
                    if (txtReceiptSource == "")
                    {
                        ModelState.AddModelError("txtReceiptSource", "Receipt Name is required");
                    }
                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtReceiptSource))
                    {
                        ModelState.AddModelError("txtReceiptSource", "Letters, numbers and characters '# -.,& are allowed");
                    }
                    else if (txtReceiptSource.Count() > 40)
                    {
                        ModelState.AddModelError("txtReceiptSource", "Receipt Name should be 40 characters");
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
                            if (txtExplanationSchedE == "")
                            {
                                ModelState.AddModelError("txtExplanationSchedE", "Explanation is required");
                            }
                            else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationSchedE))
                            {
                                ModelState.AddModelError("txtExplanationSchedE", "Letters, numbers and characters '# -., are allowed");
                            }
                            else if (txtExplanationSchedE.Count() > 250)
                            {
                                ModelState.AddModelError("txtExplanationSchedE", "Explanation should be 250 characters");
                            }
                        }
                    }

                    if (lstReceiptType != null)
                    {
                        if (lstReceiptType != "")
                        {
                            if (lstReceiptType != "0")
                            {
                                if (lstReceiptType == "3")
                                {
                                    if (txtExplanationSchedE == "")
                                    {
                                        ModelState.AddModelError("txtExplanationSchedE", "Explanation is required");
                                    }
                                    else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationSchedE))
                                    {
                                        ModelState.AddModelError("txtExplanationSchedE", "Letters, numbers and characters '# -., are allowed");
                                    }
                                    else if (txtExplanationSchedE.Count() > 250)
                                    {
                                        ModelState.AddModelError("txtExplanationSchedE", "Explanation should be 250 characters");
                                    }
                                }
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

                    if (lstReceiptType != null)
                    {
                        if (lstReceiptType != "")
                        {
                            if (lstReceiptType != "0")
                            {
                                Boolean result = objItemizedReportsBroker.GetDropdownValueExistsResponse("RECEIPT_TYPE", lstReceiptType.ToString());
                                if (!result)
                                {
                                    ModelState.AddModelError("lstContributionType", "Invalid Receipt Type");
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

                if (txtAmtReceiptSourceScheE == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtReceiptSourceScheE))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtReceiptSourceScheE))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtReceiptSourceScheE))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                //else if (!objCommonErrorsServerSide.AmountZeroVal(txtAmtReceiptSourceScheE))
                //{
                //    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                //}

                if (txtExplanationSchedE != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationSchedE))
                    {
                        ModelState.AddModelError("txtExplanationSchedE", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanationSchedE.Count() > 250)
                    {
                        ModelState.AddModelError("txtExplanationSchedE", "Explanation should be 250 characters");
                    }
                }
                #endregion Server Side Valiation Schedule E Form Data

                if (ModelState.IsValid)
                {
                    objFilingTransactionsDataModel.TransNumber = strTransNumber;
                    objFilingTransactionsDataModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsDataModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsDataModel.FlngEntName = txtReceiptSource;
                    objFilingTransactionsDataModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsDataModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsDataModel.FlngEntCity = txtCity;
                    objFilingTransactionsDataModel.FlngEntState = txtState;
                    objFilingTransactionsDataModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsDataModel.ReceiptTypeId = lstReceiptType;
                    objFilingTransactionsDataModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsDataModel.PayNumber = txtCheck;
                    objFilingTransactionsDataModel.OrgAmt = txtAmtReceiptSourceScheE;
                    objFilingTransactionsDataModel.TransExplanation = txtExplanationSchedE;
                    objFilingTransactionsDataModel.RItemized = lstItemized;
                    objFilingTransactionsDataModel.ModifiedBy = strModifiedBy;
                    objFilingTransactionsDataModel.FilerId = Session["FilerID"].ToString();

                    Boolean results = objItemizedReportsBroker.UpdateOtherReceiptsReceivedSchedEResponse(objFilingTransactionsDataModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        } 
        #endregion UpdateOtherReceiptsReceived

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

                List<String> FirstNames;

                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);

                Session["lstAutoCompEntNameAddressModel"] = lstAutoCompFLNameAddressModel;

                FirstNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                return Json(FirstNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                IList<AutoCompFLNameAddressModel> lstAutoCompEntNameAddressModel = new List<AutoCompFLNameAddressModel>();

                lstAutoCompEntNameAddressModel = (IList<AutoCompFLNameAddressModel>)Session["lstAutoCompEntNameAddressModel"];

                String strResult = lstAutoCompEntNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityId).FirstOrDefault().ToString();

                Session["FilingEntId"] = strResult;

                lstAutoCompEntNameAddressModel = lstAutoCompEntNameAddressModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstAutoCompEntNameAddressModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetAutoCompleteNameData

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AutoCompleteFirsttName

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteFilingTransactions

        #region GetReceiptTypeData
        /// <summary>
        /// GetReceiptTypeData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetReceiptTypeData()
        {
            try
            {
                IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();
                IList<ReceiptTypeModel> lstReceiptTypeModelSelect = new List<ReceiptTypeModel>();
                ReceiptTypeModel objReceiptTypeModel;
                objReceiptTypeModel = new ReceiptTypeModel();
                objReceiptTypeModel.ReceiptTypeId = "0";
                objReceiptTypeModel.ReceiptTypeDesc = "- Select -";
                objReceiptTypeModel.ReceiptTypeAbbrev = "SEL";
                lstReceiptTypeModel.Add(objReceiptTypeModel);
                lstReceiptTypeModelSelect = objItemizedReportsBroker.GetReceiptTypeDataResponse();
                foreach (var item in lstReceiptTypeModelSelect)
                {
                    if (item != null)
                    {
                        objReceiptTypeModel = new ReceiptTypeModel();
                        objReceiptTypeModel.ReceiptTypeId = item.ReceiptTypeId;
                        objReceiptTypeModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objReceiptTypeModel.ReceiptTypeAbbrev = item.ReceiptTypeAbbrev;
                        lstReceiptTypeModel.Add(objReceiptTypeModel);
                    }
                }
                // Bind Receipt Code            
                return Json(new SelectList(lstReceiptTypeModel, "ReceiptTypeId", "ReceiptTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "OtherReceiptsReceivedSchedEController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetReceiptTypeData

        #region GetScheduleEHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleEHelpPopUp()
        {
            return View("GetScheduleEHelpPopUp");
        }
        #endregion GetScheduleEHelpPopUp

        #region GetDefaultLookUpsValues
        public void GetDefaultLookUpsValues()
        {
            //IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            //lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            //// Filer ID
            //ViewData["txtFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");

            //String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            //lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //String strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            //// Committee Name
            //ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");

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
            IList<ReceiptTypeModel> lstReceiptTypeModelSelect = new List<ReceiptTypeModel>();
            ReceiptTypeModel objReceiptTypeModel;
            objReceiptTypeModel = new ReceiptTypeModel();
            objReceiptTypeModel.ReceiptTypeId = "0";
            objReceiptTypeModel.ReceiptTypeDesc = "- Select -";
            objReceiptTypeModel.ReceiptTypeAbbrev = "SEL";
            lstReceiptTypeModel.Add(objReceiptTypeModel);
            lstReceiptTypeModelSelect = objItemizedReportsBroker.GetReceiptTypeDataResponse();
            foreach (var item in lstReceiptTypeModelSelect)
            {
                if (item != null)
                {
                    if (item.ReceiptTypeId !="4")
                    {
                        objReceiptTypeModel = new ReceiptTypeModel();
                        objReceiptTypeModel.ReceiptTypeId = item.ReceiptTypeId;
                        objReceiptTypeModel.ReceiptTypeDesc = item.ReceiptTypeDesc;
                        objReceiptTypeModel.ReceiptTypeAbbrev = item.ReceiptTypeAbbrev;
                        lstReceiptTypeModel.Add(objReceiptTypeModel);
                    }
                }
            }
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
            // Sortable Columns.
        }
        #endregion GetDefaultLookUpsValues
    }        
}