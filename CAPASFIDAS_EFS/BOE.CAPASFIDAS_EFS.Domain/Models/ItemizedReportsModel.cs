using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Models
{
    public class FilingTransactionDataModel 
    {
        public String FilingSchedId { get; set; } 
        public String FilingsId { get; set; }
        public String ContributorTypeId { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String ContributionTypeId { get; set; }
        public String PaymentTypeId { get; set; }
        public String FilingTransId { get; set; }
        public String ReceiptCodeId { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String SchedDate { get; set; }
        public String FilingSchedDesc { get; set; }
        public String FilingEntityId { get; set; }
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
        public String FilingZip4 { get; set; }
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
        public String LoanerCodeID { get; set; }
        public String SubmissionDate { get; set; }
        public String Status { get; set; }
        public String RAmend { get; set; }
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
        public String LoanLiablityNumber { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String CreatedDate24Hours { get; set; }
        public String DBStatus { get; set; }
        public String FilerId { get; set; }
        public String CandidateCommitteeName { get; set; }
        public String FilerType { get; set; }
        public String ReportYear { get; set; }
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
        public String CommTypeID { get; set; }
        public String RContributions { get; set; }
        public String RecordType { get; set; }
        public String RIESupported { get; set; }
        public String RSupportOppose { get; set; }
    }

    public class FilingTransactionDataModelCSV
    {
        public String FilerId { get; set; }
        public String CandidateCommitteeName { get; set; }
        public String FilerType { get; set; }
        public String ReportYear { get; set; }
        public String ElectionType { get; set; }
        public String ReportType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String SchedDate { get; set; }
        public String FilingSchedDesc { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingFirstName { get; set; }
        public String FilingMiddleName { get; set; }
        public String FilingLastName { get; set; }
        public String FilingCountry { get; set; }
        public String FilingStreetName { get; set; }
        public String FilingCity { get; set; }
        public String FilingState { get; set; }
        public String FilingZip { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String PayNumber { get; set; }
        public String OriginalAmount { get; set; }
        public String OwedAmount { get; set; }
        public String ReceiptTypeDesc { get; set; }
        public String TransferTypeDesc { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String OriginalDate { get; set; }
        public String LoanerCode { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String TransExplanation { get; set; }
        public String RLiability { get; set; }
        public String LoanLiabilityNumber { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String CreatedDate { get; set; }     
    }

    public class FilingTransactionDataModelCSVPCFB
    {
        public String FilerId { get; set; }
        public String CandidateCommitteeName { get; set; }
        public String FilerType { get; set; }
        public String ReportYear { get; set; }
        public String ElectionType { get; set; }
        public String ReportType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String SchedDate { get; set; }
        public String FilingSchedDesc { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingFirstName { get; set; }
        public String FilingMiddleName { get; set; }
        public String FilingLastName { get; set; }
        public String FilingCountry { get; set; }
        public String FilingStreetName { get; set; }
        public String FilingCity { get; set; }
        public String FilingState { get; set; }
        public String FilingZip { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String PayNumber { get; set; }
        public String OriginalAmount { get; set; }
        public String OwedAmount { get; set; }
        public String ReceiptTypeDesc { get; set; }
        public String TransferTypeDesc { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String OriginalDate { get; set; }
        public String LoanerCode { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String TransExplanation { get; set; }
        public String RLiability { get; set; }
        public String LoanLiabilityNumber { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String CreatedDate { get; set; }
        //public String Balance { get; set; }
        public String RClaim { get; set; }
        public String InDistrict { get; set; }
        public String RMinor { get; set; }
        public String RVendor { get; set; }
        public String RLobbyist { get; set; }
        public String TreasurerEmployer { get; set; }
        public String TreasurerOccuptaion { get; set; }
        public String TreaAddr1 { get; set; }
        public String TreaCity { get; set; }
        public String TreaState { get; set; }
        public String TreaZipCode { get; set; }
    }

    public class FilingTransactionIECommitteeDataModelCSV
    {
        public String FilerId { get; set; }
        public String CandidateCommitteeName { get; set; }
        public String FilerType { get; set; }
        public String ReportYear { get; set; }
        public String ElectionType { get; set; }
        public String ReportType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String SchedDate { get; set; }
        public String FilingSchedDesc { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String FilingEntityName { get; set; }
        public String FilingFirstName { get; set; }
        public String FilingMiddleName { get; set; }
        public String FilingLastName { get; set; }
        public String FilingCountry { get; set; }
        public String FilingStreetName { get; set; }
        public String FilingCity { get; set; }
        public String FilingState { get; set; }
        public String FilingZip { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String PayNumber { get; set; }
        public String OriginalAmount { get; set; }
        public String OwedAmount { get; set; }
        public String ReceiptTypeDesc { get; set; }
        public String TransferTypeDesc { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String OriginalDate { get; set; }
        public String LoanerCode { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String TransExplanation { get; set; }
        public String RLiability { get; set; }
        public String LoanLiabilityNumber { get; set; }
        public String TransNumber { get; set; }
        public String TransMapping { get; set; }
        public String CreatedDate { get; set; }
        public String RIESupported { get; set; }
        public String RSupportOppose { get; set; }        
    }

    public class FilingTransDataModel
    {
        public String FilerId { get; set; }
        public String CommitteeId { get; set; }
        public String ReportYearId { get; set; }
        public String OfficeTypeId { get; set; }
        public String ReportYear { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosureType { get; set; }
        public String DisclosurePeriod { get; set; }
        public String CutOffDate { get; set; }
        public String FilingDate { get; set; }
        public String FilingTransID { get; set; }
        public String FilingSchedID { get; set; }                
        public String SchedName { get; set; }
        public String ElectionDateId { get; set; }
        public String Loan_Lib_Num { get; set; }
        public String Created_By { get; set; }
        public String TransNumber { get; set; }
        public String MunicipalityID { get; set; }
        public String CommTypeId { get; set; }
        public String LabelId { get; set; }
    }

    public class ContributionTypeModel
    {
        public String ContributionTypeId { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String ContributionTypeAbbrev { get; set; }
    }

    public class ContributorNameModel
    {
        public String ContributorTypeId { get; set; }
        public String ContributorTypeDesc { get; set; }
        public String ContributorTypeAbbrev { get; set; }
        public String ContributorTypeSort { get; set; }
    }

    public class DisclosurePreiodModel
    {
        public String FilingTypeId { get; set; }
        public String FilingDesc { get; set; }
        public String FilingAbbrev { get; set; }
    }

    public class ElectionDateModel
    {
        public String ElectId { get; set; }
        public String ElectDate { get; set; }
    }

    public class FilerCommitteeModel
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

    public class PaymentMethodModel
    {
        public String PaymentTypeId { get; set; }
        public String PaymentTypeDesc { get; set; }
        public String PaymentTypeAbbrev { get; set; }
    }

    public class PurposeCodeModel
    {
        public String PurposeCodeId { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String PurposeCodeAbbrev { get; set; }
    }

    public class ReceiptCodeModel
    {
        public String ReceiptCodeId { get; set; }
        public String ReceiptCodeDesc { get; set; }
        public String ReceiptCodeAbbrev { get; set; }
    }

    public class ReceiptTypeModel
    {
        public String ReceiptTypeId { get; set; }
        public String ReceiptTypeDesc { get; set; }
        public String ReceiptTypeAbbrev { get; set; }
    }

    public class TransferTypeModel
    {
        public String TransferTypeId { get; set; }
        public String TransferTypeDesc { get; set; }
        public String TransferTypeAbbrev { get; set; }
    }

    public class ElectionYearModel
    {
        public String ElectionYearId { get; set; }
        public String ElectionYearValue { get; set; }
    }

    public class ElectionTypeModel
    {
        public String ElectionTypeId { get; set; }
        public String ElectionTypeDesc { get; set; }
    }

    public class FilingCutOffDateModel
    {
        public String PoliticalCalDateId { get; set; }
        public String PoliticalCalLabelId { get; set; }
        public String FilingDueDate { get; set; }
        public String CutOffDate { get; set; }
        public String PriGenDate { get; set; }
    }

    public class ContributorTypesModel
    {
        public String ContributorTypeId { get; set; }
        public String ContributoryTypeDesc { get; set; }
    }

    public class DisclosureTypeModel
    {
        public String DisclosureTypeId { get; set; }
        public String DisclosureTypeDesc { get; set; }
    }

    public class TransactionTypeModel
    {
        public String TransactionTypeId { get; set; }
        public String TransactionTypedesc { get; set; }
    }

    public class PartnerModel
    {
        public String PartnerId { get; set; }
        public String PartnerDesc { get; set; }
    }

    public class TransactionTypesModel
    {
        public String FilingSchedId { get; set; }
        public String FilingSchedDesc { get; set; }
        public String FilingSchedAbbrev { get; set; }
    }

    public class DisclosureTypesModel
    {
        public String DisclosureTypeId { get; set; }
        public String DisclosureTypeDesc { get; set; }
        public String DisclosureSubTypeDesc { get; set; }
    }

    public class FilingTransactionsModel
    {
        public String FilerId { get; set; }
        public String FilingPeriodId { get; set; }
        public String FilingCategoryId { get; set; }
        public String ElectId { get; set; }
        public String RFilingDate { get; set; }
        public String FilingScheduleId { get; set; }
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
        public String LiabilityOrgAmt { get; set; }
        public String LiabilityOwedAmt { get; set; }
        public String LiabilityPartialAmt { get; set; }
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
        public String OriginalPayeeName { get; set; }
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
        public String TransNumberOrg { get; set; }
        public String IsExpSubcontractor { get; set; }
        public String IsExpPartialPay { get; set; }
        public String IsExistingLiab { get; set; }
        public String IsLiabPartialForgiven { get; set; }
        public String ParentFilingEntityId { get; set; }
        public String RIEIncluded { get; set; }
        public String RIESupported { get; set; }
        public String FilingsId { get; set; }
        public String ExistsLiabTransNumber { get; set; }
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

    public class FilingTransactionsTransID
    {
        public String TransID { get; set; }
    }
        public class OfficeTypeModel
    {
        public String OfficeTypeId { get; set; }
        public String OfficeTypeDesc { get; set; }
    }

    public class CountyModel
    {
        public String CountyId { get; set; }
        public String CountyDesc { get; set; }
    }

    public class MunicipalityModel
    {
        public String MunicipalityId { get; set; }
        public String MunicipalityDesc { get; set; }
    }

    public class DisclosurePeriods
    {
        public String ID { get; set; }
        public String Name { get; set; }
    }

    public class ElectionDate
    {
        public String Id { get; set; }
        public String Name { get; set; }
    }

    public class AutoCompFLNameAddressModel
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

    public class ContrInKindPartnersModel
    {
        public String FilingTransId { get; set; }
        public String FilingEntityId { get; set; }
        public String PartnershipName { get; set; }
        public String PartnerName { get; set; }
        public String SubcontractorName { get; set; }
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
        public String DateReceivedPrimary { get; set; }
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

    public class PartnersData
    {
        public String PartnershipName { get; set; }
        [Required(ErrorMessage = "First Name Required.")]
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String StreetName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Zip4 { get; set; }
        public String Amount { get; set; }
        public String PartnerExplanation { get; set; }
    }

    /// <summary>
    /// Liability
    /// </summary>
    public class LiabilityModel
    {
        public String strLiabilityId { get; set; }
        public String strLiabilityName { get; set; }
    }

    /// <summary>
    /// Subcontractor
    /// </summary>
    public class SubcontractorModel
    {
        public String strSubcontractorId { get; set; }
        public String strSubcontractorName { get; set; }
    }

    /// <summary>
    /// ItemizedModel
    /// </summary>
    public class ItemizedModel
    {
        public String strItemizedId { get; set; }
        public String strItemizedName { get; set; }
    }

    public class SupportedIEModel
    {
        public String strSupportedId { get; set; }
        public String strSupportedName { get; set; }
    }

    public class LoanerCodeModel
    {
        public String LoanerID { get; set; }
        public String LoanerDesc { get; set; }
    }

    public class OutstandingLiabilityModel
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
        public String TransNumber { get; set; }
    }

    public class DateIncurredModel
    {
        public String DateIncurredId { get; set; }
        public String DateIncurredValue { get; set; }
        public String AmountLiability { get; set; }
        public String OrginalDate { get; set; }
        public String OutstandingAmount { get; set; }
    }

    public class OriginalAmountModel
    {
        public String OriginalAmountId { get; set; }
        public String OutstandingAmount { get; set; }
    }


    public class GetSearchForScheduledIModel
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

    public class ExpPaymentTransIdPopUpSchedFModel
    {
        public String TransNumber { get; set; }
        public String FilingSchedId { get; set; }
        public String ScheduleDate { get; set; }
        public String OrgAmount { get; set; }
    }
    public class ExpPaymentOriginalNameModel
    {
        public String FilingEntityId { get; set; }
        public String FilingEntityName { get; set; }
    }

    public class ExpPaymentOriginalAmountModel
    {        
        public String OriginalAmount { get; set; }
        public String TransNumber { get; set; }
    }

    public class ExpPaymentOriginalExpenseDateModel
    {        
        public String OriginalExpenseDate { get; set; }
        public String TransNumber { get; set; }
    }

    public class ValidateFilerInfoModel
    {
        public String FilerID { get; set; }
        public String RoleID { get; set; }
        public String Name { get; set; }
    }

    public class DistrictModel
    {
        public String District_ID { get; set; }
        public String Parent_District_ID { get; set; }
    }

    public class OfficeModel
    {
        public String OfficeId { get; set; }
        public String OfficeDesc { get; set; }
    }

    public class AutoCompleteSchedRModel
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

    public class InLieuOfStatementNonItemModel
    {
        public String FilingsId { get; set; }
        public String ElectionYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
        public String DateSubmitted { get; set; }
        public String FilingDate { get; set; }
    }

    public class AddInLieuOfStatementModel
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
    public class PersonNameAndTreasurerDataModel
    {
        public String PersonName { get; set; } 
        public String TreasId { get; set; }
    }


    public class FilerInfoModel
    {
        public String Trans_Cand_ID { get; set; }
        public String Filer_ID { get; set; }
        public String Cand_Comm_ID { get; set; }
        public String Cand_Comm_Name { get; set; }
        public String PersonID { get; set; }
        public String Name { get; set; }   
        public String Reconcile { get; set; }
    }

    public class Menu
    {
        public String MenuName { get; set; }
    }

    public class NonItemIETreasurerModel
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

    public class NonItemCampaignMaterialModel
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

    public class NonItemCampaignMaterialDataModel
    {
        public String CampaignMaterialId { get; set; }
        public String DateSubmitted { get; set; }
        public String FilingMethodId { get; set; }
        public String FilingMethodDesc { get; set; }
        public String CampaignMaterialDesc { get; set; }
        public String CampMatrFileType { get; set; }
        public String CampMatrFileSize { get; set; }
        public String ScanDocId { get; set; }
        public String RCampMatr { get; set; }
        public String RAmended { get; set; }
        public String CreatedDate { get; set; }
        public String CamapaignMaterialCount { get; set; }
    }

    public class FilingMthodModel
    {
        public String FilingMethodId { get; set; }
        public String FilingMethodDesc { get; set; }
    }

    public class CabinetReturnValModel
    {
        public String TokenID { get; set; }
        public String RepositoryID { get; set; }
        public String CabinetID { get; set; }
        public String ManagerID { get; set; }
        public String ExtensionID { get; set; }
        public String ExtensionName { get; set; }
        public String TabID { get; set; }
        public String TemplateID { get; set; }
        public String DocumentID { get; set; }        
        public String FolderID { get; set; }        
        public String Extension { get; set; }        
        public String FormattedFileSize { get; set; }        
        public String Keyword { get; set; }
    }
        
    public class CampMatrDocumentIdModel
    {        
        public String strCampMatrFileName { get; set; }        
        public Stream varStream { get; set; }
        public Byte[] fileBytes { get; set; }
        public String strCampMatrFilerId { get; set; }
        public String FolderFilerId { get; set; }
        public String FolderElectionYear { get; set; }
        public String FolderDisclosurePeriod { get; set; }
        public String FileExtension { get; set; }
        public String PageName { get; set; }

    }

    public class UploadFileNTDriveModel
    {
        public String CampMatrFileName { get; set; }
        public Byte[] FileBytes { get; set; }
        public String FilerIdNTDrive { get; set; }
        public String ElectionYearNTDrive { get; set; }
        public String DisclosurePeriodNTDrive { get; set; }
    }

    public class CabinetDownloadObjectModel
    {
        public Byte[] FileByte { get; set; }
        public String FileName { get; set; }
    }

    public class FilingDatesOffCycleModel
    {
        public String FilingDateId { get; set; }
        public String FilingDate { get; set; }
    }

    public class ResigTermTypeModel
    {
        public String ResigTermTypeId { get; set; }
        public String ResigTermTypeDesc { get; set; }
        public String FilingsId { get; set; }
    }

    public class LiabilityDetailsModel
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

    public class CheckAmendStatusModel
    {
        public String Submit_Date { get; set; }
        public String IsAmend { get; set; }
    }

    public class GetEditFlagDataModel
    {
        public String Is_Edit { get; set; }
        public String VALIDATE_FILINGS { get; set; }
        public String filerID { get; set; }
    }

    public class EFSPDFRequestModel
    {
        public String ReportName { get; set; }
        public String FilingTransId { get; set; }
        public String FilerId { get; set; }
        public String ElectionYearId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String FilingDate { get; set; }
        public String ElectionTypeID { get; set; }
        public String ElectionDateID { get; set; }
        public String SubmitDate { get; set; }
    }

    public class EFSPDFResponseModel
    {
        public Byte[] fileByte { get; set; }
        public String fileURL { get; set; }
        public string fileName { get; set; }
    }

    public class ScheduleIdModel
    {
        public String ScheduleId { get; set; }
    }

    public class SchedR_ISExists_Model
    {
        public String FilerId { get; set; }
        public String ReportYearId { get; set; }
        public String Filing_Enty_First_Name { get; set; }
        public String Filing_Enty_Middle_Name { get; set; }
        public String Filing_Enty_Last_Name { get; set; }
        public String Office_Id { get; set; }
        public String District_Id { get; set; }
    }

    public class VendorNames
    {
        public String VendorId { get; set; }
        public String VendorName { get; set; }
    }

    public class ImportDisclosureRptsData
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
        public String CreatedDate24Hours { get; set; }
        public String ElectionYearId { get; set; }
        public String OfficeTypeId { get; set; }
        public String ElectionTypeId { get; set; }
        public String ElectionDateId { get; set; }
        public String FilingTypeId { get; set; }
        public String FilingCategoryId { get; set; }
        public String VendorName { get; set; }
    }

    public class ImportDisclsoureRptsFilings
    {
        public String FilerId { get; set; }
        public String FilingPeriodId { get; set; }
        public String FilingCategoryId { get; set; }
        public String ElectId { get; set; }
        public String ResigTermTypeId { get; set; }
        public String RFilingDate { get; set; }
        public String FilingScheduleId { get; set; }
        public String CreatedBy { get; set; }
    }

    public class FilingExistsAndValidationResults
    {
        public String FilingExists { get; set; }
        public String ValidationFailed { get; set; }
        public String ValidationMessages { get; set; }
        public String CSVRowNumber { get; set; }
        public String ImportFileName { get; set; }
        public String ReportYearExists { get; set; }
        public String FilerIdExists { get; set; }
    }

    public class FilingsForFilingCutOffDate
    {
        public String FilingsId { get; set; }
        public String ElectionYearId { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String ElectionDateId { get; set; }
        public String FilingDate { get; set; }
    }

    public class CheckFilingDateModel
    {
        public String ElectionYearId { get; set; }
        public String ElectionTypeId { get; set; }
        public String OfficeTypeId { get; set; }
        public String FilingTypeId { get; set; }
        public String ElectionDateId { get; set; }
    }

    public class ErrorMessagesFiledNames
    {
        public String ErrorMessage { get; set; }
        public String FieledName { get; set; }
    }

    public class VendorImportDataModel
    {
        public String FilingsId { get; set; }
        public String VendorId { get; set; }
        public String VendorFileSize { get; set; }
        public String VendorTransCount { get; set; }
        public String CreatedBy { get; set; }
        public DateTime dtCreatedDate { get; set; }
        public String strLastSetOfTrans { get; set; }
    }

    public class VendorImportValidationModel
    {
        public String Id { get; set; }
        public String TableName { get; set; }
    }

    public class ImportErrorMessageModel
    {
        public String RowNumber { get; set; }
        public String ColumnName { get; set; }
        public String ErrorMessages { get; set; }
    }

    public class ReportSourceModel
    {
        public String FilingEntityId { get; set; }
        public String ReportSource { get; set; }
        public String StreetAddress1 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String Country { get; set; }
    }

    public class SupportOpposeModel
    {
        public String strSupportOpposeId { get; set; }
        public String strSupportOpposeName { get; set; }
    }
}
