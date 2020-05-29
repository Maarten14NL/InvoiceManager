using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Factory;
using InvoiceManager_Logic.Entities;
using InvoiceMananger_DatabaseInterface;

namespace InvoiceManager_Logic
{
    public class Companies
    {
        public List<CompanyEntity> Read(int? id = null)
        {
            List<CompanyDto> companiesList = CompanyFactory.Read(id);

            List<CompanyEntity> test = new List<CompanyEntity>();

            foreach (var company in companiesList)
            {
                CompanyEntity c = new CompanyEntity(company);
                test.Add(c);
            }

            return test;
        }

        public bool Create(CompanyEntity company)
        {
            if (company.Valid())
            {
                return CompanyFactory.Create(SetContractDto(company));
            }
            return false;
        }

        public bool Update(CompanyEntity company)
        {
            if (company.Valid())
            {
                return CompanyFactory.Update(SetContractDto(company));
            }
            return false;
        }

        public bool Delete(CompanyEntity company)
        {
            if (company.Valid())
            {
                return CompanyFactory.Delete(SetContractDto(company));
            }
            return false;
        }

        private CompanyDto SetContractDto(CompanyEntity company)
        {
            CompanyDto companyDto = new CompanyDto
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

            return companyDto;
        }
    }
}
