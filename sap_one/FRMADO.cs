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

namespace sap_one
{
    public partial class FRMADO : Form
    {
        public FRMADO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oQuery = string.Format(@"SELECT top 10 * FROM ""OITM"" ");
            dataGridView1.DataSource = VerDatos(oQuery).Tables[0];
        }
        private DataSet VerDatos(string oQuery)
        {
            SqlDataAdapter oDA = new SqlDataAdapter(oQuery, Stringconexion("LAPTOP-ICLC5GJE", "SBODemoCL", "sa", "benjamin2360"));
            DataSet oDS = new DataSet();
            oDA.Fill(oDS);
            return oDS;
        }

        private string Stringconexion(string Server, string DBName, string UserDB, string PasswordDB)
        {

            return "data source=" + Server + ";initial catalog=" + DBName + ";User id=" + UserDB + ";Password=" + PasswordDB;
        }

    }
}
