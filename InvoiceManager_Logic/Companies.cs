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
        public List<CompanyEntity> Index()
        {
            //new List<ContractModel>();
            CompanyCrud companies = new CompanyCrud();
            List<CompanyDto> companiesList = companies.FindAll();
            List<CompanyEntity> test = new List<CompanyEntity>();

            foreach (var company in companiesList)
            {
                CompanyEntity c = new CompanyEntity(
                    company.Id,
                    company.Name,
                    company.CustomerNumber,
                    company.Iban,
                    company.IbanAscription,
                    company.PhoneNumber,
                    company.Website,
                    company.Email,
                    Convert.ToString(company.MandateDate),
                    company.Hide
                );

                test.Add(c);
            }

            return test;
        }

        public void Create(CompanyEntity company)
        {
            CompanyCrud contracts = new CompanyCrud();
            contracts.Create(SetContractDto(company));
        }

        public void Update(CompanyEntity company)
        {

            CompanyCrud contracts = new CompanyCrud();
            contracts.Update(SetContractDto(company));

        }

        public void Delete(CompanyEntity company)
        {

            CompanyCrud contracts = new CompanyCrud();
            contracts.Delete(SetContractDto(company));

        }

        private CompanyDto SetContractDto(CompanyEntity company)
        {
            CompanyDto test = new CompanyDto();

            test.Id = company.Id;
            test.Name = company.Name;
            test.CustomerNumber = company.CustomerNumber;
            test.Iban = company.Iban;
            test.IbanAscription = company.IbanAscription;
            test.PhoneNumber = company.PhoneNumber;
            test.Website = company.Website;
            test.Email = company.Email;
            test.MandateDate = string.IsNullOrWhiteSpace(company.MandateDate) ? (DateTime?)null : DateTime.Parse(company.MandateDate);
            test.Hide = company.Hide;

            return test;
        }
    }
}
