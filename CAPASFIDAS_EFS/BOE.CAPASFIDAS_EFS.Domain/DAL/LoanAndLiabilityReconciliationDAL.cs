// Creighton Newsom
// Loan And Liability Reconciliation 1/2019
using System;
using System.Collections.Generic;
using BOE.CAPASFIDAS_EFS.Domain.EFSService;
using Models;

namespace DAL
{
    public class LoanAndLiabilityReconciliationDAL
    {
        // Create Service Object
        //CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient();

        #region "GetLoanReceivedGridData"
        // FUNCTION GETS DATA FOR THE LOAN RECEIVED GRID
        // FILERID IS REQUIRED
        internal IList<LoanReceivedGridModel> GetLoanReceivedGridData(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LoanReceivedGridModel> lstLoanReceivedGrid = new List<LoanReceivedGridModel>();
                    LoanReceivedGridModel objLoanReceivedGrid;

                    var results = client.GetLoanReceivedGridData(strFilerID);

                    foreach (var item in results)
                    {
                        objLoanReceivedGrid = new LoanReceivedGridModel();
                        objLoanReceivedGrid.FilingTransID = item.FilingTransID;
                        objLoanReceivedGrid.TransNumber = item.TransNumber;
                        objLoanReceivedGrid.TransMapping = item.TransMapping;
                        objLoanReceivedGrid.TransactionDate = item.TransactionDate;
                        objLoanReceivedGrid.EntityName = item.EntityName;
                        objLoanReceivedGrid.Amount = item.Amount;
                        objLoanReceivedGrid.ElectionYear = item.ElectionYear;
                        objLoanReceivedGrid.OfficeType = item.OfficeType;
                        objLoanReceivedGrid.ElectionType = item.ElectionType;
                        objLoanReceivedGrid.ElectionDate = item.ElectionDate;
                        objLoanReceivedGrid.DisclosurePeriod = item.DisclosurePeriod;

                        //add object to list
                        lstLoanReceivedGrid.Add(objLoanReceivedGrid);
                    }
                    client.Close();
                    return lstLoanReceivedGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
           
            
        }

        #endregion

