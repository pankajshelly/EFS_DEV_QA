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
    public class EditTransDepositoryBankInfoController : Controller
    {
        // Create Broker object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /EditTransDepositoryBankInfo/
        public ActionResult EditTransDepositoryBankInfo()
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
                    if (Request.QueryString["bankID"] != null)
                    {
                        if (Request.QueryString["rowNumber"] != null)
                        {
                            Session["rowNumber"] = Request.QueryString["rowNumber"].ToString();
                        }
                        Session["AddEditBankID"] = Request.QueryString["bankID"].ToString();
                        IList<TreasDepositoryBankInformationModel> lstDepositoryBankInfoModel = new List<TreasDepositoryBankInformationModel>();
                        lstDepositoryBankInfoModel = (IList<TreasDepositoryBankInformationModel>)Session["DepositoryBankInfo"];
                        var objShowAddress = (from a in lstDepositoryBankInfoModel
                                              where a.BankID == Session["AddEditBankID"].ToString()
                                              select a).ToList();
                        lstDepositoryBankInfoModel = (IList<TreasDepositoryBankInformationModel>)objShowAddress;
                        ViewBag.BankId = lstDepositoryBankInfoModel[0].BankID;
                        ViewBag.AddressId = lstDepositoryBankInfoModel[0].ADDR_ID;
                        ViewBag.PersonId = lstDepositoryBankInfoModel[0].PERSON_ID;
                        ViewBag.txtDepositortyBankName = lstDepositoryBankInfoModel[0].BankName.ToString();
                        ViewBag.txtStreetNum = lstDepositoryBankInfoModel[0].AddrNum.ToString();
                        ViewBag.txtStreetName = lstDepositoryBankInfoModel[0].AddrStrName.ToString();
                        ViewBag.txtCity = lstDepositoryBankInfoModel[0].AddrCity.ToString();
                        ViewBag.txtState = lstDepositoryBankInfoModel[0].AddrState.ToString();
                        ViewBag.txtZip = lstDepositoryBankInfoModel[0].AddrZip.ToString();
                        ViewBag.txtZip4 = lstDepositoryBankInfoModel[0].AddrZip4.ToString();

                        IList<BankAccountTypesModel> lstBankAccountTypesModel = new List<BankAccountTypesModel>();
                        lstBankAccountTypesModel = objCandidateProfileBroker.GetBankAccountTypesResponse();
                        ViewData["lstAccountType"] = new SelectList(lstBankAccountTypesModel, "AccountTypeId", "AccountTypeDesc");
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditTransDepositoryBankInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                objDepositoryBankInfoModel.ModifiedBy = "pagarwal"; // Testing only...            

                Boolean results = objCandidateProfileBroker.UpdateDepositoryBankInfoResponse(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditTransDepositoryBankInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
	}
}