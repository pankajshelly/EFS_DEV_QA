using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CAPASFIDAS_EFS_SERVICE
{
    [ServiceContract]
    public interface ICAPASFIDAS_EFS_SERVICE
    { 
        [OperationContract]
        IList<ShowAddressContract> GetAddressData(String strPersonId);

        [OperationContract]
        IList<ShowContactContract> GetContactData(String strPersonId);

        [OperationContract]
        IList<DepositoryBankInfoContract> GetDepositoryBankInfoData(String strPersonId);

        [OperationContract]
        IList<CandAuthCommitteesContract> GetCandAuthCommitteesData(String strPersonId);

        [OperationContract]
        IList<CandidateHeaderDataContract> GetCandidateHeaderData(String strPersonId);

        [OperationContract]
        Boolean AddAddressData(AddressDataContract objAddressDataContract);

        [OperationContract]
        Boolean UpdateAddressData(AddressDataContract objAddressDataContract);

        [OperationContract]
        Boolean DeleteAddressData(AddressDataContract objAddressDataContract);

        [OperationContract]
        IList<AddressTypesContract> GetAddressTypesData();

        [OperationContract]
        IList<BestContactTypesContract> GetBestContactTypesData();

        [OperationContract]
        IList<ContactTypesContract> GetContactTypesData();

        [OperationContract]
        Boolean AddContactData(ShowContactContract objShowContactContract);

        [OperationContract]
        Boolean UpdateContactData(ShowContactContract objShowContactContract);

        [OperationContract]
        Boolean DeleteContactData(ShowContactContract objShowContactContract);

        [OperationContract]
        Boolean AddDepositoryBankInfo(DepositoryBankInfoContract objDepositoryBankInfoContract);

        [OperationContract]
        Boolean UpdateDepositoryBankInfo(DepositoryBankInfoContract objDepositoryBankInfoContract);

        [OperationContract]
        Boolean DeleteDepositoryBankInfo(DepositoryBankInfoContract objDepositoryBankInfoContract);

        [OperationContract]
        IList<BankAccountTypesContract> GetBankAccountTypes();

        [OperationContract]
        IList<TreasurerProfileContract> GetTreasurerProfileInfo(string personID);

        [OperationContract]
        IList<TreasurerCommitteeInformationContract> GetTreasurerCommitteeInformation(string transID);

        [OperationContract]
        IList<TreasAssistantInformationContract> GetTreasurerAssistantInformation(string commID);

        [OperationContract]
        IList<TreasurerHistoryContract> GetTreasurerHistoryInformation(string commID, string transID);

        [OperationContract]
        IList<TreasAdditionalCommitteeContactContract> GetTreasurerAdditionalCommitteeContact(string commID);

        [OperationContract]
        IList<TreasDepositoryBankInformationContract> GetTreasurerDepositoryBankInformation(string commID);

        [OperationContract]
        IList<TreasCandidateSupportOpposeContract> GetTreasurerCandidateSupposeOppose(string commID);

        [OperationContract]
        IList<TreasAuthorizedToSignCheckContract> GetTreasurerAuthorizedToSignCheckContact(string commID);

        [OperationContract]
        IList<TreasBallotIssuesContract> GetTreasurerBallotIssuesContact(string commID);

        [OperationContract]
        Boolean AddDepositoryBankInfoTreasurer(TreasDepositoryBankInformationContract objDepositoryBankInfoContract);

        [OperationContract]
        Boolean AddSubTreasurerData(SubTreasurerPersonContract objSubTreasurerPersonContract);

        [OperationContract]
        Boolean UpdateSubTreasurerData(SubTreasurerPersonContract objSubTreasurerPersonContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransactionsData(FilingTransDataContract objFilingTransDataContract);
        
        [OperationContract]
        IList<ContributionTypeContract> GetContributionTypeData();

        [OperationContract]
        IList<ContributorNameContract> GetContributionNameData();

        [OperationContract]
        IList<DisclosurePreiodContract> GetDisclosurePeriodData(String strElectTypeId, String strfilerID, String strElectYearId);

        [OperationContract]
        IList<ElectionDateContract> GetElectionDateData(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strCounty, String strMunicipality);

        [OperationContract]
        IList<FilerCommitteeContract> GetFilerCommitteeData(String strPersonId);

        [OperationContract]
        IList<PaymentMethodContract> GetPaymentMethodData();

        [OperationContract]
        IList<PurposeCodeContract> GetPurposeCodeData();

        [OperationContract]
        IList<ReceiptCodeContract> GetReceiptCodeData();

        [OperationContract]
        IList<ReceiptTypeContract> GetReceiptTypeData();

        [OperationContract]
        IList<TransferTypeContract> GetTransferTypeData();

        [OperationContract]
        IList<ElectionYearContract> GetElectionYearData(String filerID);

        [OperationContract]
        IList<ElectionYearContract> GetElectionYearDataForFilerID(String strFilerID);

        [OperationContract]
        IList<ElectionTypeContract> GetElectionTypeData(String strElectionYearId,
            String strOfficeTypeId, String strCountyId, String strMunicipalityId, String strCommTypeId);

        [OperationContract]
        IList<FilingCutOffDateContract> GetFilingCutOffDateData(String strElectYearId, String strFilingTypeId,
            String strOfficeTypeId, String strFilingDateId, String strCuttOffDateId, String strElectionDateId);

        [OperationContract]
        IList<ContributorTypesContract> GetContributorTypesData();

        [OperationContract]
        IList<TransactionTypesContract> GetTransactionTypesData(String strCandCommId = "");

        [OperationContract]
        IList<DisclosureTypesContract> GetDisclosureTypesData(String strCandCommId);

        [OperationContract]
        string AddFlngTransContrInKindData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<OfficeTypeContract> GetOfficeType();

        [OperationContract]
        IList<CountyContract> GetCounty();

        [OperationContract]
        IList<MunicipalityContract> GetMunicipality(String strCountyId);

        [OperationContract]
        IList<AutoCompFLNameAddressContract> GetAutoCompleteNameAddress(String name, String strFilerId, String strFLName);

        [OperationContract]
        Boolean DeleteFilingTransactionsData(String strTransNumber, String strModifiedBy, String strFilerID);

        [OperationContract]
        Boolean DeleteFlngTransExpPaySchedFNData(String strLoanLiabNumberOrg, String strTransNumberOrg, String strRLiability, String strModifiedBy, String strFilerID, String strSchedID);

        [OperationContract]
        Boolean UpdateFilingTransContrInKindData(FilingTransactionDataContract objFilingTransactionDataContract);

        [OperationContract]
        IList<ViewableColumnContract> GetViewableColumns(String strUniqueID, String strApplicationName, String strPageName);

        [OperationContract]
        Boolean UpdateColumnValue(String uniqueID, String applicationName, String pageName, String uniqueValue, String modifyBy);

        [OperationContract]
        IList<ContributorNameContract> GetPartnerSubContractorData();

        //[OperationContract]
        //Boolean AddLoanReceivedData(List<FilingTransactionsContract> objFilingTransactionsContract);

        [OperationContract]
        Boolean AddContrInKindPartnersData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<ContrInKindPartnersContract> GetContrInKindPartnersData(String strFilingTransId, String strFilerId);

        [OperationContract]
        Boolean DeleteContrInKindPartnersData(String strTransNumber, String strModifiedBy, String strFilerID);

        [OperationContract]
        Boolean UpdateContrInKindPartnersData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        string AddFilingTransaction_TransferIn(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFilingTransaction_TransferIn(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        string AddFilingTransaction_NonCompHKReceipts(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFilingTransNonCompHKReceipts(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        string AddFlngTransContrMonetaryData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFlngTransMonetaryContrData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        String AddFlngTransExpenditureData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        string AddFilingTransaction_TransferOut(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFilingTransaction_TransferOut(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        string AddFilingTransaction_LoanReceived(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFilingTransaction_LoanReceived(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<LoanerCodeContract> GetLoanerCode();

        [OperationContract]
        IList<OutstandingLiabilityContract> GetAutoCompleteCreditorNameLiab(String name, String strFilerId, String strNameFlag);

        [OperationContract]
        IList<DateIncurredContract> GetDateIncurredLiabData(String strFilingEntityId, String strFilerId);

        [OperationContract]
        IList<OriginalAmountContract> GetOutstandingAmountLiabData(String strFilingEntityId, String strUpdateStatus, String strFilingTransId, String strFilingsId);

        [OperationContract]
        String GetExpenditureLiabilityExists(String strFilingEntityId, String strFlngEntyName, String filerID);

        [OperationContract]
        IList<ExpPaymentLiabilityContract> GetExpPaymentsLiabilityData(String strTransNumber, String strFilerId);

        [OperationContract]
        Boolean UpdateFlngTransExpenditureData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean GetSubcontracorsExists(String strFilingTransId);

        [OperationContract]
        IList<GetSearchForScheduledIContract> GetDate_SchedueledJ(string FILING_ENTITY_NAME, string ORG_AMT, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID);

        [OperationContract]
        IList<GetSearchForScheduledIContract> GetAmount_SchedueledJ(string FILING_ENTITY_NAME, string flng_Ent_FirstName,
                                                                 string flng_Ent_MiddleName, string flng_Ent_LastName, string filer_ID);

        [OperationContract]
        IList<GetSearchForScheduledIContract> GetName_SchedueledJ(string filer_ID);

        [OperationContract]
        IList<FilingTransactionsContract> GetScheduleJ_EntityData(string trans_Number, String filerID);

        [OperationContract]
        IList<GetSearchForScheduledIContract> ValidateSchedJ_Amount(string trans_Number, string status, string FilerID);

        [OperationContract]
        string AddFilingTransaction_LoanRepayment(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean AddFilingTransExpReimbursmentData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingTransactionsContract> GetFlngTransExpReimbursementData(String strTransNumber, String strFilerId, String strSchedID);

        [OperationContract]
        String GetReimbursementDetailsAmt(String strTransNumber, String strFilerId, String strSchedID);

        [OperationContract]
        IList<GetSearchForScheduledIContract> ValidateForUpdateScheJ(string filing_Trans_ID);

        [OperationContract]
        Boolean UpdateLoanRepaymentData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean DeleteLoanReceived(String transNumber, String strFilerID);

        [OperationContract]
        Boolean DeleteLoanRepayment(String loan_Lib_Number, String transNumber, String modify_By, String strFilerID);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransactionsForScheduledIJN(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        Boolean UpdateFilingTransExpReimbursmentData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean DeleteFlngTransReimbursementDataSchedF(String strTransNumber, String strModififedBy, String strFilerId);

        [OperationContract]
        String AddFilingTransNonCompaignHKExpensesData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingTransactionsContract> GetNCHKExpensesReimbursementData(String strFilingTransId);

        [OperationContract]
        Boolean UpdateNonCompaignHKExpensesSchedQData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateOutStandingLoansData(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingTransactionsContract> CheckOutstandingScheduled(String strFilingTransId);

        [OperationContract]
        IList<GetSearchForScheduledIContract> ValidateSchedI_UpdateAmount(string trans_Number, string FilerID);

        [OperationContract]
        String GetExpLiabilityOwedAmt(String strFlngEntityId, String filerID);

        [OperationContract]
        String GetExpSubContrTotAmt(String strTransNumber, String strFilerId);

        [OperationContract]
        String GetOutstandingLiabilityAmount(String strFilingEntityId, String strFlngTransId);

        [OperationContract]
        String GetExpPayTotalLiabAmount(String strTransNumber, String filerID);

        [OperationContract]
        IList<ContributorNameContract> GetContributorTypesSchedC();

        [OperationContract]
        string AddFilingTransaction_LoanForgiven(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean DeleteLoanForgiven(String loan_Lib_Number, String transNumber, String modify_By, String strLiability, String strFilerID);

        [OperationContract]
        Boolean AddAuthorizedToSignCheck(AuthorizedToSignCheckContract objAuthorizedToSignCheckContract);

        [OperationContract]
        IList<PurposeCodeContract> GetPurposeCodeReimburDetailsData();

        [OperationContract]
        IList<PurposeCodeContract> GetPurposeCodeSubcontractorSchedF();

        [OperationContract]
        IList<PurposeCodeContract> GetPurposeCodeCreditCardItemSchedF();

        [OperationContract]
        IList<ExpPaymentTransIdPopUpSchedFContract> GetExpPayTransIdPopUpSchedF(String strTransNumber, String filerID);

        [OperationContract]
        Boolean AddFilingTransaction_LoanForgiven_Liabiliites(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<DateIncurredContract> GetDateIncurredLiabDataForForgiven(String strFilingEntityId, String strFilerId);

        [OperationContract]
        IList<DateIncurredContract> GetDateIncurredLiabUpdateData(String strTransNumber, String strFilerId);

        [OperationContract]
        string AddOtherReceivedReceiptsSchedE(FilingTransactionsContract objFilingTransactionsEntity);

        [OperationContract]
        Boolean UpdateOtherReceiptsReceivedSchedE(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<ExpPaymentOriginalNameContract> GetOriginalName(String strFilerId);

        [OperationContract]
        IList<ExpPaymentOriginalAmountContract> GetOriginalAmount(String strFilingEntityId, String strFilerId);

        [OperationContract]
        IList<ExpPaymentOriginalExpenseDateContract> GetOriginalExpeseDate(String strTransNumber, String strFilerId);

        [OperationContract]
        string AddExpenditureRefundsSchedL(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        String GetOutstaningAmtExpRefunded(String strTransNumber, String strFilerId);

        [OperationContract]
        Boolean UpdateExpenditureRefundedSchedL(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<ExpPaymentOriginalAmountContract> GetOriginalAmtRefundedSchedL(String strTransNumber, String strFilerId);

        [OperationContract]
        IList<ExpPaymentOriginalNameContract> GetContributorOriginalName(String strFilerId);

        [OperationContract]
        IList<ExpPaymentOriginalAmountContract> GetContributorOriginalAmount(String strFilingEntityId, String strFilerId);

        [OperationContract]
        IList<ExpPaymentOriginalExpenseDateContract> GetContributorOriginalContributionDate(String strFilingEntityId, String strOriginalAmt, String strFilerId);

        [OperationContract]
        String GetOutstaningAmtContrRefunded(String strTransNumber, String strFilerId);

        [OperationContract]
        IList<ExpPaymentOriginalAmountContract> GetOriginalAmtRefundedSchedM(String strTransNumber, String filerID);

        [OperationContract]
        string AddContributionsRefundedSchedM(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateContributionsRefundedSchedM(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        string AddOutstandingLiabilitySchedN(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateOutstandingLiabilitySchedN(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        String OutstandingLiabilityChildExists(String strTransNumber, String filerID);

        [OperationContract]
        Boolean DeleteOutstandingLiabilitySchedN(String strTransNumber, String strFilingsId, String strModifiedBy);

        [OperationContract]
        IList<FilingTransactionDataContract> GetEditTransactionData(String strFilingTransId, String strFilerId);

        [OperationContract]
        IList<OriginalAmountContract> GetOutstandingAmountForForgiven(String strFilingTransId);

        [OperationContract]
        IList<ValidateFilerInfoContract> GetAuthenticateFilerInfo(String userID);

        [OperationContract]
        string AddAmountAllocationSchedN(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateAmountAllocationSchedN(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        String GetAllAmount(String filing_Ent_ID, String elect_Year, String municipalityID, String officeID, String distID, String filerID);

        [OperationContract]
        IList<DistrictContract> GetDistrictsForOffice(String strOfficeID);

        [OperationContract]
        IList<OfficeContract> GetOffices(String strMunicipalityID);

        [OperationContract]
        IList<InLieuOfStatementNonItemContract> GetInLieuOfStatementData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate);

        [OperationContract]
        IList<AutoCompleteSchedRContract> GetAutoCompleteSchedR(String name, String strFilerId);

        [OperationContract]
        Boolean AddInLieuOfStatement(AddInLieuOfStatementContract objAddInLieuOfStatementContract);

        [OperationContract]
        Boolean DeleteInLieuOfStatement(String strFilingsId, String strModifiedBy);

        [OperationContract]
        IList<PersonNameAndTreasurerDataContract> GetPersonNameAndTreasurerData(String strPersonId);

        [OperationContract]
        IList<FilerInfoContract> GetFilerInforamation(String filerID, String person_ID);

        [OperationContract]
        IList<InLieuOfStatementNonItemContract> GetNoActivityReporttData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strFilingDate);

        [OperationContract]
        Boolean AddNoActivityReport(AddInLieuOfStatementContract objAddInLieuOfStatementContract);

        [OperationContract]
        Boolean GetItemizedTransSubmitted(String strFilerId, String strElectionYearId, String strOfficeTypeId,
            String strFilingTypeId, String strFilingCatId, String strElectTypeID);

        [OperationContract]
        string TransferOutStandingBalance(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean AddNoticeOfNonParticipation(AddInLieuOfStatementContract objAddInLieuOfStatementContract);

        [OperationContract]
        IList<InLieuOfStatementNonItemContract> GetNoticeOfNonParticipationtData(String strFilerid, String strElectionDate,
            String strElectionYearId, String strElectionYear, String strElectTypeId,
            String strOfficeTypeId, String strFilingTypeId, String strCountyId, String strMunicipalityId);

        [OperationContract]
        IList<TransactionTypesContract> GetTransactionTypes24HNoticeData();

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTrans24HourNoticeData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        Boolean AddNonItem24HourNoticeFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean Update24HNoticeFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean Submit24HNoticeFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean Delete24HNoticeFlngTrans(String strTransNumber, String strModifiedBy, String filerID);

        [OperationContract]
        Boolean GetNonItemChildTransExists(String strTransNumber, String filerID);

        [OperationContract]
        Boolean GetNonItemParentTransExists(String strTransNumber, String filerID);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTrans24HourNoticeHistoryData(String strTransNumber, String filerID);

        [OperationContract]
        Boolean SubmitFilings_Summery(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransactionsDataSummary(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        String GetSummery_OpeningBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String election_Date, String filing_date);

        [OperationContract]
        String GetSummery_ClosingBalance(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String cut_Off_date);

        [OperationContract]
        IList<FilingTransactionDataContract> GetCommEdit24HourNoticeTransData(String strTransNumber, String filerID);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIEWeeklyContributioneData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<NonItemIETreasurerContract> GetIEWeeklyContrbutionTreasurerData(String strTreasurerId);

        [OperationContract]
        Boolean AddNonItemIEWeeklyContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateIEWeeklyContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean SubmitIEWeeklyContrFlngTrans(String strTransNumber, String strModifiedBy);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIETransHistoryData(String strFilingTransId);

        [OperationContract]
        IList<FilingTransactionDataContract> GetItemizedNonItemIETransactions(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strFilingDate);

        [OperationContract]
        Boolean AddItemizedIETransactionsData(IList<String> strTransNumber, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIE24HourPIDAExpenditureData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        Boolean AddNonItemIE24HourPIDAExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<ContributorNameContract> GetContributorCodeIEWeeklyContrSchedC();

        [OperationContract]
        IList<ContributorNameContract> GetContributorCodeIEWeeklyContrSchedD();

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIE24HContributioneData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIE24HContributionHistoryData(String strFilingTransId);

        [OperationContract]
        IList<TransactionTypesContract> GetIE24HContrTransactionTypes();

        [OperationContract]
        Boolean AddNonItemIE24HContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateIE24HContrFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean SubmitIE24HContrFlngTrans(String strTransNumber, String strModifiedBy);

        [OperationContract]
        String GetSummery_AllSchedBalances(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID);
        [OperationContract]
        String GetSummery_AllSchedBalances_Sched_N(String filerID, String election_Year_ID, String office_Type_ID, String filing_Type_ID, String filing_date, String filingSchedID);
        [OperationContract]
        IList<TransactionTypesContract> GetIEWeeklyExpTransactionTypes();

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIEWeeklyExpenditureData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIEWeeklyExpenditureHistoryData(String strTransNumber);

        [OperationContract]
        Boolean AddNonItemIEWeeklyExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateIEWeeklyExpenditureFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<DateIncurredContract> GetNonItemIEDateIncrdLiabUpdateData(String strTransNumber);

        [OperationContract]
        IList<PurposeCodeContract> GetNonItemIEPurposeCodes();

        [OperationContract]
        IList<PurposeCodeContract> GetNonItemIEPurposeCodesSubContr();

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIE24HourExpenditureData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        Boolean AddNonItemIE24HourExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIEWeeklyPIDAExpenditureData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        Boolean AddNonItemIEWeeklyPIDAExpFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<TransactionTypesContract> GetIEWeeklyLiabInccrTransactionTypes();

        [OperationContract]
        IList<PurposeCodeContract> GetNonItemIESchedNPurposeCodes();

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIEWeeklyLiabIncrData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingTransIEWeeklyLiabIncrHistoryData(String strTransNumber);

        [OperationContract]
        Boolean AddNonItemIEWeeklyLiabIncrFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateIEWeeklyLiabIncrFlngTrans(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingMthodContract> GetFilingMethodData();

        [OperationContract]
        IList<NonItemCampaignMaterialDataContract> GetCampaignMaterialData(NonItemCampaignMaterialContract objNonItemCampaignMaterialContract);

        [OperationContract]
        Boolean AddNonItemCampaignMaterial(NonItemCampaignMaterialContract objNonItemCampaignMaterialContract);

        [OperationContract]
        Boolean DeleteCampaignMaterial(String strCampMatrId, String strModifiedBy);

        //===============CABINET CODE=======CAMPAIGN MATERIAL=========CABINET CODE===========
        [OperationContract]        
        Task<PIDAReturnVal> GetTokenID(DocumentIDContract objDocumentIDContract);

        [OperationContract]
        Task<PIDAReturnVal> GetTokenIDData(String strFileType, String strPageName);

        [OperationContract]
        Task<PIDADownloadObject> DocumentDownload(string Token, int CabinetID, int DocumentID, string fileName);

        [OperationContract]
        Task<DocumentInfoData> GetDocumentData(string IE_Comm_Doc_ID, string cabinetFolderName);

        [OperationContract]
        Boolean UploadFileInNetworkDrive(UploadFileNTDriveContract objUploadFileNTDriveContract);

        [OperationContract]
        Byte[] DownloadFileInNetworkDrive(String strFileFolderPath, String strFileName);
        //===============CABINET CODE=======CAMPAIGN MATERIAL=========CABINET CODE===========

        [OperationContract]
        IList<FilingDatesOffCycleContract> GetFilingDateOffCycleData(String strElectionYearId, String strOfficeTypeId, String strFilerId, String strDisclosureType);

        [OperationContract]
        Boolean GetDropdownValueExists(String strTableName, String strDropdownValue);

        [OperationContract]
        IList<VendorImportValidationContract> GetDropdownValueExistsValidation();

        [OperationContract]
        IList<OfficeTypeContract> GetOfficeTypeEFS(String strElectionYear);

        [OperationContract]
        IList<ResigTermTypeContract> GeResigTermTypeData();

        [OperationContract]
        IList<ResigTermTypeContract> GetResgTermTypeExistsValue(String strFilerId, String strElectionTypeId, String strOfficeTypeId, String strFilingTypeId, String strElectionYearId, String strElectionDateId, String strFilingDate, String strFilingCategoryId, String strMunicipalityId);

        [OperationContract]
        Boolean UpdateResgTermTypeFilings(String strFilingsId, String strResgTermTypeId, String strModifiedBy);

        [OperationContract]
        Boolean GetEelectionExistsEFS(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strElectionDateId, String strMunicipalityId);

        [OperationContract]
        IList<LiabilityDetailsContract> GetOriginalLiabilityData(String strTransNumber, String filerID);

        [OperationContract]
        IList<LiabilityDetailsContract> GetExpenditurePaymentLiabilityData(String strTransNumber, String filerID, String strSchedID);

        [OperationContract]
        IList<LiabilityDetailsContract> GetOutstandingLiabilityData(String strTransNumber, String filerID);

        [OperationContract]
        IList<LiabilityDetailsContract> GetLiabilityForgivenData(String strTransNumber, String filerID);

        [OperationContract]
        IList<FilingDatesOffCycleContract> GetFilingDateIEWeeklyeData(String strElectionYearId, String strElectionTypeId, String strOfficeTypeId, String strFilerId, String strFilingType, String strFilingCatId, String strElectionDateId, String strMunicipalityID);

        #region "ViewAllDisclosures"
        [OperationContract]
        IList<CommunicationTypeContract> GetCommunicationTypes();

        [OperationContract]
        IList<CampaignMaterialsContract> GetCampaignMaterialsGridData(String strFilingsID, String strAmended);

        [OperationContract]
        IList<OfficeTypeContract> GetOfficeTypeForFilerIDWCF(String strElectYearID, String strFilerID);

        [OperationContract]
        IList<ElectionTypeContract> GetElectionTypeForFilerIDWCF(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID);

        [OperationContract]
        IList<ElectionDateContract> GetElectionDateWCF(string electionYearID, string electionTypeID, string officeTypeID, string filerID, string countyID, string municipalityID);

        [OperationContract]
        IList<CountyContract> GetCountyWCF(int officeTypeID);

        [OperationContract]
        IList<MunicipalityContract> GetMunicipalityWCF(int countyID);

        [OperationContract]
        IList<DisclosurePreiodContract> GetDisclosurePeriodsForYearAndFilerIDAndElectionType(String strFilerID, String strElectionYearID, String strElectionTypeID, String strFilingCatID, String strOfficeTypeID);

        [OperationContract]
        IList<DisclosureTypesContract> GetDisclosureTypesForYearAndFilerID(String strFilerID, String strElectionYearID, String strElectionTypeID, String strElectionDateID);

        [OperationContract]
        String InsertSupportingDocument(
                                        String strFilingTransID,
                                        String strFilingMethodID,
                                        String strDocTypeID,
                                        String strScanDocID,
                                        String strFileType,
                                        String strFileSize,
                                        String strCreatedBy,
                                        String strFilerID,
                                        String FilingsID);

        [OperationContract]
        String InsertSupportingDocumentPIDA(
                                String strFilingTransID,
                                String strFilingMethodID,
                                String strCommunicationTypeID,
                                String strScanDocID,
                                String strFileType,
                                String strFileSize,
                                String strDateSubmitted,
                                String strComments,
                                String strCreatedBy,
                                String strFilerID,
                                String strFilingsID);

        [OperationContract]
        String UpdateSupportingDocumentPIDA(
            String strSupportingDocID,
            String strFilingMethodID,
            String strCommTypeID,
            String strScanDocID,
            String strFileType,
            String strFileSize,
            String strDateSubmitted,
            String strComments,
            String strUserID);

        [OperationContract]
        String DeleteDisclosure(String strFilingID, String strIsSubmitted, String strUserName, String strTransNumber);

        [OperationContract]
        String DeleteSupportingDocument(String strSupportingDocumentID, String strUserName);

        [OperationContract]
        IList<SupportingDocumentsGridContract> GetSupportingDocumentsGridData(String strFilingTransID, string strFilingID);

        [OperationContract]
        IList<PIDAGridContract> GetPIDAGridData(String strFilingTransID);


        [OperationContract]
        IList<TransactionGridContract> GetTransactionsGridData(String strFilingsID, String strPolCalDateID, String strAmended, String strR_Status, String strDateSubmitted, String strFilingCatID, String strTransNumber);

        [OperationContract]
        IList<DocumentTypeContract> GetDocumentTypes(string ApplicationID);

        [OperationContract]
        IList<DisclosureGridContract> GetDisclosureGridData(String strFilerID, String strReportYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strElectionTypeID, String strElectionDateID, String strDiclosureTypeID, String strDisclosurePeriodID);

        [OperationContract]
        IList<TransactionDetailsGridContract> GetTransactionDetailsGridData(String strTransNum, String strSubmitDate, String strFilerID);

        [OperationContract]
        String TransactionHasDetails(String strTransNumber, String filerID);

        [OperationContract]
        String DoesTransNumberExistInTemp(String strTransNumber, String filerID);
        #endregion


        #region "ViewSupportingDocuments"
        [OperationContract]
        IList<ViewSupportingDocumentsGridContract> GetViewSupportingDocumentsGridData(String strFilerID, String strReportYearID, String strDisclosurePeriodID);

        [OperationContract]
        IList<DisclosurePreiodContract> GetDisclosurePeriodsForYearAndFilerID(String strFilerID, String strElectionYearID);

        [OperationContract]
        IList<ElectionYearContract> GetElectionYearForFilerID_VSD(String strFilerID);
        #endregion

        #region "Loan and Liability Reconciliation"

        [OperationContract]
        IList<LoanReceivedGridContract> GetLoanReceivedGridData(String strFilerID);

        [OperationContract]
        IList<LoanPaymentGridContract> GetLoanPaymentGridData(String strFilerID);

        [OperationContract]
        IList<OutstandingLiabilityGridContract> GetOutstandingLiabilityGridData(String strFilerID, int dataToReturn);

        [OperationContract]
        IList<LiabilityLoanForgivenGridContract> GetLiabilityLoanFogivenGridData(String strFilerID, int dataToReturn);

        [OperationContract]
        IList<ExpenditurePaymentGridContract> GetExpenditurePaymentGridData(String strFilerID);

        [OperationContract]
        String Reconcile_Loan(String Schedule_I_TransFilingID, String[] Schedule_J_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User);

        [OperationContract]
        String Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, String[] Schedule_F_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String strUser);

        [OperationContract]
        String GetUncreconciledLoansAndLiabilities(String strFilerID);

        [OperationContract]
        String UpdateRequiredFilerForReconcile(String strFilerID, String strUser);

        [OperationContract]
        String GetMinReconciledOwedAmount(String strTransID, String strOrgAmount, String filerID);

        #endregion

        [OperationContract]
        IList<OriginalAmountContract> GetOutstandingAmountLiabData_Forgiven(String strFilingEntityId, String strtransNumber, String strFilingsId);

        [OperationContract]
        IList<CheckAmendStatusContract> GetAmendStatus(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        String GetExpSubContrTotAmt_LoanDetails(String strTransNumber, String filerID);

        [OperationContract]
        IList<GetEditFlagDataContract> GetEditFlag(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<GetEditFlagDataContract> ValidateFilings(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        Boolean AddViewableColumn(string filer_ID, string created_By);

        [OperationContract]
        IList<ContrInKindPartnersContract> GetLoanReceviedPartnersData(String strFilingTransId, String strFilerId);

        [OperationContract]
        IList<GetEditFlagDataContract> ValidateLoanReceived_Delete(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        String TransferOutStandingLiabilityBalance(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        String GetExpPaymentExistsSchedL(String strTransNumber, String filerID, String strSchedID);

        [OperationContract]
        String GetContributionsExistsSchedM(String strTransNumber, String filerID);

        [OperationContract]
        String GetFilingsSubmittedOrNot(String strFilingsId);

        [OperationContract]
        String GetExpRefundedSchedFTotalAmt(String strTransNumber, String filerID);

        [OperationContract]
        String GetContrRefundedSchedABCTotalAmt(String strTransNumber, String filerID);

        [OperationContract]
        Boolean AddNonItemSetPrefPerFiler(String strFilerId, String strFilingTypeId, String strCreatedBy);

        [OperationContract]
        EFSPDFResponseContract GetEFSPDFBytes(EFSPDFRequestContract objEFSPDFRequestContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetCommEditIETransData(String strTransNumber, String filerID);

        [OperationContract]
        String LiabilityPrevFlngsOrgAutoCreatedExts(String strTransNumber, String strFilingsId, String filerID);

        [OperationContract]
        String GetSchedR_Exists(SchedR_ISExists_Contract objSchedR_ISExists_Contract);

        [OperationContract]
        IList<ImportDisclosureRptsDataContract> GetImportDisclosureRptsData(String txtFilerID, String strReportYear);

        [OperationContract]
        IList<VendorNamesContract> GetVendorNamesData();

        [OperationContract]
        IList<CheckFilingDateContract> GetFilingDateCheckValues(ImportDisclsoureRptsFilingsContract objImportDisclsoureRptsFilingsContract);

        [OperationContract]
        IList<FilingsForFilingCutOffDateContract> GetFilingsIdForUploadData(ImportDisclsoureRptsFilingsContract objImportDisclsoureRptsFilingsContract);

        [OperationContract]
        String GetFilingsExistsorNot(String strFilerId);

        [OperationContract]
        Boolean LoanLiabilityExists(String strFilerId, String strTransNumber, String strLoanLiabilityNumber);

        [OperationContract]
        Boolean AddVendorImportFileIntoTempDatabase(IList<FilingTransactionsContract> lstFilingTransactionsContract, VendorImportDataContract objVendorImportDataContract);

        [OperationContract]
        String GetFilerCommitteeTypeId(String strFilerId);

        [OperationContract]
        IList<ElectionTypeContract> GetElectionTypeForFilerIDForSubmit(String strElectYearID, String strOfficeTypeID, String strCountyID, String strMunicipalityID, String strFilerID);

        [OperationContract]
        IList<ElectionYearContract> GetElectionYearDataForFilerIDForSubmit(String strFilerID);

        [OperationContract]
        IList<DisclosurePreiodContract> GetDisclosurePeriodDataForNoActivity(String strFilerID, String strPolCalDateID, String strElectTypeId);

        [OperationContract]
        IList<MunicipalityContract> GetMunicipalityByOfficeType(String strCountyId, String strOfficeTypeId);

        [OperationContract]
        IList<CountyContract> GetCountyForFilings(string elect_Year_ID, string filer_ID);

        [OperationContract]
        String FilingTransactionOutStandingBalance(String loan_Lib_number, String strFilerId);

        [OperationContract]
        Boolean AddVendorImportFileForSchedA(IList<FilingTransactionsContract> lstFilingTransactionsContract);

        [OperationContract]
        List<EFSPDFResponseContract> GetFileinByteFormat();

        [OperationContract]
        List<EFSPDFResponseContract> GetFileinByteFormatPCF();

        [OperationContract]
        List<EFSPDFResponseContract> GetTemplateinByteFormat();

        [OperationContract]
        List<EFSPDFResponseContract> GetTemplateinByteFormatPCF();

        [OperationContract]
        IList<TransactionTypesContract> GetTransactionTypesForWeeklyClaim();

        [OperationContract]
        IList<FilingTransactionDataContract> GetFilingWeeklyClaimSubmissionData(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<FilingTransactionDataContract> GetWeeklyClaimSubmissionHistoryData(String strFilingTransId);

        [OperationContract]
        string AddWeeklyClaimSubSchedA(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateWeeklyClaimSubSchedA(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean WeeklyClaimSubSubmitTrans(IList<FilingTransactionsTransIDContract> lstFilingTransactionsTransIDContract, String filerID, String strModifiedBy);

        [OperationContract]
        Boolean DeleteWeeklyClaimSubSchedA(String strTransNumber, String strModifiedBy, String filerID);

        [OperationContract]
        IList<FilingTransactionDataContract> GetItemizedWCSTrans(String strFilerId, String strElectionYearId, String strOfficeTypeId, String strElectionTypeId, String strElectionDateId, String strMunicipalityId, String strCuttOffDate);

        [OperationContract]
        Boolean AddWeeklyClaimSubItemizedTrans(IList<FilingTransactionsContract> lstFilingTransactionsContract, String strFilerId, String strElectionYearId, String strOfficeTypeId, String strFilingTypeId, String strElectionTypeId, String strElectionDateId, String strCreatedBy, String strFilingDate);

        [OperationContract]
        IList<DisclosureTypesContract> GetDisclosureTypesDataForPCFB(String strCandCommId, String strElectTypeID);

        [OperationContract]
        IList<ReportSourceContract> GetReportSourceDataSchedS();

        [OperationContract]
        string AddPublic_Fund_Receipts_SchedS(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFlngtrans_PublicFundRecpt(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<PaymentMethodContract> GetPaymentMethodDataForSchedA();

        [OperationContract]
        IList<GetEditFlagDataContract> GetEditFlagPCFDueDate(FilingTransDataContract objFilingTransDataContract);

        [OperationContract]
        IList<GetEditFlagDataContract> GetEditFlagPCFDueDateImport(String filerId, String filingPeriodId, String electId);

        [OperationContract]
        string AddPublic_Fund_Payment_SchedU(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        Boolean UpdateFlngtrans_PublicFundPayment(FilingTransactionsContract objFilingTransactionsContract);

        [OperationContract]
        IList<FilingCutOffDateContract> GetFilingCutOffDateData_PCF_WCS(String strElectYearId, String strElectTypeId, String strOfficeTypeId, String strPolCalMapId);

        [OperationContract]
        IList<FilingTransactionsContract> GetFilingTransSchedR_ChildData(String strTransNumber, String strFilerId);

        [OperationContract]
        IList<FilingTransactionDataContract> GetCommEditIETransData_WCS(String strTransNumber, String filerID);

        [OperationContract]
        IList<PurposeCodeContract> GetPurposeCodeData_PCF();
    }
}
