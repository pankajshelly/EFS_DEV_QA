using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CandidateProfileModel
    {
        public String FilerType { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String Municipality { get; set; }
        public String ElectionYear { get; set; }

    }

    //Address
    public class ShowAddress
    {
        public String ADDR_ID { get; set; }
        public String ADDR_TYPE_ID { get; set; }
        public String ADDR_TYPE_DESC { get; set; }
        public String ADDR_STR_NUM { get; set; }
        public String ADDR_STR_NAME { get; set; }
        public String ADDR_ADDR1 { get; set; }
        public String ADDR_ADDR2 { get; set; }
        public String ADDR_CITY { get; set; }
        public String ADDR_STATE { get; set; }
        public String ADDR_ZIP5 { get; set; }
        public String ADDR_ZIP4 { get; set; }
        public String BEST_CONTACT_ID { get; set; }
        public String BEST_CONTACT_DESC { get; set; }
    }

    //Contract
    public class ShowContact
    {
        public String BestContract_ID { get; set; }
        public String ContactTypeId { get; set; }
        public String BestContract_Desc { get; set; }
        public String Phone { get; set; }
        public String EmailAddress { get; set; }
    }

    public class ShowContactModel
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
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
    }

    public class ShowAddressModel
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

    //Address Type
    public class AddressType
    {
        public String ADDR_TYPE_ID { get; set; }
        public String ADDR_TYPE_DESC { get; set; }
    }

    //Best Contact
    public class BestContact
    {
        public String BEST_CONTACT_ID { get; set; }
        public String BEST_CONTACT_DESC { get; set; }
    }

    public class UpdateAddress
    {
        public String ADDR_ID { get; set; }
        public String ADDR_TYPE_ID { get; set; }
        public String ADDR_STR_NUM { get; set; }
        public String ADDR_STR_NAME { get; set; }
        public String ADDR_ADDR1 { get; set; }
        public String ADDR_ADDR2 { get; set; }
        public String ADDR_CITY { get; set; }
        public String ADDR_STATE { get; set; }
        public String ADDR_ZIP { get; set; }
        public String ADDR_ZIP4 { get; set; }
        public String BEST_CONTACT_ID { get; set; }
        public String ModifyBy { get; set; }
    }

    //Title
    public class Title
    {
        public String TITLE_ID { get; set; }
        public String TITLE_DESC { get; set; }
    }

    //Contact Type
    public class ContactType
    {
        public String CONTACT_TYPE_ID { get; set; }
        public String CONTACT_TYPE_DESC { get; set; }
    }

    public class AddContact
    {
        public String TITLE_ID { get; set; }
        public String BEST_CONTACT_ID { get; set; }
        public String SITE_ID { get; set; }
        public String AGENCY_ID { get; set; }
        public String SUB_AGENCY_ID { get; set; }
        public String CONTACT_TYPE_ID { get; set; }
        public String PHONE { get; set; }
        public String EMAIL { get; set; }
        public String FAX { get; set; }
        public String URL { get; set; }
        public String PERSON_FIRST_NAME { get; set; }
        public String PERSON_MIDDLE_NAME { get; set; }
        public String PERSON_LAST_NAME { get; set; }
        public String PERSON_SUFFIX { get; set; }
        public String PERSON_PREFIX { get; set; }
        public String Created_BY { get; set; }
    }

    ////Contact
    //public class ShowContact
    //{
    //    public String CONTACT_ID { get; set; }
    //    public String BEST_CONTACT_ID { get; set; }
    //    public String PERSON_ID { get; set; }
    //    public String CONTACT_TYPE_ID { get; set; }
    //    public String TITLE_ID { get; set; }
    //    public String BEST_CONTACT_DESC { get; set; }
    //    public String TITLE_DESC { get; set; }
    //    public String PERSON_PREFIX { get; set; }
    //    public String PERSON_FIRST_NAME { get; set; }
    //    public String PERSON_MIDDLE_NAME { get; set; }
    //    public String PERSON_LAST_NAME { get; set; }
    //    public String PERSON_SUFFIX { get; set; }
    //    public String CONTACT_TYPE_DESC { get; set; }
    //    public String PHONE { get; set; }
    //    public String EMAIL { get; set; }
    //    public String FAX { get; set; }
    //    public String URL { get; set; }
    //}

    //Update Contact
    public class UpdateContact
    {
        public String CONTACT_ID { get; set; }
        public String PERSON_ID { get; set; }
        public String TITLE_ID { get; set; }
        public String BEST_CONTACT_ID { get; set; }
        public String CONTACT_TYPE_ID { get; set; }
        public String PHONE { get; set; }
        public String EMAIL { get; set; }
        public String FAX { get; set; }
        public String URL { get; set; }
        public String PERSON_FIRST_NAME { get; set; }
        public String PERSON_MIDDLE_NAME { get; set; }
        public String PERSON_LAST_NAME { get; set; }
        public String PERSON_SUFFIX { get; set; }
        public String PERSON_PREFIX { get; set; }
        public String ModifyBy { get; set; }
    }

    // Depositorty/Bannk Information
    public class DepositoryBankInfo
    {
        public String BankId { get; set; }
        public String AddressID { get; set; }
        public String DepositoryBankName { get; set; }
        public String StreetNum { get; set; }
        public String StreetName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip5 { get; set; }
        public String Zip4 { get; set; }
       
    }

    // AuthSignChecks
    public class AuthSignChecks
    {
        public String ContactId { get; set; }
        public String Prefix { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String MI { get; set; }
        public String Suffix { get; set; }
    }

    // Asistant Treasurer Information
    public class AssistTreasurerInfo
    {
        public String ContactId { get; set; }
        public String Prefix { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String MI { get; set; }
        public String Suffix { get; set; }
    }

    public class Status
    {
        public String StatusId { get; set; }
        public String StatusName { get; set; }
    }

    // Authorized Committees
    public class AuthorizedCommittees
    {
        public String CommitteeID { get; set; }
        public String FilerID { get; set; }
        public String CommitteeName { get; set; }
        public String Status { get; set; }
        public String RegistrationDate { get; set; }
        public String TerminationDate { get; set; }
    }

    // Committee Information
    public class CommitteeInfo
    {
        public String CommiteeID { get; set; }
        public String FilerID { get; set; }
        public String CommitteeName { get; set; }
        public String Status { get; set; }
        public String RegistrationDate  { get; set; }
        public String TerminationDate { get; set; }
    }

    // Treasurer History
    public class TreasurerHistory
    {
        public String TreasurerID { get; set; }
        public String Prefix { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String MI { get; set; }
        public String Suffix { get; set; }
        public String Status { get; set; }
        public String RegDate { get; set; }
        public String ResignDate { get; set; }
    }

    // Candidates to be Supported or Opposed
    public class CandidateSuppOpp
    {
        public String CandidateId { get; set; }
        public String ElectionYear { get; set; }
        public String Office { get; set; }
        public String District { get; set; }
        public String CandidateFullName { get; set; }
        public String SupportOppose { get; set; }
        public String AuthorizationDate { get; set; }
        public String NonExpenditureDate { get; set; }
    }

    // Ballot Issues
    public class BallotIssues
    {
        public String BallotId { get; set; }
        public String BallotIssue { get; set; }
        public String SupportOppose { get; set; }
    }

    public class SuppDocumentsModel
    {
        public String Received { get; set; }
        public String DocumentType { get; set; }
        public String Status { get; set; }
        public String StatusDate { get; set; }
        public String Pages { get; set; }
        public String DeliveryType { get; set; }
        public String DateFiled { get; set; }
    }

    public class DepositoryBankInfoModel
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

    public class CandAuthCommitteesModel
    {
        public String FilerId { get; set; }
        public String CommitteeName { get; set; }
        public String Status { get; set; }
        public String RegistrationDate { get; set; }
        public String TerminationDate { get; set; }
    }

    public class CandidateHeaderDataModel
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

    public class AddressDataModel
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
        public String AddresssCity { get; set; }
        public String AddressState { get; set; }
        public String AddressZip { get; set; }
        public String AddressZip4 { get; set; }
        public String CreatedBy { get; set; }
        public String ModifiedBy { get; set; }
    }

    public class AddressTypesModel
    {
        public String AddressTypeId { get; set; }
        public String AddressTypeDescription { get; set; }
    }

    public class BestContactTypesModel
    {
        public String BestContactTypeId { get; set; }
        public String BestContactTypeDesc { get; set; }
    }

    public class ContactTypesModel
    {
        public String ContactTypeId { get; set; }
        public String ContactTypeDescription { get; set; }
    }

    public class BankAccountTypesModel
    {
        public String AccountTypeId { get; set; }
        public String AccountTypeDesc { get; set; }
    }
}
