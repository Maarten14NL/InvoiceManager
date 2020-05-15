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
    public class ContractsTests
    {
        private readonly Contracts _contracts = new Contracts();

        private readonly int _id = 1;
        private readonly string _name = "Test Unit";
        private readonly string _description = "This is an Unit test.";
        private readonly double _price = 12.34;
        private readonly bool _hide = false;


        [TestMethod()]
        public void CreateWithAllValues()
        {
            ContractEntity ce = new ContractEntity(0, _name, _description, _price, _hide);
            if(!CreateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutName()
        {
            ContractEntity ce = new ContractEntity(0, null, _description, _price, _hide);
            if (CreateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutDescription()
        {
            ContractEntity ce = new ContractEntity(0, _name, null, _price, _hide);
            if (CreateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void CreateWithOutPrice()
        {
            ContractEntity ce = new ContractEntity(0, _name, _description, 00.00, _hide);
            if (CreateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithAllValues()
        {
            ContractEntity ce = new ContractEntity(_id, _name, _description, _price, _hide);
            if (!UpdateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutId()
        {
            ContractEntity ce = new ContractEntity(-1, _name, _description, _price, _hide);
            if (UpdateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutName()
        {
            ContractEntity ce = new ContractEntity(_id, null, _description, _price, _hide);
            if (UpdateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutDescription()
        {
            ContractEntity ce = new ContractEntity(_id, _name, null, _price, _hide);
            if (UpdateTest(ce))
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void UpdateWithOutPrice()
        {
            ContractEntity ce = new ContractEntity(_id, _name, _description, 00.00, _hide);
            if (UpdateTest(ce))
            {
                Assert.Fail();
            }
        }

        private bool CreateTest(ContractEntity ce)
        {
            return _contracts.Create(ce);
        }

        private bool UpdateTest(ContractEntity ce)
        {
            return _contracts.Update(ce);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ContractEntity ce = new ContractEntity(_id, _name, _description, _price, _hide);

            if (!_contracts.Delete(ce))
            {
                Assert.Fail();
            }
        }
    }
}