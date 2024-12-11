// Creighton Newsom
// LoanAndLiabilityReconciliation Page
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Broker;
using CAPASFIDAS_EFS.CommonErrors;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class LoanAndLiabilityReconciliationController : Controller
    {
        // CREATE BROKER OBJECTS
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        LoanAndLiabilityReconciliationBroker objLoanAndLiabilityReconciliatioBroker = new LoanAndLiabilityReconciliationBroker();  

        // CREATE COMMON ERROR OBJECT
        CommonErrorsServerSide objCommonErrorsServerSide = new CommonErrorsServerSide();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();


        #region "LoanAndLiabilityReconciliation"
        // FUNCTION ASSIGNS TESTING VALUES TO SESSION VARIABLES
        // AND CALLS FUNCTION GetDefaultValues AND RETURNS VIEW
        public ActionResult LoanAndLiabilityReconciliation()
        {
            try
            {
                // COMMENTED WHILE TESTING UAT DATABASE HISTORICAL DATA.
                // UN-COMMENT IF ITS COMMENTED WHILE WORKING ON DEV DATBASE.

                if (Session["SAMLResponse"] == null)
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                else
                {
                    GetDefaultValues();
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }
        #endregion

        public JsonResult GetFilerIdData()
        {
            try
            {
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = new List<ValidateFilerInfoModel>();
                lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserName"].ToString());
                ViewBag.lstFilerID = Session["FilerID"].ToString();
                ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
                Session["AuthenticatedFilerID"] = lstValidateFilerInfo[0].FilerID.ToString();
                Session["AuthenticatedCommitteeName"] = lstValidateFilerInfo[0].Name.ToString();
                ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
                return Json(new SelectList(lstValidateFilerInfo, "FilerID", "FilerID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region "GetDefaultValues"
        // FUNCTION MAKES CALLS TO DATABASE AND POPULATES VIEWDATA ITEMS FOR VIEW
        public void GetDefaultValues()
        {
            IList<FilerCommitteeModel> lstFilerCommitteeModel = new List<FilerCommitteeModel>();
            lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["PersonId"].ToString());
            Session["PersonFilerId"] = lstFilerCommitteeModel;
            String strCommId = "";
            ViewBag.txtCommitteeName = Session["Cand_Comm_Name"].ToString();
            // Filer ID
            //if (Session["FILER_INFO"] != null)
            //{
            //    IList<FilerInfoModel> listFilerInfo = new List<FilerInfoModel>();
            //    listFilerInfo = (IList<FilerInfoModel>)Session["FILER_INFO"];
            //    ViewData["lstFilerID"] = new SelectList(listFilerInfo, "Filer_ID", "Filer_ID");
            //    ViewData["lstCommitteeName"] = new SelectList(listFilerInfo, "Cand_Comm_ID", "Cand_Comm_Name");
            //    Session["CommitteeDataInLieuOf"] = listFilerInfo;
            //    strCommId = listFilerInfo[0].Cand_Comm_ID.ToString();
            //}
            //else
            //{
            //    ViewData["lstFilerID"] = new SelectList(lstFilerCommitteeModel, "FilerId", "FilerId");
            //    String strFilerId = lstFilerCommitteeModel.Select(x => x.FilerId).First().ToString();
            //    lstFilerCommitteeModel = lstFilerCommitteeModel.Where(x => x.FilerId == strFilerId).ToList();
            //    strCommId = lstFilerCommitteeModel.Select(x => x.CommitteeId).FirstOrDefault().ToString();
            //    Session["CommitteeDataInLieuOf"] = lstFilerCommitteeModel;

            //    // Committee Name
            //    ViewData["lstCommitteeName"] = new SelectList(lstFilerCommitteeModel, "CommitteeId", "CommitteeName");
            //}

            ////////////////////// FILTER DROP DOWN LISTS ////////////////////////////
            // Loan/Liability
            var lstLoanLiability = new SelectList(new[]
                          {
                                            new {ID="0",Name="Loan"},
                                            new{ID="1",Name="Liability"},
                                        },

                           "ID", "Name", "Loan");
            ViewData["lstLoanLiability"] = lstLoanLiability;
            ViewBag.txtFilerType = Session["Office_Type_Desc"].ToString();
        }

        #endregion "GetDefaultValues"

        #region "GetLoanReceivedGridData"
        // FUNCTION GETS THE DATA FOR THE LOAN RECEIVED GRID
        public JsonResult GetLoanReceivedGridData()
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String FilerID = string.Empty;
                if (Session == null || Session["FilerID"] == null)
                    FilerID = "113070";
                else
                    FilerID = Session["FilerID"].ToString();

                IList<LoanReceivedGridModel> lstLoanReceivedGrid = new List<LoanReceivedGridModel>();
                lstLoanReceivedGrid = objLoanAndLiabilityReconciliatioBroker.GetLoanReceivedGridData(FilerID);

                return Json(new
                {
                    aaData = lstLoanReceivedGrid.Select(x => new[] {
                 x.FilingTransID,
                 x.TransNumber,
                 x.TransMapping,
                 "",
                 "",
                 x.TransactionDate,
                 x.EntityName,
                 x.Amount,
                 x.ElectionYear,
                 x.OfficeType,
                 x.ElectionType,
                 x.ElectionDate,
                 x.DisclosurePeriod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetLoanPaymentGridData"
        // FUNCTION GETS THE DATA FOR THE LOAN PAYMENT GRID
        public JsonResult GetLoanPaymentGridData(String strCorrespondingSchedN, String strOrgLoanDate)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String FilerID = string.Empty;
                if (Session == null || Session["FilerID"] == null)
                    FilerID = "113070";
                else
                    FilerID = Session["FilerID"].ToString();

                IList<LoanPaymentGridModel> lstLoanPaymentGrid = new List<LoanPaymentGridModel>();
                lstLoanPaymentGrid = objLoanAndLiabilityReconciliatioBroker.GetLoanPaymentGridData(FilerID);

                if (strCorrespondingSchedN == "")
                    Session["LoanPayments"] = lstLoanPaymentGrid;

                if (strOrgLoanDate != "")
                {
                    lstLoanPaymentGrid = lstLoanPaymentGrid.Where(x => x.OriginalLoanDate == strOrgLoanDate).ToList();
                }

                return Json(new
                {
                    aaData = lstLoanPaymentGrid.Select(x => new[] {
                 x.FilingTransID,
                 x.TransNumber,
                 x.TransMapping,
                 "",
                 "",
                 x.TransactionDate,
                 x.EntityName,
                 x.Amount,
                 x.OriginalLoanDate,
                 x.ElectionYear,
                 x.OfficeType,
                 x.ElectionType,
                 x.ElectionDate,
                 x.DisclosurePeriod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetOutstandingLiabilityGridData"
        // FUNCTION GETS THE DATA FOR THE OUTSTANDING LIABILITY GRID
        // IF DATATORETURN IS 0, THEN ALL RECORDS ARE RETURNED
        // IF DATATORETURN IS 1 THEN RECORDS WHERE ORG_AMT = OWED_AMT ARE RETURNED
        // IF DATATORETURN IS 2 THEN RECORDS WHERE ORG_AMT <> OWED_AMT ARE RETURNED	
        public JsonResult GetOutstandingLiabilityGridData(int dataToReturn, String strOriginalScheduleNTransID, String strLoan_OR_Payment)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String FilerID = string.Empty;
                if (Session == null || Session["FilerID"] == null)
                    FilerID = "113070";
                else
                    FilerID = Session["FilerID"].ToString();

                IList <OutstandingLiabilityGridModel> lstOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                lstOutStandingLiabilityGrid = objLoanAndLiabilityReconciliatioBroker.GetOutstandingLiabilityGridData(FilerID, dataToReturn);

                //////////////////////////////////////////////////////////
                IList<OutstandingLiabilityGridModel> lstAllOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                lstAllOutStandingLiabilityGrid = objLoanAndLiabilityReconciliatioBroker.GetOutstandingLiabilityGridData(FilerID, 3);
                Session["OutStandingLiabilities_3"] = lstAllOutStandingLiabilityGrid;
                //////////////////////////////////////////////////////////

                if (dataToReturn == 0 && strOriginalScheduleNTransID == "" && strLoan_OR_Payment == "")
                    Session["OutStandingLiabilities_0"] = lstOutStandingLiabilityGrid;

                if (strOriginalScheduleNTransID != "" && strLoan_OR_Payment == "LOAN")
                    lstOutStandingLiabilityGrid = GetOriginalScheduleNGridData(strOriginalScheduleNTransID);

                if (strOriginalScheduleNTransID != "" && (strLoan_OR_Payment == "PAYMENT" || strLoan_OR_Payment == "FORGIVEN"))
                    lstOutStandingLiabilityGrid = GetCorrespondingScheduleNGridData(strOriginalScheduleNTransID);


                return Json(new
                {
                    aaData = lstOutStandingLiabilityGrid.Select(x => new[] {
                 x.FilingTransID,
                 x.TransNumber,
                 x.TransMapping,
                 "",
                 "",
                 x.TransactionDate,
                 x.EntityName,
                 x.OriginalAmount,
                 x.OutstandingAmount,
                 x.ElectionYear,
                 x.OfficeType,
                 x.ElectionType,
                 x.ElectionDate,
                 x.DisclosurePeriod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetLiabilityLoanForgivenGridData"
        // FUNCTION GETS DATA FOR THE LIABILITY/LOAN FORGIVEN GRID
        public JsonResult GetLiabilityLoanForgivenGridData(String strReconcileMode)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String FilerID = string.Empty;
                if (Session == null || Session["FilerID"] == null)
                    FilerID = "113070";
                else
                    FilerID = Session["FilerID"].ToString();

                int dataToReturn = 0;
                if (strReconcileMode == "LOAN")
                    dataToReturn = 0;
                else
                    dataToReturn = 1;

                IList<LiabilityLoanForgivenGridModel> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridModel>();
                lstLiabilityLoanForgivenGrid = objLoanAndLiabilityReconciliatioBroker.GetLiabilityLoanFogivenGridData(FilerID, dataToReturn);

                return Json(new
                {
                    aaData = lstLiabilityLoanForgivenGrid.Select(x => new[] {
                 x.FilingTransID,
                 x.TransNumber,
                 x.TransMapping,
                 "",
                 "",
                 x.TransactionDate,
                 x.EntityName,
                 x.Amount,
                 x.OriginalDate,
                 x.ElectionYear,
                 x.OfficeType,
                 x.ElectionType,
                 x.ElectionDate,
                 x.DisclosurePeriod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetExpenditurePaymentGridData"
        // FUNCTION GETS DATA FOR THE EXPENDITURES/PAYMENTS GRID
        public JsonResult GetExpenditurePaymentGridData()
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                String FilerID = string.Empty;
                if (Session == null || Session["FilerID"] == null)
                    FilerID = "113070";
                else
                    FilerID = Session["FilerID"].ToString();

                IList<ExpenditurePaymentGridModel> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridModel>();
                lstExpenditurePaymentGrid = objLoanAndLiabilityReconciliatioBroker.GetExpenditurePaymentGridData(FilerID);

                return Json(new
                {
                    aaData = lstExpenditurePaymentGrid.Select(x => new[] {
                 x.FilingTransID,
                 x.TransNumber,
                 x.TransMapping,
                 "",
                 "",
                 x.TransactionDate,
                 x.EntityName,
                 x.Amount,
                 x.Explanation,
                 x.ElectionYear,
                 x.OfficeType,
                 x.ElectionType,
                 x.ElectionDate,
                 x.DisclosurePeriod
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "Reconcile_Loan"
        // PROCEDURE RECONCILES LOANS, PAYMENTS, OUTSTANDING LIABILITIES AND LOAN FORGIVENS
        public JsonResult Reconcile_Loan(String strSchedule_I_TransFilingID, string[] strSchedule_J_TransFilingIDs, string[] strSchedule_N_TransFilingIDs, string[] strSchedule_K_TransFilingIDs)
        {
            try
            {

                IList<OutstandingLiabilityGridModel> currentScheduleNTransIDs = new List<OutstandingLiabilityGridModel>();
                currentScheduleNTransIDs = (IList<OutstandingLiabilityGridModel>)Session["CurrentScheduleNTransIDs"];
                strSchedule_N_TransFilingIDs = currentScheduleNTransIDs.Select(x => x.FilingTransID).ToArray();

                // PERFORM THE SERVER SIDE VALIDATION. THE FUNCTION ENSURES THAT ALL 
                // THE TRANS_FILING_IDS PASSED IN ACTUALLY EXIST IN THE FILING_TRANSACTION TABLE
                // IF ANY DO NOT, THE FUNCTION RETURNS FALSE AND WE ADD AN ERROR TO MODELSTATE
                if (!objCommonErrorsServerSide.ValidateTransFilingIDs(strSchedule_I_TransFilingID, strSchedule_J_TransFilingIDs, strSchedule_N_TransFilingIDs, strSchedule_K_TransFilingIDs))
                    ModelState.AddModelError("FILING_TRANSACTIONS", "Invalid Trans Number");

                // FOR UNIT TESTS SESSION == NULL
                String User = string.Empty;
                if (Session["UserName"] == null)
                    User = "Admin";
                else
                    User = Session["UserName"].ToString();

                // IF THERE IS NO ERROR IN MODEL STATE, THEN WE CALL THE RECONCILE FUNCTION, OTHERWISE
                // WE RETURN ERROR CONDITION TO VIEW
                if (ModelState.IsValid)
                    return Json(objLoanAndLiabilityReconciliatioBroker.Reconcile_Loan(strSchedule_I_TransFilingID, strSchedule_J_TransFilingIDs, strSchedule_N_TransFilingIDs, strSchedule_K_TransFilingIDs, User));
                else
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "Reconcile_Liability"
        // PROCEDURE RECONCILES THE ORIGINAL LIABILITY WITH EXPENDITURES, OUTSTANDING
        // LIABILITIES AND LOANS FORGIVEN	
        public JsonResult Reconcile_Liability(String Schedule_N_OriginalLiability_TransFilingID, string[] strSchedule_F_TransFilingIDs, string[] strSchedule_N_TransFilingIDs, string[] strSchedule_K_TransFilingIDs)
        {
            try
            {
                // PERFORM THE SERVER SIDE VALIDATION. THE FUNCTION ENSURES THAT ALL 
                // THE TRANS_FILING_IDS PASSED IN ACTUALLY EXIST IN THE FILING_TRANSACTION TABLE
                // IF ANY DO NOT, THE FUNCTION RETURNS FALSE AND WE ADD AN ERROR TO MODELSTATE
                if (!objCommonErrorsServerSide.ValidateTransFilingIDs(Schedule_N_OriginalLiability_TransFilingID, strSchedule_F_TransFilingIDs, strSchedule_N_TransFilingIDs, strSchedule_K_TransFilingIDs))
                    ModelState.AddModelError("FILING_TRANSACTIONS", "Invalid Trans Number");

                // FOR UNIT TESTS SESSION == NULL
                String User = string.Empty;
                if (Session["UserName"] == null)
                    User = "Admin";
                else
                    User = Session["UserName"].ToString();

                // IF THERE IS NO ERROR IN MODEL STATE, THEN WE CALL THE RECONCILE FUNCTION, OTHERWISE
                // WE RETURN ERROR CONDITION TO VIEW
                if (ModelState.IsValid)
                    return Json(objLoanAndLiabilityReconciliatioBroker.Reconcile_Liability(Schedule_N_OriginalLiability_TransFilingID, strSchedule_F_TransFilingIDs, strSchedule_N_TransFilingIDs, strSchedule_K_TransFilingIDs, User));
                else
                    return Json(new { Errors = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetLoansAndLiabilities"
        // FUNCTION CALLS THE RELEVANT STORED PROCEDURES AND 
        // SUMS THE RESULTS TO RETURN TO THE CALLER
        private int GetLoansAndLiabilities()
        {
            // FOR UNIT TESTS SESSION == NULL
            String FilerID = string.Empty;
            FilerID = Session["FilerID"].ToString();            

            // GET THE LOANS
            IList<LoanPaymentGridModel> lstLoanPaymentGrid = new List<LoanPaymentGridModel>();
            lstLoanPaymentGrid = objLoanAndLiabilityReconciliatioBroker.GetLoanPaymentGridData(FilerID);
            int loanPaymentCount = lstLoanPaymentGrid.Count();

            // THE THE OUTSTANDING LIABILITIES FOR LOAN PAGE
            IList<OutstandingLiabilityGridModel> lstOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
            lstOutStandingLiabilityGrid = objLoanAndLiabilityReconciliatioBroker.GetOutstandingLiabilityGridData(FilerID, 0);
            int outstandingLiabilitiesForLoanPageCount = lstOutStandingLiabilityGrid.Count();

            // GET THE OUTSTANDING LIABILITIES FOR LIABILITES PAGE
            // commented out 5/7/2021 no longer considering liabilities
            //lstOutStandingLiabilityGrid = objLoanAndLiabilityReconciliatioBroker.GetOutstandingLiabilityGridData(FilerID, 2);
            //int outstandingLiabilitiesForLiabilityPageCount = lstOutStandingLiabilityGrid.Count();

            // EXPENDITURES EXCLUDED 10/7 PER DISCUSSION WITH HOPE
            // GET THE EXPENDITURES FOR LIABILITIES PAGE
            //IList<ExpenditurePaymentGridModel> lstExpenditurePaymentGrid = new List<ExpenditurePaymentGridModel>();
            //lstExpenditurePaymentGrid = objLoanAndLiabilityReconciliatioBroker.GetExpenditurePaymentGridData(FilerID);
            //int expenditurePaymentCount = lstExpenditurePaymentGrid.Count();

            // GET THE LIABILITIES/LOANS FORGIVEN (for loans)
            IList<LiabilityLoanForgivenGridModel> lstLiabilityLoanForgivenGrid = new List<LiabilityLoanForgivenGridModel>();
            lstLiabilityLoanForgivenGrid = objLoanAndLiabilityReconciliatioBroker.GetLiabilityLoanFogivenGridData(FilerID, 0);
            int liabilityLoanForgivenCount = lstLiabilityLoanForgivenGrid.Count();

            // GET THE LIABILITIES/LOANS FORGIVEN (for liabilities) 
            // commented out 5/7/2021 no longer considering liabilities
            //lstLiabilityLoanForgivenGrid = objLoanAndLiabilityReconciliatioBroker.GetLiabilityLoanFogivenGridData(FilerID, 1);
            //liabilityLoanForgivenCount += lstLiabilityLoanForgivenGrid.Count();

            // RETURN THE SUM
            return loanPaymentCount +
                   outstandingLiabilitiesForLoanPageCount +
                   // EXPENDITURES EXCLUDED 10/7 PER DISCUSSION WITH HOPE
                   //expenditurePaymentCount +
                   // commented out 5/7/2021 no longer considering liabilities
                   //outstandingLiabilitiesForLiabilityPageCount +
                   liabilityLoanForgivenCount;
        }
        #endregion

        #region "AreAllTransactionsReconciled"
        // FUNCTION CALLED BY VIEW TO DETERMINE IF THE TRANSACTIONS HAVE ALL BEEN RECONCILE
        public JsonResult AreAllTransactionsReconciled()
        {
            try
            {
                if (GetLoansAndLiabilities() == 0)
                    return Json("TRUE");
                return Json("FALSE");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                return Json("FALSE");
            }
        }
        #endregion

        #region "GetUnreconciledLoansOrLiabilities"
        // FUNCTION RETURNS THE NUMBER OF LOANS +
        // THE NUMBER OF LIABILITIES. IF THE RESULT IS 0 THEN THE 
        // RECONCILIATION PAGE DOESN'T NEED TO LOAD. IT WILL CALL 
        // UPDATEREQUIREDFILER METHOD AND THAT IS IT.
        //public JsonResult GetUncreconciledLoansAndLiabilities()
        public String GetUncreconciledLoansAndLiabilities(String strFilerID)
        {
            try
            {
                //return Json(objLoanAndLiabilityReconciliatioBroker.GetUncreconciledLoansAndLiabilities(strFilerID));
                return objLoanAndLiabilityReconciliatioBroker.GetUncreconciledLoansAndLiabilities(strFilerID);
                //return "0";// RETURN 0 TO BYPASS RECONCILIATION
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "UpdateRequiredFilerForReconcile"
        // THIS METHOD SIMPLY UPDATE THE R_RECONCILED AND MODIFIED_BY COLUMNS
        // IN THE REQUIRED_FILER TABLE. IT IS CALLED WHEN THERE ARE NO LOANS 
        // OR LIABILITIES OR WHEN THEY HAVE ALL BEEN RECONCILED
        //public JsonResult UpdateRequiredFilerForReconcile()
        public String UpdateRequiredFilerForReconcile(String strFilerID)
        {
            try
            {
                // FOR UNIT TESTS SESSION == NULL
                //String FilerID = string.Empty;
                //if (Session == null || Session["Filer_Id"] == null)
                //    FilerID = "113070";
                //else
                //    FilerID = Session["FilerId"].ToString();

                // FOR UNIT TESTS SESSION == NULL
                String User = string.Empty;
                if (Session["UserName"] == null)
                    User = "Admin";
                else
                    User = Session["UserName"].ToString();

                //return Json(objLoanAndLiabilityReconciliatioBroker.UpdateRequiredFilerForReconcile(FilerID, User));
                return objLoanAndLiabilityReconciliatioBroker.UpdateRequiredFilerForReconcile(strFilerID, User);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetOriginalScheduleNTransNumber"
        // FUNCTION CALLED BY VIEW TO DETERMINE IF THE TRANSACTIONS HAVE ALL BEEN RECONCILE
        public JsonResult GetOriginalScheduleNTransNumber(String strEntityName, String strOrgAmount, String strElectionYear, String strDisclosurePeriod, String strTransactionDate)
        {
            try
            {
                IList<OutstandingLiabilityGridModel> lstOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                lstOutStandingLiabilityGrid = (IList<OutstandingLiabilityGridModel>)Session["OutStandingLiabilities_0"];              

                IList<OutstandingLiabilityGridModel> lstOriginalScheduleN = new List<OutstandingLiabilityGridModel>();
                lstOriginalScheduleN = lstOutStandingLiabilityGrid.Where(x => 
                                                           x.EntityName == strEntityName &&
                                                           x.OriginalAmount == strOrgAmount &&
                                                           x.OutstandingAmount == strOrgAmount &&
                                                           x.ElectionYear == strElectionYear &&
                                                           x.DisclosurePeriod == strDisclosurePeriod &&
                                                           x.TransactionDate == strTransactionDate).ToList();
                if (lstOriginalScheduleN.Count() == 1)
                {
                    String TransID = lstOriginalScheduleN[0].FilingTransID.ToString();
                    return Json(TransID);
                }
                else
                {
                    IList<OutstandingLiabilityGridModel> lstAllOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                    lstAllOutStandingLiabilityGrid = (IList<OutstandingLiabilityGridModel>)Session["OutStandingLiabilities_3"];

                    lstOriginalScheduleN = lstAllOutStandingLiabilityGrid.Where(x =>
                                               x.EntityName == strEntityName &&
                                               x.OriginalAmount == strOrgAmount &&
                                               x.OutstandingAmount == strOrgAmount &&
                                               x.ElectionYear == strElectionYear &&
                                               x.DisclosurePeriod == strDisclosurePeriod &&
                                               x.TransactionDate == strTransactionDate).ToList();
                    if (lstOriginalScheduleN.Count() == 1)
                    {
                        //return Json("");
                        String TransID = lstOriginalScheduleN[0].FilingTransID.ToString();
                        return Json(TransID);
                    }
                    else
                        return Json("X");
                }

            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                return Json("FALSE");
            }
        }
        #endregion
        
        #region "GetOriginallScheduleNGridData"
        public IList<OutstandingLiabilityGridModel> GetOriginalScheduleNGridData(String strOriginalScheduleNTransID)
        {
            try
            {

                IList<OutstandingLiabilityGridModel> lstOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                lstOutStandingLiabilityGrid = (IList<OutstandingLiabilityGridModel>)Session["OutStandingLiabilities_3"];

                String strEntityName = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strOriginalScheduleNTransID).Select(x => x.EntityName).FirstOrDefault().ToString();
                String strOrgAmount = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strOriginalScheduleNTransID).Select(x => x.OriginalAmount).FirstOrDefault().ToString();
                String strElectionYear = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strOriginalScheduleNTransID).Select(x => x.ElectionYear).FirstOrDefault().ToString();
                String strTransactionDate = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strOriginalScheduleNTransID).Select(x => x.TransactionDate).FirstOrDefault().ToString();

                IList<OutstandingLiabilityGridModel> lstOriginalScheduleN = new List<OutstandingLiabilityGridModel>();
                lstOriginalScheduleN = lstOutStandingLiabilityGrid.Where(x => x.EntityName == strEntityName &&
                                                                           x.OriginalAmount == strOrgAmount &&
                                                                           x.OutstandingAmount == strOrgAmount &&
                                                                           //x.ElectionYear == strElectionYear &&
                                                                           x.TransactionDate == strTransactionDate).ToList();

                Session["CurrentScheduleNTransIDs"] = lstOriginalScheduleN;

                return lstOriginalScheduleN;             
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region "GetCorrespondingScheduleNTransNumber"
        public JsonResult GetCorrespondingScheduleNTransNumber(String strEntityName, String strPaymentAmount, String strElectionYear, String strDisclosurePeriod, String strOrgAmount, String strTransactionDate)
        {
            try
            {
                IList<OutstandingLiabilityGridModel> lstOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                lstOutStandingLiabilityGrid = (IList<OutstandingLiabilityGridModel>)Session["OutStandingLiabilities_0"];

                if (lstOutStandingLiabilityGrid.Count() > 0)
                {
                    String aTransID = lstOutStandingLiabilityGrid.Where(x => x.EntityName == strEntityName).Select(x => x.FilingTransID).FirstOrDefault().ToString();
                    Decimal owedAmount = Convert.ToDecimal(objLoanAndLiabilityReconciliatioBroker.GetMinReconciledOwedAmount(aTransID, strOrgAmount, Session["FilerID"].ToString()));

                    Decimal paymentAmount = Convert.ToDecimal(strPaymentAmount);
                    String strOwedAmount = Convert.ToString(owedAmount - paymentAmount);

                    IList<OutstandingLiabilityGridModel> lstOriginalScheduleN = new List<OutstandingLiabilityGridModel>();
                    lstOriginalScheduleN = lstOutStandingLiabilityGrid.Where(x =>
                                                               x.EntityName == strEntityName &&
                                                               x.OriginalAmount == strOrgAmount &&
                                                               x.OutstandingAmount == strOwedAmount &&
                                                               x.ElectionYear == strElectionYear &&
                                                               x.DisclosurePeriod == strDisclosurePeriod &&
                                                               x.TransactionDate == strTransactionDate
                                                               ).ToList();
                    if (lstOriginalScheduleN.Count() == 1)
                    {
                        String TransID = lstOriginalScheduleN[0].FilingTransID.ToString();
                        return Json(TransID);
                    }
                    return Json("");
                }
                return Json("");
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                return Json("FALSE");
            }
        }
        #endregion

        #region "GetCorrespondingScheduleNGridData"
        public IList<OutstandingLiabilityGridModel> GetCorrespondingScheduleNGridData(String strCorrespondingScheduleNTransID)
        {
            try
            {

                IList<OutstandingLiabilityGridModel> lstOutStandingLiabilityGrid = new List<OutstandingLiabilityGridModel>();
                lstOutStandingLiabilityGrid = (IList<OutstandingLiabilityGridModel>)Session["OutStandingLiabilities_0"];

                String strEntityName = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strCorrespondingScheduleNTransID).Select(x => x.EntityName).FirstOrDefault().ToString();
                String strOrgAmount = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strCorrespondingScheduleNTransID).Select(x => x.OriginalAmount).FirstOrDefault().ToString();
                String strOutstandingAmount = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strCorrespondingScheduleNTransID).Select(x => x.OutstandingAmount).FirstOrDefault().ToString();
                String strTransactionDate = lstOutStandingLiabilityGrid.Where(x => x.FilingTransID == strCorrespondingScheduleNTransID).Select(x => x.TransactionDate).FirstOrDefault().ToString();

                IList<OutstandingLiabilityGridModel> lstOriginalScheduleN = new List<OutstandingLiabilityGridModel>();
                lstOriginalScheduleN = lstOutStandingLiabilityGrid.Where(x => x.EntityName == strEntityName &&
                                                                           x.OriginalAmount == strOrgAmount &&
                                                                           x.OutstandingAmount == strOutstandingAmount &&
                                                                           x.TransactionDate == strTransactionDate
                                                                           ).ToList();

                Session["CurrentScheduleNTransIDs"] = lstOriginalScheduleN;

                return lstOriginalScheduleN;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "LoanAndLiabilityReconciliationController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region Grid Help
        /// <summary>
        /// ActiveDeactiveFilerGridHelp
        /// </summary>
        /// <returns></returns>
        //public ActionResult ActiveDeactiveFilerGridHelp()
        //{
        //    return View("ActiveDeactiveFilerGridHelp");
        //}
        #endregion Grid Help

        #region Filer Help
        /// <summary>
        /// LoanAndLiabilityReconciliationSearchHelp
        /// </summary>
        /// <returns></returns>
        public ActionResult LoanAndLiabilityReconciliationSearchHelp()
        {
            return View("LoanAndLiabilityReconciliationSearchHelp");
        }
        #endregion Filer Help    
    }

}