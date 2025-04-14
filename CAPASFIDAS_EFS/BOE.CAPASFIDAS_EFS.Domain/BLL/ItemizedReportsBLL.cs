using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class ItemizedReportsBLL
    {
        // Create DAL Object
        ItemizedReportsDAL objItemizedReportsDAL = new ItemizedReportsDAL();

        /// <summary>
        /// mapGetFilingTransactionsDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransactionsDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransactionsDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        
        internal IList<ContributionTypeModel> mapGetContributionTypeDataBLLResponse()
        {
            IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();

            lstContributionTypeModel = objItemizedReportsDAL.mapGetContributionTypeDataDALResponse();

            return lstContributionTypeModel;
        }

        internal IList<ContributorNameModel> mapGetContributionNameDataBLLResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsDAL.mapGetContributionNameDataDALResponse();

            return lstContributorNameModel;
        }

        internal IList<DisclosurePreiodModel> mapGetDisclosurePeriodDataBLLResponse(String strElectTypeId, String strfilerID, String strElectYearId)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

            lstDisclosurePreiodModel = objItemizedReportsDAL.mapGetDisclosurePeriodDataDALResponse(strElectTypeId, strfilerID, strElectYearId);

            return lstDisclosurePreiodModel;
        }

        internal IList<ElectionDateModel> mapGetElectionDateDataBLLResponse(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strCounty, String strMunicipality)
        {
            IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();

            lstElectionDateModel = objItemizedReportsDAL.mapGetElectionDateDataDALResponse(strElectYearId, strElectTypeId, strOfficeTypeId, strCounty, strMunicipality);
            
            return lstElectionDateModel;
        }

        internal IList<FilerCommitteeModel> mapGetFilerCommitteeDataBLLResponse(String strPersonId)
        {
            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();

            lstFilerCommitteeModel = objItemizedReportsDAL.mapGetFilerCommitteeDataDALResponse(strPersonId);

            return lstFilerCommitteeModel;
        }

        internal IList<PaymentMethodModel> mapGetPaymentMethodDataBLLResponse()
        {
            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();

            lstPaymentMethodModel = objItemizedReportsDAL.mapGetPaymentMethodDataDALResponse();

            return lstPaymentMethodModel;
        }

        internal IList<PurposeCodeModel> mapGetPurposeCodeDataBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetPurposeCodeDataDALResponse();

            return lstPurposeCodeModel;
        }

        internal IList<ReceiptCodeModel> mapGetReceiptCodeDataBLLResponse()
        {
            IList<ReceiptCodeModel> lstReceiptCodeModel = new List<ReceiptCodeModel>();

            lstReceiptCodeModel = objItemizedReportsDAL.mapGetReceiptCodeDataDALResponse();

            return lstReceiptCodeModel;
        }

        internal IList<ReceiptTypeModel> mapGetReceiptTypeDataBLLResponse()
        {
            IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();

            lstReceiptTypeModel = objItemizedReportsDAL.mapGetReceiptTypeDataDALResponse();
            
            return lstReceiptTypeModel;
        }

        internal IList<TransferTypeModel> mapGetTransferTypeDataBLLResponse()
        {
            IList<TransferTypeModel> lstTransferTypeModel = new List<TransferTypeModel>();

            lstTransferTypeModel = objItemizedReportsDAL.mapGetTransferTypeDataDALResponse();

            return lstTransferTypeModel;
        }

        internal IList<ElectionYearModel> mapGetElectionYearDataBLLResponse(String filerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objItemizedReportsDAL.mapGetElectionYearDataDALResponse(filerID);

            return lstElectionYearModel;
        }

        internal IList<ElectionTypeModel> mapGetElectionTypeDataBLLResponse(String strElectionYearId,
            String strOfficeTypeId, String strCountyId, String strMunicipalityId, String strCommTypeId)
        {
            IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();

            lstElectionTypeModel = objItemizedReportsDAL.mapGetElectionTypeDataDALResponse(strElectionYearId,
                strOfficeTypeId, strCountyId, strMunicipalityId, strCommTypeId);
           
            return lstElectionTypeModel;
        }

        internal IList<FilingCutOffDateModel> mapGetFilingCutOffDateDataBLLResponse(String strElectYearId, String strFilingTypeId, String strOfficeTypeId, String strFilingDateId, String strCuttOffDateId, String strElectionDateId)
        {
            IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

            lstFilingCutOffDateModel = objItemizedReportsDAL.mapGetFilingCutOffDateDataDALResponse(strElectYearId, strFilingTypeId, strOfficeTypeId, strFilingDateId, strCuttOffDateId, strElectionDateId);

            return lstFilingCutOffDateModel;
        }

        /// <summary>
        /// mapGetContributorTypesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorTypesModel> mapGetContributorTypesDataBLLResponse()
        {
            IList<ContributorTypesModel> lstContributorTypesModel = new List<ContributorTypesModel>();

            lstContributorTypesModel = objItemizedReportsDAL.mapGetContributorTypesDataDALResponse();

            
            return lstContributorTypesModel;
        }

        /// <summary>
        /// mapGetTransactionTypesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetTransactionTypesDataBLLResponse(String strCandCommId = "")
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsDAL.mapGetTransactionTypesDataDALResponse(strCandCommId);

            return lstTransactionTypesModel;
        }

        /// <summary>
        /// mapGetDisclosureTypesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<DisclosureTypesModel> mapGetDisclosureTypesDataBLLResponse(String strCandCommId)
        {
            IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();

            lstDisclosureTypesModel = objItemizedReportsDAL.mapGetDisclosureTypesDataDALResponse(strCandCommId);

            return lstDisclosureTypesModel;
        }

        /// <summary>
        /// mapAddFilingTransactionsDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddFlngTransContrInKindDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.mapAddFlngTransContrInKindDataDALResponse(objFilingTransactionsModel);

            return result;
        }

        internal IList<OfficeTypeModel> mapGetOfficeTypeBLLResponse()
        {
            IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();

            lstOfficeTypeModel = objItemizedReportsDAL.mapGetOfficeTypeDALResponse();

            return lstOfficeTypeModel;
        }

        internal IList<CountyModel> mapGetCountyBLLResponse()
        {
            IList<CountyModel> lstCountyModel = new List<CountyModel>();

            lstCountyModel = objItemizedReportsDAL.mapGetCountyDALResponse();

            return lstCountyModel;
        }

        internal IList<MunicipalityModel> mapGetMunicipalityBLLResponse(String strCountyId)
        {
            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();

            lstMunicipalityModel = objItemizedReportsDAL.mapGetMunicipalityDALResponse(strCountyId);

            return lstMunicipalityModel;
        }

        /// <summary>
        /// mapGetAutoCompleteNameAddressBLLResponse
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strFLName"></param>
        /// <returns></returns>
        internal IList<AutoCompFLNameAddressModel> mapGetAutoCompleteNameAddressBLLResponse(String name, String strFilerId, String strFLName)
        {
            IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

            lstAutoCompFLNameAddressModel = objItemizedReportsDAL.mapGetAutoCompleteNameAddressDALResponse(name, strFilerId, strFLName);
            
            return lstAutoCompFLNameAddressModel;
        }

        /// <summary>
        /// mapDeleteFilingTransactionsDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteFilingTransactionsDataBLLResponse(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            Boolean results = objItemizedReportsDAL.mapDeleteFilingTransactionsDataDALResponse(strTransNumber, strModifiedBy, strFilerID);

            return results;
        }

        /// <summary>
        /// mapDeleteFlngTransExpPaySchedFNDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteFlngTransExpPaySchedFNDataBLLResponse(String strLoanLiabNumberOrg, String strTransNumberOrg, String strRLiability, String strModifiedBy, String strFilerID, String strSchedID)
        {
            Boolean results = objItemizedReportsDAL.mapDeleteFlngTransExpPaySchedFNDataDALResponse(strLoanLiabNumberOrg, strTransNumberOrg, strRLiability, strModifiedBy, strFilerID, strSchedID);

            return results;
        }

        /// <summary>
        /// Viewable Column BLL
        /// </summary>
        /// <param name="strUniqueID"></param>
        /// <param name="strApplicationName"></param>
        /// <param name="strPageName"></param>
        /// <returns></returns>
        internal IList<ViewableColumnModel> GetViewableColumnsBLL(String strUniqueID, String strApplicationName, String strPageName)
        {
            IList<ViewableColumnModel> lstViewableColumnModel = new List<ViewableColumnModel>();

            lstViewableColumnModel = objItemizedReportsDAL.GetViewableColumnsDAL(strUniqueID, strApplicationName, strPageName);

            return lstViewableColumnModel;
        }

        internal IList<ViewableColumnModel> GetViewableColumnsSortingBLL(String strUniqueID, String strApplicationName, String strPageName)
        {
            IList<ViewableColumnModel> lstViewableColumnModel = new List<ViewableColumnModel>();

            lstViewableColumnModel = objItemizedReportsDAL.GetViewableColumnsSortingDAL(strUniqueID, strApplicationName, strPageName);                                         
            return lstViewableColumnModel;
        }

        /// <summary>
        /// Update Column BLL
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="modifyBy"></param>
        /// <returns></returns>
        internal Boolean UpdateColumnValueBLL(String uniqueID, String applicationName, String pageName, String uniqueValue, String modifyBy)
        {
            Boolean results = objItemizedReportsDAL.UpdateColumnValueDAL(uniqueID,
                                         applicationName,
                                         pageName,
                                         uniqueValue,
                                         modifyBy);

            return results;
        }

        /// <summary>
        /// mapUpdateFilingTransactionsDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionDataModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFilingTransContrInKindDataBLLResponse(FilingTransactionDataModel objFilingTransactionDataModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateFilingTransContrInKindDataDALResponse(objFilingTransactionDataModel);

            return returnValue;
        }

        internal IList<ContributorNameModel> mapGetPartnerSubContractorDataBLLResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsDAL.mapGetPartnerSubContractorDataDALResponse();

            return lstContributorNameModel;
        }

        //internal Boolean mapAddLoanReceivedBLLResponse(IList<FilingTransactionsModel> objFilingTransactionsModel)
        //{
        //    Boolean result = objItemizedReportsDAL.mapAddLoanReceivedDALResponse(objFilingTransactionsModel);

        //    return result;
        //}

        /// <summary>
        /// mapAddContrInKindPartnersDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddContrInKindPartnersDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.mapAddContrInKindPartnersDataDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapGetContrInKindPartnersDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ContrInKindPartnersModel> mapGetContrInKindPartnersDataBLLResponse(String strFilingTransId, String strFilerId)
        {
            IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();

            lstContrInKindPartnersModel = objItemizedReportsDAL.mapGetContrInKindPartnersDataDALResponse(strFilingTransId, strFilerId);

            return lstContrInKindPartnersModel;
        }

        /// <summary>
        /// mapDeleteContrInKindPartnersDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteContrInKindPartnersDataBLLResponse(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsDAL.mapDeleteContrInKindPartnersDataDALResponse(strTransNumber, strModifiedBy, strFilerID);

            return returnValue;

        }

        /// <summary>
        /// mapUpdateContrInKindPartnersDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateContrInKindPartnersDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateContrInKindPartnersDataDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// Add Transfer In scheudled data BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_TransferIn_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddFilingTransaction_TransferIn_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction 
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFilingTransaction_TransferIn_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.UpdateFilingTransaction_TransferIn_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapAddFilingTransactionNonCompHKReceiptsBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddFilingTransactionNonCompHKReceiptsBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string results = objItemizedReportsDAL.mapAddFilingTransactionNonCompHKReceiptsDALResponse(objFilingTransactionsModel);

            return results;
        }

        /// <summary>
        /// mapUpdateFilingTransNonCompHKReceiptsBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFilingTransNonCompHKReceiptsBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsDAL.mapUpdateFilingTransNonCompHKReceiptsDALResponse(objFilingTransactionsModel);

            return results;
        }

        /// <summary>
        /// mapAddFlngTransContrMonetaryDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddFlngTransContrMonetaryDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.mapAddFlngTransContrMonetaryDataDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateFlngTransMonetaryContrDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFlngTransMonetaryContrDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateFlngTransMonetaryContrDataDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// mapAddFlngTransExpenditureDataDALResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal String mapAddFlngTransExpenditureDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            String result = objItemizedReportsDAL.mapAddFlngTransExpenditureDataDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Add Transfer Out scheudled data BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_TransferOut_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddFilingTransaction_TransferOut_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction 
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFilingTransaction_TransferOut_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.UpdateFilingTransaction_TransferOut_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Add Loan Received scheudled data BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_LoanReceived_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddFilingTransaction_LoanReceived_DAL(objFilingTransactionsModel);

            return result;
        }

        internal string AddFilingTransaction_LoanRepayment_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddFilingTransaction_LoanRepayment_DAL(objFilingTransactionsModel);

            return result;
        }
        

        /// <summary>
        /// Update Filing Transaction 
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFilingTransaction_LoanReceived_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.UpdateFilingTransaction_LoanReceived_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Get Loaner Code BLL
        /// </summary>
        /// <returns></returns>
        internal IList<LoanerCodeModel> GetLoanerCodeBLL()
        {
            IList<LoanerCodeModel> lstLoanerCodeModel = new List<LoanerCodeModel>();
            lstLoanerCodeModel = objItemizedReportsDAL.GetLoanerCodeDAL();
            return lstLoanerCodeModel;
        }

        /// <summary>
        /// GetAutoCompleteCreditorNameLiabBLLResponse
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal IList<OutstandingLiabilityModel> mapGetAutoCompleteCreditorNameLiabBLLResponse(String name, String strFilerId, String strNameFlag)
        {
            IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

            lstOutstandingLiabilityModel = objItemizedReportsDAL.mapGetAutoCompleteCreditorNameLiabDALResponse(name, strFilerId, strNameFlag);
                                                                          
            return lstOutstandingLiabilityModel;
        }

        /// <summary>
        /// GetDateIncurredLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetDateIncurredLiabDataBLLResponse(String strFilingEntityId, String strFilerId)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsDAL.mapGetDateIncurredLiabDataDALResponse(strFilingEntityId, strFilerId);
                                       
            return lstDateIncurredModel;
        }

        /// <summary>
        /// GetDateIncurredLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetDateIncurredLiabDataForForgivenBLL(String strFilingEntityId, String strFilerId)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsDAL.mapGetDateIncurredLiabDataForForgivenDAL(strFilingEntityId, strFilerId);

            return lstDateIncurredModel;
        }

        /// <summary>
        /// GetOriginalAmountLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<OriginalAmountModel> mapGetOutstandingAmountLiabDataBLLResponse(String strFilingEntityId, String strUpdateStatus, String strFilingTransId, String strFilingsId)
        {
            IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

            lstOriginalAmountModel = objItemizedReportsDAL.mapGetOutstandingAmountLiabDataDALResponse(strFilingEntityId, strUpdateStatus, strFilingTransId, strFilingsId);

            return lstOriginalAmountModel;
        }

        /// <summary>
        /// mapGetExpenditureLiabilityExistsBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal String mapGetExpenditureLiabilityExistsBLLResponse(String strFilingEntityId, String strFlngEntyName, String filerID)
        {
            String returnFlngEntityId = String.Empty;

            returnFlngEntityId = objItemizedReportsDAL.mapGetExpenditureLiabilityExistsDALResponse(strFilingEntityId, strFlngEntyName, filerID);

            return returnFlngEntityId;
        }

        /// <summary>
        /// mapGetExpPaymentsLiabilityDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<OutstandingLiabilityModel> mapGetExpPaymentsLiabilityDataBLLResponse(String strTransNumber, String strFilerId)
        {
            IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

            lstOutstandingLiabilityModel = objItemizedReportsDAL.mapGetExpPaymentsLiabilityDataDALResponse(strTransNumber, strFilerId);

            return lstOutstandingLiabilityModel;
        }

        /// <summary>
        /// mapUpdateFlngTransExpenditureDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFlngTransExpenditureDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {   
            Boolean returnValue = objItemizedReportsDAL.mapUpdateFlngTransExpenditureDataDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// mapGetSubcontracorsExistsBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal Boolean mapGetSubcontracorsExistsBLLResponse(String strFilingTransId)
        {
            Boolean results = objItemizedReportsDAL.mapGetSubcontracorsExistsDALResponse(strFilingTransId);

            return results;
        }

        /// <summary>
        /// Get Date
        /// </summary>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> GetDate_SchedueledJBLL(string FILING_ENTITY_NAME, string ORG_AMT, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsDAL.GetDate_SchedueledJDAL(FILING_ENTITY_NAME, ORG_AMT, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Amount
        /// </summary>
        /// <param name="filing_date"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> GetAmount_SchedueledJBLL(string FILING_ENTITY_NAME, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsDAL.GetAmount_SchedueledJDAL(FILING_ENTITY_NAME, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Name
        /// </summary>
        /// <param name="filing_date"></param>
        /// <param name="org_amt"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> GetName_SchedueledJBLL(string filer_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsDAL.GetName_SchedueledJDAL(filer_ID);
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Schedule J Entity Data
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> GetScheduleJ_EntityDataBLL(string trans_Number, String filerID)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
            lstFilingTransactionsModel = objItemizedReportsDAL.GetScheduleJ_EntityDataDAL(trans_Number, filerID);
            return lstFilingTransactionsModel;
        }

        /// <summary>
        /// Validate Scheduled J Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> ValidateSchedJ_AmountBLL(string trans_Nubmer, string status, string FilerID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsDAL.ValidateSchedJ_AmountDAL(trans_Nubmer, status, FilerID);            
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// mapAddFilingTransExpReimbursmentDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddFilingTransExpReimbursmentDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {  
            Boolean result = objItemizedReportsDAL.mapAddFilingTransExpReimbursmentDataDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapGetFlngTransExpReimbursementDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>GetReimbursementDetailsAmt
        /// <returns></returns>
        internal IList<FilingTransactionsModel> mapGetFlngTransExpReimbursementDataBLLResponse(String strTransNumber, String strFilerId, String strSchedID)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

            lstFilingTransactionsModel = objItemizedReportsDAL.mapGetFlngTransExpReimbursementDataDALResponse(strTransNumber, strFilerId, strSchedID);                       

            return lstFilingTransactionsModel;
        }

        /// <summary>
        /// mapGetReimbursementDetailsAmtBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetReimbursementDetailsAmtBLLResponse(String strTransNumber, String strFilerId, String strSchedID)
        {
            String strReimbursementDetailsAmt = String.Empty;

            strReimbursementDetailsAmt = objItemizedReportsDAL.mapGetReimbursementDetailsAmtDALResponse(strTransNumber, strFilerId, strSchedID);

            return strReimbursementDetailsAmt;
        }
        
        /// <summary>
        /// mapUpdateFilingTransExpReimbursmentDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateFilingTransExpReimbursmentDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {           
            Boolean result = objItemizedReportsDAL.mapUpdateFilingTransExpReimbursmentDataDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapDeleteFlngTransReimbursementDataSchedFBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModififedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteFlngTransReimbursementDataSchedFBLLResponse(String strTransNumber, String strModififedBy, String strFilerId)
        {
            Boolean results = objItemizedReportsDAL.mapDeleteFlngTransReimbursementDataSchedFDALResponse(strTransNumber, strModififedBy, strFilerId);

            return results;
        }

        /// <summary>
        /// mapAddFilingTransNonCompaignHKExpensesDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal String mapAddFilingTransNonCompaignHKExpensesDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            String results = objItemizedReportsDAL.mapAddFilingTransNonCompaignHKExpensesDataDALResponse(objFilingTransactionsModel);

            return results;
        }

        /// <summary>
        /// mapGetNCHKExpensesReimbursementDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> mapGetNCHKExpensesReimbursementDataBLLResponse(String strFilingTransId)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();           

            lstFilingTransactionsModel = objItemizedReportsDAL.mapGetNCHKExpensesReimbursementDataDALResponse(strFilingTransId);
                        
            return lstFilingTransactionsModel;
        }

        /// <summary>
        /// mapUpdateNonCompaignHKExpensesSchedQDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateNonCompaignHKExpensesSchedQDataBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {           
            Boolean results = objItemizedReportsDAL.mapUpdateNonCompaignHKExpensesSchedQDataDALResponse(objFilingTransactionsModel);

            return results;
        }

        internal IList<GetSearchForScheduledIModel> ValidateForUpdateScheJBLL(string filing_Trans_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsDAL.ValidateForUpdateScheJDAL(filing_Trans_ID);
            return lstGetSearchForScheduledI;
        }

        internal Boolean UpdateLoanRepaymentDataBLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.UpdateLoanRepaymentDataDAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Delete Loan Received Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        internal Boolean DeleteLoanReceivedBLL(String transNumber, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsDAL.DeleteLoanReceivedDAL(transNumber, strFilerID);
            return returnValue;
        }


        /// <summary>
        /// Delete Loan Repayment Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        internal Boolean DeleteLoanRepaymentBLL(String loan_Lib_Number, String transNumber, String modify_By, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsDAL.DeleteLoanRepaymentDAL(loan_Lib_Number, transNumber, modify_By, strFilerID);
            return returnValue;
        }

        internal IList<FilingTransactionDataModel> GetFilingTransactionsForScheduledIJNBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.GetFilingTransactionsForScheduledIJNDAL(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }

        /// <summary>
        /// Update Outstanding Loans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean UpdateOutStandingLoansDataBLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            var returnValue = objItemizedReportsDAL.UpdateOutStandingLoansDataDAL(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// Check Scheduled for Outstanding Loans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> CheckOutstandingScheduledBLL(String strFilingTransId)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsEntity = new List<FilingTransactionsModel>();

            lstFilingTransactionsEntity  = objItemizedReportsDAL.CheckOutstandingScheduledDAL(strFilingTransId);            

            return lstFilingTransactionsEntity;
        }

        /// <summary>
        /// Validate Loan Received Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        internal IList<GetSearchForScheduledIModel> ValidateSchedI_UpdateAmountBLL(string trans_Number, string FilerID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();

            lstGetSearchForScheduledI = objItemizedReportsDAL.ValidateSchedI_UpdateAmountDAL(trans_Number, FilerID);

            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// mapGetExpLiabilityOwedAmtBLLResponse
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        internal String mapGetExpLiabilityOwedAmtBLLResponse(String strFlngEntityId, String filerID)
        {
            String strExpLiabilityOwedAmt = String.Empty;

            strExpLiabilityOwedAmt = objItemizedReportsDAL.mapGetExpLiabilityOwedAmtDALResponse(strFlngEntityId, filerID);

            return strExpLiabilityOwedAmt;
        }

        /// <summary>
        /// mapGetExpSubContrTotAmtBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetExpSubContrTotAmtBLLResponse(String strTransNumber, String strFilerId)
        {
            String strExpSubContrTotAmt = String.Empty;

            strExpSubContrTotAmt = objItemizedReportsDAL.mapGetExpSubContrTotAmtDALResponse(strTransNumber, strFilerId);

            return strExpSubContrTotAmt;
        }

        internal String mapGetOutstandingLiabilityAmountBLLResponse(String strFilingEntityId, String strFlngTransId)
        {
            String strOutstandingLiablityAmount = String.Empty;

            strOutstandingLiablityAmount = objItemizedReportsDAL.mapGetOutstandingLiabilityAmountDALResponse(strFilingEntityId, strFlngTransId);

            return strOutstandingLiablityAmount;
        }

        /// <summary>
        /// GetExpPayTotalLiabAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        internal String mapGetExpPayTotalLiabAmountBLLResponse(String strTransNumber, String filerID)
        {
            String strExpPayTotalLiabAmount = String.Empty;

            strExpPayTotalLiabAmount = objItemizedReportsDAL.mapGetExpPayTotalLiabAmountDALResponse(strTransNumber, filerID);

            return strExpPayTotalLiabAmount;
        }

        /// <summary>
        /// mapGetContributorTypesSchedCBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorNameModel> mapGetContributorTypesSchedCBLLResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsDAL.mapGetContributorTypesSchedCDALResponse();            

            return lstContributorNameModel;
        }


        /// <summary>
        /// Loan Forgiven BLL layer
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddFilingTransaction_LoanForgiven_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string returnValue = objItemizedReportsDAL.AddFilingTransaction_LoanForgiven_DAL(objFilingTransactionsModel);
            return returnValue;
        }

        /// <summary>
        /// Delete Loan Forgiven 
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        internal Boolean DeleteLoanForgivenBLL(String loan_Lib_Number, String transNumber, String modify_By, String strLiability, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsDAL.DeleteLoanForgivenDAL(loan_Lib_Number, transNumber, modify_By, strLiability, strFilerID);
            return returnValue;
        }

        /// <summary>
        /// mapGetPurposeCodeReimburDetailsDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeReimburDetailsDataBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetPurposeCodeReimburDetailsDataDALResponse();

            return lstPurposeCodeModel;
        }

        /// <summary>
        /// mapGetPurposeCodeSubcontractorSchedFBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeSubcontractorSchedFBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetPurposeCodeSubcontractorSchedFDALResponse();

            return lstPurposeCodeModel;
        }

        /// <summary>
        /// mapGetPurposeCodeCreditCardItemSchedFBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeCreditCardItemSchedFBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetPurposeCodeCreditCardItemSchedFDALResponse();

            return lstPurposeCodeModel;
        }

        /// <summary>
        /// mapGetExpPayTransIdPopUpSchedFBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentTransIdPopUpSchedFModel> mapGetExpPayTransIdPopUpSchedFBLLResponse(String strTransNumber, String filerID)
        {
            IList<ExpPaymentTransIdPopUpSchedFModel> lstExpPaymentTransIdPopUpSchedFModel = new List<ExpPaymentTransIdPopUpSchedFModel>();            

            lstExpPaymentTransIdPopUpSchedFModel = objItemizedReportsDAL.mapGetExpPayTransIdPopUpSchedFDALResponse(strTransNumber, filerID);

            return lstExpPaymentTransIdPopUpSchedFModel;
        }

        /// <summary>
        /// Add Loan Received scheudled data BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean AddFilingTransaction_LoanForgiven_Liabiliites_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.AddFilingTransaction_LoanForgiven_Liabiliites_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapGetDateIncurredLiabUpdateDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetDateIncurredLiabUpdateDataBLLResponse(String strTransNumber, String strFilerId)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsDAL.mapGetDateIncurredLiabUpdateDataDALResponse(strTransNumber, strFilerId);
                        
            return lstDateIncurredModel;
        }

        internal string mapAddOtherReceivedReceiptsSchedEBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.mapAddOtherReceivedReceiptsSchedEDALResponse(objFilingTransactionsModel);

            return result;
        }

        // Update Other Receipts Received Transactions.
        /// <summary>
        /// UpdateOtherReceiptsReceivedSchedE
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean mapUpdateOtherReceiptsReceivedSchedEBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateOtherReceiptsReceivedSchedEDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// mapGetOriginalNameBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalNameModel> mapGetOriginalNameBLLResponse(String strFilerId)
        {
            IList<ExpPaymentOriginalNameModel> lstExpPaymentOriginalNameModel = new List<ExpPaymentOriginalNameModel>();

            lstExpPaymentOriginalNameModel = objItemizedReportsDAL.mapGetOriginalNameDALResponse(strFilerId);
         
            return lstExpPaymentOriginalNameModel;
        }

        /// <summary>
        /// mapGetOriginalAmountBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetOriginalAmountBLLResponse(String strFilingEntityId, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsDAL.mapGetOriginalAmountDALResponse(strFilingEntityId, strFilerId);
            
            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// mapGetOriginalExpeseDateBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalExpenseDateModel> mapGetOriginalExpeseDateBLLResponse(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentOriginalExpenseDateModel> lstExpPaymentOriginalExpenseDateModel = new List<ExpPaymentOriginalExpenseDateModel>();

            lstExpPaymentOriginalExpenseDateModel = objItemizedReportsDAL.mapGetOriginalExpeseDateDALResponse(strTransNumber, strFilerId);
                        
            return lstExpPaymentOriginalExpenseDateModel;
        }

        /// <summary>
        /// mapAddExpenditureRefundsSchedLBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddExpenditureRefundsSchedLBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.mapAddExpenditureRefundsSchedLDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapGetOutstaningAmtExpRefundedBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetOutstaningAmtExpRefundedBLLResponse(String strTransNumber, String strFilerId)
        {
            var results = objItemizedReportsDAL.mapGetOutstaningAmtExpRefundedDALResponse(strTransNumber, strFilerId);

            return results;
        }

        /// <summary>
        /// mapUpdateExpenditureRefundedSchedLBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateExpenditureRefundedSchedLBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateExpenditureRefundedSchedLDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// mapGetOriginalAmtRefundedSchedLBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetOriginalAmtRefundedSchedLBLLResponse(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsDAL.mapGetOriginalAmtRefundedSchedLDALResponse(strTransNumber, strFilerId);
                        
            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// mapGetContributorOriginalNameBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalNameModel> mapGetContributorOriginalNameBLLResponse(String strFilerId)
        {
            IList<ExpPaymentOriginalNameModel> lstExpPaymentOriginalNameModel = new List<ExpPaymentOriginalNameModel>();

            lstExpPaymentOriginalNameModel = objItemizedReportsDAL.mapGetContributorOriginalNameDALResponse(strFilerId);

            return lstExpPaymentOriginalNameModel;
        }

        /// <summary>
        /// mapContributorGetOriginalAmountBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapContributorGetOriginalAmountBLLResponse(String strFilingEntityId, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsDAL.mapGetContributorOriginalAmountDALResponse(strFilingEntityId, strFilerId);

            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// mapContributorGetOriginalContributionDateBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalExpenseDateModel> mapContributorGetOriginalContributionDateBLLResponse(String strFilingEntityId, String strOriginalAmt, String strFilerId)
        {
            IList<ExpPaymentOriginalExpenseDateModel> lstExpPaymentOriginalExpenseDateModel = new List<ExpPaymentOriginalExpenseDateModel>();

            lstExpPaymentOriginalExpenseDateModel = objItemizedReportsDAL.mapGetContributorOriginalContributionDateDALResponse(strFilingEntityId, strOriginalAmt, strFilerId);

            return lstExpPaymentOriginalExpenseDateModel;
        }

        /// <summary>
        /// mapGetOutstaningAmtContrRefundedBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapGetOutstaningAmtContrRefundedBLLResponse(String strTransNumber, String strFilerId)
        {
            var results = objItemizedReportsDAL.mapGetOutstaningAmtContrRefundedDALResponse(strTransNumber, strFilerId);

            return results;
        }

        /// <summary>
        /// mapGetOriginalAmtRefundedSchedMBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ExpPaymentOriginalAmountModel> mapGetOriginalAmtRefundedSchedMBLLResponse(String strTransNumber, String filerID)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsDAL.mapGetOriginalAmtRefundedSchedMDALResponse(strTransNumber, filerID);

            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// mapAddContributionsRefundedSchedLBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddContributionsRefundedSchedLBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.mapAddContributionsRefundedSchedMDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapUpdateContributionsRefundedSchedMBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateContributionsRefundedSchedMBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateContributionsRefundedSchedMDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// mapAddOutstandingLIabilitySchedNBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string mapAddOutstandingLIabilitySchedNBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.mapAddOutstandingLiabilitySchedNDALResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapUpdateOutstandingLiabilitySchedNBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateOutstandingLiabilitySchedNBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapUpdateOutstandingLiabilitySchedNDALResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// mapOutstandingLiabilityChildExistsBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String mapOutstandingLiabilityChildExistsBLLResponse(String strTransNumber, String filerID)
        {
            String strExists = String.Empty;

            strExists = objItemizedReportsDAL.mapOutstandingLiabilityChildExistsDALResponse(strTransNumber, filerID);

            return strExists;
        }

        /// <summary>
        /// mapDeleteOutstandingLiabilitySchedNBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteOutstandingLiabilitySchedNBLLResponse(String strTransNumber, String strFilingsId, String strModifiedBy)
        {
            Boolean returnValue = objItemizedReportsDAL.mapDeleteOutstandingLiabilitySchedNDALResponse(strTransNumber, strFilingsId, strModifiedBy);

            return returnValue;
        }

        /// <summary>
        /// mapGetEditTransactionDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetEditTransactionDataBLLResponse(String strTransNumber, String strFilerId)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetEditTransactionDataDALResponse(strTransNumber, strFilerId);

            return lstFilingTransactionDataModel;
        }


        /// <summary>
        /// GetOriginalAmountLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        internal IList<OriginalAmountModel> GetOutstandingAmountForForgivenBLL(String strFilingTransId)
        {
            IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

            lstOriginalAmountModel = objItemizedReportsDAL.GetOutstandingAmountForForgivenDAL(strFilingTransId);

            return lstOriginalAmountModel;
        }

        /// <summary>
        /// Get and Authenticate value from Temp CAPASFIDAS Database
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        internal IList<ValidateFilerInfoModel> GetAuthenticateFilerInfoBLL(String userID)
        {
            IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
            try
            {
                lstValidateFilerInfo = objItemizedReportsDAL.GetAuthenticateFilerInfoDAL(userID);
            }
            catch (Exception)
            {

                throw;
            }
            return lstValidateFilerInfo;
        }

        /// <summary>
        /// Add Amount Allocation Scheduled R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal string AddAmountAllocationSchedNBLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddAmountAllocationSchedNDAL(objFilingTransactionsModel);
            return result;
        }

        /// <summary>
        /// Update Amount Allocation Sched R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        internal Boolean UpdateAmountAllocationSchedNBLL(FilingTransactionsModel objFilingTransactionsModel)
        {            
            var result = objItemizedReportsDAL.UpdateAmountAllocationSchedNDAL(objFilingTransactionsModel);
            return result;
        }

        /// <summary>
        /// Get All Amount for Amount Allocation Sched R
        /// </summary>
        /// <param name="filing_Ent_ID"></param>
        /// <param name="elect_Year"></param>
        /// <param name="municipalityID"></param>
        /// <param name="officeID"></param>
        /// <param name="distID"></param>
        /// <returns></returns>
        internal String GetAllAmountBLL(String filing_Ent_ID, String elect_Year, String municipalityID, String officeID, String distID, String filerID)
        {
            String results = objItemizedReportsDAL.GetAllAmountDAL(filing_Ent_ID, elect_Year, municipalityID, officeID, distID, filerID);
            return results;
        }

        internal IList<DistrictModel> GetDistrictsForOfficeBLL(String strOfficeID)
        {
            IList<DistrictModel> listGetDistrictsEntity = new List<DistrictModel>();
            listGetDistrictsEntity = objItemizedReportsDAL.GetDistrictsForOfficeDAL(strOfficeID);            
            return listGetDistrictsEntity;
        }

        internal IList<OfficeModel> GetOfficesBLL(String strMunicipalityID)
        {
            IList<OfficeModel> listGetOfficeEntity = new List<OfficeModel>();
            listGetOfficeEntity = objItemizedReportsDAL.GetOfficesDAL(strMunicipalityID);            
            return listGetOfficeEntity;
        }

        /// <summary>
        /// Auto Complete of Sched R
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal IList<AutoCompleteSchedRModel> GetAutoCompleteSchedRBLL(String name, String strFilerId)
        {
            IList<AutoCompleteSchedRModel> lstAutoCompleteSchedREntity = new List<AutoCompleteSchedRModel>();
            lstAutoCompleteSchedREntity = objItemizedReportsDAL.GetAutoCompleteSchedRDAL(name, strFilerId);  
            return lstAutoCompleteSchedREntity;
        }

        #region mapGetOriginalLiabilityDataBLLResponse GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// mapGetOriginalLiabilityDataBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetOriginalLiabilityDataBLLResponse(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();            

            lstLiabilityDetailsModel = objItemizedReportsDAL.mapGetOriginalLiabilityDataDALResponse(strTransNumber, filerID);            

            return lstLiabilityDetailsModel;
        }
        #endregion mapGetOriginalLiabilityDataBLLResponse GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region mapGetExpenditurePaymentLiabilityDataBLLResponse GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.
        /// <summary>
        /// mapGetExpenditurePaymentLiabilityDataBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetExpenditurePaymentLiabilityDataBLLResponse(String strTransNumber, String filerID, String strSchedID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsDAL.mapGetExpenditurePaymentLiabilityDataDALResponse(strTransNumber, filerID, strSchedID);

            return lstLiabilityDetailsModel;                        
        }
        #endregion mapGetExpenditurePaymentLiabilityDataBLLResponse GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.

        #region mapGetOutstandingLiabilityDataBLLResponse GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// mapGetOutstandingLiabilityDataBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetOutstandingLiabilityDataBLLResponse(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsDAL.mapGetOutstandingLiabilityDataDALResponse(strTransNumber, filerID);

            return lstLiabilityDetailsModel;
        }
        #endregion mapGetOutstandingLiabilityDataBLLResponse GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.

        #region mapGetLiabilityForgivenDataBLLResponse GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.
        /// <summary>
        /// mapGetLiabilityForgivenDataBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<LiabilityDetailsModel> mapGetLiabilityForgivenDataBLLResponse(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsDAL.mapGetLiabilityForgivenDataDALResponse(strTransNumber, filerID);

            return lstLiabilityDetailsModel;
        }
        #endregion mapGetLiabilityForgivenDataBLLResponse GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>>> START START START >>>>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================

        #region mapGetInLieuOfStatementDataBLLResponse
        /// <summary>
        /// mapGetInLieuOfStatementDataBLLResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<InLieuOfStatementNonItemModel> mapGetInLieuOfStatementDataBLLResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

            lstInLieuOfStatementNonItemModel = objItemizedReportsDAL.mapGetInLieuOfStatementDataDALResponse(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

            return lstInLieuOfStatementNonItemModel;
        }
        #endregion mapGetInLieuOfStatementDataBLLResponse

        #region mapAddInLieuOfStatementBLLResponse
        /// <summary>
        /// mapAddInLieuOfStatementBLLResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        internal Boolean mapAddInLieuOfStatementBLLResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {                 
            Boolean results = objItemizedReportsDAL.mapAddInLieuOfStatementDALResponse(objAddInLieuOfStatementModel);

            return results;
        }
        #endregion mapAddInLieuOfStatementBLLResponse

        #region mapDeleteInLieuOfStatementBLLResponse
        /// <summary>
        /// mapDeleteInLieuOfStatementBLLResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteInLieuOfStatementBLLResponse(String strFilingsId, String strModifiedBy)
        {
            Boolean results = objItemizedReportsDAL.mapDeleteInLieuOfStatementDALResponse(strFilingsId, strModifiedBy);

            return results;
        }
        #endregion mapDeleteInLieuOfStatementBLLResponse

        #region mapGetPersonNameAndTreasurerDataBLLResponse
        /// <summary>
        /// mapGetPersonNameAndTreasurerDataBLLResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        internal IList<PersonNameAndTreasurerDataModel> mapGetPersonNameAndTreasurerDataBLLResponse(String strPersonId)
        {
            IList<PersonNameAndTreasurerDataModel> lstPersonNameAndTreasurerDataModel = new List<PersonNameAndTreasurerDataModel>();

            lstPersonNameAndTreasurerDataModel = objItemizedReportsDAL.mapGetPersonNameAndTreasurerDataDALResponse(strPersonId);

            return lstPersonNameAndTreasurerDataModel;
        }
        #endregion mapGetPersonNameAndTreasurerDataBLLResponse

        #region mapGetNoActivityReporttDataBLLResponse
        /// <summary>
        /// mapGetNoActivityReporttDataBLLResponse
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<InLieuOfStatementNonItemModel> mapGetNoActivityReporttDataBLLResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

            lstInLieuOfStatementNonItemModel = objItemizedReportsDAL.mapGetNoActivityReporttDataDALResponse(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);
            
            return lstInLieuOfStatementNonItemModel;
        }
        #endregion mapGetNoActivityReporttDataBLLResponse

        #region mapAddNoActivityReportBLLResponse
        /// <summary>
        /// mapAddNoActivityReportBLLResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNoActivityReportBLLResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {                    
            Boolean results = objItemizedReportsDAL.mapAddNoActivityReportDALResponse(objAddInLieuOfStatementModel);

            return results;
        }
        #endregion mapAddNoActivityReportBLLResponse

        #region mapGetItemizedTransSubmittedBLLResponse
        /// <summary>
        /// mapGetItemizedTransSubmittedBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal Boolean mapGetItemizedTransSubmittedBLLResponse(String strFilerId, String strElectionYearId, String strOfficeTypeId,
            String strFilingTypeId, String strFilingCatId, String strElectTypeID)
        {
            Boolean strSubmitted;

            strSubmitted = objItemizedReportsDAL.mapGetItemizedTransSubmittedDALResponse(strFilerId, strElectionYearId,
                strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectTypeID);

            return strSubmitted;
        }
        #endregion mapGetItemizedTransSubmittedBLLResponse

        #region mapAddNoticeOfNonParticipationBLLResponse
        /// <summary>
        /// mapAddNoticeOfNonParticipationBLLResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNoticeOfNonParticipationBLLResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            Boolean results = objItemizedReportsDAL.mapAddNoticeOfNonParticipationDALResponse(objAddInLieuOfStatementModel);

            return results;
        }
        #endregion mapAddNoticeOfNonParticipationBLLResponse

        #region mapGetNoticeOfNonParticipationtDataBLLResponse
        /// <summary>
        /// mapGetNoticeOfNonParticipationtDataBLLResponse
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        internal IList<InLieuOfStatementNonItemModel> mapGetNoticeOfNonParticipationtDataBLLResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strCountyId, String strMunicipalityId)
        {
            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

            lstInLieuOfStatementNonItemModel = objItemizedReportsDAL.mapGetNoticeOfNonParticipationtDataDALResponse(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strCountyId, strMunicipalityId);

            return lstInLieuOfStatementNonItemModel;
        }
        #endregion mapGetNoticeOfNonParticipationtDataBLLResponse

        #region mapGetTransactionTypes24HNoticeDataBLLResponse
        /// <summary>
        /// mapGetTransactionTypes24HNoticeDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetTransactionTypes24HNoticeDataBLLResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsDAL.mapGetTransactionTypes24HNoticeDataDALResponse();

            return lstTransactionTypesModel;
        }
        #endregion mapGetTransactionTypes24HNoticeDataBLLResponse

        #region mapGetFilingTrans24HourNoticeDataBLLResponse
        /// <summary>
        /// mapGetFilingTrans24HourNoticeDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTrans24HourNoticeDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTrans24HourNoticeDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTrans24HourNoticeDataBLLResponse

        #region mapGetFilingTrans24HourNoticeHistoryDataBLLResponse
        /// <summary>
        /// mapGetFilingTrans24HourNoticeHistoryDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTrans24HourNoticeHistoryDataBLLResponse(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTrans24HourNoticeHistoryDataDALResponse(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTrans24HourNoticeHistoryDataBLLResponse

        #region mapAddNonItem24HourNoticeFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItem24HourNoticeFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItem24HourNoticeFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItem24HourNoticeFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapAddNonItem24HourNoticeFlngTransBLLResponse

        #region mapUpdate24HNoticeFlngTransBLLResponse
        /// <summary>
        /// mapUpdate24HNoticeFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdate24HNoticeFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            Boolean returnValue = objItemizedReportsDAL.mapUpdate24HNoticeFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapUpdate24HNoticeFlngTransBLLResponse

        #region mapSubmit24HNoticeFlngTransBLLResponse
        /// <summary>
        /// mapSubmit24HNoticeFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapSubmit24HNoticeFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            Boolean returnValue = objItemizedReportsDAL.mapSubmit24HNoticeFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapSubmit24HNoticeFlngTransBLLResponse

        #region mapDelete24HNoticeFlngTransBLLResponse
        /// <summary>
        /// mapDelete24HNoticeFlngTransBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDelete24HNoticeFlngTransBLLResponse(String strTransNumber, String strModifiedBy, String filerID)
        {
            Boolean returnValue = objItemizedReportsDAL.mapDelete24HNoticeFlngTransDALResponse(strTransNumber, strModifiedBy, filerID);

            return returnValue;
        }
        #endregion mapDelete24HNoticeFlngTransBLLResponse

        #region mapGetNonItemChildTransExistsBLLResponse
        /// <summary>
        /// mapGetNonItemChildTransExistsBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal Boolean mapGetNonItemChildTransExistsBLLResponse(String strTransNumber, String filerID)
        {
            Boolean strChildTransExists = objItemizedReportsDAL.mapGetNonItemChildTransExistsDALResponse(strTransNumber, filerID);

            return strChildTransExists;
        }
        #endregion mapGetNonItemChildTransExistsBLLResponse

        #region mapGetNonItemParentTransExistsBLLResponse
        /// <summary>
        /// mapGetNonItemParentTransExistsBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal Boolean mapGetNonItemParentTransExistsBLLResponse(String strTransNumber, String filerID)
        {
            Boolean strChildTransExists = objItemizedReportsDAL.mapGetNonItemParentTransExistsDALResponse(strTransNumber, filerID);

            return strChildTransExists;
        }
        #endregion mapGetNonItemParentTransExistsBLLResponse

        #region mapGetCommEdit24HourNoticeTransDataBLLResponse
        /// <summary>
        /// /mapGetCommEdit24HourNoticeTransDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetCommEdit24HourNoticeTransDataBLLResponse(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetCommEdit24HourNoticeTransDataDALResponse(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetCommEdit24HourNoticeTransDataBLLResponse

        #region mapGetFilingTransIEWeeklyContributioneDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyContributioneDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyContributioneDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIEWeeklyContributioneDataDALResponse(objFilingTransDataModel);           

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIEWeeklyContributioneDataBLLResponse

        #region mapGetIEWeeklyContrbutionTreasurerDataBLLResponse
        /// <summary>
        /// mapGetIEWeeklyContrbutionTreasurerDataBLLResponse
        /// </summary>
        /// <param name="strTreasurerId"></param>
        /// <returns></returns>
        internal IList<NonItemIETreasurerModel> mapGetIEWeeklyContrbutionTreasurerDataBLLResponse(String strTreasurerId)
        {
            IList<NonItemIETreasurerModel> lstNonItemIETreasurerModel = new List<NonItemIETreasurerModel>();
            
            lstNonItemIETreasurerModel = objItemizedReportsDAL.mapGetIEWeeklyContrbutionTreasurerDataDALResponse(strTreasurerId);
                        
            return lstNonItemIETreasurerModel;
        }
        #endregion mapGetIEWeeklyContrbutionTreasurerDataBLLResponse

        #region mapAddNonItemIEWeeklyContrFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyContrFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyContrFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            Boolean results = objItemizedReportsDAL.mapAddNonItemIEWeeklyContrFlngTransDALResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion mapAddNonItemIEWeeklyContrFlngTransBLLResponse

        #region mapUpdateIEWeeklyContrFlngTransBLLResponse
        /// <summary>
        /// mapUpdateIEWeeklyContrFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIEWeeklyContrFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                    
            Boolean results = objItemizedReportsDAL.mapUpdateIEWeeklyContrFlngTransDALResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion mapUpdateIEWeeklyContrFlngTransBLLResponse

        #region mapSubmitIEWeeklyContrFlngTransBLLResponse
        /// <summary>
        /// mapSubmitIEWeeklyContrFlngTransBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapSubmitIEWeeklyContrFlngTransBLLResponse(String strTransNumber, String strModifiedBy)
        {
            Boolean results = objItemizedReportsDAL.mapSubmitIEWeeklyContrFlngTransDALResponse(strTransNumber, strModifiedBy);

            return results;
        }
        #endregion mapSubmitIEWeeklyContrFlngTransBLLResponse

        #region mapGetFilingTransIETransHistoryDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIETransHistoryDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIETransHistoryDataBLLResponse(String strFilingTransId)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIETransHistoryDataDALResponse(strFilingTransId);            

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIETransHistoryDataBLLResponse

        #region mapGetItemizedNonItemIETransactionsBLLResponse
        /// <summary>
        /// mapGetItemizedNonItemIETransactionsBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetItemizedNonItemIETransactionsBLLResponse(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strFilingDate)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetItemizedNonItemIETransactionsDALResponse(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId,strMunicipalityId, strFilingDate); 

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetItemizedNonItemIETransactionsBLLResponse

        #region mapAddItemizedIETransactionsDataBLLResponse
        /// <summary>
        /// mapAddItemizedIETransactionsDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <param name="strCreatedBy"></param>
        /// <returns></returns>
        internal Boolean mapAddItemizedIETransactionsDataBLLResponse(IEnumerable<String> strTransNumber, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            Boolean results = objItemizedReportsDAL.mapAddItemizedIETransactionsDataDALResponse(strTransNumber, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

            return results;
        }
        #endregion mapAddItemizedIETransactionsDataBLLResponse

        #region mapGetContributorCodeIEWeeklyContrSchedCBLLResponse
        /// <summary>
        /// mapGetContributorCodeIEWeeklyContrSchedCBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorNameModel> mapGetContributorCodeIEWeeklyContrSchedCBLLResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsDAL.mapGetContributorCodeIEWeeklyContrSchedCDALResponse();
                        
            return lstContributorNameModel;
        }
        #endregion mapGetContributorCodeIEWeeklyContrSchedCBLLResponse

        #region mapGetContributorCodeIEWeeklyContrSchedDBLLRespnse
        /// <summary>
        /// mapGetContributorCodeIEWeeklyContrSchedDBLLRespnse
        /// </summary>
        /// <returns></returns>
        internal IList<ContributorNameModel> mapGetContributorCodeIEWeeklyContrSchedDBLLRespnse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();           

            lstContributorNameModel = objItemizedReportsDAL.mapGetContributorCodeIEWeeklyContrSchedDDALRespnse();
                        
            return lstContributorNameModel;
        }
        #endregion mapGetContributorCodeIEWeeklyContrSchedDBLLRespnse

        #region mapGetFilingTransIE24HContributioneDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIE24HContributioneDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HContributioneDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();           

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIE24HContributioneDataDALResponse(objFilingTransDataModel);           

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIE24HContributioneDataBLLResponse

        #region mapGetFilingTransIE24HContributionHistoryDataDALResponse
        /// <summary>
        /// /mapGetFilingTransIE24HContributionHistoryDataDALResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HContributionHistoryDataBLLResponse(String strTransNumber)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIE24HContributionHistoryDataDALResponse(strTransNumber);           

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIE24HContributionHistoryDataDALResponse

        #region mapGetIE24HContrTransactionTypesDALResponse
        /// <summary>
        /// mapGetIE24HContrTransactionTypesDALResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetIE24HContrTransactionTypesBLLResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();            

            lstTransactionTypesModel = objItemizedReportsDAL.mapGetIE24HContrTransactionTypesDALResponse();
            
            return lstTransactionTypesModel;
        }
        #endregion mapGetIE24HContrTransactionTypesDALResponse

        #region mapAddNonItemIE24HContrFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIE24HContrFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIE24HContrFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsDAL.mapAddNonItemIE24HContrFlngTransDALResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion mapAddNonItemIE24HContrFlngTransBLLResponse

        #region mapUpdateIE24HContrFlngTransBLLResponse
        /// <summary>
        /// mapUpdateIE24HContrFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIE24HContrFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsDAL.mapUpdateIE24HContrFlngTransDALResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion mapUpdateIE24HContrFlngTransBLLResponse

        #region mapSubmitIE24ContrFlngTransBLLResponse
        /// <summary>
        /// mapSubmitIE24ContrFlngTransBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapSubmitIE24ContrFlngTransBLLResponse(String strTransNumber, String strModifiedBy)
        {
            Boolean results = objItemizedReportsDAL.mapSubmitIE24HContrFlngTransDALResponse(strTransNumber, strModifiedBy);

            return results;
        }
        #endregion mapSubmitIE24ContrFlngTransBLLResponse

        #region mapGetIEWeeklyExpTransactionTypesBLLResponse
        /// <summary>
        /// mapGetIEWeeklyExpTransactionTypesBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetIEWeeklyExpTransactionTypesBLLResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsDAL.mapGetIEWeeklyExpTransactionTypesDALResponse();

            return lstTransactionTypesModel;
        }
        #endregion mapGetIEWeeklyExpTransactionTypesBLLResponse

        #region mapGetFilingTransIEWeeklyExpenditureDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyExpenditureDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyExpenditureDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIEWeeklyExpenditureDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIEWeeklyExpenditureDataBLLResponse

        #region mapGetFilingTransIEWeeklyExpenditureHistoryDataBLLResponse
        /// <summary>
        /// /mapGetFilingTransIEWeeklyExpenditureHistoryDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyExpenditureHistoryDataBLLResponse(String strTransNumber)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIEWeeklyExpenditureHistoryDataDALResponse(strTransNumber);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIEWeeklyExpenditureHistoryDataBLLResponse

        #region mapAddNonItemIEWeeklyExpFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyExpFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyExpFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                    
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemIEWeeklyExpFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapAddNonItemIEWeeklyExpFlngTransBLLResponse

        #region mapUpdateIEWeeklyExpenditureFlngTransBLLResponse
        /// <summary>
        /// mapUpdateIEWeeklyExpenditureFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIEWeeklyExpenditureFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            Boolean returnValue = objItemizedReportsDAL.mapUpdateIEWeeklyExpenditureFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapUpdateIEWeeklyExpenditureFlngTransBLLResponse

        #region mapGetNonItemIEDateIncrdLiabUpdateDataBLLResponse
        /// <summary>
        /// mapGetNonItemIEDateIncrdLiabUpdateDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<DateIncurredModel> mapGetNonItemIEDateIncrdLiabUpdateDataBLLResponse(String strTransNumber)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsDAL.mapGetNonItemIEDateIncrdLiabUpdateDataDALResponse(strTransNumber);
           
            return lstDateIncurredModel;
        }
        #endregion mapGetNonItemIEDateIncrdLiabUpdateDataBLLResponse

        #region mapGetNonItemIEPurposeCodesBLLResponse
        /// <summary>
        /// mapGetNonItemIEPurposeCodesBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetNonItemIEPurposeCodesBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();            

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetNonItemIEPurposeCodesDALResponse();

            return lstPurposeCodeModel;
        }
        #endregion mapGetNonItemIEPurposeCodesBLLResponse

        #region mapGetNonItemIEPurposeCodesSubContrBLLResponse
        /// <summary>
        /// mapGetNonItemIEPurposeCodesSubContrBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetNonItemIEPurposeCodesSubContrBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();            

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetNonItemIEPurposeCodesSubContrDALResponse();

            return lstPurposeCodeModel;
        }
        #endregion mapGetNonItemIEPurposeCodesSubContrBLLResponse

        #region mapGetFilingTransIE24HourExpenditureDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIE24HourExpenditureDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HourExpenditureDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIE24HourExpenditureDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIE24HourExpenditureDataBLLResponse

        #region mapGetFilingTransIE24HourPIDAExpenditureDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIE24HourPIDAExpenditureDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIE24HourPIDAExpenditureDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIE24HourPIDAExpenditureDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIE24HourPIDAExpenditureDataBLLResponse

        #region mapAddNonItemIE24HourExpFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIE24HourExpFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIE24HourExpFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemIE24HourExpFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapAddNonItemIE24HourExpFlngTransBLLResponse

        #region mapAddNonItemIE24HourPIDAExpFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIE24HourPIDAExpFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIE24HourPIDAExpFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemIE24HourPIDAExpFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapAddNonItemIE24HourPIDAExpFlngTransBLLResponse

        #region mapGetFilingTransIEWeeklyPIDAExpenditureDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyPIDAExpenditureDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyPIDAExpenditureDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIEWeeklyPIDAExpenditureDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIEWeeklyPIDAExpenditureDataBLLResponse

        #region mapAddNonItemIEWeeklyPIDAExpFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyPIDAExpFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyPIDAExpFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemIEWeeklyPIDAExpFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapAddNonItemIEWeeklyPIDAExpFlngTransBLLResponse

        #region mapGetIEWeeklyLiabInccrTransactionTypesBLLResponse
        /// <summary>
        /// mapGetIEWeeklyLiabInccrTransactionTypesBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> mapGetIEWeeklyLiabInccrTransactionTypesBLLResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsDAL.mapGetIEWeeklyLiabInccrTransactionTypesDALResponse();

            return lstTransactionTypesModel;
        }
        #endregion mapGetIEWeeklyLiabInccrTransactionTypesBLLResponse

        #region mapGetNonItemIESchedNPurposeCodesBLLResponse
        /// <summary>
        /// mapGetNonItemIESchedNPurposeCodesBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetNonItemIESchedNPurposeCodesBLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetNonItemIESchedNPurposeCodesDALResponse();

            return lstPurposeCodeModel;
        }
        #endregion mapGetNonItemIESchedNPurposeCodesBLLResponse

        #region mapGetFilingTransIEWeeklyLiabIncrDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyLiabIncrDataBLLResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyLiabIncrDataBLLResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIEWeeklyLiabIncrDataDALResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIEWeeklyLiabIncrDataBLLResponse

        #region mapGetFilingTransIEWeeklyLiabIncrHistoryDataBLLResponse
        /// <summary>
        /// mapGetFilingTransIEWeeklyLiabIncrHistoryDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetFilingTransIEWeeklyLiabIncrHistoryDataBLLResponse(String strTransNumber)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetFilingTransIEWeeklyLiabIncrHistoryDataDALResponse(strTransNumber);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetFilingTransIEWeeklyLiabIncrHistoryDataBLLResponse

        #region mapAddNonItemIEWeeklyLiabIncrFlngTransBLLResponse
        /// <summary>
        /// mapAddNonItemIEWeeklyLiabIncrFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemIEWeeklyLiabIncrFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemIEWeeklyLiabIncrFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapAddNonItemIEWeeklyLiabIncrFlngTransBLLResponse

        #region mapUpdateIEWeeklyLiabIncrFlngTransBLLResponse
        /// <summary>
        /// mapUpdateIEWeeklyLiabIncrFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean mapUpdateIEWeeklyLiabIncrFlngTransBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            Boolean returnValue = objItemizedReportsDAL.mapUpdateIEWeeklyLiabIncrFlngTransDALResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapUpdateIEWeeklyLiabIncrFlngTransBLLResponse

        #region mapGetFilingMethodDataBLLResponse
        /// <summary>
        /// mapGetFilingMethodDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<FilingMthodModel> mapGetFilingMethodDataBLLResponse()
        {
            IList<FilingMthodModel> lstFilingMthodModel = new List<FilingMthodModel>();

            lstFilingMthodModel = objItemizedReportsDAL.mapGetFilingMethodDataDALResponse();
            
            return lstFilingMthodModel;
        }
        #endregion mapGetFilingMethodDataBLLResponse

        #region mapGetCampaignMaterialDataBLLResponse
        /// <summary>
        /// mapGetCampaignMaterialDataBLLResponse
        /// </summary>
        /// <param name="objNonItemCampaignMaterialModel"></param>
        /// <returns></returns>
        internal IList<NonItemCampaignMaterialDataModel> mapGetCampaignMaterialDataBLLResponse(NonItemCampaignMaterialModel objNonItemCampaignMaterialModel)
        {
            IList<NonItemCampaignMaterialDataModel> lstNonItemCampaignMaterialDataModel = new List<NonItemCampaignMaterialDataModel>();
           
            lstNonItemCampaignMaterialDataModel = objItemizedReportsDAL.mapGetCampaignMaterialDataDALResponse(objNonItemCampaignMaterialModel);                   

            return lstNonItemCampaignMaterialDataModel;
        }
        #endregion mapGetCampaignMaterialDataBLLResponse

        #region mapAddNonItemCampaignMaterialBLLResponse
        /// <summary>
        /// mapAddNonItemCampaignMaterialBLLResponse
        /// </summary>
        /// <param name="objNonItemCampaignMaterialModel"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemCampaignMaterialBLLResponse(NonItemCampaignMaterialModel objNonItemCampaignMaterialModel)
        {         
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemCampaignMaterialDALResponse(objNonItemCampaignMaterialModel);

            return returnValue;
        }
        #endregion mapAddNonItemCampaignMaterialBLLResponse

        #region mapDeleteCampaignMaterialBLLResponse
        /// <summary>
        /// mapDeleteCampaignMaterialBLLResponse
        /// </summary>
        /// <param name="strCampMatrId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapDeleteCampaignMaterialBLLResponse(String strCampMatrId, String strModifiedBy)
        {
            Boolean returnValue = objItemizedReportsDAL.mapDeleteCampaignMaterialDALResponse(strCampMatrId, strModifiedBy);

            return returnValue;
        }
        #endregion mapDeleteCampaignMaterialBLLResponse

        //=======CABITNET CODE==================CABINET CODE========================

        #region mapGetTokenIdBLLResponse
        /// <summary>
        /// mapGetTokenIdBLLResponse
        /// </summary>
        /// <param name="objCampMatrDocumentIdModel"></param>
        /// <returns></returns>
        internal CabinetReturnValModel mapGetTokenIdBLLResponse(CampMatrDocumentIdModel objCampMatrDocumentIdModel)
        {
            CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();

            objCabinetReturnValModel = objItemizedReportsDAL.mapGetTokenIdDALResponse(objCampMatrDocumentIdModel);
                        
            return objCabinetReturnValModel;
        }
        #endregion mapGetTokenIdBLLResponse

        #region GetTokenIDBLL
        /// <summary>
        /// GetTokenIDBLL
        /// </summary>
        /// <param name="strFileType"></param>
        /// <returns></returns>
        internal CabinetReturnValModel GetTokenIDBLL(String strFileType, String strPageName)
        {
            CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
            objCabinetReturnValModel = objItemizedReportsDAL.GetTokenIDDAL(strFileType, strPageName);
            return objCabinetReturnValModel;
        }
        #endregion GetTokenIDBLL

        #region DocumentDownloadBLL
        /// <summary>
        /// DocumentDownloadBLL
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="CabinetID"></param>
        /// <param name="DocumentID"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal CabinetDownloadObjectModel DocumentDownloadBLL(string Token, int CabinetID, int DocumentID, string fileName)
        {
            CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();
            objCabinetDownloadObjectModel = objItemizedReportsDAL.DocumentDownloadDAL(Token, CabinetID, DocumentID, fileName);
            return objCabinetDownloadObjectModel;
        }
        #endregion DocumentDownloadBLL

        //=======CABITNET CODE==================CABINET CODE========================

        //=======NETWORK DRIVE CODE==================NETWORK DRIVE CODE========================

        #region mapUploadFileInNetworkDriveBLLResponse
        /// <summary>
        /// mapUploadFileInNetworkDriveBLLResponse
        /// </summary>
        /// <param name="objUploadFileNTDriveModel"></param>
        /// <returns></returns>
        internal Boolean mapUploadFileInNetworkDriveBLLResponse(UploadFileNTDriveModel objUploadFileNTDriveModel)
        {           
            Boolean returnValue = objItemizedReportsDAL.mapUploadFileInNetworkDriveDALResponse(objUploadFileNTDriveModel);

            return returnValue;
        }
        #endregion mapUploadFileInNetworkDriveBLLResponse

        #region mapDownloadFileInNetworkDriveBLLResponse
        /// <summary>
        /// mapDownloadFileInNetworkDriveBLLResponse
        /// </summary>
        /// <param name="strFileFolderPath"></param>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        internal Byte[] mapDownloadFileInNetworkDriveBLLResponse(String strFileFolderPath, String strFileName)
        {
            Byte[] returnValue = objItemizedReportsDAL.mapDownloadFileInNetworkDriveDALResponse(strFileFolderPath, strFileName);

            return returnValue;
        }
        #endregion mapDownloadFileInNetworkDriveBLLResponse

        //=======NETWORK DRIVE CODE==================NETWORK DRIVE CODE========================

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>>> END END END >>>>>>>>>>>>>>>>>>>>>>>>>>>        
        //=========================================================================================================================================

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region mapGetDropdownValueExistsBLLResponse
        /// <summary>
        /// mapGetDropdownValueExistsBLLResponse
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strDropdownValue"></param>
        /// <returns></returns>
        internal Boolean mapGetDropdownValueExistsBLLResponse(String strTableName, String strDropdownValue)
        {
            Boolean returnValue = objItemizedReportsDAL.mapGetDropdownValueExistsDALResponse(strTableName, strDropdownValue);

            return returnValue;
        }
        #endregion mapGetDropdownValueExistsBLLResponse

        #region GetDropdownValueExistsValidation
        /// <summary>
        /// GetDropdownValueExistsValidation
        /// </summary>
        /// <returns></returns>
        internal IList<VendorImportValidationModel> GetDropdownValueExistsValidation()
        {
            IList<VendorImportValidationModel> lstVendorImportValidation = new List<VendorImportValidationModel>();

            lstVendorImportValidation = objItemizedReportsDAL.GetDropdownValueExistsValidation();                       

            return lstVendorImportValidation;
        }
        #endregion GetDropdownValueExistsValidation

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region mapGetFilingDateOffCycleDataBLLResponse
        /// <summary>
        /// mapGetFilingDateOffCycleDataBLLResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        internal IList<FilingDatesOffCycleModel> mapGetFilingDateOffCycleDataBLLResponse(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strDisclosureType)
        {
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();

            lstFilingDatesOffCycleModel = objItemizedReportsDAL.mapGetFilingDateOffCycleDataDALResponse(strElectionYearId, strOfficeTypeId, strFilerId, strDisclosureType);

            return lstFilingDatesOffCycleModel;
        }
        #endregion mapGetFilingDateOffCycleDataBLLResponse

        #region mapGetFilingDateIEWeeklyeDataBLLResponse
        /// <summary>
        /// mapGetFilingDateIEWeeklyeDataBLLResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strFilingType"></param>
        /// <param name="strFilingCatId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        internal IList<FilingDatesOffCycleModel> mapGetFilingDateIEWeeklyeDataBLLResponse(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strFilerId, String strFilingType, String strFilingCatId, String strElectionDateId, String strMunicipalityID)
        {
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();

            lstFilingDatesOffCycleModel = objItemizedReportsDAL.mapGetFilingDateIEWeeklyeDataDALResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId, strMunicipalityID);

            return lstFilingDatesOffCycleModel;
        }
        #endregion mapGetFilingDateIEWeeklyeDataBLLResponse

        #region mapGeResigTermTypeDataBLLResponse
        /// <summary>
        /// mapGeResigTermTypeDataBLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<ResigTermTypeModel> mapGeResigTermTypeDataBLLResponse()
        {
            IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
            
            lstResigTermTypeModel = objItemizedReportsDAL.mapGeResigTermTypeDataDALResponse();
                      
            return lstResigTermTypeModel;
        }
        #endregion mapGeResigTermTypeDataBLLResponse

        #region mapGetResgTermTypeExistsValueBLLResponse
        /// <summary>
        /// mapGetResgTermTypeExistsValueBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionYearId"></param>
        /// <returns></returns>
        internal IList<ResigTermTypeModel> mapGetResgTermTypeExistsValueBLLResponse(String strFilerId, String strElectionTypeId, String strOfficeTypeId, String strFilingTypeId, String strElectionYearId, String strElectionDateId, String strFilingDate, String strFilingCategoryId, String strMunicipalityId)
        {
            IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();

            lstResigTermTypeModel = objItemizedReportsDAL.mapGetResgTermTypeExistsValueDALResponse(strFilerId, strElectionTypeId, strOfficeTypeId, strFilingTypeId, strElectionYearId, strElectionDateId, strFilingDate, strFilingCategoryId, strMunicipalityId);

            return lstResigTermTypeModel;
        }
        #endregion mapGetResgTermTypeExistsValueDALResponse

        #region mapUpdateResgTermTypeFilingsBLLResponse
        /// <summary>
        /// mapUpdateResgTermTypeFilingsBLLResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strResgTermTypeId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean mapUpdateResgTermTypeFilingsBLLResponse(String strFilingsId, String strResgTermTypeId, String strModifiedBy)
        {
            Boolean results = objItemizedReportsDAL.mapUpdateResgTermTypeFilingsDALResponse(strFilingsId, strResgTermTypeId, strModifiedBy);

            return results;
        }
        #endregion UpdateResgTermTypeFilings

        #region mapGetEelectionExistsEFSBLLResponse
        /// <summary>
        /// mapGetEelectionExistsEFSBLLResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public Boolean mapGetEelectionExistsEFSBLLResponse(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId, String strMunicipalityId)
        {
            Boolean results = objItemizedReportsDAL.mapGetEelectionExistsEFSDALResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strElectionDateId, strMunicipalityId);

            return results;
        }
        #endregion mapGetEelectionExistsEFSDALResponse


        /// <summary>
        /// Get Filer Information
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="person_ID"></param>
        /// <returns></returns>
        public IList<FilerInfoModel> GetFilerInforamationBLL(String filerID, String person_ID)
        {
            IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
            listFilerInfo = objItemizedReportsDAL.GetFilerInforamationDAL(filerID, person_ID);
            return listFilerInfo;
        }

        /// <summary>
        /// Transfer Outstanding balance in Sched N
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string TransferOutStandingBalanceBLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string results = objItemizedReportsDAL.TransferOutStandingBalanceDAL(objFilingTransactionsModel);
            return results;
        }

        /// <summary>
        /// Submit filings from summery page
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean SubmitFilings_SummeryBLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.SubmitFilings_SummeryDAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetFilingTransactionsDataSummaryDAL
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetFilingTransactionsDataSummaryBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.GetFilingTransactionsDataSummaryDAL(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }

        /// <summary>
        /// Get Opening Balance of Disclosure Summery
        /// </summary>
        /// <param name = "filerID" ></ param >
        /// < param name="election_Year_ID"></param>
        /// <param name = "office_Type_ID" ></ param >
        /// < param name="filing_Type_ID"></param>
        /// <param name = "election_Date" ></ param >
        /// < returns ></ returns >
        internal String GetSummery_OpeningBalanceBLL(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_Date)
        {
            String strOpeningBalance = String.Empty;

            strOpeningBalance = objItemizedReportsDAL.GetSummery_OpeningBalanceDAL(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, election_Date, filing_Date);

            return strOpeningBalance;
        }

        /// <summary>
        /// Get Closing Balance of Summery page
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <returns></returns>
        internal String GetSummery_ClosingBalanceBLL(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_Date)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objItemizedReportsDAL.GetSummery_ClosingBalanceDAL(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_Date);

            return strClosingBalance;
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
        internal String GetSummery_AllSchedBalancesBLL(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objItemizedReportsDAL.GetSummery_AllSchedBalancesDAL(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            return strClosingBalance;
        }

        internal String GetSummery_AllSchedBalancesBLL_Sched_N(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objItemizedReportsDAL.GetSummery_AllSchedBalancesDAL_Sched_N(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            return strClosingBalance;
        }

        #region mapTransferOutStandingLiabilityBalanceBLLResponse
        /// <summary>
        /// mapTransferOutStandingLiabilityBalanceBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal String mapTransferOutStandingLiabilityBalanceBLLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {                   
            String results = objItemizedReportsDAL.mapTransferOutStandingLiabilityBalanceDALResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion mapTransferOutStandingLiabilityBalanceBLLResponse

        #region mapGetOfficeTypeEFSBLLResponse
        /// <summary>
        /// mapGetOfficeTypeEFSBLLResponse
        /// </summary>
        /// <param name="strElectionYear"></param>
        /// <returns></returns>
        internal IList<OfficeTypeModel> mapGetOfficeTypeEFSBLLResponse(String strElectionYear)
        {
            IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();
            
            lstOfficeTypeModel = objItemizedReportsDAL.mapGetOfficeTypeEFSDALResponse(strElectionYear);
                        
            return lstOfficeTypeModel;
        }
        #endregion mapGetOfficeTypeEFSBLLResponse

        
        /// <summary>
        /// Get Outstanding Forgiven
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strTranNumber"></param>
        /// <returns></returns>
        internal IList<OriginalAmountModel> GetOutstandingAmountLiabData_ForgivenBLL(String strFilingEntityId, String strTranNumber, String strFilingsId)
        {
            IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

            lstOriginalAmountModel = objItemizedReportsDAL.GetOutstandingAmountLiabData_ForgivenDAL(strFilingEntityId, strTranNumber, strFilingsId);

            return lstOriginalAmountModel;
        }

        /// <summary>
        /// Check Amend Status
        /// </summary>
        /// <param name="filings_ID"></param>
        /// <returns></returns>
        internal IList<CheckAmendStatusModel> GetAmendStatusBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<CheckAmendStatusModel> lstCheckAmendStatusEntity = new List<CheckAmendStatusModel>();

            lstCheckAmendStatusEntity = objItemizedReportsDAL.GetAmendStatusDAL(objFilingTransDataModel);                        

            return lstCheckAmendStatusEntity;
        }

        /// <summary>
        /// GetExpSubContrTotAmtBLL
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal String GetExpSubContrTotAmtBLL(String strTransNumber, String filerID)
        {
            String strExpSubContrTotAmt = String.Empty;

            strExpSubContrTotAmt = objItemizedReportsDAL.GetExpSubContrTotAmtDAL(strTransNumber, filerID);

            return strExpSubContrTotAmt;
        }

        /// <summary>
        /// Get Edit Flag
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> GetEditFlagBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsDAL.GetEditFlagDAL(objFilingTransDataModel);            

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// ValidateFilingsBLL
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> ValidateFilingsBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsDAL.ValidateFilingsDAL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// Add Viewable Column
        /// </summary>
        /// <param name="filer_ID"></param>
        /// <param name="created_By"></param>
        /// <returns></returns>
        internal Boolean AddViewableColumnBLL(string filer_ID, string created_By)
        {
            Boolean result = objItemizedReportsDAL.AddViewableColumnDAL(filer_ID, created_By);

            return result;
        }

        /// <summary>
        /// mapGetContrInKindPartnersDataBLLResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<ContrInKindPartnersModel> GetLoanReceviedPartnersDataBLL(String strFilingTransId, String strFilerId)
        {
            IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();

            lstContrInKindPartnersModel = objItemizedReportsDAL.GetLoanReceviedPartnersDataDAL(strFilingTransId, strFilerId);

            return lstContrInKindPartnersModel;
        }

        /// <summary>
        /// Validate Loan Received delete
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> ValidateLoanReceived_Delete_BLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsDAL.ValidateLoanReceived_Delete_DAL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        #region mapGetExpPaymentExistsSchedLBLLResponse
        /// <summary>
        /// mapGetExpPaymentExistsSchedLBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mapGetExpPaymentExistsSchedLBLLResponse(String strTransNumber, String filerID, String strSchedID)
        {
            String results = objItemizedReportsDAL.mapGetExpPaymentExistsSchedLDALResponse(strTransNumber, filerID, strSchedID);

            return results;
        }
        #endregion mapGetExpPaymentExistsSchedLBLLResponse

        #region mapGetContributionsExistsSchedMBLLResponse
        /// <summary>
        /// mapGetContributionsExistsSchedMBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mapGetContributionsExistsSchedMBLLResponse(String strTransNumber, String filerID)
        {
            String results = objItemizedReportsDAL.mapGetContributionsExistsSchedMDALResponse(strTransNumber, filerID);

            return results;
        }
        #endregion mapGetContributionsExistsSchedMBLLResponse

        #region mapGetFilingsSubmittedOrNotBLLResponse
        /// <summary>
        /// mapGetFilingsSubmittedOrNotBLLResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        internal String mapGetFilingsSubmittedOrNotBLLResponse(String strFilingsId)
        {
            String strExists = objItemizedReportsDAL.mapGetFilingsSubmittedOrNotDALResponse(strFilingsId);

            return strExists;
        }
        #endregion mapGetFilingsSubmittedOrNotBLLResponse

        #region mpaGetExpRefundedSchedFTotalAmtBLLResponse
        /// <summary>
        /// mpaGetExpRefundedSchedFTotalAmtBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mpaGetExpRefundedSchedFTotalAmtBLLResponse(String strTransNumber, String filerID)
        {
            String strExpRefundedAmt = objItemizedReportsDAL.mpaGetExpRefundedSchedFTotalAmtDALResponse(strTransNumber, filerID);

            return strExpRefundedAmt;
        }
        #endregion mpaGetExpRefundedSchedFTotalAmtBLLResponse

        #region mapGetContrRefundedSchedABCTotalAmtBLLResponse
        /// <summary>
        /// mapGetContrRefundedSchedABCTotalAmtBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal String mapGetContrRefundedSchedABCTotalAmtBLLResponse(String strTransNumber, String filerID)
        {
            String strContrRefundedAmt = objItemizedReportsDAL.mapGetContrRefundedSchedABCTotalAmtDALResponse(strTransNumber, filerID);

            return strContrRefundedAmt;
        }
        #endregion mapGetContrRefundedSchedABCTotalAmtBLLResponse

        #region mapGetCommEditIETransDataBLLResponse
        /// <summary>
        /// mapGetCommEditIETransDataBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetCommEditIETransDataBLLResponse(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();            

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetCommEditIETransDataDALResponse(strTransNumber, filerID);                        

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetCommEditIETransDataBLLResponse

        #region mapLiabilityPrevFlngsOrgAutoCreatedExtsBLLResponse
        /// <summary>
        /// mapLiabilityPrevFlngsOrgAutoCreatedExtsBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        internal String mapLiabilityPrevFlngsOrgAutoCreatedExtsBLLResponse(String strTransNumber, String strFilingsId, String filerID)
        {
            String strExists = String.Empty;

            strExists = objItemizedReportsDAL.mapLiabilityPrevFlngsOrgAutoCreatedExtsDALResponse(strTransNumber, strFilingsId, filerID);

            return strExists;
        }
        #endregion mapLiabilityPrevFlngsOrgAutoCreatedExtsBLLResponse

        #region mapAddNonItemSetPrefPerFilerBLLResponse
        /// <summary>
        /// mapAddNonItemSetPrefPerFilerBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strCreatedBy"></param>
        /// <returns></returns>
        internal Boolean mapAddNonItemSetPrefPerFilerBLLResponse(String strFilerId, String strFilingTypeId, String strCreatedBy)
        {
            Boolean returnValue = objItemizedReportsDAL.mapAddNonItemSetPrefPerFilerDALResponse(strFilerId, strFilingTypeId, strCreatedBy);

            return returnValue;
        }
        #endregion mapAddNonItemSetPrefPerFilerBLLResponse

        #region mapGetEFSPDFBytesBLLResponse
        /// <summary>
        /// mapGetEFSPDFBytesBLLResponse
        /// </summary>
        /// <param name="objEFSPDFRequestModel"></param>
        /// <returns></returns>
        internal EFSPDFResponseModel mapGetEFSPDFBytesBLLResponse(EFSPDFRequestModel objEFSPDFRequestModel)
        {
            EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();                        

            objEFSPDFResponseModel = objItemizedReportsDAL.mapGetEFSPDFBytesDALResponse(objEFSPDFRequestModel);
                        
            return objEFSPDFResponseModel;
        }
        #endregion mapGetEFSPDFBytesBLLResponse

        #region GetImportDisclosureRptsDataBLLResponse
        /// <summary>
        /// GetImportDisclosureRptsDataBLLResponse
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="strReportYear"></param>
        /// <returns></returns>
        public IList<ImportDisclosureRptsData> GetImportDisclosureRptsDataBLLResponse(String txtFilerID, String strReportYear)
        {
            IList<ImportDisclosureRptsData> lstImportDisclosureRptsData = new List<ImportDisclosureRptsData>();            

            lstImportDisclosureRptsData = objItemizedReportsDAL.GetImportDisclosureRptsDataDALResponse(txtFilerID, strReportYear);                        

            return lstImportDisclosureRptsData;
        }
        #endregion GetImportDisclosureRptsDataBLLResponse

        #region GetVendorNamesDataBLLResponse
        /// <summary>
        /// GetVendorNamesDataBLLResponse
        /// </summary>
        /// <returns></returns>
        public IList<VendorNames> GetVendorNamesDataBLLResponse()
        {
            IList<VendorNames> lstVendorNames = new List<VendorNames>();            

            lstVendorNames = objItemizedReportsDAL.GetVendorNamesDataDALResponse();                        

            return lstVendorNames;
        }
        #endregion GetVendorNamesData

        #region GetFilingDateCheckValuesBLLResponse
        /// <summary>
        /// GetFilingDateCheckValues
        /// </summary>
        /// <param name="GetFilingDateCheckValuesBLLResponse"></param>
        /// <returns></returns>
        public IList<CheckFilingDateModel> GetFilingDateCheckValuesBLLResponse(String filingPeriodID, String electID)
        {            
            IList<CheckFilingDateModel> lstCheckFilingDateModel = new List<CheckFilingDateModel>();                                   

            lstCheckFilingDateModel = objItemizedReportsDAL.GetFilingDateCheckValuesDALResponse(filingPeriodID, electID);
                        
            return lstCheckFilingDateModel;
        }
        #endregion GetFilingDateCheckValuesBLLResponse

        #region GetFilingsIdForUploadDataBLLResponse
        /// <summary>
        /// GetFilingsIdForUploadDataBLLResponse
        /// </summary>
        /// <param name="objImportDisclsoureRptsFilings"></param>
        /// <returns></returns>
        public IList<FilingsForFilingCutOffDate> GetFilingsIdForUploadDataBLLResponse(String filerID, String filingPeriodID,
                                                                                   String filingCategoryID, String electID,
                                                                                   String resigTermTypeID, String rFilingDate,
                                                                                   String createdBy)
        {
            IList<FilingsForFilingCutOffDate> lstFilingsForFilingCutOffDate = new List<FilingsForFilingCutOffDate>();
            lstFilingsForFilingCutOffDate = objItemizedReportsDAL.GetFilingsIdForUploadDataDALResponse(filerID, filingPeriodID, filingCategoryID, electID, resigTermTypeID, rFilingDate, createdBy);

            return lstFilingsForFilingCutOffDate;
        }
        #endregion GetFilingsIdForUploadDataBLLResponse

        #region GetFilingsExistsorNotBLLResponse
        /// <summary>
        /// GetFilingsExistsorNotBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String GetFilingsExistsorNotBLLResponse(String strFilerId)
        {
            var results = objItemizedReportsDAL.GetFilingsExistsorNotDALResponse(strFilerId);

            return results.ToString();
        }
        #endregion GetFilingsExistsorNotBLLResponse

        #region LoanLiabilityExistsBLLResponse
        /// <summary>
        /// LoanLiabilityExistsBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strTransNumber"></param>
        /// <param name="strLoanLiabilityNumber"></param>
        /// <returns></returns>
        public Boolean LoanLiabilityExistsBLLResponse(String strFilerId, String strTransNumber, String strLoanLiabilityNumber)
        {
            Boolean results = objItemizedReportsDAL.LoanLiabilityExistsDALResponse(strFilerId, strTransNumber, strLoanLiabilityNumber);

            return results;
        }
        #endregion LoanLiabilityExistsBLLResponse

        #region AddVendorImportFileIntoTempDatabaseBLLResponse
        /// <summary>
        /// AddVendorImportFileIntoTempDatabaseBLLResponse
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileIntoTempDatabaseBLLResponse(IList<FilingTransactionsModel> lstFilingTransactionsModel, VendorImportDataModel objVendorImportDataModel)
        {
            Boolean returnValue = objItemizedReportsDAL.AddVendorImportFileIntoTempDatabaseDALResponse(lstFilingTransactionsModel, objVendorImportDataModel);

            return returnValue;
        }
        #endregion AddVendorImportFileIntoTempDatabaseBLLResponse

        /// <summary>
        /// GetSchedR_Exists
        /// </summary>
        /// <param name="objSchedR_ISExists_Entity"></param>
        /// <returns></returns>
        internal String GetSchedR_Exists_BLL(SchedR_ISExists_Model objSchedR_ISExists_Model)
        {
            String results = objItemizedReportsDAL.GetSchedR_Exists_DAL(objSchedR_ISExists_Model);

            return results;
        }

        /// <summary>
        /// GetFilerCommitteeTypeId
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal String GetFilerCommitteeTypeId(String strFilerId)
        {
            String strCommitteeTypeId = objItemizedReportsDAL.GetFilerCommitteeTypeId(strFilerId);

            return strCommitteeTypeId;
        }

        internal IList<DisclosurePreiodModel> mapGetDisclosurePeriodDataBLLResponseForNoActivity(String strFilerID, String strPolCalDateID, String strElectTypeId)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

            lstDisclosurePreiodModel = objItemizedReportsDAL.mapGetDisclosurePeriodDataDALResponseForNoActivity(strFilerID, strPolCalDateID, strElectTypeId);

            return lstDisclosurePreiodModel;
        }

        #region GetMunicipalityByOfficeType
        /// <summary>
        /// GetMunicipalityByOfficeType
        /// </summary>
        /// <param name="strCountyId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        // GetMunicipalityByOfficeType
        internal IList<MunicipalityModel> GetMunicipalityByOfficeType(String strCountyId, String strOfficeTypeId)
        {
            IList<MunicipalityModel> lstMunicipalityEntity = new List<MunicipalityModel>();

            lstMunicipalityEntity = objItemizedReportsDAL.GetMunicipalityByOfficeType(strCountyId, strOfficeTypeId);                     

            return lstMunicipalityEntity;
        }
        #endregion GetMunicipalityByOfficeType

        #region "mapGetCountyBLLResponse"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        /// <summary>
        /// GetCountyForFilingsBLL
        /// </summary>
        /// <param name="elect_Year_ID"></param>
        /// <param name="filer_ID"></param>
        /// <returns></returns>
        internal IEnumerable<County> GetCountyForFilingsBLL(string elect_Year_ID, string filer_ID)
        {
            IList<County> listCounty = new List<County>();

            listCounty = objItemizedReportsDAL.GetCountyForFilingsDAL(elect_Year_ID,filer_ID).ToList();

            return listCounty;
        }
        #endregion

        /// <summary>
        /// Get Loan Outstanding balance
        /// </summary>
        /// <param name="loan_Lib_number"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal String FilingTransactionOutStandingBalanceBLL(String loan_Lib_number, String strFilerId)
        {
            String results = objItemizedReportsDAL.FilingTransactionOutStandingBalanceDAL(loan_Lib_number, strFilerId);

            return results;
        }

        #region AddVendorImportFileForSchedABLL
        /// <summary>
        /// AddVendorImportFileForSchedABLL
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileForSchedABLL(IList<FilingTransactionsModel> lstFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.AddVendorImportFileForSchedADAL(lstFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddVendorImportFileForSchedABLL

        /// <summary>
        /// DowloadHelpDocumentPDFFileBLL()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DowloadHelpDocumentPDFFileBLL()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            // Call DAL Wrapper to Get PDF Bytes and File Name.
            objEFSPDFResponseModel = objItemizedReportsDAL.DowloadHelpDocumentPDFFileDAL();

            // Return Output Object
            return objEFSPDFResponseModel;
        }

        /// <summary>
        /// DownloadPCFHelpDocumentPDF()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DownloadPCFHelpDocumentPDF()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            objEFSPDFResponseModel = objItemizedReportsDAL.DownloadPCFHelpDocumentPDF();

            return objEFSPDFResponseModel;
        }

        /// <summary>
        /// DownloadSchedAImportTemplate()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DownloadSchedAImportTemplate()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            objEFSPDFResponseModel = objItemizedReportsDAL.DownloadSchedAImportTemplate();

            return objEFSPDFResponseModel;
        }

        /// <summary>
        /// DownloadSchedAImportPCFTemplate()
        /// </summary>
        /// <returns></returns>
        internal List<EFSPDFResponseModel> DownloadSchedAImportPCFTemplate()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            objEFSPDFResponseModel = objItemizedReportsDAL.DownloadSchedAImportPCFTemplate();

            return objEFSPDFResponseModel;
        }

        #region GetTransactionTypesForWeeklyClaimBrokerBLL
        /// <summary>
        /// GetTransactionTypesForWeeklyClaimBrokerBLL
        /// </summary>
        /// <returns></returns>
        internal IList<TransactionTypesModel> GetTransactionTypesForWeeklyClaimBrokerBLL()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsDAL.GetTransactionTypesForWeeklyClaimBrokerDAL();

            return lstTransactionTypesModel;
        }
        #endregion GetTransactionTypesForWeeklyClaimBrokerBLL

        #region GetFilingWeeklyClaimSubmissionDataDALBLL
        /// <summary>
        /// GetFilingWeeklyClaimSubmissionDataDALBLL
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetFilingWeeklyClaimSubmissionDataDALBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.GetFilingWeeklyClaimSubmissionDataDAL(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingWeeklyClaimSubmissionDataDALBLL

        #region GetWeeklyClaimSubmissionHistoryDataBLL
        /// <summary>
        /// GetWeeklyClaimSubmissionHistoryDataBLL
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetWeeklyClaimSubmissionHistoryDataBLL(String strFilingTransId)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.GetWeeklyClaimSubmissionHistoryDataDAL(strFilingTransId);

            return lstFilingTransactionDataModel;
        }
        #endregion GetWeeklyClaimSubmissionHistoryDataBLL

        /// <summary>
        /// AddWeeklyClaimSubSchedABLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddWeeklyClaimSubSchedABLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddWeeklyClaimSubSchedADAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateWeeklyClaimSubSchedABLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateWeeklyClaimSubSchedABLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsDAL.UpdateWeeklyClaimSubSchedADAL(objFilingTransactionsModel);

            return returnValue;
        }

        #region WeeklyClaimSubSubmitTransBLL
        /// <summary>
        /// WeeklyClaimSubSubmitTransBLL
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean WeeklyClaimSubSubmitTransBLL(IList<FilingTransactionsTransID> lstFilingTransactionsTransID, String filerID, String strModifiedBy)
        {
            Boolean results = objItemizedReportsDAL.WeeklyClaimSubSubmitTransDAL(lstFilingTransactionsTransID, filerID, strModifiedBy);

            return results;
        }
        #endregion WeeklyClaimSubSubmitTransBLL

        #region DeleteWeeklyClaimSubSchedABLL
        /// <summary>
        /// DeleteWeeklyClaimSubSchedABLL
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        internal Boolean DeleteWeeklyClaimSubSchedABLL(String strTransNumber, String strModifiedBy, String filerID)
        {
            Boolean returnValue = objItemizedReportsDAL.DeleteWeeklyClaimSubSchedADAL(strTransNumber, strModifiedBy, filerID);

            return returnValue;
        }
        #endregion DeleteWeeklyClaimSubSchedABLL

        #region GetItemizedWCSTransBLL
        /// <summary>
        /// GetItemizedWCSTransBLL
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> GetItemizedWCSTransBLL(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strCuttOffDate)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.GetItemizedWCSTransDAL(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strCuttOffDate);

            return lstFilingTransactionDataModel;
        }
        #endregion GetItemizedWCSTransBLL

        #region AddWeeklyClaimSubItemizedTransDAL
        /// <summary>
        /// AddVendorImportFileForSchedABLL
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddWeeklyClaimSubItemizedTransBLL(IList<FilingTransactionsModel> lstFilingTransactionsModel, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            Boolean returnValue = objItemizedReportsDAL.AddWeeklyClaimSubItemizedTransDAL(lstFilingTransactionsModel, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

            return returnValue;
        }
        #endregion AddWeeklyClaimSubItemizedTransDAL

        /// <summary>
        /// GetDisclosureTypesDataForPCFBBLL
        /// </summary>
        /// <returns></returns>
        internal IList<DisclosureTypesModel> GetDisclosureTypesDataForPCFBBLL(String strCandCommId, String strElectTypeID)
        {
            IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();

            lstDisclosureTypesModel = objItemizedReportsDAL.GetDisclosureTypesDataForPCFBDAL(strCandCommId, strElectTypeID);

            return lstDisclosureTypesModel;
        }

        /// <summary>
        /// GetReportSourceDataSchedSBLL
        /// </summary>
        /// <returns></returns>
        internal IList<ReportSourceModel> GetReportSourceDataSchedSBLL()
        {
            IList<ReportSourceModel> lstReportSourceModel = new List<ReportSourceModel>();

            lstReportSourceModel = objItemizedReportsDAL.GetReportSourceDataSchedSDAL();

            return lstReportSourceModel;
        }

        /// <summary>
        /// AddPublic_Fund_Receipts_SchedS_BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddPublic_Fund_Receipts_SchedS_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddPublic_Fund_Receipts_SchedS_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateFlngtrans_PublicFundRecptBLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFlngtrans_PublicFundRecptBLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.UpdateFlngtrans_PublicFundRecptDAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// mapGetPaymentMethodDataBLLSchedA
        /// </summary>
        /// <returns></returns>
        internal IList<PaymentMethodModel> mapGetPaymentMethodDataBLLSchedA()
        {
            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();

            lstPaymentMethodModel = objItemizedReportsDAL.mapGetPaymentMethodDataDALSchedA();

            return lstPaymentMethodModel;
        }

        /// <summary>
        /// GetEditFlagPCFDueDate
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strCommTypeId"></param>
        /// <param name="strLabelId"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> GetEditFlagPCFDueDateBLL(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsDAL.GetEditFlagPCFDueDateDAL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// GetEditFlagPCFDueDateImportBLL
        /// </summary>
        /// <param name="filerId"></param>
        /// <param name="filingPeriodId"></param>
        /// <param name="electId"></param>
        /// <returns></returns>
        internal IList<GetEditFlagDataModel> GetEditFlagPCFDueDateImportBLL(String filerId, String filingPeriodId, String electId)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsDAL.GetEditFlagPCFDueDateImportDAL(filerId, filingPeriodId, electId);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// AddPublic_Fund_Payment_SchedU_BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal string AddPublic_Fund_Payment_SchedU_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsDAL.AddPublic_Fund_Payment_SchedU_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateFlngtrans_PublicFundPayment_BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        internal Boolean UpdateFlngtrans_PublicFundPayment_BLL(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsDAL.UpdateFlngtrans_PublicFundPayment_DAL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetFilingCutOffDateData_PCF_WCS_BLL
        /// </summary>
        /// <param name="strElectYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        internal IList<FilingCutOffDateModel> GetFilingCutOffDateData_PCF_WCS_BLL(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strPolCalMapId)
        {
            IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

            lstFilingCutOffDateModel = objItemizedReportsDAL.GetFilingCutOffDateData_PCF_WCS_DAL(strElectYearId, strElectTypeId, strOfficeTypeId, strPolCalMapId);

            return lstFilingCutOffDateModel;
        }

        /// <summary>
        /// GetFilingTransSchedR_ChildDataBLL
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        internal IList<FilingTransactionsModel> GetFilingTransSchedR_ChildDataBLL(String strTransNumber, String strFilerId)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

            lstFilingTransactionsModel = objItemizedReportsDAL.GetFilingTransSchedR_ChildDataDAL(strTransNumber, strFilerId);

            return lstFilingTransactionsModel;
        }

        #region mapGetCommEditIETransDataBLLResponse_WCS
        /// <summary>
        /// mapGetCommEditIETransDataBLLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        internal IList<FilingTransactionDataModel> mapGetCommEditIETransDataBLLResponse_WCS(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsDAL.mapGetCommEditIETransDataDALResponse_WCS(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion mapGetCommEditIETransDataBLLResponse_WCS

        /// <summary>
        /// mapGetPurposeCodeData_PCF_BLLResponse
        /// </summary>
        /// <returns></returns>
        internal IList<PurposeCodeModel> mapGetPurposeCodeData_PCF_BLLResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsDAL.mapGetPurposeCodeData_PCF_DALResponse();

            return lstPurposeCodeModel;
        }
    }
}
