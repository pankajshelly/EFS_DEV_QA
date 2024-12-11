using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using SAML_Interface;
using System.Configuration;
using Broker;
using Models;

namespace CAPASFIDAS_EFS.Controllers
{ 
    public class _MasterLayoutController : Controller
    {        
        // GET: _MasterLayout
        public ActionResult _MasterLayout()
        {
            return View();
        }
    }
}