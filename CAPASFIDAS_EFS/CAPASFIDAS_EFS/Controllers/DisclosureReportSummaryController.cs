using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broker;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using CAPASFIDAS_EFS.CommonErrors;
using System.Diagnostics;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class DisclosureReportSummaryController : Controller
    {
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ViewAllDisclosuresBroker objViewAllDisclosuresBroker = new ViewAllDisclosuresBroker();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /DisclosureReportSummary/
        public ActionResult DisclosureReportSummary(FormCollection collections, string Command)
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

                    if (Command == "btnCSVAsEntered")
                    {
                        IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                        if (Session["COMM_TYPE_ID"].ToString() == "23")
                        {
                            FilingTransactionDataModelCSVPCFB FilingTransactionDataModelCSVObj = new FilingTransactionDataModelCSVPCFB();
                            IList<FilingTransactionDataModelCSVPCFB> lstFilingTransactionDataModelCSV = new List<FilingTransactionDataModelCSVPCFB>();
                            lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                            foreach (var item in lstFilingTransactionDataModel)
                            {
                                if (item != null)
                                {
                                    FilingTransactionDataModelCSVObj = new FilingTransactionDataModelCSVPCFB();
                                    FilingTransactionDataModelCSVObj.FilerId = item.FilerId;
                                    FilingTransactionDataModelCSVObj.CandidateCommitteeName = item.CandidateCommitteeName;
                                    FilingTransactionDataModelCSVObj.FilerType = item.FilerType;
                                    FilingTransactionDataModelCSVObj.ReportYear = item.ReportYear;
                                    FilingTransactionDataModelCSVObj.ElectionType = item.ElectionType;
                                    FilingTransactionDataModelCSVObj.ReportType = item.ReportType;
                                    if (item.ElectionDate == "01/01/0001")
                                        FilingTransactionDataModelCSVObj.ElectionDate = "";
                                    else
                                        FilingTransactionDataModelCSVObj.ElectionDate = item.ElectionDate;
                                    FilingTransactionDataModelCSVObj.DisclosureType = item.DisclosureType;
                                    FilingTransactionDataModelCSVObj.DisclosurePeriod = item.DisclosurePeriod;
                                    FilingTransactionDataModelCSVObj.SchedDate = item.SchedDate;
                                    FilingTransactionDataModelCSVObj.FilingSchedDesc = item.FilingSchedDesc;
                                    FilingTransactionDataModelCSVObj.ContributorTypeDesc = item.ContributorTypeDesc;
                                    FilingTransactionDataModelCSVObj.FilingEntityName = item.FilingEntityName;
                                    FilingTransactionDataModelCSVObj.FilingFirstName = item.FilingFirstName;
                                    FilingTransactionDataModelCSVObj.FilingMiddleName = item.FilingMiddleName;
                                    FilingTransactionDataModelCSVObj.FilingLastName = item.FilingLastName;
                                    FilingTransactionDataModelCSVObj.FilingCountry = item.FilingCountry;
                                    FilingTransactionDataModelCSVObj.FilingStreetName = item.FilingStreetName;
                                    FilingTransactionDataModelCSVObj.FilingCity = item.FilingCity;
                                    FilingTransactionDataModelCSVObj.FilingState = item.FilingState;
                                    FilingTransactionDataModelCSVObj.FilingZip = item.FilingZip;
                                    FilingTransactionDataModelCSVObj.PaymentTypeDesc = item.PaymentTypeDesc;
                                    FilingTransactionDataModelCSVObj.PayNumber = item.PayNumber;
                                    FilingTransactionDataModelCSVObj.OriginalAmount = item.OriginalAmount;
                                    FilingTransactionDataModelCSVObj.OwedAmount = item.OwedAmount;
                                    FilingTransactionDataModelCSVObj.ReceiptTypeDesc = item.ReceiptTypeDesc;
                                    FilingTransactionDataModelCSVObj.TransferTypeDesc = item.TransferTypeDesc;
                                    FilingTransactionDataModelCSVObj.ContributionTypeDesc = item.ContributionTypeDesc;
                                    FilingTransactionDataModelCSVObj.PurposeCodeDesc = item.PurposeCodeDesc;
                                    FilingTransactionDataModelCSVObj.ReceiptCodeDesc = item.ReceiptCodeDesc;
                                    FilingTransactionDataModelCSVObj.OriginalDate = item.OriginalDate;
                                    FilingTransactionDataModelCSVObj.LoanerCode = item.LoanerCode;
                                    FilingTransactionDataModelCSVObj.ElectionYear = item.ElectionYear;
                                    FilingTransactionDataModelCSVObj.Office = item.Office;
                                    FilingTransactionDataModelCSVObj.District = item.District;
                                    FilingTransactionDataModelCSVObj.TransExplanation = item.TransExplanation;
                                    FilingTransactionDataModelCSVObj.RLiability = item.RLiability;
                                    FilingTransactionDataModelCSVObj.CreatedDate = item.CreatedDate;
                                    FilingTransactionDataModelCSVObj.LoanLiabilityNumber = item.LoanLiablityNumber;
                                    FilingTransactionDataModelCSVObj.TransNumber = item.TransNumber;
                                    FilingTransactionDataModelCSVObj.TransMapping = item.TransMapping;
                                    //FilingTransactionDataModelCSVObj.Balance = item.Balance;
                                    FilingTransactionDataModelCSVObj.RClaim = item.RClaim;
                                    FilingTransactionDataModelCSVObj.InDistrict = item.InDistrict;
                                    FilingTransactionDataModelCSVObj.RMinor = item.RMinor;
                                    FilingTransactionDataModelCSVObj.RVendor = item.RVendor;
                                    FilingTransactionDataModelCSVObj.RLobbyist = item.RLobbyist;
                                    FilingTransactionDataModelCSVObj.TreasurerEmployer = item.TreasurerEmployer;
                                    FilingTransactionDataModelCSVObj.TreasurerOccuptaion = item.TreasurerOccuptaion;
                                    FilingTransactionDataModelCSVObj.TreaAddr1 = item.TreaAddr1;
                                    FilingTransactionDataModelCSVObj.TreaCity = item.TreaCity;
                                    FilingTransactionDataModelCSVObj.TreaState = item.TreaState;
                                    FilingTransactionDataModelCSVObj.TreaZipCode = item.TreaZipCode;
                                    lstFilingTransactionDataModelCSV.Add(FilingTransactionDataModelCSVObj);
                                }
                            }

                            btnExportCSV_Click(lstFilingTransactionDataModelCSV, "AsEnteredCSV");
                        }
                        else if (Session["COMM_TYPE_ID"].ToString() == "19")
                        {
                            FilingTransactionIECommitteeDataModelCSV FilingTransactionDataModelCSVObj = new FilingTransactionIECommitteeDataModelCSV();
                            IList<FilingTransactionIECommitteeDataModelCSV> lstFilingTransactionDataModelCSV = new List<FilingTransactionIECommitteeDataModelCSV>();
                            lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                            foreach (var item in lstFilingTransactionDataModel)
                            {
                                if (item != null)
                                {
                                    FilingTransactionDataModelCSVObj = new FilingTransactionIECommitteeDataModelCSV();
                                    FilingTransactionDataModelCSVObj.FilerId = item.FilerId;
                                    FilingTransactionDataModelCSVObj.CandidateCommitteeName = item.CandidateCommitteeName;
                                    FilingTransactionDataModelCSVObj.FilerType = item.FilerType;
                                    FilingTransactionDataModelCSVObj.ReportYear = item.ReportYear;
                                    FilingTransactionDataModelCSVObj.ElectionType = item.ElectionType;
                                    FilingTransactionDataModelCSVObj.ReportType = item.ReportType;
                                    if (item.ElectionDate == "01/01/0001")
                                        FilingTransactionDataModelCSVObj.ElectionDate = "";
                                    else
                                        FilingTransactionDataModelCSVObj.ElectionDate = item.ElectionDate;
                                    FilingTransactionDataModelCSVObj.DisclosureType = item.DisclosureType;
                                    FilingTransactionDataModelCSVObj.DisclosurePeriod = item.DisclosurePeriod;
                                    FilingTransactionDataModelCSVObj.SchedDate = item.SchedDate;
                                    FilingTransactionDataModelCSVObj.FilingSchedDesc = item.FilingSchedDesc;
                                    FilingTransactionDataModelCSVObj.ContributorTypeDesc = item.ContributorTypeDesc;
                                    FilingTransactionDataModelCSVObj.FilingEntityName = item.FilingEntityName;
                                    FilingTransactionDataModelCSVObj.FilingFirstName = item.FilingFirstName;
                                    FilingTransactionDataModelCSVObj.FilingMiddleName = item.FilingMiddleName;
                                    FilingTransactionDataModelCSVObj.FilingLastName = item.FilingLastName;
                                    FilingTransactionDataModelCSVObj.FilingCountry = item.FilingCountry;
                                    FilingTransactionDataModelCSVObj.FilingStreetName = item.FilingStreetName;
                                    FilingTransactionDataModelCSVObj.FilingCity = item.FilingCity;
                                    FilingTransactionDataModelCSVObj.FilingState = item.FilingState;
                                    FilingTransactionDataModelCSVObj.FilingZip = item.FilingZip;
                                    FilingTransactionDataModelCSVObj.PaymentTypeDesc = item.PaymentTypeDesc;
                                    FilingTransactionDataModelCSVObj.PayNumber = item.PayNumber;
                                    FilingTransactionDataModelCSVObj.OriginalAmount = item.OriginalAmount;
                                    FilingTransactionDataModelCSVObj.OwedAmount = item.OwedAmount;
                                    FilingTransactionDataModelCSVObj.ReceiptTypeDesc = item.ReceiptTypeDesc;
                                    FilingTransactionDataModelCSVObj.TransferTypeDesc = item.TransferTypeDesc;
                                    FilingTransactionDataModelCSVObj.ContributionTypeDesc = item.ContributionTypeDesc;
                                    FilingTransactionDataModelCSVObj.PurposeCodeDesc = item.PurposeCodeDesc;
                                    FilingTransactionDataModelCSVObj.ReceiptCodeDesc = item.ReceiptCodeDesc;
                                    FilingTransactionDataModelCSVObj.OriginalDate = item.OriginalDate;
                                    FilingTransactionDataModelCSVObj.LoanerCode = item.LoanerCode;
                                    FilingTransactionDataModelCSVObj.ElectionYear = item.ElectionYear;
                                    FilingTransactionDataModelCSVObj.Office = item.Office;
                                    FilingTransactionDataModelCSVObj.District = item.District;
                                    FilingTransactionDataModelCSVObj.TransExplanation = item.TransExplanation;
                                    FilingTransactionDataModelCSVObj.RLiability = item.RLiability;
                                    FilingTransactionDataModelCSVObj.CreatedDate = item.CreatedDate;
                                    FilingTransactionDataModelCSVObj.LoanLiabilityNumber = item.LoanLiablityNumber;
                                    FilingTransactionDataModelCSVObj.TransNumber = item.TransNumber;
                                    FilingTransactionDataModelCSVObj.TransMapping = item.TransMapping;
                                    FilingTransactionDataModelCSVObj.RIESupported = item.RIESupported;
                                    FilingTransactionDataModelCSVObj.RSupportOppose = item.RSupportOppose;
                                    lstFilingTransactionDataModelCSV.Add(FilingTransactionDataModelCSVObj);
                                }
                            }

                            btnExportCSV_Click(lstFilingTransactionDataModelCSV, "AsEnteredCSV");
                        }
                        else
                        {
                            FilingTransactionDataModelCSV FilingTransactionDataModelCSVObj = new FilingTransactionDataModelCSV();
                            IList<FilingTransactionDataModelCSV> lstFilingTransactionDataModelCSV = new List<FilingTransactionDataModelCSV>();
                            lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                            foreach (var item in lstFilingTransactionDataModel)
                            {
                                if (item != null)
                                {
                                    FilingTransactionDataModelCSVObj = new FilingTransactionDataModelCSV();
                                    FilingTransactionDataModelCSVObj.FilerId = item.FilerId;
                                    FilingTransactionDataModelCSVObj.CandidateCommitteeName = item.CandidateCommitteeName;
                                    FilingTransactionDataModelCSVObj.FilerType = item.FilerType;
                                    FilingTransactionDataModelCSVObj.ReportYear = item.ReportYear;
                                    FilingTransactionDataModelCSVObj.ElectionType = item.ElectionType;
                                    FilingTransactionDataModelCSVObj.ReportType = item.ReportType;
                                    if (item.ElectionDate == "01/01/0001")
                                        FilingTransactionDataModelCSVObj.ElectionDate = "";
                                    else
                                        FilingTransactionDataModelCSVObj.ElectionDate = item.ElectionDate;
                                    FilingTransactionDataModelCSVObj.DisclosureType = item.DisclosureType;
                                    FilingTransactionDataModelCSVObj.DisclosurePeriod = item.DisclosurePeriod;
                                    FilingTransactionDataModelCSVObj.SchedDate = item.SchedDate;
                                    FilingTransactionDataModelCSVObj.FilingSchedDesc = item.FilingSchedDesc;
                                    FilingTransactionDataModelCSVObj.ContributorTypeDesc = item.ContributorTypeDesc;
                                    FilingTransactionDataModelCSVObj.FilingEntityName = item.FilingEntityName;
                                    FilingTransactionDataModelCSVObj.FilingFirstName = item.FilingFirstName;
                                    FilingTransactionDataModelCSVObj.FilingMiddleName = item.FilingMiddleName;
                                    FilingTransactionDataModelCSVObj.FilingLastName = item.FilingLastName;
                                    FilingTransactionDataModelCSVObj.FilingCountry = item.FilingCountry;
                                    FilingTransactionDataModelCSVObj.FilingStreetName = item.FilingStreetName;
                                    FilingTransactionDataModelCSVObj.FilingCity = item.FilingCity;
                                    FilingTransactionDataModelCSVObj.FilingState = item.FilingState;
                                    FilingTransactionDataModelCSVObj.FilingZip = item.FilingZip;
                                    FilingTransactionDataModelCSVObj.PaymentTypeDesc = item.PaymentTypeDesc;
                                    FilingTransactionDataModelCSVObj.PayNumber = item.PayNumber;
                                    FilingTransactionDataModelCSVObj.OriginalAmount = item.OriginalAmount;
                                    FilingTransactionDataModelCSVObj.OwedAmount = item.OwedAmount;
                                    FilingTransactionDataModelCSVObj.ReceiptTypeDesc = item.ReceiptTypeDesc;
                                    FilingTransactionDataModelCSVObj.TransferTypeDesc = item.TransferTypeDesc;
                                    FilingTransactionDataModelCSVObj.ContributionTypeDesc = item.ContributionTypeDesc;
                                    FilingTransactionDataModelCSVObj.PurposeCodeDesc = item.PurposeCodeDesc;
                                    FilingTransactionDataModelCSVObj.ReceiptCodeDesc = item.ReceiptCodeDesc;
                                    FilingTransactionDataModelCSVObj.OriginalDate = item.OriginalDate;
                                    FilingTransactionDataModelCSVObj.LoanerCode = item.LoanerCode;
                                    FilingTransactionDataModelCSVObj.ElectionYear = item.ElectionYear;
                                    FilingTransactionDataModelCSVObj.Office = item.Office;
                                    FilingTransactionDataModelCSVObj.District = item.District;
                                    FilingTransactionDataModelCSVObj.TransExplanation = item.TransExplanation;
                                    FilingTransactionDataModelCSVObj.RLiability = item.RLiability;
                                    FilingTransactionDataModelCSVObj.CreatedDate = item.CreatedDate;
                                    FilingTransactionDataModelCSVObj.LoanLiabilityNumber = item.LoanLiablityNumber;
                                    FilingTransactionDataModelCSVObj.TransNumber = item.TransNumber;
                                    FilingTransactionDataModelCSVObj.TransMapping = item.TransMapping;
                                    //FilingTransactionDataModelCSVObj.Balance = item.Balance;         
                                    
                                    lstFilingTransactionDataModelCSV.Add(FilingTransactionDataModelCSVObj);
                                }
                            }

                            btnExportCSV_Click(lstFilingTransactionDataModelCSV, "AsEnteredCSV");
                        }
                    }
                    else if (Command == "btnCSVOpt2ScheA")
                    {
                        IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                        lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                        btnExportCSV_Click(lstFilingTransactionDataModel, "Opt2SchedACSV");
                    }
                    else if (Command == "btnCSVOpt2MiseGrid")
                    {
                        IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                        lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                        btnExportCSV_Click(lstFilingTransactionDataModel, "Opt2MiseGridCSV");
                    }
                    else if (Command == "btnCSVOpt2ExpensesGrid")
                    {
                        IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                        lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                        btnExportCSV_Click(lstFilingTransactionDataModel, "CSVOpt2ExpensesGrid");
                    }
                    else if (Command == "btnCSVOpt2NotEffectbal")
                    {
                        IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                        lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                        btnExportCSV_Click(lstFilingTransactionDataModel, "CSVOpt2NotEffectbal");
                    }
                    else if (Command == "btnCSVOpt3Grid")
                    {
                        IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                        lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["lstFilingTransactionDataModel"];
                        btnExportCSV_Click(lstFilingTransactionDataModel, "CSVOpt3Grid");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        public JsonResult GetFilerIdData()
        {
            try
            {
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
                lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserName"].ToString());
                ViewBag.lstFilerID = Session["FilerID"].ToString();
                ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
                ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
                Session["AuthenticatedFilerID"] = lstValidateFilerInfo[0].FilerID.ToString();
                Session["AuthenticatedCommitteeName"] = lstValidateFilerInfo[0].Name.ToString();
                return Json(new SelectList(lstValidateFilerInfo, "FilerID", "FilerID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
            if (Session["PersonId"] != null)
                lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            Session["PersonFilerId"] = lstFilerCommitteeModel;
            String strCandCommId = "";
            ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
            ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
            // Filer ID
            //if (Session["FILER_INFO"] != null)
            //{
            //    IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
            //    listFilerInfo = (IList<FilerInfoModel>)Session["FILER_INFO"];
            //    ViewData["txtFilerID"] = new SelectList(listFilerInfo, "Filer_ID", "Filer_ID");
            //    ViewData["txtCommitteeName"] = new SelectList(listFilerInfo, "Cand_Comm_ID", "Cand_Comm_Name");
            //    Session["CommitteeDataInLieuOf"] = listFilerInfo;
            //    Session["FilerId"] = listFilerInfo[0].Filer_ID.ToString();
            //    strCandCommId = listFilerInfo[0].Cand_Comm_ID.ToString();
            //}
            //else
            //{
            //    if (lstFilerCommitteeModel.Count() > 0)
            //    {
            //        ViewData["txtFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");
            //        String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            //        lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //        strCandCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            //        Session["CommitteeDataInLieuOf"] = lstFilerCommitteeModel;
            //        Session["FilerId"] = strFilerId;
            //        // Committee Name
            //        ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");
            //    }
            //    else
            //    {
            //        // Committee Name
            //        ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");
            //    }
            //}

            IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
            IList<DisclosureTypesModel> lstDisclosureTypeModeltemp = new List<DisclosureTypesModel>();
            DisclosureTypesModel objDisclosureTypesModel;
            var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCandCommId); //GetDisclosureTypeData();
            objDisclosureTypesModel = new DisclosureTypesModel();
            //objDisclosureTypesModel.DisclosureTypeId = "0";
            //objDisclosureTypesModel.DisclosureTypeDesc = "- Select -";
            //lstDisclosureTypeModel.Add(objDisclosureTypesModel);
            foreach (var item in results)
            {
                if (item != null)
                {
                    if (item.DisclosureTypeId == "1")
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
            }
            // Bind Disclosure Type            
            ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
            // Bind Transaction Type - Itemized.
            ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");
            // Bind Transaction Type for Non-Itemized - 24-Hour Notice.            
            ViewData["lstTransactionTypeNonItem"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");
            // IE Weekly Expenditure Transaction Types
            IList<TransactionTypesModel> lstTransactionTypeModelWeeklyExp = new List<TransactionTypesModel>();
            lstTransactionTypeModelWeeklyExp = objItemizedReportsBroker.GetIEWeeklyExpTransactionTypesResponse(); ; //GetTransactionTypeData();
            // Bind Transaction Type - Itemized.
            ViewData["lstTransTypeNonItemWeeklyExp"] = new SelectList(lstTransactionTypeModelWeeklyExp, "FilingSchedId", "FilingSchedDesc");

            // =====================================================================================================================================
            // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
            // Bind Filing Date for Off Cycle.
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModelResults = new List<FilingDatesOffCycleModel>();
            FilingDatesOffCycleModel objFilingDatesOffCycleModel;
            if (Session["ElectionYearId"] != null && Session["OfficeTypeId"] != null && Session["FilerIdOffCycle"] != null && Session["DisclosureType"] != null)
            {
                lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(Session["ElectionYearId"].ToString(), Session["OfficeTypeId"].ToString(), Session["FilerIdOffCycle"].ToString(), Session["DisclosureType"].ToString());
                objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                objFilingDatesOffCycleModel.FilingDateId = "- Select -";
                objFilingDatesOffCycleModel.FilingDate = "- Select -";
                lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                //objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                //objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
                //objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
                lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            }
            else
            {
                lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(String.Empty, String.Empty, String.Empty, String.Empty);
                objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                objFilingDatesOffCycleModel.FilingDateId = "- Select -";
                objFilingDatesOffCycleModel.FilingDate = "- Select -";
                lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
                //objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
                //objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
                //objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
                lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            }
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
            lstResigTermTypeModel = objItemizedReportsBroker.GeResigTermTypeDataResponse();
            // Bind Partner Data
            ViewData["lstResigTermType"] = new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc");
            // PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
            // =====================================================================================================================================            

            //IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
            //lstElectionYearModel = objItemizedReportsBroker.GetElectionYearDataResponse();
            //// Report Year
            //ViewData["lstElectionCycle"] = new SelectList(lstElectionYearModel, "ElectionYearId", "ElectionYearValue");
            
            IList<ElectionYearModel> lstReportYear = new List<ElectionYearModel>();
            lstReportYear = objViewAllDisclosuresBroker.GetElectionYearForFilerIDForSubmit(Session["FilerId"].ToString());
            ViewData["lstElectionCycle"] = new SelectList(lstReportYear, "ElectionYearId", "ElectionYearValue");

            IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
            if (Session["ElectionTypes"] != null)
            {
                lstElectionTypeModel = (IList<ElectionTypeModel>)Session["ElectionTypes"];
            }
            else
            {
                lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            }
            // Election Type
            ViewData["lstElectionType"] = new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc");

            IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
            if (Session["ElectionCycleVal"] != null)
            {
                String strElectionCycle = Session["ElectionCycleVal"].ToString();
                String strElectionType = Session["ElectionTypeVal"].ToString();
                String strOffictType = Session["OfficeTypeVal"].ToString();

                lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(strElectionCycle, strElectionType, strOffictType, "", "");
            }
            else
            {
                lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(String.Empty, String.Empty, String.Empty, "", "");
            }
            // Electin Date
            ViewData["lstElectionDate"] = new SelectList(lstElectionDateModel, "ElectId", "ElectDate");

            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            if (Session["DisclosurePeriods"] != null)
            {
                lstDisclosurePreiodModel = (IList<DisclosurePreiodModel>)Session["DisclosurePeriods"];
            }
            else
            {
                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty, Session["FilerID"].ToString(), "");
            }
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

            //IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
            //if (Session["OfficeTypes"] != null)
            //{
            //    lstOfficeTypeModel = (IList<OfficeTypeModel>)Session["OfficeTypes"];
            //}
            //else
            //{
            //    lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeResponse();
            //}
            // Bind Office Type
            ViewData["lstUCOfficeType"] = new SelectList("", "OfficeTypeId", "OfficeTypeDesc");            

            IList<CountyModel> lstCountyModel = new List<CountyModel>();
            lstCountyModel = objItemizedReportsBroker.GetCountyResponse();
            // Bind County
            ViewData["lstUCCounty"] = new SelectList(lstCountyModel, "CountyId", "CountyDesc");

            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
            lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(String.Empty);
            // Bind Municipality
            ViewData["lstUCMuncipality"] = new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc");

            //// ===================================================================================================================================
            //// THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
            //// ===================================================================================================================================
            //// PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
            //// Bind Filing Date for Off Cycle.
            //IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
            //IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModelResults = new List<FilingDatesOffCycleModel>();
            //FilingDatesOffCycleModel objFilingDatesOffCycleModel;
            //if (Session["ElectionYearId"] != null)
            //    lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(Session["ElectionYearId"].ToString(), Session["OfficeTypeId"].ToString());
            //else
            //    lstFilingDatesOffCycleModelResults = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(String.Empty, String.Empty);
            //objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            //objFilingDatesOffCycleModel.FilingDateId = "- Select -";
            //objFilingDatesOffCycleModel.FilingDate = "- Select -";
            //lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            //objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            //objFilingDatesOffCycleModel.FilingDateId = "- New Filing Date -";
            //objFilingDatesOffCycleModel.FilingDate = "- New Filing Date -";
            //lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            //if (lstFilingDatesOffCycleModelResults.Count() > 0)
            //{
            //    foreach (var item in lstFilingDatesOffCycleModelResults)
            //    {
            //        objFilingDatesOffCycleModel = new FilingDatesOffCycleModel();
            //        objFilingDatesOffCycleModel.FilingDateId = item.FilingDateId;
            //        objFilingDatesOffCycleModel.FilingDate = item.FilingDate;
            //        lstFilingDatesOffCycleModel.Add(objFilingDatesOffCycleModel);
            //    }
            //}
            //// Bind Filing Date for Off Cycle.
            //ViewData["lstFilingDate"] = new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate");

            // GET REASON FOR FILING DATA.
            ////IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
            //IList<ResigTermTypeModel> lstResigTermTypeModelResults = new List<ResigTermTypeModel>();
            //ResigTermTypeModel objResigTermTypeModel;
            //lstResigTermTypeModelResults = objItemizedReportsBroker.GeResigTermTypeDataResponse();
            //objResigTermTypeModel = new ResigTermTypeModel();
            //objResigTermTypeModel.ResigTermTypeId = "- Select -";
            //objResigTermTypeModel.ResigTermTypeDesc = "- Select -";
            //lstResigTermTypeModel.Add(objResigTermTypeModel);
            //foreach (var item in lstResigTermTypeModelResults)
            //{
            //    objResigTermTypeModel = new ResigTermTypeModel();
            //    objResigTermTypeModel.ResigTermTypeId = item.ResigTermTypeId;
            //    objResigTermTypeModel.ResigTermTypeDesc = item.ResigTermTypeDesc;
            //    lstResigTermTypeModel.Add(objResigTermTypeModel);
            //}
            //// Bind Partner Data
            //ViewData["lstResigTermType"] = new SelectList(lstResigTermTypeModel, "ResigTermTypeId", "ResigTermTypeDesc");
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        #region GetMunicipality
        /// <summary>
        /// GetMunicipality
        /// </summary>
        /// <param name="lstUCCounty"></param>
        /// <returns></returns>
        public JsonResult GetMunicipalityForOffices(String lstUCCounty, String lstOfficeType)
        {
            try
            {
                if (lstUCCounty == "- Select -" || lstUCCounty == "All" || lstUCCounty == "0")
                {
                    lstUCCounty = "";
                }
                IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
                //lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(lstUCCounty);
                // LOADIG MUNICIPALITY BASED ON COUNTY ID AND OFFICE TYPE ID - 06/03/2020.
                lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityByOfficeType(lstUCCounty, lstOfficeType);
                // Bind Municipality
                return Json(new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetMunicipality   

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region GetElectionDate
        /// <summary>
        /// GetElectionDate
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetElectionDate(String lstElectionCycle, String lstElectionType, String lstOfficeType, string countyID, string municipalityID)
        {
            try
            {
                IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();

                if (countyID == null)
                {
                    countyID = "";
                }
                if (municipalityID == null)
                {
                    municipalityID = "";
                }

                if (lstElectionCycle == "- Select -")
                    lstElectionCycle = "";
                if (lstElectionType == "- Select -")
                    lstElectionType = "";
                if (lstOfficeType == "- Select -")
                    lstOfficeType = "";

                if (lstOfficeType == "1")
                    lstOfficeType = "4";

                //if (lstElectionType == "4" || lstElectionType == "11") // PERIODIC - EITHER JANURARY OR JULY WE HAVE TO SEND STATE PRIMARY ELECTION DATE ID.
                if (lstElectionType == "4") // PERIODIC - EITHER JANURARY OR JULY WE HAVE TO SEND STATE PRIMARY ELECTION DATE ID.
                {
                    lstElectionType = "2";

                    Session["ElectionCycleVal_DRS"] = lstElectionCycle.ToString();
                    Session["ElectionTypeVal_DRS"] = lstElectionType.ToString();
                    Session["OfficeTypeVal_DRS"] = lstOfficeType.ToString();
                    Session["CountyVal"] = countyID;
                    Session["MunicipalityVal"] = municipalityID;

                    lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(lstElectionCycle, lstElectionType, lstOfficeType, countyID, municipalityID);
                    return Json(new SelectList(lstElectionDateModel, "ElectId", "ElectDate"), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["ElectionCycleVal_DRS"] = lstElectionCycle.ToString();
                    Session["ElectionTypeVal_DRS"] = lstElectionType.ToString();
                    Session["OfficeTypeVal_DRS"] = lstOfficeType.ToString();
                    Session["CountyVal"] = countyID;
                    Session["MunicipalityVal"] = municipalityID;

                    lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(lstElectionCycle, lstElectionType, lstOfficeType, countyID, municipalityID);

                    return Json(new SelectList(lstElectionDateModel, "ElectId", "ElectDate"), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetElectionDate

        #region GetDisclosurePeriod
        /// <summary>
        /// GetDisclosurePeriod
        /// </summary>
        /// <param name="lstElectionType"></param>
        /// <returns></returns>
        public JsonResult GetDisclosurePeriodForNoActivity(String lstElectID,  String lstElectionType)
        {
            try
            {
                if (lstElectionType == "- Select -")
                    lstElectionType = "";
                if (lstElectionType == null)
                    lstElectionType = "";

                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponseForNoActivity(Session["FilerId"].ToString(), lstElectID, lstElectionType);

                Session["DisclosurePeriods"] = lstDisclosurePreiodModel;

                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetDisclosurePeriod

        #region "GetDisclosureTypesForYearAndFilerID"
        // THIS FUNCTION GETS THE DISCLOSURETYPES FOR FILTER DROPDOWN
        public JsonResult GetDisclosureTypesForYearAndFilerID(String strElectionYearID, String strElectionTypeID)
        {
            try
            {
                String strFilerID = string.Empty;
                strFilerID = Session["FilerId"].ToString();

                IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
                lstDisclosureTypeModel = objViewAllDisclosuresBroker.GetDisclosureTypesForYearAndFilerIDDataResponse(strFilerID, strElectionYearID, strElectionTypeID, "");
                lstDisclosureTypeModel = lstDisclosureTypeModel.Where(x => x.DisclosureTypeId.ToString() == "1").ToList();
                return Json(new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion

        /// <summary>
        /// GetFilingCutOffDate
        /// </summary>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <returns></returns>
        public JsonResult GetFilingCutOffDate(String lstElectionCycle, String lstElectionType, String lstUCOfficeType, String lstDisclosurePeriod, String strElectionDateId)
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
                    strFilingDateId = "61";
                    strCuttOffDateId = "62";
                }
                else if (lstDisclosurePeriod == "3") // 10 Day Post-Primary
                {
                    strFilingDateId = "65";
                    strCuttOffDateId = "66";
                }
                else if (lstDisclosurePeriod == "4") // 32 Day Pre-General
                {
                    strFilingDateId = "104";
                    strCuttOffDateId = "105";
                }
                else if (lstDisclosurePeriod == "5") // 11 Day Pre-General
                {
                    strFilingDateId = "106";
                    strCuttOffDateId = "107";
                }
                else if (lstDisclosurePeriod == "6") // 27 Day Post-General
                {
                    strFilingDateId = "108";
                    strCuttOffDateId = "109";
                }
                else if (lstDisclosurePeriod == "7") // 32 Day Pre-Speceial
                {
                    strFilingDateId = "122";
                    strCuttOffDateId = "123";
                }
                else if (lstDisclosurePeriod == "8") // 11 Day Pre-Special
                {
                    strFilingDateId = "124";
                    strCuttOffDateId = "125";
                }
                else if (lstDisclosurePeriod == "9") // 27 Day Post-Special
                {
                    strFilingDateId = "126";
                    strCuttOffDateId = "127";
                }
                else if (lstDisclosurePeriod == "10") // January Periodic
                {
                    strFilingDateId = "69";
                    strCuttOffDateId = "70";
                }
                else if (lstDisclosurePeriod == "11") // July Periodic
                {
                    strFilingDateId = "71";
                    strCuttOffDateId = "72";
                }
                else if (lstDisclosurePeriod == "12") // Off Cycle
                {
                    //strFilingDateId = "108";
                    //strCuttOffDateId = "109";
                }
                //else if (lstDisclosurePeriod == "14") // January
                //{
                //    strFilingDateId = "144";
                //    strCuttOffDateId = "145";
                //}
                //else if (lstDisclosurePeriod == "15") // February
                //{
                //    strFilingDateId = "146";
                //    strCuttOffDateId = "147";
                //}
                //else if (lstDisclosurePeriod == "16") // March
                //{
                //    strFilingDateId = "148";
                //    strCuttOffDateId = "149";
                //}
                //else if (lstDisclosurePeriod == "17") // April
                //{
                //    strFilingDateId = "150";
                //    strCuttOffDateId = "151";
                //}
                //else if (lstDisclosurePeriod == "18") // July
                //{
                //    strFilingDateId = "152";
                //    strCuttOffDateId = "153";
                //}
                //else if (lstDisclosurePeriod == "19") // December
                //{
                //    strFilingDateId = "142";
                //    strCuttOffDateId = "143";
                //}

                IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

                lstFilingCutOffDateModel = objItemizedReportsBroker.GetFilingCutOffDateDataResponse(lstElectionCycle, lstElectionType, lstUCOfficeType,
                    strFilingDateId, strCuttOffDateId, strElectionDateId);

                return Json(lstFilingCutOffDateModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult SubmitFilings_Summery(String txtFilerId, String lstOfficeTypeId, String lstFilingTypeId, String lstElectYearId, String filing_date, String lstFilingDate, String txtReportPeriodDatesTo, String txtCuttOffDate, String lstElectionType, String electionDateId, String strElectionTypeId)
        {
            try
            {
                var results = true;

                if (lstFilingDate != null)
                    lstFilingDate = lstFilingDate.Trim();

                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                objFilingTransactionsModel.FilerId = txtFilerId;
                objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                objFilingTransactionsModel.ElectYearId = lstElectYearId;
                //objFilingTransactionsModel.FilingDate = filing_date;
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
                objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                objFilingTransactionsModel.ElectionDateId = electionDateId;
                results = objItemizedReportsBroker.SubmitFilings_SummeryBroker(objFilingTransactionsModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        #region Get Filing Transaction Summery As Entered
        /// <summary>
        /// Get Filing Transaction Summery
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>;
        /// <returns></returns>
        public JsonResult GetFilingTransactionsDataSummaryAsEntered(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType,
                                    String lstElectionDateId, String lstFilingDate,String txtFilingDate,String lstFilingSchedID, String countyID, String municipalityID)
        {
            try
            {
                if (countyID == null)
                {
                    countyID = "";
                }
                if (municipalityID == null)
                {
                    municipalityID = "";
                }

                //if (lstElectionType == "4" || lstElectionType == "11") // Periodic
                if (lstElectionType == "4") // Periodic
                {
                    Session["ElectionTypeVal_DRS"] = "2";
                }
                else
                {
                    Session["ElectionTypeVal_DRS"] = lstElectionType;
                }
                
                Session["OfficeTypeVal_DRS"] = lstUCOfficeType;
                Session["ElectionCycleVal_DRS"] = lstElectionCycle;
                Session["CountyVal"] = countyID;
                Session["MunicipalityVal"] = municipalityID;


                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();                                                
            
            objFilingTransDataModel.FilerId = txtFilerID;
            objFilingTransDataModel.ReportYearId = lstElectionCycle;
            objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
            objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
            objFilingTransDataModel.ElectionType = lstElectionType;
            objFilingTransDataModel.ElectionDateId = lstElectionDateId;
            // ADDING SESSION FOR PDF REPORT.
            Session["PDFFilerId"] = txtFilerID;
            Session["PDFReprotYearId"] = lstElectionCycle;
            Session["PDFOfficeTypeId"] = lstUCOfficeType;
            Session["PDFFilingTypeId"] = lstDisclosurePeriod;

            Session["PDFElectionTypeId"] = lstElectionType;
            Session["PDFElectionDateId"] = lstElectionDateId;

            if (lstElectionType == "6") // OFF-CYCLE FILING DATE    
            {
                if (lstFilingDate == "- New Filing Date -")
                    objFilingTransDataModel.FilingDate = txtFilingDate;

                else
                    objFilingTransDataModel.FilingDate = lstFilingDate;
            }
            else // OTHER THAN OFF-CYCLE FILING DATE
            {
                objFilingTransDataModel.FilingDate = txtFilingDate;
            }
            Session["PDFFilingDate"] = objFilingTransDataModel.FilingDate;
            objFilingTransDataModel.FilingSchedID = lstFilingSchedID;
            lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsDataSummaryBroker(objFilingTransDataModel);

            Session["lstFilingTransactionDataModel"] = lstFilingTransactionDataModel;

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

                        lstFilingTransactionDataModel[i].Increased = "$" + lstFilingTransactionDataModel[i].Increased;
                        lstFilingTransactionDataModel[i].Decreased = "$" + lstFilingTransactionDataModel[i].Decreased;
                        lstFilingTransactionDataModel[i].Balance = "$" + string.Format("{0:0.00}", Convert.ToDouble(lstFilingTransactionDataModel[i].Balance));

                        if (lstFilingTransactionDataModel[i].OriginalAmount == "")
                        {
                            lstFilingTransactionDataModel[i].OriginalAmount = "0.00";
                        }
                    }
               }
                JsonResult result = Json(new
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
                    x.Office_Desc,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.CountyDesc,
                    x.MunicipalityDesc,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.DBStatus,
                    x.RClaim,
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
                    x.RIESupported,
                    x.RSupportOppose
                })
            }, JsonRequestBehavior.AllowGet);
                result.MaxJsonLength = int.MaxValue;
                return result;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion    

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
                                    String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType,
                                    String lstElectionDateId, String lstFilingDate, String txtFilingDate, String lstFilingSchedID, String countyID, String municipalityID)
        {
            try
            {
                if (countyID == null)
                {
                    countyID = "";
                }
                if (municipalityID == null)
                {
                    municipalityID = "";
                }

                //if (lstElectionType == "4" || lstElectionType == "11") // Periodic
                if (lstElectionType == "4") // Periodic
                {
                    Session["ElectionTypeVal_DRS"] = "2";
                }
                else
                {
                    Session["ElectionTypeVal_DRS"] = lstElectionType;
                }
                Session["OfficeTypeVal_DRS"] = lstUCOfficeType;
                Session["ElectionCycleVal_DRS"] = lstElectionCycle;
                Session["CountyVal"] = countyID;
                Session["MunicipalityVal"] = municipalityID;

                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                //objFilingTransDataModel.FilerId = txtFilerID;
                //objFilingTransDataModel.ReportYearId = lstElectionCycle;
                //objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                //objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
                //objFilingTransDataModel.FilingSchedID = lstFilingSchedID;
                //objFilingTransDataModel.ElectionType = lstElectTypeID;

                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                objFilingTransDataModel.FilingSchedID = lstFilingSchedID;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsDataSummaryBroker(objFilingTransDataModel);

                Session["lstFilingTransactionDataModel"] = lstFilingTransactionDataModel;

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

                        lstFilingTransactionDataModel[i].Increased = "$" + lstFilingTransactionDataModel[i].Increased;
                        lstFilingTransactionDataModel[i].Decreased = "$" + lstFilingTransactionDataModel[i].Decreased;
                        lstFilingTransactionDataModel[i].Balance = "$" + string.Format("{0:0.00}", Convert.ToDouble(lstFilingTransactionDataModel[i].Balance));
                    }
                }

                JsonResult result = Json(new
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
                    x.Office_Desc,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.CountyDesc,
                    x.MunicipalityDesc,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.DBStatus,
                    x.RClaim,
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
                    x.RIESupported,
                    x.RSupportOppose
                })
                }, JsonRequestBehavior.AllowGet);
                result.MaxJsonLength = int.MaxValue;
                return result;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult GetSummery_OpeningBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_date, String off_cycle_filing_Date)
        {
            try
            {
                String strOpeningBalance = String.Empty;
                if (filing_date == "")
                {
                    filing_date = off_cycle_filing_Date;
                }
                strOpeningBalance = objItemizedReportsBroker.GetSummery_OpeningBalanceBroker(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, election_Date, filing_date);


                return Json(string.Format("{0:0.00}", Convert.ToDouble(strOpeningBalance)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult GetSummery_ClosingBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String off_cycle_filing_Date)
        {
            try
            {
                String strClosingBalance = String.Empty;
                if (filing_date == "")
                {
                    filing_date = off_cycle_filing_Date;
                }
                strClosingBalance = objItemizedReportsBroker.GetSummery_ClosingBalanceBroker(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date);

                return Json(string.Format("{0:0.00}", Convert.ToDouble(strClosingBalance)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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

                return Json(string.Format("{0:0.00}", Convert.ToDouble(strClosingBalance)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        /// <summary>
        /// GetSummery_AllSchedBalances_Sched_N
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <param name="filing_date"></param>
        /// <param name="filingSchedID"></param>
        /// <returns></returns>
        public JsonResult GetSummery_AllSchedBalances_Sched_N(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            try
            {
                String strClosingBalance = String.Empty;

                strClosingBalance = objItemizedReportsBroker.GetSummery_AllSchedBalancesBroker_Sched_N(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

                return Json(string.Format("{0:0.00}", Convert.ToDouble(strClosingBalance)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }


        /// <summary>
        /// Get Amend Status data
        /// </summary>
        /// <param name="filings_ID"></param>
        /// <returns></returns>
        public JsonResult GetAmendStatus(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType,
                                    String lstElectionDateId, String lstFilingDate, String txtFilingDate)
        {
            try
            {
                IList<CheckAmendStatusModel> lstCheckAmendStatusModel = new List<CheckAmendStatusModel>();
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();

                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                lstCheckAmendStatusModel = objItemizedReportsBroker.GetAmendStatusBroker(objFilingTransDataModel);
                return Json(lstCheckAmendStatusModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        /// <summary>
        /// ValidateFilings
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="lstFilingDate"></param>
        /// <param name="txtFilingDate"></param>
        /// <returns></returns>
        public JsonResult ValidateFilings(String txtFilerId, String strElectionTypeId, String lstFilingDate, String txtFilingDate)
        {
            try
            {
                IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerId;
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                lstGetEditFlagDataModel = objItemizedReportsBroker.ValidateFilingsBroker(objFilingTransDataModel);
                return Json(lstGetEditFlagDataModel[0].VALIDATE_FILINGS.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        #region GetValidateFilter
        /// <summary>
        /// GetValidateFilter
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="txtCommitteeName"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="lstUCCounty"></param>
        /// <param name="lstUCMuncipality"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="lstDisclosureType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="txtReportPeriodDatesFrom"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <returns></returns>
        public JsonResult GetValidateFilter(String strFilerId, String txtCommitteeName, String strElectionYearId, String strElectionYear, String strOfficeTypeId, String lstUCCounty, String lstUCMuncipality, String strElectionTypeId, String strElectionDateId, String lstDisclosureType, String lstDisclosurePeriod, String txtReportPeriodDatesFrom, String txtReportPeriodDatesTo, String lstResigTermType, String lstFilingDate, String txtNewFilingDate)
        {
            try
            {
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = "";
                if (lstDisclosurePeriod == "- Select -")
                    lstDisclosurePeriod = "";

                if (strFilerId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("REQUIRED_FILER", strFilerId.ToString());
                    if (!results)
                        ModelState.AddModelError("txtFilerID", "Invalid Filer Id");
                }
                else
                {
                    ModelState.AddModelError("txtFilerID", "Filer Id is required");
                }
                if (txtCommitteeName != "")
                {
                    txtCommitteeName = Session["CommID"].ToString();
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("CANDIDATE_COMMITTEE", txtCommitteeName.ToString());
                    if (!results)
                        ModelState.AddModelError("txtCommitteeName", "Invalid Candidate/Committee Name");
                }
                else
                {
                    ModelState.AddModelError("txtCommitteeName", "Candidate/Committee Name is required");
                }
                if (strElectionYearId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_YEAR", strElectionYearId.ToString());
                    if (!results)
                        ModelState.AddModelError("lstElectionCycle", "Invalid Report Year");
                }
                else
                {
                    ModelState.AddModelError("lstElectionCycle", "Report Year is required1");
                }
                if (strOfficeTypeId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("OFFICE_TYPE", strOfficeTypeId.ToString());
                    if (!results)
                        ModelState.AddModelError("lstUCOfficeType", "Invalid Filer Type");
                }
                else
                {
                    ModelState.AddModelError("lstUCOfficeType", "Filer Type is required");
                }
                if (strOfficeTypeId != "")
                {
                    if (strOfficeTypeId == "2")
                    {
                        if (lstUCCounty != "")
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("COUNTY", lstUCCounty.ToString());
                            if (!results)
                                ModelState.AddModelError("lstUCCounty", "Invalid County");
                        }
                        else
                        {
                            ModelState.AddModelError("lstUCCounty", "County is required");
                        }
                        if (lstUCMuncipality != "")
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("MUNICIPALITY", lstUCMuncipality.ToString());
                            if (!results)
                                ModelState.AddModelError("lstUCMuncipality", "Invalid Municipality");
                        }
                        else
                        {
                            ModelState.AddModelError("lstUCCounty", "Municipality is required");
                        }
                    }
                }
                if (strElectionTypeId != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("ELECTION_TYPE", strElectionTypeId.ToString());
                    if (!results)
                        ModelState.AddModelError("lstElectionType", "Invalid Election Type");
                }
                else
                {
                    ModelState.AddModelError("lstElectionType", "Report Type is required");
                }
                if (strElectionDateId != "- Select -")
                {
                    if (strElectionDateId != "")
                    {
                        if (strElectionDateId != null)
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_DATES", strElectionDateId.ToString());
                            if (!results)
                                ModelState.AddModelError("lstElectionDate", "Invalid Election Date");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("lstElectionDate", "Election Date is required");
                    }
                }
                if (lstDisclosureType != "0")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_CATEGORY", lstDisclosureType.ToString());
                    if (!results)
                        ModelState.AddModelError("lstDisclosureType", "Invalid Disclosure Type");
                }
                else
                {
                    ModelState.AddModelError("lstDisclosureType", "Disclosure Type is required");
                }
                if (lstDisclosureType == "1")
                {
                    if (lstDisclosurePeriod != "")
                    {
                        // Call Procedure
                        Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("FILING_TYPE", lstDisclosurePeriod.ToString());
                        if (!results)
                            ModelState.AddModelError("lstDisclosurePeriod", "Invalid Disclosure Period");
                    }
                    else
                    {
                        ModelState.AddModelError("lstDisclosurePeriod", "Disclosure Period is required");
                    }
                }
                if (strElectionTypeId.ToString() != "6")
                {
                    if (lstDisclosureType.ToString() != "18" && lstDisclosureType.ToString() != "21" && lstDisclosureType.ToString() != "20" && lstDisclosureType.ToString() != "23")
                    {
                        IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();
                        lstFilingCutOffDateModel = (IList<FilingCutOffDateModel>)Session["FilingAndCutOffDate"];

                        String cutOffDateLabelId = String.Empty;
                        String filingDateLabelId = String.Empty;

                        if (txtReportPeriodDatesFrom != "" && txtReportPeriodDatesTo != "")
                        {
                            foreach (var item in lstFilingCutOffDateModel)
                            {
                                if (item != null)
                                {
                                    if (item.FilingDueDate != null)
                                        filingDateLabelId = item.PoliticalCalLabelId;
                                    else if (item.CutOffDate != null)
                                        cutOffDateLabelId = item.PoliticalCalLabelId;
                                }
                            }
                        }

                        if (txtReportPeriodDatesFrom != "")
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_LABEL", filingDateLabelId);
                            if (!results)
                                ModelState.AddModelError("txtReportPeriodDatesFrom", "Invalid Cut of Date");
                        }
                        else
                        {
                            ModelState.AddModelError("txtReportPeriodDatesFrom", "Cut of Date is required");
                        }
                        if (txtReportPeriodDatesTo != "")
                        {
                            // Call Procedure
                            Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("POLITICAL_CALENDAR_LABEL", cutOffDateLabelId);
                            if (!results)
                                ModelState.AddModelError("txtReportPeriodDatesTo", "Invalid Filing Date");
                        }
                        else
                        {
                            ModelState.AddModelError("txtReportPeriodDatesTo", "Filing Date is required");
                        }
                    }
                    else
                    {
                        if (lstFilingDate != "- Select -")
                        {
                            if (lstFilingDate == "- New Filing Date -")
                            {
                                DateTime dDate;
                                // Current Date.
                                if (String.IsNullOrEmpty(txtNewFilingDate))
                                {
                                    ModelState.AddModelError("txtNewFilingDate", "Filing Date is required");
                                }
                                else if (!objCommonErrorsServerSide.DateUS(txtNewFilingDate))
                                {
                                    ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                                }
                                else if (!DateTime.TryParse(txtNewFilingDate, out dDate))
                                {
                                    ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                                }
                                else if (!objCommonErrorsServerSide.FilingDateValidation(txtNewFilingDate, strElectionYear))
                                {
                                    ModelState.AddModelError("txtNewFilingDate", "Filing Date within the Election Year");
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (lstFilingDate != "- Select -")
                    {
                        if (lstFilingDate == "- New Filing Date -")
                        {
                            DateTime dDate;
                            // Current Date.
                            if (String.IsNullOrEmpty(txtNewFilingDate))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Filing Date is required");
                            }
                            else if (!objCommonErrorsServerSide.DateUS(txtNewFilingDate))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                            }
                            else if (!DateTime.TryParse(txtNewFilingDate, out dDate))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Enter valid date format (MM/DD/YYYY)");
                            }
                            else if (!objCommonErrorsServerSide.FilingDateValidation(txtNewFilingDate, strElectionYear))
                            {
                                ModelState.AddModelError("txtNewFilingDate", "Filing Date within the Election Year");
                            }
                        }
                    }
                }
                if (lstResigTermType != "")
                {
                    // Call Procedure
                    Boolean results = objItemizedReportsBroker.GetDropdownValueExistsResponse("RESIGNATION_TERMINATION_TYPE", lstResigTermType);
                    if (!results)
                        ModelState.AddModelError("lstResigTermType", "Invalid Resignation/Termination");
                }

                if (ModelState.IsValid)
                {
                    var results = true;
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetValidateFilter

        #region GetFilingDateOffCycle
        /// <summary>
        /// GetFilingDateOffCycle
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public JsonResult GetFilingDateOffCycle(String strElectionYearId, String strOfficeTypeId, String strFilerId, String lstDisclosureType)
        {
            try
            {
                if (lstDisclosureType == "- Select -")
                {
                    lstDisclosureType = "1";
                }
                else if (lstDisclosureType == null)
                {
                    lstDisclosureType = "1";
                }

                Session["ElectionYearId"] = strElectionYearId;
                Session["OfficeTypeId"] = strOfficeTypeId;
                Session["FilerIdOffCycle"] = strFilerId;
                Session["DisclosureType"] = lstDisclosureType;

                IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();
                lstFilingDatesOffCycleModel = objItemizedReportsBroker.GetFilingDateOffCycleDataResponse(strElectionYearId, strOfficeTypeId, strFilerId, lstDisclosureType);

                Session["lstFilingDatesOffCycleModel"] = lstFilingDatesOffCycleModel;
                // Bind Filing Date for Off Cycle.
                return Json(new SelectList(lstFilingDatesOffCycleModel, "FilingDateId", "FilingDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            

        }
        #endregion GetFilingDateOffCycle

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
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilerId")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Filer ID";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "CandidateCommitteeName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Candidate/Committee Name";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilerType")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Filer Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ElectionYear")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Report Year";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ElectionType")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Election Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ReportType")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Report Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ElectionDate")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Election Date";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "DisclosureType")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Disclosure Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "DisclosurePeriod")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Disclosure Period";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "SchedDate")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Transaction Date";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingSchedDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Transaction Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ContributorTypeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Contributor Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingEntityName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Entity Name";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingFirstName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "First Name";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingMiddleName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Middle Name";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingLastName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Last Name";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingCountry")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Country";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingStreetName")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Street Address";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingCity")
                {
                    GridView1.HeaderRow.Cells[k].Text = "City";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingState")
                {
                    GridView1.HeaderRow.Cells[k].Text = "State";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "FilingZip")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Zip Code";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "PaymentTypeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Method";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "PayNumber")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Check/Money Order #";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "OriginalAmount")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Amount $";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "OwedAmount")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Outstanding Amount $";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ReceiptTypeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Receipt Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TransferTypeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Transfer Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ContributionTypeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Contribution Type";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "PurposeCodeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Purpose Code";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ReceiptCodeDesc")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Receipt Code";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "OriginalDate")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Original Date";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "LoanerCode")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Loaner Code";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "ElectionYear")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Election Year";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "Office")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Office";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "District")
                {
                    GridView1.HeaderRow.Cells[k].Text = "District";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TransExplanation")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Explanation";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RItemized")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Itemized";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "CreatedDate")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Created Date";
                }
                //if (GridView1.HeaderRow.Cells[k].Text.ToString() == "Balance")
                //{
                //    GridView1.HeaderRow.Cells[k].Text = "Balance";
                //}
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RClaim")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Claim";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "InDistrict")
                {
                    GridView1.HeaderRow.Cells[k].Text = "In District";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RMinor")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Minor";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RVendor")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Vendor";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RLobbyist")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Lobbyist";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TreasurerEmployer")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Employer";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TreasurerOccuptaion")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Occuptaion";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TreaAddr1")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Employer Addr1";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TreaCity")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Employer City";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TreaState")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Employer State";
                }
                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "TreaZipCode")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Employer Zip Code";
                }

                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RIESupported")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Is Support or Oppose";
                }

                if (GridView1.HeaderRow.Cells[k].Text.ToString() == "RSupportOppose")
                {
                    GridView1.HeaderRow.Cells[k].Text = "Support or Oppose";
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
                    sb.Append("\"" + GridView1.Rows[i].Cells[k].Text + "\"" + ',');
                }
                var lastDataCount = sb.ToString().LastIndexOf(',');
                if (lastDataCount >= 0)
                    sb.Remove(lastDataCount, 1);
                //append new line 
                sb.Append("\r\n");
            }
            System.Web.HttpContext.Current.Response.Output.Write(sb.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion

        #region GetFullPeriodReportPDF
        /// <summary>
        /// GetFullPeriodReportPDF
        /// </summary>
        public void GetFullPeriodReportPDF()
        {
            EFSPDFRequestModel objEFSPDFRequestModel = new EFSPDFRequestModel();
            EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();

            objEFSPDFRequestModel.ReportName = "EFS_FullPeriod_Report";
            objEFSPDFRequestModel.FilerId = Session["PDFFilerId"].ToString();
            objEFSPDFRequestModel.ElectionYearId = Session["PDFReprotYearId"].ToString();
            objEFSPDFRequestModel.OfficeTypeId = Session["PDFOfficeTypeId"].ToString();
            objEFSPDFRequestModel.FilingTypeId = Session["PDFFilingTypeId"].ToString();
            objEFSPDFRequestModel.FilingDate = Session["PDFFilingDate"].ToString();
            objEFSPDFRequestModel.ElectionTypeID = Session["PDFElectionTypeId"].ToString();
            objEFSPDFRequestModel.ElectionDateID = Session["PDFElectionDateId"].ToString();
            //objEFSPDFRequestModel.ReportName = "DeficiencyLetterCandidateNotification";
            //objEFSPDFRequestModel.FilerId = "113070";
            //objEFSPDFRequestModel.ElectionYearId = "16";
            //objEFSPDFRequestModel.OfficeTypeId = "1";
            //objEFSPDFRequestModel.FilingTypeId = "1";

            byte[] bytesData = new byte[64];
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", "Testing PDF");
            Response.BinaryWrite(bytesData);

            objEFSPDFResponseModel = objItemizedReportsBroker.GetEFSPDFBytesResponse(objEFSPDFRequestModel);

            //Open PDF using Bytes
            if (objEFSPDFResponseModel.fileByte != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", objEFSPDFResponseModel.fileByte.Length.ToString());
                Response.BinaryWrite(objEFSPDFResponseModel.fileByte);
            }
            else
            {
                //Open PDF using File URL
                Process.Start(objEFSPDFResponseModel.fileURL);
            }
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion GetFullPeriodReportPDF

        #region "GetElectionTypeDataForFilerID"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONTYPE FILTER DROPDOWN	
        /// <returns></returns>
        public JsonResult GetElectionTypeData(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String FilerId = string.Empty;
                //if (Session == null || Session["Filer_Id"] == null)
                //    FilerId = "113070";
                //else
                FilerId = Session["FilerId"].ToString();

                // DropDown Election Type Data
                IList<ElectionType> listElectionType = new List<ElectionType>();
                if ((strElectYearID == "- Select -") || (String.IsNullOrEmpty(strElectYearID)))
                    strElectYearID = "";
                if ((strOfficeTypeID == "- Select -") || (String.IsNullOrEmpty(strOfficeTypeID)))
                    strOfficeTypeID = "";
                if ((strCountyID == "- Select -") || (String.IsNullOrEmpty(strCountyID)))
                    strCountyID = "";
                if ((strMunicipalityID == "- Select -") || (String.IsNullOrEmpty(strMunicipalityID)))
                    strMunicipalityID = "";
                    listElectionType = objViewAllDisclosuresBroker.GetElectionTypeForFilerIDForSubmit(strElectYearID, strOfficeTypeID, strCountyID, strMunicipalityID, FilerId).ToList();
                return Json(new SelectList(listElectionType, "ElectionTypeID", "ElectionTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion

        #region GetDisclosurePeriod
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
                if (lstElectionType == null)
                    lstElectionType = "";

                IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

                lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(lstElectionType, Session["FilerID"].ToString(),"");

                Session["DisclosurePeriods"] = lstDisclosurePreiodModel;

                return Json(new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetDisclosurePeriod

        //#region "GetDisclosurePeriodsForYearAndFilerID"
        //// THIS FUNCTION GETS DISCLOSURE PERIODS FOR FILTER DROPDOWN	
        //public JsonResult GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strElectionYearID, String strElectionTypeID)
        //{
        //    try
        //    {   
        //        String strFilerID = string.Empty;
        //        strFilerID = Session["FilerId"].ToString();

        //        IList<DisclosurePreiodModel> lstDisclosurePeriodModel = new List<DisclosurePreiodModel>();
        //        lstDisclosurePeriodModel = objViewAllDisclosuresBroker.GetDisclosurePeriodsForYearAndFilerIDAndElectionType(strFilerID, strElectionYearID, strElectionTypeID, "");
        //        return Json(new SelectList(lstDisclosurePeriodModel, "FilingTypeId", "FilingDesc"), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ViewAllDisclosuresController", "GetDisclosurePeriodsForYearAndFilerIDAndElectionType", "", "", "Filer Error Found", "Test Admin");
        //        throw;
        //    }
        //}
        //#endregion

        #region "GetElectionDateData"
        // THIS FUNCTION GETS THE DATA FOR THE ELECTIONDATE FILTER DROPDOWN	
        public JsonResult GetElectionDateData(String strElectionYearID, String strElectionTypeID, String strOfficeTypeID, String countyID, String municipalityID)
        {
            try
            {
                if (countyID == null)
                {
                    countyID = "";
                }
                if (municipalityID == null)
                {
                    municipalityID = "";
                }
                Session["ElectionCycleVal_DRS"] = strElectionYearID.ToString();
                Session["CountyVal"] = countyID;
                Session["MunicipalityVal"] = municipalityID;

                // DropDown Election Type Data
                IList<Election_Date> listElectionDate = new List<Election_Date>();
                listElectionDate = objViewAllDisclosuresBroker.GetElectionDateResponse(strElectionYearID, strElectionTypeID, strOfficeTypeID, Session["FilerId"].ToString(), countyID, municipalityID).ToList();
                return Json(new SelectList(listElectionDate, "ElectionDateId", "ElectionDate"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetOfficeTypeDataForFilerID"
        // FUNCTION POPULATES OFFICETYPES FOR THE FILTER DROPDOWN
        public JsonResult GetOfficeTypeData(String strElectYearID)
        {
            try
            {
               
                String FilerId = string.Empty;
                
                FilerId = Session["FilerId"].ToString();

                // DropDown Office Type Data
                IList<OfficeType> listOfficeType = new List<OfficeType>();
                if (strElectYearID == "")
                {
                    listOfficeType = objViewAllDisclosuresBroker.GetOfficeTypeForFilerIDResponse("0", FilerId).ToList();
                }
                else
                {
                    listOfficeType = objViewAllDisclosuresBroker.GetOfficeTypeForFilerIDResponse(strElectYearID, FilerId).ToList();
                }
                return Json(new SelectList(listOfficeType, "OfficeTypeID", "OfficeTypeDesc"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetCountyData"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        /// <summary>
        /// GetCountyDataForFilings
        /// </summary>
        /// <param name="elect_Year_ID"></param>
        /// <param name="filer_ID"></param>
        /// <returns></returns>
        public JsonResult GetCountyDataForFilings(string elect_Year_ID, string filer_ID)
        {
            try
            {
                // DropDown County Data
                IList<County> listCounty = new List<County>();
                listCounty = objItemizedReportsBroker.GetCountyForFilingsBroker(elect_Year_ID, filer_ID).ToList();
                return Json(new SelectList(listCounty, "CountyID", "CountyBoard"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "DisclosureReportSummaryController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region Grid Help
        /// <summary>
        /// ActiveDeactiveFilerGridHelp
        /// </summary>
        /// <returns></returns>
        //public ActionResult ActiveDeactiveFilerGridHelp()
        //{
        //    return View("ActiveDeactiveFilerGridHelp");
        //}
        #endregion Grid Help

        #region Filer Help
        /// <summary>
        /// ContributionsMonetarySearchHelp
        /// </summary>
        /// <returns></returns>
        public ActionResult DisclosureReportSummarySearchHelp()
        {
            return View("DisclosureReportSummarySearchHelp");
        }

        #endregion Filer Help    

        /// <summary>
        /// Set Global Session
        /// </summary>
        /// <param name="strReportYearID"></param>
        /// <param name="strElectionTypeID"></param>
        /// <param name="strOfficeTypeID"></param>
        /// <returns></returns>
        public JsonResult SetSession(String strReportYearID, String strElectionTypeID, String strOfficeTypeID)
        {
            try
            {
                //if (strElectionTypeID == "4" || strElectionTypeID == "11")
                if (strElectionTypeID == "4")
                    Session["ElectionTypeVal"] = "2";
                else
                    Session["ElectionTypeVal"] = strElectionTypeID;
                Session["OfficeTypeVal"] = strOfficeTypeID;
                Session["ElectionCycleVal"] = strReportYearID;
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanReceivedSchedIController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}