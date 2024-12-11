using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    /// <summary>
    /// Summary description for ContributionCandIndFamilySchedABCUT
    /// </summary>
    [TestClass]
    public class ContributionCandIndFamilySchedABCUT
    {
        public ContributionCandIndFamilySchedABCUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }        

        #region ContributionsCandIndFamily_UnitTest
        /// <summary>
        /// /ContributionsCandIndFamily_UnitTest
        /// </summary>
        [TestMethod]
        public void ContributionsCandIndFamily_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();
            FormCollection formCollection = null;
            var result = controller.ContributionsCandIndFamily(formCollection, "") as ViewResult;

            Assert.AreEqual("ContributionsCandIndFamily", result.ViewName.ToString());
        }
        #endregion ContributionsCandIndFamily_UnitTest

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

        #region AutoCompleteFirstName_UnitTest
        /// <summary>
        /// AutoCompleteFirstName_UnitTest
        /// </summary>
        [TestMethod]
        public void AutoCompleteFirstName_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

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
            var controller = new ContributionsCandIndFamilyController();

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
            var controller = new ContributionsCandIndFamilyController();

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
            var controller = new ContributionsCandIndFamilyController();

            String strValue = "";

            var results = controller.GetAutoCompleteNameData(strValue);

            IList<AutoCompFLNameAddressModel> data = results.Data as List<AutoCompFLNameAddressModel>;

            Assert.IsTrue(data.Count >= 1);
        }
        #endregion GetAutoCompleteNameData_UnitTest

        #region DeleteFilingTransactionsSchedABC_UnitTest
        /// <summary>
        /// DeleteFilingTransactionsSchedABC_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteFilingTransactionsSchedABC_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            String strLoanLiabNumberOrg = "";
            String strTransNumber = "";
            String strRLiability = "";

            var results = controller.DeleteFilingTransactions(strLoanLiabNumberOrg, strTransNumber, strRLiability);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteFilingTransactionsSchedABC_UnitTest

        #region SaveFilingTransContrMonetaryData_UnitTest
        /// <summary>
        /// SaveFilingTransContrMonetaryData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveFilingTransContrMonetaryData_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilerId = "",
                FilingEntId = "",
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
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                OrgAmt = "",
                ContributorTypeId = "",
                PaymentTypeId = "",
                PayNumber = "",
                TransExplanation = "",
                RItemized = "",
                FlngEntCountry = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveFilingTransContrMonetaryData(data.FilerId, data.ElectionYear,
                data.ElectYearId, data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate, data.FilingSchedId,
                data.SchedDate, data.ContributionTypeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName,
                data.FlngEntStrName, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber,
                data.OrgAmt, data.TransExplanation, data.RItemized, data.FlngEntCountry, "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());

        }
        #endregion SaveFilingTransContrMonetaryData_UnitTest

        #region UpdateFlngTransMonetaryContrData_UnitTest
        /// <summary>
        /// UpdateFlngTransMonetaryContrData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateFlngTransMonetaryContrData_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingTransId = "",
                FilingEntId = "",
                ContributorTypeId = "",
                SchedDate = "",
                PayNumber = "",
                PaymentTypeId = "",
                OrgAmt = "",
                TransExplanation = "",
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntMiddleName = "",
                FlngEntLastName = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                FlngEntCountry = "",
                ModifiedBy = "SBasireddy"
            };

            var results = controller.UpdateFlngTransMonetaryContrData(data.FilingTransId, data.FilingEntId,
                data.ContributionTypeId, data.SchedDate, data.PayNumber, data.PaymentTypeId, data.OrgAmt, data.TransExplanation,
                data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntStrName,
                data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.FlngEntCountry, "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "", "","");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateFlngTransMonetaryContrData_UnitTest

        #region GetSchedAPartnersData_UnitTest
        /// <summary>
        /// GetSchedAPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetSchedAPartnersData_UnitTest()
        {
            String strFilingTransId = "";            

            var controller = new ContributionsCandIndFamilyController();

            JsonResult results = controller.GetSchedAPartnersData(strFilingTransId, "") as JsonResult;

            IList<ContrInKindPartnersModel> lstContrInKindPartnersModel = results.Data as List<ContrInKindPartnersModel>;

            Assert.IsTrue(lstContrInKindPartnersModel.Count >= 1);

        }
        #endregion GetSchedAPartnersData_UnitTest

        #region SaveSchedAPartnersData_UnitTest
        /// <summary>
        /// SaveSchedAPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveSchedAPartnersData_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

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
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveSchedAPartnersData(data.FilingTransId, data.FilingSchedId, data.SchedDate, data.FilerId,
                data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.FilingTypeId, data.ElectionTypeId, data.ElectionDate,
                data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntStrName,
                data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.OrgAmt, data.TransExplanation, data.RItemized, data.FlngEntCountry, "", "", "", "", "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());

        }
        #endregion SaveSchedAPartnersData_UnitTest

        #region UpdateSchedAPartnersData_UnitTest
        /// <summary>
        /// UpdateSchedAPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void UpdateSchedAPartnersData_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                FilingTransId = "",
                FilingEntId = "",
                FlngEntName = "",
                FlngEntFirstName = "",
                FlngEntMiddleName = "",
                FlngEntLastName = "",
                FlngEntStrName = "",
                FlngEntCity = "",
                FlngEntState = "",
                FlngEntZip = "",
                OrgAmt = "",
                TransExplanation = "",
                FlngEntCountry = "",
                ModifiedBy = "SBasireddy"
            };

            var results = controller.UpdateSchedAPartnersData(data.FilingTransId, data.FilingEntId, data.FlngEntName,
                data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntStrName, data.FlngEntCity,
                data.FlngEntState, data.FlngEntZip, data.OrgAmt, data.TransExplanation, data.FlngEntCountry, "", "", "", "", "", "", "", "", "", "", "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion UpdateSchedAPartnersData_UnitTest

        #region DeleteSchedAPartnersData_UnitTest
        /// <summary>
        /// DeleteSchedAPartnersData_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteSchedAPartnersData_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            String strFilingTransId = "";
            String strFilingTransMapping = "";

            var results = controller.DeleteSchedAPartnersData(strFilingTransId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteSchedAPartnersData_UnitTest

        #region GetContributorTypeCodeSchedC_UnitTest
        /// <summary>
        /// GetContributorTypeCodeSchedC_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorTypeCodeSchedC_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            JsonResult results = controller.GetContributorTypeCodeSchedC() as JsonResult;

            IList<ContributorNameModel> lstContributorNameModel = results.Data as IList<ContributorNameModel>;            

            //dynamic data = results.Data;

            //Assert.IsNotNull("test");

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorTypeCodeSchedC_UnitTest

        #region GetContributorCodeSchedA_UnitTest
        /// <summary>
        /// GetContributorCodeSchedA_UnitTest
        /// </summary>
        [TestMethod]
        public void GetContributorCodeSchedA_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            IList<ContributorNameModel> lstContributorNameModel = new List<ContributorNameModel>();


            var results = controller.GetContributorCodeSchedA() as JsonResult;


            SelectList list = results.Data as SelectList;                    
                                   
            lstContributorNameModel = (IList<ContributorNameModel>)results.Data;

            Assert.IsTrue(lstContributorNameModel.Count >= 1);
        }
        #endregion GetContributorCodeSchedA_UnitTest

        #region GetPartnershipTotAmt_UnitTest
        /// <summary>
        /// GetPartnershipTotAmt_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPartnershipTotAmt_UnitTest()
        {
            var controller = new ContributionsCandIndFamilyController();

            String strFilingTransId = "";

            var results = controller.GetPartnershipTotAmt(strFilingTransId);

            Assert.IsTrue(results.ToString() != null);
        }
        #endregion GetPartnershipTotAmt_UnitTest




    }
}
