// Creighton Newsom
// LoanAndLiabilityReconciliation Page

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class LoanAndLiabilityReconciliationUT: Controller
    {
        #region "LoanAndLiabilityReconciliation"
        //[TestMethod]
        public void LoanAndLiabilityReconciliation()
        {
            //Arrange
            var controller = new LoanAndLiabilityReconciliationController(); 
            //Act
            var result = controller.LoanAndLiabilityReconciliation() as ViewResult;
            //Assert
            Assert.AreEqual("LoanAndLiabilityReconciliation", result.ViewName.ToString());
        }
        #endregion

        #region "GetLoanReceivedGridData_UnitTest"
        [TestMethod]
        public void GetLoanReceivedGridData_UnitTest()
        {
            var controller = new LoanAndLiabilityReconciliationController();
            JsonResult results = controller.GetLoanReceivedGridData();
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetLoanPaymentGridData_UnitTest"
        [TestMethod]
        public void GetLoanPaymentGridData_UnitTest()
        {
            var controller = new LoanAndLiabilityReconciliationController();
            JsonResult results = controller.GetLoanPaymentGridData("", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetOutstandingLiabilityGridData_UnitTest"
        [TestMethod]
        public void GetOutstandingLiabilityGridData_UnitTest()
        {
            var controller = new LoanAndLiabilityReconciliationController();
            JsonResult results = controller.GetOutstandingLiabilityGridData(0, "", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetLiabilityLoanForgivenGridData_UnitTest"
        [TestMethod]
        public void GetLiabilityLoanForgivenGridData_UnitTest()
        {
            var controller = new LoanAndLiabilityReconciliationController();
            JsonResult results = controller.GetLiabilityLoanForgivenGridData("0");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetExpenditurePaymentGridData_UnitTest"
        [TestMethod]
        public void GetExpenditurePaymentGridData_UnitTest()
        {
            var controller = new LoanAndLiabilityReconciliationController();
            JsonResult results = controller.GetExpenditurePaymentGridData();
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "AreAllTransactionsReconciled_UnitTest"
        [TestMethod]
        public void AreAllTransactionsReconciled_UnitTest()
        {
            var controller = new LoanAndLiabilityReconciliationController();
            JsonResult results = controller.AreAllTransactionsReconciled();
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetUncreconciledLoansAndLiabilities_UnitTest"
        [TestMethod]
        public void GetUncreconciledLoansAndLiabilities_UnitTest()
        {
            //var controller = new LoanAndLiabilityReconciliationController();
            //JsonResult results = controller.GetUncreconciledLoansAndLiabilities("");
            //dynamic data = results.Data;
            //Assert.AreEqual(data, "10");
        }
        #endregion

        #region "Reconcile_Loan_UnitTest_A"
        [TestMethod]
        public void Reconcile_Loan_UnitTest_A()
        {
            LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();

            string Schedule_I_TransFilingID = "4210089";
            string[] Schedule_J_TransFilingIDs = {"4210091", "4210093"};
            string[] Schedule_N_TransFilingIDs = { "4210090", "4210092", "4210094", "4209836" };
            string[] Schedule_K_TransFilingIDs = { "4209843" };
           
            var result = controller.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs);
            Assert.AreEqual("A", result.Data.ToString());
        }
        #endregion

        #region "Reconcile_Loan_UnitTest_B"
        [TestMethod]
        public void Reconcile_Loan_UnitTest_B()
        {
            LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();

            string Schedule_I_TransFilingID = "4210089";
            string[] Schedule_J_TransFilingIDs = {};
            string[] Schedule_N_TransFilingIDs = { "4210090", "4210092", "4210094", "4209836" };
            string[] Schedule_K_TransFilingIDs = {};

            var result = controller.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs);
            Assert.AreEqual("B", result.Data.ToString());
        }
        #endregion

        #region "Reconcile_Loan_UnitTest_D"
        [TestMethod]
        public void Reconcile_Loan_UnitTest_D()
        {
            LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();

            string Schedule_I_TransFilingID = "4210089";
            string[] Schedule_J_TransFilingIDs = { "4210091", "4210093" };
            string[] Schedule_N_TransFilingIDs = {};
            string[] Schedule_K_TransFilingIDs = { "4209843" };

            var result = controller.Reconcile_Loan(Schedule_I_TransFilingID, Schedule_J_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs);
            Assert.AreEqual("D", result.Data.ToString());
        }
        #endregion

        #region "Reconcile_Liability_UnitTest_A"
        [TestMethod]
        public void Reconcile_Liability_UnitTest_A()
        {
            string Schedule_N_OriginalLiability_TransFilingID = "4210090";
            string[] Schedule_F_TransFilingIDs = { "4209662", "4209663" };
            string[] Schedule_N_TransFilingIDs = { "4210092", "4210094", "4209836" };
            string[] Schedule_K_TransFilingIDs = { "4209843" };
            LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();
            var result = controller.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs);
            Assert.AreEqual("A", result.Data.ToString());
        }
        #endregion

        #region "Reconcile_Liability_UnitTest_B"
        [TestMethod]
        public void Reconcile_Liability_UnitTest_B()
        {
            string Schedule_N_OriginalLiability_TransFilingID = "4210090";
            string[] Schedule_F_TransFilingIDs = {};
            string[] Schedule_N_TransFilingIDs = { "4210092", "4210094", "4209836" };
            string[] Schedule_K_TransFilingIDs = {};
            LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();
            var result = controller.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs);
            Assert.AreEqual("B", result.Data.ToString());
        }
        #endregion

        #region "Reconcile_Liability_UnitTest_D"
        [TestMethod]
        public void Reconcile_Liability_UnitTest_D()
        {
            string Schedule_N_OriginalLiability_TransFilingID = "4210090";
            string[] Schedule_F_TransFilingIDs = { "4209662", "4209663" };
            string[] Schedule_N_TransFilingIDs = {};
            string[] Schedule_K_TransFilingIDs = { "4209843" };
            LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();
            var result = controller.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, Schedule_F_TransFilingIDs, Schedule_N_TransFilingIDs, Schedule_K_TransFilingIDs);
            Assert.AreEqual("D", result.Data.ToString());
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile_UnitTest"
        [TestMethod]
        public void UpdateRequiredFilerForReconcile_UnitTest()
        {
            //LoanAndLiabilityReconciliationController controller = new LoanAndLiabilityReconciliationController();
            //var result = controller.UpdateRequiredFilerForReconcile("");
            //Assert.AreEqual("TRUE", result.Data.ToString());
        }
        #endregion




    }
}
