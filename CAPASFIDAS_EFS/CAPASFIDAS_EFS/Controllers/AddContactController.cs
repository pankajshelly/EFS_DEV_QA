using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class AddContactController : Controller
    {
        // Create Broker object
        CandidateProfileBroker objCandidateProfileBroker = new CandidateProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /AddContact/
        public ActionResult AddContact()
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

                    //Bind Best Contact
                    IList<BestContactTypesModel> lstBestContactTypesModel = new List<BestContactTypesModel>();

                    lstBestContactTypesModel = objCandidateProfileBroker.GetBestContactTypesDataResponse();

                    ViewData["lstBestContact"] = new SelectList(lstBestContactTypesModel, "BestContactTypeId", "BestContactTypeDesc", 0);

                    //Bind Contact Type
                    IList<ContactTypesModel> lstContactTypesModel = new List<ContactTypesModel>();

                    lstContactTypesModel = objCandidateProfileBroker.GetContactTypesDataResponse();

                    ViewData["lstContactType"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 1);
                    ViewData["lstContactType1"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 2);
                    ViewData["lstContactType2"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 3);
                    ViewData["lstContactType3"] = new SelectList(lstContactTypesModel, "ContactTypeId", "ContactTypeDescription", 4);

                }

                return View();
            }
            catch (Exception ex)
            {                
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddContactController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
        public JsonResult AddContactData(String lstBestContact, String lstContactType,
            String lstContactType1, String lstContactType2, String lstContactType3,
            String txtContactValue, String txtContactValue1, String txtContactValue2, String txtContactValue3)
        {
            try
            {
                String strPersonId = Session["PersonId"].ToString();

                Boolean results = false;

                ShowContactModel objShowContactModel = new ShowContactModel();
                objShowContactModel.PersonId = strPersonId;
                objShowContactModel.BestContactId = lstBestContact;
                objShowContactModel.CreatedBy = "SBasireddy"; // Testing only....
                using (TransactionScope scope = new TransactionScope())
                {
                    if (txtContactValue != "")
                    {
                        objShowContactModel.ContactTypeId = lstContactType;
                        objShowContactModel.Phone = txtContactValue;

                        results = objCandidateProfileBroker.AddContactDataResponse(objShowContactModel);

                        if (results != true)
                        {
                            scope.Dispose();
                        }
                        else
                        {
                            objShowContactModel.Phone = null;
                        }

                    }
                    if (txtContactValue1 != "")
                    {
                        objShowContactModel.ContactTypeId = lstContactType1;
                        objShowContactModel.EmailAddress = txtContactValue1;

                        results = objCandidateProfileBroker.AddContactDataResponse(objShowContactModel);

                        if (results != true)
                        {
                            scope.Dispose();
                        }
                        else
                        {
                            objShowContactModel.EmailAddress = null;
                        }
                    }
                    if (txtContactValue2 != "")
                    {
                        objShowContactModel.ContactTypeId = lstContactType2;
                        objShowContactModel.FAX = txtContactValue2;

                        results = objCandidateProfileBroker.AddContactDataResponse(objShowContactModel);

                        if (results != true)
                        {
                            scope.Dispose();
                        }
                        else
                        {
                            objShowContactModel.FAX = null;
                        }
                    }
                    if (txtContactValue3 != "")
                    {
                        objShowContactModel.ContactTypeId = lstContactType3;
                        objShowContactModel.URL = txtContactValue3;

                        results = objCandidateProfileBroker.AddContactDataResponse(objShowContactModel);

                        if (results != true)
                        {
                            scope.Dispose();
                        }
                        else
                        {
                            objShowContactModel.URL = null;
                        }
                    }
                }

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddContactController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}