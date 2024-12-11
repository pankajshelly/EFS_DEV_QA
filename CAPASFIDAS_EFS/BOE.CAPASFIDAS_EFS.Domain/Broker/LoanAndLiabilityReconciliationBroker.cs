// Creighton Newsom
// LoanAndLiabilitiesReconciliation Page
using System;
using System.Collections.Generic;
using BLL;
using Models;

namespace Broker
{
    public class LoanAndLiabilityReconciliationBroker
    {
        // Create BLL Object
        LoanAndLiabilityReconciliationBLL objLoanAndLiabilityReconciliationBLL = new LoanAndLiabilityReconciliationBLL();

        #region "GetLoanReceivedGridData"
        // FUNCTION GETS DATA FOR THE LOAN RECEIVED GRID
        // FILERID IS REQUIRED
        public IList<LoanReceivedGridModel> GetLoanReceivedGridData(String strFilerID)
        {
            IList<LoanReceivedGridModel> lstLoanReceivedGrid = new List<LoanReceivedGridModel>();
            lstLoanReceivedGrid = objLoanAndLiabilityReconciliationBLL.GetLoanReceivedGridData(strFilerID);
            return lstLoanReceivedGrid;
        }

        #endregion

        #region "GetLoanPaymentGridData"
        // FUNCTION GETS DATA FOR THE LOAN PAYMENT GRID
        // FILERID IS REQUIRED
        public IList<LoanPaymentGridModel> GetLoanPaymentGridData(String strFilerID)
        {
            IList<LoanPaymentGridModel> lstLoanPaymentGrid = new List<LoanPaymentGridModel>();
            lstLoanPaymentGrid = objLoanAndLiabilityReconciliationBLL.GetLoanPaymentGridData(strFilerID);
            return lstLoanPaymentGrid;
        }

        #endregion

        #region "GetOutstandingLiabilityGridData"
        // FUNCTION GETS DATA FOR THE OUTSTANDING LIABILITIES GRID
        // FILERID AND DATATORETURN ARE REQUIRED
        // IF DATATORETURN IS 0, THEN ALL RECORDS ARE RETURNED
        // IF DATATORETURN IS 1 THEN RECORDS WHERE ORG_AMT = OWED_AMT ARE RETURNED
        // IF DATATORETURN IS 2 THEN RECORDS WHERE ORG_AMT <> OWED_AMT ARE RETURNED	
        public IList<OutstandingLiabilityGridModel> GetOutstandingLiabilityGridData(String strFilerID, int dataToReturn)
        {
            IList<OutstandingLiabilityGridModel> lstOutstandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
            lstOutstandingLiabilityGrid = objLoanAndLiabilityReconciliationBLL.GetOutstandingLiabilityGridData(strFilerID, dataToReturn);
            return lstOutstandingLiabilityGrid;
        }

        #endregion

        #region "GetLiabilityLoanForgivenGridData"
        // FUNCTION GETS DATA FOR THE LIABILITY/LOAN FORGIVEN GRID
        // FILERID IS REQUIRED
        public IList<LiabilityLoanForgivenGridModel> GetLiabilityLoanFogivenGridData(String strFilerID, int dataToReturn)
        {
            IList<LiabilityLoanForgivenGridModel> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridModel>();
            lstLiabilityLoanForgivenGrid = objLoanAndLiabilityReconciliationBLL.GetLiabilityLoanFogivenGridData(strFilerID, dataToReturn);
            return lstLiabilityLoanForgivenGrid;
        }

        #endregion

        #region "GetExpenditurePaymentGridData"
        // FUNCTION GETS DATA FOR THE EXPENDITURES/PAYMENTS GRID
        // FILERID IS REQUIRED	
        public IList<ExpenditurePaymentGridModel> GetExpenditurePaymentGridData(String strFilerID)
        {
            IList<ExpenditurePaymentGridModel> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridModel>();
            lstExpenditurePaymentGrid = objLoanAndLiabilityReconciliationBLL.GetExpenditurePaymentGridData(strFilerID);
            return lstExpenditurePaymentGrid;
        }

        #endregion

        #region "Reconcile_Loan"
        // PROCEDURE RECONCILES LOANS, PAYMENTS, OUTSTANDING LIABILITIES AND LOAN FORGIVENS
        public String Reconcile_Loan(String Schedule_I_TransFilingID, String[] Schedule_J_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            return objLoanAndLiabilityReconciliationBLL.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
        }
        #endregion

        #region "Reconcile_Liability"
        // PROCEDURE RECONCILES THE ORIGINAL LIABILITY WITH EXPENDITURES, OUTSTANDING
        // LIABILITIES AND LOANS FORGIVEN	
        public String Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, String[] Schedule_F_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            return objLoanAndLiabilityReconciliationBLL.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
        }
        #endregion

        #region "GetUnreconciledLoansOrLiabilities"
        // FUNCTION RETURNS THE NUMBER OF LOANS +
        // THE NUMBER OF LIABILITIES. IF THE RESULT IS 0 THEN THE 
        // RECONCILIATION PAGE DOESN'T NEED TO LOAD. IT WILL CALL 
        // UPDATEREQUIREDFILER METHOD AND THAT IS IT.
        public String GetUncreconciledLoansAndLiabilities(String strFilerID)
        {
            return objLoanAndLiabilityReconciliationBLL.GetUncreconciledLoansAndLiabilities(strFilerID);
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile"
        // THIS METHOD SIMPLY UPDATE THE R_RECONCILED AND MODIFIED_BY COLUMNS
        // IN THE REQUIRED_FILER TABLE. IT IS CALLED WHEN THERE ARE NO LOANS 
        // OR LIABILITIES OR WHEN THEY HAVE ALL BEEN RECONCILED
        public String UpdateRequiredFilerForReconcile(String strFilerID, String strUser)
        {
            return objLoanAndLiabilityReconciliationBLL.UpdateRequiredFilerForReconcile(strFilerID, strUser);
        }
        #endregion

        #region "GetMinReconciledOwedAmount"
        public String GetMinReconciledOwedAmount(String strTransID, String strOrgAmount, String filerID)
        {
            return objLoanAndLiabilityReconciliationBLL.GetMinReconciledOwedAmount(strTransID, strOrgAmount, filerID);
        }
        #endregion
    }

}
