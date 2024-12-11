using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Web.Mvc;
using Broker;
using SAML_Interface;
using System.Configuration;


namespace CAPASFIDAS_EFS.Controllers
{
    public class FileDisclosureSummeryController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        public ActionResult FileDisclosureSummery()
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
                    if (Session["PersonId"] == null)
                    {
                        Session["PersonId"] = "4929"; //"23161";
                    }
                    if (Session["FilerId"] == null)
                    {
                        Session["FilerId"] = "113070"; // Testing only replace with main Session (Login).
                    }


                    // Bind Filer ID
                    var lstFilerID = new SelectList(new[]
                                                  {
                                              new {ID="-Select-",Name="-Select-"},
                                          },
                                    "ID", "Name", 1);
                    ViewData["lstFilerID"] = lstFilerID;

                    GetDefaultLookUpsValues();
                }

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        #region GetDefaultLookUpsValues
        /// <summary>
        /// GetDefaultLookUpsValues
        /// </summary>
        public void GetDefaultLookUpsValues()
        {
            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            Session["PersonFilerId"] = lstFilerCommitteeModel;
            String strCommId = "";
            // Filer ID
            if (Session["FILER_INFO"] != null)
            {
                IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
                listFilerInfo = (IList<FilerInfoModel>)Session["FILER_INFO"];
                ViewData["txtFilerID"] = new SelectList(listFilerInfo, "Filer_ID", "Filer_ID");
                ViewData["txtCommitteeName"] = new SelectList(listFilerInfo, "Cand_Comm_Name", "Cand_Comm_Name");
                Session["CommitteeDataInLieuOf"] = listFilerInfo;
                strCommId = listFilerInfo[0].Cand_Comm_ID.ToString();
            }
            else
            {
                ViewData["txtFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");
                String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
                lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
                strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
                Session["CommitteeDataInLieuOf"] = lstFilerCommitteeModel;
                // Committee Name
                ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeName", "CommitteeName");
            }

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
            lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
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
            if (Session["ElectionCycleVal"] != null)
            {
                String strElectionCycle = Session["ElectionCycleVal"].ToString();
                String strElectionType = Session["ElectionTypeVal"].ToString();
                String strOffictType = Session["OfficeTypeVal"].ToString();

                lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(strElectionCycle, strElectionType, strOffictType, Session["CountyVal"].ToString(), Session["MunicipalityVal"].ToString());
            }
            else
            {
                lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(String.Empty, String.Empty, String.Empty, "", "");
            }
            // Electin Date
            ViewData["lstElectionDate"] = new SelectList(lstElectionDateModel, "ElectId", "ElectDate");

            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(), "");
            // Disclosure Period
            ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
            lstPaymentMethodModel = objItemizedReportsBroker.GetPaymentMethodDataResponse();
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

            // Bind Summary View
            var lstSummaryOptions = new SelectList(new[]
                                          {
                                              new {ID="1",Name="As Entered"},
                                              new {ID="2",Name="By Transaction Type"},
                                              new {ID="3",Name="By Schedule"},
                                          },
                            "ID", "Name", 1);
            ViewData["lstSummaryOptions"] = lstSummaryOptions;

        }
        #endregion GetDefaultLookUpsValues

        /// <summary>
        /// GetMunicipality
        /// </summary>
        /// <param name="lstUCCounty"></param>
        /// <returns></returns>
        public JsonResult GetMunicipality(String lstUCCounty)
        {
            try
            {
                IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
                lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(lstUCCounty);
                // Bind Municipality
                return Json(new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetElectionType
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstOfficeType"></param>
        /// <param name="lstCounty"></param>
        /// <param name="lstMunicipality"></param>
        /// <returns></returns>
        public JsonResult GetElectionType(String lstElectionCycle, String lstOfficeType, String lstCounty, String lstMunicipality)
        {
            try
            {
                IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();

                lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(lstElectionCycle,
                    lstOfficeType, lstCounty, lstMunicipality, Session["COMM_TYPE_ID"].ToString());

                return Json(new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }

        /// <summary>
        /// GetElectionDate
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetElectionDate(String lstElectionCycle, String lstElectionType, String lstOfficeType)
        {
            try
            {
                if (lstElectionCycle == "- Select -")
                    lstElectionCycle = "";
                if (lstElectionType == "- Select -")
                    lstElectionType = "";
                if (lstOfficeType == "- Select -")
                    lstOfficeType = "";

                if (lstOfficeType == "1")
                    lstOfficeType = "4";

                Session["ElectionCycleVal"] = lstElectionCycle.ToString();
                Session["ElectionTypeVal"] = lstElectionType.ToString();
                Session["OfficeTypeVal"] = lstOfficeType.ToString();

                IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();

                lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(lstElectionCycle, lstElectionType, lstOfficeType, Session["CountyVal"].ToString(), Session["MunicipalityVal"].ToString());

                return Json(new SelectList(lstElectionDateModel, "ElectId", "ElectDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetDisclosurePeriod
        /// </summary>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetDisclosurePeriod(String lstElectionType)
        {
            try
            {
                if (lstElectionType == "- Select -")
                    lstElectionType = "";

                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(lstElectionType, Session["FilerID"].ToString(), "");

                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetFilingCutOffDate
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <returns></returns>
        public JsonResult GetFilingCutOffDate(String lstElectionCycle, String lstElectionType, String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionDateId)
        {
            try
            {
                String strFilingDateId = String.Empty;
                String strCuttOffDateId = String.Empty;

                if (lstUCOfficeType == "1")
                    lstUCOfficeType = "4";

                if (lstDisclosurePeriod == "1") // 32 Day Pre-Primary
                {
                    strFilingDateId = "59";
                    strCuttOffDateId = "60";
                }
                else if (lstDisclosurePeriod == "2") // 11 Day Pre-Primary
                {

                }
                else if (lstDisclosurePeriod == "3") // 10 Day Post-Primary
                {
                    strFilingDateId = "65";
                    strCuttOffDateId = "66";
                }
                else if (lstDisclosurePeriod == "4") // 32 Day Pre-General
                {

                }
                else if (lstDisclosurePeriod == "5") // 11 Day Pre-General
                {

                }
                else if (lstDisclosurePeriod == "6") // 27 Day Post-General
                {

                }
                else if (lstDisclosurePeriod == "7") // 32 Day Pre-Speceial
                {

                }
                else if (lstDisclosurePeriod == "8") // 11 Day Pre-Special
                {

                }
                else if (lstDisclosurePeriod == "9") // 27 Day Post-Special
                {

                }
                else if (lstDisclosurePeriod == "10") // January Periodic
                {

                }
                else if (lstDisclosurePeriod == "11") // July Periodic
                {

                }
                else if (lstDisclosurePeriod == "12") // Off Cycle
                {

                }

                IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

                lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateDataResponse(lstElectionCycle, lstElectionType, lstUCOfficeType,
                    strFilingDateId, strCuttOffDateId, lstElectionDateId);

                return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Submit filings from summery page
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstElectYearId"></param>
        /// <returns></returns>
        public JsonResult SubmitFilings_Summery(String txtFilerId, String lstOfficeTypeId, String lstFilingTypeId, String lstElectYearId)
        {
            try
            {
                var results = true;

                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;            
                objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                objFilingTransactionsModel.ElectYearId = "16";
                objFilingTransactionsModel.CreatedBy = "Admin"; // Testing Only...
                results = objItemizedReportsBroker.SubmitFilings_SummeryBroker(objFilingTransactionsModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region Get Filing Transaction Summery
        /// <summary>
        /// Get Filing Transaction Summery
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>;
        /// <returns></returns>
        public JsonResult GetFilingTransactionsDataSummary(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstDisclosurePeriod, String lstFilingSchedID)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
                objFilingTransDataModel.FilingSchedID = lstFilingSchedID;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsDataSummaryBroker(objFilingTransDataModel);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("01/01/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
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
                        //lstFilingTransactionDataModel[i].OriginalAmount = "$" + lstFilingTransactionDataModel[i].OriginalAmount;// + ".00";
                        lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                        else if (lstFilingTransactionDataModel[i].OwedAmount != null && lstFilingTransactionDataModel[i].OwedAmount != "")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
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
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.Increased,
                    x.Decreased,
                    x.Balance,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
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
                    x.TransExplanation,
                    x.RItemized,
                    x.CountyDesc,
                    x.MunicipalityDesc,
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion       

        /// <summary>
        /// Get Opening Balance of Disclosure Summery
        /// </summary>
        /// <param name = "filerID" ></ param >
        /// < param name="election_Year_ID"></param>
        /// <param name = "office_Type_ID" ></ param >
        /// < param name="filing_Type_ID"></param>
        /// <param name = "election_Date" ></ param >
        /// < returns ></ returns >
        public JsonResult GetSummery_OpeningBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_date)
        {
            try
            {
                String strOpeningBalance = String.Empty;

                strOpeningBalance = objItemizedReportsBroker.GetSummery_OpeningBalanceBroker(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, election_Date, filing_date);

                return Json(strOpeningBalance, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Get Closing Balance of Summery page
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <returns></returns>
        public JsonResult GetSummery_ClosingBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date)
        {
            try
            {
                String strClosingBalance = String.Empty;

                strClosingBalance = objItemizedReportsBroker.GetSummery_ClosingBalanceBroker(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date);

                return Json(strClosingBalance, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Get All Scheduled Balances
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <param name="filing_date"></param>
        /// <param name="filingSchedID"></param>
        /// <returns></returns>
        public JsonResult GetSummery_AllSchedBalances(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            try
            {
                String strClosingBalance = String.Empty;

                strClosingBalance = objItemizedReportsBroker.GetSummery_AllSchedBalancesBroker(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

                return Json(strClosingBalance, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "FileDisclosureSummeryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}