using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NoActivityReportUnitTest
    {
        #region NoActivityReport_UniteTest
        /// <summary>
        /// NoActivityReport_UniteTest
        /// </summary>
        [TestMethod]
        public void NoActivityReport_UniteTest()
        {
            var controller = new NoActivityReportController();

            var result = controller.NoActivityReport() as ViewResult;

            Assert.AreEqual("NoActivityReport", result.ViewName.ToString());
        }
        #endregion NoActivityReport_UniteTest

        #region GetNoActivityReport_UnitTest
        /// <summary>
        /// GetNoActivityReport_UnitTest
        /// </summary>
        [TestMethod]
        public void GetNoActivityReport_UnitTest()
        {
            String txtFilerID = "113072";
            String lstElectionDate = "09/09/2014";
            String lstElectionCycle = "";
            String lstElectionType = "";
            String strElectionYear = "";
            String lstUCOfficeType = "";
            String lstDisclosurePeriod = "";

            var controller = new NoActivityReportController();

            JsonResult results = controller.GetNoActivityReport(txtFilerID,
                lstElectionDate, lstElectionCycle, lstElectionType, strElectionYear, lstUCOfficeType, lstDisclosurePeriod, "", "", "") as JsonResult;

            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = results.Data as List<InLieuOfStatementNonItemModel>;

            Assert.IsTrue(lstInLieuOfStatementNonItemModel.Count >= 1);
        }
        #endregion GetNoActivityReport_UnitTest

        #region AddNoActivityReportData_UnitTest
        /// <summary>
        /// AddNoActivityReportData_UnitTest
        /// </summary>
        [TestMethod]
        public void AddNoActivityReportData_UnitTest()
        {
            var controller = new NoActivityReportController();

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

            var results = controller.AddNoActivityReportData(data.FilerId, data.ElectionDate,
                data.ElectionTypeId, data.OfficeTypeId, data.FilingTypeId, data.FilingCategoryId,
                data.ElectYearId, data.ElectionYear, data.CountyId, data.MunicipalityId, "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion AddNoActivityReportData_UnitTest

        #region GetPersonNameTreasureYN_UnitTest
        /// <summary>
        /// GetPersonNameTreasureYN_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPersonNameTreasureYN_UnitTest()
        {                   
            var controller = new NoActivityReportController();

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

            var controller = new NoActivityReportController();

            var results = controller.GetItemizedSubmitted(strFilerId, strElectionYearId, strOfficeTypeId, strFilingTypeId,"1","");

            Assert.AreEqual("true", results.ToString());            
        }
        #endregion GetItemizedSubmitted_UnitTest
    }
}
