// ============================================================
// AUTHOR     : SATHEESH BASIREDDY
// CREATE DATE     : 08/10/2017
// PURPOSE     : EXPENDITURE PAYMENTS SCHEDULE F,N, AND O
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
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;
#endregion Namespaces

namespace CAPASFIDAS_EFS.Controllers
{
    //SQLName : QualifiedExpendituresSchedT
    public class PublicFundExpensesSchedTController : Controller
    {
        #region Global Declaration
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Declaration

        #region ExpenditurePaymentsSchedF
        /// <summary>
        /// ExpenditurePaymentsSchedF
        /// </summary>
        /// <returns></returns>
        // GET: /ExpenditurePaymentsSchedF/
        public ActionResult PublicFundExpensesSchedT()
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
                    GetDefaultLookUpsValues();
                }

                return View("PublicFundExpensesSchedT");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion ExpenditurePaymentsSchedF        

        #region DeleteFilingTransactions
        /// <summary>
        /// DeleteFilingTransactions
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult DeleteFilingTransactions(String strLoanLiabNumberOrg, String strTransNumber, String strRLiability)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.DeleteFlngTransExpPaySchedFNDataResponse(strLoanLiabNumberOrg, strTransNumber, strRLiability, strModifiedBy, Session["FilerId"].ToString(),"20");

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteFilingTransactions

