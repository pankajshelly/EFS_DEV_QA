/*
 * =====================================================================
 * PAGE NAME: Public Fund Receipts (SCHEDULE S TRANSACTIONS).
 * AUTHOR NAME: Pankaj Agarwal
 * CREATED DATE: 11/07/2022
 * UPDATED BY:
 * UPDATED DATE:
 * =========================================================================
 * 
*/

using Broker;
using CAPASFIDAS_EFS.CommonErrors;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Net;
using System.Web.UI;

namespace CAPASFIDAS_EFS.Controllers
{
    public class PublicFundReceiptsSchedSController : Controller
    {
        #region Global Variables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        #endregion Global Variables

        // GET: PublicFundReceiptsSchedS
        public ActionResult PublicFundReceiptsSchedS()
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

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ContributionsMonetaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

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

            var lstPaymentType = new string[] { "1", "5" };
            lstPaymentMethodModel = lstPaymentMethodModel.Where(x => lstPaymentType.Contains(x.PaymentTypeId)).ToList();
            // Payment Method
            ViewData["lstMethod"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");

            IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();
            lstReceiptTypeModel = objItemizedReportsBroker.GetReceiptTypeDataResponse();
            lstReceiptTypeModel = lstReceiptTypeModel.Where(x => x.ReceiptTypeId == "4").ToList();
            // Bind Receipt Code
            ViewData["lstReceiptType"] = new SelectList(lstReceiptTypeModel, "ReceiptTypeId", "ReceiptTypeDesc");            

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
        #endregion GetDefaultLookUpsValues

        /// <summary>
        /// GetReportSourceDataSchedS
        /// </summary>
        /// <returns></returns>
        public JsonResult GetReportSourceDataSchedS()
        {
            IList<ReportSourceModel> lstReportSourceModel = new List<ReportSourceModel>();
            lstReportSourceModel = objItemizedReportsBroker.GetReportSourceDataSchedSBroker();
            Session["ReportSourceData"] = lstReportSourceModel;
            return Json(lstReportSourceModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AddTransferInScheduledData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="lstFilingEntId"></param>
        /// <param name="strReceiptTypeId"></param>
        /// <param name="PaymentTypeId"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstElectYearId"></param>
        /// <param name="strFilingDate"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <param name="electionDateId"></param>
        /// <param name="lstResigTermType"></param>
        /// <param name="txtCuttOffDate"></param>
        /// <returns></returns>
        public JsonResult AddPublicFundReceiptScheduledData(String txtFilerId, String strFilingSchedDate, 
            String strReceiptTypeId, String PaymentTypeId,
            String strPayNumber, String strOrgAmt, String strTransExplanation, String strElectionTypeId, 
            String lstOfficeTypeId, String lstFilingTypeId, String lstElectYearId,  String strFilingDate,
            String txtReportPeriodDatesTo, String electionDateId, String lstResigTermType, String txtCuttOffDate)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (PaymentTypeId == "0")
                {
                    PaymentTypeId = "";
                    strPayNumber = "";
                }

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                #region FormValidationScheduleS                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateReceived", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (strElectionTypeId == "6")
                {
                    if (strFilingDate == "- New Filing Date -")
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                        {
                            ModelState.AddModelError("txtCurrentDateReceived", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                    else
                    {
                        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, strFilingDate))
                        {
                            ModelState.AddModelError("txtCurrentDateReceived", "Date Received cannot be later than Cut Off Date");
                        }
                    }
                }

                if (PaymentTypeId == "1")
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

                if (PaymentTypeId != "")
                {
                    if (PaymentTypeId != "0")
                    {
                        Boolean resultsData = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", PaymentTypeId.ToString());
                        if (!resultsData)
                        {
                            ModelState.AddModelError("lstMethod", "Invalid Method");
                        }
                    }
                }


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
                else if (!objCommonErrorsServerSide.AmountZeroVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (strTransExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                    {
                        ModelState.AddModelError("txtExplanationCommon", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtExplanationCommon", "Explanation should be 250 characters");
                    }
                }
                #endregion FormValidationScheduleS

                string results = string.Empty;
                if (ModelState.IsValid)
                {
                    IList<ReportSourceModel> lstReportSourceModel = new List<ReportSourceModel>();
                    lstReportSourceModel = (IList<ReportSourceModel>)Session["ReportSourceData"];
                    objFilingTransactionsModel.FilerId = txtFilerId;
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.FilingEntId = lstReportSourceModel[0].FilingEntityId.ToString();
                    objFilingTransactionsModel.ReceiptTypeId = strReceiptTypeId;
                    objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                    objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                    objFilingTransactionsModel.ElectYearId = lstElectYearId;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                    {
                        if (strFilingDate == "- New Filing Date -")
                            objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                        else
                            objFilingTransactionsModel.FilingDate = strFilingDate;
                    }
                    else // OTHER THAN OFF-CYCLE FILING DATE
                    {
                        objFilingTransactionsModel.FilingDate = txtReportPeriodDatesTo;
                    }
                    objFilingTransactionsModel.ElectionDateId = electionDateId;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();

                    results = objItemizedReportsBroker.AddPublic_Fund_Receipts_SchedS_Broker(objFilingTransactionsModel);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferInScheGController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// UpdatePublicFundReceiptsData
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="transNumber"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="PaymentTypeId"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <returns></returns>
        public JsonResult UpdatePublicFundReceiptsData(String txtFilerId, String transNumber, String strFilingSchedDate, String PaymentTypeId,
                                                        String strPayNumber, String strOrgAmt, String strTransExplanation)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (PaymentTypeId == "0")
                {
                    PaymentTypeId = "";
                    strPayNumber = "";
                }                

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateReceived", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateReceived", "Enter valid date format (MM/DD/YYYY)");
                }
               

                if (PaymentTypeId == "1")
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

                if (PaymentTypeId != "")
                {
                    if (PaymentTypeId != "0")
                    {
                        Boolean resultsData = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", PaymentTypeId.ToString());
                        if (!resultsData)
                        {
                            ModelState.AddModelError("lstMethod", "Invalid Method");
                        }
                    }
                }


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
                else if (!objCommonErrorsServerSide.AmountZeroVal(strOrgAmt))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }

                if (strTransExplanation != "")
                {
                    if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strTransExplanation))
                    {
                        ModelState.AddModelError("txtExplanationCommon", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }
                #endregion FormValidationScheduleA
                if (ModelState.IsValid)
                {
                    objFilingTransactionsModel.FilerId = txtFilerId;
                    objFilingTransactionsModel.TransNumber = transNumber;
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.PaymentTypeId = PaymentTypeId;
                    objFilingTransactionsModel.PayNumber = strPayNumber;
                    objFilingTransactionsModel.OrgAmt = strOrgAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;                    
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    var results = objItemizedReportsBroker.UpdateFlngtrans_PublicFundRecptBroker(objFilingTransactionsModel);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TransferInScheGController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}