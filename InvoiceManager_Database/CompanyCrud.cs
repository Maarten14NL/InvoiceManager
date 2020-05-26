using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceMananger_DatabaseInterface;

namespace InvoiceManager_Database
{
    public class CompanyCrud: ICompany
    {

        private Connection con = new Connection();
        public List<CompanyDto> Read(int? id = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM [Companies] cp ");
            if(id != null)
            {
                sb.Append("Where Id = " + id);
            }
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Select(sql);

            List<CompanyDto> ContractList = new List<CompanyDto>();
            while (reader.Read())
            {
                ContractList.Add(this.Company(reader));
            }

            return ContractList;
        }

        public CompanyDto Company(dynamic data)
        {
            CompanyDto company = new CompanyDto();
            company.Id = Convert.ToInt32(data["Id"]);
            company.Name = Convert.ToString(data["Name"]);
            company.CustomerNumber = Convert.ToString(data["CustomerNumber"]);
            company.Iban = Convert.ToString(data["Iban"]);
            company.IbanAscription = Convert.ToString(data["IbanAscription"]);
            company.PhoneNumber = Convert.ToString(data["PhoneNumber"]);
            company.Website = Convert.ToString(data["Website"]);
            company.Email = Convert.ToString(data["Email"]);
            company.MandateDate = Convert.ToDateTime(data["MandateDate"]);

            company.Hide = Convert.ToBoolean(data["Hide"]);

            return company;
        }

        public bool Create(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Companies]");
            sb.Append("(Name, CustomerNumber, Iban, IbanAscription, PhoneNumber, Website, Email, MandateDate, Hide)");
            sb.Append("VALUES ( '" + company.Name + "', '" + company.CustomerNumber + "', '" + company.Iban + "', '" + company.IbanAscription + "', '" + company.PhoneNumber + "', '" + company.Website + "', '" + company.Email + "', '" + company.MandateDate + "', 0 )");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Insert(sql);

            return true;
        }

        public bool Update(CompanyDto company)
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
            var reader = conn.Update(sql);

            return true;
        }

        public bool Delete(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [Companies]");
            sb.Append("WHERE Id = " + company.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Delete(sql);

            return true;
        }

    }
}
