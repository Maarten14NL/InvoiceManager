﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using InvoiceManager_Logic;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class CompanyController : Controller
    {


        public ActionResult Index()
        {
            Companies cont = new Companies();
            var Companies = cont.Index();

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
            CompanyEntity deleteCompanies = JsonConvert.DeserializeObject<CompanyEntity>(data);
            Companies cont = new Companies();
            cont.Delete(deleteCompanies);

            return Json(new { companies = deleteCompanies }, JsonRequestBehavior.AllowGet);
        }
    }
}