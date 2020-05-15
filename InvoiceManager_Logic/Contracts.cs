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
        public List<ContractEntity> Read(int? id = null)
        {
            //new List<ContractModel>();
            ContractsCrud contracts = new ContractsCrud();
            List<ContractDto> contractsList =  contracts.Read(id);
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
        public bool Create(ContractEntity contract)
        {
            if (contract.Valid())
            {
                ContractDto test = new ContractDto
                {
                    Id = contract.Id,
                    Name = contract.Name,
                    Description = contract.Description,
                    Price = contract.Price,
                    Hide = contract.Hide
                };

                ContractsCrud contracts = new ContractsCrud();
                contracts.Create(test);

                return true;
            }
            return false;
        }

        public bool Update(ContractEntity contract)
        {
            if (contract.Valid())
            {
                ContractDto test = new ContractDto
                {
                    Id = contract.Id,
                    Name = contract.Name,
                    Description = contract.Description,
                    Price = contract.Price,
                    Hide = contract.Hide
                };

                ContractsCrud contracts = new ContractsCrud();
                contracts.Update(test);

                return true;
            }
            return false;
        }

        public bool Delete(ContractEntity contract)
        {
            ContractDto test = new ContractDto
            {
                Id = contract.Id,
                Name = contract.Name,
                Description = contract.Description,
                Price = contract.Price,
                Hide = contract.Hide
            };

            ContractsCrud contracts = new ContractsCrud();
            contracts.Delete(test);

            return true;
        }

    }
}
