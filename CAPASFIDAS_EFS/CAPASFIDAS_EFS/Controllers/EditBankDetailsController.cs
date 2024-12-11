using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Broker;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class EditBankDetailsController : Controller
    {
        // Create Broker object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //
        // GET: /EditBankDetails/
        public ActionResult EditBankDetails()
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
                    IList<DepositoryBankInfoModel> lstDepositoryBankInfoModelObject = new List<DepositoryBankInfoModel>();
                    if (Request.QueryString["bankID"] != null)
                    {
                        if (Request.QueryString["rowNumber"] != null)
                        {
                            Session["rowNumber"] = Request.QueryString["rowNumber"].ToString();
                        }
                        Session["AddEditBankID"] = Request.QueryString["bankID"].ToString();
                        IList<DepositoryBankInfoModel> lstDepositoryBankInfoModel = new List<DepositoryBankInfoModel>();
                        lstDepositoryBankInfoModel = (IList<DepositoryBankInfoModel>)Session["DepositoryBankInfo"];
                        var objShowAddress = (from a in lstDepositoryBankInfoModel
                                              where a.BankId == Session["AddEditBankID"].ToString()
                                              select a).ToList();
                        lstDepositoryBankInfoModelObject = (IList<DepositoryBankInfoModel>)objShowAddress;
                        ViewBag.BankId = lstDepositoryBankInfoModelObject[0].BankId;
                        ViewBag.AddressId = lstDepositoryBankInfoModelObject[0].AddressId;
                        ViewBag.txtDepositortyBankName = lstDepositoryBankInfoModelObject[0].DepositoryBankName.ToString();
                        ViewBag.txtStreetNum = lstDepositoryBankInfoModelObject[0].StreetNumber.ToString();
                        ViewBag.txtStreetName = lstDepositoryBankInfoModelObject[0].StreetName.ToString();
                        ViewBag.txtCity = lstDepositoryBankInfoModelObject[0].City.ToString();
                        ViewBag.txtState = lstDepositoryBankInfoModelObject[0].State.ToString();
                        ViewBag.txtZip = lstDepositoryBankInfoModelObject[0].Zip.ToString();
                        ViewBag.txtZip4 = lstDepositoryBankInfoModelObject[0].Zip4.ToString();

                        IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();
                        lstBankAccountTypesModel = objCandidateProfileBroker.GetBankAccountTypesResponse();
                        ViewData["lstAccountType"] = new SelectList(lstBankAccountTypesModel, "AccountTypeId", "AccountTypeDesc", lstDepositoryBankInfoModelObject[0].BankAccountTypeId);
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditBankDetailsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult UpdateDeposotoryBank(String strBankId, String strAddressId, String txtDepositortyBankName,
            String lstAccountType, String txtStreetNum, String txtStreetName, String txtCity, String txtState, 
            String txtZip, String txtZip4)
        {
            try
            {
                DepositoryBankInfoModel objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                objDepositoryBankInfoModel.AddressId = strAddressId;
                objDepositoryBankInfoModel.BankId = strBankId;
                objDepositoryBankInfoModel.DepositoryBankName = txtDepositortyBankName;
                objDepositoryBankInfoModel.BankAccountTypeId = lstAccountType;
                objDepositoryBankInfoModel.StreetNumber = txtStreetNum;
                objDepositoryBankInfoModel.StreetName = txtStreetName;
                objDepositoryBankInfoModel.City = txtCity;
                objDepositoryBankInfoModel.State = txtState;
                objDepositoryBankInfoModel.Zip = txtZip;
                objDepositoryBankInfoModel.Zip4 = txtZip4;
                objDepositoryBankInfoModel.ModifiedBy = "SBasireddy"; // Testing only...

                Boolean results = objCandidateProfileBroker.UpdateDepositoryBankInfoResponse(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditBankDetailsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}