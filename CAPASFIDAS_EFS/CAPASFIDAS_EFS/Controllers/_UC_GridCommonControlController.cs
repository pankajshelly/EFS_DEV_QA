using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_GridCommonControlController : Controller
    {

        #region Global Valirables
        // Create Broker Object
        ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        ContributionsMonetaryController objContributionsMonetaryController = new ContributionsMonetaryController();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        #endregion Global Valirables

        //
        // GET: /_UC_GridCommonControl/
        public ActionResult _UC_GridCommonControl()
        {
            return View();
        }

        #region GetColumns
        /// <summary>
        /// GetColumns
        /// </summary>
        /// <param name="uniqudId"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public JsonResult GetColumns(string uniqudId, string applicationName, string pageName)
        {
            try
            {
                IList<ViewableColumnModel> lstViewableColumn = new List<ViewableColumnModel>();

                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(uniqudId, applicationName, pageName);

                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();

                return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetColumns", "", "", ex.Message, Session["UserName"].ToString());                    
                }
                throw;
            }
        }
        #endregion GetColumns

        #region GetColumnUpdatedValue
        /// <summary>
        /// GetColumnUpdatedValue
        /// </summary>
        /// <param name="uniqudId"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public JsonResult GetColumnUpdatedValue(String uniqudId)
        {
            try
            {
                IList<ViewableColumnModel> lstViewableColumn = new List<ViewableColumnModel>();

                lstViewableColumn = objItemizedReportsBroker.GetViewableColumnsBroker(uniqudId, "EFS", "FileDisclosureReport");

                lstViewableColumn = lstViewableColumn.Where(a => a.Viewable == "Y").ToList();

                return Json(lstViewableColumn, JsonRequestBehavior.AllowGet);
                //return Json(new SelectList(lstViewableColumn, "ViewableFieldID", "ViewableFieldID"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetColumnUpdatedValue", "", "", ex.Message, Session["UserName"].ToString());                    
                }
                throw;
            }
            
        }
        #endregion GetColumnUpdatedValue

        #region UpdateColumnValue
        /// <summary>
        /// Update Column Value
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <param name="applicationName"></param>
        /// <param name="pageName"></param>
        /// <param name="uniqueValue"></param>
        /// <param name="modifyBy"></param>
        /// <returns></returns>
        //[HttpPost]
        public JsonResult UpdateColumnValue(String uniqueValue)
        {
            try
            {
                //Update Column data
                bool result = true;
                result = objItemizedReportsBroker.UpdateColumnValueBroker(Session["FilerID"].ToString(),
                                             "EFS",
                                             "FileDisclosureReport",
                                             uniqueValue,
                                             "Admin");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "UpdateColumnValue", "", "", ex.Message, Session["UserName"].ToString());                    
                }
                throw;
            }
            
        }
        #endregion UpdateColumnValue

        #region Get and Delete Filing Transaction
        /// <summary>
        /// Get Filing Transaction
        /// </summary>
        /// <param name="txtFilerID"></param>
        /// <param name="lstElectionCycle"></param>
        /// <param name="lstUCOfficeType"></param>
        /// <param name="lstDisclosurePeriod"></param>
        /// <returns></returns>
        public JsonResult GetAllTransactionTypesData(String txtFilerID, String lstElectionCycle,
                                    String lstUCOfficeType, String lstDisclosurePeriod, String lstElectionType,
                                    String lstElectionDateId, String lstFilingDate, String txtFilingDate, String lstUCMuncipality)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                if (lstUCMuncipality == "- Select -" || lstUCMuncipality == null)
                    lstUCMuncipality = "";

                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();
                objFilingTransDataModel.FilerId = txtFilerID;
                objFilingTransDataModel.ReportYearId = lstElectionCycle;
                objFilingTransDataModel.OfficeTypeId = lstUCOfficeType;
                objFilingTransDataModel.DisclosurePeriod = lstDisclosurePeriod;
                objFilingTransDataModel.ElectionType = lstElectionType;
                objFilingTransDataModel.ElectionDateId = lstElectionDateId;
                if (lstElectionType == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                objFilingTransDataModel.MunicipalityID = lstUCMuncipality;

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetFilingTransactionsDataResponse(objFilingTransDataModel);

                // GET THE FILINGS ID.
                if (lstFilingTransactionDataModel.Count() > 0)
                    Session["FilingsIdOutLiabAmount"] = lstFilingTransactionDataModel.Select(x => x.FilingsId).FirstOrDefault().ToString();

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("01/01/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("01/01/1900"))
                        {
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        }
                        else if (lstFilingTransactionDataModel[i].SchedDate == "")
                        {
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].SchedDate = Convert.ToDateTime(lstFilingTransactionDataModel[i].SchedDate).ToString("MM/dd/yyyy");
                        }
                        //lstFilingTransactionDataModel[i].OriginalAmount = "$" + lstFilingTransactionDataModel[i].OriginalAmount;// + ".00";
                        if (lstFilingTransactionDataModel[i].OriginalAmount == "0") // ADDED THIS FOR IF AMOUNT ZERO THEN USING "0.00" ADDED - 05/06/2020.
                            lstFilingTransactionDataModel[i].OriginalAmount = "0.00";
                        else
                            lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                        else if (lstFilingTransactionDataModel[i].OwedAmount != null && lstFilingTransactionDataModel[i].OwedAmount != "")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                        }
                        else
                        {
                            if (lstFilingTransactionDataModel[i].FilingSchedId == "14")
                            {
                                if (lstFilingTransactionDataModel[i].OwedAmount == "")
                                {
                                    lstFilingTransactionDataModel[i].OwedAmount = "0.00";
                                }
                                else
                                {
                                    lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                                }
                            }
                            else
                            {
                                lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                            }
                        }
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "6")
                        {
                            if (lstFilingTransactionDataModel[i].OwedAmount == "0.00")
                                lstFilingTransactionDataModel[i].OwedAmount = "";
                            else
                                lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount;
                        }

                        if (lstFilingTransactionDataModel[i].FilingSchedId == "20")
                        {
                            if (lstFilingTransactionDataModel[i].OwedAmount == "0.00")
                                lstFilingTransactionDataModel[i].OwedAmount = "";
                            else
                                lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount;
                        }

                        if (lstFilingTransactionDataModel[i].Office == "0")
                        {
                            lstFilingTransactionDataModel[i].Office = "";
                        }
                        if (lstFilingTransactionDataModel[i].FilingSchedId.ToString() == "11")
                        {
                            lstFilingTransactionDataModel[i].OriginalDate = lstFilingTransactionDataModel[i].OriginalDate;
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        }
                    }
                }

                Session["AllTransactionsList"] = lstFilingTransactionDataModel;

                JsonResult result = Json(new
                {
                    aaData = lstFilingTransactionDataModel.Select(x => new[] {
                    x.FilingTransId,
                    x.FilingSchedId,
                    x.FilingEntityId,
                    x.ContributorTypeId,
                    x.ContributionTypeId,
                    x.PaymentTypeId,
                    x.RLiability,
                    x.RSubcontractor,
                    "",
                    "",
                    x.SchedDate,
                    x.FilingSchedDesc,
                    x.ContributorTypeDesc,
                    x.FilingEntityName,
                    x.FilingFirstName,
                    x.FilingMiddleName,
                    x.FilingLastName,
                    x.FilingCountry,
                    x.FilingStreetName,
                    x.FilingCity,
                    x.FilingState,
                    x.FilingZip,
                    x.PaymentTypeDesc,
                    x.PayNumber,
                    x.OriginalAmount,
                    x.OwedAmount,
                    x.ReceiptTypeDesc,
                    x.TransferTypeDesc,
                    x.ContributionTypeDesc,
                    x.PurposeCodeDesc,
                    x.ReceiptCodeDesc,
                    x.OriginalDate,
                    x.LoanerCode,
                    x.ElectionYear,
                    x.Office_Desc,
                    x.District,
                    x.TransExplanation,
                    x.RItemized,
                    x.CountyDesc,
                    x.MunicipalityDesc,
                    x.CreatedDate,
                    x.LoanLiablityNumber,
                    x.TransNumber,
                    x.TransMapping,
                    x.FilingsId,
                    x.Office,
                    x.RClaim,
                    x.InDistrict,
                    x.RMinor,
                    x.RVendor,
                    x.RLobbyist,
                    x.RContributions,
                    x.TreasurerEmployer,
                    x.TreasurerOccuptaion,
                    x.TreaAddress,
                    x.TreaAddr1,
                    x.TreaCity,
                    x.TreaState,
                    x.TreaZipCode,
                    x.IESupported //59
                })
                }, JsonRequestBehavior.AllowGet);
                result.MaxJsonLength = int.MaxValue;
                return result;
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetAllTransactionTypesData", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion

        #region GetEditTransactionData
        /// <summary>
        /// GetEditTransactionData
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        public JsonResult GetEditTransactionData(String strTransNumber)
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();

                String strFilerId = Session["FilerID"].ToString();

                lstFilingTransactionDataModel = objItemizedReportsBroker.GetEditTransactionDataResponse(strTransNumber, strFilerId);

                for (int i = 0; i < lstFilingTransactionDataModel.Count; i++)
                {   
                    if (lstFilingTransactionDataModel[i] != null)
                    {
                        if (lstFilingTransactionDataModel[i].OriginalDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].OriginalDate = "";
                        if (lstFilingTransactionDataModel[i].SchedDate.Contains("1/1/1900"))
                            lstFilingTransactionDataModel[i].SchedDate = "";
                        lstFilingTransactionDataModel[i].OriginalAmount = lstFilingTransactionDataModel[i].OriginalAmount;// + ".00";
                        if (lstFilingTransactionDataModel[i].FilingSchedId == "9" || lstFilingTransactionDataModel[i].FilingSchedId == "10")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = "";
                        }
                        else if (lstFilingTransactionDataModel[i].OwedAmount != null && lstFilingTransactionDataModel[i].OwedAmount != "")
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                        }
                        else
                        {
                            lstFilingTransactionDataModel[i].OwedAmount = lstFilingTransactionDataModel[i].OwedAmount; // + ".00";
                        }
                    }
                }

                return Json(lstFilingTransactionDataModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetEditTransactionData", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetEditTransactionData

        #region DeleteFilingTransactions
        /// <summary>
        /// Delete Filing Transaction
        /// </summary>
        /// <param name="strFilingTransId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteFilingTransactions(String strFilingTransId)
        {
            try
            {
                String strModifiedBy = "SBasireddy"; //Testing only

                Boolean results = objItemizedReportsBroker.DeleteFilingTransactionsDataResponse(strFilingTransId, strModifiedBy, Session["FilerId"].ToString());

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "DeleteFilingTransactions", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion DeleteFilingTransactions

        #region AutoCompleteForEntityName
        /// <summary>
        /// AutoCompleteEntityName
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteForEntityName(String term)
        {
            try
            {
                String strFilerId = Session["FilerID"].ToString(); // Testing only
                String strFLName = "EName";

                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                List<String> EntityNames;

                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);

                Session["lstAutoCompFLNameAddressModel"] = lstAutoCompFLNameAddressModel;

                EntityNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                return Json(EntityNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "AutoCompleteForEntityName", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion AutoCompleteForEntityName

        #region GetAutoCompleteForEntityData
        /// <summary>
        /// GetAutoCompleteNameData
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public JsonResult GetAutoCompleteForEntityData(String strValue)
        {
            try
            {
                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                lstAutoCompFLNameAddressModel = (IList<AutoCompFLNameAddressModel>)Session["lstAutoCompFLNameAddressModel"];

                String strResult = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityId).FirstOrDefault().ToString();

                Session["FilingEntId"] = strResult;

                lstAutoCompFLNameAddressModel = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstAutoCompFLNameAddressModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetAutoCompleteForEntityData", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetAutoCompleteForEntityData

        #region GetViewableColumnsData
        /// <summary>
        /// GetViewableColumnsData
        /// </summary>
        /// <returns></returns>
        public JsonResult GetViewableColumnsData()
        {
            try
            {
                string results = string.Empty;
                IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
                lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
                lstSortColumnName = lstSortColumnName.Where(x => x.Viewable == "Y").ToList();
                foreach (var item in lstSortColumnName)
                {
                    if (item != null)
                    {
                        results = results + item.ColumnName + ",";
                    }
                }
                results = results.Substring(0, (results.Length - 1));
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetViewableColumnsData", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetViewableColumnsData

        #region GetSortColumnName
        /// <summary>
        /// GetSortColumnName
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSortColumnName()
        {
            try
            {
                string results = string.Empty;
                IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
                //lstSortColumnName = (IList<ViewableColumnModel>)Session["SorList"];
                lstSortColumnName = objItemizedReportsBroker.GetViewableColumnsSortingBroker(Session["FilerID"].ToString(), "EFS", "FileDisclosureReport");
                lstSortColumnName = lstSortColumnName.Where(x => x.Viewable == "Y").ToList();
                foreach (var item in lstSortColumnName)
                {
                    if (item != null)
                    {
                        results = results + item.ColumnName + ",";
                    }
                }
                results = results.Substring(0, (results.Length - 1));
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetSortColumnName", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetSortColumnName

        #region AutoCompleteFirstName
        /// <summary>
        /// AutoCompleteFirstName
        /// </summary>
        /// <param name="term"></param>
        /// <param name="txtFilerId"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteFirstName(String term)
        {
            try
            {
                String strFilerId = Session["FilerID"].ToString();
                String strFLName = "FName";

                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                List<String> FirstNames;

                lstAutoCompFLNameAddressModel = objItemizedReportsBroker.GetAutoCompleteNameAddressResponse(term, strFilerId, strFLName);

                Session["lstCommonAutoComplete"] = lstAutoCompFLNameAddressModel;

                FirstNames = lstAutoCompFLNameAddressModel.Select(x => x.FilingEntityNameAndAddress).Distinct().ToList();

                return Json(FirstNames, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "AutoCompleteFirstName", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion AutoCompleteFirstName

        #region GetAutoCompleteNameData
        /// <summary>
        /// GetAutoCompleteNameData
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public JsonResult GetAutoCompleteNameData(String strValue)
        {
            try
            {
                IList<AutoCompFLNameAddressModel> lstAutoCompFLNameAddressModel = new List<AutoCompFLNameAddressModel>();

                lstAutoCompFLNameAddressModel = (IList<AutoCompFLNameAddressModel>)Session["lstCommonAutoComplete"];

                String strResult = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityNameAndAddress == strValue).Select(x => x.FilingEntityId).FirstOrDefault().ToString();

                Session["FilingEntId"] = strResult;

                lstAutoCompFLNameAddressModel = lstAutoCompFLNameAddressModel.Where(x => x.FilingEntityId == strResult).ToList();

                return Json(lstAutoCompFLNameAddressModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetAutoCompleteNameData", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetAutoCompleteNameData

        #region GetDeleteFlag
        /// <summary>
        /// GetDeleteFlag
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeleteFlag()
        {
            try
            {
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactions = new List<FilingTransactionDataModel>();
                IList<ScheduleIdModel> lstScheduleIdModel = new List<ScheduleIdModel>();

                String strIsDeleted = String.Empty;
                String strLoanExistsOrginal = String.Empty;
                String strLoanExistsPayment = String.Empty;
                String strLiabilityExistsPayment = String.Empty;
                String strLoanLiabOutstanding = String.Empty;
                String strIsFilingSubmitted = String.Empty;

                lstFilingTransactionDataModel = (IList<FilingTransactionDataModel>)Session["AllTransactionsList"];

                if (lstFilingTransactionDataModel.Count() > 0)
                {
                    // GET THE FILINGS ID.
                    String strFilingsId = lstFilingTransactionDataModel.Select(x => x.FilingsId).FirstOrDefault().ToString();

                    // GET THE FILING SUBMITTED OR NOT...
                    // IF FILING SUBMITTED THEN YOU CAN'T DELETE LAST TRANSACTION....
                    // IF FILING NOT SUBMITTED ITS NEW FILING THEN YOU CAN DELETE ALL TRANSACTIONS....
                    strIsFilingSubmitted = objItemizedReportsBroker.GetFilingsSubmittedOrNotResponse(strFilingsId);

                    if (strIsFilingSubmitted == "TRUE")
                    {
                        // USER SHOULD NOT DELETE LAST TRANSACTION AFTER FILING SUBMITTED.
                        // IF THEY DELETE LAST TRANSACTION IT WILL SHOW THE WARNING MESSAGE....
                        FilingTransactionDataModel objFilingTransactionDataModel;
                        foreach (var item in lstFilingTransactionDataModel)
                        {
                            if (item != null)
                            {
                                String strTransNumberLiabPay = String.Empty;
                                String strTransNumberLiabForgiven = String.Empty;
                                String strTransMapping = String.Empty;

                                // IF ANY SCHEDULE '14' OUTSTANDING TRANSACTION EXISTS THEN REMOVE FROM THE LIST.
                                // ONLY CHECK THE TRANSACTIONS 
                                objFilingTransactionDataModel = new FilingTransactionDataModel();
                                if (item.FilingSchedId.ToString() == "14")
                                {
                                    if ((item.OriginalAmount.ToString() == item.OwedAmount.ToString()) && (item.RLiability.ToString() == "Y"))
                                    {
                                        //// CHECK IF ITS 14 AND ITS MAPPED WITH 6 OR 11
                                        //// THEN DON'T ADD ITS NOT CONSIDER AS TRANSACTION...
                                        //strTransNumberLiabPay = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "6").Select(x => x.TransNumber).FirstOrDefault());

                                        //strTransNumberLiabForgiven = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "11").Select(x => x.TransNumber).FirstOrDefault());

                                        //strTransMapping = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "14").Select(x => x.TransMapping).FirstOrDefault());

                                        //if((strTransNumberLiabPay != null && strTransNumberLiabPay != ""))
                                        //{
                                        //    if ((strTransNumberLiabPay != null && strTransNumberLiabPay != "") && (strTransMapping != null && strTransMapping != ""))
                                        //    {
                                        //        if (strTransNumberLiabPay != strTransMapping)
                                        //        {
                                        //            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                        //            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                        //        }
                                        //    }
                                        //}
                                        //if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != ""))
                                        //{
                                        //    if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != "") && (strTransMapping != null && strTransMapping != ""))
                                        //    {
                                        //        if (strTransNumberLiabForgiven != strTransMapping)
                                        //        {
                                        //            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                        //            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                        //        }
                                        //    }
                                        //}
                                        objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                        lstFilingTransactions.Add(objFilingTransactionDataModel);
                                    }
                                    else
                                    {
                                        if ((item.OriginalAmount.ToString() != item.OwedAmount.ToString()) && (item.RLiability.ToString() == "Y"))
                                        {
                                            if (item.FilingSchedId == "6")
                                            {
                                                // CHECK IF ITS 14 AND ITS MAPPED WITH 6 OR 11
                                                // THEN DON'T ADD ITS NOT CONSIDER AS TRANSACTION...
                                                strTransNumberLiabPay = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "6" && x.TransNumber == item.TransMapping.ToString()).Select(x => x.TransNumber).FirstOrDefault());

                                                strTransNumberLiabForgiven = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "11" && x.TransNumber == item.TransMapping.ToString()).Select(x => x.TransNumber).FirstOrDefault());

                                                strTransMapping = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "14" && x.TransNumber == item.TransNumber.ToString()).Select(x => x.TransMapping).FirstOrDefault());

                                                if ((strTransNumberLiabPay != null && strTransNumberLiabPay != ""))
                                                {
                                                    if ((strTransNumberLiabPay != null && strTransNumberLiabPay != "") && (strTransMapping != null && strTransMapping != ""))
                                                    {
                                                        if (strTransNumberLiabPay != strTransMapping)
                                                        {
                                                            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                        }
                                                    }
                                                }
                                                if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != ""))
                                                {
                                                    if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != "") && (strTransMapping != null && strTransMapping != ""))
                                                    {
                                                        if (strTransNumberLiabForgiven != strTransMapping)
                                                        {
                                                            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                    lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                }
                                                //objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                //lstFilingTransactions.Add(objFilingTransactionDataModel);
                                            }
                                            else if (item.FilingSchedId == "20")
                                            {
                                                // CHECK IF ITS 14 AND ITS MAPPED WITH 20 OR 11
                                                // THEN DON'T ADD ITS NOT CONSIDER AS TRANSACTION...
                                                strTransNumberLiabPay = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "20" && x.TransNumber == item.TransMapping.ToString()).Select(x => x.TransNumber).FirstOrDefault());

                                                strTransNumberLiabForgiven = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "11" && x.TransNumber == item.TransMapping.ToString()).Select(x => x.TransNumber).FirstOrDefault());

                                                strTransMapping = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "14" && x.TransNumber == item.TransNumber.ToString()).Select(x => x.TransMapping).FirstOrDefault());

                                                if ((strTransNumberLiabPay != null && strTransNumberLiabPay != ""))
                                                {
                                                    if ((strTransNumberLiabPay != null && strTransNumberLiabPay != "") && (strTransMapping != null && strTransMapping != ""))
                                                    {
                                                        if (strTransNumberLiabPay != strTransMapping)
                                                        {
                                                            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                        }
                                                    }
                                                }
                                                if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != ""))
                                                {
                                                    if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != "") && (strTransMapping != null && strTransMapping != ""))
                                                    {
                                                        if (strTransNumberLiabForgiven != strTransMapping)
                                                        {
                                                            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                    lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                }
                                                //objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                //lstFilingTransactions.Add(objFilingTransactionDataModel);
                                            }
                                            else
                                            {
                                                // CHECK IF ITS 14 AND ITS MAPPED WITH 6 OR 11
                                                // THEN DON'T ADD ITS NOT CONSIDER AS TRANSACTION...
                                                strTransNumberLiabPay = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "6" && x.TransNumber == item.TransMapping.ToString()).Select(x => x.TransNumber).FirstOrDefault());

                                                strTransNumberLiabForgiven = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "11" && x.TransNumber == item.TransMapping.ToString()).Select(x => x.TransNumber).FirstOrDefault());

                                                strTransMapping = Convert.ToString(lstFilingTransactionDataModel.Where(x => x.FilingSchedId.ToString() == "14" && x.TransNumber == item.TransNumber.ToString()).Select(x => x.TransMapping).FirstOrDefault());

                                                if ((strTransNumberLiabPay != null && strTransNumberLiabPay != ""))
                                                {
                                                    if ((strTransNumberLiabPay != null && strTransNumberLiabPay != "") && (strTransMapping != null && strTransMapping != ""))
                                                    {
                                                        if (strTransNumberLiabPay != strTransMapping)
                                                        {
                                                            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                        }
                                                    }
                                                }
                                                if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != ""))
                                                {
                                                    if ((strTransNumberLiabForgiven != null && strTransNumberLiabForgiven != "") && (strTransMapping != null && strTransMapping != ""))
                                                    {
                                                        if (strTransNumberLiabForgiven != strTransMapping)
                                                        {
                                                            objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                            lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                    lstFilingTransactions.Add(objFilingTransactionDataModel);
                                                }
                                                //objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                                //lstFilingTransactions.Add(objFilingTransactionDataModel);
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    objFilingTransactionDataModel.FilingSchedId = item.FilingSchedId;
                                    lstFilingTransactions.Add(objFilingTransactionDataModel);
                                }
                            }
                        }

                        // IF SCHEDULES COUNT 1 THEN ITS LANST TRANSACTION THEN YOU SCHOULD NOT DELETE.
                        // IF SCHEDULES MORE THAN 1 THEN USER CAN DELETE UNTIL ITS LAST TRANSACTION.
                        if (lstFilingTransactions.Count() == 1)
                        {
                            strIsDeleted = "False";
                        }
                        else
                        {
                            strIsDeleted = "True";
                        }
                    }
                    else
                    {
                        strIsDeleted = "True";
                    }
                }

                return Json(strIsDeleted, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetDeleteFlag", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetDeleteFlag

        #region GetEditFlag
        /// <summary>
        /// GetEditFlag
        /// </summary>
        /// <param name="txtFilerId"></param>
        /// <param name="lstElectYearId"></param>
        /// <param name="strElectionTypeId"></param>
        /// <param name="lstOfficeTypeId"></param>
        /// <param name="lstFilingTypeId"></param>
        /// <param name="lstFilingDate"></param>
        /// <param name="electionDateId"></param>
        /// <returns></returns>
        public JsonResult GetEditFlag(String txtFilerId, String lstElectYearId,
            String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId,
            String lstFilingDate, String txtFilingDate, String electionDateId, String strTransNumber, String lstUCMuncipality)
        {
            try
            {                

                if (lstOfficeTypeId == "4") lstOfficeTypeId = "1";

                IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();

                objFilingTransDataModel.FilerId = txtFilerId;
                objFilingTransDataModel.ReportYearId = lstElectYearId;
                objFilingTransDataModel.ElectionType = strElectionTypeId;
                objFilingTransDataModel.OfficeTypeId = lstOfficeTypeId;
                objFilingTransDataModel.DisclosurePeriod = lstFilingTypeId;
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                objFilingTransDataModel.ElectionDateId = electionDateId;
                objFilingTransDataModel.TransNumber = strTransNumber;
                objFilingTransDataModel.Created_By = Session["UserName"].ToString();
                objFilingTransDataModel.MunicipalityID = lstUCMuncipality;

                lstGetEditFlagDataModel = objItemizedReportsBroker.GetEditFlagBroker(objFilingTransDataModel);
                return Json(lstGetEditFlagDataModel[0].Is_Edit.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetEditFlag", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetEditFlag

        #region GetSortName
        /// <summary>
        /// GetSortName
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSortName()
        {
            try
            {                
                string results = string.Empty;
                IList<ViewableColumnModel> lstSortColumnName = new List<ViewableColumnModel>();
                lstSortColumnName = (IList<ViewableColumnModel>)Session["SorList"];
                lstSortColumnName = lstSortColumnName.Where(x => x.Viewable == "Y").ToList();
                foreach (var item in lstSortColumnName)
                {
                    if (item != null)
                    {
                        results = results + item.ColumnName + ",";
                    }
                }
                if (results != "")
                {
                    results = results.Substring(0, (results.Length - 1));
                }

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetSortName", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion GetSortName

        #region GetNumberOrNot
        /// <summary>
        /// GetNumberOrNot
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public JsonResult GetNumberOrNot(String strValue)
        {
            try
            {
                Boolean returnValue;

                Match match = Regex.Match(strValue, @"^[0-9.]*$");

                if (match.Success)
                    returnValue = true;
                else
                    returnValue = false;

                return Json(returnValue, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetNumberOrNot", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion GetNumberOrNot


        /// <summary>
        /// GetEditFlagPCFDueDate
        /// </summary>
        /// <param name="lstDisclosurePeriod"></param>
        /// <param name="strFilingDate"></param>
        /// <returns></returns>
        public JsonResult GetEditFlagPCFDueDate(String lstElectYearId,
            String strElectionTypeId, String lstOfficeTypeId, String lstFilingTypeId,
            String lstFilingDate, String txtFilingDate, String electionDateId)
        {
            try
            {
                String strLabelId = String.Empty;
                IList<GetEditFlagDataModel> lstGetEditFlagDataModel = new List<GetEditFlagDataModel>();
                IList<FilingTransactionDataModel> lstFilingTransactionDataModel = new List<FilingTransactionDataModel>();
                FilingTransDataModel objFilingTransDataModel = new FilingTransDataModel();

                if (lstFilingTypeId == "1") // 32 Day Pre-Primary
                {
                    strLabelId = "59";
                }
                else if (lstFilingTypeId == "2") // 11 Day Pre-Primary
                {
                    strLabelId = "61";
                }
                else if (lstFilingTypeId == "3") // 10 Day Post-Primary
                {
                    strLabelId = "65";
                }
                else if (lstFilingTypeId == "4") // 32 Day Pre-General
                {
                    strLabelId = "104";
                }
                else if (lstFilingTypeId == "5") // 11 Day Pre-General
                {
                    strLabelId = "106";
                }
                else if (lstFilingTypeId == "6") // 27 Day Post-General
                {
                    strLabelId = "108";
                }
                else if (lstFilingTypeId == "7") // 32 Day Pre-Speceial
                {
                    strLabelId = "122";
                }
                else if (lstFilingTypeId == "8") // 11 Day Pre-Special
                {
                    strLabelId = "124";
                }
                else if (lstFilingTypeId == "9") // 27 Day Post-Special
                {
                    strLabelId = "126";
                }
                else if (lstFilingTypeId == "10") // January Periodic
                {
                    strLabelId = "69";
                }
                else if (lstFilingTypeId == "11") // July Periodic
                {
                    strLabelId = "71";
                }
                else if (lstFilingTypeId == "12") // Off Cycle
                {
                    //strFilingDateId = "108";
                }
                else if (lstFilingTypeId == "13") // March Periodic
                {
                    strLabelId = "140";
                }
                else if (lstFilingTypeId == "14") // January
                {
                    strLabelId = "144";
                }
                else if (lstFilingTypeId == "15") // February
                {
                    strLabelId = "146";
                }
                else if (lstFilingTypeId == "16") // March
                {
                    strLabelId = "148";
                }
                else if (lstFilingTypeId == "17") // April
                {
                    strLabelId = "150";
                }
                else if (lstFilingTypeId == "18") // July
                {
                    strLabelId = "152";
                }
                else if (lstFilingTypeId == "19") // December
                {
                    strLabelId = "142";
                }

                if (lstOfficeTypeId == "4") lstOfficeTypeId = "1";

                

                objFilingTransDataModel.FilerId = Session["FilerID"].ToString();
                objFilingTransDataModel.ReportYearId = lstElectYearId;
                objFilingTransDataModel.ElectionType = strElectionTypeId;
                objFilingTransDataModel.OfficeTypeId = lstOfficeTypeId;
                objFilingTransDataModel.DisclosurePeriod = lstFilingTypeId;
                if (strElectionTypeId == "6") // OFF-CYCLE FILING DATE
                {
                    if (lstFilingDate == "- New Filing Date -")
                        objFilingTransDataModel.FilingDate = txtFilingDate;
                    else
                        objFilingTransDataModel.FilingDate = lstFilingDate;
                }
                else // OTHER THAN OFF-CYCLE FILING DATE
                {
                    objFilingTransDataModel.FilingDate = txtFilingDate;
                }
                objFilingTransDataModel.ElectionDateId = electionDateId;                
                objFilingTransDataModel.Created_By = Session["UserName"].ToString();                
                objFilingTransDataModel.CommTypeId = Session["COMM_TYPE_ID"].ToString();
                objFilingTransDataModel.LabelId = strLabelId;

                lstGetEditFlagDataModel = objItemizedReportsBroker.GetEditFlagPCFDueDateBroker(objFilingTransDataModel);
                return Json(lstGetEditFlagDataModel[0].Is_Edit.ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_GridCommonControlController", "GetEditFlagPCFDueDate", "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }

        }

    }
}