using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic.Entities
{
    public class CompanyContractsEntity
    {
        public int Id;
        public CompanyEntity Company;
        public ContractEntity Contract;
        public int Amount;

        public CompanyContractsEntity(int Id, CompanyEntity Company, ContractEntity Contract, int Amount)
        {
            this.Id = Id;
            this.Company = Company;
            this.Contract = Contract;
            this.Amount = Amount;
        }
    }
}