        #region DeleteReimbursementData
        /// <summary>
        /// DeleteReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <returns></returns>
        public JsonResult DeleteReimbursementData(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString();  //"SBasireddy"; //Testing only

                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                Boolean results = objItemizedReportsBroker.DeleteFlngTransReimbursementDataSchedFResponse(strTransNumber, strModifiedBy, strFilerId);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteReimbursementData

        #region SaveFilingTransExpenditureData
        /// <summary>
        /// SaveFilingTransExpenditureData
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
        /// <param name="txtPayorName"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZipCode"></param>
        /// <param name="lstPurposeCode"></param>
        /// <param name="lstMethod"></param>
        /// <param name="txtCheck"></param>
        /// <param name="txtAmt"></param>
        /// <param name="txtExplanation"></param>
        /// <param name="lstLiability"></param>
        /// <param name="lstSubcontractor"></param>
        /// <returns></returns>        
        public JsonResult SaveFilingTransExpenditureData(String txtFilerId, String lstElectionCycle, String lstElectionCycleId,
            String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType, String lstElectionDate, String lstElectionDateId,
            String lstTransactionType, String txtDateRcvd, String txtPayorName, String lstPurposeCode, String txtCountry,
            String txtStreetName, String txtCity, String txtState, String txtZipCode,
            String lstMethod, String txtCheckExpenditurePayments, String txtAmtExpenditurePayments, String txtOriginalAmount,
            String txtOutstandingAmt, String txtExplanationExpenditurePayments, String txtLiabExplanation, String lstLiability,
            String lstSubcontractor, String lstItemized, String strOriginalDate, String lstDateIncurred, String lstLiabilityExists, String lstFilingDate, String txtReportPeriodDatesTo, String lstResigTermType, String chkCountry, String txtCuttOffDate, String lstUCMuncipality)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                Double strOwedAmt = 0;

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (lstLiability == "Y")
                {
                    if (lstLiabilityExists == "N")
                    {
                        if (Convert.ToDouble(txtOriginalAmount) >= Convert.ToDouble(txtAmtExpenditurePayments))
                        {
                            strOwedAmt = Convert.ToDouble(txtOriginalAmount) - Convert.ToDouble(txtAmtExpenditurePayments);
                        }
                    }

                    if (txtOriginalAmount == "")
                    {
                        IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                        lstDateIncurredModel = (IList<DateIncurredModel>)Session["DateIncurredOrgAmount"];
                        txtOriginalAmount = lstDateIncurredModel.Where(x => x.DateIncurredId == lstDateIncurred).Select(x => x.AmountLiability).FirstOrDefault().ToString();
                    }
                }

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (lstMethod == "0")
                {
                    lstMethod = null;
                    txtCheckExpenditurePayments = null;
                }

                if (lstItemized == "N")
                {
                    lstPurposeCode = null;
                    lstMethod = null;
                }
                if (txtZipCode == "00000-0000")
                    txtZipCode = "";

                if (lstDateIncurred == "- Select -" || lstDateIncurred == "0")
                    lstDateIncurred = "";

                if (txtOriginalAmount.Contains("$"))
                {
                    var indexOrgAmt = txtOriginalAmount.IndexOf(".");
                    txtOriginalAmount = txtOriginalAmount.Substring(1, indexOrgAmt - 1);
                }

                if (txtOutstandingAmt.Contains("$"))
                {
                    var indexOwedAmt = txtOutstandingAmt.IndexOf(".");
                    txtOutstandingAmt = txtOutstandingAmt.Substring(1, indexOwedAmt - 1);
                }

                if (txtAmtExpenditurePayments.Contains("$"))
                {
                    var indexOwedAmt = txtAmtExpenditurePayments.IndexOf(".");
                    txtAmtExpenditurePayments = txtAmtExpenditurePayments.Substring(1, indexOwedAmt - 1);
                }

                #region Form Server Side Validation Schdule T

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
                        ModelState.AddModelError("txtPartnerShipName", "Payor Name is required");
                    }
                    else if (!objCommonErrorsServerSide.EntityNameValidate(txtPayorName))
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                    }
                    else if (txtPayorName.Count() > 40)
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Payor Name should be 40 characters");
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
                        if (txtCheckExpenditurePayments == "")
                        {
                            ModelState.AddModelError("txtCheck", "Check # is required");
                        }
                        else if (!objCommonErrorsServerSide.AlphaNumeric(txtCheckExpenditurePayments))
                        {
                            ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                        }
                        else if (txtCheckExpenditurePayments.Count() > 30)
                        {
                            ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                        }
                    }
                    else if (lstMethod == "7")
                    {
                        if (txtExplanationExpenditurePayments == "")
                        {
                            ModelState.AddModelError("txtExplanation", "Explanation is required");
                        }
                        else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtCheckExpenditurePayments))
                        {
                            ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                        }
                        else if (txtExplanationExpenditurePayments.Count() > 250)
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
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (txtAmtExpenditurePayments == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanationExpenditurePayments != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationExpenditurePayments))
                    {
                        ModelState.AddModelError("txtExplanation", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (txtExplanationExpenditurePayments.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                if (lstLiability != "Y" && lstLiability != "N")
                {
                    ModelState.AddModelError("txtCheck", "Liability should be either Y or N");
                }

                if (lstSubcontractor != "Y" && lstSubcontractor != "N")
                {
                    ModelState.AddModelError("txtCheck", "Subcontractor should be either Y or N");
                }

                if (lstItemized != "Y" && lstItemized != "N")
                {
                    ModelState.AddModelError("txtCheck", "Itemized should be either Y or N");
                }

                #endregion Form Server Side Validation Schdule F

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.FilerId = txtFilerId;
                    objFilingTransactionsModel.TransNumber = lstDateIncurred;
                    objFilingTransactionsModel.TransNumberOrg = lstDateIncurred;
                    if (lstItemized != "N")
                    {
                        if (Session["FilingEntId"] != null)
                        {
                            objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                            Session["FilingEntId"] = null;
                        }
                        else
                        {
                            objFilingTransactionsModel.FilingEntId = "";
                        }

                        objFilingTransactionsModel.FlngEntName = txtPayorName;
                    }
                    else
                    {
                        objFilingTransactionsModel.FilingEntId = null;
                        objFilingTransactionsModel.FlngEntName = null;
                    }
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType; 
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.FilingTypeId = lstDisclosurePeriod;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    objFilingTransactionsModel.FilingSchedId = lstTransactionType;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.OrgDate = strOriginalDate.Trim();
                    if (lstLiability == "N")
                    {
                        objFilingTransactionsModel.OrgAmt = txtAmtExpenditurePayments;
                    }
                    else if (lstLiabilityExists == "N")
                    {
                        objFilingTransactionsModel.LiabilityPartialAmt = txtAmtExpenditurePayments;
                        objFilingTransactionsModel.LiabilityOwedAmt = Convert.ToString(strOwedAmt);
                    }
                    else
                    {
                        objFilingTransactionsModel.LiabilityPartialAmt = txtAmtExpenditurePayments;
                        //objFilingTransactionsModel.LiabilityOwedAmt = Convert.ToString(Convert.ToInt32(txtOutstandingAmt) - Convert.ToInt32(txtAmtExpenditurePayments));
                        objFilingTransactionsModel.LiabilityOwedAmt = txtOutstandingAmt;
                    }

                    objFilingTransactionsModel.LiabilityOrgAmt = txtOriginalAmount;

                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.PaymentTypeId = lstMethod;
                    objFilingTransactionsModel.PayNumber = txtCheckExpenditurePayments;
                    objFilingTransactionsModel.TransExplanation = txtExplanationExpenditurePayments;
                    objFilingTransactionsModel.LiabilityTransExplanation = txtLiabExplanation;
                    objFilingTransactionsModel.RLiability = lstLiability;
                    objFilingTransactionsModel.RSubcontractor = lstSubcontractor;
                    objFilingTransactionsModel.RItemized = lstItemized;
                    objFilingTransactionsModel.RLiabilityExists = lstLiabilityExists;
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
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo; // txtCuttOffDate; its using R_Filing_Date.
                    }
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing Only...
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;
                    objFilingTransactionsModel.SchedID = "20";

                    var results = objItemizedReportsBroker.AddFlngTransExpenditureDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveFilingTransExpenditureData

        #region UpdateFilingTransExpenditureData
        /// <summary>
        /// UpdateFilingTransExpenditureData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="strPurposeCodeId"></param>
        /// <param name="strSchedDate"></param>
        /// <param name="strOrgDate"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strPaymentTypeId"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strOwedAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="strLiabilityTransExplanation"></param>
        /// <param name="strRLiability"></param>
        /// <param name="strRSubcontractor"></param>
        /// <param name="strFlngEntityName"></param>
        /// <param name="strFlngStreetName"></param>
        /// <param name="strFlngCity"></param>
        /// <param name="strFlngState"></param>
        /// <param name="strFlngZipCode"></param>
        /// <param name="strItemized"></param>
        /// <param name="strLiabilityOrgAmt"></param>
        /// <returns></returns>        
        public JsonResult UpdateFilingTransExpenditureData(String strFilingEntId, String strSchedDate, String strPayNumber, String strPaymentTypeId, String strOrgAmt, String strTransExplanation, String strRLiability, String strRSubcontractor,
            String strFlngEntityName, String txtCountry, String strFlngStreetName, String strFlngCity, String strFlngState, String strFlngZipCode, String strItemized, String strTransNumber, String strLoanLiabNumber, String strAmountLiabPay, String lstElectionType, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry, String lstPurposeCode)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only...

                String strIsAmountChange = String.Empty;

                // CHECK THE ORIGINAL AMOUNT AND UPDATED AMOUNT DIFFERENT THEN.. 
                // .. SEND THE IS AMOUNT UPDATED PARAMETER 'YES' OTHERWISE 'NO'....
                Decimal dOriginalAmount = 0;
                Decimal dChangedAmount = 0;
                if (strAmountLiabPay != "")
                    dOriginalAmount = Convert.ToDecimal(strAmountLiabPay);
                if (strOrgAmt != "")
                    dChangedAmount = Convert.ToDecimal(strOrgAmt);

                if (strRLiability == "Y")
                {
                    if (dOriginalAmount == dChangedAmount)
                        strIsAmountChange = "NO";
                    else
                        strIsAmountChange = "YES";
                }
                else
                {
                    strIsAmountChange = "NO";
                }

                if (strItemized == "N")
                {
                    strFlngEntityName = null;
                    strFilingEntId = null;
                    lstPurposeCode = null;
                }

                if (strPaymentTypeId == "0")
                    strPaymentTypeId = null;

                if (strOrgAmt.Contains("$"))
                {
                    var indexOrgAmt = strOrgAmt.IndexOf(".");
                    strOrgAmt = strOrgAmt.Substring(1, indexOrgAmt - 1);
                }

                #region Form Server Side Validation Schdule F

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (lstElectionType == "6")
                {
                    if (lstFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strSchedDate, lstFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }
                else if (!objCommonErrorsServerSide.CuttOffDateValidation(strSchedDate, txtCuttOffDate))
                {
                    ModelState.AddModelError("txtCurrentDate", "Date Received cannot be later than Cut Off Date");
                }


                if (strFlngEntityName != null) // Itemized Transaction
                {
                    if (strFlngEntityName == "")
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Payor Name is required");
                    }
                    else if (!objCommonErrorsServerSide.EntityNameValidate(strFlngEntityName))
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Letters, numbers and characters '# -.,& are allowed");
                    }
                    else if (strFlngEntityName.Count() > 40)
                    {
                        ModelState.AddModelError("txtPartnerShipName", "Payor Name should be 40 characters");
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

                        if (strFlngStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngStreetName))
                            {
                                ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (strFlngStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                                }
                            }

                            if (strFlngStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                            }
                        }

                        if (strFlngCity != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.ValidateAlphaSpecial(strFlngCity))
                                {
                                    ModelState.AddModelError("txtCity", "Letters and characters '# -., are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(strFlngCity))
                                {
                                    ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                                }
                            }

                            if (strFlngCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtCity", "City should be 30 characters");
                            }
                        }

                        if (strFlngState != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.AlphabetsValState(strFlngState))
                                {
                                    ModelState.AddModelError("txtState", "Two letters are allowed");
                                }
                                if (strFlngState.Length != 2)
                                {
                                    ModelState.AddModelError("txtState", "Two letters are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(strFlngState))
                                {
                                    ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                                }
                            }
                        }

                        if (strFlngZipCode != "")
                        {
                            if (txtCountry == "United States")
                            {
                                if (!objCommonErrorsServerSide.FomatZipcode(strFlngZipCode))
                                {
                                    ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                                }
                            }
                            else // Other Country
                            {
                                if (!objCommonErrorsServerSide.OtherCountryZipVal(strFlngZipCode))
                                {
                                    ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                                }
                            }
                            if (strFlngZipCode.Count() > 10)
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

                        if (strFlngStreetName != "")
                        {
                            if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngStreetName))
                            {
                                ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                            }
                            else
                            {
                                if (strFlngStreetName.Length < 4)
                                {
                                    ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                                }
                            }
                            if (strFlngStreetName.Count() > 60)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address should be 60 characters");
                            }
                        }


                        if (strFlngCity != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialNumOtherCntry(strFlngCity))
                            {
                                ModelState.AddModelError("txtCity", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (strFlngCity.Count() > 30)
                            {
                                ModelState.AddModelError("txtCity", "City should be 30 characters");
                            }
                        }

                        if (strFlngState != "")
                        {
                            if (!objCommonErrorsServerSide.AlphaSpecialStateOtherCntry(strFlngState))
                            {
                                ModelState.AddModelError("txtState", "Letters, numbers and characters '# -., are allowed");
                            }
                            if (strFlngState.Count() > 30)
                            {
                                ModelState.AddModelError("txtState", "State should be 30 characters");
                            }
                        }

                        if (strFlngZipCode != "")
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(strFlngZipCode))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                            if (strFlngZipCode.Count() > 10)
                            {
                                ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                            }
                        }

                    }

                    if (strPaymentTypeId == "1")
                    {
                        if (strPayNumber == "")
                        {
                            ModelState.AddModelError("txtCheck", "Check # is required");
                        }
                        else if (!objCommonErrorsServerSide.AlphaNumeric(strPayNumber))
                        {
                            ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                        }
                        else if (strPayNumber.Count() > 30)
                        {
                            ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                        }
                    }
                    else if (strPaymentTypeId == "7")
                    {
                        if (strTransExplanation == "")
                        {
                            ModelState.AddModelError("txtExplanation", "Explanation is required");
                        }
                        else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                        {
                            ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                        }
                        else if (strTransExplanation.Count() > 250)
                        {
                            ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                        }
                    }

                    if (strPaymentTypeId != null)
                    {
                        if (strPaymentTypeId != "")
                        {
                            if (strPaymentTypeId != "0")
                            {
                                Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", strPaymentTypeId.ToString());
                                if (!results)
                                {
                                    ModelState.AddModelError("lstMethod", "Invalid Method");
                                }
                            }
                        }
                    }
                }

                // Unitemized Transaction // UN-ITEMIZED TRANSACTIONS.

                if (strOrgAmt == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (strTransExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                    {
                        ModelState.AddModelError("txtExplanation", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                if (strRLiability != "Y" && strRLiability != "N")
                {
                    ModelState.AddModelError("txtCheck", "Liability should be either Y or N");
                }

                if (strRSubcontractor != "Y" && strRSubcontractor != "N")
                {
                    ModelState.AddModelError("txtCheck", "Subcontractor should be either Y or N");
                }

                #endregion Form Server Side Validation Schdule F

                if (ModelState.IsValid)
                {

                    FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                    objFilingTransactionsModel.FilingEntId = strFilingEntId;
                    objFilingTransactionsModel.SchedDate = strSchedDate;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.PaymentTypeId = strPaymentTypeId;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.RLiability = strRLiability;
                    objFilingTransactionsModel.RSubcontractor = strRSubcontractor;
                    objFilingTransactionsModel.RItemized = strItemized;
                    objFilingTransactionsModel.FlngEntName = strFlngEntityName;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.FlngEntStrName = strFlngStreetName;
                    objFilingTransactionsModel.FlngEntCity = strFlngCity;
                    objFilingTransactionsModel.FlngEntState = strFlngState;
                    objFilingTransactionsModel.FlngEntZip = strFlngZipCode;
                    objFilingTransactionsModel.ModifiedBy = strModifiedBy;
                    objFilingTransactionsModel.Loan_Lib_Number = strLoanLiabNumber;
                    objFilingTransactionsModel.TransNumberOrg = strTransNumber;
                    objFilingTransactionsModel.IsAmtChanged = strIsAmountChange;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.FilerId = Session["FilerID"].ToString();
                    objFilingTransactionsModel.SchedID = "20";

                    Boolean results = objItemizedReportsBroker.UpdateFlngTransExpenditureDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateFilingTransExpenditureData

        #region GetSchedFSubcontractorData
        /// <summary>
        /// GetSchedFSubcontractorData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetSchedFSubcontractorData(String strTransNumber, String strFilerId)
        {
            try
            {
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();
                IList<ContrInKindPartnersModel> lstContrInKindPartnersModelResults = new List<ContrInKindPartnersModel>();
                ContrInKindPartnersModel objContrInKindPartnersModel;

                lstContrInKindPartnersModel = objItemizedReportsBroker.GetContrInKindPartnersDataResponse(strTransNumber, strFilerId);

                String strPartnershipName = String.Empty;

                if (lstContrInKindPartnersModel.Count() > 0)
                {
                    strPartnershipName = lstContrInKindPartnersModel.Where(x => x.TransNumber == strTransNumber).Select(x => x.PartnershipName).FirstOrDefault().ToString();

                    var itemRemove = lstContrInKindPartnersModel.Single(x => x.TransNumber == strTransNumber);

                    lstContrInKindPartnersModel.Remove(itemRemove);
                }

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
                        objContrInKindPartnersModel.PartnershipCountry = item.PartnershipCountry;
                        if (item.PartnerAmountAttributed != "")
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        else
                            objContrInKindPartnersModel.PartnerAmountAttributed = item.PartnerAmountAttributed;
                        objContrInKindPartnersModel.PartnerExplanation = item.PartnerExplanation;
                        objContrInKindPartnersModel.RItemized = item.RItemized;
                        objContrInKindPartnersModel.TransNumber = item.TransNumber;
                        objContrInKindPartnersModel.TransMapping = item.TransMapping;
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
                    x.TransMapping
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetSchedFSubcontractorData

        #region SaveSchedFSubcontractorData
        /// <summary>
        /// SaveSchedFSubcontractorData
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
        public JsonResult SaveSchedFSubcontractorData(String strTransNumber, String strFilingSchedId, String strFilingSchedDate, String txtFilerId,
            String lstElectionCycle, String lstElectionCycleId, String lstUCOfficeType, String lstDisclosurePeriod,
            String lstElectionType, String lstElectionDate, String txtSubcontractorName, String txtPartFirstName,
            String txtPartMI, String txtPartLastName, String txtCountryPartnership, String txtPartStreetName,
            String txtPartCity, String txtPartState, String txtPartZip5, String txtPartAmt,
            String txtPartExplanationInKind, String lstItemizedSubcontr, String chkCountryPartnership, String lstIndividualSubcontr)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                #region Form Server Side Validation Schedule F - Subcontractor

                if (lstItemizedSubcontr == "Y")
                {
                    if (lstIndividualSubcontr == "N")
                    {
                        txtPartFirstName = "";
                        txtPartMI = "";
                        txtPartLastName = "";

                        if (txtSubcontractorName == "")
                        {
                            ModelState.AddModelError("txtPartnerName", "Partner Name is required");
                        }
                        else if (txtSubcontractorName != "")
                        {
                            if (!objCommonErrorsServerSide.EntityNameValidate(txtSubcontractorName))
                            {
                                ModelState.AddModelError("txtPartnerName", "Letters, numbers and characters '# -.,& are allowed");
                            }
                            else if (txtSubcontractorName.Count() > 40)
                            {
                                ModelState.AddModelError("txtPartnerName", "Partner Name should be 40 characters");
                            }
                        }
                    }
                    else
                    {
                        txtSubcontractorName = "";

                        if (txtPartFirstName == "")
                        {
                            ModelState.AddModelError("txtPartFirstName", "First Name is required");
                        }
                        else if (txtPartFirstName != "")
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

                        if (txtPartMI != "")
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

                        if (txtPartLastName == "")
                        {
                            ModelState.AddModelError("txtPartLastName", "Last Name is required");
                        }
                        else if (txtPartLastName != "")
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

                if (lstItemizedSubcontr != "Y" && lstItemizedSubcontr != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid Is Transaction Itemized");
                }

                //Double outstandingOrgAmt = Convert.ToDouble(String.Format("{0:0.00}", outOrginalAmount));

                //String strOutstandingDetailsAmount;
                //if (Session["OutstandingAmountDetails"].ToString() != "")
                //{
                //    strOutstandingDetailsAmount = Session["OutstandingAmountDetails"].ToString();
                //}
                //else
                //{
                //    strOutstandingDetailsAmount = outOrginalAmount;
                //}

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
                //else if (txtPartAmt != "")
                //{
                //    Double partnershipAmount = Convert.ToDouble(String.Format("{0:0.00}", txtPartAmt));
                //    Double outstandingAmount = Convert.ToDouble(String.Format("{0:0.00}", strOutstandingDetailsAmount));

                //    Double pendingAmount;
                //    if (outstandingOrgAmt == outstandingAmount)
                //    {
                //        if (recordCount == "1")
                //        {
                //            pendingAmount = outstandingAmount;
                //        }
                //        else
                //        {
                //            if (Convert.ToInt32(recordCount) > 1)
                //                pendingAmount = outstandingOrgAmt - outstandingAmount;
                //            else
                //                pendingAmount = outstandingOrgAmt;
                //        }
                //    }
                //    else
                //    {
                //        pendingAmount = outstandingOrgAmt - outstandingAmount;
                //    }

                //    if (partnershipAmount > pendingAmount)
                //    {
                //        ModelState.AddModelError("AmountError", "Partnership amount should not be more than outstanding amount");
                //    }
                //}

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

                #endregion Form Server Side Validation Schedule F - Subcontractor

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.FilingSchedId = ""; // Partnership/SubContractor.... strFilingSchedId;
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.OrgAmt = txtPartAmt;
                    objFilingTransactionsModel.ElectionDate = lstElectionDate;
                    objFilingTransactionsModel.ElectionTypeId = lstElectionType; //"P"; // lstElectionType; Testing Only...
                    objFilingTransactionsModel.ElectYearId = lstElectionCycleId;
                    objFilingTransactionsModel.OfficeTypeId = lstUCOfficeType;
                    objFilingTransactionsModel.FilingTypeId = lstDisclosurePeriod;
                    objFilingTransactionsModel.ElectionYear = lstElectionCycle;
                    if (lstItemizedSubcontr == "Y")
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

                    objFilingTransactionsModel.FlngEntName = txtSubcontractorName;
                    objFilingTransactionsModel.FlngEntFirstName = txtPartFirstName;
                    objFilingTransactionsModel.FlngEntLastName = txtPartLastName;
                    objFilingTransactionsModel.FlngEntMiddleName = txtPartMI;
                    objFilingTransactionsModel.FlngEntStrNum = "";
                    objFilingTransactionsModel.FlngEntCountry = txtCountryPartnership;
                    objFilingTransactionsModel.FlngEntStrName = txtPartStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtPartCity;
                    objFilingTransactionsModel.FlngEntState = txtPartState;
                    objFilingTransactionsModel.FlngEntZip = txtPartZip5;
                    objFilingTransactionsModel.TransExplanation = txtPartExplanationInKind;
                    objFilingTransactionsModel.RItemized = lstItemizedSubcontr;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); 
                    objFilingTransactionsModel.SchedID = "20";

                    Boolean results = objItemizedReportsBroker.AddContrInKindPartnersDataResponse(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveSchedFSubcontractorData

        #region UpdateSchedFSubcontractorData
        /// <summary>
        /// UpdateSchedFSubcontractorData
        /// </summary>
        /// <param name="strFilingTransId"></param>
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
        public JsonResult UpdateSchedFSubcontractorData(String strTransNumber, String strFilingEntityId,
            String txtPartshiptName, String txtPartFirstName, String txtPartMI, String txtPartLastName, String txtCountryPartnership,
            String txtPartStreetName, String txtPartCity, String txtPartState, String txtPartZip5, String txtPartZip4,
            String txtPartAmt, String txtPartExplanationInKind, String chkCountryPartnership)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (txtPartFirstName == "" && txtPartshiptName == "")
                    strFilingEntityId = null;

                if (txtPartZip5 == "00000-0000")
                    txtPartZip5 = "";

                #region Form Server Side Validation Schedule F Subcontractor

                if (txtPartshiptName != "")
                {
                    if (txtPartshiptName == "")
                    {
                        ModelState.AddModelError("txtPartnerName", "Partner Name is required");
                    }
                    else if (txtPartshiptName != "")
                    {
                        if (!objCommonErrorsServerSide.EntityNameValidate(txtPartshiptName))
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
                    if (txtPartFirstName != "")
                    {
                        if (txtPartFirstName == "")
                        {
                            ModelState.AddModelError("txtPartFirstName", "First Name is required");
                        }
                        else if (txtPartFirstName != "")
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

                        if (txtPartMI != "")
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

                        if (txtPartLastName == "")
                        {
                            ModelState.AddModelError("txtPartLastName", "Last Name is required");
                        }
                        else if (txtPartLastName != "")
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

                #endregion Form Server Side Validation Schedule F Subcontractor

                String strModifiedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only.

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateSchedFSubcontractorData

        #region DeleteSchedFSubcontractorData
        /// <summary>
        /// DeleteSchedFSubcontractorData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <returns></returns>
        public JsonResult DeleteSchedFSubcontractorData(String strTransNumber)
        {
            try
            {
                String strModifiedBy = Session["UserName"].ToString(); 

                Boolean results = objItemizedReportsBroker.DeleteContrInKindPartnersDataResponse(strTransNumber, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion DeleteSchedFSubcontractorData

        #region GetReimbursementData
        /// <summary>
        /// GetReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetReimbursementData(String strTransNumberReimb)
        {
            try
            {
                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                lstFilingTransactionsModel = objItemizedReportsBroker.GetFlngTransExpReimbursementDataResponse(strTransNumberReimb, strFilerId, "20");

                String strOriginalPayeeName = String.Empty;

                if (lstFilingTransactionsModel.Count > 0)
                {
                    strOriginalPayeeName = lstFilingTransactionsModel.Where(x => x.TransNumber == strTransNumberReimb).Select(x => x.FlngEntName).FirstOrDefault().ToString();
                    var itemRemove = lstFilingTransactionsModel.Single(x => x.TransNumber == strTransNumberReimb);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetReimbursementData

        #region GetCreditCardItemizationData
        /// <summary>
        /// GetCreditCardItemizationData
        /// </summary>
        /// <param name="strFilingTransIdReimb"></param>
        /// <returns></returns>
        public JsonResult GetCreditCardItemizationData(String strFilingTransIdCreditCardItem)
        {
            try
            {
                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

                lstFilingTransactionsModel = objItemizedReportsBroker.GetFlngTransExpReimbursementDataResponse(strFilingTransIdCreditCardItem, strFilerId, "20");

                String strOriginalPayeeName = String.Empty;

                if (lstFilingTransactionsModel.Count > 0)
                {
                    strOriginalPayeeName = lstFilingTransactionsModel.Where(x => x.TransNumber == strFilingTransIdCreditCardItem).Select(x => x.FlngEntName).FirstOrDefault().ToString();
                    var itemRemove = lstFilingTransactionsModel.Single(x => x.TransNumber == strFilingTransIdCreditCardItem);
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
                    x.TransNumber,
                    x.FilingEntId,
                    x.PurposeCodeId,
                    "",
                    "",
                    x.SchedDate,
                    x.OriginalPayeeName,
                    x.FlngEntName,
                    x.FlngEntStrName,
                    x.FlngEntCity,
                    x.FlngEntState,
                    x.FlngEntZip,
                    x.PurposeCodeDesc,
                    x.OrgAmt,
                    x.TransExplanation,
                    x.RItemized
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetCreditCardItemizationData

        #region SaveFlngTransExpReimbursementData
        /// <summary>
        /// SaveFlngTransExpReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
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
        public JsonResult SaveFlngTransExpReimbursementData(String strTransNumber, String strFilingSchedId,
            String txtDateRcvd, String txtAmtExpenditurePayments, String txtExplanationExpenditurePayments,
            String txtPayorName, String txtCountryReim, String txtStreetName, String txtCity, String txtState,
            String txtZipCode, String lstPurposeCode, String strItemized, String lstElectionType, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (strItemized == "Y")
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
                    lstPurposeCode = null;
                }

                #region Form Server Side Validation Schedule F - Reimbursement Details.

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
                }

                if (strItemized != "Y" && strItemized != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid is Transaction Itemized");
                }

                if (txtAmtExpenditurePayments == "")
                {
                    ModelState.AddModelError("txtPartAmt", "Amount Attributed is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanationExpenditurePayments != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationExpenditurePayments))
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    if (txtExplanationExpenditurePayments.Count() > 250)
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Explanation should be 250 characters");
                    }
                }

                #endregion Form Server Side Validation Schedule F - Reimbursement Details.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.FilingSchedId = strFilingSchedId;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.OrgAmt = txtAmtExpenditurePayments;
                    objFilingTransactionsModel.TransExplanation = txtExplanationExpenditurePayments;
                    objFilingTransactionsModel.FlngEntName = txtPayorName;
                    objFilingTransactionsModel.FlngEntCountry = txtCountryReim;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.RItemized = strItemized;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only....
                    if (Session["FilerId"] != null)
                        objFilingTransactionsModel.FilerId = Session["FilerId"].ToString();
                    else
                        objFilingTransactionsModel.FilerId = "";

                    objFilingTransactionsModel.SchedID = "20";
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion SaveFlngTransExpReimbursementData

        #region UpdateFlngTransExpReimbursementData
        /// <summary>
        /// UpdateFlngTransExpReimbursementData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingEntityId"></param>
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
        public JsonResult UpdateFlngTransExpReimbursementData(String strTransNumber, String strFilingEntityId, String strFilingSchedId,
            String txtDateRcvd, String txtAmtExpenditurePayments, String txtExplanationExpenditurePayments,
            String txtPayorName, String txtCountryReim, String txtStreetName, String txtCity, String txtState, String txtZipCode,
            String lstPurposeCode, String strItemized, String lstElectionType, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String chkCountry)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

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

                #region Form Server Side Validation Schedule F - Reimbursement Details.

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
                }

                if (strItemized != "Y" && strItemized != "N")
                {
                    ModelState.AddModelError("lstItemizedPart", "Invalid is Transaction Itemized");
                }

                if (txtAmtExpenditurePayments == "")
                {
                    ModelState.AddModelError("txtPartAmt", "Amount Attributed is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroValSched_ABC(txtAmtExpenditurePayments))
                {
                    ModelState.AddModelError("txtPartAmt", "Enter valid Amount (999999999.99)");
                }

                if (txtExplanationExpenditurePayments != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(txtExplanationExpenditurePayments))
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Letters, numbers and characters '# -., are allowed");
                    }
                    if (txtExplanationExpenditurePayments.Count() > 250)
                    {
                        ModelState.AddModelError("txtPartExplanationInKind", "Explanation should be 250 characters");
                    }
                }

                #endregion Form Server Side Validation Schedule F - Reimbursement Details.

                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.TransNumber = strTransNumber;
                    objFilingTransactionsModel.FilingSchedId = strFilingSchedId;
                    objFilingTransactionsModel.SchedDate = txtDateRcvd;
                    objFilingTransactionsModel.OrgAmt = txtAmtExpenditurePayments;
                    objFilingTransactionsModel.TransExplanation = txtExplanationExpenditurePayments;
                    if (strItemized == "Y")
                        objFilingTransactionsModel.FlngEntName = txtPayorName;
                    else
                        objFilingTransactionsModel.FlngEntName = "";
                    objFilingTransactionsModel.FlngEntCountry = txtCountryReim;
                    objFilingTransactionsModel.FlngEntStrName = txtStreetName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZipCode;
                    objFilingTransactionsModel.PurposeCodeId = lstPurposeCode;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString(); //"SBasireddy"; // Testing only....
                    if (Session["FilerId"] != null)
                        objFilingTransactionsModel.FilerId = Session["FilerId"].ToString();
                    else
                        objFilingTransactionsModel.FilerId = "";
                    objFilingTransactionsModel.SchedID = "20";

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion UpdateFlngTransExpReimbursementData

        #region GetSchedFLiablityData
        /// <summary>
        /// GetSchedFLiablityData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetSchedFLiablityData(String strFilingTransId)
        {
            try
            {
                IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

                String strFilerId = Session["FilerID"].ToString();

                lstOutstandingLiabilityModel = objItemizedReportsBroker.GetExpPaymentsLiabilityDataResponse(strFilingTransId, strFilerId);

                if (lstOutstandingLiabilityModel.Count > 0)
                {
                    var itemRemove = lstOutstandingLiabilityModel.Single(x => x.FilingTransId == strFilingTransId);
                    lstOutstandingLiabilityModel.Remove(itemRemove);
                }

                return Json(new
                {
                    aaData = lstOutstandingLiabilityModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingEntityId,
                    "",
                    "",
                    x.PayeeName,
                    x.DateIncurred,
                    x.OriginalAmount,
                    x.OutstandingAmount,
                    x.LiabilityStreetName,
                    x.LiabilityCity,
                    x.LiabilityState,
                    x.LiabilityZipCode,
                    x.LiabilityExplanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetSchedFLiablityData

        #region GetLiabilityDetailsOrgLiabData
        /// <summary>
        /// GetLiabilityDetailsOrgLiabData
        /// </summary>
        /// <param name="fiingTransID"></param>
        /// <param name="filingSchedID"></param>
        /// <param name="SchedName"></param>
        /// <returns></returns>
        public JsonResult GetLiabilityDetailsOrgLiabData(String fiingTransID, String filingSchedID, String SchedName)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilingTransID = fiingTransID;
                objFilingTransDataModel.FilingSchedID = filingSchedID;
                objFilingTransDataModel.SchedName = SchedName;
                objFilingTransDataModel.FilerId = Session["FilerID"].ToString();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsForScheduledIJNBroker(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/0001"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        //if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        //{
                        //    lstFilingTransactionDataModel[i].OwedAmount = "";
                        //}
                    }
                }


                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.ContributorTypeId,
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.OwedAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.ReceiptCodeDesc,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetLiabilityDetailsOrgLiabData

        #region GetLiabilityDetailsExpPaymentsData
        /// <summary>
        /// GetLiabilityDetailsExpPaymentsData
        /// </summary>
        /// <param name="fiingTransID"></param>
        /// <param name="filingSchedID"></param>
        /// <param name="SchedName"></param>
        /// <returns></returns>
        public JsonResult GetLiabilityDetailsExpPaymentsData(String fiingTransID, String filingSchedID, String SchedName)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilingTransID = fiingTransID;
                objFilingTransDataModel.FilingSchedID = filingSchedID;
                objFilingTransDataModel.SchedName = SchedName;
                objFilingTransDataModel.FilerId = Session["FilerID"].ToString();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsForScheduledIJNBroker(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/0001"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        //if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        //{
                        //    lstFilingTransactionDataModel[i].OwedAmount = "";
                        //}
                    }
                }


                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.ContributorTypeId,
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.OwedAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.ReceiptCodeDesc,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetLiabilityDetailsExpPaymentsData

        #region GetLiabilityDetailsOutLiabData
        /// <summary>
        /// GetLiabilityDetailsOutLiabData
        /// </summary>
        /// <param name="fiingTransID"></param>
        /// <param name="filingSchedID"></param>
        /// <param name="SchedName"></param>
        /// <returns></returns>
        public JsonResult GetLiabilityDetailsOutLiabData(String fiingTransID, String filingSchedID, String SchedName)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilingTransID = fiingTransID;
                objFilingTransDataModel.FilingSchedID = filingSchedID;
                objFilingTransDataModel.SchedName = SchedName;
                objFilingTransDataModel.FilerId = Session["FilerID"].ToString();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsForScheduledIJNBroker(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/0001"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        //if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        //{
                        //    lstFilingTransactionDataModel[i].OwedAmount = "";
                        //}
                    }
                }

                return Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.ContributorTypeId,
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.OwedAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.ReceiptCodeDesc,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetLiabilityDetailsOutLiabData

        #region GetLiabilityData
        /// <summary>
        /// GetLiabilityData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetLiabilityData(String strTransNumber)
        {
            try
            {
                IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

                String strFilerId = Session["FilerID"].ToString();

                lstOutstandingLiabilityModel = objItemizedReportsBroker.GetExpPaymentsLiabilityDataResponse(strTransNumber, strFilerId);

                var itemRemove = lstOutstandingLiabilityModel.Single(x => x.TransNumber == strTransNumber);

                lstOutstandingLiabilityModel.Remove(itemRemove);

                foreach (var item in lstOutstandingLiabilityModel)
                {
                    if (item != null)
                    {
                        item.DateIncurred = item.DateIncurred + " - " + item.OriginalAmount;
                    }
                }

                return Json(lstOutstandingLiabilityModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetLiabilityData

        #region GetCreditorNameExists
        /// <summary>
        /// GetCreditorNameExists
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public JsonResult GetCreditorNameExists(String strFilingEntityId, String strFlngEntityName)
        {
            try
            {
                Boolean returnValue = false;

                if (strFilingEntityId == null)
                    strFilingEntityId = "";
                if (strFlngEntityName == null)
                    strFlngEntityName = "";

                var results = objItemizedReportsBroker.GetExpenditureLiabilityExistsResponse(strFilingEntityId, strFlngEntityName, Session["FilerID"].ToString());

                if (results != "")
                    returnValue = true;

                return Json(returnValue, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetCreditorNameExists

        #region GetSubcontractorsDataExists
        /// <summary>
        /// GetSubcontractorsDataExists
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetSubcontractorsDataExists(String strFilingTransId)
        {
            try
            {
                Boolean results = objItemizedReportsBroker.GetSubcontracorsExistsResponse(strFilingTransId);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetSubcontractorsDataExists

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

                if (strFilingEntityId != "")
                {
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
                }

                return Json(new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult GetDateIncurredUpdate(String strTransNumber)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                String strFilerId = Session["FilerID"].ToString();

                lstDateIncurredModel = objItemizedReportsBroker.GetDateIncurredLiabUpdateDataResponse(strTransNumber, strFilerId);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDateIncurredUpdate

        #region GetDateIncurredForForgiven
        /// <summary>
        /// GetDateIncurredForForgiven
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public JsonResult GetDateIncurredForForgiven(String strFilingEntityId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                String strFilerId = Session["FilerId"].ToString();

                if (strFilingEntityId == null || strFilingEntityId == "")
                    if (Session["FilingEntId"] != null)
                        strFilingEntityId = Session["FilingEntId"].ToString();

                lstDateIncurredModel = objItemizedReportsBroker.mapGetDateIncurredLiabDataForForgivenBroker(strFilingEntityId, strFilerId);

                foreach (var item in lstDateIncurredModel)
                {
                    if (item != null)
                    {
                        item.OrginalDate = item.DateIncurredValue;
                        item.DateIncurredValue = item.DateIncurredValue + " - " + "$" + item.AmountLiability;
                    }
                }

                Session["DateIncurredOrgAmountForForgiven"] = lstDateIncurredModel;

                return Json(new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDateIncurredForForgiven

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

                if (Session["FilingEntId"] == null)
                {
                    if (lstOutstandingLiabilityModel.Count() > 0)
                    {
                        Session["FilingEntId"] = lstOutstandingLiabilityModel.Where(x => x.PayeeName.ToLower() == strPayeeName.ToLower()).Select(x => x.FilingEntityId).FirstOrDefault().ToString();
                    }
                }
                else
                {
                    if (lstOutstandingLiabilityModel.Count() > 0)
                    {
                        for (int i = 0; i < lstOutstandingLiabilityModel.Count; i++)
                        {
                            if (lstOutstandingLiabilityModel[i] != null)
                            {
                                lstOutstandingLiabilityModel[i].FilingEntityId = Session["FilingEntId"].ToString();
                            }
                        }
                    }
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPayeeNameExistsLiability

        #region GetOriginalAmountValue
        /// <summary>
        /// GetOriginalAmountValue
        /// </summary>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public JsonResult GetOriginalAmountValue(String strFlngTransId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                lstDateIncurredModel = (List<DateIncurredModel>)Session["DateIncurredOrgAmount"];

                String strOriginalAmount = lstDateIncurredModel.Where(x => x.DateIncurredId == strFlngTransId).Select(x => x.AmountLiability).First().ToString();

                return Json(strOriginalAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOriginalAmountValue

        #region GetOriginalDateValue
        /// <summary>
        /// GetOriginalDateValue
        /// </summary>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public JsonResult GetOriginalDateValue(String strFlngTransId)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

                lstDateIncurredModel = (List<DateIncurredModel>)Session["DateIncurredOrgAmount"];

                String strOriginalDate = lstDateIncurredModel.Where(x => x.DateIncurredId == strFlngTransId).Select(x => x.OrginalDate).FirstOrDefault().ToString();

                return Json(strOriginalDate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOriginalDateValue

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
                            // NOT OUTSTANDING AMOUNT ITS TOTAL PAYMENT AMOUNT...
                            // DO CALCULATIONS HERE....
                            // SUBSTRACT ORIGINAL AMOUNT FROM TOTAL PAYMENT AMOUNT THEN WILL GET OUTSTANDING AMOUNT....
                            // ORIGINAL AMT - TOTAL PAYMENT AMT = OUTSTANDING AMOUNT.

                            String strOriginalAmount = String.Empty;

                            // NOT REQUIRED TO FIND OUT ORGINAL AMOUNT...
                            // ... DIRECT PROCEDURE GETING OUTSTANDING AMOUNT....

                            //lstDateIncurredModel = (IList<DateIncurredModel>)Session["DateIncurredOrgAmount"];
                            //strOriginalAmount = lstDateIncurredModel.Where(x => x.DateIncurredId == strFilingTransId).Select(x => x.AmountLiability).First().ToString();

                            strOutstandingAmount = item.OutstandingAmount.ToString();

                            //// DECIMAL VALUES.
                            //Decimal dOriginalAmount = Convert.ToDecimal(strOriginalAmount);
                            //Decimal dTotalPayAmount = Convert.ToDecimal(strOutstandingAmount);
                            //Decimal dOutstandingAmount;

                            //dOutstandingAmount = dOriginalAmount - dTotalPayAmount;

                            //strOutstandingAmount = dOutstandingAmount.ToString();    
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOutstandingAmount

        #region GetReimbursementDetailsTotalAmt
        /// <summary>
        /// GetReimbursementDetailsTotalAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetReimbursementDetailsTotalAmt(String strTransNumber)
        {
            try
            {
                String strReimbursementDetailsAmt = String.Empty;

                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                strReimbursementDetailsAmt = objItemizedReportsBroker.GetReimbursementDetailsAmtResponse(strTransNumber, strFilerId, "20");

                return Json(strReimbursementDetailsAmt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetReimbursementDetailsTotalAmt

        #region GetCreditCardItemTotalAmt
        /// <summary>
        /// GetCreditCardItemTotalAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetCreditCardItemTotalAmt(String strTransNumber)
        {
            try
            {
                String strReimbursementDetailsAmt = String.Empty;

                String strFilerId = String.Empty;
                if (Session["FilerId"] != null)
                    strFilerId = Session["FilerId"].ToString();

                strReimbursementDetailsAmt = objItemizedReportsBroker.GetReimbursementDetailsAmtResponse(strTransNumber, strFilerId, "20");

                return Json(strReimbursementDetailsAmt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetCreditCardItemTotalAmt

        #region GetExpLiabilityOwedAmount
        /// <summary>
        /// GetExpLiabilityOwedAmount
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        public JsonResult GetExpLiabilityOwedAmount()
        {
            try
            {
                String strExpLiabilityOwedAmount = String.Empty;
                String strFlngEntityId = String.Empty;

                if (Session["FilingEntId"] != null)
                    strFlngEntityId = Session["FilingEntId"].ToString();

                strExpLiabilityOwedAmount = objItemizedReportsBroker.GetExpLiabilityOwedAmtResponse(strFlngEntityId, Session["FilerID"].ToString());

                return Json(strExpLiabilityOwedAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpLiabilityOwedAmount

        #region GetExpLiabilityOwedAmountUpdate
        /// <summary>
        /// GetExpLiabilityOwedAmountUpdate
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        public JsonResult GetExpLiabilityOwedAmountUpdate(String strFlngEntityId)
        {
            try
            {
                String strExpLiabilityOwedAmount = String.Empty;

                strExpLiabilityOwedAmount = objItemizedReportsBroker.GetExpLiabilityOwedAmtResponse(strFlngEntityId, Session["FilerID"].ToString());

                return Json(strExpLiabilityOwedAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpLiabilityOwedAmountUpdate

        #region GetExpSubContrTotAmt
        /// <summary>
        /// GetExpSubContrTotAmt
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmt(String strTransNumber)
        {
            try
            {
                String strExpSubContrTotAmt = String.Empty;

                String strFilerId = Session["FilerID"].ToString();

                strExpSubContrTotAmt = objItemizedReportsBroker.GetExpSubContrTotAmtResponse(strTransNumber, strFilerId);

                return strExpSubContrTotAmt;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpSubContrTotAmt

        #region GetOUtstandingLiabilityAmount
        /// <summary>
        /// GetOUtstandingLiabilityAmount
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public JsonResult GetOUtstandingLiabilityAmount(String strFlngEntityId, String strFlngTransId)
        {
            try
            {
                String strOutstandingLiablityAmount = String.Empty;

                strOutstandingLiablityAmount = objItemizedReportsBroker.GetOutstandingLiabilityAmountResponse(strFlngEntityId, strFlngTransId);

                return Json(strOutstandingLiablityAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOUtstandingLiabilityAmount

        #region GetExpPayTotalLiabAmount
        /// <summary>
        /// GetExpPayTotalLiabAmount
        /// </summary>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public JsonResult GetExpPayTotalLiabAmount(String strTransNumber)
        {
            try
            {
                String strExpPayTotalLiabAmount = String.Empty;

                strExpPayTotalLiabAmount = objItemizedReportsBroker.GetExpPayTotalLiabAmountResponse(strTransNumber, Session["FilerID"].ToString());

                return Json(strExpPayTotalLiabAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpPayTotalLiabAmount

        #region GetPurposeCodeReimDetails
        /// <summary>
        /// GetPurposeCodeReimDetails
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeReimDetails()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeReimburDetailsDataResponse();
                // Bind Purpose Code            
                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeReimDetails

        #region GetPurposeCodesSubcontractor
        public JsonResult GetPurposeCodesSubcontractor()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeSubcontractorSchedFResponse();
                // Bind Purpose Code            
                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodesSubcontractor

        #region GetPurposeCodesCreditCardItem
        /// <summary>
        /// GetPurposeCodesCreditCardItem
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodesCreditCardItem()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeCreditCardItemSchedFResponse();
                // Bind Purpose Code  
                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodesCreditCardItem

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
                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeDataResponse();
                // Bind Purpose Code            
                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeExpenditure

        #region GetPurposeCodeExpLiability
        /// <summary>
        /// GetPurposeCodeExpLiability
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodeExpLiability()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeDataResponse();

                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();

                var itemRemoveInternetExpenses = lstPurposeCodeModel.Single(x => x.PurposeCodeId == "10");
                lstPurposeCodeModel.Remove(itemRemoveInternetExpenses);
                var itemRemoveBankFee = lstPurposeCodeModel.Single(x => x.PurposeCodeId == "22");
                lstPurposeCodeModel.Remove(itemRemoveBankFee);

                // Bind Purpose Code                        
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeExpLiability

        #region GetPurposeCodesDefault
        /// <summary>
        /// GetPurposeCodesDefault
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPurposeCodesDefault()
        {
            try
            {
                IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

                lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeDataResponse();

                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();

                // Bind Purpose Code                        
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodesDefault

        #region GetExpPayTransIdPopUp
        /// <summary>
        /// GetExpPayTransIdPopUp
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetExpPayTransIdPopUp(String strTransNumber)
        {
            try
            {
                IList<ExpPaymentTransIdPopUpSchedFModel> lstExpPaymentTransIdPopUpSchedFModel = new List<ExpPaymentTransIdPopUpSchedFModel>();

                lstExpPaymentTransIdPopUpSchedFModel = objItemizedReportsBroker.GetExpPayTransIdPopUpSchedFResponse(strTransNumber, Session["FilerID"].ToString());

                return Json(lstExpPaymentTransIdPopUpSchedFModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpPayTransIdPopUp

        #region AutoComplete First, Last, and Entity Name
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// AutoCompleteEntityName
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteEntityName(String term)
        {
            try
            {
                String strFilerId = Session["FilerId"].ToString();
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

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

                if (lstAutoCompFLNameAddressModel.Count() > 0)
                    Session["LiabilityNameFound"] = "Yes";

                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;

                Session.Remove("EntityNameLiability");

                Session["FilingEntId"] = null;

                EntityNames = lstOutstandingLiabilityModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                // IT IS GETTING DISTRICT RECORDS BASED ON NAME AND ADDRESS IT IS NOT CHECKING ENEITY ID.
                // SO WE NEED TO ADD ENTITY ID IF REQUIRED. BUT DISTRICT WORKING FINE.
                //var EntityNames1 = lstOutstandingLiabilityModel.Select(x => new { x.FilingEntityNameAndAddress, x.FilingEntityId }).Distinct().ToList();
                //EntityNames = EntityNames1.Select(x => x.FilingEntityNameAndAddress).ToList();

                return Json(EntityNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetAutoCompleteCreditorNameData(String strValue)
        {
            try
            {
                IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

                lstOutstandingLiabilityModel = (IList<OutstandingLiabilityModel>)Session["lstOutstandingLiabilityModel"];

                String strResult = lstOutstandingLiabilityModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityId).FirstOrDefault().ToString();

                Session["FilingEntId"] = strResult;

                lstOutstandingLiabilityModel = lstOutstandingLiabilityModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstOutstandingLiabilityModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #endregion AutoComplete First, Last, and Entity Name

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPaymentMethodData

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

                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();

                // Bind Purpose Code            
                return Json(new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetPurposeCodeData

        #region GetOriginalLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOriginalLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetOriginalLiabilityData(String strTransNumber)
        {
            try
            {
                IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

                if (strTransNumber != "")
                {
                    lstLiabilityDetailsModel = objItemizedReportsBroker.GetOriginalLiabilityDataResponse(strTransNumber, Session["FilerID"].ToString());

                    for (int i = 0; i < lstLiabilityDetailsModel.Count; i++)
                    {
                        if (lstLiabilityDetailsModel[i] != null)
                        {
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/0001"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].TransactionDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].TransactionDate = "";
                            lstLiabilityDetailsModel[i].OriginalDate = "";
                        }
                    }
                }

                return Json(new
                {
                    aaData = lstLiabilityDetailsModel.Select(x => new[] {
                    x.FilingTransId,
                    x.TransNumber,
                    "",
                    x.TransactionDate,
                    x.TransactionType,
                    x.ContributorCode,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingState,
                    x.FilingCity,
                    x.FilingZip,
                    x.PaymentType,
                    x.PayNumber,
                    x.Amount,
                    x.OutstandingAmount,
                    x.RecieptType,
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.RecieptCdoe,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.County,
                    x.Municipality,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOriginalLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region GetExpenditurePaymentLiabilityData GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.
        /// <summary>
        /// GetExpenditurePaymentLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetExpenditurePaymentLiabilityData(String strTransNumber)
        {
            try
            {
                IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

                if (strTransNumber != "")
                {
                    lstLiabilityDetailsModel = objItemizedReportsBroker.GetExpenditurePaymentLiabilityDataResponse(strTransNumber, Session["FilerID"].ToString(), "6");

                    for (int i = 0; i < lstLiabilityDetailsModel.Count; i++)
                    {
                        if (lstLiabilityDetailsModel[i] != null)
                        {
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/0001"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].TransactionDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].TransactionDate = "";
                            lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OutstandingAmount == "0.00")
                                lstLiabilityDetailsModel[i].OutstandingAmount = "";
                        }
                    }
                }

                return Json(new
                {
                    aaData = lstLiabilityDetailsModel.Select(x => new[] {
                    x.FilingTransId,
                    x.TransNumber,
                    "",
                    x.TransactionDate,
                    x.TransactionType,
                    x.ContributorCode,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingState,
                    x.FilingCity,
                    x.FilingZip,
                    x.PaymentType,
                    x.PayNumber,
                    x.Amount,
                    x.OutstandingAmount,
                    x.RecieptType,
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.RecieptCdoe,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.County,
                    x.Municipality,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpenditurePaymentLiabilityData GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.


        /// <summary>
        /// GetQualifiedExpendituresLiabilityData Sched T
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetQualifiedExpendituresLiabilityData(String strTransNumber)
        {
            try
            {
                IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

                if (strTransNumber != "")
                {
                    lstLiabilityDetailsModel = objItemizedReportsBroker.GetExpenditurePaymentLiabilityDataResponse(strTransNumber, Session["FilerID"].ToString(), "20");

                    for (int i = 0; i < lstLiabilityDetailsModel.Count; i++)
                    {
                        if (lstLiabilityDetailsModel[i] != null)
                        {
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/0001"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].TransactionDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].TransactionDate = "";
                            lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OutstandingAmount == "0.00")
                                lstLiabilityDetailsModel[i].OutstandingAmount = "";
                        }
                    }
                }

                return Json(new
                {
                    aaData = lstLiabilityDetailsModel.Select(x => new[] {
                    x.FilingTransId,
                    x.TransNumber,
                    "",
                    x.TransactionDate,
                    x.TransactionType,
                    x.ContributorCode,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingState,
                    x.FilingCity,
                    x.FilingZip,
                    x.PaymentType,
                    x.PayNumber,
                    x.Amount,
                    x.OutstandingAmount,
                    x.RecieptType,
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.RecieptCdoe,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.County,
                    x.Municipality,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetOutstandingLiabilityData GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOutstandingLiabilityData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetOutstandingLiabilityData(String strTransNumber)
        {
            try
            {
                IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

                if (strTransNumber != "")
                {
                    lstLiabilityDetailsModel = objItemizedReportsBroker.GetOutstandingLiabilityDataResponse(strTransNumber, Session["FilerID"].ToString());

                    for (int i = 0; i < lstLiabilityDetailsModel.Count; i++)
                    {
                        if (lstLiabilityDetailsModel[i] != null)
                        {
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/0001"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].TransactionDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].TransactionDate = "";
                            lstLiabilityDetailsModel[i].OriginalDate = "";
                        }
                    }
                }

                return Json(new
                {
                    aaData = lstLiabilityDetailsModel.Select(x => new[] {
                    x.FilingTransId,
                    x.TransNumber,
                    "",
                    x.TransactionDate,
                    x.TransactionType,
                    x.ContributorCode,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingState,
                    x.FilingCity,
                    x.FilingZip,
                    x.PaymentType,
                    x.PayNumber,
                    x.Amount,
                    x.OutstandingAmount,
                    x.RecieptType,
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.RecieptCdoe,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.County,
                    x.Municipality,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOutstandingLiabilityData GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region GetLiabilityForgivenData GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.
        /// <summary>
        /// GetLiabilityForgivenData
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetLiabilityForgivenData(String strTransNumber)
        {
            try
            {
                IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

                if (strTransNumber != "")
                {
                    lstLiabilityDetailsModel = objItemizedReportsBroker.GetLiabilityForgivenDataResponse(strTransNumber, Session["FilerID"].ToString());

                    for (int i = 0; i < lstLiabilityDetailsModel.Count; i++)
                    {
                        if (lstLiabilityDetailsModel[i] != null)
                        {
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].OriginalDate.Contains("1/1/0001"))
                                lstLiabilityDetailsModel[i].OriginalDate = "";
                            if (lstLiabilityDetailsModel[i].TransactionDate.Contains("1/1/1900"))
                                lstLiabilityDetailsModel[i].TransactionDate = "";
                        }
                    }
                }

                return Json(new
                {
                    aaData = lstLiabilityDetailsModel.Select(x => new[] {
                    x.FilingTransId,
                    x.TransNumber,
                    "",
                    x.TransactionDate,
                    x.TransactionType,
                    x.ContributorCode,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingState,
                    x.FilingCity,
                    x.FilingZip,
                    x.PaymentType,
                    x.PayNumber,
                    x.Amount,
                    x.OutstandingAmount,
                    x.RecieptType,
                    x.TransferType,
                    x.ContributionType,
                    x.PurposeCode,
                    x.RecieptCdoe,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.County,
                    x.Municipality,
                    x.CreatedDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetLiabilityForgivenData GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.

        #region GetScheduleFHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleFHelpPopUp()
        {
            return View("GetScheduleFHelpPopUp");
        }
        #endregion GetScheduleFHelpPopUp

        #region ExpenditureRefundSchedLExists
        /// <summary>
        /// ExpenditureRefundSchedLExists
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult ExpenditureRefundSchedLExists(String strTransNumber)
        {
            try
            {
                String results = objItemizedReportsBroker.GetExpPaymentExistsSchedLResponse(strTransNumber, Session["FilerID"].ToString(), "20");

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion ExpenditureRefundSchedLExists

        #region GetExpRefundedTotalAmt
        /// <summary>
        /// GetExpRefundedTotalAmt
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public JsonResult GetExpRefundedTotalAmt(String strTransNumber)
        {
            try
            {
                String results = objItemizedReportsBroker.GetExpRefundedSchedFTotalAmtResponse(strTransNumber, Session["FilerID"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetExpRefundedTotalAmt               

        #region GetDefaultLookUpsValues
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
                // Bind Contribution Name
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

                var lstiPurposeCode = new string[] { "1", "2" , "5" , "6", "7", "8", "9", "10", "11", "13", "14", "15"
                    , "16", "17", "18", "19", "21", "22", "23", "24", "29", "31", "32", "33", "34", "35", "36", "37", "38", "40"
                    , "41", "42", "43", "45", "46", "47", "48" };

                lstPurposeCodeModel = lstPurposeCodeModel.Where(x => lstiPurposeCode.Contains(x.PurposeCodeId)).ToList();

                // Bind Purpose Code            
                ViewData["lstPurposeCode"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");
                ViewData["lstPurposeCodeItem"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");
                ViewData["lstPurposeCodeReim"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");
                ViewData["lstPurposeCodeCCI"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");
                ViewData["lstPurposeCodeReim"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");

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

                List<ItemizedModel> lstItemizedModelForList = new List<ItemizedModel>();
                ItemizedModel objItemizedModelForList;
                objItemizedModelForList = new ItemizedModel();
                objItemizedModelForList.strItemizedId = "Y";
                objItemizedModelForList.strItemizedName = "Yes";
                lstItemizedModelForList.Add(objItemizedModelForList);

                // Bind Subcontractor
                ViewData["lstItemized"] = new SelectList(lstItemizedModelForList, "strItemizedId", "strItemizedName", 1);
                ViewData["lstItemizedSubcontr"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
                ViewData["lstItemizedCCI"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
                ViewData["lstItemizedReim"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
                ViewData["lstIndividualSubcontr"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);

                List<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                DateIncurredModel objDateIncurredModel;
                objDateIncurredModel = new DateIncurredModel();
                objDateIncurredModel.DateIncurredId = "0";
                objDateIncurredModel.DateIncurredValue = "- Select -";
                lstDateIncurredModel.Add(objDateIncurredModel);
                // Bind Date Incurred
                ViewData["lstDateIncurred"] = new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue");

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
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ExpenditurePaymentsSchedFController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDefaultLookUpsValues


    }
}