using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Database
{
    class CompanyCrud
    {

        private Connection con = new Connection();
        public List<CompanyDto> FindAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM [Contracts] ct ");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "SELECT");

            List<CompanyDto> ContractList = new List<CompanyDto>();
            while (reader.Read())
            {
                CompanyDto company = new CompanyDto();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.Name = Convert.ToString(reader["Name"]);
                company.Hide = Convert.ToBoolean(reader["Hide"]);

                ContractList.Add(company);
            }

            return ContractList;
        }

        public void Create(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Contracts]");
            sb.Append("(Name, Description, Price)");
            //sb.Append("VALUES ( '" + company.Name + "', '" + company.Description + "', '" + company.Price + "' )");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "INSERT");
        }

        public void Update(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [Contracts] SET ");
            sb.Append("Name = '" + company.Name + "', ");
            //sb.Append("Description = '" + company.Description + "', ");
            //sb.Append("Price = '" + contract.Price + "', " );
            sb.Append("Hide = '" + company.Hide + "' ");
            sb.Append("WHERE Id = " + company.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "UPDATE");
        }

        public void Delete(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [Contracts]");
            sb.Append("WHERE Id = " + company.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "DELETE");
        }

    }
}
