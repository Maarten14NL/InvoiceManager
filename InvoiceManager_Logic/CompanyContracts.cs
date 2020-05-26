using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Factory;
using InvoiceMananger_DatabaseInterface;

namespace InvoiceManager_Logic
{
    public class CompanyContracts
    {
        public List<CompanyContractsDto> Index()
        {
            List<CompanyContractsDto> companyContractsList = CompanyContractFactory.Read();

            return companyContractsList;
        }
    }
}
