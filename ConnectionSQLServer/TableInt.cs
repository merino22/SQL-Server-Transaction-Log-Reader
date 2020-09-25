using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionSQLServer
{
    public class TableInt
    {
        connectionDB db = new connectionDB();

        public DataTable showInts()
        {
            SqlDataAdapter data = new SqlDataAdapter("SP_TLOG", db.connectDB.ConnectionString);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public DataTable showInserts()
        {
            SqlDataAdapter data = new SqlDataAdapter("SP_TLOG_INSERT", db.connectDB.ConnectionString);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public DataTable showDeletes()
        {
            SqlDataAdapter data = new SqlDataAdapter("SP_TLOG_DELETE", db.connectDB.ConnectionString);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public DataTable showUpdates()
        {
            SqlDataAdapter data = new SqlDataAdapter("SP_TLOG_UPDATE", db.connectDB.ConnectionString);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public void getInfo()
        {

            SqlConnection connection;
            SqlCommand command;

            SqlDataReader dataReader;
            string connectionString = "Data Source = LAPTOP-NVM8LJNB; Initial Catalog = test1; Integrated Security = True";
            string sql = "Select[RowLog Contents 0] FROM fn_dblog(null,null) WHERE Operation = 'LOP_INSERT_ROWS'";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                byte[] bytes = null;
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    bytes = (byte[])dataReader[0];
                }
                string y = Encoding.UTF8.GetString(bytes);
                dataReader.Close();
                command.Dispose();
                MessageBox.Show(y);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable BindGrid()
        {
            string constring = "Data Source = LAPTOP-NVM8LJNB; Initial Catalog = test1; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                // " BEGIN TRAN TRN_INSERT INSERT INTO productos(Product_Name, Product_Id) VALUES('Ch', 14) " + "COMMIT TRAN TRN_INSERT " +
                string queryStr = "SELECT [RowLog Contents 0], [RowLog Contents 1], [RowLog Contents 2],[RowLog Contents 3], [RowLog Contents 4], [RowLog Contents 5] FROM fn_dblog(null, null) WHERE Operation IN('LOP_DELETE_ROWS', 'LOP_INSERT_ROWS', 'LOP_MODIFY_ROW')";
                string sql = "SELECT [Transaction ID],[RowLog Contents 0], [RowLog Contents 2] FROM fn_dblog(null,null) WHERE [Transaction ID] IN( SELECT[Transaction ID] FROM fn_dblog(null, null) WHERE[Transaction Name] = 'TRN_INSERT') AND Operation = 'LOP_INSERT_ROWS'";

                using (SqlDataAdapter sda = new SqlDataAdapter(queryStr, constring))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        string y = Encoding.UTF8.GetString((byte[])dt.Rows[0][1]);
                        byte[] bytes = (byte[])dt.Rows[0][1];
                        /*foreach(Byte b in (byte [])dt.Rows[0][1])
                    {

                    }*/
                        Console.WriteLine(bytes[3].ToString());
                        MessageBox.Show(y);
                        //Console.WriteLine( dt.Rows[0][0].ToString());
                        return dt;
                    }
                }

            }
        }

        public List<Contents> showData()
        {
            string queryStr = "SELECT CONVERT(varchar(MAX), [RowLog Contents 0]), CONVERT(varchar(MAX), [RowLog Contents 1]), CONVERT(varchar(MAX), [RowLog Contents 2]), CONVERT(varchar(MAX), [RowLog Contents 3]), CONVERT(varchar(MAX), [RowLog Contents 4]), CONVERT(varchar(MAX), [RowLog Contents 5]) FROM fn_dblog(null, null) WHERE Operation IN('LOP_DELETE_ROWS', 'LOP_INSERT_ROWS', 'LOP_MODIFY_ROW')";
            string queryStr2 = "SELECT * FROM dbo.int_values";
            SqlCommand cmd = new SqlCommand(queryStr, db.connectDB);
            db.connectDB.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Contents> active = new List<Contents>();
            try
            {
                while(reader.Read())
                {
                    var contents = new Contents();
                    Console.Write(reader.GetString(0).ToString());
                    contents.RowLog1 = reader[1].ToString();
                    contents.RowLog2 = reader[2].ToString();
                    contents.RowLog3 = reader[3].ToString();
                    contents.RowLog4 = reader[4].ToString();
                    contents.RowLog5 = reader[5].ToString();

                    Console.WriteLine("0: " + contents.RowLog0);
                    Console.WriteLine("1: " + contents.RowLog1);
                    Console.WriteLine("2: " + contents.RowLog2);
                    Console.WriteLine("3: " + contents.RowLog3);
                    Console.WriteLine("4: " + contents.RowLog4);
                    Console.WriteLine("5: " + contents.RowLog5);
                    active.Add(contents);
                }
                return active;
            }
            finally
            {
                reader.Close();
                db.connectDB.Close();
            }
        }
    }
}
