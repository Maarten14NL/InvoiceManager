using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using InvoiceManager.Services;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class InvoiceController : Controller
    {
        private readonly FileService fileService = new FileService();
        public ActionResult Generate()
        {
            InvoiceService invoiceService = new InvoiceService();
            invoiceService.Generate();

            ViewBag.Message = "Your application description page.";

            return Json(new { foo = "bar", baz = "Blech" }, JsonRequestBehavior.AllowGet);
        }

        private static string GetDataFilePath() => HttpRuntime.AppDomainAppVirtualPath != null ?
        Path.Combine(HttpRuntime.AppDomainAppPath, "App_templates") :
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        //public ActionResult Download()
        //{
        //    string templatePath = GetDataFilePath();
        //    //File to be downloaded.
        //    string fileName = "invoice.zip";

        //    //Path of the File to be downloaded.
        //    string filePath = fileName = templatePath + "\\" + fileName;

        //    //Content Type and Header.
        //    Response.ContentType = "application/pdf";
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        //    //Writing the File to Response Stream.
        //    Response.WriteFile(filePath);

        //    //Flushing the Response.
        //    Response.Flush();

        //    //Deleting the File and ending the Response.
        //    //File.Delete(filePath);
        //    fileService.DeleteFile(filePath);
        //    Response.End();

        //    return Json(new { foo = "bar", baz = "Blech" }, JsonRequestBehavior.AllowGet);
        //}

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