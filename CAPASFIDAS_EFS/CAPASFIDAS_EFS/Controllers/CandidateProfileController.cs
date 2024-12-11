using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Broker;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class CandidateProfileController : Controller
    {

        // Create Broker Object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        TreasurerProfileBroker objTreasurerProfileBroker = new TreasurerProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /CandidateProfile/
        public ActionResult CandidateProfile()
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
                    //Session["PersonId"] = "18099"; // Testing only replace with main session.
                    //Session["PersonId"] = "23161";
                    String strSiteId = String.Empty;
                    String strPersonId = Session["PersonId"].ToString();

                    // Get Header Data
                    IList<CandidateHeaderDataModel> lstCandidateHeaderDataModel = new List<CandidateHeaderDataModel>();

                    lstCandidateHeaderDataModel = objCandidateProfileBroker.GetCandidateHeaderDataResponse(strPersonId);

                    if (lstCandidateHeaderDataModel.Count != 0)
                    {
                        var results = lstCandidateHeaderDataModel.ToList().First();

                        ViewBag.FilerType = results.FilerType;
                        ViewBag.Office = results.Office;
                        if (results.District == "0")
                            ViewBag.District = "";
                        else
                            ViewBag.District = results.District;
                        ViewBag.Municipality = results.Municipality;
                        ViewBag.ElectionYear = results.ElectionYear;
                        ViewBag.CandidateId = results.CandidateId;
                        Session["CandidateId"] = results.CandidateId.ToString();
                        if (!String.IsNullOrEmpty(results.SSN))
                            ViewBag.SSN = "Yes";
                        else
                            ViewBag.SSN = "No";
                        ViewBag.PoliticalParty = results.PoliticalParty;
                        ViewBag.RegistrationDate = results.RegistrationDate;
                        if (results.Status == "I")
                            ViewBag.Status = "In-Active";
                        if (results.Status == "A")
                            ViewBag.Status = "Active";
                        if (results.TerminationDate.Trim() == "01/01/1900")
                            ViewBag.TerminationDate = "";
                        else
                            ViewBag.TerminationDate = results.TerminationDate;
                        ViewBag.Prefix = results.Prefix;
                        ViewBag.LastName = results.LastName;
                        ViewBag.FirstName = results.FirstName;
                        ViewBag.MiddleName = results.MiddleName;
                        ViewBag.Suffix = results.Suffix;
                    }

                    IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();
                    lstBankAccountTypesModel = objCandidateProfileBroker.GetBankAccountTypesResponse();
                    ViewData["lstAccountType"] = new SelectList(lstBankAccountTypesModel, "AccountTypeId", "AccountTypeDesc");

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

                }

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();
                lstDepositoryBankInfoModel = objCandidateProfileBroker.GetDepositoryBankInfoDataResponse(Session["PersonId"].ToString());

                Session["DepositoryBankInfo"] = lstDepositoryBankInfoModel;

                return Json(new
                {
                    aaData = lstDepositoryBankInfoModel.Select(x => new[] {
                    x.BankId,
                    "",
                    x.DepositoryBankName,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip
                })
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
            try
            {
                IList<AuthSignChecks> lstAuthSignChecks = new List<AuthSignChecks>();
                AuthSignChecks objAuthSignChecks;

                objAuthSignChecks = new AuthSignChecks();
                objAuthSignChecks.ContactId = "1";
                objAuthSignChecks.Prefix = "";
                objAuthSignChecks.LastName = "Smith";
                objAuthSignChecks.FirstName = "John";
                objAuthSignChecks.MI = "";
                objAuthSignChecks.Suffix = "";
                lstAuthSignChecks.Add(objAuthSignChecks);

                objAuthSignChecks = new AuthSignChecks();
                objAuthSignChecks.ContactId = "2";
                objAuthSignChecks.Prefix = "";
                objAuthSignChecks.LastName = "Kevin";
                objAuthSignChecks.FirstName = "Smith";
                objAuthSignChecks.MI = "T";
                objAuthSignChecks.Suffix = "";
                lstAuthSignChecks.Add(objAuthSignChecks);

                Session["AuthSignChecks"] = lstAuthSignChecks;

                return Json(new
                {
                    aaData = lstAuthSignChecks.Select(x => new[] {
                    x.ContactId,
                    x.Prefix,
                    x.LastName,
                    x.FirstName,
                    x.MI,
                    x.Suffix
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        /// <summary>
        /// GetAuthCommittees
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAuthCommittees()
        {
            try
            {
                String strPersonId = Session["PersonId"].ToString();

                IList<CandAuthCommitteesModel> lstCandAuthCommitteesModel = new List<CandAuthCommitteesModel>();

                var results = objCandidateProfileBroker.GetCandAuthCommitteesDataResponse(strPersonId);

                results = results.Where(x => x.Status == "A").Select(x => { x.Status = "Active"; return x; }).ToList();

                CandAuthCommitteesModel objCandAuthCommitteesModel;
                foreach (var item in results)
                {
                    if (item != null)
                    {
                        objCandAuthCommitteesModel = new CandAuthCommitteesModel();
                        objCandAuthCommitteesModel.FilerId = item.FilerId;
                        objCandAuthCommitteesModel.CommitteeName = item.CommitteeName;
                        objCandAuthCommitteesModel.Status = item.Status;
                        objCandAuthCommitteesModel.RegistrationDate = item.RegistrationDate;
                        if (item.TerminationDate != null)
                        {
                            if (item.TerminationDate.Trim() == "01/01/1900")
                                objCandAuthCommitteesModel.TerminationDate = "";
                            else
                                objCandAuthCommitteesModel.TerminationDate = item.TerminationDate;
                        }
                        else
                        {
                            objCandAuthCommitteesModel.TerminationDate = "";
                        }

                        lstCandAuthCommitteesModel.Add(objCandAuthCommitteesModel);
                    }
                }

                Session["AuthCommittees"] = lstCandAuthCommitteesModel;

                return Json(new
                {
                    aaData = lstCandAuthCommitteesModel.Select(x => new[] {
                    x.FilerId,
                    x.CommitteeName,
                    x.Status,
                    x.RegistrationDate.Trim(),
                    x.TerminationDate.Trim()
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        public JsonResult DeleteDepositoryBank(String strBankId)
        {
            try
            {
                // Check that 1 Bank required.
                String strPersonId = Session["PersonId"].ToString();

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();
                lstDepositoryBankInfoModel = (IList<DepositoryBankInfoModel>)Session["DepositoryBankInfo"];
                var objShowAddress = (from a in lstDepositoryBankInfoModel
                                      where a.BankId == strBankId
                                      select a).ToList();
                lstDepositoryBankInfoModel = (IList<DepositoryBankInfoModel>)objShowAddress;

                DepositoryBankInfoModel objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                objDepositoryBankInfoModel.AddressId = lstDepositoryBankInfoModel[0].AddressId;
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();
                lstDepositoryBankInfoModel = (IList<DepositoryBankInfoModel>)Session["DepositoryBankInfo"];

                if (lstAccountType == "- Select -")
                    lstAccountType = "";


                String strPersonId = Session["PersonId"].ToString();

                DepositoryBankInfoModel objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                objDepositoryBankInfoModel.PersonId = strPersonId;
                objDepositoryBankInfoModel.CandidateId = lstDepositoryBankInfoModel[0].CandidateId;
                objDepositoryBankInfoModel.DepositoryBankName = txtDepositortyBankName;
                objDepositoryBankInfoModel.BankAccountTypeId = lstAccountType;
                objDepositoryBankInfoModel.StreetName = txtStreetName;
                objDepositoryBankInfoModel.City = txtCity;
                objDepositoryBankInfoModel.State = txtState;
                objDepositoryBankInfoModel.Zip = txtZip;
                objDepositoryBankInfoModel.CreatedBy = "Pagarwal";

                Boolean results = objCandidateProfileBroker.AddDepositoryBankInfoResponse(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "CandidateProfileController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
    }
}