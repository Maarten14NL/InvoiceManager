using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Database;

namespace InvoiceManager_Logic
{
    public class Companies
    {
        public List<Company> Index()
        {
            //new List<ContractModel>();
            CompanyCrud companies = new CompanyCrud();
            List<CompanyDto> companiesList = companies.FindAll();
            List<Company> test = new List<Company>();

            foreach (var company in companiesList)
            {
                Company c = new Company(
                    company.Id,
                    company.Name,
                    company.CustomerNumber,
                    company.Iban,
                    company.IbanAscription,
                    company.PhoneNumber,
                    company.Website,
                    company.Email,
                    company.MandateDate,
                    company.Hide
                );

                test.Add(c);
            }

            return test;
        }
        public void Create(ContractEntity contract)
        {
            ContractDto test = new ContractDto();

            test.Id = contract.Id;
            test.Name = contract.Name;
            test.Description = contract.Description;
            test.Price = contract.Price;
            test.Hide = contract.Hide;


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
