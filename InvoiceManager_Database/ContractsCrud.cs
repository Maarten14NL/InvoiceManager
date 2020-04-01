using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Database
{
    public class ContractsCrud
    {            
        private Connection con = new Connection();
        public List<ContractDto> FindAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM [Contracts] ct ");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "SELECT");

            List<ContractDto> ContractList = new List<ContractDto>();
            while (reader.Read())
            {
                ContractDto contract = new ContractDto();
                contract.Id             = Convert.ToInt32(reader["Id"]);
                contract.Name           = Convert.ToString(reader["Name"]);
                contract.Description    = Convert.ToString(reader["Description"]);
                contract.Price          = Convert.ToDouble(reader["Price"]); 
                contract.Hide           = Convert.ToBoolean(reader["Hide"]);

                ContractList.Add(contract);
            }

            return ContractList;
        }

        public void Create(ContractDto contract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Contracts]");
            sb.Append("(Name, Description, Price)");
            sb.Append("VALUES ( '" + contract.Name + "', '" + contract.Description + "', '" + contract.Price + "' )");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "INSERT");
        }

        public void Update(ContractDto contract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [Contracts] SET ");
            sb.Append("Name = '"+ contract.Name +"', ");
            sb.Append("Description = '" + contract.Description + "', ");
            //sb.Append("Price = '" + contract.Price + "', " );
            sb.Append("Hide = '" + contract.Hide + "' ");
            sb.Append("WHERE Id = " + contract.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "UPDATE");
        }

        public void Delete(ContractDto contract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [Contracts]");
            sb.Append("WHERE Id = " + contract.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Query(sql, "DELETE");
        }
       

    }
}
