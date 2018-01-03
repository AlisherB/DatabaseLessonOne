using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = @"Provider=SQLOLEDB.1;
            //                            Persist Security Info=False;
            //                            User ID=sa;
            //                            Password = Shag1115;
            //                            Initial Catalog=NORTHWND;
            //                            Data Source=SQL";
            //try
            //{
            //    //OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            //    //oleDbConnection.Open();
            //    SqlConnection sqlConnection = new SqlConnection(connectionString);
            //    sqlConnection.Open();
            //    Console.WriteLine("Success");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //Console.ReadLine();

            //string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();

            //try
            //{
            //    SqlConnection sqlConnection = new SqlConnection(connectionString);
            //    sqlConnection.Open();
            //    Console.WriteLine("Success");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //Console.ReadLine();

            string defaultConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder(defaultConnectionString);

            //{
            //    //PersistSecurityInfo = false,
            //    //UserID = "sa",
            //    //Password = "Shag1115",
            //    //InitialCatalog = "NORTHWND",
            //    //DataSource = "SQL"
            //};
            string connectionString = sqlConnectionString.ToString();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText= "SELECT COUNT(name) \"CountOfRecords\" FROM sys.tables";
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                    Console.WriteLine(sqlDataReader["CountOfRecords"]);
                sqlConnection.Close();

                //Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();

        }
    }
}
