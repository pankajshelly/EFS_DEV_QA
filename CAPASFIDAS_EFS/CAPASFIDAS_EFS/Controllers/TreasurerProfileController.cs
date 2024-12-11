using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Broker;
using System.Transactions;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class TreasurerProfileController : Controller
    {
        // Create Broker Object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        TreasurerProfileBroker objTreasurerProfileBroker = new TreasurerProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /TreasurerProfile/
        public ActionResult TreasurerProfile()
        {
            try
            {
                if (Session["SAMLResponse"] == null)
                {
                    SAMLRequest request = new SAMLRequest();
                    Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                }
                else
                {
                    //Session["PersonId"] = "23161"; // Testing only replace with main session.
                    IList<TreasurerProfileModel> lstTreasurerProfileModel = new List<TreasurerProfileModel>();
                    lstTreasurerProfileModel = objTreasurerProfileBroker.GetTreasurerProfileInfoBroker(Session["PersonId"].ToString());
                    Session["TransIDValue"] = lstTreasurerProfileModel[0].TransID.ToString();
                    foreach (var item in lstTreasurerProfileModel)
                    {
                        if (item != null)
                        {
                            ViewBag.txtTreasurerID = item.TransID.ToString();
                            if (item.PersonSSN != null)
                            {
                                ViewBag.txtSSN = item.PersonSSN.ToString();
                            }
                            else
                            {
                                ViewBag.txtSSN = "No";
                            }
                            ViewBag.txtRegistrationDate = Convert.ToDateTime(item.TransRegDate).ToShortDateString();
                            if (item.Status.ToString() == "I")
                                ViewBag.txtStatus = "In-Active";
                            else
                                ViewBag.txtStatus = "Active";
                            if (item.TransTermDate.ToString() == "1/1/1900 12:00:00 AM")
                            {
                                ViewBag.txtResignationDate = "";
                            }
                            else
                            {
                                //ViewBag.txtResignationDate = Convert.ToDateTime(item.TransTermDate).ToShortDateString(); 
                                ViewBag.txtResignationDate = "";
                            }
                            ViewBag.txtPrefix = item.PersonPrefix.ToString();
                            ViewBag.txtLastName = item.PersonLastName.ToString();
                            ViewBag.txtFirstName = item.PersonFirstName.ToString();
                            ViewBag.txtMI = item.PersonMiddleName.ToString();
                            ViewBag.txtSuffix = item.PersonSuffix.ToString();
                        }
                    }

                    IList<TreasurerCommitteeInformationModel> lstTreasurerCommitteeInformationModel = new List<TreasurerCommitteeInformationModel>();
                    lstTreasurerCommitteeInformationModel = objTreasurerProfileBroker.GetTreasurerCommitteeInformationBroker(ViewBag.txtTreasurerID);

                    Session["CommitteeInfo"] = lstTreasurerCommitteeInformationModel;
                    Session["TreaCommID"] = lstTreasurerCommitteeInformationModel[0].CommID.ToString();
                    if (lstTreasurerCommitteeInformationModel.Count == 1)
                    {
                        foreach (var item in lstTreasurerCommitteeInformationModel)
                        {
                            if (item != null)
                            {
                                ViewBag.CommitteeId = item.CommID.ToString();
                                ViewBag.FilerId = item.FilerID.ToString();
                                ViewBag.CommitteeName = item.CommitteeName.ToString();
                                ViewBag.Status = item.Status.ToString();
                                ViewBag.RegistrationDate = Convert.ToDateTime(item.CommitteeRegDate).ToShortDateString();
                                if (item.CommitteeTermDate != null)
                                {
                                    if (item.CommitteeTermDate.ToString() == "1/1/1900 12:00:00 AM")
                                    {
                                        ViewBag.TerminationDate = "";
                                    }
                                    else
                                    {
                                        ViewBag.TerminationDate = Convert.ToDateTime(item.CommitteeTermDate).ToShortDateString();
                                    }
                                }
                                else
                                {
                                    ViewBag.TerminationDate = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewBag.RowCount = lstTreasurerCommitteeInformationModel.Count();
                        ViewBag.CommitteeId = "";
                        ViewBag.FilerId = "";
                        ViewBag.CommitteeName = "";
                        ViewBag.Status = "";
                        ViewBag.RegistrationDate = "";
                        ViewBag.TerminationDate = "";
                    }

                    //Bind Adders Type
                    IList<AddressTypesModel> lstAddressTypesModel = new List<AddressTypesModel>();

                    lstAddressTypesModel = objCandidateProfileBroker.GetAddressTypesDataResponse();

                    Session["lstAddressTypesModel"] = lstAddressTypesModel;
                    ViewData["lstAddressType"] = new SelectList(lstAddressTypesModel, "AddressTypeId", "AddressTypeDescription");

                    //Bind Best Contact
                    IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();

                    lstBestContactTypesModel = objCandidateProfileBroker.GetBestContactTypesDataResponse();

                    Session["lstBestContactTypesModel"] = lstBestContactTypesModel;
                    ViewData["lstBestContact"] = new SelectList(lstBestContactTypesModel, "BestContactTypeId", "BestContactTypeDesc");

                    IList<Status> lstStatus = new List<Status>();
                    Status objStatus;

                    objStatus = new Status();
                    objStatus.StatusId = "1";
                    objStatus.StatusName = "Active";
                    lstStatus.Add(objStatus);

                    objStatus = new Status();
                    objStatus.StatusId = "2";
                    objStatus.StatusName = "In-Active";
                    lstStatus.Add(objStatus);

                    ViewData["lstStatus"] = new SelectList(lstStatus, "StatusId", "StatusName");
                    ViewData["lstASCStatus"] = new SelectList(lstStatus, "StatusId", "StatusName");

                    IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();
                    lstBankAccountTypesModel = objCandidateProfileBroker.GetBankAccountTypesResponse();
                    ViewData["lstAccountType"] = new SelectList(lstBankAccountTypesModel, "AccountTypeId", "AccountTypeDesc");
                }
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
        }

        //#region Get Address Data
        ///// <summary>
        ///// Get Address Data
        ///// </summary>
        ///// <returns></returns>
        //public JsonResult GetAddressData()
        //{
        //    String strSiteId = String.Empty;

        //    IList<ShowAddress> lstShowAddress = new List<ShowAddress>();
        //    ShowAddress objShowAddress;
            
        //    objShowAddress = new ShowAddress();
        //    objShowAddress.ADDR_ADDR1 = "124-132 Washington Ave";
        //    objShowAddress.ADDR_ADDR2 = "";
        //    objShowAddress.BEST_CONTACT_ID = "1";
        //    objShowAddress.BEST_CONTACT_DESC = "Primary";
        //    objShowAddress.ADDR_TYPE_ID = "1";
        //    objShowAddress.ADDR_TYPE_DESC = "Business";
        //    objShowAddress.ADDR_STR_NUM = "";
        //    objShowAddress.ADDR_STR_NAME = "";
        //    objShowAddress.ADDR_CITY = "Endicott";
        //    objShowAddress.ADDR_STATE = "NY";
        //    objShowAddress.ADDR_ZIP5 = "13760";
        //    objShowAddress.ADDR_ZIP4 = "0";
        //    objShowAddress.ADDR_ID = "11";
        //    lstShowAddress.Add(objShowAddress);

        //    objShowAddress = new ShowAddress();
        //    objShowAddress.ADDR_ADDR1 = "124-132 Washington Ave";
        //    objShowAddress.ADDR_ADDR2 = "";
        //    objShowAddress.BEST_CONTACT_ID = "1";
        //    objShowAddress.BEST_CONTACT_DESC = "Secondry";
        //    objShowAddress.ADDR_TYPE_ID = "1";
        //    objShowAddress.ADDR_TYPE_DESC = "Business";
        //    objShowAddress.ADDR_STR_NUM = "";
        //    objShowAddress.ADDR_STR_NAME = "";
        //    objShowAddress.ADDR_CITY = "Endicott";
        //    objShowAddress.ADDR_STATE = "NY";
        //    objShowAddress.ADDR_ZIP5 = "13760";
        //    objShowAddress.ADDR_ZIP4 = "0";
        //    objShowAddress.ADDR_ID = "11";
        //    lstShowAddress.Add(objShowAddress);

        //    Session["ShowAddress"] = lstShowAddress;

        //    return Json(new
        //    {
        //        aaData = lstShowAddress.Select(x => new[] { 
        //            x.ADDR_ID, 
        //            x.BEST_CONTACT_DESC,
        //            x.ADDR_TYPE_DESC,                    
        //            x.ADDR_STR_NUM,
        //            x.ADDR_STR_NAME,
        //            x.ADDR_CITY,
        //            x.ADDR_STATE,
        //            x.ADDR_ZIP5,
        //            x.ADDR_ZIP4
        //        })
        //    }, JsonRequestBehavior.AllowGet);
        //}
        //#endregion Get Address Data

        ///// <summary>
        ///// Show Contract
        ///// </summary>
        ///// <returns></returns>
        //public JsonResult GetShowContact()
        //{
        //    IList<ShowContact> lstShowContact = new List<ShowContact>();
        //    ShowContact objShowContact;

        //    objShowContact = new ShowContact();
        //    objShowContact.BestContract_ID = "1";
        //    objShowContact.BestContract_Desc = "Primary";
        //    objShowContact.Phone = "123456789";
        //    objShowContact.EmailAddress = "abc@abc.com";
        //    lstShowContact.Add(objShowContact);

        //    objShowContact = new ShowContact();
        //    objShowContact.BestContract_ID = "2";
        //    objShowContact.BestContract_Desc = "Secondary";
        //    objShowContact.Phone = "123456789";
        //    objShowContact.EmailAddress = "abc@abc.com";
        //    lstShowContact.Add(objShowContact);

        //    Session["ShowContact"] = lstShowContact;

        //    return Json(new
        //    {
        //        aaData = lstShowContact.Select(x => new[] { 
        //            x.BestContract_ID, 
        //            x.BestContract_Desc,
        //            x.Phone,
        //            x.EmailAddress
        //        })
        //    }, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// Committee Information
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCommitteeInfo()
        {
            try
            {
                IList<TreasurerCommitteeInformationModel> lstTreasurerCommitteeInformationModel = new List<TreasurerCommitteeInformationModel>();
                TreasurerCommitteeInformationModel objTreasurerCommitteeInformationModel;
                var results = (IList<TreasurerCommitteeInformationModel>)Session["CommitteeInfo"];

                foreach (var item in results)
                {
                    if (item != null)
                    {
                        objTreasurerCommitteeInformationModel = new TreasurerCommitteeInformationModel();
                        objTreasurerCommitteeInformationModel.CommID = item.CommID;
                        objTreasurerCommitteeInformationModel.FilerID = item.FilerID;
                        objTreasurerCommitteeInformationModel.CommitteeName = item.CommitteeName;
                        if (item.Status == "I")
                            objTreasurerCommitteeInformationModel.Status = "In-Active";
                        else
                            objTreasurerCommitteeInformationModel.Status = "Active";
                        objTreasurerCommitteeInformationModel.PersonID = item.PersonID;
                        objTreasurerCommitteeInformationModel.CommitteeRegDate = Convert.ToDateTime(item.CommitteeRegDate).ToShortDateString();
                        if (item.CommitteeTermDate.ToString() == "1/1/1900 12:00:00 AM")
                        {
                            objTreasurerCommitteeInformationModel.CommitteeTermDate = "";
                        }
                        else
                        {
                            objTreasurerCommitteeInformationModel.CommitteeTermDate = Convert.ToDateTime(item.CommitteeTermDate).ToShortDateString();
                        }
                        objTreasurerCommitteeInformationModel.CommitteeTypeDesc = item.CommitteeTypeDesc;
                        lstTreasurerCommitteeInformationModel.Add(objTreasurerCommitteeInformationModel);
                    }
                }

                return Json(new
                {
                    aaData = lstTreasurerCommitteeInformationModel.Select(x => new[] {
                    x.CommID,
                    x.FilerID,
                    x.CommitteeName,
                    x.Status,
                    x.CommitteeRegDate,
                    x.CommitteeTermDate
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Treasurer History
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTreasurerHistory()
        {
            //IList<TreasurerHistory> lstTreasurerHistory = new List<TreasurerHistory>();
            //TreasurerHistory objTreasurerHistory;

            //objTreasurerHistory = new TreasurerHistory();
            //objTreasurerHistory.TreasurerID = "1";
            //objTreasurerHistory.Prefix = "";
            //objTreasurerHistory.LastName = "Smith";
            //objTreasurerHistory.FirstName = "John";
            //objTreasurerHistory.MI = "";
            //objTreasurerHistory.Suffix = "";
            //objTreasurerHistory.Status = "Active";
            //objTreasurerHistory.RegDate = "10/02/2014";
            //objTreasurerHistory.ResignDate = "";
            //lstTreasurerHistory.Add(objTreasurerHistory);

            //objTreasurerHistory = new TreasurerHistory();
            //objTreasurerHistory.TreasurerID = "2";
            //objTreasurerHistory.Prefix = "";
            //objTreasurerHistory.LastName = "Smith";
            //objTreasurerHistory.FirstName = "Kevin";
            //objTreasurerHistory.MI = "T";
            //objTreasurerHistory.Suffix = "";
            //objTreasurerHistory.Status = "In-Active";
            //objTreasurerHistory.RegDate = "10/02/2013";
            //objTreasurerHistory.ResignDate = "05/12/2014";
            //lstTreasurerHistory.Add(objTreasurerHistory);
            try
            {
                IList<TreasurerHistoryModel> lstTreasurerHistoryModel = new List<TreasurerHistoryModel>();
                lstTreasurerHistoryModel = objTreasurerProfileBroker.GetTreasurerHistoryInformationBroker(Session["TreaCommID"].ToString(), Session["TransIDValue"].ToString());
                Session["TreasurerHistory"] = lstTreasurerHistoryModel;
                return Json(new
                {
                    aaData = lstTreasurerHistoryModel.Select(x => new[] {
                    Session["TransIDValue"].ToString(),
                    x.PersonID,
                    x.PersonPrefix,
                    x.PersonLastName,
                    x.PersonFirstName,
                    x.PersonMiddleName,
                    x.PersonSuffix,
                    x.Status,
                    Convert.ToDateTime(x.RegDate).ToShortDateString(),
                    Convert.ToDateTime(x.TermDate).ToShortDateString()
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetDepositoryBankInfo
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDepositoryBankInfo()
        {
            try
            {
                IList<TreasDepositoryBankInformationModel> lstTreasDepositoryBankInformationModel = new List<TreasDepositoryBankInformationModel>();
                lstTreasDepositoryBankInformationModel = objTreasurerProfileBroker.GetTreasurerDepositoryBankInformationBroker(Session["TreaCommID"].ToString());

                Session["DepositoryBankInfo"] = lstTreasDepositoryBankInformationModel;

                return Json(new
                {
                    aaData = lstTreasDepositoryBankInformationModel.Select(x => new[] {
                    x.BankID,
                    "",
                    x.BankName,
                    x.AddrStrName,
                    x.AddrCity,
                    x.AddrState,
                    x.AddrZip
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetAuthSignChecks
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAuthSignChecks()
        {
            //IList<AuthSignChecks> lstAuthSignChecks = new List<AuthSignChecks>();
            //AuthSignChecks objAuthSignChecks;

            //objAuthSignChecks = new AuthSignChecks();
            //objAuthSignChecks.ContactId = "1";
            //objAuthSignChecks.Prefix = "";
            //objAuthSignChecks.LastName = "Smith";
            //objAuthSignChecks.FirstName = "John";
            //objAuthSignChecks.MI = "";
            //objAuthSignChecks.Suffix = "";
            //lstAuthSignChecks.Add(objAuthSignChecks);

            //objAuthSignChecks = new AuthSignChecks();
            //objAuthSignChecks.ContactId = "2";
            //objAuthSignChecks.Prefix = "";
            //objAuthSignChecks.LastName = "Kevin";
            //objAuthSignChecks.FirstName = "Smith";
            //objAuthSignChecks.MI = "T";
            //objAuthSignChecks.Suffix = "";
            //lstAuthSignChecks.Add(objAuthSignChecks);

            try
            {
                IList<TreasAuthorizedToSignCheckModel> lstTreasAuthorizedToSignCheckModel = new List<TreasAuthorizedToSignCheckModel>();
                lstTreasAuthorizedToSignCheckModel = objTreasurerProfileBroker.GetTreasurerAuthorizedToSignCheckContactBroker(Session["TreaCommID"].ToString());

                Session["AuthSignChecks"] = lstTreasAuthorizedToSignCheckModel;

                return Json(new
                {
                    aaData = lstTreasAuthorizedToSignCheckModel.Select(x => new[] {
                    x.AuthSignedID,
                    x.PersonID,
                    "",
                    x.PersonPrefix,
                    x.PersonLastName,
                    x.PersonFirstName,
                    x.PersonMiddleName,
                    x.PersonSuffix,
                    x.StartDate,
                    x.EndDate,
                    x.Status
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// GetAssitTreasurerInfo
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAssitTreasurerInfo()
        {
            //IList<AssistTreasurerInfo> lstAssistTreasurerInfo = new List<AssistTreasurerInfo>();
            //AssistTreasurerInfo objAssistTreasurerInfo;

            //objAssistTreasurerInfo = new AssistTreasurerInfo();
            //objAssistTreasurerInfo.ContactId = "1";
            //objAssistTreasurerInfo.Prefix = "";
            //objAssistTreasurerInfo.LastName = "Smith";
            //objAssistTreasurerInfo.FirstName = "John";
            //objAssistTreasurerInfo.MI = "";
            //objAssistTreasurerInfo.Suffix = "";
            //lstAssistTreasurerInfo.Add(objAssistTreasurerInfo);

            //objAssistTreasurerInfo = new AssistTreasurerInfo();
            //objAssistTreasurerInfo.ContactId = "2";
            //objAssistTreasurerInfo.Prefix = "";
            //objAssistTreasurerInfo.LastName = "Kevin";
            //objAssistTreasurerInfo.FirstName = "Smith";
            //objAssistTreasurerInfo.MI = "T";
            //objAssistTreasurerInfo.Suffix = "";
            //lstAssistTreasurerInfo.Add(objAssistTreasurerInfo);

            try
            {
                IList<TreasAssistantInformationModel> lstTreasAssistantInformationModel = new List<TreasAssistantInformationModel>();
                lstTreasAssistantInformationModel = objTreasurerProfileBroker.GetTreasurerAssistantInformationBroker(Session["TreaCommID"].ToString());
                Session["AssistTreasurerInfo"] = lstTreasAssistantInformationModel;
                return Json(new
                {
                    aaData = lstTreasAssistantInformationModel.Select(x => new[] {
                    x.PersonID,
                    "",
                    "",
                    x.PersonPrefix,
                    x.PersonLastName,
                    x.PersonFirstName,
                    x.PersonMiddleName,
                    x.PersonSuffix,
                    x.Status
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        ///  Candidate Supported or Opposed
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCandidatesSuppOpp()
        {
            //IList<CandidateSuppOpp> lstCandidateSuppOpp = new List<CandidateSuppOpp>();
            //CandidateSuppOpp objCandidateSuppOpp;

            //objCandidateSuppOpp = new CandidateSuppOpp();
            //objCandidateSuppOpp.CandidateId = "1";
            //objCandidateSuppOpp.ElectionYear = "2014";
            //objCandidateSuppOpp.Office = "Governor";
            //objCandidateSuppOpp.District = "2";
            //objCandidateSuppOpp.CandidateFullName = "John Smith";
            //objCandidateSuppOpp.SupportOppose = "Support";
            //objCandidateSuppOpp.AuthorizationDate = "02/15/2014";
            //objCandidateSuppOpp.NonExpenditureDate = "05/17/2015";
            //lstCandidateSuppOpp.Add(objCandidateSuppOpp);

            //objCandidateSuppOpp = new CandidateSuppOpp();
            //objCandidateSuppOpp.CandidateId = "2";
            //objCandidateSuppOpp.ElectionYear = "2010";
            //objCandidateSuppOpp.Office = "Member of Assembly";
            //objCandidateSuppOpp.District = "4";
            //objCandidateSuppOpp.CandidateFullName = "Smith T Kevin";
            //objCandidateSuppOpp.SupportOppose = "Oppose";
            //objCandidateSuppOpp.AuthorizationDate = "01/13/2013";
            //objCandidateSuppOpp.NonExpenditureDate = "04/11/2014";
            //lstCandidateSuppOpp.Add(objCandidateSuppOpp);

            try
            {
                IList<TreasCandidateSupportOpposeModel> lstTreasCandidateSupportOpposeModel = new List<TreasCandidateSupportOpposeModel>();
                lstTreasCandidateSupportOpposeModel = objTreasurerProfileBroker.GetTreasurerCandidateSupposeOpposeBroker(Session["TreaCommID"].ToString());

                Session["CandidatesSuppOpp"] = lstTreasCandidateSupportOpposeModel;

                return Json(new
                {
                    aaData = lstTreasCandidateSupportOpposeModel.Select(x => new[] { 
                    //x.CandidateId, 
                    "",
                    x.ElectionYear,
                    x.OfficeDesc,
                    x.DistID,
                    x.PersonFirstName + " "  + x.PersonMiddleName + " " + x.PersonLastName,
                    x.SupposeOppose,
                    Convert.ToDateTime(x.AuthorizedDate).ToShortDateString(),
                    Convert.ToDateTime(x.NonExpenditureDate).ToShortDateString()
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Ballot Issues
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBallotIssues()
        {
            //IList<BallotIssues> lstBallotIssues = new List<BallotIssues>();
            //BallotIssues objBallotIssues;

            //objBallotIssues = new BallotIssues();
            //objBallotIssues.BallotId = "1";
            //objBallotIssues.BallotIssue = "Ballot Issue 1";
            //objBallotIssues.SupportOppose = "Support";
            //lstBallotIssues.Add(objBallotIssues);

            //objBallotIssues = new BallotIssues();
            //objBallotIssues.BallotId = "2";
            //objBallotIssues.BallotIssue = "Ballot Issue 2";
            //objBallotIssues.SupportOppose = "Oppose";
            //lstBallotIssues.Add(objBallotIssues);
            try
            {
                IList<TreasBallotIssuesModel> lstTreasBallotIssuesModel = new List<TreasBallotIssuesModel>();
                lstTreasBallotIssuesModel = objTreasurerProfileBroker.GetTreasurerBallotIssuesContactBroker(Session["TreaCommID"].ToString());
                Session["BallotIssues"] = lstTreasBallotIssuesModel;

                return Json(new
                {
                    aaData = lstTreasBallotIssuesModel.Select(x => new[] { 
                    //x.BallotId, 
                    x.BallotIssues,
                    x.SupposeOppose
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        #region Get Address Data
        /// <summary>
        /// Get Address Data
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAddressData(string personID)
        {
            try
            {
                String strSiteId = String.Empty;
                String strPersonId = String.Empty;
                if (personID == null || personID == "")
                {
                    strPersonId = Session["PersonId"].ToString();
                }
                else
                {
                    strPersonId = personID;
                }

                IList<ShowAddressModel> lstShowAddressModel = new List<ShowAddressModel>();

                lstShowAddressModel = objCandidateProfileBroker.GetAddressDataResponse(strPersonId);

                Session["ShowAddress"] = lstShowAddressModel;

                return Json(new
                {
                    aaData = lstShowAddressModel.Select(x => new[] {
                    x.AddressId,
                    "",
                    x.BestContractDesc,
                    x.AddressTypeDesc,
                    x.AddressStreetName,
                    x.AddressCity,
                    x.AddressState,
                    x.AddressZip
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        #endregion Get Address Data

        /// <summary>
        /// Show Contract
        /// </summary>
        /// <returns></returns>
        public JsonResult GetShowContact(String personID)
        {
            try
            {
                IList<ShowContactModel> lstShowContactModel = new List<ShowContactModel>();
                ShowContactModel objShowContactModel;
                String strPersonId = "";

                if (personID == null || personID == "")
                {
                    strPersonId = Session["PersonId"].ToString();
                }
                else
                {
                    strPersonId = personID;
                }

                var results = objCandidateProfileBroker.GetContactDataResponse(strPersonId);

                foreach (var item in results)
                {
                    if (item != null)
                    {
                        objShowContactModel = new ShowContactModel();
                        if (item.ContactTypeDescription != "Fax" && item.ContactTypeDescription != "URL")
                        {
                            objShowContactModel.ContractId = item.ContractId;
                            objShowContactModel.BestContactId = item.BestContactId;
                            objShowContactModel.BestContract_Desc = item.BestContract_Desc;
                            objShowContactModel.ContactTypeId = item.ContactTypeId;
                            //objShowContactModel.Phone = item.Phone;
                            if (item.Phone != "" && item.Phone != null)
                            {
                                String phone1 = item.Phone.Substring(0, 3);
                                String phone2 = item.Phone.Substring(3, 3);
                                String phone3 = item.Phone.Substring(6, 4);
                                objShowContactModel.Phone = phone1 + "-" + phone2 + "-" + phone3;
                            }
                            objShowContactModel.EmailAddress = item.EmailAddress;
                            lstShowContactModel.Add(objShowContactModel);
                        }
                    }
                }

                Session["ShowContact"] = lstShowContactModel;

                return Json(new
                {
                    aaData = lstShowContactModel.Select(x => new[] {
                    x.ContractId,
                    x.ContactTypeId,
                    x.BestContactId,
                    "",
                    x.BestContract_Desc,
                    x.Phone,
                    x.EmailAddress,
                    x.FAX,
                    x.URL
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// DeleteAddress
        /// </summary>
        /// <param name="txtAddressID"></param>
        /// <returns></returns>
        public JsonResult DeleteAddress(String txtAddressID)
        {
            try
            {
                String strPersonId = Session["PersonId"].ToString();

                AddressDataModel objAddressDataModel = new AddressDataModel();
                objAddressDataModel.AddressId = txtAddressID;
                objAddressDataModel.ModifiedBy = "SBasireddy";

                var results = objCandidateProfileBroker.DeleteAddressDataResponse(objAddressDataModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// DeleteContact
        /// </summary>
        /// <param name="txtContactId"></param>
        /// <returns></returns>
        public JsonResult DeleteContact(String txtContactId)
        {
            try
            {
                String strPersonId = Session["PersonId"].ToString();

                ShowContactModel objShowContactModel = new ShowContactModel();
                objShowContactModel.ContractId = txtContactId;
                objShowContactModel.ModifiedBy = "SBasireddy";

                var results = objCandidateProfileBroker.DeleteContactDataResponse(objShowContactModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        public JsonResult DeleteDepositoryBankTreasurer(String strBankId)
        {
            try
            {
                // Check that 1 Bank required.
                String strPersonId = Session["PersonId"].ToString();

                //IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();
                //lstDepositoryBankInfoModel = objCandidateProfileBroker.GetDepositoryBankInfoDataResponse(strPersonId);

                //if (lstDepositoryBankInfoModel.Count > 1)
                //{
                DepositoryBankInfoModel objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                objDepositoryBankInfoModel.BankId = strBankId;
                objDepositoryBankInfoModel.ModifiedBy = "PAgarwal";

                var results = objCandidateProfileBroker.DeleteDepositoryBankInfoResponse(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json(results, JsonRequestBehavior.AllowGet);
                //}
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// AddAddress
        /// </summary>
        /// <param name="lstAddressType"></param>
        /// <param name="lstBestContact"></param>
        /// <param name="txtStreetNum"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtAddr1"></param>
        /// <param name="txtAddr2"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip"></param>
        /// <param name="txtZip4"></param>
        /// <returns></returns>
        public JsonResult AddAddress(String lstAddressType, String lstBestContact, String txtStreetName,
            String txtCity, String txtState, String txtZip)
        {
            try
            {
                if (lstAddressType == "- Select -")
                    lstAddressType = "";
                if (lstBestContact == "- Select -")
                    lstBestContact = "";

                String strPersonId = Session["PersonId"].ToString();

                AddressDataModel objAddressDataModel = new AddressDataModel();
                objAddressDataModel.AddressTypeId = lstAddressType;
                objAddressDataModel.PersonId = strPersonId;
                objAddressDataModel.BestContactId = lstBestContact;
                objAddressDataModel.AddressStreetName = txtStreetName;
                objAddressDataModel.AddresssCity = txtCity;
                objAddressDataModel.AddressState = txtState;
                objAddressDataModel.AddressZip = txtZip;
                objAddressDataModel.CreatedBy = "Admin"; // Change later

                Boolean result = objCandidateProfileBroker.AddAddressDataResponse(objAddressDataModel);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// UpdateAddress
        /// </summary>
        /// <param name="strAddressId"></param>
        /// <param name="lstAddressType"></param>
        /// <param name="lstBestContact"></param>
        /// <param name="txtStreetNum"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtAddr1"></param>
        /// <param name="txtAddr2"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip"></param>
        /// <param name="txtZip4"></param>
        /// <returns></returns>
        public JsonResult UpdateAddress(String strAddressId, String lstAddressType, String lstBestContact, String txtStreetName,
            String txtCity, String txtState, String txtZip)
        {
            //if (lstAddressType != "- Select -")
            //    lstAddressType = "";
            //if (lstBestContact != "- Select -")
            //    lstBestContact = "";
            try
            {
                AddressDataModel objAddressDataModel = new AddressDataModel();
                objAddressDataModel.AddressId = strAddressId;
                objAddressDataModel.AddressTypeId = lstAddressType;
                objAddressDataModel.BestContactId = lstBestContact;
                objAddressDataModel.AddressStreetName = txtStreetName;
                objAddressDataModel.AddresssCity = txtCity;
                objAddressDataModel.AddressState = txtState;
                objAddressDataModel.AddressZip = txtZip;
                objAddressDataModel.ModifiedBy = "Admin"; // Change later

                Boolean result = objCandidateProfileBroker.UpdateAddressDataResponse(objAddressDataModel);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Add Contact
        /// </summary>
        /// <param name="lstBestContact"></param>
        /// <param name="txtTitle"></param>
        /// <param name="txtPrefix"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMiddleName"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtSuffix"></param>
        /// <param name="lstContactType"></param>
        /// <param name="txtContactValue"></param>
        /// <returns></returns>
        public JsonResult AddContactData(String lstBestContact, String txtContactPhone, String txtContactEmail, String tabName)
        {
            try
            {
                String strPersonId = Session["PersonId"].ToString();

                Boolean results = false;

                ShowContactModel objShowContactModel = new ShowContactModel();
                objShowContactModel.PersonId = strPersonId;
                objShowContactModel.BestContactId = lstBestContact;
                objShowContactModel.ContactTypeId = "1";
                objShowContactModel.Phone = txtContactPhone;
                objShowContactModel.EmailAddress = txtContactEmail;
                objShowContactModel.CreatedBy = "Admin"; // Testing only....
                results = objCandidateProfileBroker.AddContactDataResponse(objShowContactModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// AddSubTreasurerData
        /// </summary>
        /// <param name="txtStartDate"></param>
        /// <param name="lstStatus"></param>
        /// <param name="txtPrefix"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtFirstName"></param>
        /// <param name="txtMiddleName"></param>
        /// <param name="txtSuffix"></param>
        /// <returns></returns>
        public JsonResult AddSubTreasurerData(String txtStartDate, String lstStatus, String txtPrefix,
            String txtLastName, String txtFirstName, String txtMiddleName, String txtSuffix)
        {
            try
            {
                if (lstStatus == "1")
                    lstStatus = "A";
                else
                    lstStatus = "I";

                SubTreasurerPersonModel objSubTreasurerPersonModel = new SubTreasurerPersonModel();
                objSubTreasurerPersonModel.StateDate = txtStartDate;
                objSubTreasurerPersonModel.RStatus = lstStatus;
                objSubTreasurerPersonModel.Preffix = txtPrefix;
                objSubTreasurerPersonModel.LastName = txtLastName;
                objSubTreasurerPersonModel.FirstName = txtFirstName;
                objSubTreasurerPersonModel.MiddleName = txtMiddleName;
                objSubTreasurerPersonModel.Suffix = txtSuffix;
                objSubTreasurerPersonModel.PersonId = Session["PersonId"].ToString();
                objSubTreasurerPersonModel.TreasurerId = Session["TransIDValue"].ToString();
                objSubTreasurerPersonModel.CreatedBy = "PAgarwal";

                var results = objTreasurerProfileBroker.AddSubTreasurerDataResponse(objSubTreasurerPersonModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// AddDepositoryBank
        /// </summary>
        /// <param name="txtDepositortyBankName"></param>
        /// <param name="txtStreetNum"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtLastName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip"></param>
        /// <param name="txtZip4"></param>
        /// <returns></returns>
        public JsonResult AddDepositoryBankInfoTreasurer(String txtDepositortyBankName, String lstAccountType, 
            String txtStreetName, String txtCity, String txtState, String txtZip)
        {
            try
            {
                IList<TreasDepositoryBankInformationModel> lstDepositoryBankInfoModel = new List<TreasDepositoryBankInformationModel>();
                lstDepositoryBankInfoModel = (IList<TreasDepositoryBankInformationModel>)Session["DepositoryBankInfo"];

                if (lstAccountType == "- Select -")
                    lstAccountType = "";


                String strPersonId = Session["PersonId"].ToString();

                TreasDepositoryBankInformationModel objDepositoryBankInfoModel = new TreasDepositoryBankInformationModel();
                objDepositoryBankInfoModel.PERSON_ID = strPersonId;
                objDepositoryBankInfoModel.COMM_ID = lstDepositoryBankInfoModel[0].COMM_ID;
                objDepositoryBankInfoModel.BankName = txtDepositortyBankName;
                objDepositoryBankInfoModel.BankAccountTypeID = lstAccountType;
                objDepositoryBankInfoModel.AddrStrName = txtStreetName;
                objDepositoryBankInfoModel.AddrCity = txtCity;
                objDepositoryBankInfoModel.AddrState = txtState;
                objDepositoryBankInfoModel.AddrZip = txtZip;
                objDepositoryBankInfoModel.CreatedBy = "Pagarwal";

                Boolean results = objCandidateProfileBroker.AddDepositoryBankInfoResponseTrans(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }


        /// <summary>
        /// UpdateDeposotoryBank
        /// </summary>
        /// <param name="strBankId"></param>
        /// <param name="strAddressId"></param>
        /// <param name="txtDepositortyBankName"></param>
        /// <param name="txtStreetNum"></param>
        /// <param name="txtStreetName"></param>
        /// <param name="txtCity"></param>
        /// <param name="txtState"></param>
        /// <param name="txtZip"></param>
        /// <param name="txtZip4"></param>
        /// <returns></returns>
        public JsonResult UpdateDeposotoryBank(String strBankId, String txtDepositortyBankName,
            String lstAccountType, String txtStreetName, String txtCity, String txtState, String txtZip)
        {
            try
            {
                IList<TreasDepositoryBankInformationModel> lstDepositoryBankInfoModel = new List<TreasDepositoryBankInformationModel>();
                lstDepositoryBankInfoModel = (IList<TreasDepositoryBankInformationModel>)Session["DepositoryBankInfo"];
                var objShowAddress = (from a in lstDepositoryBankInfoModel
                                      where a.BankID == strBankId
                                      select a).ToList();
                lstDepositoryBankInfoModel = (IList<TreasDepositoryBankInformationModel>)objShowAddress;

                DepositoryBankInfoModel objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                objDepositoryBankInfoModel.AddressId = lstDepositoryBankInfoModel[0].ADDR_ID;
                objDepositoryBankInfoModel.BankId = strBankId;
                objDepositoryBankInfoModel.DepositoryBankName = txtDepositortyBankName;
                objDepositoryBankInfoModel.BankAccountTypeId = lstAccountType;
                objDepositoryBankInfoModel.StreetName = txtStreetName;
                objDepositoryBankInfoModel.City = txtCity;
                objDepositoryBankInfoModel.State = txtState;
                objDepositoryBankInfoModel.Zip = txtZip;
                objDepositoryBankInfoModel.ModifiedBy = "pagarwal"; // Testing only...            

                Boolean results = objCandidateProfileBroker.UpdateDepositoryBankInfoResponse(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// EditContactData
        /// </summary>
        /// <param name="strContactId"></param>
        /// <param name="lstBestContact"></param>
        /// <param name="lstContactType"></param>
        /// <param name="txtPhone"></param>
        /// <param name="txtEmail"></param>
        /// <param name="txtFax"></param>
        /// <param name="txtURL"></param>
        /// <returns></returns>
        public JsonResult EditContactData(String contactID, String lstBestContact, String txtPhone, String txtEmail)
        {
            try
            {
                ShowContactModel objShowContactModel = new ShowContactModel();
                objShowContactModel.ContractId = contactID;
                objShowContactModel.BestContactId = lstBestContact;
                objShowContactModel.Phone = txtPhone;
                objShowContactModel.EmailAddress = txtEmail;
                objShowContactModel.ModifiedBy = "Pagarwal"; //Session["UserName"].ToString();

                Boolean results = objCandidateProfileBroker.UpdateContactDataResponse(objShowContactModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
        
        /// <summary>
        /// Add Authorized to Sign check
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="status"></param>
        /// <param name="endDate"></param>
        /// <param name="prefix"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public JsonResult AddAuthorizedToSignCheck(String commID, String startDate, String status, String endDate, String prefix,
                                                    String firstName, String middleName, String lastName, String suffix)
        {
            try
            {
                AuthorizedToSignCheckModel objAuthorizedToSignCheckModel = new AuthorizedToSignCheckModel();
                objAuthorizedToSignCheckModel.CommID = commID;
                objAuthorizedToSignCheckModel.StartDate = startDate;
                objAuthorizedToSignCheckModel.Status = status;
                objAuthorizedToSignCheckModel.EndDate = endDate;
                objAuthorizedToSignCheckModel.Prefix = prefix;
                objAuthorizedToSignCheckModel.FirstName = firstName;
                objAuthorizedToSignCheckModel.MiddleName = middleName;
                objAuthorizedToSignCheckModel.LastName = lastName;
                objAuthorizedToSignCheckModel.Suffix = suffix;
                objAuthorizedToSignCheckModel.Signature = null;
                objAuthorizedToSignCheckModel.CreatedBy = "Admin";

                Boolean results = objTreasurerProfileBroker.AddAuthorizedToSignCheckBroker(objAuthorizedToSignCheckModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "TreasurerProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}