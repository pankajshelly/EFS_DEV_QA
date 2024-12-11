using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for ContributionInKindSchedDUT
    /// </summary>
    [TestClass]
    public class ContributionInKindSchedDUT
    {
        public ContributionInKindSchedDUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ContributionInKind_UnitTest
        /// <summary>
        /// ContributionInKind_UnitTest
        /// </summary>
        [TestMethod]
        public void ContributionInKind_UnitTest()
        {
            var controller = new ContributionInKindController();

            var result = controller.ContributionInKind() as ViewResult;

            Assert.AreEqual("ContributionInKind", result.ViewName.ToString());
        }
        #endregion ContributionInKind_UnitTest

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

        #region SaveFilingTransInKindData_UnitTest
        /// <summary>
        /// SaveFilingTransInKindData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveFilingTransInKindData_UnitTest()
        {
            var controller = new ContributionInKindController();

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
                ContributorTypeId = "",
                ContributionTypeId = "",
                PaymentTypeId = "",
                PayNumber = "",
                TransExplanation = "",
                RItemized = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveFilingTransInKindData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId,
                data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingSchedId, data.SchedDate, data.ContributorTypeId,
                data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName,
                data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.ContributionTypeId, data.PaymentTypeId, data.PayNumber,
                data.OrgAmt, data.TransExplanation, data.RItemized, "", "", "", "", "", "", "", "",
                "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveFilingTransInKindData_UnitTest

        #region UpdateFilingTransContrInKindData_UnitTest
        /// <summary>
        /// UpdateFilingTransContrInKindData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateFilingTransContrInKindData_UnitTest()
        {
            var controller = new ContributionInKindController();

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

            var results = controller.UpdateFilingTransContrInKindData(data.FilingTransId, data.FilingEntityId, data.ContributorTypeId,
                data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OriginalAmount, data.TransExplanation, data.FilingEntityName,
                data.FilingFirstName, data.FilingMiddleName, data.FilingLastName, data.FilingCountry, data.FilingStreetName,
                data.FilingCity, data.FilingState, data.FilingZip, "", "", "", "", "", "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateFilingTransContrInKindData_UnitTest

        #region DeleteFilingTransactions_UnitTest
        /// <summary>
        /// DeleteFilingTransactions_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteFilingTransactions_UnitTest()
        {
            var controller = new ContributionInKindController();

            String strFilingTransId = "";

            var results = controller.DeleteFilingTransactions(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteFilingTransactions_UnitTest

        #region SaveSchedDPartnersData_UnitTest
        /// <summary>
        /// SaveSchedDPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveSchedDPartnersData_UnitTest()
        {
            var controller = new ContributionInKindController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilerId = "",
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
                FilingEntId = "",
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntLastName = "",
                FlngEntMiddleName = "",
                FlngEntStrNum = "",
                FlngEntCountry = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                FlngEntZip4 = "",
                TransExplanation = "",
                RItemized = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveSchedDPartnersData(data.FilingTransId, data.FilingSchedId, data.SchedDate,
                data.FilerId, data.FilerId, data.ElectYearId, data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate,
                data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName,
                data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.FlngEntZip4, data.OrgAmt, data.TransExplanation, data.RItemized, "", "", "", "",
                "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveSchedDPartnersData_UnitTest

        #region UpdateSchedDPartnersData_UnitTest
        /// <summary>
        /// UpdateSchedDPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateSchedDPartnersData_UnitTest()
        {
            var controller = new ContributionInKindController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingTransId = "",
                FilingEntId = "",
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntMiddleName = "",
                FlngEntLastName = "",
                FlngEntStrNum = "",
                FlngEntCountry = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                FlngEntZip4 = "",
                OrgAmt = "",
                TransExplanation = "",
                ModifiedBy = "SBasireddy"
            };

            var results = controller.UpdateSchedDPartnersData(data.FilingTransId, data.FilingEntId, data.FlngEntName,
                data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.FlngEntStrName,
                data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.FlngEntZip4, data.OrgAmt, data.TransExplanation,"","","","","","",
                "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateSchedDPartnersData_UnitTest

        #region DeleteSchedDPartnersData_UnitTest
        /// <summary>
        /// DeleteSchedDPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteSchedDPartnersData_UnitTest()
        {
            var controller = new ContributionInKindController();

            String strFilingTransId = "";            

            var results = controller.DeleteSchedDPartnersData(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteSchedDPartnersData_UnitTest

        #region GetSchedDPartnersData_UnitTest
        /// <summary>
        /// GetSchedDPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetSchedDPartnersData_UnitTest()
        {
            String strFilingTransId = "";

            var controller = new ContributionInKindController();

            JsonResult results = controller.GetSchedDPartnersData(strFilingTransId,"") as JsonResult;

            IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = results.Data as List<ContrInKindPartnersModel>;

            Assert.IsTrue(lstContrInKindPartnersModel.Count >= 1);

        }
        #endregion GetSchedDPartnersData_UnitTest

        #region GetPartnershipTotAmt_UnitTest
        /// <summary>
        /// GetPartnershipTotAmt_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPartnershipTotAmt_UnitTest()
        {
            var controller = new ContributionInKindController();

            String strFilingTransId = "";

            var results = controller.GetPartnershipTotAmt(strFilingTransId);

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetPartnershipTotAmt_UnitTest

        #region GetPaymentMethodData_UnitTest
        /// <summary>
        /// GetPaymentMethodData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPaymentMethodData_UnitTest()
        {
            var controller = new ContributionInKindController();

            var results = controller.GetPaymentMethodData();

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetPaymentMethodData_UnitTest

        #region GetContributionNameData_UnitTest
        /// <summary>
        /// GetContributionNameData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributionNameData_UnitTest()
        {
            var controller = new ContributionInKindController();

            var results = controller.GetContributionNameData();

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetContributionNameData_UnitTest

        #region GetContributionTypeData_UnitTest
        /// <summary>
        /// GetContributionTypeData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributionTypeData_UnitTest()
        {
            var controller = new ContributionInKindController();

            var results = controller.GetContributionTypeData();

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetContributionTypeData_UnitTest

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
