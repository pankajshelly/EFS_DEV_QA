using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedIE24HContrTransSchedCUT
    {        
        public NonItemizedIE24HContrTransSchedCUT()
        {
            // TO DO;
        }

        #region NonItemizedIE24HContrTransSchedCUT_UnitTest
        /// <summary>
        /// NonItemizedIE24HContrTransSchedCUT_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemizedIE24HContrTransSchedCUT_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

            var result = controller.NonItemIE24HContributionSchedC() as ViewResult;

            Assert.AreEqual("NonItemIE24HContributionSchedC", result.ViewName.ToString());
        }
        #endregion NonItemizedIE24HContrTransSchedCUT_UnitTest

        #region SaveNonItemIE24HContrSchedCData_UnitTest
        /// <summary>
        /// SaveNonItemIE24HContrSchedCData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIE24HContrSchedCData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

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

            var results = controller.SaveNonItemIE24HContrSchedCData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.ContributorTypeId, data.FlngEntName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemIE24HContrSchedCData_UnitTest

        #region UpdateNonItemIE24HContrSchedCData_UnitTest
        /// <summary>
        /// UpdateNonItemIE24HContrSchedCData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateNonItemIE24HContrSchedCData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

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

            var results = controller.UpdateNonItemIE24HContrSchedCData(data.FilingTransId, data.FilingEntId, data.ContributorTypeId, data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.TransExplanation, data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.TreasId, data.AddrId, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.TreasurerOccupation, data.TreasurerEmployer, data.R_Supported, data.CandBallotPropReference, "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItemIE24HContrSchedCData_UnitTest

        #region SubmitNonItemIE24HContrSchedCData_UnitTest
        /// <summary>
        /// SubmitNonItemIE24HContrSchedCData_UnitTest
        /// </summary>
        [TestMethod]
        public void SubmitNonItemIE24HContrSchedCData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

            String strFilingTransId = "";

            var results = controller.SubmitNonItemIE24HContrSchedCData(strFilingTransId);

            Assert.AreEqual("TRUE", results.ToString());
        }
        #endregion SubmitNonItemIE24HContrSchedCData_UnitTest

        #region DeleteNonItemIE24HContrSchedC_UnitTest
        /// <summary>
        /// DeleteNonItemIE24HContrSchedC_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemIE24HContrSchedC_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItemIE24HContrSchedC(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemIE24HContrSchedC_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

            var results = controller.GetPaymentMethodData() as JsonResult;

            IList<PaymentMethodModel> lstPaymentMethodModel = results.Data as List<PaymentMethodModel>;

            Assert.IsTrue(lstPaymentMethodModel.Count >= 1);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region GetContributorCodeSchedC_UnitTest
        /// <summary>
        /// GetContributorCodeSchedC_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorCodeSchedC_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

            var results = controller.GetContributorCodeSchedC() as JsonResult;

            IList<ContributorNameModel> lstContributorNameModel = results.Data as List<ContributorNameModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorCodeSchedC_UnitTest

        #region GetChildTransExists_UnitTest
        /// <summary>
        /// GetChildTransExists_UnitTest
        /// </summary>
        [TestMethod]
        public void GetChildTransExists_UnitTest()
        {
            var controller = new NonItemIE24HContributionSchedCController();

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
            var controller = new NonItemIE24HContributionSchedCController();

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
            var controller = new NonItemIE24HContributionSchedCController();

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
            var controller = new NonItemIE24HContributionSchedCController();

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
            var controller = new NonItemIE24HContributionSchedCController();

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
            var controller = new NonItemIE24HContributionSchedCController();

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
            var controller = new NonItemIE24HContributionSchedCController();

            String strFilingTransId = "";

            var results = controller.GetIETransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion GetIETransactionsHistory_UnitTest
        
    }
}
