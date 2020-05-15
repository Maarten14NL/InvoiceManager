using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Database
{
    public struct CompanyContractsDto
    {
        public int Id;
        public CompanyDto Company;
        public ContractDto Contract;
        public int Amount;
    }
}
