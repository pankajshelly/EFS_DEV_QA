using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedIE24HourExpTransSchedFUT
    {
        public NonItemizedIE24HourExpTransSchedFUT()
        {
            ///
            /// TO DO;
            /// 
        }

        #region NonItemIEWeeklyExpenditureSchedF_UnitTest
        /// <summary>
        /// NonItemIEWeeklyExpenditureSchedF_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemIEWeeklyExpenditureSchedF_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            var result = controller.NonItemIE24HourExpenditureSchedF() as ViewResult;

            Assert.AreEqual("NonItemIE24HourExpenditureSchedF", result.ViewName.ToString());
        }
        #endregion NonItemIEWeeklyExpenditureSchedF_UnitTest

        #region SaveNonItemIEWeeklyContrSchedFData_UnitTest
        /// <summary>
        /// SaveNonItemIEWeeklyContrSchedFData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIEWeeklyContrSchedFData_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

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

            var results = controller.SaveNonItemIE24HourExpSchedFData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.ContributorTypeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "", "", "");

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
            var controller = new NonItemIE24HourExpenditureSchedFController();

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

            var results = controller.UpdateNonItemIE24HourExpSchedFData(data.FilingTransId, data.FilingEntId, data.PurposeCodeId, data.SubmissionDate, data.FilingSchedId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.OwedAmt, data.TransExplanation, data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.TreasId, data.AddrId, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.IEDescription, data.TreasurerOccupation, data.TreasurerEmployer, data.R_Supported, data.CandBallotPropReference, data.RSubcontractor, data.RLiability, data.DateIncurredOrgAmtId, "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateNonItemIEWeeklyContrSchedFData_UnitTest

        #region SubmitNonItemIEWeeklyContrSchedFData_UnitTest
        /// <summary>
        /// SubmitNonItemIEWeeklyContrSchedFData_UnitTest
        /// </summary>
        [TestMethod]
        public void SubmitNonItemIEWeeklyContrSchedFData_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            String strFilingTransId = "";

            var results = controller.SubmitNonItemIE24HourExpSchedFData(strFilingTransId);

            Assert.AreEqual("TRUE", results.ToString());
        }
        #endregion SubmitNonItemIEWeeklyContrSchedFData_UnitTest

        #region DeleteNonItemIEWeeklyContrSchedF_UnitTest
        /// <summary>
        /// DeleteNonItemIEWeeklyContrSchedF_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemIEWeeklyContrSchedF_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            String strFilingTransId = "";

            var results = controller.DeleteNonItemIEWeeklyContrSchedF(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemIEWeeklyContrSchedF_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

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
        public void GetPurposeCodeSchedF_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            var results = controller.GetPurposeCodeSchedF() as JsonResult;

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
            var controller = new NonItemIE24HourExpenditureSchedFController();

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
            var controller = new NonItemIE24HourExpenditureSchedFController();

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
            var controller = new NonItemIE24HourExpenditureSchedFController();

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
            var controller = new NonItemIE24HourExpenditureSchedFController();

            var results = controller.GetIE24HourExpTreasurerData() as JsonResult;

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
            var controller = new NonItemIE24HourExpenditureSchedFController();

            String strFilingTransId = "";

            var results = controller.GetIETransactionsHistory(strFilingTransId) as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);
        }
        #endregion GetIETransactionsHistory_UnitTest

        #region GetDateIncurredUpdate_UnitTest
        /// <summary>
        /// GetDateIncurredUpdate_UnitTest
        /// </summary>
        [TestMethod]
        public void GetDateIncurredUpdate_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            String strFilingTransId = "";

            var results = controller.GetDateIncurredUpdate(strFilingTransId) as JsonResult;

            IList<DateIncurredModel> lstDateIncurredModel = results.Data as List<DateIncurredModel>;

            Assert.IsTrue(lstDateIncurredModel.Count >= 1);
        }
        #endregion GetDateIncurredUpdate_UnitTest

        #region GetDateIncurredNew_UnitTest
        /// <summary>
        /// GetDateIncurredNew_UnitTest
        /// </summary>
        [TestMethod]
        public void GetDateIncurredNew_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            var results = controller.GetDateIncurredNew() as JsonResult;

            IList<DateIncurredModel> lstDateIncurredModel = results.Data as List<DateIncurredModel>;

            Assert.IsTrue(lstDateIncurredModel.Count >= 1);
        }
        #endregion GetDateIncurredNew_UnitTest

        #region GetPurposeCodesSubcontractor_UnitTest
        /// <summary>
        /// GetPurposeCodesSubcontractor_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPurposeCodesSubcontractor_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            var results = controller.GetPurposeCodesSubcontractor() as JsonResult;

            IList<PurposeCodeModel> lstPurposeCodeModel = results.Data as List<PurposeCodeModel>;

            Assert.IsTrue(lstPurposeCodeModel.Count >= 1);
        }
        #endregion GetPurposeCodesSubcontractor_UnitTest

        #region GetPurposeCodeExpenditure_UnitTest
        /// <summary>
        /// GetPurposeCodeExpenditure_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPurposeCodeExpenditure_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            var results = controller.GetPurposeCodeExpenditure() as JsonResult;

            IList<PurposeCodeModel> lstPurposeCodeModel = results.Data as List<PurposeCodeModel>;

            Assert.IsTrue(lstPurposeCodeModel.Count >= 1);
        }
        #endregion GetPurposeCodeExpenditure_UnitTest

        #region GetAutoCompleteCreditorName_UnitTest
        /// <summary>
        /// GetAutoCompleteCreditorName_UnitTest
        /// </summary>
        [TestMethod]
        public void GetAutoCompleteCreditorName_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            String strName = "A";

            var results = controller.GetAutoCompleteCreditorName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteCreditorName_UnitTest

        #region GetOutstandingAmount_UnitTest
        /// <summary>
        /// GetOutstandingAmount_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOutstandingAmount_UnitTest()
        {
            var controller = new NonItemIE24HourExpenditureSchedFController();

            String strFlngEntityId = "";
            String strUpdateStatusVal = "";
            String strSchedFAmt = "";
            String strFilingTransId = "";

            var results = controller.GetOutstandingAmount(strFlngEntityId, strUpdateStatusVal, strSchedFAmt, strFilingTransId) as JsonResult;

            String strResults = results.Data as String;

            Assert.IsTrue(strResults != "");
        }
        #endregion GetOutstandingAmount_UnitTest
    }
}
