using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;


namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for NonCampaignHousekeepingReceiptsSchedPUT
    /// </summary>
    [TestClass]
    public class NonCampaignHousekeepingReceiptsSchedPUT
    {
        public NonCampaignHousekeepingReceiptsSchedPUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NonCampaignHousekeepingReceiptsSchedP_UnitTest
        /// <summary>
        /// NonCampaignHousekeepingReceiptsSchedP_UnitTest
        /// </summary>
        [TestMethod]
        public void NonCampaignHousekeepingReceiptsSchedP_UnitTest()
        {
            var controller = new NonCampaignHousekeepingReceiptsSchedPController();

            var result = controller.NonCampaignHousekeepingReceiptsSchedP() as ViewResult;

            Assert.AreEqual("NonCampaignHousekeepingReceiptsSchedP", result.ViewName.ToString());
        }
        #endregion NonCampaignHousekeepingReceiptsSchedP_UnitTest

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

        #region SaveFilingTransNonCompReceipts_UnitTest
        /// <summary>
        /// SaveFilingTransNonCompReceipts_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveFilingTransNonCompReceipts_UnitTest()
        {
            var controller = new NonCampaignHousekeepingReceiptsSchedPController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingEntId = "",
                FilerId = "",
                ElectionDate = "",
                ElectionTypeId = "P", // lstElectionType; Testing Only...
                ElectYearId = "",
                OfficeTypeId = "",
                FilingTypeId = "",
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
                ReceiptCodeId = "",
                PaymentTypeId = "",
                PayNumber = "",
                TransExplanation = "",
                RItemized = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveFilingTransNonCompReceipts(data.FilerId, data.ElectionYear, data.ElectYearId,
                data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingSchedId,
                data.SchedDate, data.ReceiptCodeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName,
                data.FlngEntCountry, data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId,
                data.PayNumber, data.OrgAmt, data.TransExplanation, data.RItemized, "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveFilingTransNonCompReceipts_UnitTest

        #region UpdateFilingTransNonCompHKReceipts_UnitTest
        /// <summary>
        /// UpdateFilingTransNonCompHKReceipts_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateFilingTransNonCompHKReceipts_UnitTest()
        {
            var controller = new NonCampaignHousekeepingReceiptsSchedPController();

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

            var results = controller.UpdateFilingTransNonCompHKReceipts(data.FilingTransId, data.FilingEntityId, data.ContributorTypeId,
                data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OriginalAmount, data.TransExplanation, data.FilingEntityName,
                data.FilingFirstName, data.FilingMiddleName, data.FilingLastName, data.FilingCountry, data.FilingStreetName,
                data.FilingCity, data.FilingState, data.FilingZip, "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateFilingTransNonCompHKReceipts_UnitTest                                              
                
        #region GetReceiptCodeData_UnitTest
        /// <summary>
        /// GetReceiptCodeData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetReceiptCodeData_UnitTest()
        {
            var controller = new NonCampaignHousekeepingReceiptsSchedPController();

            var results = controller.GetReceiptCodeData() as JsonResult;

            IList<ReceiptCodeModel> lstContributorNameModel = results.Data as List<ReceiptCodeModel>;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetReceiptCodeData_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new NonCampaignHousekeepingReceiptsSchedPController();

            var results = controller.GetPaymentMethodData();

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region AutoCompleteFirstName_UnitTest
        /// <summary>
        /// AutoCompleteFirstName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteFirstName_UnitTest()
        {
            var controller = new ContributionInKindController();

            String strName = "A";

            var results = controller.AutoCompleteFirsttName(strName);

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
            var controller = new ContributionInKindController();

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
            var controller = new ContributionInKindController();

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
            var controller = new ContributionInKindController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

    }
}
