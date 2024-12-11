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
    public class AddEditAddressController : Controller
    {
        // Create Broker Object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /AddEditAddress/
        public ActionResult AddEditAddress()
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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddEditAddressController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult AddAddress(String lstAddressType, String lstBestContact, String txtStreetNum,
            String txtStreetName, String txtAddr1, String txtAddr2, String txtCity, String txtState, String txtZip,
            String txtZip4)
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
                objAddressDataModel.AddressStreetNumber = txtStreetNum;
                objAddressDataModel.AddressStreetName = txtStreetName;
                objAddressDataModel.AddressAddress1 = txtAddr1;
                objAddressDataModel.AddressAddress2 = txtAddr2;
                objAddressDataModel.AddresssCity = txtCity;
                objAddressDataModel.AddressState = txtState;
                objAddressDataModel.AddressZip = txtZip;
                objAddressDataModel.AddressZip4 = txtZip4;
                objAddressDataModel.CreatedBy = "SBasireddy"; // Change later

                Boolean result = objCandidateProfileBroker.AddAddressDataResponse(objAddressDataModel);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddEditAddressController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult UpdateAddress(String strAddressId, String lstAddressType, String lstBestContact, String txtStreetNum,
            String txtStreetName, String txtAddr1, String txtAddr2, String txtCity, String txtState, String txtZip,
            String txtZip4)
        {
            try
            {
                if (lstAddressType != "- Select -")
                    lstAddressType = "";
                if (lstBestContact != "- Select -")
                    lstBestContact = "";

                AddressDataModel objAddressDataModel = new AddressDataModel();
                objAddressDataModel.AddressId = strAddressId;
                objAddressDataModel.AddressTypeId = lstAddressType;
                objAddressDataModel.BestContactId = lstBestContact;
                objAddressDataModel.AddressStreetNumber = txtStreetNum;
                objAddressDataModel.AddressStreetName = txtStreetName;
                objAddressDataModel.AddressAddress1 = txtAddr1;
                objAddressDataModel.AddressAddress2 = txtAddr2;
                objAddressDataModel.AddresssCity = txtCity;
                objAddressDataModel.AddressState = txtState;
                objAddressDataModel.AddressZip = txtZip;
                objAddressDataModel.AddressZip4 = txtZip4;
                objAddressDataModel.ModifiedBy = "SBasireddy"; // Change later

                Boolean result = objCandidateProfileBroker.UpdateAddressDataResponse(objAddressDataModel);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddEditAddressController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        /// <summary>
        /// DeleteAddress
        /// </summary>
        /// <param name="strAddressId"></param>
        /// <returns></returns>
        public JsonResult DeleteAddress(String strAddressId)
        {
            try
            {
                AddressDataModel objAddressDataModel = new AddressDataModel();
                objAddressDataModel.AddressId = strAddressId;
                objAddressDataModel.ModifiedBy = "SBasireddy"; // Change later

                Boolean result = objCandidateProfileBroker.DeleteAddressDataResponse(objAddressDataModel);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddEditAddressController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
    }
}