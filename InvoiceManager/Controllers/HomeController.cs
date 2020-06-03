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
        public ActionResult About()
        {
            Invoices invoiceService = new Invoices();
            invoiceService.Generate(new List<CompanyEntity>(), GetDataFilePath());

            ViewBag.Message = "Your application description page.";

            return Json(new { foo = "bar", baz = "Blech" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}