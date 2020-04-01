using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Database;

namespace InvoiceManager_Logic
{
    public class Contracts
    {
        public List<ContractEntity> Index()
        {
            //new List<ContractModel>();
            ContractsCrud contracts = new ContractsCrud();
            List<ContractDto> contractsList =  contracts.FindAll();
            List <ContractEntity> test = new List<ContractEntity>();

            foreach (var contract in contractsList)
            {
                ContractEntity c = new ContractEntity(
                    contract.Id,
                    contract.Name,
                    contract.Description,
                    contract.Price,
                    contract.Hide
                );
                
                test.Add(c);
            } 

            return test;
        }
        public void Create(ContractEntity contract)
        {
            ContractDto test = new ContractDto();

            test.Id             = contract.Id;
            test.Name           = contract.Name;
            test.Description    = contract.Description;
            test.Price          = contract.Price;
            test.Hide           = contract.Hide;
            

            ContractsCrud contracts = new ContractsCrud();
            contracts.Create(test);
        }

        public void Update(ContractEntity contract)
        {
            ContractDto test = new ContractDto();

            test.Id = contract.Id;
            test.Name = contract.Name;
            test.Description = contract.Description;
            test.Price = contract.Price;
            test.Hide = contract.Hide;

            ContractsCrud contracts = new ContractsCrud();
            contracts.Update(test);

        }

        public void Delete(ContractEntity contract)
        {
            ContractDto test = new ContractDto();

            test.Id = contract.Id;
            test.Name = contract.Name;
            test.Description = contract.Description;
            test.Price = contract.Price;
            test.Hide = contract.Hide;

            ContractsCrud contracts = new ContractsCrud();
            contracts.Delete(test);

        }

    }
}
