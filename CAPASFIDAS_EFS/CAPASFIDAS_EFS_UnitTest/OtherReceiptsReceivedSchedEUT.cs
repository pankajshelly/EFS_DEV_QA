using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for OtherReceiptsReceivedSchedEUT
    /// </summary>
    [TestClass]
    public class OtherReceiptsReceivedSchedEUT
    {
        public OtherReceiptsReceivedSchedEUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region OtherReceiptsReceivedSchedE_UnitTest
        /// <summary>
        /// OtherReceiptsReceivedSchedE_UnitTest
        /// </summary>
        [TestMethod]
        public void OtherReceiptsReceivedSchedE_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

            var result = controller.OtherReceiptsReceivedSchedE() as ViewResult;

            Assert.AreEqual("ContributionInKind", result.ViewName.ToString());
        }
        #endregion OtherReceiptsReceivedSchedE_UnitTest

        #region SaveFlngTransOtherReceiptsReceived_UnitTest
        /// <summary>
        /// SaveFlngTransOtherReceiptsReceived_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveFlngTransOtherReceiptsReceived_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

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
                FilingSchedId = "",
                SchedDate = "",
                FlngEntName = "",
                FlngEntCountry = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                PayNumber = "",
                OrgAmt = "",
                TransExplanation = "",
                RItemized = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveFlngTransOtherReceiptsReceived(data.FilerId, data.ElectionYear, data.ElectYearId,
                data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingSchedId,
                data.SchedDate, data.FlngEntName, data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState,
                data.FlngEntZip, data.ReceiptTypeId, data.ContributionTypeId, data.PaymentTypeId, data.PayNumber, data.OrgAmt,
                data.TransExplanation, data.RItemized, "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveFlngTransOtherReceiptsReceived_UnitTest

        #region UpdateOtherReceiptsReceived_UnitTest
        /// <summary>
        /// UpdateOtherReceiptsReceived_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateOtherReceiptsReceived_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

            FilingTransactionDataModel data = new FilingTransactionDataModel
            {
                FilingTransId = "",
                FilingEntityId = "",
                ContributionTypeId = "",
                SchedDate = "",
                PayNumber = "",
                PaymentTypeId = "",
                OriginalAmount = "",
                TransExplanation = "",
                FilingEntityName = "",
                FilingFirstName = "",
                FilingMiddleName = "",
                FilingLastName = "",
                FilingCountry = "",
                FilingStreetName = "",
                FilingCity = "",
                FilingState = "",
                FilingZip = "",
                ModifiedBy = "SBasireddy"
            };

            var results = controller.UpdateOtherReceiptsReceived(data.FilingTransId, data.FilingEntityId, data.SchedDate,
                data.FilingEntityName, data.FilingEntityName, data.FilingStreetName, data.FilingCity, data.FilingState, data.FilingZip,
                data.ReceiptCodeId, data.PaymentTypeId, data.PayNumber, data.OriginalAmount, data.TransExplanation, data.RItemized, "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateOtherReceiptsReceived_UnitTest

        #region DeleteFilingTransactions_UnitTest
        /// <summary>
        /// DeleteFilingTransactions_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteFilingTransactions_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

            String strFilingTransId = "";

            var results = controller.DeleteFilingTransactions(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteFilingTransactions_UnitTest

        #region AutoCompleteFirstName_UnitTest
        /// <summary>
        /// AutoCompleteFirstName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteFirstName_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

            String strName = "A";

            var results = controller.AutoCompleteFirsttName(strName);

            IList<String> data = results.Data as List<String>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion AutoCompleteFirstName_UnitTest        

        #region AutoCompleteEntityName_UnitTest
        /// <summary>
        /// AutoCompleteEntityName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteEntityName_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

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
            var controller = new OtherReceiptsReceivedSchedEController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

        #region GetReceiptTypeData_UnitTest
        /// <summary>
        /// GetReceiptTypeData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetReceiptTypeData_UnitTest()
        {
            var controller = new OtherReceiptsReceivedSchedEController();

            var results = controller.GetReceiptTypeData();

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetReceiptTypeData_UnitTest

    }
}
