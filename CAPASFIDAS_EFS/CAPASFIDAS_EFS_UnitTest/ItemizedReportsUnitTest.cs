using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;

namespace CAPASFIDAS_EFS_UnitTest.Controllers
{
    /// <summary>
    /// Summary description for ItemizedReportsUnitTest
    /// </summary>
    [TestClass]
    public class ItemizedReportsUnitTest
    {
        public ItemizedReportsUnitTest()
        {            
            //Session["PersonId"] = "4929"; //"23161";
            //Session["FilerId"] = "113070"; // Testing only replace with main Session (Login).
        }

        private String _filerId;
        private String _electionCycle;
        private String _OfficeType;
        private String _disclosurePeriod;
        public String FilerId { get { return _filerId; } set { _filerId = "113070"; } }
        public String ElectionCycle { get { return _electionCycle; } set { _electionCycle = "16"; } }
        public String OfficeType { get { return _OfficeType; } set { _OfficeType = "1"; } }
        public String DisclosurePeriod { get { return _disclosurePeriod; } set { _disclosurePeriod = "1"; } } 

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

      

        [TestMethod]
        public void ExpenditurePaymentsSchedF_Test()
        {
            var controller = new ExpenditurePaymentsSchedFController();                       
            
            var result = controller.ExpenditurePaymentsSchedF() as ViewResult;

            Assert.AreEqual("ExpenditurePaymentsSchedF", result.ViewName.ToString());
        }

        [TestMethod]
        public void GetAllTransactionTypesData_Test()
        {
            var controller = new ExpenditurePaymentsSchedFController();

            //var results = controller.GetAllTransactionTypesData(FilerId, ElectionCycle, OfficeType, DisclosurePeriod) as JsonResult;

        }
    }
}
