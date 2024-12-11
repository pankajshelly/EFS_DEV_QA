using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for OutstandingLiabilityLoansSchedNUT
    /// </summary>
    [TestClass]
    public class OutstandingLiabilityLoansSchedNUT
    {
        public OutstandingLiabilityLoansSchedNUT()
        {
            
        }

        #region  OutstandingLiabilityLoansSchedN_UnitTest
        /// <summary>
        /// OutstandingLiabilityLoansSchedN_UnitTest
        /// </summary>
        [TestMethod]
        public void OutstandingLiabilityLoansSchedN_UnitTest()
        {
            var controller = new OutStandingLiabilityLoansSchedNController();

            var result = controller.OutStandingLiabilityLoansSchedN() as ViewResult;

            Assert.AreEqual("OutStandingLiabilityLoansSchedN", result.ViewName.ToString());
        }
        #endregion OutstandingLiabilityLoansSchedN_UnitTest

        #region GetAllTransactionTypesData_UnitTest
        /// <summary>
        /// GetAllTransactionTypesData_UnitTest
        /// </summary>
        [TestMethod]        
        public void GetAllTransactionTypesData_UnitTest()
        {
            String strFilerId = "113070";
            String strElectionCycle = "16";
            String strOfficeType = "1";
            String strDisclosurePeriod = "1";

            var controller = new _UC_GridCommonControlController();

            JsonResult results = controller.GetAllTransactionTypesData(strFilerId, strElectionCycle, strOfficeType, strDisclosurePeriod, "", "", "", "", "") as JsonResult;

            IList<FilingTransactionDataModel> lstFilingTransactionDataModel = results.Data as List<FilingTransactionDataModel>;

            Assert.IsTrue(lstFilingTransactionDataModel.Count >= 1);

        }
        #endregion GetAllTransactionTypesData_UnitTest

        #region SaveOutstandingLiabilityData_UnitTest
        /// <summary>
        /// SaveOutstandingLiabilityData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveOutstandingLiabilityData_UnitTest()
        {
            var controller = new OutStandingLiabilityLoansSchedNController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilerId = "",
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
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                FlngEntCountry = "",
                PurposeCodeId = "",
                PaymentTypeId = "",
                PayNumber = "",
                OrgAmt = "",
                OwedAmt = "",
                TransExplanation = "",
                CreatedBy = "SBasireddy"
            };

            var results = controller.SaveOutstandingLiabilityData(data.FilerId, data.ElectYearId, data.ElectYearId,
                data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingTransId,
                data.FilingSchedId, data.SchedDate, data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity,
                data.FlngEntState, data.FlngEntZip, data.PurposeCodeId, data.PaymentTypeId, data.PayNumber, data.OrgAmt,
                data.OwedAmt, data.TransExplanation, "", "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());

        }
        #endregion SaveOutstandingLiabilityData_UnitTest

        #region UpdateOutstandingLiabilitySchedN_UnitTest
        /// <summary>
        /// UpdateOutstandingLiabilitySchedN_UnitTest
        /// </summary>
        [TestMethod]        
        public void UpdateOutstandingLiabilitySchedN_UnitTest()
        {
            var controller = new OutStandingLiabilityLoansSchedNController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingTransId = "",
                SchedDate = "",
                FilingEntId = "",
                FlngEntName = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                FlngEntCountry = "",
                PaymentTypeId = "",
                PurposeCodeId = "",
                PayNumber = "",
                OrgAmt = "",
                OwedAmt = "",
                TransExplanation = "",
                ModifiedBy = "SBasireddy" // Testing Only....
            };

            var results = controller.UpdateOutstandingLiabilitySchedN(data.FilingTransId, data.FilingEntId, data.SchedDate, data.FlngEntName,
                data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PurposeCodeId,
                data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.OwedAmt, data.TransExplanation, "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateOutstandingLiabilitySchedN_UnitTest

        #region GetOutstandingLiabilityExists_UnitTest
        /// <summary>
        /// GetOutstandingLiabilityExists_UnitTest
        /// </summary>
        [TestMethod]
        public void GetOutstandingLiabilityExists_UnitTest()
        {
            var controller = new OutStandingLiabilityLoansSchedNController();

            String strFilingTransId = "";

            var results = controller.GetOutstandingLiabilityExists(strFilingTransId, "");

            if (results.ToString() == "TRUE")
                Assert.AreEqual("TRUE", results.ToString());
            else
                Assert.AreEqual("FALSE", results.ToString());
        }
        #endregion GetOutstandingLiabilityExists_UnitTest

        #region DeleteOutstandingLiability_UnitTest
        /// <summary>
        /// DeleteOutstandingLiability_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteOutstandingLiability_UnitTest()
        {
            var controller = new OutStandingLiabilityLoansSchedNController();

            String strFilingTransId = "";

            var results = controller.DeleteOutstandingLiability(strFilingTransId, "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteOutstandingLiability_UnitTest

        #region AutoCompleteEntityName_UnitTest
        /// <summary>
        /// AutoCompleteEntityName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteEntityName_UnitTest()
        {
            var controller = new OutStandingLiabilityLoansSchedNController();

            String strName = "";

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
            var controller = new OutStandingLiabilityLoansSchedNController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest


    }
}
