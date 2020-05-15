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
        public List<CompanyEntity> Read(int? id = null)
        {
            //new List<ContractModel>();
            CompanyCrud companies = new CompanyCrud();
            List<CompanyDto> companiesList = companies.Read(id);
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

        public bool Create(CompanyEntity company)
        {
            if (company.Valid())
            {
                CompanyCrud contracts = new CompanyCrud();
                contracts.Create(SetContractDto(company));

                return true;
            }
            return false;
        }

        public bool Update(CompanyEntity company)
        {
            if (company.Valid())
            {
                CompanyCrud contracts = new CompanyCrud();
                contracts.Update(SetContractDto(company));

                return true;
            }
            return false;
        }

        public bool Delete(CompanyEntity company)
        {
            CompanyCrud contracts = new CompanyCrud();
            contracts.Delete(SetContractDto(company));

            return true;
        }

        private CompanyDto SetContractDto(CompanyEntity company)
        {
            CompanyDto test = new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                CustomerNumber = company.CustomerNumber,
                Iban = company.Iban,
                IbanAscription = company.IbanAscription,
                PhoneNumber = company.PhoneNumber,
                Website = company.Website,
                Email = company.Email,
                MandateDate = string.IsNullOrWhiteSpace(company.MandateDate) ? (DateTime?)null : DateTime.Parse(company.MandateDate),
                Hide = company.Hide
            };

            return test;
        }
    }
}
