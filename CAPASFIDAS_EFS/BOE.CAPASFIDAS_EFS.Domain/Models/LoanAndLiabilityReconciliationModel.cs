using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{

    public class LoanReceivedGridModel
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

    public class LoanPaymentGridModel
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

    public class OutstandingLiabilityGridModel
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

    public class LiabilityLoanForgivenGridModel
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

    public class ExpenditurePaymentGridModel
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

}
