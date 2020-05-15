using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Database
{
    public class CompanyContractsCrud
    {
        private readonly Connection con = new Connection();

        public List<CompanyContractsDto> FindAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM [CompanyContract] cc ");
            sb.Append("LEFT JOIN [Companies] company ON cc.CompanyId = company.Id ");
            sb.Append("LEFT JOIN [Contracts] contract ON cc.ContractId = contract.Id ");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Select(sql);

            List<CompanyContractsDto> ContractList = new List<CompanyContractsDto>();
            while (reader.Read())
            {
                CompanyDto company = new CompanyCrud().Company(reader);

                ContractDto contract = new ContractsCrud().Contract(reader);

                CompanyContractsDto companyContract = new CompanyContractsDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Company = company,
                    Contract = contract,
                    Amount = Convert.ToInt32(reader["Amount"])
                };


                ContractList.Add(companyContract);
            }

            return ContractList;
        }
    }
}
