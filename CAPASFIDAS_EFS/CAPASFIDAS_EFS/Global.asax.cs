using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CAPASFIDAS_EFS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true; //this line is to hide mvc header
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            string redirectPath = "~/Home/Home/";
            //Get the error triggered by the server.
            Exception ex = Server.GetLastError();
            try
            {
                HttpContext context = HttpContext.Current;
                //Public Reporting applications sessions are currently not handled via authentication.
                //However if we don't have a sessionID we re-route to home page.
                if (context != null && context.Session != null && context.Session.SessionID == null)
                {
                    //Always clear the server errror.
                    Server.ClearError();
                    Response.Redirect(redirectPath);
                }
                else
                {
                    bool storeInSession = false;
                    HttpException lastErrorWrapper = new HttpException(ex.Message, ex);
                    try
                    {

                        switch (lastErrorWrapper.GetHttpCode())
                        {
                            case int n when (n >= 400 && n < 500)://400-499 Client Errors
                                //If context and session are both null we may be dealing with an HttpRequestValidationException which requires additional handling.
                                if (context == null || context.Session == null)
                                {
                                    redirectPath = "~/ErrorPage/PotentiallyDangerousError400/";
                                }
                                else
                                {
                                    storeInSession = true;
                                    redirectPath = "~/ErrorPage/Error400/";
                                }
                                break;
                            case int n when (n >= 500 && n < 600)://500-599 Server Errors
                                storeInSession = true;
                                redirectPath = "~/ErrorPage/Error500/";
                                break;
                            default:
                                // Redirects user to whatever the default redirectPath was.
                                break;
                        }
                    }
                    catch (Exception error)
                    {
                        //Should let us know if something goes wrong and eat the error.
                        Debug.WriteLine(error.ToString());
                        ex = error;
                    }
                    //Redirect the user to the appropriate custom error page
                    storeInSesssionAndRedirect(ex, redirectPath, storeInSession);
                }
            }
            catch (Exception error)
            {
                //Should let us know if something goes wrong and eat the error.
                Debug.WriteLine(error.ToString());
                //Always clear the server errror.
                Server.ClearError();
                //Other unhandled Errors get redirected to Home Page.
                Response.Redirect(redirectPath);
            }
        }

        /// <summary>
        /// Used to redirect the response to a different location.
        /// If possible it wil store a given exception in a session Variable called [GlobalHttpError].
        /// NOTE: Errors only appear int the ErrorPage.cshtml when the web config "compilation" setting has debug="true" .
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="string">redirectPath</param>
        /// <param name="nool">storeInSession</param>
        private void storeInSesssionAndRedirect(Exception ex, string redirectPath, bool storeInSession = false)
        {
            try
            {
                if (ex != null && storeInSession)
                {
                    //Get the error triggered by the server and convert it into an HttpException so we can determine the Error Code, if available.
                    //NOTE that the last error in the server may not be of type HttpException.
                    //It could be an SQLException, SystemException, IndexOutOfRangeException, etc.
                    System.Web.HttpContext.Current.Session["GlobalHttpError"] = new List<string> {
                            ex.Message,
                            ex.Source ,
                            ex.TargetSite.ToString() ,
                            ex.StackTrace
                    };
                }
                //Always clear the server errror.
                Server.ClearError();
                Response.Redirect(redirectPath);
            }
            catch (Exception error)
            {
                //Should let us know if something goes wrong and eat the error.
                Debug.WriteLine(error.ToString());
                //Always clear the server errror.
                Server.ClearError();
                Response.Redirect("~/ErrorPage/Error500/");
            }
        }
        void Session_Start(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session.Timeout = 60; // sixty minutes
            string sessionId = Session.SessionID;
        }
    }
}
