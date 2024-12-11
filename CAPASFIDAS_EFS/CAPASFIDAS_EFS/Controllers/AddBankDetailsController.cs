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
    public class AddBankDetailsController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        // Create Broker object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        //
        // GET: /AddBankDetails/
        public ActionResult AddBankDetails()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddBankDetailsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult AddDepositoryBank(String txtDepositortyBankName, String lstAccountType, String txtStreetNum,
            String txtStreetName, String txtLastName, String txtCity, String txtState, String txtZip, String txtZip4)
        {
            try
            {
                IList<TreasDepositoryBankInformationModel> lstDepositoryBankInfoModel = new List<TreasDepositoryBankInformationModel>();
                //lstDepositoryBankInfoModel = (IList<TreasDepositoryBankInformationModel>)Session["DepositoryBankInfo"];

                String strCandidateId = String.Empty;

                if (Session["CandidateId"].ToString() != null)
                    strCandidateId = Session["CandidateId"].ToString();

                if (lstAccountType == "- Select -")
                    lstAccountType = "";


                String strPersonId = Session["PersonId"].ToString();

                DepositoryBankInfoModel objDepositoryBankInfoModel = new DepositoryBankInfoModel();
                objDepositoryBankInfoModel.PersonId = strPersonId;
                objDepositoryBankInfoModel.CandidateId = strCandidateId; // lstDepositoryBankInfoModel[0].COMM_ID;
                objDepositoryBankInfoModel.DepositoryBankName = txtDepositortyBankName;
                objDepositoryBankInfoModel.BankAccountTypeId = lstAccountType;
                objDepositoryBankInfoModel.StreetNumber = txtStreetNum;
                objDepositoryBankInfoModel.StreetName = txtStreetName;
                objDepositoryBankInfoModel.City = txtCity;
                objDepositoryBankInfoModel.State = txtState;
                objDepositoryBankInfoModel.Zip = txtZip;
                objDepositoryBankInfoModel.Zip4 = txtZip4;
                objDepositoryBankInfoModel.CreatedBy = "SBasireddy";

                Boolean results = objCandidateProfileBroker.AddDepositoryBankInfoResponse(objDepositoryBankInfoModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddBankDetailsController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        
    }
}