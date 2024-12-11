using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for ExpenditureRefundsSchedLUT
    /// </summary>
    [TestClass]
    public class ExpenditureRefundsSchedLUT
    {
        public ExpenditureRefundsSchedLUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ExpenditureRefundsSchedL_UnitTest
        /// <summary>
        /// ExpenditureRefundsSchedL_UnitTest
        /// </summary>
        [TestMethod]
        public void ExpenditureRefundsSchedL_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            var result = controller.ExpenditureRefundsSchedL() as ViewResult;

            Assert.AreEqual("ExpenditureRefundsSchedL", result.ViewName.ToString());
        }
        #endregion ExpenditureRefundsSchedL_UnitTest

        #region SaveExpenditureRefundsData_UnitTest
        /// <summary>
        /// SaveExpenditureRefundsData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveExpenditureRefundsData_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingEntId = "",
                FilerId = "", //"110993"; // txtFilerId;            
                ElectionDate = "",
                ElectionTypeId = "P", // lstElectionType; Testing Only...
                ElectYearId = "",
                OfficeTypeId = "",
                FilingTypeId = "",
                ElectionYear = "",
                FilingTransId = "",
                FilingSchedId = "",
                SchedDate = "",
                FlngEntName = "",
                FlngEntCountry = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                PaymentTypeId = "",
                PayNumber = "",
                OrgAmt = "",
                TransExplanation = "",
                CreatedBy = "SBasireddy"
            };

            var results = controller.SaveExpenditureRefundsData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId,
                data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingTransId, data.FilingSchedId, data.SchedDate,
                data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip,
                data.ReceiptTypeId, data.ContributionTypeId, data.PaymentTypeId, data.PayNumber, data.OrgAmt,
                data.TransExplanation, "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveExpenditureRefundsData_UnitTest

        #region UpdateExpenditureRefunded_UnitTest
        /// <summary>
        /// UpdateExpenditureRefunded_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateExpenditureRefunded_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingEntId = "",
                FilerId = "", //"110993"; // txtFilerId;            
                ElectionDate = "",
                ElectionTypeId = "P", // lstElectionType; Testing Only...
                ElectYearId = "",
                OfficeTypeId = "",
                FilingTypeId = "",
                ElectionYear = "",
                FilingTransId = "",
                FilingSchedId = "",
                SchedDate = "",
                FlngEntName = "",
                FlngEntCountry = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                PaymentTypeId = "",
                PayNumber = "",
                OrgAmt = "",
                TransExplanation = "",
                CreatedBy = "SBasireddy"
            };

            var results = controller.UpdateExpenditureRefunded(data.FilingTransId, data.FilingEntId, data.SchedDate, data.FlngEntName,
                data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId,
                data.PayNumber, data.OrgAmt, data.TransExplanation, "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateExpenditureRefunded_UnitTest

        #region DeleteFilingTransactions_UnitTest
        /// <summary>
        /// DeleteFilingTransactions_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteFilingTransactions_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            String strFilingTransId = "";

            var results = controller.DeleteFilingTransactions(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteFilingTransactions_UnitTest

        #region AutoCompleteEntityName_UnitTest
        /// <summary>
        /// AutoCompleteEntityName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteEntityName_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            String strName = "A";

            var results = controller.AutoCompleteEntityName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion AutoCompleteEntityName_UnitTest

        #region GetOutstandingExpRefundedAmt_UnitTest
        /// <summary>
        /// GetOutstandingExpRefundedAmt_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOutstandingExpRefundedAmt_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            String strFilingTransId = "";

            var results = controller.GetOutstandingExpRefundedAmt(strFilingTransId,"");

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetOutstandingExpRefundedAmt_UnitTest

        #region GetOriginalAmountTransIdUpdate_UnitTest
        /// <summary>
        /// GetOriginalAmountTransIdUpdate_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOriginalAmountTransIdUpdate_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            String strFilingTransId = "";

            var results = controller.GetOriginalAmountTransIdUpdate(strFilingTransId);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetOriginalAmountTransIdUpdate_UnitTest

        #region GetOrginalAmount_UnitTest
        /// <summary>
        /// GetOrginalAmount_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOrginalAmount_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            String strFilingTransId = "";

            var results = controller.GetOriginalAmountTransIdUpdate(strFilingTransId);                       

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetOrginalAmount_UnitTest

        #region GetOriginalExpenseDate_UnitTest
        /// <summary>
        /// GetOriginalExpenseDate_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOriginalExpenseDate_UnitTest()
        {
            var controller = new ExpenditureRefundsSchedLController();

            String strFilingTransId = "";

            var results = controller.GetOriginalExpenseDate(strFilingTransId);

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetOriginalExpenseDate_UnitTest

    }
}
