using System;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class CommunicationTypeContract
    {
        [DataMember]
        public String CommunicationTypeID { get; set; }
        [DataMember]
        public String CommunicationTypeDesc { get; set; }
    }

    [DataContract]
    public class ShowAddressContract
    {
        [DataMember]
        public String AddressId { get; set; }
        [DataMember]
        public String BestContactId { get; set; }
        [DataMember]
        public String BestContractDesc { get; set; }
        [DataMember]
        public String AddressTypeId { get; set; }
        [DataMember]
        public String AddressTypeDesc { get; set; }
        [DataMember]
        public String AddressStreetNumber { get; set; }
        [DataMember]
        public String AddressStreetName { get; set; }
        [DataMember]        
        public String AddressAddress1 { get; set; }
        [DataMember]
        public String AddressAddress2 { get; set; }
        [DataMember]
        public String AddressCity { get; set; }
        [DataMember]
        public String AddressState { get; set; }
        [DataMember]
        public String AddressZip { get; set; }
        [DataMember]
        public String AddressZip4 { get; set; } 
    }

    [DataContract]
    public class ShowContactContract
    {
        [DataMember]
        public String ContractId { get; set; }
        [DataMember]
        public String PersonId { get; set; }
        [DataMember]
        public String ContactTypeId { get; set; }
        [DataMember]
        public String ContactTypeDescription { get; set; }
        [DataMember]
        public String BestContactId { get; set; }
        [DataMember]
        public String BestContract_Desc { get; set; }
        [DataMember]
        public String Phone { get; set; }
        [DataMember]
        public String EmailAddress { get; set; }
        [DataMember]
        public String FAX { get; set; }
        [DataMember]
        public String URL { get; set; }
        [DataMember]
        public String ContactValue { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
    }

    [DataContract]
    public class DepositoryBankInfoContract
    {
        [DataMember]
        public String BankId { get; set; }
        [DataMember]
        public String AddressId { get; set; }
        [DataMember]
        public String CandidateId { get; set; }
        [DataMember]
        public String DepositoryBankName { get; set; }
        [DataMember]
        public String BankAccountTypeId { get; set; }
        [DataMember]
        public String StreetNumber { get; set; }
        [DataMember]
        public String StreetName { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String State { get; set; }
        [DataMember]
        public String Zip { get; set; }
        [DataMember]
        public String Zip4 { get; set; }
        [DataMember]
        public String PersonId { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
    }

    [DataContract]
    public class CandAuthCommitteesContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String CommitteeName { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String RegistrationDate { get; set; }
        [DataMember]
        public String TerminationDate { get; set; }
    }

    [DataContract]
    public class CandidateHeaderDataContract
    {
        [DataMember]
        public String FilerType { get; set; }
        [DataMember]
        public String Office { get; set; }
        [DataMember]
        public String District { get; set; }
        [DataMember]
        public String Municipality { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String CandidateId { get; set; }
        [DataMember]
        public String SSN { get; set; }
        [DataMember]
        public String PoliticalParty { get; set; }
        [DataMember]
        public String RegistrationDate { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String TerminationDate { get; set; }
        [DataMember]
        public String Prefix { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String MiddleName { get; set; }
        [DataMember]
        public String Suffix { get; set; }
    }

    [DataContract]
    public class AddressDataContract
    {
        [DataMember]
        public String AddressId { get; set; }
        [DataMember]
        public String AddressTypeId { get; set; }
        [DataMember]
        public String PersonId { get; set; }
        [DataMember]
        public String BestContactId { get; set; }
        [DataMember]
        public String AddressBusinessName { get; set; }
        [DataMember]
        public String AddressStreetNumber { get; set; }
        [DataMember]
        public String AddressStreetName { get; set; }
        [DataMember]
        public String AddressAddress1 { get; set; }
        [DataMember]
        public String AddressAddress2 { get; set; }
        [DataMember]
        public String AdresssCity { get; set; }
        [DataMember]
        public String AddressState { get; set; }
        [DataMember]
        public String AddressZip { get; set; }
        [DataMember]
        public String AddressZip4 { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
    }

    [DataContract]
    public class AddressTypesContract
    {
        [DataMember]
        public String AddressTypeId { get; set; }
        [DataMember]
        public String AddressTypeDescription { get; set; }
    }

    [DataContract]
    public class BestContactTypesContract
    {
        [DataMember]
        public String BestContactTypeId { get; set; }
        [DataMember]
        public String BestContactTypeDesc { get; set; }
    }

    [DataContract]
    public class ContactTypesContract
    {
        [DataMember]
        public String ContactTypeId { get; set; }
        [DataMember]
        public String ContactTypeDescription { get; set; }
    }

    [DataContract]
    public class BankAccountTypesContract
    {
        [DataMember]
        public String AccountTypeId { get; set; }
        [DataMember]
        public String AccountTypeDesc { get; set; }
    }

    [DataContract]
    public class TreasurerProfileContract
    {
        [DataMember]
        public String TransID { get; set; }
        [DataMember]
        public String PersonID { get; set; }
        [DataMember]
        public String PersonSSN { get; set; }
        [DataMember]
        public String TransRegDate { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String TransTermDate { get; set; }
        [DataMember]
        public String PersonPrefix { get; set; }
        [DataMember]
        public String PersonFirstName { get; set; }
        [DataMember]
        public String PersonMiddleName { get; set; }
        [DataMember]
        public String PersonLastName { get; set; }
        [DataMember]
        public String PersonSuffix { get; set; }
    }

    [DataContract]
    public class TreasurerCommitteeInformationContract
    {
        [DataMember]
        public String CommID { get; set; }
        [DataMember]
        public String FilerID { get; set; }
        [DataMember]
        public String PersonID { get; set; }
        [DataMember]
        public String CommitteeName { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String CommitteeRegDate { get; set; }
        [DataMember]
        public String CommitteeTermDate { get; set; }
        [DataMember]
        public String CommitteeTypeDesc { get; set; }
    }

    [DataContract]
    public class TreasAssistantInformationContract
    {
        [DataMember]
        public String PersonPrefix { get; set; }
        [DataMember]
        public String PersonFirstName { get; set; }
        [DataMember]
        public String PersonMiddleName { get; set; }
        [DataMember]
        public String PersonLastName { get; set; }
        [DataMember]
        public String PersonSuffix { get; set; }
        [DataMember]
        public String PersonID { get; set; }
    }

    [DataContract]
    public class TreasurerHistoryContract
    {
        [DataMember]
        public String PersonPrefix { get; set; }
        [DataMember]
        public String PersonFirstName { get; set; }
        [DataMember]
        public String PersonMiddleName { get; set; }
        [DataMember]
        public String PersonLastName { get; set; }
        [DataMember]
        public String PersonSuffix { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String RegDate { get; set; }
        [DataMember]
        public String TermDate { get; set; }
        [DataMember]
        public String PersonID { get; set; }
    }

    [DataContract]
    public class TreasAdditionalCommitteeContactContract
    {
        [DataMember]
        public String PersonPrefix { get; set; }
        [DataMember]
        public String PersonFirstName { get; set; }
        [DataMember]
        public String PersonMiddleName { get; set; }
        [DataMember]
        public String PersonLastName { get; set; }
        [DataMember]
        public String PersonSuffix { get; set; }
    }

    [DataContract]
    public class TreasDepositoryBankInformationContract
    {
        [DataMember]
        public String BankID { get; set; }
        [DataMember]
        public String BankName { get; set; }
        [DataMember]
        public String AddrNum { get; set; }
        [DataMember]
        public String AddrStrName { get; set; }
        [DataMember]
        public String AddrCity { get; set; }
        [DataMember]
        public String AddrState { get; set; }
        [DataMember]
        public String AddrZip { get; set; }
        [DataMember]
        public String AddrZip4 { get; set; }
        [DataMember]
        public String ADDR_ID { get; set; }
        [DataMember]
        public String PERSON_ID { get; set; }
        [DataMember]
        public String COMM_ID { get; set; }
        [DataMember]
        public String BankAccountTypeID { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        
        
    }

    [DataContract]
    public class TreasCandidateSupportOpposeContract
    {
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeDesc { get; set; }
        [DataMember]
        public String DistID { get; set; }
        [DataMember]
        public String PersonFirstName { get; set; }
        [DataMember]
        public String PersonMiddleName { get; set; }
        [DataMember]
        public String PersonLastName { get; set; }
        [DataMember]
        public String SupposeOppose { get; set; }
        [DataMember]
        public String AuthorizedDate { get; set; }
        [DataMember]
        public String NonExpenditureDate { get; set; }
    }

    [DataContract]
    public class TreasAuthorizedToSignCheckContract
    {
        [DataMember]
        public String PersonPrefix { get; set; }
        [DataMember]
        public String PersonFirstName { get; set; }
        [DataMember]
        public String PersonMiddleName { get; set; }
        [DataMember]
        public String PersonLastName { get; set; }
        [DataMember]
        public String PersonSuffix { get; set; }
        [DataMember]
        public String AuthSignedID { get; set; }
        [DataMember]
        public String PersonID { get; set; }
        [DataMember]
        public String StartDate { get; set; }
        [DataMember]
        public String EndDate { get; set; }
        [DataMember]
        public String Status { get; set; }
    }

    [DataContract]
    public class TreasBallotIssuesContract
    {
        [DataMember]
        public String BallotIssues { get; set; }
        [DataMember]
        public String SupposeOppose { get; set; }
    }

    [DataContract]
    public class SubTreasurerPersonContract
    {
        [DataMember]
        public String TreasurerId { get; set; }
        [DataMember]
        public String SubTreasurerId { get; set; }
        [DataMember]
        public String PersonId { get; set; }
        [DataMember]
        public String StateDate { get; set; }
        [DataMember]
        public String RStatus { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String MiddleName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String Suffix { get; set; }
        [DataMember]
        public String Preffix { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
    }

    [DataContract]
    public class FilingTransactionDataContract
    {
        [DataMember]
        public String FilingSchedId { get; set; }
        [DataMember]
        public String FilingsId { get; set; }
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String ReportYear { get; set; }
        [DataMember]
        public String ContributorTypeId { get; set; }
        [DataMember]
        public String ContributorTypeDesc { get; set; }
        [DataMember]
        public String ContributionTypeId { get; set; }
        [DataMember]
        public String PaymentTypeId { get; set; }
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String ReceiptCodeId { get; set; }
        [DataMember]
        public String ReceiptCodeDesc { get; set; }
        [DataMember]
        public String SchedDate { get; set; }
        [DataMember]
        public String FilingSchedDesc { get; set; }
        [DataMember]
        public String FilingEntityName { get; set; }
        [DataMember]
        public String FilingFirstName { get; set; }
        [DataMember]
        public String FilingMiddleName { get; set; }
        [DataMember]
        public String FilingLastName { get; set; }
        [DataMember]
        public String FilingStreetNumber { get; set; }
        [DataMember]
        public String FilingStreetName { get; set; }
        [DataMember]
        public String FilingCity { get; set; }
        [DataMember]
        public String FilingState { get; set; }
        [DataMember]
        public String FilingZip { get; set; }
        [DataMember]
        public String FilingCountry { get; set; }
        [DataMember]
        public String PaymentTypeDesc { get; set; }
        [DataMember]
        public String PayNumber { get; set; }
        [DataMember]
        public String OriginalAmount { get; set; }
        [DataMember]
        public String ReceiptTypeDesc { get; set; }
        [DataMember]
        public String TransferTypeDesc { get; set; }
        [DataMember]
        public String ContributionTypeDesc { get; set; }
        [DataMember]
        public String PurposeCodeDesc { get; set; }
        [DataMember]
        public String OriginalDate { get; set; }
        [DataMember]
        public String LoanerCode { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String Office { get; set; }
        [DataMember]
        public String District { get; set; }
        [DataMember]
        public String RLiability { get; set; }
        [DataMember]
        public String RSubcontractor { get; set; }
        [DataMember]
        public String TransExplanation { get; set; }
        [DataMember]
        public String CreatedDate { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
        [DataMember]
        public String OwedAmount { get; set; }
        [DataMember]
        public String RItemized { get; set; }
        [DataMember]
        public String CountyID { get; set; }
        [DataMember]
        public String CountyDesc { get; set; }
        [DataMember]
        public String MunicipalityID { get; set; }
        [DataMember]
        public String MunicipalityDesc { get; set; }
        [DataMember]
        public String LoanerCodeID { get; set; }
        [DataMember]
        public String SubmissionDate { get; set; }
        [DataMember]
        public String RAmend { get; set; }
        [DataMember]
        public String RStatus { get; set; }
        [DataMember]
        public String TreasurerFirstName { get; set; }
        [DataMember]
        public String TreasurerLastName { get; set; }
        [DataMember]
        public String TreasurerMiddleName { get; set; }
        [DataMember]
        public String TreasurerOccuptaion { get; set; }
        [DataMember]
        public String TreasurerEmployer { get; set; }
        [DataMember]
        public String TreasurerStreetAddress { get; set; }
        [DataMember]
        public String TreasurerCity { get; set; }
        [DataMember]
        public String TreasurerState { get; set; }
        [DataMember]
        public String TreasurerZip { get; set; }
        [DataMember]
        public String ContributorOccupation { get; set; }
        [DataMember]
        public String ContributorEmployer { get; set; }
        [DataMember]
        public String IEDescription { get; set; }
        [DataMember]
        public String CandBallotPropReference { get; set; }
        [DataMember]
        public String IESupported { get; set; }
        [DataMember]
        public String AddrId { get; set; }
        [DataMember]
        public String TreasId { get; set; }
        [DataMember]
        public String IEType { get; set; }
        [DataMember]
        public String TreasurerName { get; set; }
        [DataMember]
        public String ContributorName { get; set; }
        [DataMember]
        public String PurposeCodeId { get; set; }
        [DataMember]
        public String Increased { get; set; }
        [DataMember]
        public String Decreased { get; set; }
        [DataMember]
        public String Balance { get; set; }
        [DataMember]
        public String DateIncurredOrgAmtId { get; set; }
        [DataMember]
        public String LoanLiablityNumber { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }
        [DataMember]
        public String DBStatus { get; set; }
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String CandidateCommitteeName { get; set; }
        [DataMember]
        public String FilerType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ReportType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosureType { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
        [DataMember]
        public String Office_Desc { get; set; }
        [DataMember]
        public String Original_Sched_Date { get; set; }
        [DataMember]
        public String RClaim { get; set; }
        [DataMember]
        public String InDistrict { get; set; }
        [DataMember]
        public String RMinor { get; set; }
        [DataMember]
        public String RVendor { get; set; }
        [DataMember]
        public String RLobbyist { get; set; }
        [DataMember]
        public String TreaAddress { get; set; }
        [DataMember]
        public String TreaAddr1 { get; set; }
        [DataMember]
        public String TreaCity { get; set; }
        [DataMember]
        public String TreaState { get; set; }
        [DataMember]
        public String TreaZipCode { get; set; }
        [DataMember]
        public String CommTypeID { get; set; }
        [DataMember]
        public String RContributions { get; set; }
        [DataMember]
        public String RecordType { get; set; }
        [DataMember]
        public String RIESupported { get; set; }
        [DataMember]
        public String RSupportOppose { get; set; }
    }

    [DataContract]
    public class FilingTransDataContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String CommitteeId { get; set; }
        [DataMember]
        public String ReportYearId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String ReportYear { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosureType { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
        [DataMember]
        public String CutOffDate { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
        [DataMember]
        public String FilingSchedID { get; set; }
        [DataMember]
        public String FilingTransID { get; set; }
        [DataMember]
        public String SchedName { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
        [DataMember]
        public String Loan_Lib_Num { get; set; }
        [DataMember]
        public String Created_By { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String MunicipalityID { get; set; }
        [DataMember]
        public String CommTypeId { get; set; }
        [DataMember]
        public String LabelId { get; set; }
    }

    [DataContract]
    public class ContributionTypeContract
    {
        [DataMember]
        public String ContributionTypeId { get; set; }
        [DataMember]
        public String ContributionTypeDesc { get; set; }
        [DataMember]
        public String ContributionTypeAbbrev { get; set; }
    }

    [DataContract]
    public class ContributorNameContract
    {
        [DataMember]
        public String ContributorTypeId { get; set; }
        [DataMember]
        public String ContributorTypeDesc { get; set; }
        [DataMember]
        public String ContributorTypeAbbrev { get; set; }
    }

    [DataContract]
    public class DisclosurePreiodContract
    {
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String FilingDesc { get; set; }
        [DataMember]
        public String FilingAbbrev { get; set; }
    }

    [DataContract]
    public class ElectionDateContract
    {
        [DataMember]
        public String ElectId { get; set; }
        [DataMember]
        public String ElectDate { get; set; }
    }

    [DataContract]
    public class FilerCommitteeContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String CommitteeId { get; set; }
        [DataMember]
        public String CommitteeName { get; set; }
        [DataMember]
        public String OfficeId { get; set; }
        [DataMember]
        public String personID { get; set; }
        [DataMember]
        public String TreasurerId { get; set; }
        [DataMember]
        public String CommTypeId { get; set; }
        [DataMember]
        public String OfficTypeID { get; set; }
        [DataMember]
        public String OfficeTypeDesc { get; set; }
    }

    [DataContract]
    public class PaymentMethodContract
    {
        [DataMember]
        public String PaymentTypeId { get; set; }
        [DataMember]
        public String PaymentTypeDesc { get; set; }
        [DataMember]
        public String PaymentTypeAbbrev { get; set; }
    }

    [DataContract]
    public class PurposeCodeContract
    {
        [DataMember]
        public String PurposeCodeId { get; set; }
        [DataMember]
        public String PurposeCodeDesc { get; set; }
        [DataMember]
        public String PurposeCodeAbbrev { get; set; }
    }

    [DataContract]
    public class ReceiptCodeContract
    {
        [DataMember]
        public String ReceiptCodeId { get; set; }
        [DataMember]
        public String ReceiptCodeDesc { get; set; }
        [DataMember]
        public String ReceiptCodeAbbrev { get; set; }
    }

    [DataContract]
    public class ReceiptTypeContract
    {
        [DataMember]
        public String ReceiptTypeId { get; set; }
        [DataMember]
        public String ReceiptTypeDesc { get; set; }
        [DataMember]
        public String ReceiptTypeAbbrev { get; set; }
    }

    [DataContract]
    public class TransferTypeContract
    {
        [DataMember]
        public String TransferTypeId { get; set; }
        [DataMember]
        public String TransferTypeDesc { get; set; }
        [DataMember]
        public String TransferTypeAbbrev { get; set; }
    }

    [DataContract]
    public class ElectionYearContract
    {
        [DataMember]
        public String ElectionYearId { get; set; }
        [DataMember]
        public String ElectionYearValue { get; set; }
    }

    [DataContract]
    public class ElectionTypeContract
    {
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String ElectionTypeDesc { get; set; }
    }

    [DataContract]
    public class FilingCutOffDateContract
    {
        [DataMember]
        public String PoliticalCalDateId { get; set; }
        [DataMember]
        public String PoliticalCalLabelId { get; set; }
        [DataMember]
        public String FilingDueDate { get; set; }
        [DataMember]
        public String CutOffDate { get; set; }
        [DataMember]
        public String PriGenDate { get; set; }
    }

    [DataContract]
    public class ContributorTypesContract
    {
        [DataMember]
        public String ContributorTypeId { get; set; }
        [DataMember]
        public String ContributoryTypeDesc { get; set; }
    }

    [DataContract]
    public class TransactionTypesContract
    {
        [DataMember]
        public String FilingSchedId { get; set; }
        [DataMember]
        public String FilingSchedDesc { get; set; }
        [DataMember]
        public String FilingSchedAbbrev { get; set; }
    }

    [DataContract]
    public class DisclosureTypesContract
    {
        [DataMember]
        public String DisclosureTypeId { get; set; }
        [DataMember]
        public String DisclosureTypeDesc { get; set; }
        [DataMember]
        public String DisclosureSubTypeDesc { get; set; }
    }

    [DataContract]
    public class FilingTransactionsContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String FilingEntId { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String ElectYearId { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String FilingSchedId { get; set; }
        [DataMember]
        public String SchedDate { get; set; }
        [DataMember]
        public String FlngEntName { get; set; }
        [DataMember]
        public String OrgDate { get; set; }
        [DataMember]
        public String RBankLoan { get; set; }
        [DataMember]
        public String ReceiptTypeId { get; set; }
        [DataMember]
        public String ReceiptCodeId { get; set; }
        [DataMember]
        public String FlngEntFirstName { get; set; }
        [DataMember]
        public String FlngEntLastName { get; set; }
        [DataMember]
        public String FlngEntMiddleName { get; set; }
        [DataMember]
        public String DistOffCandBalProp { get; set; }
        [DataMember]
        public String FlngEntStrNum { get; set; }
        [DataMember]
        public String FlngEntStrName { get; set; }
        [DataMember]
        public String FlngEntCity { get; set; }
        [DataMember]
        public String FlngEntState { get; set; }
        [DataMember]
        public String FlngEntZip { get; set; }
        [DataMember]
        public String FlngEntZip4 { get; set; }
        [DataMember]
        public String FlngEntCountry { get; set; }
        [DataMember]
        public String TransferTypeId { get; set; }
        [DataMember]
        public String OrgAmt { get; set; }
        [DataMember]
        public String LiabilityOrgAmt { get; set; }
        [DataMember]
        public String LiabilityOwedAmt { get; set; }
        [DataMember]
        public String LiabilityPartialAmt { get; set; }
        [DataMember]
        public String ContributorTypeId { get; set; }
        [DataMember]
        public String ContributionTypeId { get; set; }
        [DataMember]
        public String PurposeCodeId { get; set; }
        [DataMember]
        public String PurposeCodeDesc { get; set; }
        [DataMember]
        public String PaymentTypeId { get; set; }
        [DataMember]
        public String PayNumber { get; set; }
        [DataMember]
        public String LoanOtherId { get; set; }
        [DataMember]
        public String TransCode { get; set; }
        [DataMember]
        public String TransDesc { get; set; }
        [DataMember]
        public String PayDate { get; set; }
        [DataMember]
        public String OwedAmt { get; set; }
        [DataMember]
        public String RLiability { get; set; }
        [DataMember]
        public String RSubcontractor { get; set; }
        [DataMember]
        public String RItemized { get; set; }
        [DataMember]
        public String RLiabilityExists { get; set; }
        [DataMember]
        public String TransExplanation { get; set; }
        [DataMember]
        public String LiabilityTransExplanation { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
        [DataMember]
        public String OtherTransExplanation { get; set; }
        [DataMember]
        public String OtherFilingSchedId { get; set; }
        [DataMember]
        public String OtherAmount { get; set; }
        [DataMember]
        public String MunicipalityID { get; set; }
        [DataMember]
        public String OfficeID { get; set; }
        [DataMember]
        public String DistrictID { get; set; }
        [DataMember]
        public String RAmend { get; set; }
        [DataMember]
        public String SubmissionDate { get; set; }
        [DataMember]
        public String TreasId { get; set; }
        [DataMember]
        public String AddrId { get; set; }
        [DataMember]
        public String TreasurerOccupation { get; set; }
        [DataMember]
        public String TreasurerEmployer { get; set; }
        [DataMember]
        public String TreasurerStreetAddress { get; set; }
        [DataMember]
        public String TreasurerCity { get; set; }
        [DataMember]
        public String TreasurerState { get; set; }
        [DataMember]
        public String TreasurerZip { get; set; }
        [DataMember]
        public String ContributorOccupation { get; set; }
        [DataMember]
        public String ContributorEmployer { get; set; }
        [DataMember]
        public String IEDescription { get; set; }
        [DataMember]
        public String CandBallotPropReference { get; set; }
        [DataMember]
        public String R_Supported { get; set; }
        [DataMember]
        public String PersonId { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
        [DataMember]
        public String DateIncurredOrgAmtId { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
        [DataMember]
        public String ResigTermTypeId { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String Loan_Lib_Number { get; set; }
        [DataMember]
        public String TransMapping { get; set; }
        [DataMember]
        public String IsAmtChanged { get; set; }
        [DataMember]
        public String TransNumberOrg { get; set; }
        [DataMember]
        public String IsExpSubcontractor { get; set; }
        [DataMember]
        public String IsExpPartialPay { get; set; }
        [DataMember]
        public String IsExistingLiab { get; set; }
        [DataMember]
        public String IsLiabPartialForgiven { get; set; }
        [DataMember]
        public String ParentFilingEntityId { get; set; }
        [DataMember]
        public String RIEIncluded { get; set; }
        [DataMember]
        public String RIESupported { get; set; }
        [DataMember]
        public String ExistsLiabTransNumber { get; set; }
        [DataMember]
        public String FilingsId { get; set; }
        [DataMember]
        public String RParent { get; set; }
        [DataMember]
        public String ContributorTypeDesc { get; set; }
        [DataMember]
        public String PaymentTypeDesc { get; set; }
        [DataMember]
        public String Unique_Num { get; set; }
        [DataMember]
        public String IsClaim { get; set; }
        [DataMember]
        public String InDistrict { get; set; }
        [DataMember]
        public String Minor { get; set; }
        [DataMember]
        public String Vendor { get; set; }
        [DataMember]
        public String Lobbyist { get; set; }
        [DataMember]
        public String CommTypeID { get; set; }
        [DataMember]
        public String RContributions { get; set; }
        [DataMember]
        public String SchedID { get; set; }
        [DataMember]
        public String SupportOppose { get; set; }
    }

    [DataContract]
    public class OfficeTypeContract
    {
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String OfficeTypeDesc { get; set; }
    }

    [DataContract]
    public class CountyContract
    {
        [DataMember]
        public String CountyId { get; set; }
        [DataMember]
        public String CountyDesc { get; set; }
    }

    [DataContract]
    public class MunicipalityContract
    {
        [DataMember]
        public String MunicipalityId { get; set; }
        [DataMember]
        public String MunicipalityDesc { get; set; }
    }

    [DataContract]
    public class AutoCompFLNameAddressContract
    {
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String FilingEntityName { get; set; }
        [DataMember]
        public String FilingEntityFirstName { get; set; }
        [DataMember]
        public String FilingEntityMiddleName { get; set; }
        [DataMember]
        public String FilingEntityLastName { get; set; }
        [DataMember]
        public String FilingEntityStreetNum { get; set; }
        [DataMember]
        public String FilingEntityStreetName { get; set; }
        [DataMember]
        public String FilingEntityCity { get; set; }
        [DataMember]
        public String FilingEntityState { get; set; }
        [DataMember]
        public String FilingEntityZip { get; set; }
        [DataMember]
        public String FilingEntityZip4 { get; set; }
        [DataMember]
        public String FilingEntityCountry { get; set; }
        [DataMember]
        public String FilingEntityNameAndAddress { get; set; }
    }

    [DataContract]
    public class ViewableColumnContract
    {
        [DataMember]
        public String ViewableFieldID { get; set; }
        [DataMember]
        public String UniqueID { get; set; }
        [DataMember]
        public String ColumnName { get; set; }
        [DataMember]
        public String Viewable { get; set; }
    }

    [DataContract]
    public class ContrInKindPartnersContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String PartnershipName { get; set; }
        [DataMember]
        public String PartnerFirstName { get; set; }
        [DataMember]
        public String PartnerMiddleName { get; set; }
        [DataMember]
        public String PartnerLastName { get; set; }
        [DataMember]
        public String PartnerStreetNo { get; set; }
        [DataMember]
        public String PartnerStreetName { get; set; }
        [DataMember]
        public String PartnerCity { get; set; }
        [DataMember]
        public String PartnerState { get; set; }
        [DataMember]
        public String PartnerZip5 { get; set; }
        [DataMember]
        public String PartnershipCountry { get; set; }
        [DataMember]
        public String PartnerAmountAttributed { get; set; }
        [DataMember]
        public String PartnerExplanation { get; set; }
        [DataMember]
        public String RUnitemzied { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }
        [DataMember]
        public String TreasurerOccupation { get; set; }
        [DataMember]
        public String TreasurerEmployer { get; set; }
        [DataMember]
        public String TreaAddress { get; set; }
        [DataMember]
        public String TreaAddr1 { get; set; }
        [DataMember]
        public String TreaCity { get; set; }
        [DataMember]
        public String TreaState { get; set; }
        [DataMember]
        public String TreaZipCode { get; set; }
        [DataMember]
        public String CommTypeID { get; set; }
        [DataMember]
        public String RContributions { get; set; }
    }

    [DataContract]
    public class LoanerCodeContract
    {
        [DataMember]
        public String LoanerID { get; set; }
        [DataMember]
        public String LoanerDesc { get; set; }
    }

    [DataContract]
    public class OutstandingLiabilityContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String PayeeName { get; set; }
        [DataMember]
        public String DateIncurred { get; set; }
        [DataMember]
        public String OriginalAmount { get; set; }
        [DataMember]
        public String OutstandingAmount { get; set; }
        [DataMember]
        public String CreditorName { get; set; }
        [DataMember]
        public String FlngEntCountry { get; set; }
        [DataMember]
        public String LiabilityStreetName { get; set; }
        [DataMember]
        public String LiabilityCity { get; set; }
        [DataMember]
        public String LiabilityState { get; set; }
        [DataMember]
        public String LiabilityZipCode { get; set; }
        [DataMember]
        public String LiabilityAmount { get; set; }
        [DataMember]
        public String LiabilityExplanation { get; set; }
        [DataMember]
        public String FilingEntityNameAndAddress { get; set; }
    }

    [DataContract]
    public class DateIncurredContract
    {
        [DataMember]
        public String DateIncurredId { get; set; }
        [DataMember]
        public String DateIncurredValue { get; set; }
        [DataMember]
        public String AmountLiability { get; set; }
        [DataMember]
        public String OutstandingAmount { get; set; }
    }

    [DataContract]
    public class OriginalAmountContract
    {
        [DataMember]
        public String OriginalAmountId { get; set; }
        [DataMember]
        public String OutstandingAmount { get; set; }
    }

    [DataContract]
    public class ExpPaymentLiabilityContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String PayeeName { get; set; }
        [DataMember]
        public String DateIncurred { get; set; }
        [DataMember]
        public String OrignalAmount { get; set; }
        [DataMember]
        public String OutstandingAmount { get; set; }
        [DataMember]
        public String CreditorName { get; set; }
        [DataMember]
        public String LiabilityStreetName { get; set; }
        [DataMember]
        public String LiabilityCity { get; set; }
        [DataMember]
        public String LiabilityState { get; set; }
        [DataMember]
        public String LiabilityZipCode { get; set; }
        [DataMember]
        public String LiabilityExplanation { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
    }

    [DataContract]
    public class GetSearchForScheduledIContract
    {
        [DataMember]
        public String Date { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String FILING_TRANS_ID { get; set; }
        [DataMember]
        public String Original_Amt { get; set; }
        [DataMember]
        public String Trans_Number { get; set; }
        [DataMember]
        public String Loan_Lib_Number { get; set; }
        [DataMember]
        public String flng_Ent_FirstName { get; set; }
        [DataMember]
        public String flng_Ent_MiddleName { get; set; }
        [DataMember]
        public String flng_Ent_LastName { get; set; }
        [DataMember]
        public String filer_Id { get; set; }
    }

    [DataContract]
    public class AuthorizedToSignCheckContract
    {
        [DataMember]
        public String CommID { get; set; }
        [DataMember]
        public String StartDate { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String EndDate { get; set; }
        [DataMember]
        public String Prefix { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String MiddleName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String Suffix { get; set; }
        [DataMember]
        public byte[] Signature { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
    }

    [DataContract]
    public class ExpPaymentTransIdPopUpSchedFContract
    {
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String FilingSchedId { get; set; }
        [DataMember]
        public String ScheduleDate { get; set; }
        [DataMember]
        public String OrgAmount { get; set; }
    }

    [DataContract]
    public class ExpPaymentOriginalNameContract
    {
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String FilingEntityName { get; set; }
    }

    [DataContract]
    public class ExpPaymentOriginalAmountContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String OriginalAmount { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
    }

    [DataContract]
    public class ExpPaymentOriginalExpenseDateContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String OriginalExpenseDate { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
    }

    [DataContract]
    public class ValidateFilerInfoContract
    {
        [DataMember]
        public String FilerID { get; set; }
        [DataMember]
        public String RoleID { get; set; }
        [DataMember]
        public String Name { get; set; }
    }

    [DataContract]
    public class DistrictContract
    {
        [DataMember]
        public String District_ID { get; set; }
        [DataMember]
        public String Parent_District_ID { get; set; }
    }

    [DataContract]
    public class OfficeContract
    {
        [DataMember]
        public String OfficeId { get; set; }
        [DataMember]
        public String OfficeDesc { get; set; }
    }

    [DataContract]
    public class AutoCompleteSchedRContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String Org_Amt { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String MiddleName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String Office_ID { get; set; }
        [DataMember]
        public String Dist_ID { get; set; }
    }

    [DataContract]
    public class InLieuOfStatementNonItemContract
    {
        [DataMember]
        public String FilingsId { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
    }

    [DataContract]
    public class AddInLieuOfStatementContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String FilingCategoryId { get; set; }
        [DataMember]
        public String ElectYearId { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String CountyId { get; set; }
        [DataMember]
        public String MunicipalityId { get; set; }
        [DataMember]
        public String ResigTermTypeId { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
    }

    [DataContract]
    public class PersonNameAndTreasurerDataContract
    {
        [DataMember]
        public String PersonName { get; set; }
        [DataMember]
        public String TreasId { get; set; }
    }

    [DataContract]
    public class FilerInfoContract
    {
        [DataMember]
        public String Trans_Cand_ID { get; set; }
        [DataMember]
        public String Filer_ID { get; set; }
        [DataMember]
        public String Cand_Comm_ID { get; set; }
        [DataMember]
        public String Cand_Comm_Name { get; set; }
        [DataMember]
        public String PersonID { get; set; }
        [DataMember]
        public String Name { get; set; }
    }

    [DataContract]
    public class NonItemIETreasurerContract
    {
        [DataMember]
        public String PersonId { get; set; }
        [DataMember]
        public String AddressId { get; set; }
        [DataMember]
        public String TreasurerName { get; set; }
        [DataMember]
        public String TreasurerOccupation { get; set; }
        [DataMember]
        public String TreasurerEmployer { get; set; }
        [DataMember]
        public String TreasurerStreetAddress { get; set; }
        [DataMember]
        public String TreasurerCity { get; set; }
        [DataMember]
        public String TreasurerState { get; set; }
        [DataMember]
        public String TreasurerZip { get; set; }
        [DataMember]
        public String TreasurerCountry { get; set; }
    }

    [DataContract]
    public class FilingMthodContract
    {
        [DataMember]
        public String FilingMethodId { get; set; }
        [DataMember]
        public String FilingMethodDesc { get; set; }
    }

    [DataContract]
    public class NonItemCampaignMaterialContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String FilingCategoryId { get; set; }
        [DataMember]
        public String ElectYearId { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String CountyId { get; set; }
        [DataMember]
        public String MunicipalityId { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
        [DataMember]
        public String FilingMethodId { get; set; }
        [DataMember]
        public String CampaignMaterialDesc { get; set; }
        [DataMember]
        public String CampMatrFileType { get; set; }
        [DataMember]
        public String CampMatrFileSize { get; set; }
        [DataMember]
        public String SacnDocId { get; set; }
        [DataMember]
        public String RCampMatr { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
    }

    [DataContract]
    public class NonItemCampaignMaterialDataContract
    {
        [DataMember]
        public String CampaignMaterialId { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
        [DataMember]
        public String FilingMethodId { get; set; }
        [DataMember]
        public String FilingMethodDesc { get; set; }
        [DataMember]
        public String CampaignMaterialDesc { get; set; }
        [DataMember]
        public String CampMatrFileType { get; set; }
        [DataMember]
        public String CampMatrFileSize { get; set; }
        [DataMember]
        public String SacnDocId { get; set; }
        [DataMember]
        public String RCampMatr { get; set; }
        [DataMember]
        public String RAmended { get; set; }
        [DataMember]
        public String CreatedDate { get; set; }
    }

    //====CABINET CODE======CAMPAIGN MATERIAL==============CABINET CODE============
    [DataContract]
    public class PIDAReturnVal
    {
        [DataMember]
        public String TokenID { get; set; }
        [DataMember]
        public String RepositoryID { get; set; }
        [DataMember]
        public String CabinetID { get; set; }
        [DataMember]
        public String ManagerID { get; set; }
        [DataMember]
        public String ExtensionID { get; set; }
        [DataMember]
        public String ExtensionName { get; set; }
        [DataMember]
        public String TabID { get; set; }
        [DataMember]
        public String TemplateID { get; set; }
        [DataMember]
        public String DocumentID { get; set; }
        [DataMember]
        public String FolderID { get; set; }
        [DataMember]
        public String Extension { get; set; }
        [DataMember]
        public String FormattedFileSize { get; set; }
        [DataMember]
        public String Keyword { get; set; }
    }

    [DataContract]
    public class PIDADownloadObject
    {
        [DataMember]
        public Byte[] FileByte { get; set; }
        [DataMember]
        public String FileName { get; set; }

    }

    [DataContract]
    public class DocumentInfoData
    {
        [DataMember]
        public String Extension { get; set; }
        [DataMember]
        public String FormattedFileSize { get; set; }
        [DataMember]
        public String Keyword { get; set; }
    }

    [DataContract]    
    public class DocumentIDContract
    {
        [DataMember]
        public String strCampMatrFileName { get; set; }
        [DataMember]
        public Byte[] fileBytes { get; set; }
        [DataMember]
        public String strCampMatrFilerId { get; set; }
        [DataMember]
        public String FolderFilerId { get; set; }
        [DataMember]
        public String FolderElectionYear { get; set; }
        [DataMember]
        public String FolderDisclosurePeriod { get; set; }
        [DataMember]
        public String FileExtension { get; set; }
        [DataMember]
        public String PageName { get; set; }
    }

    [DataContract]
    public class UploadFileNTDriveContract
    {
        [DataMember]
        public String CampMatrFileName { get; set; }
        [DataMember]
        public Byte[] FileBytes { get; set; }
        [DataMember]
        public String FilerIdNTDrive { get; set; }
        [DataMember]
        public String ElectionYearNTDrive { get; set; }
        [DataMember]
        public String DisclosurePeriodNTDrive { get; set; }
    }
    //====CABINET CODE======CAMPAIGN MATERIAL==============CABINET CODE============

    [DataContract]
    public class FilingDatesOffCycleContract
    {
        [DataMember]
        public String FilingDateId { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
    }

    [DataContract]
    public class ResigTermTypeContract
    {
        [DataMember]
        public String ResigTermTypeId { get; set; }
        [DataMember]
        public String ResigTermTypeDesc { get; set; }
        [DataMember]
        public String FilingsId { get; set; }
    }

    [DataContract]
    public class LiabilityDetailsContract
    {
        [DataMember]
        public String FilingTransId { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String TransactionType { get; set; }
        [DataMember]
        public String ContributorCode { get; set; }
        [DataMember]
        public String FilingEntityName { get; set; }
        [DataMember]
        public String FilingFirstName { get; set; }
        [DataMember]
        public String FilingMiddleName { get; set; }
        [DataMember]
        public String FilingLastName { get; set; }
        [DataMember]
        public String FilingStreetName { get; set; }
        [DataMember]
        public String FilingCity { get; set; }
        [DataMember]
        public String FilingState { get; set; }
        [DataMember]
        public String FilingZip { get; set; }
        [DataMember]
        public String FilingCountry { get; set; }
        [DataMember]
        public String PayNumber { get; set; }
        [DataMember]
        public String PaymentType { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String OutstandingAmount { get; set; }
        [DataMember]
        public String RecieptType { get; set; }
        [DataMember]
        public String TransferType { get; set; }
        [DataMember]
        public String ContributionType { get; set; }
        [DataMember]
        public String PurposeCode { get; set; }
        [DataMember]
        public String RecieptCdoe { get; set; }
        [DataMember]
        public String OriginalDate { get; set; }
        [DataMember]
        public String LoanerCode { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String Office { get; set; }
        [DataMember]
        public String District { get; set; }
        [DataMember]        
        public String TransExplanation { get; set; }
        [DataMember]
        public String RItemized { get; set; }
        [DataMember]
        public String CountId { get; set; }
        [DataMember]
        public String County { get; set; }
        [DataMember]
        public String MunicipalityId { get; set; }
        [DataMember]
        public String Municipality { get; set; }
        [DataMember]
        public String CreatedDate { get; set; }
    }

    #region "ViewAllDisclosures"

    [DataContract]
    public class CampaignMaterialsContract
    {
        [DataMember]
        public String CampaignMaterialID { get; set; }
        [DataMember]
        public String FilingMethodID { get; set; }
        [DataMember]
        public String ScanDocID { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
        [DataMember]
        public String FilingMethodDesc { get; set; }
        [DataMember]
        public String CampaignMaterialDesc { get; set; }
        [DataMember]
        public String FileSize { get; set; }
        [DataMember]
        public String FileType { get; set; }
        [DataMember]
        public String CreatedDate { get; set; }
        [DataMember]
        public String CampaignMaterialAvailable { get; set; }
    }

    [DataContract]
    public class SupportingDocumentsGridContract
    {
        [DataMember]
        public String SupportingDocID { get; set; }
        [DataMember]
        public String ScanDocID { get; set; }
        [DataMember]
        public String DateReceived { get; set; }
        [DataMember]
        public String DocumentType { get; set; }
        [DataMember]
        public String FileType { get; set; }
        [DataMember]
        public String FileSize { get; set; }
        [DataMember]
        public String FilingMethod { get; set; }
    }

    [DataContract]
    public class PIDAGridContract
    {
        [DataMember]
        public String SupportingDocID { get; set; }
        [DataMember]
        public String ScanDocID { get; set; }
        [DataMember]
        public String CommunicationTypeID { get; set; }
        [DataMember]
        public String FileType { get; set; }
        [DataMember]
        public String FileSize { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
        [DataMember]
        public String CommunicationType { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String SubmittedBy { get; set; }
    }


    [DataContract]
    public class TransactionGridContract
    {
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String FilingSchedID { get; set; }


        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String TransactionType { get; set; }
        [DataMember]
        public String ContributorCode { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String MiddleName { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String Country { get; set; }
        [DataMember]
        public String StreetAddress { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String State { get; set; }
        [DataMember]
        public String ZipCode { get; set; }
        [DataMember]
        public String Method { get; set; }
        [DataMember]
        public String CheckNum { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String OutStandingAmount { get; set; }
        [DataMember]
        public String ReceiptType { get; set; }
        [DataMember]
        public String TransferType { get; set; }
        [DataMember]
        public String ContributionType { get; set; }
        [DataMember]
        public String PurposeCode { get; set; }
        [DataMember]
        public String ReceiptCode { get; set; }
        [DataMember]
        public String OriginalDate { get; set; }
        [DataMember]
        public String LoanerCode { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String Office { get; set; }
        [DataMember]
        public String District { get; set; }
        [DataMember]
        public String Explanation { get; set; }
        [DataMember]
        public String Itemized { get; set; }
        [DataMember]
        public String County { get; set; }
        [DataMember]
        public String Municipality { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String Amended { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
        [DataMember]
        public String CreatedDate { get; set; }
        [DataMember]
        public String TransMapping { get; set; }
        [DataMember]
        public String ContributorTypeID { get; set; }
        [DataMember]
        public String LoanOtherID { get; set; }
        [DataMember]
        public String ReceiptCodeID { get; set; }
        [DataMember]
        public String R_Subcontractor { get; set; }
        [DataMember]
        public String PurposeCodeID { get; set; }
        [DataMember]
        public String R_Liability { get; set; }
        [DataMember]
        public String LoanLibNumber { get; set; }


        [DataMember]
        public String TreasurerOccupation { get; set; }
        [DataMember]
        public String TreasurerEmployer { get; set; }
        [DataMember]
        public String TreasurerStreetAddress { get; set; }
        [DataMember]
        public String TreasurerCity { get; set; }
        [DataMember]
        public String TreasurerState { get; set; }
        [DataMember]
        public String TreasurerZipCode { get; set; }
        [DataMember]
        public String ContributorType { get; set; }
        [DataMember]
        public String ContributorName { get; set; }
        [DataMember]
        public String ContributorOccupation { get; set; }
        [DataMember]
        public String ContributorEmployer { get; set; }
        [DataMember]
        public String IEDescription { get; set; }
        [DataMember]
        public String CandidateNameBallotPropReference { get; set; }
        [DataMember]
        public String Supported { get; set; }
        [DataMember]
        public String RClaim { get; set; }
        [DataMember]
        public String InDistrict { get; set; }
        [DataMember]
        public String RMinor { get; set; }
        [DataMember]
        public String RVendor { get; set; }
        [DataMember]
        public String RLobbyist { get; set; }
        [DataMember]
        public String TreaAddress { get; set; }
        [DataMember]
        public String TreaAddr1 { get; set; }
        [DataMember]
        public String TreaCity { get; set; }
        [DataMember]
        public String TreaState { get; set; }
        [DataMember]
        public String TreaZipCode { get; set; }
        [DataMember]
        public String RContributions { get; set; }
    }

    [DataContract]
    public class DocumentTypeContract
    {
        [DataMember]
        public String DocumentTypeID{ get; set; }
        [DataMember]
        public String DocumentTypeDesc { get; set; }
    }

    [DataContract]
    public class DisclosureGridContract
    {
        [DataMember]
        public String FilingsID { get; set; }
        [DataMember]
        public String PolCalDateID { get; set; }
        [DataMember]
        public String ReportYearID { get; set; }
        [DataMember]
        public String OfficeTypeID { get; set; }
        [DataMember]
        public String ElectTypeID { get; set; }
        [DataMember]
        public String DisclosureTypeID { get; set; }
        [DataMember]
        public String DisclosurePeriodID { get; set; }

        [DataMember]
        public String ReportYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
        [DataMember]
        public String DisclosureType { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
        [DataMember]
        public String Amended { get; set; }
        [DataMember]
        public String DateSubmitted { get; set; }
        [DataMember]
        public String R_Status { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String FilingAbbrev { get; set; }
        [DataMember]
        public String ResigTermTypeID { get; set; }
        [DataMember]
        public String LoanLibNumber { get; set; }
        [DataMember]
        public String County { get; set; }
        [DataMember]
        public String Municipality { get; set; }
        [DataMember]
        public String CCDocType { get; set; }
    }

    [DataContract]
    public class TransactionDetailsGridContract
    {
        [DataMember]
        public String FilingEntityID { get; set; }
        [DataMember]
        public String FilingEntityName { get; set; }
        [DataMember]
        public String FilingEntityFirstName { get; set; }
        [DataMember]
        public String FilingEntityMiddleName { get; set; }
        [DataMember]
        public String FilingEntityLastName { get; set; }
        [DataMember]
        public String FilingEntityCountry { get; set; }
        [DataMember]
        public String FilingEntityStreetAddress { get; set; }
        [DataMember]
        public String FilingEntityCity { get; set; }
        [DataMember]
        public String FilingEntityState { get; set; }
        [DataMember]
        public String FilingEntityZip { get; set; }
        [DataMember]
        public String PurposeCode { get; set; }
        [DataMember]
        public String PayDate { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String Explanation { get; set; }
        [DataMember]
        public String Itemized { get; set; }
        [DataMember]
        public String CreatedDate { get; set; }
        [DataMember]
        public String TreasurerOccupation { get; set; }
        [DataMember]
        public String TreasurerEmployer { get; set; }
        [DataMember]
        public String TreaAddress { get; set; }
        [DataMember]
        public String TreaAddr1 { get; set; }
        [DataMember]
        public String TreaCity { get; set; }
        [DataMember]
        public String TreaState { get; set; }
        [DataMember]
        public String TreaZipCode { get; set; }
        [DataMember]
        public String RContributions { get; set; }
    }


    #endregion

    #region "ViewSupportingDocuments"
    [DataContract]
    public class ViewSupportingDocumentsGridContract
    {
        [DataMember]
        public String SupportDocID { get; set; }
        [DataMember]
        public String ScanDocID { get; set; }
        [DataMember]
        public String OfficeTypeID { get; set; }
        [DataMember]
        public String ElectTypeID { get; set; }
        [DataMember]
        public String PolCalDateID { get; set; }

        [DataMember]
        public String DateReceived { get; set; }
        [DataMember]
        public String DocumentType { get; set; }
        [DataMember]
        public String Amended { get; set; }
        [DataMember]
        public String ReportYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
        [DataMember]
        public String R_Status { get; set; }
        [DataMember]
        public String FileType { get; set; }
        [DataMember]
        public String Size { get; set; }
        [DataMember]
        public String FilingMethod { get; set; }
    }
    #endregion

    #region "Loan and Liability Reconciliation"

    [DataContract]
    public class LoanReceivedGridContract
    {
        [DataMember]
        public String FilingTransID { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }

        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
    }

    [DataContract]
    public class LoanPaymentGridContract
    {
        [DataMember]
        public String FilingTransID { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }

        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String OriginalLoanDate { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
    }

    [DataContract]
    public class OutstandingLiabilityGridContract
    {
        [DataMember]
        public String FilingTransID { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }

        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String OriginalAmount { get; set; }
        [DataMember]
        public String OutstandingAmount { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
    }

    [DataContract]
    public class LiabilityLoanForgivenGridContract
    {
        [DataMember]
        public String FilingTransID { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }

        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String OriginalDate { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
    }

    [DataContract]
    public class ExpenditurePaymentGridContract
    {
        [DataMember]
        public String FilingTransID { get; set; }
        [DataMember]
        public String TransNumber { get; set; }
        [DataMember]
        public String TransMapping { get; set; }

        [DataMember]
        public String TransactionDate { get; set; }
        [DataMember]
        public String EntityName { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String Explanation { get; set; }
        [DataMember]
        public String ElectionYear { get; set; }
        [DataMember]
        public String OfficeType { get; set; }
        [DataMember]
        public String ElectionType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
    }

    #endregion

    [DataContract]
    public class CheckAmendStatusContract
    {
        [DataMember]
        public String Submit_Date { get; set; }
        [DataMember]
        public String IsAmend { get; set; }
    }

    [DataContract]
    public class GetEditFlagDataContract
    {
        [DataMember]
        public String Is_Edit { get; set; }
        [DataMember]
        public String VALIDATE_FILINGS { get; set; }
    }

    [DataContract]
    public class EFSPDFResponseContract
    {
        [DataMember]
        public Byte[] fileByte { get; set; }
        [DataMember]
        public String fileURL { get; set; }
        [DataMember]
        public string fileName { get; set; }
    }

    [DataContract]
    public class EFSPDFRequestContract
    {
        [DataMember]
        public String ReportName { get; set; }
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String ElectionYearId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String ElectionTypeID { get; set; }
        [DataMember]
        public String FilingDate { get; set; }
        [DataMember]
        public String ElectionDateID { get; set; }
        [DataMember]
        public String SubmitDate { get; set; }

    }

    [DataContract]
    public class SchedR_ISExists_Contract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String ReportYearId { get; set; }
        [DataMember]
        public String Filing_Enty_First_Name { get; set; }
        [DataMember]
        public String Filing_Enty_Middle_Name { get; set; }
        [DataMember]
        public String Filing_Enty_Last_Name { get; set; }
        [DataMember]
        public String Office_Id { get; set; }
        [DataMember]
        public String District_Id { get; set; }
    }

    [DataContract]
    public class ImportDisclosureRptsDataContract
    {
        [DataMember]
        public String VendorImportId { get; set; }
        [DataMember]
        public String FilingsId { get; set; }
        [DataMember]
        public String VendorId { get; set; }
        [DataMember]
        public String DateImported { get; set; }
        [DataMember]
        public String TransactionType { get; set; }
        [DataMember]
        public String ReportYear { get; set; }
        [DataMember]
        public String FilerType { get; set; }
        [DataMember]
        public String ReportType { get; set; }
        [DataMember]
        public String ElectionDate { get; set; }
        [DataMember]
        public String DisclosurePeriod { get; set; }
        [DataMember]
        public String SubmissionStatus { get; set; }
        [DataMember]
        public String FileSize { get; set; }        
        [DataMember]
        public String NoOfTrans { get; set; }
        [DataMember]
        public String ElectionYearId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String FilingCategoryId { get; set; }
        [DataMember]
        public String VendorName { get; set; }
    }

    [DataContract]
    public class VendorNamesContract
    {
        [DataMember]
        public String VendorId { get; set; }
        [DataMember]
        public String VendorName { get; set; }        
    }

    [DataContract]
    public class ImportDisclsoureRptsFilingsContract
    {
        [DataMember]
        public String FilerId { get; set; }
        [DataMember]
        public String FilingPeriodId { get; set; }
        [DataMember]
        public String FilingCategoryId { get; set; }
        [DataMember]
        public String ElectId { get; set; }
        [DataMember]
        public String ResigTermTypeId { get; set; }
        [DataMember]
        public String RFilingDate { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }        
    }

    [DataContract]
    public class FilingsForFilingCutOffDateContract
    {
        [DataMember]
        public String FilingsId { get; set; }
        [DataMember]
        public String ElectionYearId { get; set; }
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
        [DataMember]
        public String FilingDate { get; set; }    
    }

    [DataContract]
    public class CheckFilingDateContract
    {
        [DataMember]
        public String ElectionYearId { get; set; }
        [DataMember]
        public String ElectionTypeId { get; set; }
        [DataMember]
        public String OfficeTypeId { get; set; }
        [DataMember]
        public String FilingTypeId { get; set; }
        [DataMember]
        public String ElectionDateId { get; set; }
    }

    [DataContract]
    public class VendorImportDataContract
    {
        [DataMember]
        public String FilingsId { get; set; }
        [DataMember]
        public String VendorId { get; set; }
        [DataMember]
        public String VendorFileSize { get; set; }
        [DataMember]
        public String VendorTransCount { get; set; }
        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public DateTime dtCreatedDate { get; set; }
        [DataMember]
        public String strLastSetOfTrans { get; set; }
    }

    [DataContract]
    public class VendorImportValidationContract
    {
        [DataMember]
        public String Id { get; set; }
        [DataMember]
        public String TableName { get; set; }
    }

    [DataContract]
    public class ReportSourceContract
    {
        [DataMember]
        public String FilingEntityId { get; set; }
        [DataMember]
        public String ReportSource { get; set; }
        [DataMember]
        public String StreetAddress1 { get; set; }
        [DataMember]
        public String City { get; set; }
        [DataMember]
        public String State { get; set; }
        [DataMember]
        public String ZipCode { get; set; }
        [DataMember]
        public String Country { get; set; }
    }

    [DataContract]
    public class FilingTransactionsTransIDContract
    {
        [DataMember]
        public String TransID { get; set; }
    }

}