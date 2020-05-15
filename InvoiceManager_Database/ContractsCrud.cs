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
        private readonly Connection _con = new Connection();
        public List<ContractDto> Read(int? id = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM [Contracts] ct ");
            if (id != null)
            {
                sb.Append("Where Id = " + id);
            }

            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Select(sql);

            List<ContractDto> ContractList = new List<ContractDto>();
            while (reader.Read())
            {
                ContractList.Add(this.Contract(reader));
            }

            return ContractList;
        }
        public ContractDto Contract(dynamic data)
        {
            ContractDto contract = new ContractDto
            {
                Id = Convert.ToInt32(data["Id"]),
                Name = Convert.ToString(data["Name"]),
                Description = Convert.ToString(data["Description"]),
                Price = Convert.ToDouble(data["Price"]),
                Hide = Convert.ToBoolean(data["Hide"])
            };

            return contract;
        }

        public void Create(ContractDto contract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Contracts]");
            sb.Append("(Name, Description, Price)");
            sb.Append("VALUES ( '" + contract.Name + "', '" + contract.Description + "', '" + contract.Price + "' )");
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Insert(sql);
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
            var reader = conn.Update(sql);
        }

        public void Delete(ContractDto contract)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM [Contracts]");
            sb.Append("WHERE Id = " + contract.Id);
            String sql = sb.ToString();

            Connection conn = new Connection();
            var reader = conn.Delete(sql);
        }
       

    }
}
