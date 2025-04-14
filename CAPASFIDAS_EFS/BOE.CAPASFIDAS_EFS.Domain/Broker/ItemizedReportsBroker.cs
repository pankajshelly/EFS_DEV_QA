using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace Broker
{
    public class ItemizedReportsBroker
    {
        // Create BLL Object
        ItemizedReportsBLL objItemizedReportsBLL = new ItemizedReportsBLL();

        public IList<FilingTransactionDataModel> GetFilingTransactionsDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel =objItemizedReportsBLL.mapGetFilingTransactionsDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        

        public IList<ContributionTypeModel> GetContributionTypeDataResponse()
        {
            IList<ContributionTypeModel> lstContributionTypeModel = new List<ContributionTypeModel>();

            lstContributionTypeModel = objItemizedReportsBLL.mapGetContributionTypeDataBLLResponse();

            return lstContributionTypeModel;
        }

        public IList<ContributorNameModel> GetContributionNameDataResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsBLL.mapGetContributionNameDataBLLResponse();

            return lstContributorNameModel;
        }

        public IList<DisclosurePreiodModel> GetDisclosurePeriodDataResponse(String strElectTypeId, String strfilerID, String strElectYearId)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

            lstDisclosurePreiodModel = objItemizedReportsBLL.mapGetDisclosurePeriodDataBLLResponse(strElectTypeId, strfilerID, strElectYearId);

            return lstDisclosurePreiodModel;
        }

        public IList<ElectionDateModel> GetElectionDateDataResponse(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strCounty, String strMunicipality)
        {
            IList<ElectionDateModel> lstElectionDateModel = new List<ElectionDateModel>();

            lstElectionDateModel = objItemizedReportsBLL.mapGetElectionDateDataBLLResponse(strElectYearId, strElectTypeId, strOfficeTypeId, strCounty, strMunicipality);

            return lstElectionDateModel;
        }

        public IList<FilerCommitteeModel> GetFilerCommitteeDataResponse(String strPersonId)
        {
            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();

            lstFilerCommitteeModel = objItemizedReportsBLL.mapGetFilerCommitteeDataBLLResponse(strPersonId);

            return lstFilerCommitteeModel;
        }

        public IList<PaymentMethodModel> GetPaymentMethodDataResponse()
        {
            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();

            lstPaymentMethodModel = objItemizedReportsBLL.mapGetPaymentMethodDataBLLResponse();

            return lstPaymentMethodModel;
        }

        public IList<PurposeCodeModel> GetPurposeCodeDataResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetPurposeCodeDataBLLResponse();

            return lstPurposeCodeModel;
        }

        public IList<ReceiptCodeModel> GetReceiptCodeDataResponse()
        {
            IList<ReceiptCodeModel> lstReceiptCodeModel = new List<ReceiptCodeModel>();

            lstReceiptCodeModel = objItemizedReportsBLL.mapGetReceiptCodeDataBLLResponse();

            return lstReceiptCodeModel;
        }

        public IList<ReceiptTypeModel> GetReceiptTypeDataResponse()
        {
            IList<ReceiptTypeModel> lstReceiptTypeModel = new List<ReceiptTypeModel>();

            lstReceiptTypeModel = objItemizedReportsBLL.mapGetReceiptTypeDataBLLResponse();

            return lstReceiptTypeModel;
        }

        public IList<TransferTypeModel> GetTransferTypeDataResponse()
        {
            IList<TransferTypeModel> lstTransferTypeModel = new List<TransferTypeModel>();

            lstTransferTypeModel = objItemizedReportsBLL.mapGetTransferTypeDataBLLResponse();

            return lstTransferTypeModel;
        }

        public IList<ElectionYearModel> GetElectionYearDataResponse(String filerID)
        {
            IList<ElectionYearModel> lstElectionYearModel = new List<ElectionYearModel>();

            lstElectionYearModel = objItemizedReportsBLL.mapGetElectionYearDataBLLResponse(filerID);

            return lstElectionYearModel;
        }

        public IList<ElectionTypeModel> GetElectionTypeDataResponse(String strElectionYearId,
            String strOfficeTypeId, String strCountyId, String strMunicipalityId, String strCommTypeId)
        {
            IList<ElectionTypeModel> lstElectionTypeModel = new List<ElectionTypeModel>();

            lstElectionTypeModel = objItemizedReportsBLL.mapGetElectionTypeDataBLLResponse(strElectionYearId,
                strOfficeTypeId, strCountyId, strMunicipalityId, strCommTypeId);

            return lstElectionTypeModel;
        }

        public IList<FilingCutOffDateModel> GetFilingCutOffDateDataResponse(String strElectYearId, String strFilingTypeId, String strOfficeTypeId,
            String strFilingDateId, String strCuttOffDateId, String strElectionDateId)
        {
            IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

            lstFilingCutOffDateModel = objItemizedReportsBLL.mapGetFilingCutOffDateDataBLLResponse(strElectYearId, strFilingTypeId, strOfficeTypeId, strFilingDateId, strCuttOffDateId, strElectionDateId);

            return lstFilingCutOffDateModel;
        }

        /// <summary>
        /// GetContributorTypesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<ContributorTypesModel> GetContributorTypesDataResponse()
        {
            IList<ContributorTypesModel> lstContributorTypesModel = new List<ContributorTypesModel>();

            lstContributorTypesModel = objItemizedReportsBLL.mapGetContributorTypesDataBLLResponse();
            
            return lstContributorTypesModel;
        }

        /// <summary>
        /// GetTransactionTypesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetTransactionTypesDataResponse(String strCandCommId = "")
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsBLL.mapGetTransactionTypesDataBLLResponse(strCandCommId);

            return lstTransactionTypesModel;
        }

        /// <summary>
        /// GetDisclosureTypesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<DisclosureTypesModel> GetDisclosureTypesDataResponse(String strCandCommId)
        {
            IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();

            lstDisclosureTypesModel = objItemizedReportsBLL.mapGetDisclosureTypesDataBLLResponse(strCandCommId);

            return lstDisclosureTypesModel;
        }

        /// <summary>
        /// AddFilingTransactionsDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFlngTransContrInKindDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.mapAddFlngTransContrInKindDataBLLResponse(objFilingTransactionsModel);

            return result;
        }

        public IList<OfficeTypeModel> GetOfficeTypeResponse()
        {
            IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();

            lstOfficeTypeModel = objItemizedReportsBLL.mapGetOfficeTypeBLLResponse();

            return lstOfficeTypeModel;
        }

        public IList<CountyModel> GetCountyResponse()
        {
            IList<CountyModel> lstCountyModel = new List<CountyModel>();

            lstCountyModel = objItemizedReportsBLL.mapGetCountyBLLResponse();

            return lstCountyModel;
        }

        public IList<MunicipalityModel> GetMunicipalityResponse(String strCountyId)
        {
            IList<MunicipalityModel> lstMunicipalityModel = new List<MunicipalityModel>();

            lstMunicipalityModel = objItemizedReportsBLL.mapGetMunicipalityBLLResponse(strCountyId);

            return lstMunicipalityModel;
        }

        /// <summary>
        /// GetAutoCompleteNameAddressResponse
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strFLName"></param>
        /// <returns></returns>
        public IList<AutoCompFLNameAddressModel> GetAutoCompleteNameAddressResponse(String name, String strFilerId, String strFLName)
        {
            IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

            lstAutoCompFLNameAddressModel = objItemizedReportsBLL.mapGetAutoCompleteNameAddressBLLResponse(name, strFilerId, strFLName);

            return lstAutoCompFLNameAddressModel;
        }

        /// <summary>
        /// DeleteFilingTransactionsDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFilingTransactionsDataResponse(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            Boolean results = objItemizedReportsBLL.mapDeleteFilingTransactionsDataBLLResponse(strTransNumber, strModifiedBy, strFilerID);

            return results;
        }

        /// <summary>
        /// DeleteFlngTransExpPaySchedFNDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFlngTransExpPaySchedFNDataResponse(String strLoanLiabNumberOrg, String strTransNumberOrg, String strRLiability, String strModifiedBy, String strFilerID, String strSchedID)
        {
            Boolean results = objItemizedReportsBLL.mapDeleteFlngTransExpPaySchedFNDataBLLResponse(strLoanLiabNumberOrg, strTransNumberOrg, strRLiability, strModifiedBy, strFilerID, strSchedID);

            return results;
        }


        /// <summary>
        /// Viewable Column BLL
        /// </summary>
        /// <param name="strUniqueID"></param>
        /// <param name="strApplicationName"></param>
        /// <param name="strPageName"></param>
        /// <returns></returns>
        public IList<ViewableColumnModel> GetViewableColumnsBroker(String strUniqueID, String strApplicationName, String strPageName)
        {
            IList<ViewableColumnModel> lstViewableColumnModel = new List<ViewableColumnModel>();

            lstViewableColumnModel = objItemizedReportsBLL.GetViewableColumnsBLL(strUniqueID, strApplicationName, strPageName);

            return lstViewableColumnModel;
        }

        public IList<ViewableColumnModel> GetViewableColumnsSortingBroker(String strUniqueID, String strApplicationName, String strPageName)
        {
            IList<ViewableColumnModel> lstViewableColumnModel = new List<ViewableColumnModel>();

            lstViewableColumnModel = objItemizedReportsBLL.GetViewableColumnsSortingBLL(strUniqueID, strApplicationName, strPageName);

            return lstViewableColumnModel;
        }

        /// <summary>
        /// Update Column Broker
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="modifyBy"></param>
        /// <returns></returns>
        public Boolean UpdateColumnValueBroker(String uniqueID, String applicationName, String pageName, String uniqueValue, String modifyBy)
        {
            Boolean results = objItemizedReportsBLL.UpdateColumnValueBLL(uniqueID,
                                         applicationName,
                                         pageName,
                                         uniqueValue,
                                         modifyBy);

            return results;
        }

        /// <summary>
        /// UpdateFilingTransactionsDataResponse
        /// </summary>
        /// <param name="objFilingTransactionDataModel"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransContrInKindDataResponse(FilingTransactionDataModel objFilingTransactionDataModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateFilingTransContrInKindDataBLLResponse(objFilingTransactionDataModel);

            return returnValue;
        }

        public IList<ContributorNameModel> GetPartnerSubContractorDataResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsBLL.mapGetPartnerSubContractorDataBLLResponse();

            return lstContributorNameModel;
        }

        //public Boolean AddFilingTransaction_LoanReceived_Broker(IList<FilingTransactionsModel> objFilingTransactionsModel)
        //{
        //    Boolean result = objItemizedReportsBLL.mapAddLoanReceivedBLLResponse(objFilingTransactionsModel);

        //    return result;
        //}

        public Boolean AddContrInKindPartnersDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.mapAddContrInKindPartnersDataBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetContrInKindPartnersDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ContrInKindPartnersModel> GetContrInKindPartnersDataResponse(String strFilingTransId, String strFilerId)
        {
            IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();

            lstContrInKindPartnersModel = objItemizedReportsBLL.mapGetContrInKindPartnersDataBLLResponse(strFilingTransId, strFilerId);

            return lstContrInKindPartnersModel;
        }

        /// <summary>
        /// DeleteContrInKindPartnersDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteContrInKindPartnersDataResponse(String strTransNumber, String strModifiedBy, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsBLL.mapDeleteContrInKindPartnersDataBLLResponse(strTransNumber, strModifiedBy, strFilerID);

            return returnValue;

        }

        /// <summary>
        /// UpdateContrInKindPartnersDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateContrInKindPartnersDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateContrInKindPartnersDataBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// Add Transfer In scheudled data Broker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFilingTransaction_TransferIn_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddFilingTransaction_TransferIn_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_TransferIn_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.UpdateFilingTransaction_TransferIn_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// AddFilingTransactionNonCompHKReceiptsResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFilingTransactionNonCompHKReceiptsResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string results = objItemizedReportsBLL.mapAddFilingTransactionNonCompHKReceiptsBLLResponse(objFilingTransactionsModel);

            return results;
        }

        /// <summary>
        /// UpdateFilingTransNonCompHKReceiptsResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransNonCompHKReceiptsResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsBLL.mapUpdateFilingTransNonCompHKReceiptsBLLResponse(objFilingTransactionsModel);

            return results;
        }

        /// <summary>
        /// AddFlngTransContrMonetaryDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFlngTransContrMonetaryDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.mapAddFlngTransContrMonetaryDataBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateFlngTransMonetaryContrDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFlngTransMonetaryContrDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateFlngTransMonetaryContrDataBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// AddFlngTransExpenditureDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public String AddFlngTransExpenditureDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            String result = objItemizedReportsBLL.mapAddFlngTransExpenditureDataBLLResponse(objFilingTransactionsModel);

            return result;
        }



        /// <summary>
        /// Add Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFilingTransaction_TransferOut_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddFilingTransaction_TransferOut_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_TransferOut_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.UpdateFilingTransaction_TransferOut_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Add Loan Received scheudled data BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFilingTransaction_LoanReceived_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddFilingTransaction_LoanReceived_BLL(objFilingTransactionsModel);

            return result;
        }

        public string AddFilingTransaction_LoanRepayment_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddFilingTransaction_LoanRepayment_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Update Filing Transaction 
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransaction_LoanReceived_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.UpdateFilingTransaction_LoanReceived_BLL(objFilingTransactionsModel);

            return result;
        }

        public IList<OutstandingLiabilityModel> GetAutoCompleteCreditorNameLiabResponse(String name, String strFilerId, String strNameFlag)
        {
            IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

            lstOutstandingLiabilityModel = objItemizedReportsBLL.mapGetAutoCompleteCreditorNameLiabBLLResponse(name, strFilerId, strNameFlag);

            return lstOutstandingLiabilityModel;
        }

        /// <summary>
        /// GetDateIncurredLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredModel> GetDateIncurredLiabDataResponse(String strFilingEntityId, String strFilerId)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsBLL.mapGetDateIncurredLiabDataBLLResponse(strFilingEntityId, strFilerId);

            return lstDateIncurredModel;
        }

        /// <summary>
        /// GetDateIncurredLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<DateIncurredModel> mapGetDateIncurredLiabDataForForgivenBroker(String strFilingEntityId, String strFilerId)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsBLL.mapGetDateIncurredLiabDataForForgivenBLL(strFilingEntityId, strFilerId);

            return lstDateIncurredModel;
        }

        /// <summary>
        /// GetOriginalAmountLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<OriginalAmountModel> GetOutstandingAmountLiabDataResponse(String strFilingEntityId, String strUpdateStatus, String strFilingTransId, String strFilingsId)
        {
            IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

            lstOriginalAmountModel = objItemizedReportsBLL.mapGetOutstandingAmountLiabDataBLLResponse(strFilingEntityId, strUpdateStatus, strFilingTransId, strFilingsId);

            return lstOriginalAmountModel;
        }

        public String GetExpenditureLiabilityExistsResponse(String strFilingEntityId, String strFlngEntyName, String filerID)
        {
            String returnFlngEntityId = String.Empty;

            returnFlngEntityId = objItemizedReportsBLL.mapGetExpenditureLiabilityExistsBLLResponse(strFilingEntityId, strFlngEntyName, filerID);

            return returnFlngEntityId;
        }

        /// <summary>
        /// GetExpPaymentsLiabilityDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<OutstandingLiabilityModel> GetExpPaymentsLiabilityDataResponse(String strTransNumber, String strFilerId)
        {
            IList<OutstandingLiabilityModel> lstOutstandingLiabilityModel = new List<OutstandingLiabilityModel>();

            lstOutstandingLiabilityModel = objItemizedReportsBLL.mapGetExpPaymentsLiabilityDataBLLResponse(strTransNumber, strFilerId);

            return lstOutstandingLiabilityModel;
        }

        /// <summary>
        /// UpdateFlngTransExpenditureDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFlngTransExpenditureDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateFlngTransExpenditureDataBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// GetSubcontracorsExistsResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetSubcontracorsExistsResponse(String strFilingTransId)
        {
            Boolean results = objItemizedReportsBLL.mapGetSubcontracorsExistsBLLResponse(strFilingTransId);

            return results;
        }


        /// <summary>
        /// Get Loaner Code BLL
        /// </summary>
        /// <returns></returns>
        public IList<LoanerCodeModel> GetLoanerCodeBroker()
        {
            IList<LoanerCodeModel> lstLoanerCodeModel = new List<LoanerCodeModel>();
            lstLoanerCodeModel = objItemizedReportsBLL.GetLoanerCodeBLL();
            return lstLoanerCodeModel;
        }

        /// <summary>
        /// Get Date
        /// </summary>
        /// <returns></returns>
        public IList<GetSearchForScheduledIModel> GetDate_SchedueledJBroker(string FILING_ENTITY_NAME, string ORG_AMT, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsBLL.GetDate_SchedueledJBLL(FILING_ENTITY_NAME, ORG_AMT, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Amount
        /// </summary>
        /// <param name="filing_date"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIModel> GetAmount_SchedueledJBroker(string FILING_ENTITY_NAME, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsBLL.GetAmount_SchedueledJBLL(FILING_ENTITY_NAME, flng_Ent_FirstName, flng_Ent_MiddleName, flng_Ent_LastName, filer_ID);
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Name
        /// </summary>
        /// <param name="filing_date"></param>
        /// <param name="org_amt"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIModel> GetName_SchedueledJBroker(string filer_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsBLL.GetName_SchedueledJBLL(filer_ID);
            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// Get Scheduled J Entity Data
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<FilingTransactionsModel> GetScheduleJ_EntityDataBroker(string trans_Number, String filerID)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();
            lstFilingTransactionsModel = objItemizedReportsBLL.GetScheduleJ_EntityDataBLL(trans_Number, filerID);
            return lstFilingTransactionsModel;
        }

        /// <summary>
        /// Validate Scheduled J Amount
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <returns></returns>
        public IList<GetSearchForScheduledIModel> ValidateSchedJ_AmountBroker(string trans_Nubmer, string status, string FilerID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsBLL.ValidateSchedJ_AmountBLL(trans_Nubmer, status, FilerID);
            return lstGetSearchForScheduledI;
        }        

        /// <summary>
        /// AddFilingTransExpReimbursmentDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddFilingTransExpReimbursmentDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.mapAddFilingTransExpReimbursmentDataBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetFlngTransExpReimbursementDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsModel> GetFlngTransExpReimbursementDataResponse(String strTransNumber, String strFilerId, String strSchedID)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

            lstFilingTransactionsModel = objItemizedReportsBLL.mapGetFlngTransExpReimbursementDataBLLResponse(strTransNumber, strFilerId, strSchedID);

            return lstFilingTransactionsModel;
        }

        /// <summary>
        /// GetReimbursementDetailsAmtResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetReimbursementDetailsAmtResponse(String strTransNumber, String strFilerId, String strSchedID)
        {
            String strReimbursementDetailsAmt = String.Empty;

            strReimbursementDetailsAmt = objItemizedReportsBLL.mapGetReimbursementDetailsAmtBLLResponse(strTransNumber, strFilerId, strSchedID);

            return strReimbursementDetailsAmt;
        }

        /// <summary>
        /// UpdateFilingTransExpReimbursmentDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFilingTransExpReimbursmentDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.mapUpdateFilingTransExpReimbursmentDataBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// DeleteFlngTransReimbursementDataSchedFResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strFilingTransMapping"></param>
        /// <param name="strModififedBy"></param>
        /// <returns></returns>
        public Boolean DeleteFlngTransReimbursementDataSchedFResponse(String strTransNumber, String strModififedBy, String strFilerId)
        {
            Boolean results = objItemizedReportsBLL.mapDeleteFlngTransReimbursementDataSchedFBLLResponse(strTransNumber, strModififedBy, strFilerId);

            return results;
        }

        /// <summary>
        /// AddFilingTransNonCompaignHKExpensesDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public String AddFilingTransNonCompaignHKExpensesDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            String results = objItemizedReportsBLL.mapAddFilingTransNonCompaignHKExpensesDataBLLResponse(objFilingTransactionsModel);

            return results;
        }

        /// <summary>
        /// GetNCHKExpensesReimbursementDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsModel> GetNCHKExpensesReimbursementDataResponse(String strFilingTransId)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

            lstFilingTransactionsModel = objItemizedReportsBLL.mapGetNCHKExpensesReimbursementDataBLLResponse(strFilingTransId);

            return lstFilingTransactionsModel;
        }

        /// <summary>
        /// UpdateNonCompaignHKExpensesSchedQDataResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateNonCompaignHKExpensesSchedQDataResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsBLL.mapUpdateNonCompaignHKExpensesSchedQDataBLLResponse(objFilingTransactionsModel);

            return results;
        }


        public IList<GetSearchForScheduledIModel> ValidateForUpdateScheJBroker(string filing_Trans_ID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();
            lstGetSearchForScheduledI = objItemizedReportsBLL.ValidateForUpdateScheJBLL(filing_Trans_ID);
            return lstGetSearchForScheduledI;
        }

        public Boolean UpdateLoanRepaymentDataBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.UpdateLoanRepaymentDataBLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// Delete Loan Received Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanReceivedBroker(String transNumber, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsBLL.DeleteLoanReceivedBLL(transNumber, strFilerID);
            return returnValue;
        }


        /// <summary>
        /// Delete Loan Repayment Entry
        /// </summary>
        /// <param name="filing_Trans_ID"></param>
        /// <param name="modify_By"></param>
        /// <returns></returns>
        public Boolean DeleteLoanRepaymentBroker(String loan_Lib_Number, String transNumber, String modify_By, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsBLL.DeleteLoanRepaymentBLL(loan_Lib_Number, transNumber, modify_By, strFilerID);
            return returnValue;
        }

        public IList<FilingTransactionDataModel> GetFilingTransactionsForScheduledIJNBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.GetFilingTransactionsForScheduledIJNBLL(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }

        /// <summary>
        /// Update Outstanding Loans
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateOutStandingLoansDataBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            var returnValue = objItemizedReportsBLL.UpdateOutStandingLoansDataBLL(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// Check Scheduled for Outstanding Loans
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsModel> CheckOutstandingScheduledBroker(String strFilingTransId)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsEntity = new List<FilingTransactionsModel>();

            lstFilingTransactionsEntity = objItemizedReportsBLL.CheckOutstandingScheduledBLL(strFilingTransId);

            return lstFilingTransactionsEntity;
        }

        public IList<GetSearchForScheduledIModel> ValidateSchedI_UpdateAmountBroker(string trans_Number, string FilerID)
        {
            IList<GetSearchForScheduledIModel> lstGetSearchForScheduledI = new List<GetSearchForScheduledIModel>();

            lstGetSearchForScheduledI = objItemizedReportsBLL.ValidateSchedI_UpdateAmountBLL(trans_Number, FilerID);

            return lstGetSearchForScheduledI;
        }

        /// <summary>
        /// GetExpLiabilityOwedAmtResponse
        /// </summary>
        /// <param name="strFlngEntityId"></param>
        /// <returns></returns>
        public String GetExpLiabilityOwedAmtResponse(String strFlngEntityId, String filerID)
        {
            String strExpLiabilityOwedAmt = String.Empty;

            strExpLiabilityOwedAmt = objItemizedReportsBLL.mapGetExpLiabilityOwedAmtBLLResponse(strFlngEntityId, filerID);

            return strExpLiabilityOwedAmt;
        }

        /// <summary>
        /// GetExpSubContrTotAmtResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmtResponse(String strTransNumber, String strFilerId)
        {
            String strExpSubContrTotAmt = String.Empty;

            strExpSubContrTotAmt = objItemizedReportsBLL.mapGetExpSubContrTotAmtBLLResponse(strTransNumber, strFilerId);

            return strExpSubContrTotAmt;
        }

        public String GetOutstandingLiabilityAmountResponse(String strFilingEntityId, String strFlngTransId)
        {
            String strOutstandingLiablityAmount = String.Empty;

            strOutstandingLiablityAmount = objItemizedReportsBLL.mapGetOutstandingLiabilityAmountBLLResponse(strFilingEntityId, strFlngTransId);

            return strOutstandingLiablityAmount;
        }

        /// <summary>
        /// GetExpPayTotalLiabAmount
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strFlngTransId"></param>
        /// <returns></returns>
        public String GetExpPayTotalLiabAmountResponse(String strTransNumber, String filerID)
        {
            String strExpPayTotalLiabAmount = String.Empty;

            strExpPayTotalLiabAmount = objItemizedReportsBLL.mapGetExpPayTotalLiabAmountBLLResponse(strTransNumber, filerID);

            return strExpPayTotalLiabAmount;
        }

        /// <summary>
        /// GetContributorTypesSchedCResponse
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameModel> GetContributorTypesSchedCResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsBLL.mapGetContributorTypesSchedCBLLResponse();

            return lstContributorNameModel;
        }

        /// <summary>
        /// Loan Forgiven Broker layer
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddFilingTransaction_LoanForgiven_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string returnValue = objItemizedReportsBLL.AddFilingTransaction_LoanForgiven_BLL(objFilingTransactionsModel);

            return returnValue;
        }

        public Boolean DeleteLoanForgivenBroker(String loan_Lib_Number, String transNumber, String modify_By, String strLiability, String strFilerID)
        {
            Boolean returnValue = objItemizedReportsBLL.DeleteLoanForgivenBLL(loan_Lib_Number, transNumber, modify_By, strLiability, strFilerID);
            return returnValue;
        }

        /// <summary>
        /// GetPurposeCodeReimburDetailsDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetPurposeCodeReimburDetailsDataResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetPurposeCodeReimburDetailsDataBLLResponse();

            return lstPurposeCodeModel;
        }

        /// <summary>
        /// GetPurposeCodeSubcontractorSchedFResponse
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetPurposeCodeSubcontractorSchedFResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetPurposeCodeSubcontractorSchedFBLLResponse();

            return lstPurposeCodeModel;
        }

        /// <summary>
        /// GetPurposeCodeCreditCardItemSchedFResponse
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetPurposeCodeCreditCardItemSchedFResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetPurposeCodeCreditCardItemSchedFBLLResponse();

            return lstPurposeCodeModel;
        }

        /// <summary>
        /// GetExpPayTransIdPopUpSchedFResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentTransIdPopUpSchedFModel> GetExpPayTransIdPopUpSchedFResponse(String strTransNumber, String filerID)
        {
            IList<ExpPaymentTransIdPopUpSchedFModel> lstExpPaymentTransIdPopUpSchedFModel = new List<ExpPaymentTransIdPopUpSchedFModel>();

            lstExpPaymentTransIdPopUpSchedFModel = objItemizedReportsBLL.mapGetExpPayTransIdPopUpSchedFBLLResponse(strTransNumber, filerID);

            return lstExpPaymentTransIdPopUpSchedFModel;
        }

        /// <summary>
        /// Add Loan Received scheudled data BLL
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddFilingTransaction_LoanForgiven_Liabiliites_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.AddFilingTransaction_LoanForgiven_Liabiliites_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetDateIncurredLiabUpdateDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<DateIncurredModel> GetDateIncurredLiabUpdateDataResponse(String strTransNumber, String strFilerId)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsBLL.mapGetDateIncurredLiabUpdateDataBLLResponse(strTransNumber, strFilerId);

            return lstDateIncurredModel;
        }

        /// <summary>
        /// AddOtherReceivedReceiptsSchedEResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddOtherReceivedReceiptsSchedEResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.mapAddOtherReceivedReceiptsSchedEBLLResponse(objFilingTransactionsModel);

            return result;
        }

        // Update Other Receipts Received Transactions.
        /// <summary>
        /// UpdateOtherReceiptsReceivedSchedEResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateOtherReceiptsReceivedSchedEResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateOtherReceiptsReceivedSchedEBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// GetOriginalNameResponse
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentOriginalNameModel> GetOriginalNameResponse(String strFilerId)
        {
            IList<ExpPaymentOriginalNameModel> lstExpPaymentOriginalNameModel = new List<ExpPaymentOriginalNameModel>();

            lstExpPaymentOriginalNameModel = objItemizedReportsBLL.mapGetOriginalNameBLLResponse(strFilerId);

            return lstExpPaymentOriginalNameModel;
        }

        /// <summary>
        /// GetOriginalAmountResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountModel> GetOriginalAmountResponse(String strFilingEntityId, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsBLL.mapGetOriginalAmountBLLResponse(strFilingEntityId, strFilerId);

            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// GetOriginalExpeseDateResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalExpenseDateModel> GetOriginalExpeseDateResponse(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentOriginalExpenseDateModel> lstExpPaymentOriginalExpenseDateModel = new List<ExpPaymentOriginalExpenseDateModel>();

            lstExpPaymentOriginalExpenseDateModel = objItemizedReportsBLL.mapGetOriginalExpeseDateBLLResponse(strTransNumber, strFilerId);

            return lstExpPaymentOriginalExpenseDateModel;
        }

        /// <summary>
        /// AddExpenditureRefundsSchedLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddExpenditureRefundsSchedLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.mapAddExpenditureRefundsSchedLBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetOutstaningAmtExpRefundedResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetOutstaningAmtExpRefundedResponse(String strTransNumber, String strFilerId)
        {
            var results = objItemizedReportsBLL.mapGetOutstaningAmtExpRefundedBLLResponse(strTransNumber, strFilerId);

            return results;
        }

        /// <summary>
        /// UpdateExpenditureRefundedSchedLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateExpenditureRefundedSchedLResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateExpenditureRefundedSchedLBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        public IList<ExpPaymentOriginalAmountModel> GetOriginalAmtRefundedSchedLResponse(String strTransNumber, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsBLL.mapGetOriginalAmtRefundedSchedLBLLResponse(strTransNumber, strFilerId);

            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// GetContributorOriginalNameResponse
        /// </summary>
        /// <returns></returns>
        public IList<ExpPaymentOriginalNameModel> GetContributorOriginalNameResponse(String strFilerId)
        {
            IList<ExpPaymentOriginalNameModel> lstExpPaymentOriginalNameModel = new List<ExpPaymentOriginalNameModel>();

            lstExpPaymentOriginalNameModel = objItemizedReportsBLL.mapGetContributorOriginalNameBLLResponse(strFilerId);

            return lstExpPaymentOriginalNameModel;
        }

        /// <summary>
        /// GetContributorOriginalAmountResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountModel> GetContributorOriginalAmountResponse(String strFilingEntityId, String strFilerId)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsBLL.mapContributorGetOriginalAmountBLLResponse(strFilingEntityId, strFilerId);

            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// GetContributorOriginalContributionDateResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalExpenseDateModel> GetContributorOriginalContributionDateResponse(String strFilingEntityId, String strOriginalAmt, String strFilerId)
        {
            IList<ExpPaymentOriginalExpenseDateModel> lstExpPaymentOriginalExpenseDateModel = new List<ExpPaymentOriginalExpenseDateModel>();

            lstExpPaymentOriginalExpenseDateModel = objItemizedReportsBLL.mapContributorGetOriginalContributionDateBLLResponse(strFilingEntityId, strOriginalAmt, strFilerId);

            return lstExpPaymentOriginalExpenseDateModel;
        }

        /// <summary>
        /// GetOutstaningAmtContrRefundedResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetOutstaningAmtContrRefundedResponse(String strTransNumber, String strFilerId)
        {
            var results = objItemizedReportsBLL.mapGetOutstaningAmtContrRefundedBLLResponse(strTransNumber, strFilerId);

            return results;
        }

        /// <summary>
        /// GetOriginalAmtRefundedSchedMResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ExpPaymentOriginalAmountModel> GetOriginalAmtRefundedSchedMResponse(String strTransNumber, String filerID)
        {
            IList<ExpPaymentOriginalAmountModel> lstExpPaymentOriginalAmountModel = new List<ExpPaymentOriginalAmountModel>();

            lstExpPaymentOriginalAmountModel = objItemizedReportsBLL.mapGetOriginalAmtRefundedSchedMBLLResponse(strTransNumber, filerID);

            return lstExpPaymentOriginalAmountModel;
        }

        /// <summary>
        /// AddContributionsRefundedSchedMResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddContributionsRefundedSchedMResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.mapAddContributionsRefundedSchedLBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateContributionsRefundedSchedMResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateContributionsRefundedSchedMResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateContributionsRefundedSchedMBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// AddOutstandingLiabilitySchedNResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddOutstandingLiabilitySchedNResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.mapAddOutstandingLIabilitySchedNBLLResponse(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateOutstandingLiabilitySchedNResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateOutstandingLiabilitySchedNResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateOutstandingLiabilitySchedNBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }

        /// <summary>
        /// OutstandingLiabilityChildExistsResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String OutstandingLiabilityChildExistsResponse(String strTransNumber, String filerID)
        {
            String strExists = String.Empty;

            strExists = objItemizedReportsBLL.mapOutstandingLiabilityChildExistsBLLResponse(strTransNumber, filerID);

            return strExists;
        }

        /// <summary>
        /// DeleteOutstandingLiabilitySchedNResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteOutstandingLiabilitySchedNResponse(String strTransNumber, String strFilingsId, String strModifiedBy)
        {
            Boolean returnValue = objItemizedReportsBLL.mapDeleteOutstandingLiabilitySchedNBLLResponse(strTransNumber, strFilingsId, strModifiedBy);

            return returnValue;
        }

        /// <summary>
        /// GetEditTransactionDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetEditTransactionDataResponse(String strTransNumber, String strFilerId)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetEditTransactionDataBLLResponse(strTransNumber, strFilerId);

            return lstFilingTransactionDataModel;
        }

        /// <summary>
        /// GetOriginalAmountLiabDataBLLResponse
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <returns></returns>
        public IList<OriginalAmountModel> GetOutstandingAmountForForgivenBroker(String strFilingTransId)
        {
            IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

            lstOriginalAmountModel = objItemizedReportsBLL.GetOutstandingAmountForForgivenBLL(strFilingTransId);

            return lstOriginalAmountModel;
        }

        /// <summary>
        /// Get and Authenticate value from Temp CAPASFIDAS Database
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IList<ValidateFilerInfoModel> GetAuthenticateFilerInfoBroker(String userID)
        {
            IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
            try
            {  

                lstValidateFilerInfo = objItemizedReportsBLL.GetAuthenticateFilerInfoBLL(userID);
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
        public string AddAmountAllocationSchedNBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddAmountAllocationSchedNBLL(objFilingTransactionsModel);
            return result;
        }

        /// <summary>
        /// Update Amount Allocation Sched R
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public Boolean UpdateAmountAllocationSchedNBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            var result = objItemizedReportsBLL.UpdateAmountAllocationSchedNBLL(objFilingTransactionsModel);
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
        public String GetAllAmountBroker(String filing_Ent_ID, String elect_Year, String municipalityID, String officeID, String distID, String filerID)
        {
            String results = objItemizedReportsBLL.GetAllAmountBLL(filing_Ent_ID, elect_Year, municipalityID, officeID, distID, filerID);
            return results;
        }

        public IList<DistrictModel> GetDistrictsForOfficeBroker(String strOfficeID)
        {
            IList<DistrictModel> listGetDistrictsEntity = new List<DistrictModel>();
            listGetDistrictsEntity = objItemizedReportsBLL.GetDistrictsForOfficeBLL(strOfficeID);
            return listGetDistrictsEntity;
        }

        public IList<OfficeModel> GetOfficesBroker(String strMunicipalityID)
        {
            IList<OfficeModel> listGetOfficeEntity = new List<OfficeModel>();
            listGetOfficeEntity = objItemizedReportsBLL.GetOfficesBLL(strMunicipalityID);
            return listGetOfficeEntity;
        }

        /// <summary>
        /// Auto Complete of Sched R
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<AutoCompleteSchedRModel> GetAutoCompleteSchedRBroker(String name, String strFilerId)
        {
            IList<AutoCompleteSchedRModel> lstAutoCompleteSchedREntity = new List<AutoCompleteSchedRModel>();
            lstAutoCompleteSchedREntity = objItemizedReportsBLL.GetAutoCompleteSchedRBLL(name, strFilerId);
            return lstAutoCompleteSchedREntity;
        }

        #region GetOriginalLiabilityDataResponse GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOriginalLiabilityDataResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsModel> GetOriginalLiabilityDataResponse(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsBLL.mapGetOriginalLiabilityDataBLLResponse(strTransNumber, filerID);

            return lstLiabilityDetailsModel;
        }
        #endregion GetOriginalLiabilityDataResponse GET ORIGINAL SCHEDULE 'N' TRANSACTIONS.

        #region GetExpenditurePaymentLiabilityDataResponse GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.
        /// <summary>
        /// GetExpenditurePaymentLiabilityDataResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsModel> GetExpenditurePaymentLiabilityDataResponse(String strTransNumber, String filerID, String strSchedID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsBLL.mapGetExpenditurePaymentLiabilityDataBLLResponse(strTransNumber, filerID, strSchedID);

            return lstLiabilityDetailsModel;
        }
        #endregion GetExpenditurePaymentLiabilityDataResponse GET EXPENDITURE PAYMENT SCHEDULE 'F' TRANSACTIONS.

        #region GetOutstandingLiabilityDataResponse GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.
        /// <summary>
        /// GetOutstandingLiabilityDataResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsModel> GetOutstandingLiabilityDataResponse(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsBLL.mapGetOutstandingLiabilityDataBLLResponse(strTransNumber, filerID);

            return lstLiabilityDetailsModel;
        }
        #endregion GetOutstandingLiabilityDataResponse GET OUTSTANDING LIABILITY SCHEDULE 'N' TRANSACTIONS.

        #region GetLiabilityForgivenDataResponse GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.
        /// <summary>
        /// GetLiabilityForgivenDataResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<LiabilityDetailsModel> GetLiabilityForgivenDataResponse(String strTransNumber, String filerID)
        {
            IList<LiabilityDetailsModel> lstLiabilityDetailsModel = new List<LiabilityDetailsModel>();

            lstLiabilityDetailsModel = objItemizedReportsBLL.mapGetLiabilityForgivenDataBLLResponse(strTransNumber, filerID);

            return lstLiabilityDetailsModel;
        }
        #endregion GetLiabilityForgivenDataResponse GET LIABILITY FORGIVEN SCHEDULE 'K' TRANSACTIONS.

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>>>>>> START START START >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================

        #region GetInLieuOfStatementDataResponse
        /// <summary>
        /// GetInLieuOfStatementDataResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemModel> GetInLieuOfStatementDataResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

            lstInLieuOfStatementNonItemModel = objItemizedReportsBLL.mapGetInLieuOfStatementDataBLLResponse(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

            return lstInLieuOfStatementNonItemModel;
        }
        #endregion GetInLieuOfStatementDataResponse

        #region AddInLieuOfStatementResponse
        /// <summary>
        /// AddInLieuOfStatementResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        public Boolean AddInLieuOfStatementResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            Boolean results = objItemizedReportsBLL.mapAddInLieuOfStatementBLLResponse(objAddInLieuOfStatementModel);

            return results;
        }
        #endregion AddInLieuOfStatementResponse

        #region DeleteInLieuOfStatementResponse
        /// <summary>
        /// DeleteInLieuOfStatementResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteInLieuOfStatementResponse(String strFilingsId, String strModifiedBy)
        {
            Boolean results = objItemizedReportsBLL.mapDeleteInLieuOfStatementBLLResponse(strFilingsId, strModifiedBy);

            return results;
        }
        #endregion DeleteInLieuOfStatementResponse

        #region GetPersonNameAndTreasurerDataResponse
        /// <summary>
        /// GetPersonNameAndTreasurerDataResponse
        /// </summary>
        /// <param name="strPersonId"></param>
        /// <returns></returns>
        public IList<PersonNameAndTreasurerDataModel> GetPersonNameAndTreasurerDataResponse(String strPersonId)
        {
            IList<PersonNameAndTreasurerDataModel> lstPersonNameAndTreasurerDataModel = new List<PersonNameAndTreasurerDataModel>();

            lstPersonNameAndTreasurerDataModel = objItemizedReportsBLL.mapGetPersonNameAndTreasurerDataBLLResponse(strPersonId);

            return lstPersonNameAndTreasurerDataModel;
        }
        #endregion GetPersonNameAndTreasurerDataResponse

        #region GetNoActivityReporttDataResponse
        /// <summary>
        /// GetNoActivityReporttDataResponse
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemModel> GetNoActivityReporttDataResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate)
        {
            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

            lstInLieuOfStatementNonItemModel = objItemizedReportsBLL.mapGetNoActivityReporttDataBLLResponse(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strFilingDate);

            return lstInLieuOfStatementNonItemModel;
        }
        #endregion GetNoActivityReporttDataResponse

        #region AddNoActivityReportResponse
        /// <summary>
        /// AddNoActivityReportResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        public Boolean AddNoActivityReportResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            Boolean results = objItemizedReportsBLL.mapAddNoActivityReportBLLResponse(objAddInLieuOfStatementModel);

            return results;
        }
        #endregion AddNoActivityReportResponse

        #region GetItemizedTransSubmittedResponse
        /// <summary>
        /// GetItemizedTransSubmittedResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public Boolean GetItemizedTransSubmittedResponse(String strFilerId, String strElectionYearId, String strOfficeTypeId,
            String strFilingTypeId, String strFilingCatId, String strElectTypeID)
        {
            Boolean strSubmitted;

            strSubmitted = objItemizedReportsBLL.mapGetItemizedTransSubmittedBLLResponse(strFilerId, strElectionYearId,
                strOfficeTypeId, strFilingTypeId, strFilingCatId, strElectTypeID);

            return strSubmitted;
        }
        #endregion GetItemizedTransSubmittedResponse

        #region AddNoticeOfNonParticipationResponse
        /// <summary>
        /// AddNoticeOfNonParticipationResponse
        /// </summary>
        /// <param name="objAddInLieuOfStatementModel"></param>
        /// <returns></returns>
        public Boolean AddNoticeOfNonParticipationResponse(AddInLieuOfStatementModel objAddInLieuOfStatementModel)
        {
            Boolean results = objItemizedReportsBLL.mapAddNoticeOfNonParticipationBLLResponse(objAddInLieuOfStatementModel);

            return results;
        }
        #endregion AddNoticeOfNonParticipationResponse

        #region GetNoticeOfNonParticipationtDataResponse
        /// <summary>
        /// GetNoticeOfNonParticipationtDataResponse
        /// </summary>
        /// <param name="strFilerid"></param>
        /// <param name="strElectionDate"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionYear"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <returns></returns>
        public IList<InLieuOfStatementNonItemModel> GetNoticeOfNonParticipationtDataResponse(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strCountyId, String strMunicipalityId)
        {
            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = new List<InLieuOfStatementNonItemModel>();

            lstInLieuOfStatementNonItemModel = objItemizedReportsBLL.mapGetNoticeOfNonParticipationtDataBLLResponse(strFilerid, strElectionDate,
                strElectionYearId, strElectionYear, strElectTypeId, strOfficeTypeId, strFilingTypeId, strCountyId, strMunicipalityId);

            return lstInLieuOfStatementNonItemModel;
        }
        #endregion GetNoticeOfNonParticipationtDataResponse

        #region GetTransactionTypes24HNoticeDataResponse
        /// <summary>
        /// GetTransactionTypes24HNoticeDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetTransactionTypes24HNoticeDataResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsBLL.mapGetTransactionTypes24HNoticeDataBLLResponse();

            return lstTransactionTypesModel;
        }
        #endregion GetTransactionTypes24HNoticeDataResponse

        #region GetFilingTrans24HourNoticeDataResponse
        /// <summary>
        /// GetFilingTrans24HourNoticeDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTrans24HourNoticeDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTrans24HourNoticeDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTrans24HourNoticeDataResponse

        #region GetFilingTrans24HourNoticeHistoryDataResponse
        /// <summary>
        /// GetFilingTrans24HourNoticeHistoryDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTrans24HourNoticeHistoryDataResponse(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTrans24HourNoticeHistoryDataBLLResponse(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTrans24HourNoticeHistoryDataResponse

        #region AddNonItem24HourNoticeFlngTransResponse
        /// <summary>
        /// AddNonItem24HourNoticeFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItem24HourNoticeFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItem24HourNoticeFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddNonItem24HourNoticeFlngTransResponse

        #region Update24HNoticeFlngTransResponse
        /// <summary>
        /// Update24HNoticeFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean Update24HNoticeFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdate24HNoticeFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion Update24HNoticeFlngTransResponse

        #region mapSubmit24HNoticeFlngTransBLLResponse
        /// <summary>
        /// mapSubmit24HNoticeFlngTransBLLResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean Submit24HNoticeFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapSubmit24HNoticeFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion mapSubmit24HNoticeFlngTransBLLResponse

        #region Delete24HNoticeFlngTransResponse
        /// <summary>
        /// Delete24HNoticeFlngTransResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean Delete24HNoticeFlngTransResponse(String strTransNumber, String strModifiedBy, String filerID)
        {
            Boolean returnValue = objItemizedReportsBLL.mapDelete24HNoticeFlngTransBLLResponse(strTransNumber, strModifiedBy, filerID);

            return returnValue;
        }
        #endregion Delete24HNoticeFlngTransResponse

        #region GetNonItemChildTransExistsResponse
        /// <summary>
        /// GetNonItemChildTransExistsResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetNonItemChildTransExistsResponse(String strTransNumber, String filerID)
        {
            Boolean strChildTransExists = objItemizedReportsBLL.mapGetNonItemChildTransExistsBLLResponse(strTransNumber, filerID);

            return strChildTransExists;
        }
        #endregion GetNonItemChildTransExistsResponse

        #region GetNonItemParentTransExistsResponse
        /// <summary>
        /// GetNonItemParentTransExistsResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public Boolean GetNonItemParentTransExistsResponse(String strTransNumber, String filerID)
        {
            Boolean strChildTransExists = objItemizedReportsBLL.mapGetNonItemParentTransExistsBLLResponse(strTransNumber, filerID);

            return strChildTransExists;
        }
        #endregion GetNonItemParentTransExistsResponse

        #region GetCommEdit24HourNoticeTransDataResponse
        /// <summary>
        /// /GetCommEdit24HourNoticeTransDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetCommEdit24HourNoticeTransDataResponse(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetCommEdit24HourNoticeTransDataBLLResponse(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion GetCommEdit24HourNoticeTransDataResponse

        #region GetFilingTransIEWeeklyContributioneDataResponse
        /// <summary>
        /// GetFilingTransIEWeeklyContributioneDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIEWeeklyContributioneDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIEWeeklyContributioneDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIEWeeklyContributioneDataResponse

        #region GetIEWeeklyContrbutionTreasurerDataResponse
        /// <summary>
        /// GetIEWeeklyContrbutionTreasurerDataResponse
        /// </summary>
        /// <param name="strTreasurerId"></param>
        /// <returns></returns>
        public IList<NonItemIETreasurerModel> GetIEWeeklyContrbutionTreasurerDataResponse(String strTreasurerId)
        {
            IList<NonItemIETreasurerModel> lstNonItemIETreasurerModel = new List<NonItemIETreasurerModel>();

            lstNonItemIETreasurerModel = objItemizedReportsBLL.mapGetIEWeeklyContrbutionTreasurerDataBLLResponse(strTreasurerId);

            return lstNonItemIETreasurerModel;
        }
        #endregion GetIEWeeklyContrbutionTreasurerDataResponse

        #region AddNonItemIEWeeklyContrFlngTransResponse
        /// <summary>
        /// AddNonItemIEWeeklyContrFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyContrFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsBLL.mapAddNonItemIEWeeklyContrFlngTransBLLResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion AddNonItemIEWeeklyContrFlngTransResponse

        #region UpdateIEWeeklyContrFlngTransResponse
        /// <summary>
        /// UpdateIEWeeklyContrFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyContrFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsBLL.mapUpdateIEWeeklyContrFlngTransBLLResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion UpdateIEWeeklyContrFlngTransResponse

        #region SubmitIEWeeklyContrFlngTransResponse
        /// <summary>
        /// SubmitIEWeeklyContrFlngTransResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean SubmitIEWeeklyContrFlngTransResponse(String strTransNumber, String strModifiedBy)
        {
            Boolean results = objItemizedReportsBLL.mapSubmitIEWeeklyContrFlngTransBLLResponse(strTransNumber, strModifiedBy);

            return results;
        }
        #endregion SubmitIEWeeklyContrFlngTransResponse

        #region GetFilingTransIETransHistoryDataResponse
        /// <summary>
        /// GetFilingTransIETransHistoryDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIETransHistoryDataResponse(String strFilingTransId)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIETransHistoryDataBLLResponse(strFilingTransId);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIETransHistoryDataResponse

        #region GetItemizedNonItemIETransactionsResponse
        /// <summary>
        /// GetItemizedNonItemIETransactionsResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetItemizedNonItemIETransactionsResponse(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strFilingDate)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetItemizedNonItemIETransactionsBLLResponse(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strFilingDate);

            return lstFilingTransactionDataModel;
        }
        #endregion GetItemizedNonItemIETransactionsResponse

        #region AddItemizedIETransactionsDataResponse
        /// <summary>
        /// AddItemizedIETransactionsDataResponse
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
        public Boolean AddItemizedIETransactionsDataResponse(IEnumerable<String> strTransNumber, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            Boolean results = objItemizedReportsBLL.mapAddItemizedIETransactionsDataBLLResponse(strTransNumber, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

            return results;
        }
        #endregion AddItemizedIETransactionsDataResponse

        #region GetContributorCodeIEWeeklyContrSchedCResponse
        /// <summary>
        /// GetContributorCodeIEWeeklyContrSchedCResponse
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameModel> GetContributorCodeIEWeeklyContrSchedCResponse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsBLL.mapGetContributorCodeIEWeeklyContrSchedCBLLResponse();

            return lstContributorNameModel;
        }
        #endregion GetContributorCodeIEWeeklyContrSchedCResponse

        #region GetContributorCodeIEWeeklyContrSchedDRespnse
        /// <summary>
        /// GetContributorCodeIEWeeklyContrSchedDRespnse
        /// </summary>
        /// <returns></returns>
        public IList<ContributorNameModel> GetContributorCodeIEWeeklyContrSchedDRespnse()
        {
            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();

            lstContributorNameModel = objItemizedReportsBLL.mapGetContributorCodeIEWeeklyContrSchedDBLLRespnse();

            return lstContributorNameModel;
        }
        #endregion GetContributorCodeIEWeeklyContrSchedDRespnse

        #region GetFilingTransIE24HContributioneDataResponse
        /// <summary>
        /// GetFilingTransIE24HContributioneDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIE24HContributioneDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIE24HContributioneDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIE24HContributioneDataResponse

        #region GetFilingTransIE24HContributionHistoryDataResponse
        /// <summary>
        /// GetFilingTransIE24HContributionHistoryDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIE24HContributionHistoryDataResponse(String strTransNumber)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIE24HContributionHistoryDataBLLResponse(strTransNumber);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIE24HContributionHistoryDataResponse

        #region GetIE24HContrTransactionTypesResponse
        /// <summary>
        /// GetIE24HContrTransactionTypesResponse
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetIE24HContrTransactionTypesResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsBLL.mapGetIE24HContrTransactionTypesBLLResponse();

            return lstTransactionTypesModel;
        }
        #endregion GetIE24HContrTransactionTypesResponse

        #region AddNonItemIE24HContrFlngTransResponse
        /// <summary>
        /// AddNonItemIE24HContrFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HContrFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsBLL.mapAddNonItemIE24HContrFlngTransBLLResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion AddNonItemIE24HContrFlngTransResponse

        #region UpdateIE24HContrFlngTransResponse
        /// <summary>
        /// UpdateIE24HContrFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateIE24HContrFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean results = objItemizedReportsBLL.mapUpdateIE24HContrFlngTransBLLResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion UpdateIE24HContrFlngTransResponse

        #region SubmitIE24HContrFlngTransResponse
        /// <summary>
        /// SubmitIE24HContrFlngTransResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean SubmitIE24HContrFlngTransResponse(String strTransNumber, String strModifiedBy)
        {
            Boolean results = objItemizedReportsBLL.mapSubmitIE24ContrFlngTransBLLResponse(strTransNumber, strModifiedBy);

            return results;
        }
        #endregion SubmitIE24HContrFlngTransResponse

        #region GetIEWeeklyExpTransactionTypesResponse
        /// <summary>
        /// GetIEWeeklyExpTransactionTypesResponse
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetIEWeeklyExpTransactionTypesResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsBLL.mapGetIEWeeklyExpTransactionTypesBLLResponse();

            return lstTransactionTypesModel;
        }
        #endregion GetIEWeeklyExpTransactionTypesResponse

        #region GetFilingTransIEWeeklyExpenditureDataResponse
        /// <summary>
        /// GetFilingTransIEWeeklyExpenditureDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIEWeeklyExpenditureDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIEWeeklyExpenditureDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIEWeeklyExpenditureDataResponse

        #region GetFilingTransIEWeeklyExpenditureHistoryDataResponse
        /// <summary>
        /// GetFilingTransIEWeeklyExpenditureHistoryDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIEWeeklyExpenditureHistoryDataResponse(String strTransNumber)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIEWeeklyExpenditureHistoryDataBLLResponse(strTransNumber);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIEWeeklyExpenditureHistoryDataResponse

        #region AddNonItemIEWeeklyExpFlngTransResponse
        /// <summary>
        /// AddNonItemIEWeeklyExpFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyExpFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemIEWeeklyExpFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddNonItemIEWeeklyExpFlngTransResponse

        #region UpdateIEWeeklyExpenditureFlngTransResponse
        /// <summary>
        /// UpdateIEWeeklyExpenditureFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyExpenditureFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateIEWeeklyExpenditureFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion UpdateIEWeeklyExpenditureFlngTransResponse

        #region GetNonItemIEDateIncrdLiabUpdateDataResponse
        /// <summary>
        /// GetNonItemIEDateIncrdLiabUpdateDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<DateIncurredModel> GetNonItemIEDateIncrdLiabUpdateDataResponse(String strTransNumber)
        {
            IList<DateIncurredModel> lstDateIncurredModel = new List<DateIncurredModel>();

            lstDateIncurredModel = objItemizedReportsBLL.mapGetNonItemIEDateIncrdLiabUpdateDataBLLResponse(strTransNumber);

            return lstDateIncurredModel;
        }
        #endregion GetNonItemIEDateIncrdLiabUpdateDataResponse

        #region GetNonItemIEPurposeCodesResponse
        /// <summary>
        /// GetNonItemIEPurposeCodesResponse
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetNonItemIEPurposeCodesResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetNonItemIEPurposeCodesBLLResponse();

            return lstPurposeCodeModel;
        }
        #endregion GetNonItemIEPurposeCodesResponse 

        #region GetNonItemIEPurposeCodesSubContrResponse
        /// <summary>
        /// GetNonItemIEPurposeCodesSubContrResponse
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetNonItemIEPurposeCodesSubContrResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetNonItemIEPurposeCodesSubContrBLLResponse();

            return lstPurposeCodeModel;
        }
        #endregion GetNonItemIEPurposeCodesSubContrResponse

        #region GetFilingTransIE24HourExpenditureDataResponse
        /// <summary>
        /// GetFilingTransIE24HourExpenditureDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIE24HourExpenditureDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIE24HourExpenditureDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIE24HourExpenditureDataResponse

        #region GetFilingTransIE24HourPIDAExpenditureDataResponse
        /// <summary>
        /// GetFilingTransIE24HourPIDAExpenditureDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIE24HourPIDAExpenditureDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIE24HourPIDAExpenditureDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIE24HourPIDAExpenditureDataResponse

        #region AddNonItemIE24HourExpFlngTransResponse
        /// <summary>
        /// AddNonItemIE24HourExpFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HourExpFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemIE24HourExpFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddNonItemIE24HourExpFlngTransResponse

        #region AddNonItemIE24HourPIDAExpFlngTransResponse
        /// <summary>
        /// AddNonItemIE24HourPIDAExpFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIE24HourPIDAExpFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemIE24HourPIDAExpFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddNonItemIE24HourPIDAExpFlngTransResponse

        #region GetFilingTransIEWeeklyPIDAExpenditureDataResponse
        /// <summary>
        /// GetFilingTransIEWeeklyPIDAExpenditureDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIEWeeklyPIDAExpenditureDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIEWeeklyPIDAExpenditureDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIEWeeklyPIDAExpenditureDataResponse

        #region AddNonItemIEWeeklyPIDAExpFlngTransResponse
        /// <summary>
        /// AddNonItemIEWeeklyPIDAExpFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyPIDAExpFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemIEWeeklyPIDAExpFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddNonItemIEWeeklyPIDAExpFlngTransResponse

        #region GetIEWeeklyLiabInccrTransactionTypesResponse
        /// <summary>
        /// GetIEWeeklyLiabInccrTransactionTypesResponse
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetIEWeeklyLiabInccrTransactionTypesResponse()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsBLL.mapGetIEWeeklyLiabInccrTransactionTypesBLLResponse();

            return lstTransactionTypesModel;
        }
        #endregion GetIEWeeklyLiabInccrTransactionTypesResponse

        #region GetNonItemIESchedNPurposeCodesResponse
        /// <summary>
        /// GetNonItemIESchedNPurposeCodesResponse
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetNonItemIESchedNPurposeCodesResponse()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetNonItemIESchedNPurposeCodesBLLResponse();

            return lstPurposeCodeModel;
        }
        #endregion GetNonItemIESchedNPurposeCodesResponse

        #region GetFilingTransIEWeeklyLiabIncrDataResponse
        /// <summary>
        /// GetFilingTransIEWeeklyLiabIncrDataResponse
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIEWeeklyLiabIncrDataResponse(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIEWeeklyLiabIncrDataBLLResponse(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIEWeeklyLiabIncrDataResponse

        #region GetFilingTransIEWeeklyLiabIncrHistoryDataResponse
        /// <summary>
        /// GetFilingTransIEWeeklyLiabIncrHistoryDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransIEWeeklyLiabIncrHistoryDataResponse(String strTransNumber)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetFilingTransIEWeeklyLiabIncrHistoryDataBLLResponse(strTransNumber);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingTransIEWeeklyLiabIncrHistoryDataResponse

        #region AddNonItemIEWeeklyLiabIncrFlngTransResponse
        /// <summary>
        /// AddNonItemIEWeeklyLiabIncrFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemIEWeeklyLiabIncrFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemIEWeeklyLiabIncrFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddNonItemIEWeeklyLiabIncrFlngTransResponse

        #region UpdateIEWeeklyLiabIncrFlngTransResponse
        /// <summary>
        /// UpdateIEWeeklyLiabIncrFlngTransResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateIEWeeklyLiabIncrFlngTransResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUpdateIEWeeklyLiabIncrFlngTransBLLResponse(objFilingTransactionsModel);

            return returnValue;
        }
        #endregion UpdateIEWeeklyLiabIncrFlngTransResponse

        #region GetFilingMethodDataResponse
        /// <summary>
        /// GetFilingMethodDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<FilingMthodModel> GetFilingMethodDataResponse()
        {
            IList<FilingMthodModel> lstFilingMthodModel = new List<FilingMthodModel>();

            lstFilingMthodModel = objItemizedReportsBLL.mapGetFilingMethodDataBLLResponse();

            return lstFilingMthodModel;
        }
        #endregion GetFilingMethodDataResponse

        #region GetCampaignMaterialDataResponse
        /// <summary>
        /// GetCampaignMaterialDataResponse
        /// </summary>
        /// <param name="objNonItemCampaignMaterialModel"></param>
        /// <returns></returns>
        public IList<NonItemCampaignMaterialDataModel> GetCampaignMaterialDataResponse(NonItemCampaignMaterialModel objNonItemCampaignMaterialModel)
        {
            IList<NonItemCampaignMaterialDataModel> lstNonItemCampaignMaterialDataModel = new List<NonItemCampaignMaterialDataModel>();

            lstNonItemCampaignMaterialDataModel = objItemizedReportsBLL.mapGetCampaignMaterialDataBLLResponse(objNonItemCampaignMaterialModel);

            return lstNonItemCampaignMaterialDataModel;
        }
        #endregion GetCampaignMaterialDataResponse

        #region AddNonItemCampaignMaterialResponse
        /// <summary>
        /// AddNonItemCampaignMaterialResponse
        /// </summary>
        /// <param name="objNonItemCampaignMaterialModel"></param>
        /// <returns></returns>
        public Boolean AddNonItemCampaignMaterialResponse(NonItemCampaignMaterialModel objNonItemCampaignMaterialModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemCampaignMaterialBLLResponse(objNonItemCampaignMaterialModel);

            return returnValue;
        }
        #endregion AddNonItemCampaignMaterialResponse

        #region DeleteCampaignMaterialResponse
        /// <summary>
        /// DeleteCampaignMaterialResponse
        /// </summary>
        /// <param name="strCampMatrId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteCampaignMaterialResponse(String strCampMatrId, String strModifiedBy)
        {
            Boolean returnValue = objItemizedReportsBLL.mapDeleteCampaignMaterialBLLResponse(strCampMatrId, strModifiedBy);

            return returnValue;
        }
        #endregion DeleteCampaignMaterialResponse

        //=======CABITNET CODE==================CABINET CODE========================

        #region GetTokenIdResponse
        /// <summary>
        /// GetTokenIdResponse
        /// </summary>
        /// <param name="objCampMatrDocumentIdModel"></param>
        /// <returns></returns>
        public CabinetReturnValModel GetTokenIdResponse(CampMatrDocumentIdModel objCampMatrDocumentIdModel)
        {
            CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();

            objCabinetReturnValModel = objItemizedReportsBLL.mapGetTokenIdBLLResponse(objCampMatrDocumentIdModel);

            return objCabinetReturnValModel;
        }
        #endregion GetTokenIdResponse

        #region GetTokenIDBroker
        /// <summary>
        /// GetTokenIDBroker
        /// </summary>
        /// <param name="strFileType"></param>
        /// <returns></returns>
        public CabinetReturnValModel GetTokenIDBroker(String strFileType, String strPageName)
        {
            CabinetReturnValModel objCabinetReturnValModel = new CabinetReturnValModel();
            objCabinetReturnValModel = objItemizedReportsBLL.GetTokenIDBLL(strFileType, strPageName);
            return objCabinetReturnValModel;
        }
        #endregion GetTokenIDBroker

        #region DocumentDownloadBroker
        /// <summary>
        /// DocumentDownloadBroker
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="CabinetID"></param>
        /// <param name="DocumentID"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public CabinetDownloadObjectModel DocumentDownloadBroker(string Token, int CabinetID, int DocumentID, string fileName)
        {
            CabinetDownloadObjectModel objCabinetDownloadObjectModel = new CabinetDownloadObjectModel();
            objCabinetDownloadObjectModel = objItemizedReportsBLL.DocumentDownloadBLL(Token, CabinetID, DocumentID, fileName);
            return objCabinetDownloadObjectModel;
        }
        #endregion DocumentDownloadBroker

        //=======CABITNET CODE==================CABINET CODE========================

        //=======NETWORK DRIVE CODE==================NETWORK DRIVE CODE========================

        #region UploadFileInNetworkDriveResponse
        /// <summary>
        /// UploadFileInNetworkDriveResponse
        /// </summary>
        /// <param name="objUploadFileNTDriveModel"></param>
        /// <returns></returns>
        public Boolean UploadFileInNetworkDriveResponse(UploadFileNTDriveModel objUploadFileNTDriveModel)
        {
            Boolean returnValue = objItemizedReportsBLL.mapUploadFileInNetworkDriveBLLResponse(objUploadFileNTDriveModel);

            return returnValue;
        }
        #endregion UploadFileInNetworkDriveResponse

        #region DownloadFileInNetworkDriveResponse
        /// <summary>
        /// DownloadFileInNetworkDriveResponse
        /// </summary>
        /// <param name="strFileFolderPath"></param>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public Byte[] DownloadFileInNetworkDriveResponse(String strFileFolderPath, String strFileName)
        {
            Byte[] returnValue = objItemizedReportsBLL.mapDownloadFileInNetworkDriveBLLResponse(strFileFolderPath, strFileName);

            return returnValue;
        }
        #endregion DownloadFileInNetworkDriveResponse

        //=======NETWORK DRIVE CODE==================NETWORK DRIVE CODE========================

        //=========================================================================================================================================
        // NON-ITEMIZED TRANSACTIONS - >>>>>>> END END END >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //=========================================================================================================================================

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region GetDropdownValueExistsResponse
        /// <summary>
        /// GetDropdownValueExistsResponse
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strDropdownValue"></param>
        /// <returns></returns>
        public Boolean GetDropdownValueExistsResponse(String strTableName, String strDropdownValue)
        {
            Boolean returnValue = objItemizedReportsBLL.mapGetDropdownValueExistsBLLResponse(strTableName, strDropdownValue);

            return returnValue;
        }
        #endregion GetDropdownValueExistsResponse

        #region GetDropdownValueExistsValidation
        /// <summary>
        /// GetDropdownValueExistsValidation
        /// </summary>
        /// <returns></returns>
        public IList<VendorImportValidationModel> GetDropdownValueExistsValidation()
        {
            IList<VendorImportValidationModel> lstVendorImportValidation = new List<VendorImportValidationModel>();

            lstVendorImportValidation = objItemizedReportsBLL.GetDropdownValueExistsValidation();

            return lstVendorImportValidation;
        }
        #endregion GetDropdownValueExistsValidation

        //========================================================================================================================================
        // COMMON METHOD FOR DROPDOWN VALUES VALIDATION.
        //========================================================================================================================================

        #region GetFilingDateOffCycleDataResponse
        /// <summary>
        /// GetFilingDateOffCycleDataResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public IList<FilingDatesOffCycleModel> GetFilingDateOffCycleDataResponse(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strDisclosureType)
        {
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();

            lstFilingDatesOffCycleModel = objItemizedReportsBLL.mapGetFilingDateOffCycleDataBLLResponse(strElectionYearId, strOfficeTypeId, strFilerId, strDisclosureType);

            return lstFilingDatesOffCycleModel;
        }
        #endregion GetFilingDateOffCycleDataResponse

        #region GetFilingDateIEWeeklyeDataResponse
        /// <summary>
        /// GetFilingDateIEWeeklyeDataResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strFilingType"></param>
        /// <param name="strFilingCatId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public IList<FilingDatesOffCycleModel> GetFilingDateIEWeeklyeDataResponse(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strFilerId, String strFilingType, String strFilingCatId, String strElectionDateId, String strMunicipalityID)
        {
            IList<FilingDatesOffCycleModel> lstFilingDatesOffCycleModel = new List<FilingDatesOffCycleModel>();

            lstFilingDatesOffCycleModel = objItemizedReportsBLL.mapGetFilingDateIEWeeklyeDataBLLResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strFilerId, strFilingType, strFilingCatId, strElectionDateId, strMunicipalityID);

            return lstFilingDatesOffCycleModel;
        }
        #endregion GetFilingDateIEWeeklyeDataResponse

        #region GeResigTermTypeDataResponse
        /// <summary>
        /// GeResigTermTypeDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<ResigTermTypeModel> GeResigTermTypeDataResponse()
        {
            IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();
            
            lstResigTermTypeModel = objItemizedReportsBLL.mapGeResigTermTypeDataBLLResponse();

            return lstResigTermTypeModel;
        }
        #endregion GeResigTermTypeDataResponse

        #region GetResgTermTypeExistsValueResponse
        /// <summary>
        /// GetResgTermTypeExistsValueResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strElectionYearId"></param>
        /// <returns></returns>
        public IList<ResigTermTypeModel> GetResgTermTypeExistsValueResponse(String strFilerId, String strElectionTypeId, String strOfficeTypeId, String strFilingTypeId, String strElectionYearId, String strElectionDateId, String strFilingDate, String strFilingCategoryId, String strMunicipalityId)
        {
            IList<ResigTermTypeModel> lstResigTermTypeModel = new List<ResigTermTypeModel>();

            lstResigTermTypeModel = objItemizedReportsBLL.mapGetResgTermTypeExistsValueBLLResponse(strFilerId, strElectionTypeId, strOfficeTypeId, strFilingTypeId, strElectionYearId, strElectionDateId, strFilingDate, strFilingCategoryId, strMunicipalityId);

            return lstResigTermTypeModel;
        }
        #endregion mapGetResgTermTypeExistsValueDALResponse

        #region UpdateResgTermTypeFilingsResponse
        /// <summary>
        /// UpdateResgTermTypeFilingsResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <param name="strResgTermTypeId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean UpdateResgTermTypeFilingsResponse(String strFilingsId, String strResgTermTypeId, String strModifiedBy)
        {
            Boolean results = objItemizedReportsBLL.mapUpdateResgTermTypeFilingsBLLResponse(strFilingsId, strResgTermTypeId, strModifiedBy);

            return results;
        }
        #endregion UpdateResgTermTypeFilings

        #region GetEelectionExistsEFSResponse
        /// <summary>
        /// GetEelectionExistsEFSResponse
        /// </summary>
        /// <param name="strElectionYearId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public Boolean GetEelectionExistsEFSResponse(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId, String strMunicipalityId)
        {
            Boolean results = objItemizedReportsBLL.mapGetEelectionExistsEFSBLLResponse(strElectionYearId, strElectionTypeId, strOfficeTypeId, strElectionDateId, strMunicipalityId);

            return results;
        }
        #endregion GetEelectionExistsEFSResponse

        /// <summary>
        /// Get Filer Information
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="person_ID"></param>
        /// <returns></returns>
        public IList<FilerInfoModel> GetFilerInforamationBroker(String filerID, String person_ID)
        {
            IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
            listFilerInfo = objItemizedReportsBLL.GetFilerInforamationBLL(filerID, person_ID);
            return listFilerInfo;
        }

        /// <summary>
        /// Transfer Outstanding balance in Sched N
        /// </summary>
        /// <param name="objFilingTransactionsEntity"></param>
        /// <returns></returns>
        public string TransferOutStandingBalanceBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string results = objItemizedReportsBLL.TransferOutStandingBalanceBLL(objFilingTransactionsModel);
            return results;
        }

        /// <summary>
        /// Submit filings from summery page
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean SubmitFilings_SummeryBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.SubmitFilings_SummeryBLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetFilingTransactionsDataSummaryBroker
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingTransactionsDataSummaryBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.GetFilingTransactionsDataSummaryBLL(objFilingTransDataModel);

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
        public String GetSummery_OpeningBalanceBroker(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_Date)
        {
            String strOpeningBalance = String.Empty;

            strOpeningBalance = objItemizedReportsBLL.GetSummery_OpeningBalanceBLL(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, election_Date, filing_Date);

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
        public String GetSummery_ClosingBalanceBroker(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_Date)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objItemizedReportsBLL.GetSummery_ClosingBalanceBLL(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_Date);

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
        public String GetSummery_AllSchedBalancesBroker(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objItemizedReportsBLL.GetSummery_AllSchedBalancesBLL(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            return strClosingBalance;
        }

        /// <summary>
        /// GetSummery_AllSchedBalancesBroker_Sched_N
        /// </summary>
        /// <param name="filerID"></param>
        /// <param name="election_Year_ID"></param>
        /// <param name="office_Type_ID"></param>
        /// <param name="filing_Type_ID"></param>
        /// <param name="filing_date"></param>
        /// <param name="filingSchedID"></param>
        /// <returns></returns>
        public String GetSummery_AllSchedBalancesBroker_Sched_N(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID)
        {
            String strClosingBalance = String.Empty;

            strClosingBalance = objItemizedReportsBLL.GetSummery_AllSchedBalancesBLL_Sched_N(filerID, election_Year_ID, office_Type_ID, filing_Type_ID, filing_date, filingSchedID);

            return strClosingBalance;
        }

        #region TransferOutStandingLiabilityBalanceResponse
        /// <summary>
        /// TransferOutStandingLiabilityBalanceResponse
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public String TransferOutStandingLiabilityBalanceResponse(FilingTransactionsModel objFilingTransactionsModel)
        {
            String results = objItemizedReportsBLL.mapTransferOutStandingLiabilityBalanceBLLResponse(objFilingTransactionsModel);

            return results;
        }
        #endregion TransferOutStandingLiabilityBalanceResponse

        #region GetOfficeTypeEFSResponse
        /// <summary>
        /// GetOfficeTypeEFSResponse
        /// </summary>
        /// <param name="strElectionYear"></param>
        /// <returns></returns>
        public IList<OfficeTypeModel> GetOfficeTypeEFSResponse(String strElectionYear)
        {
            IList<OfficeTypeModel> lstOfficeTypeModel = new List<OfficeTypeModel>();

            lstOfficeTypeModel = objItemizedReportsBLL.mapGetOfficeTypeEFSBLLResponse(strElectionYear);

            return lstOfficeTypeModel;
        }
        #endregion GetOfficeTypeEFSResponse


        /// <summary>
        /// Get Outstanding Forgiven
        /// </summary>
        /// <param name="strFilingEntityId"></param>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<OriginalAmountModel> GetOutstandingAmountLiabData_ForgivenBroker(String strFilingEntityId, String strTransNumber, String strFilingsId)
        {
            IList<OriginalAmountModel> lstOriginalAmountModel = new List<OriginalAmountModel>();

            lstOriginalAmountModel = objItemizedReportsBLL.GetOutstandingAmountLiabData_ForgivenBLL(strFilingEntityId, strTransNumber, strFilingsId);

            return lstOriginalAmountModel;
        }

        /// <summary>
        /// Check Amend Status
        /// </summary>
        /// <param name="filings_ID"></param>
        /// <returns></returns>
        public IList<CheckAmendStatusModel> GetAmendStatusBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<CheckAmendStatusModel> lstCheckAmendStatusEntity = new List<CheckAmendStatusModel>();

            lstCheckAmendStatusEntity = objItemizedReportsBLL.GetAmendStatusBLL(objFilingTransDataModel);

            return lstCheckAmendStatusEntity;
        }

        /// <summary>
        /// GetExpSubContrTotAmtBroker
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public String GetExpSubContrTotAmtBroker(String strTransNumber, String filerID)
        {
            String strExpSubContrTotAmt = String.Empty;

            strExpSubContrTotAmt = objItemizedReportsBLL.GetExpSubContrTotAmtBLL(strTransNumber, filerID);

            return strExpSubContrTotAmt;
        }

        /// <summary>
        /// Get Edit Flag
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataModel> GetEditFlagBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsBLL.GetEditFlagBLL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// ValidateFilingsBroker
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataModel> ValidateFilingsBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsBLL.ValidateFilingsBLL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// Add Viewable Column
        /// </summary>
        /// <param name="filer_ID"></param>
        /// <param name="created_By"></param>
        /// <returns></returns>
        public Boolean AddViewableColumnBroker(string filer_ID, string created_By)
        {
            Boolean result = objItemizedReportsBLL.AddViewableColumnBLL(filer_ID, created_By);

            return result;
        }

        /// <summary>
        /// GetContrInKindPartnersDataResponse
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<ContrInKindPartnersModel> GetLoanReceviedPartnersDataBroker(String strFilingTransId, String strFilerId)
        {
            IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = new List<ContrInKindPartnersModel>();

            lstContrInKindPartnersModel = objItemizedReportsBLL.GetLoanReceviedPartnersDataBLL(strFilingTransId, strFilerId);

            return lstContrInKindPartnersModel;
        }

        /// <summary>
        /// Validate Loan Received delete
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataModel> ValidateLoanReceived_Delete_Broker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsBLL.ValidateLoanReceived_Delete_BLL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        #region GetExpPaymentExistsSchedLResponse
        /// <summary>
        /// GetExpPaymentExistsSchedLResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetExpPaymentExistsSchedLResponse(String strTransNumber, String filerID, String strSchedID)
        {
            String results = objItemizedReportsBLL.mapGetExpPaymentExistsSchedLBLLResponse(strTransNumber, filerID, strSchedID);

            return results;
        }
        #endregion GetExpPaymentExistsSchedLResponse

        #region GetContributionsExistsSchedMResponse
        /// <summary>
        /// GetContributionsExistsSchedMResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetContributionsExistsSchedMResponse(String strTransNumber, String filerID)
        {
            String results = objItemizedReportsBLL.mapGetContributionsExistsSchedMBLLResponse(strTransNumber, filerID);

            return results;
        }
        #endregion GetContributionsExistsSchedMResponse

        #region GetFilingsSubmittedOrNotResponse
        /// <summary>
        /// GetFilingsSubmittedOrNotResponse
        /// </summary>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        public String GetFilingsSubmittedOrNotResponse(String strFilingsId)
        {
            String strExists = objItemizedReportsBLL.mapGetFilingsSubmittedOrNotBLLResponse(strFilingsId);

            return strExists;
        }
        #endregion GetFilingsSubmittedOrNotResponse

        #region GetExpRefundedSchedFTotalAmtResponse
        /// <summary>
        /// GetExpRefundedSchedFTotalAmtResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetExpRefundedSchedFTotalAmtResponse(String strTransNumber, String filerID)
        {
            String strExpRefundedAmt = objItemizedReportsBLL.mpaGetExpRefundedSchedFTotalAmtBLLResponse(strTransNumber, filerID);

            return strExpRefundedAmt;
        }
        #endregion GetExpRefundedSchedFTotalAmtResponse

        #region GetContrRefundedSchedABCTotalAmtResponse
        /// <summary>
        /// GetContrRefundedSchedABCTotalAmtResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public String GetContrRefundedSchedABCTotalAmtResponse(String strTransNumber, String filerID)
        {
            String strContrRefundedAmt = objItemizedReportsBLL.mapGetContrRefundedSchedABCTotalAmtBLLResponse(strTransNumber, filerID);

            return strContrRefundedAmt;
        }
        #endregion GetContrRefundedSchedABCTotalAmtResponse

        #region GetCommEditIETransDataResponse
        /// <summary>
        /// GetCommEditIETransDataResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetCommEditIETransDataResponse(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetCommEditIETransDataBLLResponse(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion GetCommEditIETransDataResponse

        #region LiabilityPrevFlngsOrgAutoCreatedExtsResponse
        /// <summary>
        /// LiabilityPrevFlngsOrgAutoCreatedExtsResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilingsId"></param>
        /// <returns></returns>
        public String LiabilityPrevFlngsOrgAutoCreatedExtsResponse(String strTransNumber, String strFilingsId, String filerID)
        {
            String strExists = String.Empty;

            strExists = objItemizedReportsBLL.mapLiabilityPrevFlngsOrgAutoCreatedExtsBLLResponse(strTransNumber, strFilingsId, filerID);

            return strExists;
        }
        #endregion LiabilityPrevFlngsOrgAutoCreatedExtsResponse

        #region mapAddNonItemSetPrefPerFilerBLLResponse
        /// <summary>
        /// mapAddNonItemSetPrefPerFilerBLLResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strFilingTypeId"></param>
        /// <param name="strCreatedBy"></param>
        /// <returns></returns>
        public Boolean AddNonItemSetPrefPerFilerResponse(String strFilerId, String strFilingTypeId, String strCreatedBy)
        {
            Boolean returnValue = objItemizedReportsBLL.mapAddNonItemSetPrefPerFilerBLLResponse(strFilerId, strFilingTypeId, strCreatedBy);

            return returnValue;
        }
        #endregion mapAddNonItemSetPrefPerFilerBLLResponse

        #region GetEFSPDFBytesResponse
        /// <summary>
        /// GetEFSPDFBytesResponse
        /// </summary>
        /// <param name="objEFSPDFRequestModel"></param>
        /// <returns></returns>
        public EFSPDFResponseModel GetEFSPDFBytesResponse(EFSPDFRequestModel objEFSPDFRequestModel)
        {
            EFSPDFResponseModel objEFSPDFResponseModel = new EFSPDFResponseModel();

            objEFSPDFResponseModel = objItemizedReportsBLL.mapGetEFSPDFBytesBLLResponse(objEFSPDFRequestModel);

            return objEFSPDFResponseModel;
        }
        #endregion GetEFSPDFBytesResponse

        #region GetImportDisclosureRptsDataResponse
        /// <summary>
        /// GetImportDisclosureRptsDataResponse
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="strReportYear"></param>
        /// <returns></returns>
        public IList<ImportDisclosureRptsData> GetImportDisclosureRptsDataResponse(String txtFilerID, String strReportYear)
        {
            IList<ImportDisclosureRptsData> lstImportDisclosureRptsData = new List<ImportDisclosureRptsData>();

            lstImportDisclosureRptsData = objItemizedReportsBLL.GetImportDisclosureRptsDataBLLResponse(txtFilerID, strReportYear);

            return lstImportDisclosureRptsData;
        }
        #endregion GetImportDisclosureRptsDataResponse

        #region GetVendorNamesDataResponse
        /// <summary>
        /// GetVendorNamesDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<VendorNames> GetVendorNamesDataResponse()
        {
            IList<VendorNames> lstVendorNames = new List<VendorNames>();

            lstVendorNames = objItemizedReportsBLL.GetVendorNamesDataBLLResponse();

            return lstVendorNames;
        }
        #endregion GetVendorNamesDataResponse

        #region GetFilingDateCheckValuesResponse
        /// <summary>
        /// GetFilingDateCheckValues
        /// </summary>
        /// <param name="GetFilingDateCheckValuesResponse"></param>
        /// <returns></returns>
        public IList<CheckFilingDateModel> GetFilingDateCheckValuesResponse(String filingPeriodID,String electID)
        {
            IList<CheckFilingDateModel> lstCheckFilingDateModel = new List<CheckFilingDateModel>();

            lstCheckFilingDateModel = objItemizedReportsBLL.GetFilingDateCheckValuesBLLResponse(filingPeriodID, electID);

            return lstCheckFilingDateModel;
        }
        #endregion GetFilingDateCheckValuesResponse

        #region GetFilingsIdForUploadDataResponse
        /// <summary>
        /// GetFilingsIdForUploadDataResponse
        /// </summary>
        /// <param name="objImportDisclsoureRptsFilings"></param>
        /// <returns></returns>
        public IList<FilingsForFilingCutOffDate> GetFilingsIdForUploadDataResponse(String filerID, String filingPeriodID, 
                                                                                   String filingCategoryID, String electID, 
                                                                                   String resigTermTypeID, String rFilingDate, 
                                                                                   String createdBy)
        {
            IList<FilingsForFilingCutOffDate> lstFilingsForFilingCutOffDate = new List<FilingsForFilingCutOffDate>();

            lstFilingsForFilingCutOffDate = objItemizedReportsBLL.GetFilingsIdForUploadDataBLLResponse(filerID, filingPeriodID, filingCategoryID, electID,resigTermTypeID,rFilingDate,createdBy);

            return lstFilingsForFilingCutOffDate;
        }
        #endregion GetFilingsIdForUploadDataResponse

        #region GetFilingsExistsorNotResponse
        /// <summary>
        /// GetFilingsExistsorNotResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String GetFilingsExistsorNotResponse(String strFilerId)
        {
            var results = objItemizedReportsBLL.GetFilingsExistsorNotBLLResponse(strFilerId);

            return results.ToString();
        }
        #endregion GetFilingsExistsorNotResponse

        #region LoanLiabilityExistsResponse
        /// <summary>
        /// LoanLiabilityExistsResponse
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strTransNumber"></param>
        /// <param name="strLoanLiabilityNumber"></param>
        /// <returns></returns>
        public Boolean LoanLiabilityExistsResponse(String strFilerId, String strTransNumber, String strLoanLiabilityNumber)
        {
            Boolean results = objItemizedReportsBLL.LoanLiabilityExistsBLLResponse(strFilerId, strTransNumber, strLoanLiabilityNumber);

            return results;
        }
        #endregion LoanLiabilityExistsResponse

        #region AddVendorImportFileIntoTempDatabaseResponse
        /// <summary>
        /// AddVendorImportFileIntoTempDatabaseResponse
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileIntoTempDatabaseResponse(IList<FilingTransactionsModel> lstFilingTransactionsModel, VendorImportDataModel objVendorImportDataModel)
        {
            Boolean returnValue = objItemizedReportsBLL.AddVendorImportFileIntoTempDatabaseBLLResponse(lstFilingTransactionsModel, objVendorImportDataModel);

            return returnValue;
        }
        #endregion AddVendorImportFileIntoTempDatabaseResponse

        /// <summary>
        /// GetSchedR_Exists
        /// </summary>
        /// <param name="objSchedR_ISExists_Entity"></param>
        /// <returns></returns>
        public String GetSchedR_Exists_Broker(SchedR_ISExists_Model objSchedR_ISExists_Model)
        {
            String results = objItemizedReportsBLL.GetSchedR_Exists_BLL(objSchedR_ISExists_Model);

            return results;
        }

        /// <summary>
        /// GetFilerCommitteeTypeId
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String GetFilerCommitteeTypeId(String strFilerId)
        {
            String strCommitteeTypeId = objItemizedReportsBLL.GetFilerCommitteeTypeId(strFilerId);

            return strCommitteeTypeId;
        }

        public IList<DisclosurePreiodModel> GetDisclosurePeriodDataResponseForNoActivity(String strFilerID, String strPolCalDateID, String strElectTypeId)
        {
            IList<DisclosurePreiodModel> lstDisclosurePreiodModel = new List<DisclosurePreiodModel>();

            lstDisclosurePreiodModel = objItemizedReportsBLL.mapGetDisclosurePeriodDataBLLResponseForNoActivity(strFilerID, strPolCalDateID, strElectTypeId);

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
        public IList<MunicipalityModel> GetMunicipalityByOfficeType(String strCountyId, String strOfficeTypeId)
        {
            IList<MunicipalityModel> lstMunicipalityEntity = new List<MunicipalityModel>();

            lstMunicipalityEntity = objItemizedReportsBLL.GetMunicipalityByOfficeType(strCountyId, strOfficeTypeId);

            return lstMunicipalityEntity;
        }
        #endregion GetMunicipalityByOfficeType

        #region "GetCountyResponse"
        // THIS FUNCTION GETS THE DATA FOR THE COUNTY FILTER DROPDOWN
        /// <summary>
        /// GetCountyForFilingsBroker
        /// </summary>
        /// <param name="elect_Year_ID"></param>
        /// <param name="filer_ID"></param>
        /// <returns></returns>
        public IEnumerable<County> GetCountyForFilingsBroker(string elect_Year_ID, string filer_ID)
        {
            IList<County> listCounty = new List<County>();

            listCounty = objItemizedReportsBLL.GetCountyForFilingsBLL(elect_Year_ID, filer_ID).ToList();

            return listCounty;
        }
        #endregion

        /// <summary>
        /// Get Loan Outstanding balance
        /// </summary>
        /// <param name="loan_Lib_number"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public String FilingTransactionOutStandingBalanceBroker(String loan_Lib_number, String strFilerId)
        {
            String results = objItemizedReportsBLL.FilingTransactionOutStandingBalanceBLL(loan_Lib_number, strFilerId);

            return results;
        }

        #region AddVendorImportFileForSchedABroker
        /// <summary>
        /// AddVendorImportFileForSchedABroker
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddVendorImportFileForSchedABroker(IList<FilingTransactionsModel> lstFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.AddVendorImportFileForSchedABLL(lstFilingTransactionsModel);

            return returnValue;
        }
        #endregion AddVendorImportFileForSchedABroker

        /// <summary>
        /// DowloadHelpDocumentPDFFileBroker()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseModel> DowloadHelpDocumentPDFFileBroker()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            // Call DAL Wrapper to Get PDF Bytes and File Name.
            objEFSPDFResponseModel = objItemizedReportsBLL.DowloadHelpDocumentPDFFileBLL();

            // Return Output Object
            return objEFSPDFResponseModel;
        }

        /// <summary>
        /// DownloadPCFHelpDocumentPDF()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseModel> DownloadPCFHelpDocumentPDF()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            objEFSPDFResponseModel = objItemizedReportsBLL.DownloadPCFHelpDocumentPDF();

            return objEFSPDFResponseModel;
        }

        /// <summary>
        /// DownloadSchedAImportTemplate()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseModel> DownloadSchedAImportTemplate()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            objEFSPDFResponseModel = objItemizedReportsBLL.DownloadSchedAImportTemplate();

            return objEFSPDFResponseModel;
        }

        /// <summary>
        /// DownloadSchedAImportPCFTemplate()
        /// </summary>
        /// <returns></returns>
        public List<EFSPDFResponseModel> DownloadSchedAImportPCFTemplate()
        {
            List<EFSPDFResponseModel> objEFSPDFResponseModel = new List<EFSPDFResponseModel>();

            objEFSPDFResponseModel = objItemizedReportsBLL.DownloadSchedAImportPCFTemplate();

            return objEFSPDFResponseModel;
        }

        #region GetTransactionTypesForWeeklyClaim
        /// <summary>
        /// GetTransactionTypes24HNoticeDataResponse
        /// </summary>
        /// <returns></returns>
        public IList<TransactionTypesModel> GetTransactionTypesForWeeklyClaimBroker()
        {
            IList<TransactionTypesModel> lstTransactionTypesModel = new List<TransactionTypesModel>();

            lstTransactionTypesModel = objItemizedReportsBLL.GetTransactionTypesForWeeklyClaimBrokerBLL();

            return lstTransactionTypesModel;
        }
        #endregion GetTransactionTypesForWeeklyClaimBroker

        #region GetFilingWeeklyClaimSubmissionDataDALBroker
        /// <summary>
        /// GetFilingWeeklyClaimSubmissionDataDALBroker
        /// </summary>
        /// <param name="objFilingTransDataModel"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetFilingWeeklyClaimSubmissionDataDALBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.GetFilingWeeklyClaimSubmissionDataDALBLL(objFilingTransDataModel);

            return lstFilingTransactionDataModel;
        }
        #endregion GetFilingWeeklyClaimSubmissionDataDALBroker

        #region GetWeeklyClaimSubmissionHistoryDataBroker
        /// <summary>
        /// GetWeeklyClaimSubmissionHistoryDataBroker
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetWeeklyClaimSubmissionHistoryDataBroker(String strFilingTransId)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.GetWeeklyClaimSubmissionHistoryDataBLL(strFilingTransId);

            return lstFilingTransactionDataModel;
        }
        #endregion GetWeeklyClaimSubmissionHistoryDataBroker

        /// <summary>
        /// AddWeeklyClaimSubSchedABroker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddWeeklyClaimSubSchedABroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddWeeklyClaimSubSchedABLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateWeeklyClaimSubSchedABroker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateWeeklyClaimSubSchedABroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean returnValue = objItemizedReportsBLL.UpdateWeeklyClaimSubSchedABLL(objFilingTransactionsModel);

            return returnValue;
        }

        #region WeeklyClaimSubSubmitTransBroker
        /// <summary>
        /// WeeklyClaimSubSubmitTransBroker
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean WeeklyClaimSubSubmitTransBroker(IList<FilingTransactionsTransID> lstFilingTransactionsTransID, String filerID, String strModifiedBy)
        {
            Boolean results = objItemizedReportsBLL.WeeklyClaimSubSubmitTransBLL(lstFilingTransactionsTransID, filerID, strModifiedBy);

            return results;
        }
        #endregion WeeklyClaimSubSubmitTransBroker

        #region DeleteWeeklyClaimSubSchedABroker
        /// <summary>
        /// DeleteWeeklyClaimSubSchedABroker
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <param name="strModifiedBy"></param>
        /// <returns></returns>
        public Boolean DeleteWeeklyClaimSubSchedABroker(String strTransNumber, String strModifiedBy, String filerID)
        {
            Boolean returnValue = objItemizedReportsBLL.DeleteWeeklyClaimSubSchedABLL(strTransNumber, strModifiedBy, filerID);

            return returnValue;
        }
        #endregion DeleteWeeklyClaimSubSchedABroker

        #region GetItemizedWCSTransBroker
        /// <summary>
        /// GetItemizedWCSTransBroker
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strElectionYearId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="strElectionDateId"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetItemizedWCSTransBroker(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strCuttOffDate)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.GetItemizedWCSTransBLL(strFilerId, strElectionYearId, strOfficeTypeId, strElectionTypeId, strElectionDateId, strMunicipalityId, strCuttOffDate);

            return lstFilingTransactionDataModel;
        }
        #endregion GetItemizedWCSTransBroker

        #region AddWeeklyClaimSubItemizedTransBLL
        /// <summary>
        /// AddWeeklyClaimSubItemizedTransBLL
        /// </summary>
        /// <param name="lstFilingTransactionsContract"></param>
        /// <returns></returns>
        public Boolean AddWeeklyClaimSubItemizedTransBroker(IList<FilingTransactionsModel> lstFilingTransactionsModel, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate)
        {
            Boolean returnValue = objItemizedReportsBLL.AddWeeklyClaimSubItemizedTransBLL(lstFilingTransactionsModel, strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId, strElectionTypeId, strElectionDateId, strCreatedBy, strFilingDate);

            return returnValue;
        }
        #endregion AddWeeklyClaimSubItemizedTransBLL

        /// <summary>
        /// GetDisclosureTypesDataForPCFBBroker
        /// </summary>
        /// <returns></returns>
        public IList<DisclosureTypesModel> GetDisclosureTypesDataForPCFBBroker(String strCandCommId, String strElectTypeID)
        {
            IList<DisclosureTypesModel> lstDisclosureTypesModel = new List<DisclosureTypesModel>();

            lstDisclosureTypesModel = objItemizedReportsBLL.GetDisclosureTypesDataForPCFBBLL(strCandCommId, strElectTypeID);

            return lstDisclosureTypesModel;
        }

        /// <summary>
        /// GetReportSourceDataSchedSBroker
        /// </summary>
        /// <returns></returns>
        public IList<ReportSourceModel> GetReportSourceDataSchedSBroker()
        {
            IList<ReportSourceModel> lstReportSourceModel = new List<ReportSourceModel>();

            lstReportSourceModel = objItemizedReportsBLL.GetReportSourceDataSchedSBLL();

            return lstReportSourceModel;
        }

        /// <summary>
        /// AddPublic_Fund_Receipts_SchedS_Broker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddPublic_Fund_Receipts_SchedS_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddPublic_Fund_Receipts_SchedS_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateFlngtrans_PublicFundRecptBroker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFlngtrans_PublicFundRecptBroker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.UpdateFlngtrans_PublicFundRecptBLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetPaymentMethodDataSchedA
        /// </summary>
        /// <returns></returns>
        public IList<PaymentMethodModel> GetPaymentMethodDataSchedA()
        {
            IList<PaymentMethodModel> lstPaymentMethodModel = new List<PaymentMethodModel>();

            lstPaymentMethodModel = objItemizedReportsBLL.mapGetPaymentMethodDataBLLSchedA();

            return lstPaymentMethodModel;
        }


        /// <summary>
        /// GetEditFlagPCFDueDateBroker
        /// </summary>
        /// <param name="strFilerId"></param>
        /// <param name="strCommTypeId"></param>
        /// <param name="strLabelId"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataModel> GetEditFlagPCFDueDateBroker(FilingTransDataModel objFilingTransDataModel)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsBLL.GetEditFlagPCFDueDateBLL(objFilingTransDataModel);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// GetEditFlagPCFDueDateImportBroker
        /// </summary>
        /// <param name="filerId"></param>
        /// <param name="filingPeriodId"></param>
        /// <param name="electId"></param>
        /// <returns></returns>
        public IList<GetEditFlagDataModel> GetEditFlagPCFDueDateImportBroker(String filerId, String filingPeriodId, String electId)
        {
            IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();

            lstGetEditFlagDataModel = objItemizedReportsBLL.GetEditFlagPCFDueDateImportBLL(filerId, filingPeriodId, electId);

            return lstGetEditFlagDataModel;
        }

        /// <summary>
        /// AddPublic_Fund_Payment_SchedU_Broker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public string AddPublic_Fund_Payment_SchedU_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            string result = objItemizedReportsBLL.AddPublic_Fund_Payment_SchedU_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// UpdateFlngtrans_PublicFundPayment_Broker
        /// </summary>
        /// <param name="objFilingTransactionsModel"></param>
        /// <returns></returns>
        public Boolean UpdateFlngtrans_PublicFundPayment_Broker(FilingTransactionsModel objFilingTransactionsModel)
        {
            Boolean result = objItemizedReportsBLL.UpdateFlngtrans_PublicFundPayment_BLL(objFilingTransactionsModel);

            return result;
        }

        /// <summary>
        /// GetFilingCutOffDateData_PCF_WCS_Broker
        /// </summary>
        /// <param name="strElectYearId"></param>
        /// <param name="strElectTypeId"></param>
        /// <param name="strOfficeTypeId"></param>
        /// <returns></returns>
        public IList<FilingCutOffDateModel> GetFilingCutOffDateData_PCF_WCS_Broker(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strPolCalMapId)
        {
            IList<FilingCutOffDateModel> lstFilingCutOffDateModel = new List<FilingCutOffDateModel>();

            lstFilingCutOffDateModel = objItemizedReportsBLL.GetFilingCutOffDateData_PCF_WCS_BLL(strElectYearId, strElectTypeId, strOfficeTypeId, strPolCalMapId);

            return lstFilingCutOffDateModel;
        }

        /// <summary>
        /// GetFilingTransSchedR_ChildDataBroker
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <param name="strFilerId"></param>
        /// <returns></returns>
        public IList<FilingTransactionsModel> GetFilingTransSchedR_ChildDataBroker(String strTransNumber, String strFilerId)
        {
            IList<FilingTransactionsModel> lstFilingTransactionsModel = new List<FilingTransactionsModel>();

            lstFilingTransactionsModel = objItemizedReportsBLL.GetFilingTransSchedR_ChildDataBLL(strTransNumber, strFilerId);

            return lstFilingTransactionsModel;
        }

        #region GetCommEditIETransDataResponse_WCS
        /// <summary>
        /// GetCommEditIETransDataResponse
        /// </summary>
        /// <param name="strTransNumber"></param>
        /// <returns></returns>
        public IList<FilingTransactionDataModel> GetCommEditIETransDataResponse_WCS(String strTransNumber, String filerID)
        {
            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

            lstFilingTransactionDataModel = objItemizedReportsBLL.mapGetCommEditIETransDataBLLResponse_WCS(strTransNumber, filerID);

            return lstFilingTransactionDataModel;
        }
        #endregion GetCommEditIETransDataResponse_WCS

        /// <summary>
        /// GetPurposeCodeData_PCF_Response
        /// </summary>
        /// <returns></returns>
        public IList<PurposeCodeModel> GetPurposeCodeData_PCF_Response()
        {
            IList<PurposeCodeModel> lstPurposeCodeModel = new List<PurposeCodeModel>();

            lstPurposeCodeModel = objItemizedReportsBLL.mapGetPurposeCodeData_PCF_BLLResponse();

            return lstPurposeCodeModel;
        }
    }
}
