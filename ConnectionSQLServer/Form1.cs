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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        connectionDB connection = new connectionDB();
        TableInt tab = new TableInt();
        private void Form1_Load_1(object sender, EventArgs e)
        {

            Console.WriteLine("write line");
        }

        private void dvgInts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            tab.showData();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAllTransactions_Click(object sender, EventArgs e)
        {
            connection.abrir();
            dvgInts.DataSource = tab.showInts();
            //tab.getInfo();
            connection.cerrar();
        }

        private void btnInsertTr_Click(object sender, EventArgs e)
        {
            connection.abrir();
            dvgInts.DataSource = tab.showInserts();
            connection.cerrar();
        }

        private void btnDeleteTr_Click(object sender, EventArgs e)
        {
            connection.abrir();
            dvgInts.DataSource = tab.showDeletes();
            connection.cerrar();
        }

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            connection.abrir();
            dvgInts.DataSource = tab.showUpdates();
            connection.cerrar();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            customQuery custom = new customQuery();
            custom.ShowDialog();
            dvgInts.DataSource = custom.custom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "Data Source = LAPTOP-NVM8LJNB; Initial Catalog = test1; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cm = new SqlCommand("Select [RowLog Contents 0] FROM fn_dblog(null,null) WHERE Operation = 'LOP_INSERT_ROWS'", con);
                cm.CommandType = CommandType.Text;
                SqlDataAdapter sd = new SqlDataAdapter(cm);
                DataTable dtt = new DataTable();
                sd.Fill(dtt);

                byte[] bytes = (byte[])dtt.Rows[0][0];
                dtt.Dispose();
                sd.Dispose();
                cm.Dispose();
                //INSERT INTO productos(Product_Name, Product_Id) VALUES('Chec', 7)  WHERE Operation = 'LOP_INSERT_ROWS'
                using (SqlCommand cmd = new SqlCommand("Select [Transaction ID], [Begin Time], Operation, [Log Record Length], [Current LSN],[AllocUnitName], Description FROM fn_dblog(null,null) WHERE Operation = 'LOP_INSERT_ROWS'", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            byte[] by = { bytes[20], bytes[21], bytes[22], bytes[23] };
                            string recio = Encoding.UTF8.GetString(by);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dt.Rows[i][1] = recio;
                            }

                            dvgInts.DataSource = dt;
                            //dvgInts.Columns["Redo"].Visible = true;
                            //dvgInts.Columns["Undo"].Visible = true;
                        }
                    }
                }
            }
        }
    }
}
