using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Database;

namespace InvoiceManager_Logic
{
    public class CompanyContracts
    {
        public List<CompanyContractsEntity> Index()
        {
            //new List<ContractModel>();
            CompanyContractsCrud companyContracts = new CompanyContractsCrud();
            List<CompanyContractsDto> companyContractsList = companyContracts.FindAll();
            List<CompanyContractsEntity> test = new List<CompanyContractsEntity>();

            foreach (var cc in companyContractsList)
            {
                CompanyContractsEntity cce = new CompanyContractsEntity(
                    cc.Id,
                    cc.Company,
                    cc.Contract,
                    cc.Amount
                );

                test.Add(cce);
            }

            return test;
        }

        private CompanyContractsDto SetCompanyContractDto(CompanyEntity company)
        {
            CompanyContractsDto test = new CompanyContractsDto();

            test.Id = company.Id;
            test.Company = new CompanyDto();
            test.Contract = new ContractDto();
            test.Amount = 3;

            return test;
        }
    }
}
