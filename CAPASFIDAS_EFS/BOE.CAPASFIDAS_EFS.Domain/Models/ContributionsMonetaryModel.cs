using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContributionsMonetaryModel
    {
        public String TransactionType { get; set; }
        public String DateReceived { get; set; }
        public String ReceiptCode { get; set; }        
        public String ContributorName { get; set; }
        public String PartnershipName { get; set; }
        public String FirstName { get; set; }
        public String MI { get; set; }
        public String LastName { get; set; }
        public String TransferorName { get; set; }        
        public String Street { get; set; }
        public String StreetName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip5 { get; set; }
        public String Zip4 { get; set; }
        public String Method { get; set; }
        public String Check { get; set; }
        public String Amount { get; set; }
        public String Explanation { get; set; }
        public String LenderGuarantorSingerName { get; set; }
        public String PurposeCode { get; set; }
        public String ReceiptType { get; set; }
        public String OriginalExpenseDate { get; set; }
        public String OriginalAmt { get; set; }
        public String TransferType { get; set; }
        public String ContributionType { get; set; }
        public String LoanDate { get; set; }
        public String LoanerCode { get; set; }
        public String DateRefundReceived { get; set; }
        public String PayorName { get; set; }
        public String ReceiptSource { get; set; }
        public String PayeeName { get; set; }
        public String DatePaid { get; set; }
        public String TransfereeName { get; set; }
        public String LenderName { get; set; }
        public String OriginalLoanDate { get; set; }
        public String OriginalLoan { get; set; }
        public String AmtRepaid { get; set; }
        public String DateRefunded { get; set; }
        public String OriginalCntrbDate { get; set; }
        public String OriginalCntrbAmt { get; set; }
        public String RefundAmt { get; set; }
        public String DateForgiven { get; set; }
        public String OriginalLiabilityDate { get; set; }
        public String OriginalLiabilityAmt { get; set; }
        public String AmtForgiven { get; set; }
        public String CreditorName { get; set; }
        public String DateAllocated { get; set; }
        public String ElectionYearAllocated { get; set; }
        public String District { get; set; }
        public String Office { get; set; }
        public String OriginalAllocationDate { get; set; }
        public String OriginalAmtAllocated { get; set; }
        public String AmtAllocatedThisReport { get; set; }
        public String AmtAllocatedAllReport { get; set; }
        public String ContractorName { get; set; }
        public String ExpenditureCode { get; set; }
        public String AmountAttributed { get; set; }
        public String Balance { get; set; }
        public String NegBalance { get; set; }
        public String PosBalance { get; set; }
    }

    public class TransactionTypesSummeryDataModel
    {
        public String FilingScheduleId { get; set; }
        public String FilingScheduleDesc { get; set; }
        public String ScheduleDate { get; set; }
        public String FilingEntityName { get; set; }
        public String OrginalDate { get; set; }
        public String RBankCode { get; set; }
        public String ElectionYear { get; set; }
        public String FilingEntityFirstName { get; set; }
        public String FilingEntityMiddleName { get; set; }
        public String FilingEntityLastName { get; set; }
        public String DistOffCandBalProp { get; set; }
        public String FilingEntityStreetNo { get; set; }
        public String FilingEntityStreetName { get; set; }
        public String FilingEntityCity { get; set; }
        public String FilingEntityState { get; set; }
        public String FilingEntityZip5 { get; set; }
        public String FilingEntityZip4 { get; set; }
        public String ReceiptTypeId { get; set; }
        public String ReceiptTypeDesc { get; set; }        
        public String TransferTypeId { get; set; }
        public String TransferTypeDesc { get; set; }
        public String OriginalAmount { get; set; }
        public String ContributionTypeId { get; set; }
        public String ContributionTypeDesc { get; set; }
        public String PurposeCodeId { get; set; }
        public String PurposeCodeDesc { get; set; }
        public String PaymentTypeId { get; set; } 
        public String PaymentTypeDesc { get; set; } // Method
        public String PayNumber { get; set; } // Check #
        public String TransactionExplanation { get; set; }
        public String Balance { get; set; }
        public String NegBalance { get; set; }
        public String PosBalance { get; set; }
    }

    public class TotalContributionsModel
    {
        public String DateReceived { get; set; }
        public String ReceiptCode { get; set; }
        public String ContributorName { get; set; }
        public String PartnershipName { get; set; }
        public String FirstName { get; set; }
        public String MI { get; set; }
        public String LastName { get; set; }
        public String TransferorName { get; set; }
        public String Street { get; set; }
        public String StreetName { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip5 { get; set; }
        public String Zip4 { get; set; }
        public String Method { get; set; }
        public String Check { get; set; }
        public String Amount { get; set; }
        public String Balance { get; set; }
        public String Explanation { get; set; }
        public String LenderGuarantorSingerName { get; set; }
        public String PurposeCode { get; set; }
        public String ReceiptType { get; set; }
        public String OriginalExpenseDate { get; set; }
        public String OriginalAmt { get; set; }
        public String TransferType { get; set; }
        public String ContributionType { get; set; }
        public String LoanDate { get; set; }
        public String LoanerCode { get; set; }
        public String DateRefundReceived { get; set; }
        public String PayorName { get; set; }
        public String ReceiptSource { get; set; }
        public String PayeeName { get; set; }
        public String DatePaid { get; set; }
        public String TransfereeName { get; set; }
        public String LenderName { get; set; }
        public String OriginalLoanDate { get; set; }
        public String OriginalLoan { get; set; }
        public String AmtRepaid { get; set; }
        public String DateRefunded { get; set; }
        public String OriginalCntrbDate { get; set; }
        public String OriginalCntrbAmt { get; set; }
        public String RefundAmt { get; set; }
        public String DateForgiven { get; set; }
        public String OriginalLiabilityDate { get; set; }
        public String OriginalLiabilityAmt { get; set; }
        public String AmtForgiven { get; set; }
        public String CreditorName { get; set; }
        public String DateAllocated { get; set; }
        public String ElectionYearAllocated { get; set; }
        public String District { get; set; }
        public String Office { get; set; }
        public String OriginalAllocationDate { get; set; }
        public String OriginalAmtAllocated { get; set; }
        public String AmtAllocatedThisReport { get; set; }
        public String AmtAllocatedAllReport { get; set; }
        public String ContractorName { get; set; }
        public String ExpenditureCode { get; set; }
        public String AmountAttributed { get; set; }
    }
}
