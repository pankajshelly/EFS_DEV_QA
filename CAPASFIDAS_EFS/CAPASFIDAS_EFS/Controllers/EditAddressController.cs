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
    public class EditAddressController : Controller
    {
        // Create Broker Object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /EditAddress/
        public ActionResult EditAddress()
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
                    Session["PersonId"] = "23161";

                    IList<ShowAddressModel> lstShowAddressObject = new List<ShowAddressModel>();
                    if (Request.QueryString["adderssID"] != null)
                    {
                        Session["AddEditAddressID"] = Request.QueryString["adderssID"].ToString();
                        Session["BestContactDescription"] = Request.QueryString["bestContactDesc"].ToString();
                        IList<ShowAddressModel> lstShowAddress = new List<ShowAddressModel>();
                        lstShowAddress = (IList<ShowAddressModel>)Session["ShowAddress"];
                        var objShowAddress = (from a in lstShowAddress
                                              where a.AddressId == Session["AddEditAddressID"].ToString() &&
                                              a.BestContractDesc == Session["BestContactDescription"].ToString()
                                              select a).ToList();
                        lstShowAddressObject = (IList<ShowAddressModel>)objShowAddress;
                        ViewBag.txtAddressId = lstShowAddressObject[0].AddressId.ToString();
                        ViewBag.txtStreetNum = lstShowAddressObject[0].AddressStreetNumber.ToString();
                        ViewBag.txtStreetName = lstShowAddressObject[0].AddressStreetName.ToString();
                        ViewBag.txtAddr1 = lstShowAddressObject[0].AddressAddress1.ToString();
                        ViewBag.txtAddr2 = lstShowAddressObject[0].AddressAddress2.ToString();
                        ViewBag.txtCity = lstShowAddressObject[0].AddressCity.ToString();
                        ViewBag.txtState = lstShowAddressObject[0].AddressState.ToString();
                        ViewBag.txtZip = lstShowAddressObject[0].AddressZip.ToString();
                        ViewBag.txtZip4 = lstShowAddressObject[0].AddressZip4.ToString();

                        //Bind Adders Type
                        IList<AddressTypesModel> lstAddressTypesModel = new List<AddressTypesModel>();

                        lstAddressTypesModel = objCandidateProfileBroker.GetAddressTypesDataResponse();

                        ViewData["lstAddressType"] = new SelectList(lstAddressTypesModel, "AddressTypeId", "AddressTypeDescription", lstShowAddressObject[0].AddressTypeId.ToString());

                        //Bind Best Contact
                        IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();

                        lstBestContactTypesModel = objCandidateProfileBroker.GetBestContactTypesDataResponse();

                        ViewData["lstBestContact"] = new SelectList(lstBestContactTypesModel, "BestContactTypeId", "BestContactTypeDesc", lstShowAddressObject[0].BestContactId.ToString());

                    }
                }
                
                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditAddressController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }

        /// <summary>
        /// Update Address
        /// </summary>
        /// <param name="txtAgencyDesc"></param>
        /// <returns></returns>
        public JsonResult UpdateAddress(String txtAddressId, String lstAddressType, String txtStreetNum, String txtStreetName,
                                        String txtAddr1, String txtAddr2, String txtCity,
                                        String txtState, String txtZip, String txtZip4, String lstBestContact)
        {
            try
            {
                String strSiteId = String.Empty;
                String strPersonId = Session["PersonId"].ToString();

                if (lstAddressType == "- Select -")
                    lstAddressType = "";
                if (lstBestContact == "- Select -")
                    lstBestContact = "";

                AddressDataModel objAddressDataModel = new AddressDataModel();
                objAddressDataModel.AddressId = txtAddressId;
                objAddressDataModel.PersonId = strPersonId;
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
                objAddressDataModel.ModifiedBy = "SBasireddy"; // Testing only.

                var results = objCandidateProfileBroker.UpdateAddressDataResponse(objAddressDataModel);
                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditAddressController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}