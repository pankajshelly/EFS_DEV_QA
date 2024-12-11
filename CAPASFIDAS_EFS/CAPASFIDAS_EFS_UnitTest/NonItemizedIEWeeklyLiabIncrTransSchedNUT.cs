using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedIEWeeklyLiabIncrTransSchedNUT
    {        
        public NonItemizedIEWeeklyLiabIncrTransSchedNUT()
        {
            //
            // TO DO;
            //
        }

        #region NonItemIEWeeklyLiabilityIncurredSchedN_UnitTest
        /// <summary>
        /// NonItemIEWeeklyLiabilityIncurredSchedN_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIEWeeklyLiabIncrSchedNData_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            var result = controller.NonItemIEWeeklyLiabilityIncurredSchedN() as ViewResult;

            Assert.AreEqual("NonItemIEWeeklyLiabilityIncurredSchedN", result.ViewName.ToString());
        }
        #endregion NonItemIEWeeklyLiabilityIncurredSchedN_UnitTest

        #region SaveNonItemIEWeeklyContrSchedFData_UnitTest
        /// <summary>
        /// SaveNonItemIEWeeklyContrSchedFData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIEWeeklyContrSchedFData_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

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
                OwedAmt = "",
                PurposeCodeId = "",
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

            var results = controller.SaveNonItemIEWeeklyLiabIncrSchedNData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.PurposeCodeId, data.FlngEntName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.OwedAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemIEWeeklyContrSchedFData_UnitTest

        #region UpdateNonItemIEWeeklyContrSchedFData_UnitTest
        /// <summary>
        /// UpdateNonItemIEWeeklyContrSchedFData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateNonItemIEWeeklyContrSchedFData_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

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
                RSubcontractor = "",
                RLiability = "",
                DateIncurredOrgAmtId = "",
                PurposeCodeId = "",
                OwedAmt = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.UpdateNonItemIEWeeklyLiabIncrSchedNData(data.FilingTransId, data.FilingEntId, data.PurposeCodeId, data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.OwedAmt, data.TransExplanation, data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.TreasId, data.AddrId, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.TreasurerOccupation, data.TreasurerEmployer, data.R_Supported, data.CandBallotPropReference, "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItemIEWeeklyContrSchedFData_UnitTest

        #region SubmitNonItemIEWeeklyLiabIncrSchedNData_UnitTest
        /// <summary>
        /// SubmitNonItemIEWeeklyLiabIncrSchedNData_UnitTest
        /// </summary>
        [TestMethod]
        public void SubmitNonItemIEWeeklyLiabIncrSchedNData_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            String strFilingTransId = "";

            var results = controller.SubmitNonItemIEWeeklyLiabIncrSchedNData(strFilingTransId);

            Assert.AreEqual("TRUE", results.ToString());
        }
        #endregion SubmitNonItemIEWeeklyLiabIncrSchedNData_UnitTest

        #region DeleteNonItemIEWeeklyLiabIncrSchedN_UnitTest
        /// <summary>
        /// DeleteNonItemIEWeeklyLiabIncrSchedN_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemIEWeeklyLiabIncrSchedN_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItemIEWeeklyLiabIncrSchedN(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemIEWeeklyLiabIncrSchedN_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            var results = controller.GetPaymentMethodData() as JsonResult;

            IList<PaymentMethodModel> lstPaymentMethodModel = results.Data as List<PaymentMethodModel>;

            Assert.IsTrue(lstPaymentMethodModel.Count >= 1);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region GetChildTransExists_UnitTest
        /// <summary>
        /// GetChildTransExists_UnitTest
        /// </summary>
        [TestMethod]
        public void GetChildTransExists_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            String strFilingTransId = "";

            var results = controller.GetChildTransExists(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion GetChildTransExists_UnitTest

        #region AutoCompleteEntityName_UnitTest
        /// <summary>
        /// AutoCompleteEntityName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteEntityName_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

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
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

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
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

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
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            String strFilingTransId = "";

            var results = controller.GetIETransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion GetIETransactionsHistory_UnitTest

        #region GetPurposeCodeLiabIncrSchedN_UnitTest
        /// <summary>
        /// GetPurposeCodeLiabIncrSchedN_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPurposeCodeLiabIncrSchedN_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            var results = controller.GetPurposeCodeLiabIncrSchedN() as JsonResult;

            IList<PurposeCodeModel> lstPurposeCodeModel = results.Data as List<PurposeCodeModel>;

            Assert.IsTrue(lstPurposeCodeModel.Count >= 1);
        }
        #endregion GetPurposeCodeLiabIncrSchedN_UnitTest

        #region GetAutoCompleteCreditorName_UnitTest
        /// <summary>
        /// GetAutoCompleteCreditorName_UnitTest
        /// </summary>
        [TestMethod]
        public void GetAutoCompleteCreditorName_UnitTest()
        {
            var controller = new NonItemIEWeeklyLiabilityIncurredSchedNController();

            String strName = "A";

            var results = controller.GetAutoCompleteCreditorName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteCreditorName_UnitTest

    }
}
