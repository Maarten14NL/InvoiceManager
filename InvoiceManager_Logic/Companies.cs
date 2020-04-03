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
        public void Create(Company company)
        {

            ContractsCrud contracts = new ContractsCrud();
            contracts.Create(SetContractDto(company));
        }

        public void Update(Company company)
        {

            ContractsCrud contracts = new ContractsCrud();
            contracts.Update(SetContractDto(company));

        }

        public void Delete(Company company)
        {

            ContractsCrud contracts = new ContractsCrud();
            contracts.Delete(SetContractDto(company));

        }

        private ContractDto SetContractDto(Company company)
        {
            ContractDto test = new ContractDto();

            test.Id = company.Id;
            test.Name = company.Name;
            test.CustomerNumber = company.CustomerNumber;
            test.Iban = company.Iban;
            test.IbanAscription = company.IbanAscription;
            test.PhoneNumber = company.PhoneNumber;
            test.Website = company.Website;
            test.Email = company.Email;
            test.MandateDate = company.MandateDate;
            test.Hide = company.Hide;

            return test;
        }
    }
}
