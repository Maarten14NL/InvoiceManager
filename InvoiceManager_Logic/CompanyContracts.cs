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

    }
}
