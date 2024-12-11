using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class InLieuOfStatementUnitTest
    {
        #region InLieuOfStatement_UnitTest
        /// <summary>
        /// InLieuOfStatement_UnitTest
        /// </summary>
        [TestMethod]
        public void InLieuOfStatement_UnitTest()
        {
            var controller = new InLieuOfStatementController();

            var result = controller.InLieuOfStatement() as ViewResult;

            Assert.AreEqual("InLieuOfStatement", result.ViewName.ToString());
        }
        #endregion InLieuOfStatement_UnitTest

        #region GetInLieuOfStatement_UnitTest
        /// <summary>
        /// GetInLieuOfStatement_UnitTest
        /// </summary>
        [TestMethod]
        public void GetInLieuOfStatement_UnitTest()
        {                  
            String txtFilerID = "113072";
            String lstElectionDate = "09/09/2014";
            String lstElectionCycle = "";
            String lstElectionType = "";
            String strElectionYear = "";
            String lstUCOfficeType = "";
            String lstDisclosurePeriod = "";

            var controller = new InLieuOfStatementController();

            JsonResult results = controller.GetInLieuOfStatement(txtFilerID,
                lstElectionDate, lstElectionCycle, lstElectionType, strElectionYear, lstUCOfficeType, lstDisclosurePeriod, "", "") as JsonResult;

            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = results.Data as List<InLieuOfStatementNonItemModel>;

            Assert.IsTrue(lstInLieuOfStatementNonItemModel.Count >= 1);

        }
        #endregion GetInLieuOfStatement_UnitTest

        #region AddInLieuOfStatementData_UnitTest
        /// <summary>
        /// AddInLieuOfStatementData_UnitTest
        /// </summary>
        [TestMethod]
        public void AddInLieuOfStatementData_UnitTest()
        {
            var controller = new InLieuOfStatementController();

            AddInLieuOfStatementModel data = new AddInLieuOfStatementModel
            {
                FilerId = "",
                ElectionDate = "",
                ElectionTypeId = "",
                OfficeTypeId = "",
                FilingTypeId = "",
                FilingCategoryId = "",
                ElectYearId = "",
                ElectionYear = "",
                CountyId = "",
                MunicipalityId = "",
                CreatedBy = "SBasireddy" // Testing Only....
            };

            var results = controller.AddInLieuOfStatementData(data.FilerId, data.ElectionDate,
                data.ElectionTypeId, data.OfficeTypeId, data.FilingTypeId, data.FilingCategoryId,
                data.ElectYearId, data.ElectionYear, data.CountyId, data.MunicipalityId, "", "", "");

            Assert.AreEqual("true", results.ToString());

        }
        #endregion AddInLieuOfStatementData_UnitTest

        #region DeleteInLieuOfStatementData_UnitTest
        /// <summary>
        /// DeleteInLieuOfStatementData_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteInLieuOfStatementData_UnitTest()
        {
            var controller = new InLieuOfStatementController();

            String strFilingsId = "";

            var results = controller.DeleteInLieuOfStatementData(strFilingsId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteInLieuOfStatementData_UnitTest

        #region GetPersonNameTreasureYN_UnitTest
        /// <summary>
        /// GetPersonNameTreasureYN_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPersonNameTreasureYN_UnitTest()
        {
            var controller = new InLieuOfStatementController();

            var results = controller.GetPersonNameTreasureYN();

            IList<PersonNameAndTreasurerDataModel> lstPersonNameAndTreasurerDataModel = results.Data as List<PersonNameAndTreasurerDataModel>;

            Assert.IsTrue(lstPersonNameAndTreasurerDataModel.Count >= 1);
        }
        #endregion GetPersonNameTreasureYN_UnitTest

        #region GetItemizedSubmitted_UnitTest
        /// <summary>
        /// GetItemizedSubmitted_UnitTest
        /// </summary>
        [TestMethod]
        public void GetItemizedSubmitted_UnitTest()
        {
            String strFilerId = "";
            String strElectionYearId = "";
            String strOfficeTypeId = "";
            String strFilingTypeId = "";

            var controller = new InLieuOfStatementController();

            var results = controller.GetItemizedSubmitted(strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId,"1","");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion GetItemizedSubmitted_UnitTest

    }
}
