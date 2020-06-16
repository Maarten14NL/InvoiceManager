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
    public class CompanyContracts
    {
        private readonly Companies companies = new Companies();
        private readonly Contracts contracts = new Contracts();

        private readonly ICompanyContracts _CompanyContractsDal = CompanyContractFactory.GetCompanyContract();
        public List<CompanyContractsEntity> Read()
        {
            List<CompanyContractsDto> companyContractsList = _CompanyContractsDal.Read();
            List<CompanyContractsEntity> test = new List<CompanyContractsEntity>();
            foreach (var cc in companyContractsList)
            {
                CompanyContractsEntity c = new CompanyContractsEntity(
                    cc
                );

                test.Add(c);
            }
            return test;
        }

        public List<CompanyContractsEntity> GetByCompany(int id)
        {
            List<CompanyContractsDto> companyContractsList = _CompanyContractsDal.GetByCompany(id);
            List<CompanyContractsEntity> test = new List<CompanyContractsEntity>();
            foreach (var cc in companyContractsList)
            {
                CompanyContractsEntity c = new CompanyContractsEntity(
                    cc
                );

                test.Add(c);
            }
            return test;
        }

        public bool Create(CompanyContractsEntity companyContract)
        {
                return _CompanyContractsDal.Create(SetCompanyContractDto(companyContract));
            //return false;
        }

        public bool Update(CompanyContractsEntity companyContract)
        {
            return _CompanyContractsDal.Update(SetCompanyContractDto(companyContract));
            //return false;
        }

        private CompanyContractsDto SetCompanyContractDto(CompanyContractsEntity companyContract)
        {
            CompanyContractsDto companyContractsDto = new CompanyContractsDto
            {
                Id = companyContract.Id,
                Company = companies.SetContractDto(companyContract.Company),
                Contract = contracts.SetContractDto(companyContract.Contract),
                Amount = companyContract.Amount,
                StartDate = string.IsNullOrWhiteSpace(companyContract.StartDate) ? (DateTime?)null : DateTime.Parse(companyContract.StartDate),
                EndDate = string.IsNullOrWhiteSpace(companyContract.EndDate) ? (DateTime?)null : DateTime.Parse(companyContract.EndDate)
            };

            return companyContractsDto;
        }

    }
}