        #region "GetLoanPaymentGridData"
        // FUNCTION GETS DATA FOR THE LOAN PAYMENT GRID
        // FILERID IS REQUIRED
        internal IList<LoanPaymentGridModel> GetLoanPaymentGridData(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LoanPaymentGridModel> lstLoanPaymentGrid = new List<LoanPaymentGridModel>();
                    LoanPaymentGridModel objLoanPaymentGrid;


                    var results = client.GetLoanPaymentGridData(strFilerID);

                    foreach (var item in results)
                    {
                        objLoanPaymentGrid = new LoanPaymentGridModel();
                        objLoanPaymentGrid.FilingTransID = item.FilingTransID;
                        objLoanPaymentGrid.TransNumber = item.TransNumber;
                        objLoanPaymentGrid.TransMapping = item.TransMapping;
                        objLoanPaymentGrid.TransactionDate = item.TransactionDate;
                        objLoanPaymentGrid.EntityName = item.EntityName;
                        objLoanPaymentGrid.Amount = item.Amount;
                        objLoanPaymentGrid.OriginalLoanDate = item.OriginalLoanDate;
                        objLoanPaymentGrid.ElectionYear = item.ElectionYear;
                        objLoanPaymentGrid.OfficeType = item.OfficeType;
                        objLoanPaymentGrid.ElectionType = item.ElectionType;
                        objLoanPaymentGrid.ElectionDate = item.ElectionDate;
                        objLoanPaymentGrid.DisclosurePeriod = item.DisclosurePeriod;

                        //add object to list
                        lstLoanPaymentGrid.Add(objLoanPaymentGrid);
                    }
                    client.Close();
                    return lstLoanPaymentGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
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
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<OutstandingLiabilityGridModel> lstOutstandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                    OutstandingLiabilityGridModel objOutstandingLiabilityGrid;

                    var results = client.GetOutstandingLiabilityGridData(strFilerID, dataToReturn);

                    foreach (var item in results)
                    {
                        objOutstandingLiabilityGrid = new OutstandingLiabilityGridModel();
                        objOutstandingLiabilityGrid.FilingTransID = item.FilingTransID;
                        objOutstandingLiabilityGrid.TransNumber = item.TransNumber;
                        objOutstandingLiabilityGrid.TransMapping = item.TransMapping;
                        objOutstandingLiabilityGrid.TransactionDate = item.TransactionDate;
                        objOutstandingLiabilityGrid.EntityName = item.EntityName;
                        objOutstandingLiabilityGrid.OriginalAmount = item.OriginalAmount;
                        objOutstandingLiabilityGrid.OutstandingAmount = item.OutstandingAmount;
                        objOutstandingLiabilityGrid.ElectionYear = item.ElectionYear;
                        objOutstandingLiabilityGrid.OfficeType = item.OfficeType;
                        objOutstandingLiabilityGrid.ElectionType = item.ElectionType;
                        objOutstandingLiabilityGrid.ElectionDate = item.ElectionDate;
                        objOutstandingLiabilityGrid.DisclosurePeriod = item.DisclosurePeriod;

                        //add object to list
                        lstOutstandingLiabilityGrid.Add(objOutstandingLiabilityGrid);
                    }
                    client.Close();
                    return lstOutstandingLiabilityGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #endregion

        #region "GetLiabilityLoanForgivenGridData"
        // FUNCTION GETS DATA FOR THE LIABILITY/LOAN FORGIVEN GRID
        // FILERID IS REQUIRED
        internal IList<LiabilityLoanForgivenGridModel> GetLiabilityLoanFogivenGridData(String strFilerID, int dataToReturn)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<LiabilityLoanForgivenGridModel> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridModel>();
                    LiabilityLoanForgivenGridModel objLiabilityLoanForgivenGrid;

                    var results = client.GetLiabilityLoanFogivenGridData(strFilerID, dataToReturn);

                    foreach (var item in results)
                    {
                        objLiabilityLoanForgivenGrid = new LiabilityLoanForgivenGridModel();
                        objLiabilityLoanForgivenGrid.FilingTransID = item.FilingTransID;
                        objLiabilityLoanForgivenGrid.TransNumber = item.TransNumber;
                        objLiabilityLoanForgivenGrid.TransMapping = item.TransMapping;
                        objLiabilityLoanForgivenGrid.TransactionDate = item.TransactionDate;
                        objLiabilityLoanForgivenGrid.EntityName = item.EntityName;
                        objLiabilityLoanForgivenGrid.Amount = item.Amount;
                        objLiabilityLoanForgivenGrid.OriginalDate = item.OriginalDate;
                        objLiabilityLoanForgivenGrid.ElectionYear = item.ElectionYear;
                        objLiabilityLoanForgivenGrid.OfficeType = item.OfficeType;
                        objLiabilityLoanForgivenGrid.ElectionType = item.ElectionType;
                        objLiabilityLoanForgivenGrid.ElectionDate = item.ElectionDate;
                        objLiabilityLoanForgivenGrid.DisclosurePeriod = item.DisclosurePeriod;

                        //add object to list
                        lstLiabilityLoanForgivenGrid.Add(objLiabilityLoanForgivenGrid);
                    }
                    client.Close();
                    return lstLiabilityLoanForgivenGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #endregion

        #region "GetExpenditurePaymentGridData"
        // FUNCTION GETS DATA FOR THE EXPENDITURES/PAYMENTS GRID
        // FILERID IS REQUIRED
        internal IList<ExpenditurePaymentGridModel> GetExpenditurePaymentGridData(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    IList<ExpenditurePaymentGridModel> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridModel>();
                    ExpenditurePaymentGridModel objExpenditurePaymentGrid;

                    var results = client.GetExpenditurePaymentGridData(strFilerID);

                    foreach (var item in results)
                    {
                        objExpenditurePaymentGrid = new ExpenditurePaymentGridModel();
                        objExpenditurePaymentGrid.FilingTransID = item.FilingTransID;
                        objExpenditurePaymentGrid.TransNumber = item.TransNumber;
                        objExpenditurePaymentGrid.TransMapping = item.TransMapping;
                        objExpenditurePaymentGrid.TransactionDate = item.TransactionDate;
                        objExpenditurePaymentGrid.EntityName = item.EntityName;
                        objExpenditurePaymentGrid.Amount = item.Amount;
                        objExpenditurePaymentGrid.Explanation = item.Explanation;
                        objExpenditurePaymentGrid.ElectionYear = item.ElectionYear;
                        objExpenditurePaymentGrid.OfficeType = item.OfficeType;
                        objExpenditurePaymentGrid.ElectionType = item.ElectionType;
                        objExpenditurePaymentGrid.ElectionDate = item.ElectionDate;
                        objExpenditurePaymentGrid.DisclosurePeriod = item.DisclosurePeriod;

                        //add object to list
                        lstExpenditurePaymentGrid.Add(objExpenditurePaymentGrid);
                    }
                    client.Close();
                    return lstExpenditurePaymentGrid;

                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }

        #endregion

        #region "Reconcile_Loan"
        // PROCEDURE RECONCILES LOANS, PAYMENTS, OUTSTANDING LIABILITIES AND LOAN FORGIVENS
        internal String Reconcile_Loan(String Schedule_I_TransFilingID, String[] Schedule_J_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "Reconcile_Liability"
        // PROCEDURE RECONCILES THE ORIGINAL LIABILITY WITH EXPENDITURES, OUTSTANDING
        // LIABILITIES AND LOANS FORGIVEN	
        internal String Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, String[] Schedule_F_TransFilingIDs, String[] Schedule_N_TransFilingIDs, String[] Schedule_K_TransFilingIDs, String User)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs, User);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "GetUnreconciledLoansOrLiabilities"
        // FUNCTION RETURNS THE NUMBER OF LOANS +
        // THE NUMBER OF LIABILITIES. IF THE RESULT IS 0 THEN THE 
        // RECONCILIATION PAGE DOESN'T NEED TO LOAD. IT WILL CALL 
        // UPDATEREQUIREDFILER METHOD AND THAT IS IT.
        internal String GetUncreconciledLoansAndLiabilities(String strFilerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.GetUncreconciledLoansAndLiabilities(strFilerID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile"
        // THIS METHOD SIMPLY UPDATE THE R_RECONCILED AND MODIFIED_BY COLUMNS
        // IN THE REQUIRED_FILER TABLE. IT IS CALLED WHEN THERE ARE NO LOANS 
        // OR LIABILITIES OR WHEN THEY HAVE ALL BEEN RECONCILED
        internal String UpdateRequiredFilerForReconcile(String strFilerID, String strUser)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.UpdateRequiredFilerForReconcile(strFilerID, strUser);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

        #region "GetMinReconciledOwedAmount"
        public String GetMinReconciledOwedAmount(String strTransID, String strOrgAmount, String filerID)
        {
            using (CAPASFIDAS_EFS_SERVICEClient client = new CAPASFIDAS_EFS_SERVICEClient())
            {
                try
                {

                    return client.GetMinReconciledOwedAmount(strTransID, strOrgAmount, filerID);
                }
                catch (Exception)
                {
                    client.Abort();
                    throw;
                }
            }
            
            
        }
        #endregion

    }
}
