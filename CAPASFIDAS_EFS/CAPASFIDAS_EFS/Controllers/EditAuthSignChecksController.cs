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
    public class EditAuthSignChecksController : Controller
    {
        public static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /EditAuthSignChecks/
        public ActionResult EditAuthSignChecks()
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
                    IList<Status> lstStatus = new List<Status>();
                    Status objStatus;

                    objStatus = new Status();
                    objStatus.StatusId = "1";
                    objStatus.StatusName = "All";
                    lstStatus.Add(objStatus);

                    objStatus = new Status();
                    objStatus.StatusId = "2";
                    objStatus.StatusName = "Active";
                    lstStatus.Add(objStatus);

                    objStatus = new Status();
                    objStatus.StatusId = "3";
                    objStatus.StatusName = "In-Active";
                    lstStatus.Add(objStatus);

                    ViewData["lstStatus"] = new SelectList(lstStatus, "StatusId", "StatusName");

                    IList<AuthSignChecks> lstAuthSignChecksObject = new List<AuthSignChecks>();
                    if (Request.QueryString["contactID"] != null)
                    {
                        if (Request.QueryString["rowNumber"] != null)
                        {
                            Session["rowNumber"] = Request.QueryString["rowNumber"].ToString();
                        }
                        Session["EditcontactID"] = Request.QueryString["contactID"].ToString();
                        IList<AuthSignChecks> lstAuthSignChecks = new List<AuthSignChecks>();
                        lstAuthSignChecks = (IList<Models.AuthSignChecks>)Session["AuthSignChecks"];
                        var objShowAddress = (from a in lstAuthSignChecks
                                              where a.ContactId == Session["EditcontactID"].ToString()
                                              select a).ToList();
                        lstAuthSignChecksObject = (IList<AuthSignChecks>)objShowAddress;

                        ViewBag.Prefix = lstAuthSignChecksObject[0].Prefix.ToString();
                        ViewBag.LastName = lstAuthSignChecksObject[0].LastName.ToString();
                        ViewBag.FirstName = lstAuthSignChecksObject[0].FirstName.ToString();
                        ViewBag.MI = lstAuthSignChecksObject[0].MI.ToString();
                        ViewBag.Suffix = lstAuthSignChecksObject[0].Suffix.ToString();

                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditAuthSignChecksController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                ShowAddress objShowAddress;

                objShowAddress = new ShowAddress();
                objShowAddress.ADDR_ADDR1 = "124-132 Washington Ave";
                objShowAddress.ADDR_ADDR2 = "";
                objShowAddress.BEST_CONTACT_ID = "1";
                objShowAddress.BEST_CONTACT_DESC = "Primary";
                objShowAddress.ADDR_TYPE_ID = "1";
                objShowAddress.ADDR_TYPE_DESC = "Business";
                objShowAddress.ADDR_STR_NUM = "";
                objShowAddress.ADDR_STR_NAME = "";
                objShowAddress.ADDR_CITY = "Endicott";
                objShowAddress.ADDR_STATE = "NY";
                objShowAddress.ADDR_ZIP5 = "13760";
                objShowAddress.ADDR_ZIP4 = "0";
                objShowAddress.ADDR_ID = "11";
                lstShowAddress.Add(objShowAddress);

                objShowAddress = new ShowAddress();
                objShowAddress.ADDR_ADDR1 = "124-132 Washington Ave";
                objShowAddress.ADDR_ADDR2 = "";
                objShowAddress.BEST_CONTACT_ID = "1";
                objShowAddress.BEST_CONTACT_DESC = "Secondry";
                objShowAddress.ADDR_TYPE_ID = "1";
                objShowAddress.ADDR_TYPE_DESC = "Business";
                objShowAddress.ADDR_STR_NUM = "";
                objShowAddress.ADDR_STR_NAME = "";
                objShowAddress.ADDR_CITY = "Endicott";
                objShowAddress.ADDR_STATE = "NY";
                objShowAddress.ADDR_ZIP5 = "13760";
                objShowAddress.ADDR_ZIP4 = "0";
                objShowAddress.ADDR_ID = "11";
                lstShowAddress.Add(objShowAddress);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditAuthSignChecksController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
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
                ShowContact objShowContact;

                objShowContact = new ShowContact();
                objShowContact.BestContract_ID = "1";
                objShowContact.BestContract_Desc = "Primary";
                objShowContact.Phone = "123456789";
                objShowContact.EmailAddress = "abc@abc.com";
                lstShowContact.Add(objShowContact);

                objShowContact = new ShowContact();
                objShowContact.BestContract_ID = "2";
                objShowContact.BestContract_Desc = "Secondary";
                objShowContact.Phone = "123456789";
                objShowContact.EmailAddress = "abc@abc.com";
                lstShowContact.Add(objShowContact);

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
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "EditAuthSignChecksController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
    }
}