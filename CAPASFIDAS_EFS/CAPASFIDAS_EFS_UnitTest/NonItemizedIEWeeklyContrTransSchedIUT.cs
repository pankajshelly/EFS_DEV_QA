using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedIEWeeklyContrTransSchedIUT
    {        
        public NonItemizedIEWeeklyContrTransSchedIUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NonItemIEWeeklyContributionSchedIUT_UnitTest
        /// <summary>
        /// NonItemIEWeeklyContributionSchedIUT_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemIEWeeklyContributionSchedIUT_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

            var result = controller.NonItemIEWeeklyContributionSchedI() as ViewResult;

            Assert.AreEqual("NonItemIEWeeklyContributionSchedI", result.ViewName.ToString());
        }
        #endregion NonItemIEWeeklyContributionSchedIUT_UnitTest

        #region SaveNonItemIEWeeklyContrSchedIData_UnitTest
        /// <summary>
        /// SaveNonItemIEWeeklyContrSchedIData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIEWeeklyContrSchedIData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

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

            var results = controller.SaveNonItemIEWeeklyContrSchedIData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.ContributorTypeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemIEWeeklyContrSchedIData_UnitTest

        #region UpdateNonItemIEWeeklyContrSchedIData_UnitTest
        /// <summary>
        /// UpdateNonItemIEWeeklyContrSchedIData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateNonItemIEWeeklyContrSchedIData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

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

            var results = controller.UpdateNonItemIEWeeklyContrSchedIData(data.FilingTransId, data.FilingEntId, data.ContributorTypeId, data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.TransExplanation, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.TreasId, data.AddrId, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.TreasurerOccupation, data.TreasurerEmployer, data.R_Supported, data.CandBallotPropReference, "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItemIEWeeklyContrSchedIData_UnitTest

        #region SubmitNonItemIEWeeklyContrSchedIData_UnitTest
        /// <summary>
        /// SubmitNonItemIEWeeklyContrSchedIData_UnitTest
        /// </summary>
        [TestMethod]
        public void SubmitNonItemIEWeeklyContrSchedIData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

            String strFilingTransId = "";

            var results = controller.SubmitNonItemIEWeeklyContrSchedIData(strFilingTransId);

            Assert.AreEqual("TRUE", results.ToString());
        }
        #endregion SubmitNonItemIEWeeklyContrSchedIData_UnitTest

        #region DeleteNonItemIEWeeklyContrSchedI_UnitTest
        /// <summary>
        /// DeleteNonItemIEWeeklyContrSchedI_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemIEWeeklyContrSchedI_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItemIEWeeklyContrSchedI(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemIEWeeklyContrSchedI_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

            var results = controller.GetPaymentMethodData() as JsonResult;

            IList<PaymentMethodModel> lstPaymentMethodModel = results.Data as List<PaymentMethodModel>;

            Assert.IsTrue(lstPaymentMethodModel.Count >= 1);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region GetContributorCodeSchedI_UnitTest
        /// <summary>
        /// GetContributorCodeSchedI_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorCodeSchedI_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

            var results = controller.GetLoanerCodeSchedI() as JsonResult;

            IList<ContributorNameModel> lstContributorNameModel = results.Data as List<ContributorNameModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorCodeSchedI_UnitTest

        #region GetChildTransExists_UnitTest
        /// <summary>
        /// GetChildTransExists_UnitTest
        /// </summary>
        [TestMethod]
        public void GetChildTransExists_UnitTest()
        {
            var controller = new NonItemIEWeeklyContributionSchedIController();

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
            var controller = new NonItemIEWeeklyContributionSchedIController();

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
            var controller = new NonItemIEWeeklyContributionSchedIController();

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
            var controller = new NonItemIEWeeklyContributionSchedIController();

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
            var controller = new NonItemIEWeeklyContributionSchedIController();

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
            var controller = new NonItemIEWeeklyContributionSchedIController();

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
            var controller = new NonItemIEWeeklyContributionSchedIController();

            String strFilingTransId = "";

            var results = controller.GetIETransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion GetIETransactionsHistory_UnitTest


    }
}
