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
    public class AddTransDepositoryBankInfoController : Controller
    {
        // Create Broker object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /AddTransDepositoryBankInfo/
        public ActionResult AddTransDepositoryBankInfo()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddTransDepositoryBankInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult AddDepositoryBankInfoTreasurer(String txtDepositortyBankName, String lstAccountType, String txtStreetNum,
            String txtStreetName, String txtLastName, String txtCity, String txtState, String txtZip, String txtZip4)
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
                objDepositoryBankInfoModel.AddrNum = txtStreetNum;
                objDepositoryBankInfoModel.AddrStrName = txtStreetName;
                objDepositoryBankInfoModel.AddrCity = txtCity;
                objDepositoryBankInfoModel.AddrState = txtState;
                objDepositoryBankInfoModel.AddrZip = txtZip;
                objDepositoryBankInfoModel.AddrZip4 = txtZip4;
                objDepositoryBankInfoModel.CreatedBy = "Pagarwal";

                Boolean results = objCandidateProfileBroker.AddDepositoryBankInfoResponseTrans(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddTransDepositoryBankInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }


	}
}