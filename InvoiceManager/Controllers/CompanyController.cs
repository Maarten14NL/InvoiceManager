using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using InvoiceManager_Logic;
using InvoiceManager_Logic.Entities;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class CompanyController : Controller
    {
        public ActionResult Read(int? id)
        {
            Companies cont = new Companies();
            var Companies = cont.Read(id);

            return Json(new { companies = Companies }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(String data)
        {
            CompanyEntity givenCompanies = JsonConvert.DeserializeObject<CompanyEntity>(data);
            Companies cont = new Companies();
            cont.Create(givenCompanies);

            return Json(new { companies = givenCompanies }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(String data)
        {
            CompanyEntity givenCompanies = JsonConvert.DeserializeObject<CompanyEntity>(data);
            Companies cont = new Companies();
            cont.Update(givenCompanies);

            return Json(new { companies = givenCompanies }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(String data)
        {
            //string Data = "{'Name':'1','CustomerNumber':'2','Iban':'5','IbanAscription':'6','PhoneNumber':'7','Website':'8','Email':'9','MandateDate':'1-1-1900 00:00:00','Hide':false}";
            CompanyEntity deleteCompanies = JsonConvert.DeserializeObject<CompanyEntity>(data);
            Companies cont = new Companies();
            cont.Delete(deleteCompanies);

            return Json(new { companies = deleteCompanies }, JsonRequestBehavior.AllowGet);
        }
    }
}