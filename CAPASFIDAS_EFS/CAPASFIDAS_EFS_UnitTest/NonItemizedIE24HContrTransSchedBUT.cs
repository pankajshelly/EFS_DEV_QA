using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;
namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedIE24HContrTransSchedBUT
    {        
        public NonItemizedIE24HContrTransSchedBUT()
        {
            // TO Do;
        }
        
        #region NonItemIE24HContributionSchedBUT_UnitTest
        /// <summary>
        /// NonItemIE24HContributionSchedBUT_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemIE24HContributionSchedBUT_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            var result = controller.NonItemIE24HContributionSchedB() as ViewResult;

            Assert.AreEqual("NonItemIE24HContributionSchedB", result.ViewName.ToString());
        }
        #endregion NonItemIE24HContributionSchedBUT_UnitTest

        #region SaveNonItemIE24HContrSchedBData_UnitTest
        /// <summary>
        /// SaveNonItemIE24HContrSchedBData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIE24HContrSchedBData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                PersonId = "",
                AddrId = "",
                TreasId = "",
                FilingEntId = "",
                FilerId = "",
                ElectionDate = "",
                ElectionDateId = "",
                ElectionTypeId = "",
                ElectYearId = "",
                OfficeTypeId = "",
                ElectionYear = "",
                FilingSchedId = "",
                SchedDate = "",
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntLastName = "",
                FlngEntMiddleName = "",
                FlngEntCountry = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                OrgAmt = "",
                ContributorTypeId = "",
                PaymentTypeId = "",
                PayNumber = "",
                TransExplanation = "",
                TreasurerOccupation = "",
                TreasurerEmployer = "",
                TreasurerStreetAddress = "",
                TreasurerCity = "",
                TreasurerState = "",
                TreasurerZip = "",
                ContributorOccupation = "",
                ContributorEmployer = "",
                IEDescription = "",
                CandBallotPropReference = "",
                R_Supported = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveNonItemIE24HContrSchedBData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.FlngEntName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemIE24HContrSchedBData_UnitTest

        #region UpdateNonItemIE24HContrSchedBData_UnitTest
        /// <summary>
        /// UpdateNonItemIE24HContrSchedBData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateNonItemIE24HContrSchedBData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

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

            var results = controller.UpdateNonItemIE24HContrSchedBData(data.FilingTransId, data.FilingEntId, data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.TransExplanation, data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.TreasId, data.AddrId, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.TreasurerOccupation, data.TreasurerEmployer, data.R_Supported, data.CandBallotPropReference, "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItemIE24HContrSchedBData_UnitTest

        #region SubmitNonItemIE24HContrSchedBData_UnitTest
        /// <summary>
        /// SubmitNonItemIE24HContrSchedBData_UnitTest
        /// </summary>
        [TestMethod]
        public void SubmitNonItemIE24HContrSchedBData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            String strFilingTransId = "";

            var results = controller.SubmitNonItemIE24HContrSchedBData(strFilingTransId);

            Assert.AreEqual("TRUE", results.ToString());
        }
        #endregion SubmitNonItemIE24HContrSchedBData_UnitTest

        #region DeleteNonItemIE24HContrSchedB_UnitTest
        /// <summary>
        /// DeleteNonItemIE24HContrSchedB_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemIE24HContrSchedB_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItemIE24HContrSchedB(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemIE24HContrSchedB_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            var results = controller.GetPaymentMethodData() as JsonResult;

            IList<PaymentMethodModel> lstPaymentMethodModel = results.Data as List<PaymentMethodModel>;

            Assert.IsTrue(lstPaymentMethodModel.Count >= 1);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region GetContributorCodeSchedB_UnitTest
        /// <summary>
        /// GetContributorCodeSchedB_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorCodeSchedB_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            var results = controller.GetContributorCodeSchedB() as JsonResult;

            IList<ContributorNameModel> lstContributorNameModel = results.Data as List<ContributorNameModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorCodeSchedB_UnitTest

        #region GetChildTransExists_UnitTest
        /// <summary>
        /// GetChildTransExists_UnitTest
        /// </summary>
        [TestMethod]
        public void GetChildTransExists_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

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
            var controller = new NonItemIE24HContributionSchedBController();

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
            var controller = new NonItemIE24HContributionSchedBController();

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
            var controller = new NonItemIE24HContributionSchedBController();

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
            var controller = new NonItemIE24HContributionSchedBController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

        #region GetIE24HContrbutionTreasurerData_UnitTest
        /// <summary>
        /// GetIE24HContrbutionTreasurerData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetIE24HContrbutionTreasurerData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            var results = controller.GetIE24HContrbutionTreasurerData() as JsonResult;

            IList<NonItemIETreasurerModel> lstNonItemIETreasurerModel = results.Data as List<NonItemIETreasurerModel>;

            Assert.IsTrue(lstNonItemIETreasurerModel.Count >= 1);
        }
        #endregion GetIE24HContrbutionTreasurerData_UnitTest

        #region GetIETransactionsHistory_UnitTest
        /// <summary>
        /// GetIETransactionsHistory_UnitTest
        /// </summary>
        [TestMethod]
        public void GetIETransactionsHistory_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedBController();

            String strFilingTransId = "";

            var results = controller.GetIETransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion GetIETransactionsHistory_UnitTest

    }
}
