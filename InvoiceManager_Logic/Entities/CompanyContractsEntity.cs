using InvoiceMananger_DatabaseInterface;
using Newtonsoft.Json;
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
        public string StartDate;
        public string EndDate;

        [JsonConstructor]
        public CompanyContractsEntity(int Id, CompanyEntity Company, ContractEntity Contract, int Amount, string StartDate, string EndDate)
        {
            this.Id = Id;
            this.Company = Company;
            this.Contract = Contract;
            this.Amount = Amount;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public CompanyContractsEntity(CompanyContractsDto companyContracts)
        {

            this.Id = companyContracts.Id;
            //this.Company = new CompanyEntity(companyContracts.Company);
            this.Contract = new ContractEntity(companyContracts.Contract);
            this.Amount = companyContracts.Amount;
            this.StartDate = companyContracts.ConvertNullableDateTimeToString(companyContracts.StartDate);
            this.EndDate = companyContracts.ConvertNullableDateTimeToString(companyContracts.EndDate);
        }
    }
}
