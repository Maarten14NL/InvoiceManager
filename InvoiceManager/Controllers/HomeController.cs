using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using InvoiceManager.Services;
using InvoiceManager_Logic;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        private static string GetDataFilePath() => HttpRuntime.AppDomainAppVirtualPath != null ?
    Path.Combine(HttpRuntime.AppDomainAppPath, "App_templates") :
    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}