﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceManager.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace InvoiceManager.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ContractController() {}

        public ActionResult Index()
        {
            var Contracts = _context.Contracts.Where(x => x.Hide == false).ToList();

            return Json(new { contracts = Contracts }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(String data)
        {
            Contract givenContract = JsonConvert.DeserializeObject<Contract>(data);

            _context.Contracts.Add(givenContract);
            _context.SaveChanges();

            return Json(new { contracts = givenContract }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(String data)
        {
            Contract givenContract = JsonConvert.DeserializeObject<Contract>(data);
            int id = 1;
            Contract editContract = _context.Contracts.Where(x => x.Id == givenContract.Id).FirstOrDefault();

            editContract.Name = givenContract.Name;
            editContract.Description = givenContract.Description;
            editContract.Price = givenContract.Price;

            _context.SaveChanges();

            return Json(new { contracts = id, data = givenContract }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(String data)
        {
            Contract givenContract = JsonConvert.DeserializeObject<Contract>(data);
            int id = 1;
            Contract deleteContract = _context.Contracts.Where(x => x.Id == givenContract.Id).FirstOrDefault();

            //if (id != 1)
            //{
            //_context.Contracts.Remove(deleteContract);
            //}
            //else
            //{
            deleteContract.Hide = true;
            //}

            _context.SaveChanges();

            return Json(new { contracts = deleteContract, data = givenContract }, JsonRequestBehavior.AllowGet);
        }
    }
}
