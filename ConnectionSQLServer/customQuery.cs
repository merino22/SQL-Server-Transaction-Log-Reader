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
    public partial class customQuery : Form
    {
        public customQuery()
        {
            InitializeComponent();
        }

        public DataTable custom = new DataTable();
        private void customQuery_Load(object sender, EventArgs e)
        {

        }

        public void btnAccept_Click(object sender, EventArgs e)
        {
            string customQuery = "SELECT ";
            string[] selectedItems;
            List<string> selectItems = new List<string>();
            int countSelected = 0;
            Console.WriteLine(tranType.SelectedItem.ToString());
            selectedItems = new string[countSelected];
            for(int i = 0; i < comboGroup.Items.Count; i++)
            {
                if(comboGroup.GetItemChecked(i))
                {
                    selectItems.Add(comboGroup.Items[i].ToString());
                }
            }
            for(int i = 0; i < selectItems.Count; i++)
            {
                if(i == selectItems.Count -1)
                {
                    customQuery += "[" + selectItems[i] + "]";
                }
                else
                {
                    customQuery += "[" + selectItems[i] + "],";
                }
               //Console.WriteLine(selectItems[i] + '\n');        
            }
            if(tranType.SelectedItem.ToString().Equals("INSERT TRANSACTIONS"))
            {
                customQuery += " FROM fn_dblog(null, null) WHERE Operation IN ('LOP_INSERT_ROWS')";
            }else if(tranType.SelectedItem.ToString().Equals("UPDATE TRANSACTIONS"))
            {
                customQuery += " FROM fn_dblog(null, null) WHERE Operation IN ('LOP_MODIFY_ROWS')";
            }
            else if (tranType.SelectedItem.ToString().Equals("DELETE TRANSACTIONS"))
            {
                customQuery += " FROM fn_dblog(null, null) WHERE Operation IN ('LOP_DELETE_ROWS')";
            }
            else
            {
                customQuery += " FROM fn_dblog(null, null) WHERE Operation IN ('LOP_DELETE_ROWS', 'LOP_INSERT_ROWS', 'LOP_MODIFY_ROWS')";
            }
            Console.WriteLine("CUSTOM QUERY: " + customQuery);

            connectionDB db = new connectionDB();
            SqlDataAdapter data = new SqlDataAdapter(customQuery, db.connectDB.ConnectionString);
            DataTable dt = new DataTable();
            data.Fill(dt);

            data.Fill(custom);

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
