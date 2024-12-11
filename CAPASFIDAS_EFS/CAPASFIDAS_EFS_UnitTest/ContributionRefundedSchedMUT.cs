using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for ContributionRefundedSchedMUT
    /// </summary>
    [TestClass]
    public class ContributionRefundedSchedMUT
    {
        public ContributionRefundedSchedMUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ContributionRefundedSchedM_UnitTest
        /// <summary>
        /// ContributionRefundedSchedM_UnitTest
        /// </summary>
        [TestMethod]
        public void ContributionRefundedSchedM_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            var result = controller.ContributionRefundedSchedM() as ViewResult;

            Assert.AreEqual("ContributionRefundedSchedM", result.ViewName.ToString());
        }
        #endregion ContributionRefundedSchedM_UnitTest

        #region SaveContributionseRefundedData_UnitTest
        /// <summary>
        /// SaveContributionseRefundedData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveContributionseRefundedData_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilerId = "", //"110993"; // txtFilerId;
                FilingTransId = "",
                FilingSchedId = "", // Partnership/SubContractor.... strFilingSchedId;
                SchedDate = "",
                OrgAmt = "",
                ElectionDate = "",
                ElectionTypeId = "P", // lstElectionType; Testing Only...
                ElectYearId = "",
                OfficeTypeId = "",
                FilingTypeId = "",
                ElectionYear = "",
                FilingEntId = null,
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntLastName = "",
                FlngEntMiddleName = "",
                FlngEntStrNum = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                FlngEntCountry = "",
                TransExplanation = "",
                RItemized = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveContributionseRefundedData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId,
                data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingTransId, data.FilingSchedId,
                data.SchedDate, data.ContributionTypeId, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState,
                data.FlngEntZip, data.ReceiptTypeId, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());

        }
        #endregion SaveContributionseRefundedData_UnitTest

        #region UpdateContributionsRefunded_UnitTest
        /// <summary>
        /// UpdateContributionsRefunded_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateContributionsRefunded_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingTransId = "",
                FilingEntId = "",
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntMiddleName = "",
                FlngEntLastName = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                OrgAmt = "",
                TransExplanation = "",
                FlngEntCountry = "",
                ModifiedBy = "SBasireddy"
            };

            var results = controller.UpdateContributionsRefunded(data.FilingTransId, data.FilingEntId, data.FlngEntName,
                data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntStrName, data.FlngEntCity,
                data.FlngEntState, data.FlngEntZip, data.OrgAmt, data.TransExplanation, data.FlngEntCountry, "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateContributionsRefunded_UnitTest

        #region DeleteFilingTransactions_UnitTest
        /// <summary>
        /// DeleteFilingTransactions_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteFilingTransactions_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strFilingTransId = "";

            var results = controller.DeleteFilingTransactions(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteFilingTransactions_UnitTest

        #region GetContributorOrginalAmount_UnitTest
        /// <summary>
        /// GetContributorOrginalAmount_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorOrginalAmount_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strFilingTransId = "";

            var results = controller.GetContributorOrginalAmount(strFilingTransId) as JsonResult;

            IList<ExpPaymentOriginalAmountModel> lstContributorNameModel = results.Data as List<ExpPaymentOriginalAmountModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorOrginalAmount_UnitTest

        #region GetContributorOriginalContributionDate_UnitTest
        /// <summary>
        /// GetContributorOriginalContributionDate_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorOriginalContributionDate_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strFilingTransId = "";

            var results = controller.GetContributorOriginalContributionDate("","") as JsonResult;

            IList<ExpPaymentOriginalExpenseDateModel> lstContributorNameModel = results.Data as List<ExpPaymentOriginalExpenseDateModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorOriginalContributionDate_UnitTest

        #region GetOutstandingContrRefundedAmt_UnitTest
        /// <summary>
        /// GetOutstandingContrRefundedAmt_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOutstandingContrRefundedAmt_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strFilingTransId = "";

            var results = controller.GetOutstandingContrRefundedAmt(strFilingTransId,"") as JsonResult;

            String lstContributorNameModel = results.Data.ToString();

            Assert.IsTrue(lstContributorNameModel.ToString() != null);
        }
        #endregion GetOutstandingContrRefundedAmt_UnitTest

        #region GetOriginalAmountContrTransIdUpdate_UnitTest
        /// <summary>
        /// GetOriginalAmountContrTransIdUpdate_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOriginalAmountContrTransIdUpdate_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strFilingTransId = "";

            var results = controller.GetOriginalAmountContrTransIdUpdate(strFilingTransId) as JsonResult;

            IList<ExpPaymentOriginalAmountModel> lstContributorNameModel = results.Data as List<ExpPaymentOriginalAmountModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetOriginalAmountContrTransIdUpdate_UnitTest

        #region AutoCompleteEntityName_UnitTest
        /// <summary>
        /// AutoCompleteEntityName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteEntityName_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strName = "A";

            var results = controller.AutoCompleteEntityName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion AutoCompleteEntityName_UnitTest

        #region GetAutoCompleteNameData_UnitTest
        /// <summary>
        /// GetAutoCompleteNameData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetAutoCompleteNameData_UnitTest()
        {
            var controller = new ContributionRefundedSchedMController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

    }
}
