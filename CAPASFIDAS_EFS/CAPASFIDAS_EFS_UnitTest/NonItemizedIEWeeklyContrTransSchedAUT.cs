using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for NonItemizedIEWeeklyContrTransSchedAUT
    /// </summary>
    [TestClass]
    public class NonItemizedIEWeeklyContrTransSchedAUT
    {
        public NonItemizedIEWeeklyContrTransSchedAUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NonItemizedIEWeeklyContrTransSchedAUT_UnitTest
        /// <summary>
        /// NonItemizedIEWeeklyContrTransSchedAUT_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemizedIEWeeklyContrTransSchedAUT_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

            var result = controller.NonItemIEWeeklyContributionSchedA() as ViewResult;

            Assert.AreEqual("NonItemIEWeeklyContributionSchedA", result.ViewName.ToString());
        }
        #endregion NonItemizedIEWeeklyContrTransSchedAUT_UnitTest

        #region SaveNonItemIEWeeklyContrSchedAData_UnitTest
        /// <summary>
        /// SaveNonItemIEWeeklyContrSchedAData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIEWeeklyContrSchedAData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

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

            var results = controller.SaveNonItemIEWeeklyContrSchedAData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.ContributorTypeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemIEWeeklyContrSchedAData_UnitTest

        #region UpdateNonItemIEWeeklyContrSchedAData_UnitTest
        /// <summary>
        /// UpdateNonItemIEWeeklyContrSchedAData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateNonItemIEWeeklyContrSchedAData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

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

            var results = controller.UpdateNonItemIEWeeklyContrSchedAData(data.FilingTransId, data.FilingEntId, data.ContributorTypeId, data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.TransExplanation, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.TreasId, data.AddrId, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.TreasurerOccupation, data.TreasurerEmployer, data.R_Supported, data.CandBallotPropReference, "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItemIEWeeklyContrSchedAData_UnitTest

        #region SubmitNonItemIEWeeklyContrSchedAData_UnitTest
        /// <summary>
        /// SubmitNonItemIEWeeklyContrSchedAData_UnitTest
        /// </summary>
        [TestMethod]
        public void SubmitNonItemIEWeeklyContrSchedAData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

            String strFilingTransId = "";

            var results = controller.SubmitNonItemIEWeeklyContrSchedAData(strFilingTransId);

            Assert.AreEqual("TRUE", results.ToString());
        }
        #endregion SubmitNonItemIEWeeklyContrSchedAData_UnitTest

        #region DeleteNonItemIEWeeklyContrSchedA_UnitTest
        /// <summary>
        /// DeleteNonItemIEWeeklyContrSchedA_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemIEWeeklyContrSchedA_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItemIEWeeklyContrSchedA(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemIEWeeklyContrSchedA_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

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
            var controller = new NonItemIEWeeklyContributionSchedAController();

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
            var controller = new NonItemIEWeeklyContributionSchedAController();

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
            var controller = new NonItemIEWeeklyContributionSchedAController();

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
            var controller = new NonItemIEWeeklyContributionSchedAController();

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
            var controller = new NonItemIEWeeklyContributionSchedAController();

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
            var controller = new NonItemIEWeeklyContributionSchedAController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

        #region GetIEWeeklyContrbutionTreasurerData_UnitTest
        /// <summary>
        /// GetIEWeeklyContrbutionTreasurerData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetIEWeeklyContrbutionTreasurerData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

            var results = controller.GetIEWeeklyContrbutionTreasurerData() as JsonResult;

            IList<NonItemIETreasurerModel> lstNonItemIETreasurerModel = results.Data as List<NonItemIETreasurerModel>;

            Assert.IsTrue(lstNonItemIETreasurerModel.Count >= 1);
        }
        #endregion GetIEWeeklyContrbutionTreasurerData_UnitTest

        #region GetIETransactionsHistory_UnitTest
        /// <summary>
        /// GetIEWeeklyContrbutionTreasurerData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetIETransactionsHistory_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedAController();

            String strFilingTransId = "";

            var results = controller.GetIETransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion GetIETransactionsHistory_UnitTest

        #region GetDateIncurredIdValue_UnitTest
        /// <summary>
        /// GetDateIncurredIdValue_UnitTest
        /// </summary>
        [TestMethod]
        public void GetDateIncurredIdValue_UnitTest()
        {
            var controller = new NonItemIEWeeklyExpenditureSchedFController();

            String strFilingEntityId = "";

            var results = controller.GetDateIncurredIdValue(strFilingEntityId,"") as JsonResult;

            IList<DateIncurredModel> lstDateIncurredModel = results.Data as List<DateIncurredModel>;

            Assert.IsTrue(lstDateIncurredModel.Count >= 1);
        }
        #endregion GetDateIncurredIdValue_UnitTest

        #region GetDateIncurred_UnitTest
        /// <summary>
        /// GetDateIncurred_UnitTest
        /// </summary>
        [TestMethod]
        public void GetDateIncurred_UnitTest()
        {
            var controller = new NonItemIEWeeklyExpenditureSchedFController();

            String strFilingEntityId = "";

            var results = controller.GetDateIncurred(strFilingEntityId,"") as JsonResult;

            IList<DateIncurredModel> lstDateIncurredModel = results.Data as List<DateIncurredModel>;

            Assert.IsTrue(lstDateIncurredModel.Count >= 1);
        }
        #endregion GetDateIncurred_UnitTest




    }
}
