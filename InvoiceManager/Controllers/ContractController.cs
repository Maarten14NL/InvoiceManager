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
        private readonly Contracts cont = new Contracts();

        public ContractController() {}

        public ActionResult Read(int? id)
        {
            var Contracts = cont.Read(id);
            return Json(new { contracts = Contracts }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(String data)
        {
            ContractEntity givenContract = JsonConvert.DeserializeObject<ContractEntity>(data);            
            return Json(new { success = cont.Create(givenContract) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(String data)
        {

            ContractEntity givenContract = JsonConvert.DeserializeObject<ContractEntity>(data);            
            return Json(new { success = cont.Update(givenContract) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(String data)
        {
            ContractEntity deleteContract = JsonConvert.DeserializeObject<ContractEntity>(data);
            cont.Delete(deleteContract);

            return Json(new { contracts = deleteContract }, JsonRequestBehavior.AllowGet);
        }
    }
}
