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

        private readonly Connection con = new Connection();
        public List<CompanyDto> Read(int? id = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append("cm.Id as CompanyId, cm.Name AS CompanyName, cm.CustomerNumber AS CompanCustomerNumber, cm.Iban AS CompanyIban, cm.IbanAscription AS CompanyIbanAscription, cm.PhoneNumber AS CompanyPhoneNumber, cm.Website AS CompanyWebsite, cm.Email AS CompanyEmail, cm.MandateDate AS CompanyMandateDate, cm.Hide AS CompanyHide ");
            sb.Append("FROM [Companies] cm ");
            if (id != null)
            {
                sb.Append("Where cm.Id = " + id);
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
            CompanyDto company = new CompanyDto
            {
                Id = Convert.ToInt32(data["CompanyId"]),
                Name = Convert.ToString(data["CompanyName"]),
                CustomerNumber = Convert.ToString(data["CompanCustomerNumber"]),
                Iban = Convert.ToString(data["CompanyIban"]),
                IbanAscription = Convert.ToString(data["CompanyIbanAscription"]),
                PhoneNumber = Convert.ToString(data["CompanyPhoneNumber"]),
                Website = Convert.ToString(data["CompanyWebsite"]),
                Email = Convert.ToString(data["CompanyEmail"]),
                MandateDate = Convert.ToDateTime(data["CompanyMandateDate"]),

                Hide = Convert.ToBoolean(data["CompanyHide"])
            };

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
            conn.Insert(sql);

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
            conn.Update(sql);

            return true;
        }

        public bool Delete(CompanyDto company)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [Companies]");
            sb.Append("WHERE Id = " + company.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            conn.Delete(sql);

            return true;
        }

    }
}
