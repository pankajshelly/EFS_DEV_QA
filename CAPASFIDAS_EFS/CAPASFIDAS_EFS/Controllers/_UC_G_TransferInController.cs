using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CAPASFIDAS_EFS.Controllers
{
    public class _UC_G_TransferInController : Controller
    {
        public static string ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"].ToString();
        CAPASFIDAS_EH_UI.ERClass objERClass = new CAPASFIDAS_EH_UI.ERClass();
        //
        // GET: /_UC_TransferIn/
        public ActionResult _UC_G_TransferIn()
        {
            try
            {
                // Bind Method
                var lstTransferType = new SelectList(new[]
                                              {
                                              new {ID="Type1",Name="Type 1"},
                                              new{ID="Type2",Name="Type 2"},
                                          },
                                "ID", "Name", 1);
                ViewData["lstTransferType"] = lstTransferType;

                return View();
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_G_TransferInController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }                
                throw;
            }
            
        }

        public JsonResult GetContributionsTransferInSearchData()
        {
            try
            {
                IList<ContributionsMonetaryModel> lstContributionsMonetaryModel = new List<ContributionsMonetaryModel>();
                ContributionsMonetaryModel objContributionsMonetaryModel;

                //Bind 1st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2016";
                objContributionsMonetaryModel.TransferorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.TransferType = "Type 1";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                //Bind 2st row
                objContributionsMonetaryModel = new ContributionsMonetaryModel();
                objContributionsMonetaryModel.DateReceived = "2015";
                objContributionsMonetaryModel.TransferorName = "Test";
                objContributionsMonetaryModel.Street = "Street";
                objContributionsMonetaryModel.StreetName = "North Pearl Street";
                objContributionsMonetaryModel.City = "Albany";
                objContributionsMonetaryModel.State = "NY";
                objContributionsMonetaryModel.Zip5 = "12206";
                objContributionsMonetaryModel.Zip4 = "1234";
                objContributionsMonetaryModel.TransferType = "Type 2";
                objContributionsMonetaryModel.Method = "Check";
                objContributionsMonetaryModel.Check = "123456";
                objContributionsMonetaryModel.Amount = "$100";
                objContributionsMonetaryModel.Explanation = "Test";
                lstContributionsMonetaryModel.Add(objContributionsMonetaryModel);

                return Json(new
                {
                    aaData = lstContributionsMonetaryModel.Select(x => new[] {
                    x.DateReceived,
                    x.TransferorName,
                    x.Street,
                    x.StreetName,
                    x.City,
                    x.State,
                    x.Zip5,
                    x.Zip4,
                    x.TransferType,
                    x.Method,
                    x.Check,
                    x.Amount,
                    x.Explanation
                })
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (Session["UserName"] != null)
                {
                    objERClass.LogExceptionInDatabase(ConfigurationManager.AppSettings["ApplicationKey"].ToString(), ex.Message, "_UC_G_TransferInController", System.Reflection.MethodBase.GetCurrentMethod().Name, "", "", ex.Message, Session["UserName"].ToString());
                }
                throw;
            }
            
        }
	}
}