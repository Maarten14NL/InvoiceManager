using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceManager.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using InvoiceManager_Logic;
using InvoiceManager_Logic.Entities;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class ContractController : Controller
    {
        public ContractController() {}

        public ActionResult Read(int? id)
        {
            Contracts cont = new Contracts();
            var Contracts = cont.Read(id);

            return Json(new { contracts = Contracts }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(String data)
        {
            ContractEntity givenContract = JsonConvert.DeserializeObject<ContractEntity>(data);
            Contracts cont = new Contracts();
            cont.Create(givenContract);

            return Json(new { contracts = givenContract }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(String data)
        {

            ContractEntity givenContract = JsonConvert.DeserializeObject<ContractEntity>(data);
            Contracts cont = new Contracts();
            cont.Update(givenContract);

            return Json(new { contracts = givenContract }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(String data)
        {
            ContractEntity deleteContract = JsonConvert.DeserializeObject<ContractEntity>(data);
            Contracts cont = new Contracts();
            cont.Delete(deleteContract);

            return Json(new { contracts = deleteContract }, JsonRequestBehavior.AllowGet);
        }
    }
}
