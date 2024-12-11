// Creighton Newsom
// ViewAllDisclosures Page

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class ViewAllDisclosuresUT: Controller
    {
        #region "ViewAllDisclosures"
        //[TestMethod]
        public void ViewAllDisclosures()
        {
            //Arrange
            var controller = new ViewAllDisclosuresController(); 
            //Act
            var result = controller.ViewAllDisclosures() as ViewResult;
            //Assert
            Assert.AreEqual("ViewAllDisclosures", result.ViewName.ToString());
        }
        #endregion

        #region "GetOfficeTypeData_UnitTest"
        [TestMethod]
        public void GetOfficeTypeData_UnitTest()
        {

            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetOfficeTypeData("85");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetElectionTypeDataForFilerID_UnitTest"
        [TestMethod]
        public void GetElectionTypeDataForFilerID_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetElectionTypeData("85", "1", "", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetElectionDateData_UnitTest"
        [TestMethod]
        public void GetElectionDataData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetElectionDateData("85", "1", "1","","");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetCountyData_UnitTest"
        [TestMethod]
        public void GetCountyData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetCountyData("1");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetMunicipalityData_UnitTest"
        [TestMethod]
        public void GetMunicipalityData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetMunicipalityData("1");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        //#region "GetDisclosurePeriods_UnitTest"
        //[TestMethod]
        //public void GetDisclosurePeriods_UnitTest()
        //{
        //    var controller = new ViewAllDisclosuresController();
        //    JsonResult results = controller.GetDisclosurePeriods("2", "1");
        //    dynamic data = results.Data;
        //    Assert.IsNotNull(data);
        //}
        //#endregion

        #region "GetDisclosureTypes_UnitTest"
        //[TestMethod]
        //public void GetDisclosureTypes_UnitTest()
        //{
        //    var controller = new ViewAllDisclosuresController();
        //    JsonResult results = controller.GetDisclosureTypes("34", "2");
        //    dynamic data = results.Data;
        //    Assert.IsNotNull(data);
        //}
        #endregion

        #region "GetDisclosureGridData_UnitTest"
        [TestMethod]
        public void GetDisclosureGridData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetDisclosuresGridData("113070", "85", "", "", "", "", "", "", "", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetTransactionGridData_UnitTest"
        [TestMethod]
        public void GetTransactionGridData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetTransactionsGridData("790473", "20979", "", "A", "", "", "", "", "", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetSupportingDocumentsGridData_UnitTest"
        [TestMethod]
        public void GetSupportingDocumentsGridData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetSupportingDocumentsGridData("4210041","");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "InsertSupportingDocuments_UnitTest"
        [TestMethod]
        public void InsertSupportingDocuments_UnitTest()
        {
            //var controller = new ViewAllDisclosuresController();
            //String answer = controller.InsertSupportingDocument("E424F479-DD2E-461C-A9B6-CC8E60781A5A", "2");
            //Assert.AreEqual("1", answer);
        }
        #endregion

        #region "DeleteSupportingDocument_UnitTest"
        [TestMethod]
        public void DeleteSupportingDocument_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.DeleteSupportingDocument("118");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "DeleteDisclosure_UnitTest"
        [TestMethod]
        public void DeleteDisclosure_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.DeleteDisclosure("790485", "False", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetPIDAGridData_UnitTest"
        [TestMethod]
        public void GetPIDAGridData_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.GetPIDAGridData("18862D85-0876-4B87-9FD4-536B7F6863B8");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "InsertSupportingDocumentPIDA_UnitTest"
        [TestMethod]
        public void InsertSupportingDocumentPIDA_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.InsertSupportingDocumentPIDA("18862D85-0876-4B87-9FD4-536B7F6863B8", "1", "08/26/1969", "comments", "4321", "432");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "UpdateSupportingDocumentPIDA_UnitTest"
        [TestMethod]
        public void UpdateSupportingDocumentPIDA_UnitTest()
        {
            var controller = new ViewAllDisclosuresController();
            JsonResult results = controller.UpdateSupportingDocumentPIDA("1915", "1", "08/26/1969", "comments");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion
        
    }
}
