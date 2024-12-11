using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ShowAddressEntity
    {
        public String AddressId { get; set; }
        public String BestContactId { get; set; }
        public String BestContractDesc { get; set; }
        public String AddressTypeId { get; set; }
        public String AddressTypeDesc { get; set; }
        public String AddressStreetNumber { get; set; }
        public String AddressStreetName { get; set; }
        public String AddressAddress1 { get; set; }
        public String AddressAddress2 { get; set; }
        public String AddressCity { get; set; } 
        public String AddressState { get; set; }
        public String AddressZip { get; set; }
        public String AddressZip4 { get; set; } 
    }

    public class ShowContactEntity
    {
        public String ContractId { get; set; }
        public String PersonId { get; set; }
        public String ContactTypeId { get; set; }
        public String ContactTypeDescription { get; set; }
        public String BestContactId { get; set; }
        public String BestContract_Desc { get; set; }
        public String Phone { get; set; }
        public String EmailAddress { get; set; }
        public String FAX { get; set; }
        public String URL { get; set; }
        public String ContactValue { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
    }

    public class DepositoryBankInfoEntity
    {
        public String BankId { get; set; }
        public String AddressId { get; set; }
        public String CandidateId { get; set; }
        public String DepositoryBankName { get; set; }
        public String BankAccountTypeId { get; set; }
        public String StreetNumber { get; set; }
        public String StreetName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Zip4 { get; set; }
        public String PersonId { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
    }

    public class CandAuthCommitteesEntity
    {
        public String FilerId { get; set; }
        public String CommitteeName { get; set; }
        public String Status { get; set; }
        public String RegistrationDate { get; set; }
        public String TerminationDate { get; set; }
    }

    public class CandidateHeaderDataEntity
    {
        public String FilerType { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String Municipality { get; set; }
        public String ElectionYear { get; set; }
        public String CandidateId { get; set; }
        public String SSN { get; set; }
        public String PoliticalParty { get; set; }
        public String RegistrationDate { get; set; }
        public String Status { get; set; }
        public String TerminationDate { get; set; }
        public String Prefix { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String Suffix { get; set; }
    }

    public class AddressDataEntity
    {
        public String AddressId { get; set; }
        public String AddressTypeId { get; set; }
        public String PersonId { get; set; }
        public String BestContactId { get; set; }
        public String AddressBusinessName { get; set; }
        public String AddressStreetNumber { get; set; }
        public String AddressStreetName { get; set; }
        public String AddressAddress1 { get; set; }
        public String AddressAddress2 { get; set; }
        public String AdresssCity { get; set; }
        public String AddressState { get; set; }
        public String AddressZip { get; set; }
        public String AddressZip4 { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
    }

    public class AddressTypesEntity
    {
        public String AddressTypeId { get; set; }
        public String AddressTypeDescription { get; set; } 
    }

    public class BestContactTypesEntity
    {
        public String BestContactTypeId { get; set; }
        public String BestContactTypeDesc { get; set; }
    }

    public class ContactTypesEntity
    {
        public String ContactTypeId { get; set; }
        public String ContactTypeDescription { get; set; }
    }

    public class TreasurerProfileEntity
    {
        public String TransID { get; set; }
        public String PersonID { get; set; }
        public String PersonSSN { get; set; }
        public String TransRegDate { get; set; }
        public String Status { get; set; }
        public String TransTermDate { get; set; }
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }        
    }

    public class TreasurerCommitteeInformationEntity
    {
        public String CommID { get; set; }
        public String FilerID { get; set; }
        public String PersonID { get; set; }
        public String CommitteeName { get; set; }        
        public String Status { get; set; }
        public String CommitteeRegDate { get; set; }
        public String CommitteeTermDate { get; set; }
        public String CommitteeTypeDesc { get; set; }        
    }

    public class TreasAssistantInformationEntity
    {        
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }
        public String PersonID { get; set; }
    }

    public class TreasurerHistoryEntity
    {
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }
        public String Status { get; set; }
        public String RegDate { get; set; }
        public String TermDate { get; set; }
        public String PersonID { get; set; }
    }

    public class TreasAdditionalCommitteeContactEntity
    {
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }
    }

    public class TreasDepositoryBankInformationEntity
    {
        public String BankID { get; set; }
        public String BankName { get; set; }
        public String BankAccountTypeID { get; set; }
        public String AddrNum { get; set; }
        public String AddrStrName { get; set; }
        public String AddrCity { get; set; }
        public String AddrState { get; set; }
        public String AddrZip { get; set; }
        public String AddrZip4 { get; set; }
        public String ADDR_ID { get; set; }
        public String PERSON_ID { get; set; }
        public String COMM_ID { get; set; }
        public String CreatedBy { get; set; }
    }

    public class TreasCandidateSupportOpposeEntity
    {
        public String ElectionYear { get; set; }
        public String OfficeDesc { get; set; }
        public String DistID { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String SupposeOppose { get; set; }
        public String AuthorizedDate { get; set; }
        public String NonExpenditureDate { get; set; }
    }

    public class TreasAuthorizedToSignCheckEntity
    {        
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }
        public String AuthSignedID { get; set; }
        public String PersonID { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Status { get; set; }
    }

    public class TreasBallotIssuesEntity
    {
        public String BallotIssues { get; set; }
        public String SupposeOppose { get; set; }        
    }
    
    public class BankAccountTypesEntity
    {
        public String AccountTypeId { get; set; }
        public String AccountTypeDesc { get; set; }
    }

    public class SubTreasurerPersonEntity
    {
        public String TreasurerId { get; set; }
        public String SubTreasurerId { get; set; }
        public String PersonId { get; set; }
        public String StateDate { get; set; }
        public String RStatus { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Suffix { get; set; }
        public String Preffix { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
    }

    public class FilingTransactionDataEntity
    {
        public String FilingSchedId { get; set; }
        public String FilingsId { get; set; }
        public String FilingEntityId { get; set; }
        public String ReportYear { get; set; }
        public String ContributorTypeId { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String ContributionTypeId { get; set; }
        public String ReceiptCodeId { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String PaymentTypeId { get; set; }
        public String FilingTransId { get; set; }
        public String SchedDate { get; set; }
        public String FilingSchedDesc { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingFirstName { get; set; }
        public String FilingMiddleName { get; set; }
        public String FilingLastName { get; set; }
        public String FilingStreetNumber { get; set; }
        public String FilingStreetName { get; set; }
        public String FilingCity { get; set; }
        public String FilingState { get; set; }
        public String FilingZip { get; set; }
        public String FilingCountry { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String PayNumber { get; set; }
        public String OriginalAmount { get; set; }
        public String ReceiptTypeDesc { get; set; }
        public String TransferTypeDesc { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String OriginalDate { get; set; }
        public String LoanerCode { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String RLiability { get; set; }
        public String RSubcontractor { get; set; }
        public String TransExplanation { get; set; }
        public String CreatedDate { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
        public String OwedAmount { get; set; }
        public String RItemized { get; set; }
        public String CountyID { get; set; }
        public String CountyDesc { get; set; }
        public String MunicipalityID { get; set; }
        public String MunicipalityDesc { get; set; }
        public String LoanerCodeId { get; set; }
        public String SubmissionDate { get; set; }
        public String RAmend { get; set; }
        public String RStatus { get; set; }
        public String TreasurerFirstName { get; set; }
        public String TreasurerLastName { get; set; }
        public String TreasurerMiddleName { get; set; }
        public String TreasurerOccuptaion { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreasurerStreetAddress { get; set; }
        public String TreasurerCity { get; set; }
        public String TreasurerState { get; set; }
        public String TreasurerZip { get; set; }
        public String ContributorOccupation { get; set; }
        public String ContributorEmployer { get; set; }
        public String IEDescription { get; set; }
        public String CandBallotPropReference { get; set; }
        public String IESupported { get; set; }
        public String AddrId { get; set; }
        public String TreasId { get; set; }
        public String IEType { get; set; }
        public String TreasurerName { get; set; }
        public String ContributorName { get; set; }
        public String PurposeCodeId { get; set; }
        public String Increased { get; set; }
        public String Decreased { get; set; }
        public String Balance { get; set; }
        public String DateIncurredOrgAmtId { get; set; }
        public String LiabExistsOrigAmount { get; set; }
        public String LiabExistsTransId { get; set; }
        public String LoanLiablityNumber { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String LoanLibNumberSchedN { get; set; }
        public String DBStatus { get; set; }
        public String FilerId { get; set; }
        public String CandidateCommitteeName { get; set; }
        public String FilerType { get; set; }
        public String ElectionType { get; set; }
        public String ReportType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String Office_Desc { get; set; }
        public String Original_Sched_Date { get; set; }
        public String RClaim { get; set; }
        public String InDistrict { get; set; }
        public String RMinor { get; set; }
        public String RVendor { get; set; }
        public String RLobbyist { get; set; }
        public String TreaAddress { get; set; }
        public String TreaAddr1 { get; set; }
        public String TreaCity { get; set; }
        public String TreaState { get; set; }
        public String TreaZipCode { get; set; }
        public String RContributions { get; set; }
        public String RecordType { get; set; }
        public String RIESupported { get; set; }
        public String RSupportOppose { get; set; }
    }

    public class FilingTransDataEntity
    {
        public String FilerId { get; set; }
        public String CommitteeId { get; set; }  public String ReportYearId { get; set; }
        public String OfficeTypeId { get; set; }      
        public String ReportYear { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String CutOffDate { get; set; }
        public String FilingDate { get; set; }
        public String FilingSchedID { get; set; }
        public String FilingTransID { get; set; }
        public String SchedName { get; set; }
        public String ElectionDateId { get; set; }
        public String Loan_Lib_Num { get; set; }
        public String Created_By { get; set; }
        public String TransNumber { get; set; }
        public String MunicipalityID { get; set; }
        public String CommTypeId { get; set; }
        public String LabelId { get; set; }
    }

    public class ContributionTypeEntity
    {
        public String ContributionTypeId { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String ContributionTypeAbbrev { get; set; }
    }

    public class ContributorNameEntity
    {
        public String ContributorTypeId { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String ContributorTypeAbbrev { get; set; }
    }

    public class DisclosurePreiodEntity
    {
        public String FilingTypeId { get; set; }
        public String FilingDesc { get; set; }
        public String FilingAbbrev { get; set; }
    }

    public class ElectionDateEntity
    {
        public String ElectId { get; set; }
        public String ElectDate { get; set; }
    }

    public class FilerCommitteeEntity
    {
        public String FilerId { get; set; }
        public String CommitteeId { get; set; }
        public String CommitteeName { get; set; }
        public String OfficeId { get; set; }
        public String personID { get; set; }
        public String TreasurerId { get; set; }
        public String CommTypeId { get; set; }
        public String OfficTypeID { get; set; }
        public String OfficeTypeDesc { get; set; }
    }

    public class PaymentMethodEntity
    {
        public String PaymentTypeId { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String PaymentTypeAbbrev { get; set; }
    }

    public class PurposeCodeEntity
    {
        public String PurposeCodeId { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String PurposeCodeAbbrev { get; set; }
    }

    public class ReceiptCodeEntity
    {
        public String ReceiptCodeId { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String ReceiptCodeAbbrev { get; set; }
    }

    public class ReceiptTypeEntity
    {
        public String ReceiptTypeId { get; set; }
        public String ReceiptTypeDesc { get; set; }
        public String ReceiptTypeAbbrev { get; set; }
    }

    public class TransferTypeEntity
    {
        public String TransferTypeId { get; set; }
        public String TransferTypeDesc { get; set; }
        public String TransferTypeAbbrev { get; set; }
    }

    public class ElectionYearEntity
    {
        public String ElectionYearId { get; set; }
        public String ElectionYearValue { get; set; }
    }

    public class ElectionTypeEntity
    {
        public String ElectionTypeId { get; set; }
        public String ElectionTypeDesc { get; set; }
    }

    public class FilingCutOffDateEntity
    {
        public String PoliticalCalDateId { get; set; }
        public String PoliticalCalLabelId { get; set; }
        public String FilingDueDate { get; set; }
        public String CutOffDate { get; set; }
        public String PriGenDate { get; set; }
    }

    public class ContributorTypesEntity
    {
        public String ContributorTypeId { get; set; }
        public String ContributoryTypeDesc { get; set; }
    }

    public class TransactionTypesEntity
    {
        public String FilingSchedId { get; set; }
        public String FilingSchedDesc { get; set; }
        public String FilingSchedAbbrev { get; set; }
    }

    public class DisclosureTypesEntity
    {
        public String DisclosureTypeId { get; set; }
        public String DisclosureTypeDesc { get; set; }
        public String DisclosureSubTypeDesc { get; set; }
    }

    public class FilingTransactionsEntity
    {
        public String FilerId { get; set; }
        public String FilingTransId { get; set; }
        public String FilingEntId { get; set; }
        public String ElectionDate { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String ElectYearId { get; set; }
        public String ElectionYear { get; set; }
        public String FilingSchedId { get; set; }
        public String SchedDate { get; set; }
        public String FlngEntName { get; set; }
        public String OrgDate { get; set; }
        public String RBankLoan { get; set; }
        public String ReceiptTypeId { get; set; }
        public String ReceiptCodeId { get; set; }
        public String FlngEntFirstName { get; set; }
        public String FlngEntLastName { get; set; }
        public String FlngEntMiddleName { get; set; }
        public String DistOffCandBalProp { get; set; }
        public String FlngEntStrNum { get; set; }
        public String FlngEntStrName { get; set; }
        public String FlngEntCity { get; set; }
        public String FlngEntState { get; set; }
        public String FlngEntZip { get; set; }
        public String FlngEntZip4 { get; set; }
        public String FlngEntCountry { get; set; }
        public String TransferTypeId { get; set; }
        public String OrgAmt { get; set; }
        public String LiabilityOrgAmt { get; set; }
        public String LiabilityOwedAmt { get; set; }
        public String LiabilityPartialAmt { get; set; }
        public String ContributorTypeId { get; set; }
        public String ContributionTypeId { get; set; }
        public String PurposeCodeId { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String PaymentTypeId { get; set; }
        public String PayNumber { get; set; }
        public String LoanOtherId { get; set; }
        public String TransCode { get; set; }
        public String TransDesc { get; set; }
        public String PayDate { get; set; }
        public String OwedAmt { get; set; }
        public String RLiability { get; set; }
        public String RSubcontractor { get; set; }
        public String RItemized { get; set; }
        public String RLiabilityExists { get; set; }
        public String TransExplanation { get; set; }
        public String LiabilityTransExplanation { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
        public String OtherTransExplanation { get; set; }
        public String OtherFilingSchedId { get; set; }
        public String OtherAmount { get; set; }
        public String MunicipalityID { get; set; }
        public String OfficeID { get; set; }
        public String DistrictID { get; set; }
        public String RAmend { get; set; }
        public String SubmissionDate { get; set; }
        public String TreasId { get; set; }
        public String AddrId { get; set; }
        public String TreasurerOccupation { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreasurerStreetAddress { get; set; }
        public String TreasurerCity { get; set; }
        public String TreasurerState { get; set; }
        public String TreasurerZip { get; set; }
        public String ContributorOccupation { get; set; }
        public String ContributorEmployer { get; set; }
        public String IEDescription { get; set; }
        public String CandBallotPropReference { get; set; }
        public String R_Supported { get; set; }
        public String PersonId { get; set; }
        public String ElectionDateId { get; set; }
        public String DateIncurredOrgAmtId { get; set; }
        public String FilingDate { get; set; }
        public String ResigTermTypeId { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String Loan_Lib_Number { get; set; }
        public String IsAmtChanged { get; set; }
        public String LoanLiabNumberOrg { get; set; }
        public String TransNumberOrg { get; set; }
        public String IsExpSubcontractor { get; set; }
        public String IsExpPartialPay { get; set; }
        public String IsExistingLiab { get; set; }
        public String IsLiabPartialForgiven { get; set; }
        public String ParentFilingEntityId { get; set; }
        public String RIEIncluded { get; set; }
        public String RIESupported { get; set; }
        public String ExistsLiabTransNumber { get; set; }
        public String FilingsId { get; set; }
        public String RParent { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String Unique_Num { get; set; }
        public String IsClaim { get; set; }
        public String InDistrict { get; set; }
        public String Minor { get; set; }
        public String Vendor { get; set; }
        public String Lobbyist { get; set; }
        public String CommTypeID { get; set; }
        public String RContributions { get; set; }
        public String SchedID { get; set; }
        public String SupportOppose { get; set; }
    }

    public class OfficeTypeEntity
    {
        public String OfficeTypeId { get; set; }
        public String OfficeTypeDesc { get; set; }
    }

    public class CountyEntity
    {
        public String CountyId { get; set; }
        public String CountyDesc { get; set; }
    }

    public class MunicipalityEntity
    {
        public String MunicipalityId { get; set; }
        public String MunicipalityDesc { get; set; }
    }

    public class AutoCompFLNameAddressEntity
    {
        public String FilingEntityId { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingEntityFirstName { get; set; }
        public String FilingEntityMiddleName { get; set; }
        public String FilingEntityLastName { get; set; }
        public String FilingEntityStreetNum { get; set; }
        public String FilingEntityStreetName { get; set; }
        public String FilingEntityCity { get; set; }
        public String FilingEntityState { get; set; }
        public String FilingEntityZip { get; set; }
        public String FilingEntityZip4 { get; set; }
        public String FilingEntityCountry { get; set; }
        public String FilingEntityNameAndAddress { get; set; }
    }

    public class ViewableColumnEntity
    {
        public String ViewableFieldID { get; set; }
        public String UniqueID { get; set; }
        public String ColumnName { get; set; }
        public String Viewable { get; set; }
    }

    public class ContrInKindPartnersEntity
    {
        public String FilingTransId { get; set; }
        public String FilingEntityId { get; set; }
        public String PartnershipName { get; set; }
        public String PartnerFirstName { get; set; }
        public String PartnerMiddleName { get; set; }
        public String PartnerLastName { get; set; }
        public String PartnerStreetNo { get; set; }
        public String PartnerStreetName { get; set; }
        public String PartnerCity { get; set; }
        public String PartnerState { get; set; }
        public String PartnerZip5 { get; set; }
        public String PartnershipCountry { get; set; }
        public String PartnerAmountAttributed { get; set; }
        public String PartnerExplanation { get; set; }
        public String RItemized { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String TreasurerOccupation { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreaAddress { get; set; }
        public String TreaAddr1 { get; set; }
        public String TreaCity { get; set; }
        public String TreaState { get; set; }
        public String TreaZipCode { get; set; }
        public String CommTypeID { get; set; }
        public String RContributions { get; set; }
    }

    public class LoanerCodeEntity
    {
        public String LoanerID { get; set; }
        public String LoanerDesc { get; set; } 
    }

    public class OutstandingLiabilityEntity
    {
        public String FilingTransId { get; set; }
        public String FilingEntityId { get; set; }
        public String PayeeName { get; set; }
        public String DateIncurred { get; set; }
        public String OriginalAmount { get; set; }
        public String OutstandingAmount { get; set; }
        public String CreditorName { get; set; }
        public String FlngEntCountry { get; set; }
        public String LiabilityStreetName { get; set; }
        public String LiabilityCity { get; set; }
        public String LiabilityState { get; set; }
        public String LiabilityZipCode { get; set; }
        public String LiabilityAmount { get; set; }
        public String LiabilityExplanation { get; set; }
        public String FilingEntityNameAndAddress { get; set; }
    }

    public class DateIncurredEntity
    {
        public String DateIncurredId { get; set; }
        public String DateIncurredValue { get; set; }
        public String AmountLiability { get; set; }
        public String OutstandingAmount { get; set; }
    }

    public class OriginalAmountEntity
    {
        public String OriginalAmountId { get; set; }
        public String OutstandingAmount { get; set; }
    }

    public class ExpPaymentLiabilityEntity
    {
        public String FilingTransId { get; set; }
        public String FilingEntityId { get; set; }
        public String PayeeName { get; set; }
        public String DateIncurred { get; set; }
        public String OrignalAmount { get; set; }
        public String OutstandingAmount { get; set; }
        public String CreditorName { get; set; }
        public String LiabilityStreetName { get; set; }
        public String LiabilityCity { get; set; }
        public String LiabilityState { get; set; }
        public String LiabilityZipCode { get; set; }
        public String LiabilityExplanation { get; set; }
        public String TransNumber { get; set; }

    }

    public class GetSearchForScheduledI
    {
        public String Date { get; set; }
        public String Amount { get; set; }
        public String Name { get; set; }
        public String FILING_TRANS_ID { get; set; }   
        public String Original_Amt { get; set; }
        public String Trans_Number { get; set; }
        public String Loan_Lib_Number { get; set; }
        public String flng_Ent_FirstName { get; set; }
        public String flng_Ent_MiddleName { get; set; }
        public String flng_Ent_LastName { get; set; }
        public String filer_Id { get; set; }
    }

    public class AuthorizedToSignCheckEntity
    {
        public String CommID { get; set; }
        public String StartDate { get; set; }
        public String Status { get; set; }
        public String EndDate { get; set; }
        public String Prefix { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Suffix { get; set; }
        public byte[] Signature { get; set; }
        public String CreatedBy { get; set; }
    }

    public class ExpPaymentTransIdPopUpSchedFEntity
    {
        public String TransNumber { get; set; }
        public String FilingSchedId { get; set; }
        public String ScheduleDate { get; set; }
        public String OrgAmount { get; set; }
    }

    public class ExpPaymentOriginalNameEntity
    {
        public String FilingEntityId { get; set; }
        public String FilingEntityName { get; set; }
    }

    public class ExpPaymentOriginalAmountEntity
    {
        public String FilingTransId { get; set; }
        public String OriginalAmount { get; set; }
        public String TransNumber { get; set; }
    }

    public class ExpPaymentOriginalExpenseDateEntity
    {
        public String FilingTransId { get; set; }
        public String OriginalExpenseDate { get; set; }
        public String TransNumber { get; set; }
    }

    public class ValidateFilerInfo
    {
        public String FilerID { get; set; }
        public String RoleID { get; set; }
        public String Name { get; set; }
    }

    public class DistrictEntity
    { 
        public String District_ID { get; set; }
        public String Parent_District_ID { get; set; }
    }

    public class OfficeEntity
    {
        public String OfficeId { get; set; }
        public String OfficeDesc { get; set; }
    }

    public class AutoCompleteSchedREntity
    {
        public String FilingTransId { get; set; }
        public String FilingEntityId { get; set; }
        public String EntityName { get; set; }
        public String Org_Amt { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String ElectionYear { get; set; }
        public String Office_ID { get; set; }
        public String Dist_ID { get; set; }        
    }

    public class InLieuOfStatementNonItemEntity
    {
        public String FilingsId { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
        public String DateSubmitted { get; set; }          
    }

    public class AddInLieuOfStatementEntity
    {
        public String FilerId { get; set; }
        public String ElectionDate { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String FilingCategoryId { get; set; }
        public String ElectYearId { get; set; }
        public String ElectionYear { get; set; }
        public String CountyId { get; set; }
        public String MunicipalityId { get; set; }
        public String ResigTermTypeId { get; set; }
        public String CreatedBy { get; set; }
        public String ElectionDateId { get; set; }
        public String FilingDate { get; set; }
    }

    public class PersonNameAndTreasurerDataEntity
    {
        public String PersonName { get; set; }
        public String TreasId { get; set; }
    }

    public class FilerInfo
    {
        public String Trans_Cand_ID { get; set; }
        public String Filer_ID { get; set; }
        public String Cand_Comm_ID { get; set; }
        public String Cand_Comm_Name { get; set; }
        public String PersonID { get; set; }
        public String Name { get; set; }
    }

    public class NonItemIETreasurerData
    {
        public String PersonId { get; set; }
        public String AddressId { get; set; }
        public String TreasurerName { get; set; }
        public String TreasurerOccupation { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreasurerStreetAddress { get; set; }
        public String TreasurerCity { get; set; }
        public String TreasurerState { get; set; }
        public String TreasurerZip { get; set; }
        public String TreasurerCountry { get; set; }
    }

    public class FilingMthodEntity
    {
        public String FilingMethodId { get; set; }
        public String FilingMethodDesc { get; set; }        
    }

    public class NonItemCampaignMaterialEntity
    {
        public String FilerId { get; set; }
        public String ElectionDate { get; set; }
        public String ElectionDateId { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String FilingCategoryId { get; set; }
        public String ElectYearId { get; set; }
        public String ElectionYear { get; set; }
        public String CountyId { get; set; }
        public String MunicipalityId { get; set; }
        public String DateSubmitted { get; set; }
        public String FilingMethodId { get; set; }        
        public String CampaignMaterialDesc { get; set; }
        public String CampMatrFileType { get; set; }
        public String CampMatrFileSize { get; set; }
        public String SacnDocId { get; set; }
        public String RCampMatr { get; set; }
        public String CreatedBy { get; set; }
        public String FilingDate { get; set; }
    }

    public class NonItemCampaignMaterialDataEntity
    {
        public String CampaignMaterialId { get; set; }
        public String DateSubmitted { get; set; }
        public String FilingMethodId { get; set; }
        public String FilingMethodDesc { get; set; }
        public String CampaignMaterialDesc { get; set; }
        public String CampMatrFileType { get; set; }
        public String CampMatrFileSize { get; set; }
        public String SacnDocId { get; set; }
        public String RCampMatr { get; set; }
        public String RAmended { get; set; }
        public String CreatedDate { get; set; }
    }

    public class FilingDatesOffCycleEntity
    {
        public String FilingDateId { get; set; }
        public String FilingDate { get; set; }
    }

    public class ResigTermTypeEntity
    {
        public String ResigTermTypeId { get; set; }
        public String ResigTermTypeDesc { get; set; }
        public String FilingsId { get; set; }
    }

    public class LiabilityDetailsEntity
    {
        public String FilingTransId { get; set; }
        public String TransNumber { get; set; }
        public String TransactionDate { get; set; }
        public String TransactionType { get; set; }
        public String ContributorCode { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingFirstName { get; set; }
        public String FilingMiddleName { get; set; }
        public String FilingLastName { get; set; }
        public String FilingStreetName { get; set; }
        public String FilingCity { get; set; }
        public String FilingState { get; set; }
        public String FilingZip { get; set; }
        public String FilingCountry { get; set; }
        public String PayNumber { get; set; }
        public String PaymentType { get; set; }
        public String Amount { get; set; }
        public String OutstandingAmount { get; set; }
        public String RecieptType { get; set; }
        public String TransferType { get; set; }
        public String ContributionType { get; set; }
        public String PurposeCode { get; set; }
        public String RecieptCdoe { get; set; }
        public String OriginalDate { get; set; }
        public String LoanerCode { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String TransExplanation { get; set; }
        public String RItemized { get; set; }
        public String CountId { get; set; }
        public String County { get; set; }
        public String MunicipalityId { get; set; }
        public String Municipality { get; set; }
        public String CreatedDate { get; set; }
    }

    public class EFSPDFRequestEntity
    {
        public String ReportName { get; set; }
        public String FilerId { get; set; }
        public String ElectionYearId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String FilingDate { get; set; }
        public String ElectionTypeID { get; set; }
        public String ElectionDateID { get; set; }
        public String SubmitDate { get; set; }
    }

    public class EFSPDFResponseEntity
    {
        public Byte[] fileByte { get; set; }
        public String fileURL { get; set; }
    }


    #region "ViewAllDisclosures"

    //public class OfficeTypeEntity
    //{
    //    public String OfficeTypeID { get; set; }
    //    public String OfficeTypeDesc { get; set; }
    //}

    //public class ElectionTypeEntity
    //{
    //    public String ElectionTypeID { get; set; }
    //    public String ElectionTypeDesc { get; set; }
    //}

    //public class ElectionDateEntity
    //{
    //    public String ElectionID { get; set; }
    //    public String ElectionDate { get; set; }
    //}

    //public class CountyEntity
    //{
    //    public String CountyID { get; set; }
    //    public String CountyBoard { get; set; }
    //}

    //public class MunicipalityEntity
    //{
    //    public String MunicipalityID { get; set; }
    //    public String MunicipalityDesc { get; set; }
    //}

    public class TransactionGridEntity
    {
        public String TransNumber { get; set; }
        public String FilingSchedID { get; set; }
        public String PurposeCodeID { get; set; }


        public String TransactionDate { get; set; }
        public String TransactionType { get; set; }
        public String ContributorCode { get; set; }
        public String EntityName { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Country { get; set; }
        public String StreetAddress { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String Method { get; set; }
        public String CheckNum { get; set; }
        public String Amount { get; set; }
        public String OutStandingAmount { get; set; }
        public String ReceiptType { get; set; }
        public String TransferType { get; set; }
        public String ContributionType { get; set; }
        public String PurposeCode { get; set; }
        public String ReceiptCode { get; set; }
        public String OriginalDate { get; set; }
        public String LoanerCode { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String Explanation { get; set; }
        public String Itemized { get; set; }
        public String County { get; set; }
        public String Municipality { get; set; }
        public String Status { get; set; }
        public String Amended { get; set; }
        public String DateSubmitted { get; set; }
        public String TransMapping { get; set; }
        public String R_Subcontractor { get; set; }
        public String CreatedDate { get; set; }
        public String ContributorTypeID { get; set; }   
        public String LoanOtherID { get; set; }
        public String ReceiptCodeID { get; set; }
        public String R_Liability { get; set; }
        public String LoanLibNumber { get; set; }

        public String TreasurerOccupation { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreasurerStreetAddress { get; set; }
        public String TreasurerCity { get; set; }
        public String TreasurerState { get; set; }
        public String TreasurerZipCode { get; set; }
        public String ContributorType { get; set; }
        public String ContributorName { get; set; }
        public String ContributorOccupation { get; set; }
        public String ContributorEmployer { get; set; }
        public String IEDescription { get; set; }
        public String CandidateNameBallotPropReference { get; set; }
        public String Supported { get; set; }
        public String RClaim { get; set; }
        public String InDistrict { get; set; }
        public String RMinor { get; set; }
        public String RVendor { get; set; }
        public String RLobbyist { get; set; }
        public String TreaAddress { get; set; }
        public String TreaAddr1 { get; set; }
        public String TreaCity { get; set; }
        public String TreaState { get; set; }
        public String TreaZipCode { get; set; }
        public String RContributions { get; set; }
    }

    public class DisclosureGridEntity
    {
        public String FilingsID { get; set; }
        public String PolCalDateID { get; set; }
        public String ReportYearID { get; set; }
        public String OfficeTypeID { get; set; }
        public String ElectTypeID { get; set; }
        public String DisclosureTypeID { get; set; }
        public String DisclosurePeriodID { get; set; }
        public String ReportYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String FilingDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String Amended { get; set; }
        public String DateSubmitted { get; set; }
        public String R_Status { get; set; }
        public String TransNumber { get; set; }
        public String FilingAbbrev { get; set; }
        public String ResigTermTypeID { get; set; }
        public String LoanLibNumber { get; set; }
        public String County { get; set; }
        public String Municipality { get; set; }
        public String CCDocType { get; set; }
    }

    public class PIDAGridEntity
    {
        public String SupportingDocID { get; set; }
        public String ScanDocID { get; set; }
        public String CommunicationTypeID { get; set; }
        public String FileType { get; set; }
        public String FileSize { get; set; }
        public String DateSubmitted { get; set; }
        public String CommunicationType { get; set; }
        public String Description { get; set; }
        public String SubmittedBy { get; set; }
    }

    public class SupportingDocumentsGridEntity
    {
        public String SupportingDocID { get; set; }
        public String ScanDocID { get; set; }
        public String DateReceived { get; set; }
        public String DocumentType { get; set; }
        public String FileType { get; set; }
        public String FileSize { get; set; }
        public String FilingMethod { get; set; }
    }

    public class CampaignMaterialsGridEntity
    {
        public String CampaignMaterialID { get; set; }
        public String FilingMethodID { get; set; }
        public String ScanDocID{ get; set; }
        public String DateSubmitted { get; set; }
        public String FilingMethodDesc { get; set; }
        public String CampaignMaterialDesc { get; set; }
        public String FileSize { get; set; }
        public String FileType { get; set; }
        public String CreatedDate { get; set; }
        public String CampaignMaterialAvailable { get; set; }
    }

    public class TransactionDetailsGridEntity
    {
        public String FilingEntityID { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingEntityFirstName { get; set; }
        public String FilingEntityMiddleName { get; set; }
        public String FilingEntityLastName { get; set; }
        public String FilingEntityCountry { get; set; }
        public String FilingEntityStreetAddress { get; set; }
        public String FilingEntityCity { get; set; }
        public String FilingEntityState { get; set; }
        public String FilingEntityZip { get; set; }
        public String PurposeCode { get; set; }
        public String PayDate { get; set; }
        public String Amount { get; set; }
        public String Explanation { get; set; }
        public String Itemized { get; set; }
        public String CreatedDate { get; set; }
        public String TreasurerOccupation { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreaAddress { get; set; }
        public String TreaAddr1 { get; set; }
        public String TreaCity { get; set; }
        public String TreaState { get; set; }
        public String TreaZipCode { get; set; }
        public String RContributions { get; set; }
    }

    public class CommunicationTypeEntity
    {
        public String CommunicationTypeID { get; set; }
        public String CommunicationTypeDesc { get; set; }
    }

    public class DocumentTypeEntity
    {
        public String DocumentTypeID { get; set; }
        public String DocumentTypeDesc { get; set; }
    }

    #endregion

    #region "ViewSupportingDocuments"

    public class ViewSupportingDocumentsGridEntity
    {
        public String SupportDocID { get; set; }
        public String ScanDocID { get; set; }
        public String OfficeTypeID { get; set; }
        public String ElectTypeID { get; set; }
        public String PolCalDateID { get; set; }

        public String DateReceived { get; set; }
        public String DocumentType { get; set; }
        public String Amended { get; set; }
        public String ReportYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
        public String R_Status { get; set; }
        public String FileType { get; set; }
        public String Size { get; set; }
        public String FilingMethod { get; set; }
    }


    #endregion

    #region "Loan and Liability Reconciliation"

    public class LoanReceivedGridEntity
    {
        public String FilingTransID { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }

        public String TransactionDate { get; set; }
        public String EntityName { get; set; }
        public String Amount { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
    }

    public class LoanPaymentGridEntity
    {
        public String FilingTransID { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }

        public String TransactionDate { get; set; }
        public String EntityName { get; set; }
        public String Amount { get; set; }
        public String OriginalLoanDate { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
    }

    public class OutstandingLiabilityGridEntity
    {
        public String FilingTransID { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }

        public String TransactionDate { get; set; }
        public String EntityName { get; set; }
        public String OriginalAmount { get; set; }
        public String OutstandingAmount { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
    }

    public class LiabilityLoanForgivenGridEntity
    {
        public String FilingTransID { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }

        public String TransactionDate { get; set; }
        public String EntityName { get; set; }
        public String Amount { get; set; }
        public String OriginalDate { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
    }

    public class ExpenditurePaymentGridEntity
    {
        public String FilingTransID { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }

        public String TransactionDate { get; set; }
        public String EntityName { get; set; }
        public String Amount { get; set; }
        public String Explanation { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
    }

    public class CheckAmendStatus
    {
        public String Submit_Date { get; set; }
        public String IsAmend { get; set; }
    }

    public class GetEditFlagData
    {
        public String Is_Edit { get; set; }

        public String VALIDATE_FILINGS { get; set; }
    }

    #endregion

    public class SchedR_ISExists_Entity
    {
        public String FilerId { get; set; }
        public String ReportYearId { get; set; }
        public String Filing_Enty_First_Name { get; set; }
        public String Filing_Enty_Middle_Name { get; set; }
        public String Filing_Enty_Last_Name { get; set; }
        public String Office_Id { get; set; }
        public String District_Id { get; set; }
    }

    public class ImportDisclosureRptsDataEntity
    {
        public String VendorImportId { get; set; }
        public String FilingsId { get; set; }
        public String VendorId { get; set; }
        public String DateImported { get; set; }
        public String TransactionType { get; set; }
        public String ReportYear { get; set; }
        public String FilerType { get; set; }
        public String ReportType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
        public String SubmissionStatus { get; set; }
        public String FileSize { get; set; }
        public String NoOfTrans { get; set; }
        public String ElectionYearId { get; set; }
        public String OfficeTypeId { get; set; }
        public String ElectionTypeId { get; set; }
        public String ElectionDateId { get; set; }
        public String FilingTypeId { get; set; }
        public String FilingCategoryId { get; set; }
        public String VendorName { get; set; }
    }

    public class VendorNamesEntity
    {
        public String VendorId { get; set; }
        public String VendorName { get; set; }
    }

    public class ImportDisclsoureRptsFilingsEntity
    {
        public String FilerId { get; set; }
        public String FilingPeriodId { get; set; }
        public String FilingCategoryId { get; set; }
        public String ElectId { get; set; }
        public String ResigTermTypeId { get; set; }
        public String RFilingDate { get; set; }
        public String CreatedBy { get; set; }
    }

    public class FilingsForFilingCutOffDateEntity
    {
        public String FilingsId { get; set; }
        public String ElectionYearId { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String ElectionDateId { get; set; }
        public String FilingDate { get; set; }
    }

    public class CheckFilingDateEntity
    {        
        public String ElectionYearId { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String ElectionDateId { get; set; }     
    }

    public class VendorImportDataEntity
    {
        public String FilingsId { get; set; }
        public String VendorId { get; set; }
        public String VendorFileSize { get; set; }
        public String VendorTransCount { get; set; }
        public String CreatedBy { get; set; }
        public DateTime dtCreatedDate { get; set; }
        public String strLastSetOfTrans { get; set; }
    }

    public class VendorImportValidationEntity
    {
        public String Id { get; set; }
        public String TableName { get; set; }
    }

    public class ReportSourceEntity
    {
        public String FilingEntityId { get; set; }
        public String ReportSource { get; set; }
        public String StreetAddress1 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String Country { get; set; }
    }

    public class FilingTransactionsTransIDEntity
    {
        public String TransID { get; set; }
    }

}
