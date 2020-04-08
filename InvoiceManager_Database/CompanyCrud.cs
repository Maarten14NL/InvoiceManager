using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Database
{
    public class CompanyCrud
    {

        private Connection con = new Connection();
        public List<CompanyDto> FindAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM [Companies] cp ");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "SELECT");

            List<CompanyDto> ContractList = new List<CompanyDto>();
            while (reader.Read())
            {
                CompanyDto company = new CompanyDto();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.Name = Convert.ToString(reader["Name"]);
                company.CustomerNumber = Convert.ToString(reader["CustomerNumber"]);
                company.Iban = Convert.ToString(reader["Iban"]);
                company.IbanAscription = Convert.ToString(reader["IbanAscription"]);
                company.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                company.Website = Convert.ToString(reader["Website"]);
                company.Email = Convert.ToString(reader["Email"]);
                company.MandateDate = Convert.ToDateTime(reader["MandateDate"]);

                company.Hide = Convert.ToBoolean(reader["Hide"]);

                ContractList.Add(company);
            }

            return ContractList;
        }

        public void Create(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Companies]");
            sb.Append("(Name, CustomerNumber, Iban, IbanAscription, PhoneNumber, Website, Email, MandateDate, Hide)");
            sb.Append("VALUES ( '" + company.Name + "', '" + company.CustomerNumber + "', '" + company.Iban + "', '" + company.IbanAscription + "', '" + company.PhoneNumber + "', '" + company.Website + "', '" + company.Email + "', '" + company.MandateDate + "', 0 )");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "INSERT");
        }

        public void Update(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [Companies] SET ");
            sb.Append("Name = '" + company.Name + "', ");
            sb.Append("CustomerNumber = '" + company.CustomerNumber + "', ");
            sb.Append("Iban = '" + company.Iban + "', ");
            sb.Append("IbanAscription = '" + company.IbanAscription + "', ");
            sb.Append("PhoneNumber = '" + company.PhoneNumber + "', ");
            sb.Append("Website = '" + company.Website + "', ");
            sb.Append("Email = '" + company.Email + "', ");
            sb.Append("MandateDate = '" + company.MandateDate + "', ");

            sb.Append("Hide = '" + company.Hide + "' ");
            sb.Append("WHERE Id = " + company.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "UPDATE");
        }

        public void Delete(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [Companies]");
            sb.Append("WHERE Id = " + company.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "DELETE");
        }

    }
}
