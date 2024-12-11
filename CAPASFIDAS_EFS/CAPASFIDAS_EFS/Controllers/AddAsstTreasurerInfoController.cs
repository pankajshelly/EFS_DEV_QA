using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAML_Interface;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class AddAsstTreasurerInfoController : Controller
    {
        // Broker Object
        TreasurerProfileBroker objTreasurerProfileBroker = new TreasurerProfileBroker();
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /AddAsstTreasurerInfo/
        public ActionResult AddAsstTreasurerInfo()
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
                    if (Request.QueryString["treasurerId"] != null)
                    {
                        Session["TreasurerId"] = Request.QueryString["treasurerId"].ToString();
                    }

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

                }
                return View();
            }
            catch (Exception ex)
            {                
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddAsstTreasurerInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }

        #region Get Address Data
        /// <summary>
        /// Get Address Data
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAddressData()
        {
            try
            {
                String strSiteId = String.Empty;

                IList<ShowAddress> lstShowAddress = new List<ShowAddress>();
                //ShowAddress objShowAddress;

                //objShowAddress = new ShowAddress();
                //objShowAddress.ADDR_ADDR1 = "124-132 Washington Ave";
                //objShowAddress.ADDR_ADDR2 = "";
                //objShowAddress.BEST_CONTACT_ID = "1";
                //objShowAddress.BEST_CONTACT_DESC = "Primary";
                //objShowAddress.ADDR_TYPE_ID = "1";
                //objShowAddress.ADDR_TYPE_DESC = "Business";
                //objShowAddress.ADDR_STR_NUM = "";
                //objShowAddress.ADDR_STR_NAME = "";
                //objShowAddress.ADDR_CITY = "Endicott";
                //objShowAddress.ADDR_STATE = "NY";
                //objShowAddress.ADDR_ZIP5 = "13760";
                //objShowAddress.ADDR_ZIP4 = "0";
                //objShowAddress.ADDR_ID = "11";
                //lstShowAddress.Add(objShowAddress);

                //objShowAddress = new ShowAddress();
                //objShowAddress.ADDR_ADDR1 = "124-132 Washington Ave";
                //objShowAddress.ADDR_ADDR2 = "";
                //objShowAddress.BEST_CONTACT_ID = "1";
                //objShowAddress.BEST_CONTACT_DESC = "Secondry";
                //objShowAddress.ADDR_TYPE_ID = "1";
                //objShowAddress.ADDR_TYPE_DESC = "Business";
                //objShowAddress.ADDR_STR_NUM = "";
                //objShowAddress.ADDR_STR_NAME = "";
                //objShowAddress.ADDR_CITY = "Endicott";
                //objShowAddress.ADDR_STATE = "NY";
                //objShowAddress.ADDR_ZIP5 = "13760";
                //objShowAddress.ADDR_ZIP4 = "0";
                //objShowAddress.ADDR_ID = "11";
                //lstShowAddress.Add(objShowAddress);

                Session["ShowAddress"] = lstShowAddress;

                return Json(new
                {
                    aaData = lstShowAddress.Select(x => new[] {
                    x.ADDR_ID,
                    x.BEST_CONTACT_DESC,
                    x.ADDR_TYPE_DESC,
                    x.ADDR_STR_NUM,
                    x.ADDR_STR_NAME,
                    x.ADDR_CITY,
                    x.ADDR_STATE,
                    x.ADDR_ZIP5,
                    x.ADDR_ZIP4
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddAsstTreasurerInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
        #endregion Get Address Data

        /// <summary>
        /// Show Contract
        /// </summary>
        /// <returns></returns>
        public JsonResult GetShowContact()
        {
            try
            {
                IList<ShowContact> lstShowContact = new List<ShowContact>();
                //ShowContact objShowContact;

                //objShowContact = new ShowContact();
                //objShowContact.BestContract_ID = "1";
                //objShowContact.BestContract_Desc = "Primary";
                //objShowContact.Phone = "123456789";
                //objShowContact.EmailAddress = "abc@abc.com";
                //lstShowContact.Add(objShowContact);

                //objShowContact = new ShowContact();
                //objShowContact.BestContract_ID = "2";
                //objShowContact.BestContract_Desc = "Secondary";
                //objShowContact.Phone = "123456789";
                //objShowContact.EmailAddress = "abc@abc.com";
                //lstShowContact.Add(objShowContact);

                Session["ShowContact"] = lstShowContact;

                return Json(new
                {
                    aaData = lstShowContact.Select(x => new[] {
                    x.BestContract_ID,
                    x.BestContract_Desc,
                    x.Phone,
                    x.EmailAddress
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddAsstTreasurerInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                objSubTreasurerPersonModel.TreasurerId = Session["TreasurerId"].ToString();
                objSubTreasurerPersonModel.CreatedBy = "sbasireddy";

                var results = objTreasurerProfileBroker.AddSubTreasurerDataResponse(objSubTreasurerPersonModel);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "AddAsstTreasurerInfoController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
    }
}