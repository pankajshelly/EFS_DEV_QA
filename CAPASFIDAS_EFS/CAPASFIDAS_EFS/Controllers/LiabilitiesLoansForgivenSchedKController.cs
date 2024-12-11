using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class LiabilitiesLoansForgivenSchedKController : Controller
    {
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /LiabilitiesLoansForgivenSchedK/
        public ActionResult LiabilitiesLoansForgivenSchedK()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        #region GetDefaultLookUpsValues
        public void GetDefaultLookUpsValues()
        {
            //IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            ////lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            //lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["FilerID"].ToString());
            //// Filer ID
            //ViewData["txtFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");

            //String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            //lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //String strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            //// Committee Name
            //ViewData["txtCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");

            //IList<DisclosureTypesModel> lstDisclosureTypeModel = new List<DisclosureTypesModel>();
            //DisclosureTypesModel objDisclosureTypesModel;
            //var results = objItemizedReportsBroker.GetDisclosureTypesDataResponse(strCommId); //GetDisclosureTypeData();
            //objDisclosureTypesModel = new DisclosureTypesModel();
            //objDisclosureTypesModel.DisclosureTypeId = "0";
            //objDisclosureTypesModel.DisclosureTypeDesc = "- Select -";
            //lstDisclosureTypeModel.Add(objDisclosureTypesModel);
            //foreach (var item in results)
            //{
            //    objDisclosureTypesModel = new DisclosureTypesModel();
            //    objDisclosureTypesModel.DisclosureTypeId = item.DisclosureTypeId;
            //    if (!String.IsNullOrEmpty(item.DisclosureSubTypeDesc))
            //        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc + " " + item.DisclosureSubTypeDesc;
            //    else
            //        objDisclosureTypesModel.DisclosureTypeDesc = item.DisclosureTypeDesc;
            //    lstDisclosureTypeModel.Add(objDisclosureTypesModel);
            //}
            //// Bind Disclosure Type
            //ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            //IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            //lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
            //// Bind Transaction Type
            //ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

            //IList<PartnerModel> lstPartnerModel = new List<PartnerModel>();
            //lstPartnerModel = objContributionsMonetaryController.GetPartnerData();
            //// Bind Partner Data
            //ViewData["lstPartner"] = new SelectList(lstPartnerModel, "PartnerId", "PartnerDesc");

            //IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();
            //lstElectionYearModel = objItemizedReportsBroker.GetElectionYearDataResponse();
            //// Report Year
            //ViewData["lstElectionCycle"] = new SelectList(lstElectionYearModel, "ElectionYearId", "ElectionYearValue");

            //IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();
            //lstElectionTypeModel = objItemizedReportsBroker.GetElectionTypeDataResponse(String.Empty,
            //    String.Empty, String.Empty, String.Empty);
            //// Election Type
            //ViewData["lstElectionType"] = new SelectList(lstElectionTypeModel, "ElectionTypeId", "ElectionTypeDesc");

            //IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();
            //lstElectionDateModel = objItemizedReportsBroker.GetElectionDateDataResponse(Session["ElectionCycleVal"].ToString(), Session["ElectionTypeVal"].ToString(), Session["OfficeTypeVal"].ToString());
            //// Electin Date
            //ViewData["lstElectionDate"] = new SelectList(lstElectionDateModel, "ElectId", "ElectDate");

            //IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();
            //lstDisclosurePreiodModel = objItemizedReportsBroker.GetDisclosurePeriodDataResponse(String.Empty);
            //// Disclosure Period
            //ViewData["lstDisclosurePeriod"] = new SelectList(lstDisclosurePreiodModel, "FilingTypeId", "FilingDesc");

            //IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();
            //PaymentMethodModel objPaymentMethodModel;
            //objPaymentMethodModel = new PaymentMethodModel();
            //objPaymentMethodModel.PaymentTypeId = "0";
            //objPaymentMethodModel.PaymentTypeDesc = "- Select -";
            //objPaymentMethodModel.PaymentTypeAbbrev = "SEL";
            //lstPaymentMethodModel.Add(objPaymentMethodModel);
            //var resPayMethods = objItemizedReportsBroker.GetPaymentMethodDataResponse();
            //foreach (var item in resPayMethods)
            //{
            //    objPaymentMethodModel = new PaymentMethodModel();
            //    objPaymentMethodModel.PaymentTypeId = item.PaymentTypeId;
            //    objPaymentMethodModel.PaymentTypeDesc = item.PaymentTypeDesc;
            //    objPaymentMethodModel.PaymentTypeAbbrev = item.PaymentTypeAbbrev;
            //    lstPaymentMethodModel.Add(objPaymentMethodModel);
            //}
            //// Payment Method
            //ViewData["lstMethod"] = new SelectList(lstPaymentMethodModel, "PaymentTypeId", "PaymentTypeDesc");


            //IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();
            //ContributorNameModel objContributorNameModel;
            //objContributorNameModel = new ContributorNameModel();
            //objContributorNameModel.ContributorTypeId = "0";
            //objContributorNameModel.ContributorTypeDesc = "- Select -";
            //objContributorNameModel.ContributorTypeAbbrev = "SEL";
            //lstContributorNameModel.Add(objContributorNameModel);
            //var resContributorNames = objItemizedReportsBroker.GetContributionNameDataResponse();
            //var itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "6");
            //if (itemToRemove != null)
            //    resContributorNames.Remove(itemToRemove);
            //itemToRemove = resContributorNames.SingleOrDefault(x => x.ContributorTypeId == "7");
            //if (itemToRemove != null)
            //    resContributorNames.Remove(itemToRemove);
            //foreach (var item in resContributorNames)
            //{
            //    objContributorNameModel = new ContributorNameModel();
            //    objContributorNameModel.ContributorTypeId = item.ContributorTypeId;
            //    objContributorNameModel.ContributorTypeDesc = item.ContributorTypeDesc;
            //    objContributorNameModel.ContributorTypeAbbrev = item.ContributorTypeAbbrev;
            //    lstContributorNameModel.Add(objContributorNameModel);
            //}
            //ViewData["lstContributionName"] = new SelectList(lstContributorNameModel, "ContributorTypeId", "ContributorTypeDesc");

            //IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();
            //lstContributionTypeModel = objItemizedReportsBroker.GetContributionTypeDataResponse();
            //// Bind Contribution Type
            //ViewData["lstContributionType"] = new SelectList(lstContributionTypeModel, "ContributionTypeId", "ContributionTypeDesc");

            //IList<TransferTypeModel> lstTransferTypeModel = new List<TransferTypeModel>();
            //lstTransferTypeModel = objItemizedReportsBroker.GetTransferTypeDataResponse();
            //// Bind Transfer Type
            //ViewData["lstTransferType"] = new SelectList(lstTransferTypeModel, "TransferTypeId", "TransferTypeDesc");

            //IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();
            //lstReceiptTypeModel = objItemizedReportsBroker.GetReceiptTypeDataResponse();
            //// Bind Receipt Code
            //ViewData["lstReceiptType"] = new SelectList(lstReceiptTypeModel, "ReceiptTypeId", "ReceiptTypeDesc");

            //IList<ReceiptCodeModel> lstReceiptCodeModel = new List<ReceiptCodeModel>();
            //lstReceiptCodeModel = objItemizedReportsBroker.GetReceiptCodeDataResponse();
            //// Bind Receipt Code            
            //ViewData["lstReceiptCode"] = new SelectList(lstReceiptCodeModel, "ReceiptCodeId", "ReceiptCodeDesc");

            //IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();
            //lstPurposeCodeModel = objItemizedReportsBroker.GetPurposeCodeDataResponse();
            //// Bind Purpose Code            
            //ViewData["lstPurposeCode"] = new SelectList(lstPurposeCodeModel, "PurposeCodeId", "PurposeCodeDesc");

            //IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
            //lstOfficeTypeModel = objItemizedReportsBroker.GetOfficeTypeResponse();
            //// Bind Office Type
            //ViewData["lstUCOfficeType"] = new SelectList(lstOfficeTypeModel, "OfficeTypeId", "OfficeTypeDesc");

            //IList<CountyModel> lstCountyModel = new List<CountyModel>();
            //lstCountyModel = objItemizedReportsBroker.GetCountyResponse();
            //// Bind County
            //ViewData["lstUCCounty"] = new SelectList(lstCountyModel, "CountyId", "CountyDesc");

            //IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();
            //lstMunicipalityModel = objItemizedReportsBroker.GetMunicipalityResponse(String.Empty);
            //// Bind Municipality
            //ViewData["lstUCMuncipality"] = new SelectList(lstMunicipalityModel, "MunicipalityId", "MunicipalityDesc");

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

            //// GET REASON FOR FILING DATA.
            //IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
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
            //// PLACE ALL THE SCHEDULES CONTROLLER BY DEFAULT NEW DROPDOWNS 
            //// ===================================================================================================================================
            //// THIS CODE ADD IN ALL SCHEDULES IF NOT ADDED FOR OFF-CYCLE AND PERIODIC FILINGS.
            //// ===================================================================================================================================

            //List<ItemizedModel> lstItemizedModel = new List<ItemizedModel>();
            //ItemizedModel objItemizedModel;
            //objItemizedModel = new ItemizedModel();
            //objItemizedModel.strItemizedId = "Y";
            //objItemizedModel.strItemizedName = "Yes";
            //lstItemizedModel.Add(objItemizedModel);
            //objItemizedModel = new ItemizedModel();
            //objItemizedModel.strItemizedId = "N";
            //objItemizedModel.strItemizedName = "No";
            //lstItemizedModel.Add(objItemizedModel);
            //// Bind Subcontractor
            //ViewData["lstItemized"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
            //ViewData["lstItemizedPart"] = new SelectList(lstItemizedModel, "strItemizedId", "strItemizedName", 1);
            //List<ItemizedModel> lstItemizedModelIndPart = new List<ItemizedModel>();
            //ItemizedModel objItemizedModelIndPart;
            //objItemizedModelIndPart = new ItemizedModel();
            //objItemizedModelIndPart.strItemizedId = "Y";
            //objItemizedModelIndPart.strItemizedName = "Yes";
            //lstItemizedModelIndPart.Add(objItemizedModelIndPart);
            //objItemizedModelIndPart = new ItemizedModel();
            //objItemizedModelIndPart.strItemizedId = "N";
            //objItemizedModelIndPart.strItemizedName = "No";
            //lstItemizedModelIndPart.Add(objItemizedModelIndPart);
            //ViewData["lstIndividualPart"] = new SelectList(lstItemizedModelIndPart, "strItemizedId", "strItemizedName", 1);

            //// ===================================================================================================================================
            //// ADD THIS ONE ITS NEW CODE
            //// Viewable Columns Default Values            
            //IList<ViewableColumnModel> lstViewableColumns = new List<ViewableColumnModel>();
            //lstViewableColumns = objItemizedReportsBroker.GetViewableColumnsBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            //Session["SorList"] = lstViewableColumns;
            ////Bind Column Name
            //ViewData["lstViewableColumns"] = new SelectList(lstViewableColumns, "ViewableFieldID", "ColumnName");
            //// ADD THIS ONE ITS NEW CODE
            //// ===================================================================================================================================

            //// Sortable Columns.
            //IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
            //lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
            //// Session["SorList"] = lstSortColumnName; // REMOVE SESSION HERE.....///===//===///
            ////Bind Column Name
            //ViewData["lstSortColumnName"] = new SelectList(lstSortColumnName, "ViewableFieldID", "ColumnName");
            //var lstSortColumnNameOrder = new SelectList(new[]
            //                            {
            //                                new {ID="asc",Name="Ascending "},
            //                                new{ID="desc",Name="Descending"},
            //                            },
            //                "ID", "Name", 0);
            //ViewData["lstSortColumnNameOrder"] = lstSortColumnNameOrder;

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
            };
            // Bind Disclosure Type
            ViewData["lstDisclosureType"] = new SelectList(lstDisclosureTypeModel, "DisclosureTypeId", "DisclosureTypeDesc");

            //IList<TransactionTypesModel> lstTransactionTypeModel = new List<TransactionTypesModel>();
            //lstTransactionTypeModel = objItemizedReportsBroker.GetTransactionTypesDataResponse(); ; //GetTransactionTypeData();
            //// Bind Transaction Type
            //ViewData["lstTransactionType"] = new SelectList(lstTransactionTypeModel, "FilingSchedId", "FilingSchedDesc");

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

            //Bind Loaner Code
            IList<LoanerCodeModel> lstLoanerCodeModel = new List<LoanerCodeModel>();
            lstLoanerCodeModel = objItemizedReportsBroker.GetLoanerCodeBroker();
            // Bind Municipality
            ViewData["lstLoanerCode"] = new SelectList(lstLoanerCodeModel, "LoanerID", "LoanerDesc");

            //Bind Original Date
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
            GetSearchForScheduledIModel objGetSearchForScheduledIModel = new GetSearchForScheduledIModel();
            objGetSearchForScheduledIModel.FILING_TRANS_ID = "0";
            objGetSearchForScheduledIModel.Name = "- Select -";
            lstGetSearchForScheduledIModel.Add(objGetSearchForScheduledIModel);
            var rsName = objItemizedReportsBroker.GetName_SchedueledJBroker(Session["FilerID"].ToString());

            foreach (var item in rsName)
            {
                if (item != null)
                {
                    objGetSearchForScheduledIModel = new GetSearchForScheduledIModel();
                    objGetSearchForScheduledIModel.FILING_TRANS_ID = item.FILING_TRANS_ID;
                    objGetSearchForScheduledIModel.Name = item.Name;
                    objGetSearchForScheduledIModel.flng_Ent_FirstName = item.flng_Ent_FirstName;
                    objGetSearchForScheduledIModel.flng_Ent_MiddleName = item.flng_Ent_MiddleName;
                    objGetSearchForScheduledIModel.flng_Ent_LastName = item.flng_Ent_LastName;
                    lstGetSearchForScheduledIModel.Add(objGetSearchForScheduledIModel);
                }
            }

            Session["EntityName"] = lstGetSearchForScheduledIModel;

            ViewData["lstSearchName"] = new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name");
            ViewData["lstSearchDate"] = new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name");
            ViewData["lstSearchAmount"] = new SelectList(lstGetSearchForScheduledIModel, "FILING_TRANS_ID", "Name");

            var lstLiabilityLoans = new SelectList(new[]
                                        {
                                            new {ID="0",Name="- Select -"},
                                            new{ID="1",Name="Loans"},
                                            new{ID="2",Name="Liabilities"},
                                        },
                            "ID", "Name", 0);
            ViewData["lstLiabilityLoans"] = lstLiabilityLoans;

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
            ViewData["lstLiability"] = new SelectList(lstLiability, "strLiabilityId", "strLiabilityName", 1);
            ViewData["lstLiabilityExists"] = new SelectList(lstLiability, "strLiabilityId", "strLiabilityName", 1);

            List<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
            DateIncurredModel objDateIncurredModel;
            objDateIncurredModel = new DateIncurredModel();
            objDateIncurredModel.DateIncurredId = "0";
            objDateIncurredModel.DateIncurredValue = "- Select -";
            lstDateIncurredModel.Add(objDateIncurredModel);
            // Bind Date Incurred
            ViewData["lstDateIncurred"] = new SelectList(lstDateIncurredModel, "DateIncurredId", "DateIncurredValue");

        }
        #endregion GetDefaultLookUpsValues

        /// <summary>
        /// Add Transfer In Scheduled data
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strFilingSchedId"></param>
        /// <param name="strTransferTypeId"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstElectYearId"></param>
        /// <param name="lstFilingEntId"></param>
        /// <param name="strFlngEntName"></param>
        /// <param name="strFlngEntStrName"></param>
        /// <param name="txtPartCity"></param>
        /// <param name="txtPartState"></param>
        /// <param name="txtZip"></param>
        /// <param name="txtPartZip4"></param>
        /// <param name="PaymentTypeId"></param>
        /// <returns></returns>
        public JsonResult AddLoanForgivenScheduledData(String txtFilerId, String strFilingSchedDate,
            String strAmt, String strAmtOrg, String strTransExplanation, String lstOfficeTypeId, String lstFilingTypeId, String lstElectYearId,
            String strFlngEntName, String strFlngEntFirstName, String strFlngEntMiddleName, String strFlngEntLastName,
            String strFlngEntStrName, String txtCity, String txtState, String txtZip, String txtCountry, String chkCountry, 
            String paymentTypeId, String loanerCodeID, String payNumber, String lstFilingDate, String txtReportPeriodDatesTo, 
            String electionDateId, String lstResigTermType, String txtCuttOffDate, String strElectionTypeId, String trans_Nubmer, String lstUCMuncipality)
        {
            try
            {
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                if (paymentTypeId == "0")
                {
                    paymentTypeId = "";
                    payNumber = "";
                }

                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;

                if (txtZip == "00000-0000")
                    txtZip = "";

                objFilingTransactionsModel.FilerId = txtFilerId;

                #region FormValidationScheduleA                       

                DateTime dDate;
                // Current Date.
                if (String.IsNullOrEmpty(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received is required");
                }
                else if (!objCommonErrorsServerSide.DateUS(strFilingSchedDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                else if (!DateTime.TryParse(strFilingSchedDate, out dDate))
                {
                    ModelState.AddModelError("txtCurrentDateLoanReceived", "Enter valid date format (MM/DD/YYYY)");
                }
                //else if (strElectionTypeId == "6")
                //{
                //    if (lstFilingDate == "- New Filing Date -")
                //    {
                //        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtReportPeriodDatesTo))
                //        {
                //            ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                //        }
                //    }
                //    else
                //    {
                //        if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, lstFilingDate))
                //        {
                //            //ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                //        }
                //    }
                //}
                //else if (!objCommonErrorsServerSide.CuttOffDateValidation(strFilingSchedDate, txtCuttOffDate))
                //{
                //    ModelState.AddModelError("txtCurrentDateLoanReceived", "Date Received cannot be later than Cut Off Date");
                //}

                if (loanerCodeID == "1" || loanerCodeID == "2" || loanerCodeID == "3" || loanerCodeID == "4" || loanerCodeID == "6"
                    || loanerCodeID == "7" || loanerCodeID == "8" || loanerCodeID == "9")
                {
                    if (strFlngEntFirstName == "")
                    {
                        ModelState.AddModelError("txtLenderFirstName", "First Name is required");
                    }
                    else if (!objCommonErrorsServerSide.NameValidate(strFlngEntFirstName))
                    {
                        ModelState.AddModelError("txtLenderFirstName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntFirstName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderFirstName", "First Name should be 30 characters");
                    }


                    //if (strFlngEntMiddleName == "")
                    //{
                    //    ModelState.AddModelError("txtLenderMIName", "Middle Name is required");
                    //}
                    if (!objCommonErrorsServerSide.NameValidate(strFlngEntMiddleName))
                    {
                        ModelState.AddModelError("txtLenderMIName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntMiddleName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderMIName", "Middle Name should be 30 characters");
                    }


                    if (strFlngEntLastName == "")
                    {
                        ModelState.AddModelError("txtLenderLastName", "Last Name is required");
                    }
                    else if (!objCommonErrorsServerSide.NameValidate(strFlngEntLastName))
                    {
                        ModelState.AddModelError("txtLenderLastName", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strFlngEntLastName.Count() > 30)
                    {
                        ModelState.AddModelError("txtLenderLastName", "Last Name should be 30 characters");
                    }
                }
                else if (loanerCodeID == "10" || loanerCodeID == "11" || loanerCodeID == "12" || loanerCodeID == "13")
                {
                    if (strFlngEntName == "")
                    {
                        ModelState.AddModelError("txtLenderName", "Lender Name is required");
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

                    if (strFlngEntStrName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngEntStrName))
                        {
                            ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (strFlngEntStrName.Length < 4)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                            }
                        }

                        if (strFlngEntStrName.Count() > 60)
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

                    if (txtZip != "")
                    {
                        if (txtCountry == "United States")
                        {
                            if (!objCommonErrorsServerSide.FomatZipcode(txtZip))
                            {
                                ModelState.AddModelError("txtZipCode", "Numbers and - are allowed");
                            }
                        }
                        else // Other Country
                        {
                            if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZip))
                            {
                                ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                            }
                        }
                        if (txtZip.Count() > 10)
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

                    if (strFlngEntStrName != "")
                    {
                        if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(strFlngEntStrName))
                        {
                            ModelState.AddModelError("txtStreetName", "Letters, numbers and characters '# -., are allowed");
                        }
                        else
                        {
                            if (strFlngEntStrName.Length < 4)
                            {
                                ModelState.AddModelError("txtStreetName", "Street Address must contain at least four characters");
                            }
                        }
                        if (strFlngEntStrName.Count() > 60)
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

                    if (txtZip != "")
                    {
                        if (!objCommonErrorsServerSide.OtherCountryZipVal(txtZip))
                        {
                            ModelState.AddModelError("txtZipCode", "Letters, numbers and - are allowed");
                        }
                        if (txtZip.Count() > 10)
                        {
                            ModelState.AddModelError("txtZipCode", "Zip Code should be 10 characters");
                        }
                    }

                }

                if (paymentTypeId == "1")
                {
                    if (payNumber == "")
                    {
                        ModelState.AddModelError("txtCheck", "Check # is required");
                    }
                    else if (!objCommonErrorsServerSide.AlphaNumeric(payNumber))
                    {
                        ModelState.AddModelError("txtCheck", "Letters and numbers are allowed");
                    }
                    else if (payNumber.Count() > 30)
                    {
                        ModelState.AddModelError("txtCheck", "Check should be 30 characters");
                    }
                }
                else if (paymentTypeId == "7")
                {
                    if (strTransExplanation == "")
                    {
                        ModelState.AddModelError("txtExplanation", "Explanation is required");
                    }
                    else if (!objCommonErrorsServerSide.ValidateAlphaNumericAddress(payNumber))
                    {
                        ModelState.AddModelError("txtCheck", "Letters, numbers and characters '# -., are allowed");
                    }
                    else if (strTransExplanation.Count() > 250)
                    {
                        ModelState.AddModelError("txtCheck", "Explanation should be 250 characters");
                    }
                }

                if (paymentTypeId != "")
                {
                    if (paymentTypeId != "0")
                    {
                        Boolean resultsData = objItemizedReportsBroker.GetDropdownValueExistsResponse("PAYMENT_TYPE", paymentTypeId.ToString());
                        if (!resultsData)
                        {
                            ModelState.AddModelError("lstMethod", "Invalid Method");
                        }
                    }
                }


                if (strAmtOrg == "")
                {
                    ModelState.AddModelError("txtAmt", "Amount is required");
                }
                else if (!objCommonErrorsServerSide.AmountValidate(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.NumbersOnly(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.Amount12DigitVal(strAmtOrg))
                {
                    ModelState.AddModelError("txtAmt", "Enter valid Amount (999999999.99)");
                }
                else if (!objCommonErrorsServerSide.AmountZeroVal(strAmtOrg))
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

                string results = string.Empty;
                if (ModelState.IsValid)
                {
                    //Add Loan Received                                                
                    objFilingTransactionsModel.FilerId = txtFilerId; //"110993"; // txtFilerId;
                    objFilingTransactionsModel.FilingSchedId = "11";
                    objFilingTransactionsModel.OtherFilingSchedId = "14";
                    objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                    objFilingTransactionsModel.OrgAmt = strAmtOrg;
                    objFilingTransactionsModel.OtherAmount = strAmt;
                    objFilingTransactionsModel.TransExplanation = strTransExplanation;
                    objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                    objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                    objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                    objFilingTransactionsModel.ElectYearId = lstElectYearId;
                    if (Session["FilingEntId"] != null)
                        objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                    else
                        objFilingTransactionsModel.FilingEntId = "";
                    objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                    objFilingTransactionsModel.FlngEntName = strFlngEntName;
                    objFilingTransactionsModel.FlngEntFirstName = strFlngEntFirstName;
                    objFilingTransactionsModel.FlngEntMiddleName = strFlngEntMiddleName;
                    objFilingTransactionsModel.FlngEntLastName = strFlngEntLastName;
                    objFilingTransactionsModel.FlngEntStrName = strFlngEntStrName;
                    objFilingTransactionsModel.FlngEntCity = txtCity;
                    objFilingTransactionsModel.FlngEntState = txtState;
                    objFilingTransactionsModel.FlngEntZip = txtZip;
                    objFilingTransactionsModel.FlngEntCountry = txtCountry;
                    objFilingTransactionsModel.PaymentTypeId = paymentTypeId;
                    objFilingTransactionsModel.LoanOtherId = loanerCodeID;
                    objFilingTransactionsModel.PayNumber = payNumber;
                    if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
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
                    objFilingTransactionsModel.ElectionDateId = electionDateId;
                    if (lstResigTermType == "")
                        lstResigTermType = null;
                    if (lstResigTermType == "- Not Applicable -")
                        lstResigTermType = null;
                    objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                    objFilingTransactionsModel.Loan_Lib_Number = "";
                    objFilingTransactionsModel.TransNumber = trans_Nubmer;
                    objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;

                    results = objItemizedReportsBroker.AddFilingTransaction_LoanForgiven_Broker(objFilingTransactionsModel);
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetSortName()
        {
            try
            {
                string results = string.Empty;
                IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
                lstSortColumnName = (IList<ViewableColumnModel>)Session["SorList"];
                lstSortColumnName = lstSortColumnName.Where(x => x.Viewable == "Y").ToList();
                foreach (var item in lstSortColumnName)
                {
                    if (item != null)
                    {
                        results = results + item.ColumnName + ",";
                    }
                }
                results = results.Substring(0, (results.Length - 1));
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Delete Loan Forgiven Amount
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult DeleteLoanForgiven(String strLoanLiabNumberOrg, String strTransNumber, String strRLiability)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["AllTransactionsList"];

                String strLiability = lstFilingTransactionDataModel.Where(x => x.TransNumber == strTransNumber).Select(x => x.RLiability).FirstOrDefault().ToString();

                Boolean results = objItemizedReportsBroker.DeleteLoanForgivenBroker(strLoanLiabNumberOrg, strTransNumber, Session["UserName"].ToString(), strLiability, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }        

        public JsonResult GetScheduleJ_EntityData(String filing_Trans_ID)
        {
            try
            {
                IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
                lstFilingTransactionsModel = objItemizedReportsBroker.GetScheduleJ_EntityDataBroker(filing_Trans_ID, Session["FilerID"].ToString());
                if (lstFilingTransactionsModel.Count > 0)
                {
                    Session["FilingEntityID"] = lstFilingTransactionsModel[0].FilingEntId.ToString();
                }
                else
                {
                    Session["FilingEntityID"] = "";
                }
                
                return Json(lstFilingTransactionsModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetSearchAmount(string FILING_ENTITY_NAME)
        {
            try
            {
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModelTemp = new List<GetSearchForScheduledIModel>();
                lstGetSearchForScheduledIModelTemp = (IList<GetSearchForScheduledIModel>)Session["EntityName"];
                lstGetSearchForScheduledIModelTemp = lstGetSearchForScheduledIModelTemp.Where(a => a.Name == FILING_ENTITY_NAME).ToList();
                lstGetSearchForScheduledIModel = objItemizedReportsBroker.GetAmount_SchedueledJBroker(FILING_ENTITY_NAME, lstGetSearchForScheduledIModelTemp[0].flng_Ent_FirstName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_MiddleName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_LastName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].filer_Id);
                return Json(new SelectList(lstGetSearchForScheduledIModel, "Amount", "Amount"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult GetSearchDate(string FILING_ENTITY_NAME, string ORG_AMT)
        {
            try
            {
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModel = new List<GetSearchForScheduledIModel>();
                IList<GetSearchForScheduledIModel> lstGetSearchForScheduledIModelTemp = new List<GetSearchForScheduledIModel>();
                lstGetSearchForScheduledIModelTemp = (IList<GetSearchForScheduledIModel>)Session["EntityName"];
                lstGetSearchForScheduledIModelTemp = lstGetSearchForScheduledIModelTemp.Where(a => a.Name == FILING_ENTITY_NAME).ToList();
                lstGetSearchForScheduledIModel = objItemizedReportsBroker.GetDate_SchedueledJBroker(FILING_ENTITY_NAME, ORG_AMT, lstGetSearchForScheduledIModelTemp[0].flng_Ent_FirstName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_MiddleName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].flng_Ent_LastName,
                                                                                                        lstGetSearchForScheduledIModelTemp[0].filer_Id);
                return Json(new SelectList(lstGetSearchForScheduledIModel, "Trans_Number", "Date"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region AddLoanForgivenLiabilitiesData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="strRLiabilityExists"></param>
        /// <param name="strFilingSchedDate"></param>
        /// <param name="strFilingEntName"></param>
        /// <param name="strFilingEntId"></param>
        /// <param name="strStreetName"></param>
        /// <param name="strCity"></param>
        /// <param name="strState"></param>
        /// <param name="strZip"></param>
        /// <param name="strCountry"></param>
        /// <param name="strPaymentTypeID"></param>
        /// <param name="strPayNumber"></param>
        /// <param name="strOrgAmt"></param>
        /// <param name="strOriginalAmt"></param>
        /// <param name="strOutstandingAmount"></param>
        /// <param name="strOwedAmount"></param>
        /// <param name="strTransExplanation"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstElectYearId"></param>
        /// <param name="lstFilingDate"></param>
        /// <param name="txtReportPeriodDatesTo"></param>
        /// <param name="electionDateId"></param>
        /// <param name="lstResigTermType"></param>
        /// <param name="txtCuttOffDate"></param>
        /// <param name="trans_Nubmer_Org"></param>
        /// <returns></returns>
        public JsonResult AddLoanForgivenLiabilitiesData(String txtFilerId, String strRLiabilityExists, 
            String strFilingSchedDate, String strFilingEntName, String strFilingEntId, 
            String strStreetName, String strCity, String strState, String strZip, String strCountry, String strPaymentTypeID,
            String strPayNumber, String strOrgAmt,String strOriginalAmt, String strOutstandingAmount, String strOwedAmount, 
            String strTransExplanation, String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId, 
            String lstElectYearId, String lstFilingDate, String txtReportPeriodDatesTo, String electionDateId, 
            String lstResigTermType, String txtCuttOffDate, String trans_Nubmer_Org, String lstUCMuncipality)
        {
            try
            {
                var results = true;

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                if (Session["lstDateIncurredModelnew"] != null)
                {
                    lstDateIncurredModel = (IList<DateIncurredModel>)Session["lstDateIncurredModelnew"];
                }

                //Add Loan Received                
                FilingTransactionsModel objFilingTransactionsModel = new FilingTransactionsModel();
                objFilingTransactionsModel.FilerId = txtFilerId;
                objFilingTransactionsModel.RLiabilityExists = strRLiabilityExists;
                objFilingTransactionsModel.SchedDate = strFilingSchedDate;
                objFilingTransactionsModel.FlngEntName = strFilingEntName;
                if (Session["FilingEntId"] != null)
                    objFilingTransactionsModel.FilingEntId = Session["FilingEntId"].ToString();
                else
                    objFilingTransactionsModel.FilingEntId = "";
                objFilingTransactionsModel.FlngEntStrName = strStreetName;
                objFilingTransactionsModel.FlngEntCity = strCity;
                objFilingTransactionsModel.FlngEntState = strState;
                objFilingTransactionsModel.FlngEntZip = strZip;
                objFilingTransactionsModel.FlngEntCountry = strCountry;
                objFilingTransactionsModel.PaymentTypeId = strPaymentTypeID;
                objFilingTransactionsModel.PayNumber = strPayNumber;
                if (strRLiabilityExists == "Y")
                {
                    objFilingTransactionsModel.OrgAmt = lstDateIncurredModel[0].AmountLiability.ToString();
                    objFilingTransactionsModel.OtherAmount = strOutstandingAmount;
                    objFilingTransactionsModel.OwedAmt = strOwedAmount;
                }
                else
                {
                    objFilingTransactionsModel.OrgAmt = strOriginalAmt;
                    objFilingTransactionsModel.OtherAmount = strOutstandingAmount;
                    objFilingTransactionsModel.OwedAmt = strOwedAmount;
                }

                objFilingTransactionsModel.TransExplanation = strTransExplanation;
                objFilingTransactionsModel.ElectionTypeId = strElectionTypeId;
                objFilingTransactionsModel.OfficeTypeId = lstOfficeTypeId;
                objFilingTransactionsModel.FilingTypeId = lstFilingTypeId;
                objFilingTransactionsModel.ElectYearId = lstElectYearId;
                objFilingTransactionsModel.CreatedBy = Session["UserName"].ToString();
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
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
                objFilingTransactionsModel.ElectionDateId = electionDateId;
                if (lstResigTermType == "")
                    lstResigTermType = null;
                if (lstResigTermType == "- Not Applicable -")
                    lstResigTermType = null;
                objFilingTransactionsModel.ResigTermTypeId = lstResigTermType;
                objFilingTransactionsModel.TransNumber = trans_Nubmer_Org;
                objFilingTransactionsModel.MunicipalityID = lstUCMuncipality;

                results = objItemizedReportsBroker.AddFilingTransaction_LoanForgiven_Liabiliites_Broker(objFilingTransactionsModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion AddLoanForgivenLiabilitiesData

        #region GetOutstandingAmount
        /// <summary>
        /// GetOriginalAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public JsonResult GetOutstandingAmount(String strFlngEntityId, String strUpdateStatusVal, String strSchedFAmt, String strTransNumber)
        {
            try
            {
                IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();
                IList<DateIncurredModel> lstDateIncurredModelnew = new List<DateIncurredModel>();
                IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

                if (strSchedFAmt.Contains("$"))
                {
                    var indexOrgAmt = strSchedFAmt.IndexOf(".");
                    strSchedFAmt = strSchedFAmt.Substring(1, indexOrgAmt - 1);
                }

                // FILINGS ID
                String strFilingsId = Session["FilerID"].ToString();

                lstOriginalAmountModel = objItemizedReportsBroker.GetOutstandingAmountLiabData_ForgivenBroker(strFlngEntityId, strTransNumber, strFilingsId);

                if (Session["DateIncurredOrgAmountForForgiven"] != null)
                {
                    lstDateIncurredModel = (IList<DateIncurredModel>)Session["DateIncurredOrgAmountForForgiven"];
                    lstDateIncurredModelnew = lstDateIncurredModel.Where(x => x.DateIncurredId == strTransNumber).ToList();
                    Session["lstDateIncurredModelnew"] = lstDateIncurredModelnew;
                }

                String strOutstandingAmount = String.Empty;
                if (lstOriginalAmountModel.Count > 0)
                {
                    strOutstandingAmount = lstOriginalAmountModel[0].OutstandingAmount;

                    Session["lstDateIncurredModelnew"] = lstDateIncurredModelnew;
                    //foreach (var item in lstOriginalAmountModel)
                    //{

                    //    String strOriginalAmount = String.Empty;

                    //    lstDateIncurredModel = (IList<DateIncurredModel>)Session["DateIncurredOrgAmountForForgiven"];
                    //    strOriginalAmount = lstDateIncurredModel.Where(x => x.DateIncurredId == strTransNumber).Select(x => x.AmountLiability).First().ToString();

                    //    strOutstandingAmount = item.OutstandingAmount.ToString();

                    //    // DECIMAL VALUES.
                    //    Decimal dOriginalAmount = Convert.ToDecimal(strOriginalAmount);
                    //    Decimal dTotalPayAmount = Convert.ToDecimal(strOutstandingAmount);
                    //    Decimal dOutstandingAmount;

                    //    dOutstandingAmount = dOriginalAmount - dTotalPayAmount;

                    //    strOutstandingAmount = dOutstandingAmount.ToString();
                    //}
                }
                else
                {
                    if (Session["DateIncurredOrgAmountForForgiven"] != null)
                    {
                        lstDateIncurredModel = (IList<DateIncurredModel>)Session["DateIncurredOrgAmountForForgiven"];
                        strOutstandingAmount = lstDateIncurredModel[0].OutstandingAmount;
                        //strOutstandingAmount = lstDateIncurredModel.Where(x => x.DateIncurredId == strTransNumber).Select(x => x.AmountLiability).First().ToString();
                    }
                }

                return Json(strOutstandingAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LiabilitiesLoansForgivenSchedKController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetOutstandingAmount

        #region GetScheduleKHelpPopUp
        /// <summary>
        /// GetScheduleAHelpPopUp
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScheduleKHelpPopUp()
        {
            return View("GetScheduleKHelpPopUp");
        }
        #endregion GetScheduleKHelpPopUp

        
    }
}