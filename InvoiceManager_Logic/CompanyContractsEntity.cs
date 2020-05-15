using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InvoiceManager_Database;

namespace InvoiceManager_Logic
{
    public class CompanyContractsEntity
    {
        public int Id;
        public CompanyDto Company;
        public ContractDto Contract;
        public int Amount;

        public CompanyContractsEntity(int Id, CompanyDto Company, ContractDto Contract, int Amount)
        {
            this.Id = Id;
            this.Company = Company;
            this.Contract = Contract;
            this.Amount = Amount;
        }

    }
}
