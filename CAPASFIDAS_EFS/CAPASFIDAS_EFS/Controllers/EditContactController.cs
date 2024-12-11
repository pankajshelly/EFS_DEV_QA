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
    public class EditContactController : Controller
    {
        // Create Broker object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /EditContact/
        public ActionResult EditContact()
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
                    IList<ShowContactModel> lstShowContactModelObject = new List<ShowContactModel>();
                    if (Request.QueryString["contactID"] != null)
                    {
                        //if (Request.QueryString["rowNumber"] != null)
                        //{
                        //    Session["rowNumber"] = Request.QueryString["rowNumber"].ToString();
                        //}


                        Session["EditcontactID"] = Request.QueryString["contactID"].ToString();
                        Session["BestContactId"] = Request.QueryString["BestContactId"].ToString();
                        Session["ContactTypeId"] = Request.QueryString["ContactTypeId"].ToString();

                        IList<ShowContactModel> lstShowContactModel = new List<ShowContactModel>();
                        lstShowContactModel = (IList<Models.ShowContactModel>)Session["ShowContact"];
                        var objShowAddress = (from a in lstShowContactModel
                                              where a.ContractId == Session["EditcontactID"].ToString() &&
                                              a.BestContactId == Session["BestContactId"].ToString() &&
                                              a.ContactTypeId == Session["ContactTypeId"].ToString()
                                              select a).ToList();
                        lstShowContactModelObject = (IList<ShowContactModel>)objShowAddress;
                        ViewBag.ContactId = lstShowContactModelObject[0].ContractId;
                        ViewBag.ContactTypeId = lstShowContactModelObject[0].ContactTypeId;
                        if (lstShowContactModelObject[0].Phone != null)
                            ViewBag.PHONE = Convert.ToString(lstShowContactModelObject[0].Phone);
                        else
                            ViewBag.PHONE = "";
                        if (lstShowContactModelObject[0].EmailAddress != null)
                            ViewBag.EMAIL = Convert.ToString(lstShowContactModelObject[0].EmailAddress);
                        else
                            ViewBag.EMAIL = "";
                        if (lstShowContactModelObject[0].FAX != null)
                            ViewBag.FAX = Convert.ToString(lstShowContactModelObject[0].FAX);
                        else
                            ViewBag.FAX = "";
                        if (lstShowContactModelObject[0].URL != null)
                            ViewBag.URL = Convert.ToString(lstShowContactModelObject[0].URL);
                        else
                            ViewBag.URL = "";

                        //Bind Best Contact
                        IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();

                        lstBestContactTypesModel = objCandidateProfileBroker.GetBestContactTypesDataResponse();

                        ViewData["lstBestContact"] = new SelectList(lstBestContactTypesModel, "BestContactTypeId", "BestContactTypeDesc", lstShowContactModelObject[0].BestContactId.ToString());

                        //Bind Contact Type
                        IList<ContactTypesModel> lstContactTypesModel = new List<ContactTypesModel>();

                        lstContactTypesModel = objCandidateProfileBroker.GetContactTypesDataResponse();

                        ViewData["lstContactType"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 1);
                        ViewData["lstContactType1"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 2);
                        ViewData["lstContactType2"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 3);
                        ViewData["lstContactType3"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 4);

                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditContactController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult EditContactData(String strContactId, String lstBestContact, 
                                    String lstContactType, String txtPhone, String txtEmail, String txtFax, String txtURL)
        {
            try
            {
                ShowContactModel objShowContactModel = new ShowContactModel();
                objShowContactModel.ContractId = strContactId;
                objShowContactModel.BestContactId = lstBestContact;
                objShowContactModel.ContactTypeId = lstContactType;
                objShowContactModel.Phone = txtPhone;
                objShowContactModel.EmailAddress = txtEmail;
                objShowContactModel.FAX = txtFax;
                objShowContactModel.URL = txtURL;
                objShowContactModel.ModifiedBy = "SBasireddy"; //Session["UserName"].ToString();

                Boolean results = objCandidateProfileBroker.UpdateContactDataResponse(objShowContactModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditContactController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}