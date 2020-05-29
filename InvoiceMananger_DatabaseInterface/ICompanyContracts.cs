using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMananger_DatabaseInterface
{
    public interface ICompanyContracts
    {
        List<CompanyContractsDto> Read();
        List<CompanyContractsDto> GetByCompany(int companyId);
    }

    public struct CompanyContractsDto
    {
        public int Id;
        public CompanyDto Company;
        public ContractDto Contract;
        public int Amount;
    }
}
