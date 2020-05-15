using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace InvoiceManager_Database
{
    public class Connection
    {

        private static void Main()
        {
            //switch (sqlType)
            //{
            //    case "INSERT":
            //    case "UPDATE":
            //    case "DELETE":

            //        using (SqlDataAdapter adapter = new SqlDataAdapter())
            //        {
            //            adapter.InsertCommand = command;
            //            adapter.InsertCommand.ExecuteNonQuery();
            //            return true;
            //        }
            //        break;


            //    case "SELECT":
            //    default:
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            var dt = new DataTable();
            //            dt.Load(reader);
            //            return dt.CreateDataReader();
            //        }
            //        break;
            //}
        }

        private string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=aspnet-InvoiceManager-20200211010222;Trusted_Connection=true";
        

        public DataTableReader Select(string sql)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        return dt.CreateDataReader();
                    };
                }
            }
            
        }

        public bool Insert(string sql)
        {
            return ModifyData(sql);
        }

        public bool Update(string sql)
        {
            return ModifyData(sql);
        }

        public bool Delete(string sql)
        {
            return ModifyData(sql);
        }

        private bool ModifyData(string sql)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.InsertCommand = command;
                            adapter.InsertCommand.ExecuteNonQuery();
                            return true;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
