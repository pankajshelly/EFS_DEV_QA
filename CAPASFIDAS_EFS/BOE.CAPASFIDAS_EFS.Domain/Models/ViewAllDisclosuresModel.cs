using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CommunicationTypeModel
    {
        public String CommunicationTypeID { get; set; }
        public String CommunicationTypeDesc { get; set; }
    }

    public class PIDAGridModel
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

    public class OfficeType
    {
        public String OfficeTypeID { get; set; }
        public String OfficeTypeDesc { get; set; }
    }

    public class ElectionType
    {
        public String ElectionTypeID { get; set; }
        public String ElectionTypeDesc { get; set; }
    }

    public class Election_Date
    {
        public String ElectionDateId { get; set; }
        public String ElectionDate { get; set; }
    }

    public class County
    {
        public String CountyID { get; set; }
        public String CountyBoard { get; set; }
    }

    public class Municipality
    {
        public String MunicipalityID { get; set; }
        public String MunicipalityDesc { get; set; }
    }

    public class SupportingDocumentsGridModel
    {
        public String SupportingDocID { get; set; }
        public String ScanDocID { get; set; }
        public String DateReceived { get; set; }
        public String DocumentType { get; set; }
        public String FileSize { get; set; }
        public String FileType { get; set; }
        public String FilingMethod { get; set; }
    }

    public class TransactionGridModel
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
        public String EmployerOccupation { get; set; }
        public String EmployerName { get; set; }
    }

    public class CampaignMaterialsGridModel
    {
        public String CampaignMaterialID { get; set; }
        public String FilingMethodID { get; set; }
        public String ScanDocID { get; set; }
        public String DateSubmitted { get; set; }
        public String FilingMethodDesc { get; set; }
        public String CampaignMaterialDesc { get; set; }
        public String FileSize { get; set; }
        public String FileType { get; set; }
        public String CreatedDate { get; set; }
        public String CampaignMaterialAvailable { get; set; }
    }

    public class DisclosureGridModel
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
        public String Municipality{ get; set; }
        public String CCDocType { get; set; }
        public String PCFBMonthlyFilingCheck { get; set; }
    }

    public class TransactionDetailsGridModel
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

    public class DocumentTypeModel
    {
        public String DocumentTypeId { get; set; }
        public String DocumentTypeDesc { get; set; }
    }

}
