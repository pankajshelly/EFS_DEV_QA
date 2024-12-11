using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NoticeOfNonParticipationUnitTest
    {
        #region NoticeOfNonParticipation_UnitTest
        /// <summary>
        /// NoticeOfNonParticipation_UnitTest
        /// </summary>
        [TestMethod]
        public void NoticeOfNonParticipation_UnitTest()
        {
            var controller = new NoticeOfNonParticipationController();

            var result = controller.NoticeOfNonParticipation() as ViewResult;

            Assert.AreEqual("NoticeOfNonParticipation", result.ViewName.ToString());
        }
        #endregion NoticeOfNonParticipation_UnitTest

        #region GetNonParticipation_UnitTest
        /// <summary>
        /// GetNonParticipation_UnitTest
        /// </summary>
        [TestMethod]
        public void GetNonParticipation_UnitTest()
        {
            String txtFilerID = "113072";
            String lstElectionDate = "09/09/2014";
            String lstElectionCycle = "";
            String lstElectionType = "";
            String strElectionYear = "";
            String lstUCOfficeType = "";
            String lstDisclosurePeriod = "";

            var controller = new NoticeOfNonParticipationController();

            JsonResult results = controller.GetNonParticipation(txtFilerID,
                lstElectionDate, lstElectionCycle, lstElectionType, strElectionYear, lstUCOfficeType, lstDisclosurePeriod,"","") as JsonResult;

            IList<InLieuOfStatementNonItemModel> lstInLieuOfStatementNonItemModel = results.Data as List<InLieuOfStatementNonItemModel>;

            Assert.IsTrue(lstInLieuOfStatementNonItemModel.Count >= 1);

        }
        #endregion GetNonParticipation_UnitTest

        #region AddNonParticipationData_UnitTest
        /// <summary>
        /// AddNonParticipationData_UnitTest
        /// </summary>
        [TestMethod]
        public void AddNonParticipationData_UnitTest()
        {
            var controller = new NoticeOfNonParticipationController();

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

            var results = controller.AddNonParticipationData(data.FilerId, data.ElectionDate,
                data.ElectionTypeId, data.OfficeTypeId, data.FilingTypeId, data.FilingCategoryId,
                data.ElectYearId, data.ElectionYear, data.CountyId, data.MunicipalityId, "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion AddNonParticipationData_UnitTest

        #region GetPersonNameTreasureYN_UnitTest
        /// <summary>
        /// GetPersonNameTreasureYN_UnitTest
        /// </summary>
        [TestMethod]
        public void GetPersonNameTreasureYN_UnitTest()
        {
            var controller = new NoticeOfNonParticipationController();

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
