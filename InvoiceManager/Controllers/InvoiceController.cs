using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using InvoiceManager_Logic;
using InvoiceManager_Logic.Entities;
using Newtonsoft.Json;

namespace InvoiceManager.Controllers
{

    [AllowCrossSiteJsonAttribute]
    public class InvoiceController : Controller
    {
        private readonly Invoices invoice = new Invoices();

        //private readonly FileService fileService = new FileService();
        public ActionResult Generate(string data)
        {
            List<CompanyEntity> givenCompanies = JsonConvert.DeserializeObject<List<CompanyEntity>>(data);
            invoice.Generate(givenCompanies, GetDataFilePath());

            return Json(givenCompanies, JsonRequestBehavior.AllowGet);
        }

        private static string GetDataFilePath() => HttpRuntime.AppDomainAppVirtualPath != null ?
        Path.Combine(HttpRuntime.AppDomainAppPath, "App_templates") :
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public FileResult Download()
        {
            string templatePath = GetDataFilePath();
            string fileName = "invoice.zip";

            //Path of the File to be downloaded.
            string filePath = templatePath + "\\" + fileName;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}