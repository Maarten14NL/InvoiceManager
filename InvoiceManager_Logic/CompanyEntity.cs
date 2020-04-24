﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic
{
    public class CompanyEntity
    {
        public int Id;
        public string Name;
        public string CustomerNumber;
        public string Iban;
        public string IbanAscription;
        public string PhoneNumber;
        public string Website;
        public string Email;
        public string MandateDate;
        public bool Hide;

        public CompanyEntity(int Id, string Name, string CustomerNumber, string Iban, string IbanAscription, string PhoneNumber, string Website, string Email, string MandateDate, bool Hide)
        {
            this.Id = Id;
            this.Name = Name;
            this.CustomerNumber = CustomerNumber;
            this.Iban = Iban;
            this.IbanAscription = IbanAscription;
            this.PhoneNumber = PhoneNumber;
            this.Website = Website;
            this.Email = Email;
            this.MandateDate = MandateDate;
            this.Hide = Hide;
        }
    }
}