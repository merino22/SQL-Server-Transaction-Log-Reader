using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectionSQLServer
{
    class connectionDB
    {
        string connDB = "";
        public string connStr = "Data Source=LAPTOP-NVM8LJNB;Initial Catalog=test1;Integrated Security=True";
        public SqlConnection connectDB = new SqlConnection();

        public connectionDB()
        {
            connectDB.ConnectionString = connStr;
        }

        public void abrir()
        {
            try
            {
                connectDB.Open();
                Console.WriteLine("Open Connection HEREEEEE");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while trying to open DB");
            }
        }

        public void cerrar()
        {
            connectDB.Close();
            Console.WriteLine("Connection to DB Closed.");
        }
    }
}
