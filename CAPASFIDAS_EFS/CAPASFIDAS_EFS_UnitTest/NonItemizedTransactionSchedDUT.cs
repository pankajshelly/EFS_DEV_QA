using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedTransactionSchedDUT
    {
        private NonItemizedTransactionSchedDUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NonItemizedTransactionSchedA_UnitTest
        /// <summary>
        /// NonItemizedTransactionSchedA_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemizedTransactionSchedB_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            var result = controller.NonItemizedTransactionSchedD() as ViewResult;

            Assert.AreEqual("NonItemizedTransactionSchedD", result.ViewName.ToString());
        }
        #endregion NonItemizedTransactionSchedA_UnitTest

        #region SaveNonItem24HourNoticeSchedAData_UnitTest
        /// <summary>
        /// SaveNonItem24HourNoticeSchedAData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItem24HourNoticeSchedAData_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

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

            var results = controller.SaveNonItem24HourNoticeSchedAData(data.FilerId, data.ElectionYear, data.ElectYearId,
                data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingSchedId, data.SchedDate,
                data.ContributorTypeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.ContributionTypeId, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.RItemized, "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItem24HourNoticeSchedAData_UnitTest

        #region UpdateNonItem24HourNoticeSchedAData_UnitTest
        /// <summary>
        /// UpdateNonItem24HourNoticeSchedAData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateNonItem24HourNoticeSchedAData_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

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
                SubmissionDate = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.UpdateNonItem24HourNoticeSchedAData(data.FilingTransId, data.FilingEntId, data.ContributorTypeId,
                data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.ContributionTypeId, data.OrgAmt,
                data.TransExplanation, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItem24HourNoticeSchedAData_UnitTest

        #region SubmitNonItem24HourNoticeSchedAData_UnitTest
        /// <summary>
        /// SubmitNonItem24HourNoticeSchedAData_UnitTest
        /// </summary>
        public void SubmitNonItem24HourNoticeSchedAData_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

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
                SubmissionDate = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SubmitNonItem24HourNoticeSchedAData(data.FilerId, data.FilingTransId, data.FilingEntId, data.FilingSchedId,
                data.ContributionTypeId, data.ContributorTypeId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.TransExplanation, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SubmitNonItem24HourNoticeSchedAData_UnitTest

        #region DeleteNonItem24HourNoticeSchedA_UnitTest
        /// <summary>
        /// DeleteNonItem24HourNoticeSchedA_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItem24HourNoticeSchedA_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItem24HourNoticeSchedA(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItem24HourNoticeSchedA_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            var results = controller.GetPaymentMethodData() as JsonResult;

            IList<PaymentMethodModel> lstPaymentMethodModel = results.Data as List<PaymentMethodModel>;

            Assert.IsTrue(lstPaymentMethodModel.Count >= 1);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region GetContributorCodeSchedA_UnitTest
        /// <summary>
        /// GetContributorCodeSchedA_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorCodeSchedA_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            var results = controller.GetContributorCodeSchedA() as JsonResult;

            IList<ContributorNameModel> lstContributorNameModel = results.Data as List<ContributorNameModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorCodeSchedA_UnitTest

        #region GetChildTransExists_UnitTest
        /// <summary>
        /// GetChildTransExists_UnitTest
        /// </summary>
        [TestMethod]
        public void GetChildTransExists_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            String strFilingTransId = "";

            var results = controller.GetChildTransExists(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion GetChildTransExists_UnitTest

        #region AutoCompleteFirstName_UnitTest
        /// <summary>
        /// AutoCompleteFirstName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteFirstName_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            String strName = "A";

            var results = controller.AutoCompleteFirstName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion AutoCompleteFirstName_UnitTest

        #region AutoCompleteLastName_UnitTest
        /// <summary>
        /// AutoCompleteLastName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteLastName_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            String strName = "A";

            var results = controller.AutoCompleteLastName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion AutoCompleteLastName_UnitTest

        #region AutoCompleteEntityName_UnitTest
        /// <summary>
        /// AutoCompleteEntityName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteEntityName_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            String strName = "A";

            var results = controller.AutoCompleteLastName(strName);

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
            var controller = new NonItemizedTransactionSchedDController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

        #region Get24HourNoticeTransactionsHistory_UnitTest
        /// <summary>
        /// Get24HourNoticeTransactionsHistory_UnitTest
        /// </summary>
        [TestMethod]
        public void Get24HourNoticeTransactionsHistory_UnitTest()
        {
            var controller = new NonItemizedTransactionSchedDController();

            String strFilingTransId = "";

            var results = controller.Get24HourNoticeTransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion Get24HourNoticeTransactionsHistory_UnitTest

    }
}
