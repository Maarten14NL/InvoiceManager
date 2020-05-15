using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoiceManager_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic.Tests
{
    [TestClass()]
    public class CompaniesTests
    {
        private readonly Companies companies = new Companies();

        private readonly int Id = 1;
        private readonly string _name = "Nieuw bedrijf";
        private readonly string _customerNumber = "007";
        private readonly string _iban = "123456782";
        private readonly string _ibanAscription = "J Doe";
        private readonly string _phoneNumber = "123456789";
        private readonly string _website = "WhosJoe.com";
        private readonly string _email = "JoeDoe@gmail.com";
        private readonly string _mandateDate = new DateTime().ToString();
        private readonly bool _hide = false;

        //Create test cases ---------------------------------------------
        [TestMethod()]
        public void CreateWithAllValues()
        {
            // success
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (!Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutName()
        {
            // error
            CompanyEntity ce = new CompanyEntity(0, null, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutCustomerNumber()
        {
            // success
            CompanyEntity ce = new CompanyEntity(0, _name, null, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (!Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutIban()
        {
            // error
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, null, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutIbanAscription()
        {
            // error
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, _iban, null, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutEmail()
        {
            // error
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, null, _mandateDate, _hide);
            if (Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutWebsite()
        {
            // success
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, null, _email, _mandateDate, _hide);
            if (!Create(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithPhoneNumber()
        {
            // success
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, _iban, _ibanAscription, null, _website, _email, _mandateDate, _hide);
            if (!Create(ce))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void CreateWithOutMandateDate()
        {
            // error
            CompanyEntity ce = new CompanyEntity(0, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, null, _hide);
            if (Create(ce))
            {
                Assert.Fail();
            }
        }

        //Update test cases ---------------------------------------------

        [TestMethod()]
        public void UpdateWithAllValues()
        {
            // success
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (!Update(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutId()
        {
            // error
            CompanyEntity ce = new CompanyEntity(-1, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Update(ce))
            {
                Assert.Fail();
            }
        }

        public void UpdateWithOutName()
        {
            // error
            CompanyEntity ce = new CompanyEntity(Id, null, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Update(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutCustomerNumber()
        {
            // succes
            CompanyEntity ce = new CompanyEntity(Id, _name, null, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (!Update(ce))
            {
                Assert.Fail();
            }
        }

        public void UpdateWithOutIban()
        {
            // error
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, null, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Update(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutIbanAscription()
        {
            // error
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, null, _phoneNumber, _website, _email, _mandateDate, _hide);
            if (Update(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithPhoneNumber()
        {
            // success
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, _ibanAscription, null, _website, _email, _mandateDate, _hide);
            if (!Update(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutWebsite()
        {
            // success
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, null, _email, _mandateDate,_hide);
            if (!Update(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutEmail()
        {
            // error
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, null, _mandateDate, _hide);
            if (Update(ce))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void UpdateWithOutMandateDate()
        {
            // error
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, null, _hide);
            if (Update(ce))
            {
                Assert.Fail();
            }
        }


        private bool Create(CompanyEntity ce)
        {
           return companies.Create(ce);

        }

        private bool Update(CompanyEntity ce)
        {
            return companies.Update(ce);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            CompanyEntity ce = new CompanyEntity(Id, _name, _customerNumber, _iban, _ibanAscription, _phoneNumber, _website, _email, _mandateDate, _hide);

            if (!this.companies.Delete(ce))
            {
                Assert.Fail();
            }
        }
    }
}