using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;
using System.Web;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedCampaignMaterialUT
    {
        public NonItemizedCampaignMaterialUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region NonItemCampaignMaterial_UnitTest
        /// <summary>
        /// NonItemCampaignMaterial_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemCampaignMaterial_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();

            var result = controller.NonItemCampaignMaterial() as ViewResult;

            Assert.AreEqual("NonItemCampaignMaterial", result.ViewName.ToString());
        }
        #endregion NonItemCampaignMaterial_UnitTest

        #region GetCampaignMaterialData_UnitTest
        /// <summary>
        /// GetCampaignMaterialData_UnitTest
        /// </summary>
        [TestMethod]
        public void GetCampaignMaterialData_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();

            String txtFilerID = "";
            String lstElectionCycle = "";
            String lstElectionYear = "";
            String lstUCOfficeType = "";
            String lstElectionType = "";
            String lstElectionDate = "";
            String lstDisclosurePeriod = "";
            String strDisclosurePeriodDesc = "";

            var results = controller.GetCampaignMaterialData(txtFilerID, lstElectionCycle, lstElectionYear, lstUCOfficeType, lstElectionType, lstElectionDate, lstDisclosurePeriod, strDisclosurePeriodDesc, "", "", "", "") as JsonResult;

            IList<NonItemCampaignMaterialDataModel> lstCampaignMaterialModelResults = results.Data as List<NonItemCampaignMaterialDataModel>;

            Assert.IsTrue(lstCampaignMaterialModelResults.Count >= 1);
        }
        #endregion GetCampaignMaterialData_UnitTest

        #region SaveNonItemCampMaterialData_UnitTest
        /// <summary>
        /// SaveNonItemCampMaterialData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemCampMaterialData_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();

            String txtFilerID = "";
            String lstElectionCycle = "";
            String lstElectionCycleId = "";
            String lstUCOfficeType = "";
            String lstElectionType = "";
            String lstElectionDate = "";
            String lstElectionDateId = "";
            String lstDisclosurePeriod = "";
            String lstDisclosureType = "";
            String txtDateSubmittedCampMater = "";
            String txtDescription = "";
            String txtFileUpload = "";
            String strCampMatrYN = "";

            var results = controller.SaveNonItemCampMaterialData(txtFilerID, lstElectionCycle, lstElectionCycleId, lstUCOfficeType, lstElectionType, lstElectionDate, lstElectionDateId, lstDisclosureType, lstDisclosurePeriod, txtDateSubmittedCampMater, txtDescription, txtFileUpload, strCampMatrYN, "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemCampMaterialData_UnitTest

        #region DeleteNonItemCampMaterialData_UnitTest
        /// <summary>
        /// DeleteNonItemCampMaterialData_UnitTest
        /// </summary>
        [TestMethod]
        public void DeleteNonItemCampMaterialData_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();

            String strCampaignMaterialId = "";

            var results = controller.DeleteNonItemCampMaterialData(strCampaignMaterialId);

            Assert.AreEqual("true", results.ToString());
        }
        #endregion DeleteNonItemCampMaterialData_UnitTest                

        #region UploadCampaignMaterialData_UnitTest
        /// <summary>
        /// UploadCampaignMaterialData_UnitTest
        /// </summary>
        [TestMethod]
        public void UploadCampaignMaterialData_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();

            HttpPostedFileBase data = null;
                         
            var results = controller.UploadCampaignMaterialData(data) as JsonResult;

            CabinetReturnValModel objCabinetReturnValModel = results.Data as CabinetReturnValModel;

            Assert.IsTrue(objCabinetReturnValModel.DocumentID != "");
        }
        #endregion UploadCampaignMaterialData_UnitTest

        #region DownloadCampaignMaterial_UnitTest
        /// <summary>
        /// DownloadCampaignMaterial_UnitTest
        /// </summary>
        [TestMethod]
        public void DownloadCampaignMaterial_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();

            String documentID = "";

            //var results = controller.DownloadCampaignMaterial(documentID) as JsonResult;
            controller.DownloadCampaignMaterial(documentID);

            //CabinetDownloadObjectModel objCabinetDownloadObjectModel = results.Data as CabinetDownloadObjectModel;

            //Assert.IsTrue(objCabinetDownloadObjectModel.FileByte != null);
        }
        #endregion DownloadCampaignMaterial_UnitTest

        #region DownloadCampaignMaterialNTDrive_UnitTest
        /// <summary>
        /// DownloadCampaignMaterialNTDrive_UnitTest
        /// </summary>
        [TestMethod]
        public void DownloadCampaignMaterialNTDrive_UnitTest()
        {
            var controller = new NonItemCampaignMaterialController();
            
            var results = controller.DownloadCampaignMaterialNTDrive() as FileResult;                        

            Assert.IsTrue(results != null);
        }
        #endregion DownloadCampaignMaterialNTDrive_UnitTest

    }
}
