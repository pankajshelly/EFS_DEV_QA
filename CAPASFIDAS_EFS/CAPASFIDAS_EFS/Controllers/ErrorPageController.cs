/// <summary>
/// Provides functionality to handle exception and redirect them to a page which will implementation details in enviroments other than DEV.
/// Type Page Controller: Provides methods that respond to HTTP requests that are made to an ASP.NET MVC Web site.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    [HandleError(View = "ErrorPage/ServerError")]
    public class ErrorPageController : Controller
    {
        readonly CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();

        //Isolated function to handle 400 Client Errors steming from HttpRequestValidationException and perhaps others.
        public ActionResult PotentiallyDangerousError400()
        {
            //Here you could add custom error handling code for 400.
            if (System.Web.HttpContext.Current.Session["GlobalHttpError"] == null)
            {
                System.Web.HttpContext.Current.Session["GlobalHttpError"] = new List<string> {
                    "A potentially dangerous Request.Path value was detected from the client.",
                    "These include values like '<,>,*,%,&,:,\'.",
                    "To see aditional info on this exception, test inside Global.asax.cs file Application_Error event."
                };
            }
            return HandleRedirect("Potentially Dangerous Error 400");
        }


        // GET: ErrorPage
        public ActionResult ErrorPage()
        {
            //Here you could add custom error handling code for 400.
            return HandleRedirect("Unspecified Error");
        }

        //Isolated function to handle 400 Client Errors
        public ActionResult Error400()
        {
            //Here you could add custom error handling code for 400.
            return HandleRedirect("400");
        }

        //Isolated function to handle 500 Server Errors
        public ActionResult Error500()
        {
            //Here you could add custom error handling code for 500.
            return HandleRedirect("500");
        }


        /// <summary>
        /// Common redirect handling code.
        /// NOTE: Errors only appear int the ErrorPage.cshtml when the web config "compilation" setting has debug="true" .
        /// </summary>
        /// <param name="ErrorNum">The error to display in the page.</param>
        /// <returns>ActionResult for the ErrorPage.</returns>
        private ActionResult HandleRedirect(string ErrorNum)
        {
            try
            {
                //Attempt to use the GlobalHttpError set back in the Global.asax.cs to update ViewData.
                if (System.Web.HttpContext.Current.Session["GlobalHttpError"] != null)
                {
                    ViewData["ErrorNumber"] = ErrorNum;
                    ViewData["ErrorMessage"] = System.Web.HttpContext.Current.Session["GlobalHttpError"];
                    System.Web.HttpContext.Current.Session["GlobalHttpError"] = null;//Clear Session value.
                }
                else
                {
                    ViewData["ErrorNumber"] = null;
                    ViewData["ErrorMessage"] = null;
                }
                return View("ErrorPage");
            }
            catch (Exception ex)
            {
                //Catch and pass any exceptions triggered by this controller while handling other exceptions.
                ViewData["ErrorNumber"] = "Page Controller Exception";
                ViewData["ErrorMessage"] = new List<string>{
                    ex.Message,
                    ex.Source ,
                    ex.TargetSite.ToString() ,
                    ex.StackTrace
                };
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "ErrorPageController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                return View("ErrorPage");
            }
        }
    }
}