using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using CAPASFIDAS_EFS.Controllers;
using Models;
using System.Collections.Generic;

namespace CAPASFIDAS_EFS_UnitTest
{
    [TestClass]
    public class NonItemizedIEWeeklyPIDAExpTransSchedFUT
    {        
        public NonItemizedIEWeeklyPIDAExpTransSchedFUT()
        {
            //
            // TO DO;
            //
        }

        #region NonItemIEWeeklyExpenditureSchedF_UnitTest
        /// <summary>
        /// NonItemIEWeeklyExpenditureSchedF_UnitTest
        /// </summary>
        [TestMethod]
        public void NonItemIEWeeklyExpenditureSchedF_UnitTest()
        {
            var controller = new NonItemIEWeeklyPIDAExpenditureSchedFController();

            var result = controller.NonItemIEWeeklyPIDAExpenditureSchedF() as ViewResult;

            Assert.AreEqual("NonItemIEWeeklyPIDAExpenditureSchedF", result.ViewName.ToString());
        }
        #endregion NonItemIEWeeklyExpenditureSchedF_UnitTest

        #region SaveNonItemIEWeeklyContrSchedFData_UnitTest
        /// <summary>
        /// SaveNonItemIEWeeklyContrSchedFData_UnitTest
        /// </summary>
        [TestMethod]
        public void SaveNonItemIEWeeklyContrSchedFData_UnitTest()
        {
            var controller = new NonItemIEWeeklyPIDAExpenditureSchedFController();

            FilingTransactionsModel data = new FilingTransactionsModel
            {
                PersonId = "",
                AddrId = "",
                TreasId = "",
                FilingEntId = "",
                FilerId = "",
                ElectionDate = "",
                ElectionDateId = "",
                ElectionTypeId = "",
                ElectYearId = "",
                OfficeTypeId = "",
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
                PaymentTypeId = "",
                PayNumber = "",
                TransExplanation = "",
                TreasurerOccupation = "",
                TreasurerEmployer = "",
                TreasurerStreetAddress = "",
                TreasurerCity = "",
                TreasurerState = "",
                TreasurerZip = "",
                ContributorOccupation = "",
                ContributorEmployer = "",
                IEDescription = "",
                CandBallotPropReference = "",
                R_Supported = "",
                CreatedBy = "SBasireddy" // Testing Only...
            };

            var results = controller.SaveNonItemIEWeeklyContrSchedFData(data.FilerId, data.ElectionYear, data.ElectYearId, data.OfficeTypeId, data.ElectionTypeId, data.ElectionDate, data.ElectionDateId, data.FilingSchedId, data.SchedDate, data.ContributorTypeId, data.FlngEntName, data.FlngEntFirstName, data.FlngEntMiddleName, data.FlngEntLastName, data.FlngEntCountry, data.TreasurerStreetAddress, data.FlngEntCity, data.FlngEntState, data.FlngEntZip, data.PaymentTypeId, data.PayNumber, data.OrgAmt, data.TransExplanation, data.TreasurerOccupation, data.TreasurerEmployer, data.TreasurerStreetAddress, data.TreasurerCity, data.TreasurerState, data.TreasurerZip, data.ContributorOccupation, data.ContributorEmployer, data.IEDescription, data.CandBallotPropReference, data.R_Supported, "", "", "", "");

            Assert.AreEqual("true", results.ToString());
        }
        #endregion SaveNonItemIEWeeklyContrSchedFData_UnitTest

    }
}
