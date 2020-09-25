using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionSQLServer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        connectionDB db = new connectionDB();
        string queryString = "SELECT * FROM sys.databases";
        private void Form2_Load(object sender, EventArgs e)
        {

            Console.WriteLine("cbox");
            SqlCommand cmd = new SqlCommand(queryString, db.connectDB);
            db.connectDB.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                        
                    comboDBs.Items.Add(reader[0]);
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
        }

 
    }
}
