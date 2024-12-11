// Creighton Newsom
// ViewSupportingDocuments Page

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class ViewSupportingDocumentsUT: Controller
    {
        #region "ViewSupportingDocuments"
        //[TestMethod]
        public void ViewSupportingDocuments()
        {
            //Arrange
            var controller = new ViewSupportingDocumentsController(); 
            //Act
            var result = controller.ViewSupportingDocuments() as ViewResult;
            //Assert
            Assert.AreEqual("ViewSupportingDocuments", result.ViewName.ToString());
        }
        #endregion

        #region "GetDisclosurePeriodsForYearAndFilerID_UnitTest"
        [TestMethod]
        public void GetDisclosurePeriodsForYearAndFilerID_UnitTest()
        {
            var controller = new ViewSupportingDocumentsController();
            JsonResult results = controller.GetDisclosurePeriodsForYearAndFilerID("113070", "34");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion

        #region "GetSupportingDocumentsGridData_UnitTest"
        [TestMethod]
        public void GetSupportingDocumentsGridData_UnitTest()
        {
            var controller = new ViewSupportingDocumentsController();
            JsonResult results = controller.ViewSupportingDocumentsGridData("113070", "34", "");
            dynamic data = results.Data;
            Assert.IsNotNull(data);
        }
        #endregion


    }
}
