using Broker;
using Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;
using SAML_Interface;
using System.Configuration;
using System.Linq;

namespace CAPASFIDAS_EFS.Controllers
{
    public class RoleMapController : Controller
    {

        readonly ItemizedReportsBroker objItemizedReportsBroker = new ItemizedReportsBroker();
        public readonly static string ACSURL = ConfigurationManager.AppSettings["ACSUrl"].ToString();
        public readonly static string Issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
        public readonly static string IdentityProviderSigninURL = ConfigurationManager.AppSettings["IdentityProviderSigninURL"].ToString();
        public readonly static string underMaintanceVal = ConfigurationManager.AppSettings["UnderMaintance"].ToString();
        readonly CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        // GET: RoleMap
        public ActionResult RoleMap()
        {
            try
            {
                SAMLResponse samlResponse = new SAMLResponse();
                //Attempt to store the Cnty_FilerID value.
                if (Request.QueryString["Cnty_FilerID"] != null)
                {
                    Session["Cnty_FilerID"] = Request.QueryString["Cnty_FilerID"].ToString();
                }

                if (underMaintanceVal.ToUpper() == "TRUE")
                {
                    Response.Redirect("~/UnderMaintance/UnderMaintance");
                }
                else
                {
                    //With a Cnty_FilerID present we seem to assume we have session can try to get roles.
                    if (Session["Cnty_FilerID"] != null)
                    {
                        XmlDocument xDoc = samlResponse.ParseSAMLResponse(Session["SAMLResponse"].ToString());
                        //Check to see if we are authenticated with centrify.
                        validateSamlResponseAndGetFilerInfo(samlResponse, xDoc);
                    }
                    //Without a Cnty_FilerID the application needs to fetch additional information.
                    else
                    {
                        //Check to see if we are authenticated with centrify.
                        if (Request.Form["SAMLResponse"] != null)
                        {
                            XmlDocument xDoc = samlResponse.ParseSAMLResponse(Request.Form["SAMLResponse"]);
                            Session["SAMLResponse"] = Request.Form["SAMLResponse"];
                            //Check to see if we are authenticated with centrify.
                            validateSamlResponseAndGetFilerInfo(samlResponse, xDoc);
                        }
                        else
                        {
                            //Attempt to authenticate.
                            SAMLRequest request = new SAMLRequest();
                            Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
                        }
                    }

                    // Bind Filer ID
                    var lstFilerID = new SelectList(new[] { new { ID = "-Select-", Name = "-Select-" }, }, "ID", "Name", 1);

                    ViewData["lstFilerID"] = lstFilerID;
                }
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "RoleMapController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
            }
            return View();
        }

        /// <summary>
        /// Common code to handle SAML and authenticate.
        /// If there are no roles the user will be redirected to a different page.
        /// If roles are found then we get filer information and store it in the session.
        /// </summary>
        /// <returns>JsonResult</returns>
        private void validateSamlResponseAndGetFilerInfo(SAMLResponse samlResponse, XmlDocument xDoc)
        {
            //Check to see if we are authenticated with centrify.
            if (samlResponse.IsResponseValid(xDoc))
            {
                Session["UserName"] = samlResponse.ParseSAMLNameID(xDoc).ToString();
                Session["UserNameDisplay"] = samlResponse.ParseSAMLNameID(xDoc).ToString();
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserNameDisplay"].ToString());
                ViewData["lstValidateFilerInfo"] = new SelectList(lstValidateFilerInfo, "FilerID", "Name");
                Session["lstValidateFilerInfo"] = lstValidateFilerInfo;
                //A count of zero means we don't have roles for the user.
                if (lstValidateFilerInfo.Count == 0)
                {
                    Response.Redirect("~/UnAuthorizedAccess/UnAuthorizedAccess");
                }
                //Get additional filer information.
                else
                {
                    GetFilerInformation();
                }
            }
            //Attempt to authenticate.
            else
            {
                SAMLRequest request = new SAMLRequest();
                Response.Redirect(IdentityProviderSigninURL + "?SAMLRequest=" + Server.UrlEncode(request.GetSAMLRequest(ACSURL, Issuer)));
            }
        }


        /// <summary>
        /// Attempts to authenticate using Session["UserNameDisplay"] value.
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult AuthenticateFilerID()
        {
            try
            {
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserNameDisplay"].ToString());
                Session["lstValidateFilerInfo"] = lstValidateFilerInfo;
                return Json(new SelectList(lstValidateFilerInfo, "FilerID", "Name"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "RoleMapController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }

        /// <summary>
        /// Get Filer Information
        /// Gathers information in the session using Session["UserNameDisplay"] and Session["UserNameDisplay"] value.
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetFilerInformation()
        {
            try
            {
                IList<ValidateFilerInfoModel> lstValidateFilerInfo = objItemizedReportsBroker.GetAuthenticateFilerInfoBroker(Session["UserNameDisplay"].ToString());

                IList<FilerCommitteeModel> lstFilerCommitteeModel;
                IList<FilerInfoModel> listFilerInfo;
                if (Session["Cnty_FilerID"] != null)
                {
                    lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(Session["Cnty_FilerID"].ToString());
                    listFilerInfo = objItemizedReportsBroker.GetFilerInforamationBroker(Session["Cnty_FilerID"].ToString(), lstFilerCommitteeModel[0].personID.ToString());
                }
                else
                {
                    lstFilerCommitteeModel = objItemizedReportsBroker.GetFilerCommitteeDataResponse(lstValidateFilerInfo[0].FilerID.ToString());
                    listFilerInfo = objItemizedReportsBroker.GetFilerInforamationBroker(lstValidateFilerInfo[0].FilerID.ToString(), lstFilerCommitteeModel[0].personID.ToString());
                }
                Session["PersonId"] = lstFilerCommitteeModel[0].personID.ToString();
                Session["FilerID"] = lstFilerCommitteeModel[0].FilerId.ToString();
                Session["CommID"] = lstFilerCommitteeModel[0].CommitteeId.ToString();
                Session["TreasurerId"] = lstFilerCommitteeModel[0].TreasurerId.ToString();
                Session["FILER_INFO"] = listFilerInfo;
                Session["FILER_Data"] = listFilerInfo[0].Filer_ID.ToString() + ' ' + listFilerInfo[0].Cand_Comm_Name.ToString();
                Session["FILER_NAME"] = listFilerInfo[0].Name.ToString();
                Session["FilerId"] = listFilerInfo[0].Filer_ID.ToString();
                Session["Cand_Comm_Name"] = listFilerInfo[0].Cand_Comm_Name.ToString();
                Session["Cand_Comm_ID"] = listFilerInfo[0].Cand_Comm_ID.ToString();
                Session["COMM_TYPE_ID"] = lstFilerCommitteeModel[0].CommTypeId;
                Session["Office_Type_ID"] = lstFilerCommitteeModel[0].OfficTypeID;
                Session["Office_Type_Desc"] = lstFilerCommitteeModel[0].OfficeTypeDesc;
                // TESTING ONLY AFTER AUTHENTICATION FILL IT.
                Session["UserName"] = Session["UserNameDisplay"].ToString();                
                Session["RoleID_FILER"] = lstValidateFilerInfo.Where(x => Convert.ToString(x.FilerID) == Convert.ToString(lstFilerCommitteeModel[0].FilerId.ToString())).Select(x=> x.RoleID).FirstOrDefault().ToString();

                return Json(listFilerInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "RoleMapController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
        }
    }
}