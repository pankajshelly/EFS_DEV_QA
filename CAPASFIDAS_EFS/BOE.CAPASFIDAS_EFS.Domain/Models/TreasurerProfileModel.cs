using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TreasurerProfileModel
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

    public class TreasurerCommitteeInformationModel
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

    public class TreasAssistantInformationModel
    {
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }
        public String PersonID { get; set; }
        public String Status { get; set; }
    }

    public class TreasurerHistoryModel
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

    public class TreasAdditionalCommitteeContactModel
    {
        public String PersonPrefix { get; set; }
        public String PersonFirstName { get; set; }
        public String PersonMiddleName { get; set; }
        public String PersonLastName { get; set; }
        public String PersonSuffix { get; set; }
    }

    public class TreasDepositoryBankInformationModel
    {
        public String BankID { get; set; }
        public String BankName { get; set; }
        public String AddrNum { get; set; }
        public String AddrStrName { get; set; }
        public String AddrCity { get; set; }
        public String AddrState { get; set; }
        public String AddrZip { get; set; }
        public String AddrZip4 { get; set; }
        public String ADDR_ID { get; set; }
        public String PERSON_ID { get; set; }
        public String COMM_ID { get; set; }
        public String BankAccountTypeID { get; set; }
        public String CreatedBy { get; set; }
    }

    public class TreasCandidateSupportOpposeModel
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

    public class TreasAuthorizedToSignCheckModel
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

    public class TreasBallotIssuesModel
    {
        public String BallotIssues { get; set; }
        public String SupposeOppose { get; set; }
    }

    public class SubTreasurerPersonModel
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

    public class AuthorizedToSignCheckModel
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
}
