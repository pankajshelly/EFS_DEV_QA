// Creighton Newsom
// LoanAndLiabilityReconciliation Page
using System;
using System.Collections.Generic;
using DAL;
using Models;

namespace BLL
{
    public class LoanAndLiabilityReconciliationBLL
    {
        // Create DAL Object
        LoanAndLiabilityReconciliationDAL objLoanAndLiabilitiesReconcilationDAL = new LoanAndLiabilityReconciliationDAL();

        #region "GetLoanReceivedGridData"
        // FUNCTION GETS DATA FOR THE LOAN RECEIVED GRID
        // FILERID IS REQUIRED
        internal IList<LoanReceivedGridModel> GetLoanReceivedGridData(String strFilerID)
        {
            IList<LoanReceivedGridModel> lstLoanReceivedGrid = new List<LoanReceivedGridModel>();
            lstLoanReceivedGrid = objLoanAndLiabilitiesReconcilationDAL.GetLoanReceivedGridData(strFilerID);
            return lstLoanReceivedGrid;
        }

        #endregion

        #region "GetLoanPaymentGridData"
        // FUNCTION GETS DATA FOR THE LOAN PAYMENT GRID
        // FILERID IS REQUIRED
        internal IList<LoanPaymentGridModel> GetLoanPaymentGridData(String strFilerID)
        {
            IList<LoanPaymentGridModel> lstLoanPaymentGrid = new List<LoanPaymentGridModel>();
            lstLoanPaymentGrid = objLoanAndLiabilitiesReconcilationDAL.GetLoanPaymentGridData(strFilerID);
            return lstLoanPaymentGrid;
        }

        #endregion

        #region "GetOutstandingLiabilityGridData"
        // FUNCTION GETS DATA FOR THE OUTSTANDING LIABILITIES GRID
        // FILERID AND DATATORETURN ARE REQUIRED
        // IF DATATORETURN IS 0, THEN ALL RECORDS ARE RETURNED
        // IF DATATORETURN IS 1 THEN RECORDS WHERE ORG_AMT = OWED_AMT ARE RETURNED
        // IF DATATORETURN IS 2 THEN RECORDS WHERE ORG_AMT <> OWED_AMT ARE RETURNED	
        internal IList<OutstandingLiabilityGridModel> GetOutstandingLiabilityGridData(String strFilerID, int dataToReturn)
        {
            IList<OutstandingLiabilityGridModel> lstOutstandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
            lstOutstandingLiabilityGrid = objLoanAndLiabilitiesReconcilationDAL.GetOutstandingLiabilityGridData(strFilerID, dataToReturn);
            return lstOutstandingLiabilityGrid;
        }

        #endregion

        #region "GetLiabilityLoanForgivenGridData"
        // FUNCTION GETS DATA FOR THE LIABILITY/LOAN FORGIVEN GRID
        // FILERID IS REQUIRED
        internal IList<LiabilityLoanForgivenGridModel> GetLiabilityLoanFogivenGridData(String strFilerID, int dataToReturn)
        {
            IList<LiabilityLoanForgivenGridModel> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridModel>();
            lstLiabilityLoanForgivenGrid = objLoanAndLiabilitiesReconcilationDAL.GetLiabilityLoanFogivenGridData(strFilerID, dataToReturn);
            return lstLiabilityLoanForgivenGrid;
        }

        #endregion

        #region "GetExpenditurePaymentGridData"
        // FUNCTION GETS DATA FOR THE EXPENDITURES/PAYMENTS GRID
        // FILERID IS REQUIRED	
        internal IList<ExpenditurePaymentGridModel> GetExpenditurePaymentGridData(String strFilerID)
        {
            IList<ExpenditurePaymentGridModel> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridModel>();
            lstExpenditurePaymentGrid = objLoanAndLiabilitiesReconcilationDAL.GetExpenditurePaymentGridData(strFilerID);
            return lstExpenditurePaymentGrid;
        }

        #endregion

        #region "Reconcile_Loan"
        // PROCEDURE RECONCILES LOANS, PAYMENTS, OUTSTANDING LIABILITIES AND LOAN FORGIVENS
        internal String Reconcile_Loan(String Schedule_I_TransFilingID, String[] Schedule_J_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            return objLoanAndLiabilitiesReconcilationDAL.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
        }
        #endregion

        #region "Reconcile_Liability"
        // PROCEDURE RECONCILES THE ORIGINAL LIABILITY WITH EXPENDITURES, OUTSTANDING
        // LIABILITIES AND LOANS FORGIVEN	
        internal String Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, String[] Schedule_F_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            return objLoanAndLiabilitiesReconcilationDAL.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
        }
        #endregion

        #region "GetUnreconciledLoansOrLiabilities"
        // FUNCTION RETURNS THE NUMBER OF LOANS +
        // THE NUMBER OF LIABILITIES. IF THE RESULT IS 0 THEN THE 
        // RECONCILIATION PAGE DOESN'T NEED TO LOAD. IT WILL CALL 
        // UPDATEREQUIREDFILER METHOD AND THAT IS IT.
        internal String GetUncreconciledLoansAndLiabilities(String strFilerID)
        {
            return objLoanAndLiabilitiesReconcilationDAL.GetUncreconciledLoansAndLiabilities(strFilerID);
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile"
        // THIS METHOD SIMPLY UPDATE THE R_RECONCILED AND MODIFIED_BY COLUMNS
        // IN THE REQUIRED_FILER TABLE. IT IS CALLED WHEN THERE ARE NO LOANS 
        // OR LIABILITIES OR WHEN THEY HAVE ALL BEEN RECONCILED
        internal String UpdateRequiredFilerForReconcile(String strFilerID, String strUser)
        {
            return objLoanAndLiabilitiesReconcilationDAL.UpdateRequiredFilerForReconcile(strFilerID, strUser);
        }
        #endregion

        #region "GetMinReconciledOwedAmount"
        internal String GetMinReconciledOwedAmount(String strTransID, String strOrgAmount, String filerID)
        {
            return objLoanAndLiabilitiesReconcilationDAL.GetMinReconciledOwedAmount(strTransID, strOrgAmount, filerID);
        }
        #endregion

    }
}
