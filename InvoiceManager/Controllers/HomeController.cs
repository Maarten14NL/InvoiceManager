using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceManager.Services;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            InvoiceService invoiceService = new InvoiceService();
            invoiceService.Generate();

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