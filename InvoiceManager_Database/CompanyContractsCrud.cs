using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceMananger_DatabaseInterface;

namespace InvoiceManager_Database
{
    public class CompanyContractsCrud : ICompanyContracts
    {
        private readonly Connection con = new Connection();

        public List<CompanyContractsDto> Read()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");

            sb.Append("cc.Id as CompanyContractId, cc.Amount AS CompanyContractAmount, cc.StartDate AS CompanyContractStartDate, cc.EndDate AS CompanyContractEndDate, ");
            sb.Append("cm.Id as CompanyId, cm.Name AS CompanyName, cm.CustomerNumber AS CompanCustomerNumber, cm.Iban AS CompanyIban, cm.IbanAscription AS CompanyIbanAscription, cm.PhoneNumber AS CompanyPhoneNumber, cm.Website AS CompanyWebsite, cm.Email AS CompanyEmail, cm.MandateDate AS CompanyMandateDate, cm.Hide AS CompanyHide, ");
            sb.Append("ct.Id as ContractId, ct.Name AS ContractName, ct.Description AS ContractDescription, ct.Price AS ContractPrice, ct.Hide AS ContractHide ");

            sb.Append("FROM [CompanyContract] cc ");
            sb.Append("LEFT JOIN [Companies] cm ON cc.CompanyId = company.Id ");
            sb.Append("LEFT JOIN [Contracts] ct ON cc.ContractId = contract.Id ");
            String sql = sb.ToString();

            var reader = con.Select(sql);

            List<CompanyContractsDto> ContractList = new List<CompanyContractsDto>();
            while (reader.Read())
            {
                CompanyDto company = new CompanyCrud().Company(reader);

                ContractDto contract = new ContractsCrud().Contract(reader);

                ContractList.Add(CompanyContract(reader, company, contract));
            }

            return ContractList;
        }

        public List<CompanyContractsDto> GetByCompany(int companyId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  ");

            sb.Append("cc.Id as CompanyContractId, cc.Amount AS CompanyContractAmount, cc.StartDate AS CompanyContractStartDate, cc.EndDate AS CompanyContractEndDate, ");
            sb.Append("cm.Id as CompanyId, cm.Name AS CompanyName, cm.CustomerNumber AS CompanCustomerNumber, cm.Iban AS CompanyIban, cm.IbanAscription AS CompanyIbanAscription, cm.PhoneNumber AS CompanyPhoneNumber, cm.Website AS CompanyWebsite, cm.Email AS CompanyEmail, cm.MandateDate AS CompanyMandateDate, cm.Hide AS CompanyHide, COALESCE(totalContracts.cnt,0) as TotalContracts, ");
            sb.Append("ct.Id as ContractId, ct.Name AS ContractName, ct.Description AS ContractDescription, ct.Price AS ContractPrice, ct.Hide AS ContractHide ");

            sb.Append("FROM [CompanyContract] cc ");
            sb.Append("LEFT JOIN [Companies] cm ON cc.CompanyId = cm.Id ");
            sb.Append("LEFT JOIN [Contracts] ct ON cc.ContractId = ct.Id ");
            sb.Append("LEFT OUTER JOIN (SELECT totalContracts.CompanyId, count(*) cnt FROM [CompanyContract] totalContracts GROUP BY totalContracts.CompanyId) totalContracts ON cm.Id = totalContracts.CompanyId  ");
            sb.Append("Where cc.CompanyId = " + companyId);
            String sql = sb.ToString();

            var reader = con.Select(sql);

            List<CompanyContractsDto> ContractList = new List<CompanyContractsDto>();
            while (reader.Read())
            {
                CompanyDto company = new CompanyCrud().Company(reader);

                ContractDto contract = new ContractsCrud().Contract(reader);

                ContractList.Add(CompanyContract(reader, company, contract));
            }


            return ContractList;
        }

        public CompanyContractsDto CompanyContract(dynamic data, CompanyDto company, ContractDto contract)
        { 
            CompanyContractsDto cc = new CompanyContractsDto
            {
                Id = Convert.ToInt32(data["CompanyContractId"]),
                Company = company,
                Contract = contract,
                Amount = Convert.ToInt32(data["CompanyContractAmount"]),
                StartDate = Convert.ToDateTime(data["CompanyContractStartDate"]),
                EndDate = Convert.ToDateTime(data["CompanyContractEndDate"])

            };

            return cc;
        }

        public bool Create(CompanyContractsDto companyContract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [CompanyContract]");
            sb.Append("(CompanyId, ContractId, Amount, StartDate, EndDate)");
            sb.Append("VALUES ( '" + companyContract.Company.Id + "', '" + companyContract.Contract.Id + "', '" + companyContract.Amount + "', '" + companyContract.ConvertNullableDateTimeToString(companyContract.StartDate) + "', '" + companyContract.ConvertNullableDateTimeToString(companyContract.EndDate) + "')");
            String sql = sb.ToString();

            con.Insert(sql);

            return true;
        }

        public bool Update(CompanyContractsDto companyContract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [CompanyContract] SET ");
            sb.Append("CompanyId = '" + companyContract.Company.Id + "', ");
            sb.Append("ContractId = '" + companyContract.Contract.Id + "', ");
            sb.Append("Amount = '" + companyContract.Amount + "', ");
            sb.Append("StartDate = '" + companyContract.ConvertNullableDateTimeToString(companyContract.StartDate) + "', ");
            sb.Append("EndDate = '" + companyContract.ConvertNullableDateTimeToString(companyContract.EndDate) + "' ");

            sb.Append("WHERE Id = " + companyContract.Id);
            String sql = sb.ToString();

            con.Update(sql);

            return true;
        }
    }
}
