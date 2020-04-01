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

        }

        public dynamic Query(string sql, string sqlType)
        {
            try
            {

                string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=aspnet-InvoiceManager-20200211010222;Trusted_Connection=true";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        

                            //List<SqlDataReader> Data = new List<SqlDataReader>();
                            //while (reader.Read())
                            //{
                            //    Data.Add(reader);
                            //}
                        switch (sqlType)
                        {
                            case "INSERT":
                            case "UPDATE":
                            case "DELETE":

                                using (SqlDataAdapter adapter = new SqlDataAdapter())
                                {
                                    adapter.InsertCommand = command;
                                    adapter.InsertCommand.ExecuteNonQuery();
                                    return true;
                                }
                                break;


                            case "SELECT":
                            default:
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    var dt = new DataTable();
                                    dt.Load(reader);
                                    return dt.CreateDataReader();
                                }
                                break;
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
