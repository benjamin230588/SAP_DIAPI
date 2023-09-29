using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIAPIBENJA
{
    public partial class Form1 : Form
    {
        SAPbobsCOM.Company objcompany;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objcompany = new SAPbobsCOM.Company();
            objcompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            objcompany.Server = "LAPTOP-ICLC5GJE";
            objcompany.CompanyDB = "SBODemoCL";
            objcompany.UserName = "manager";
            objcompany.Password = "manager";
            objcompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

            int error = objcompany.Connect();
            if (error == 0)
            {
                MessageBox.Show("conexion exitosa");
                //Principal frm = new Principal(objcompany);
                //frm.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show(objcompany.GetLastErrorDescription());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.BusinessPartners objsocio = null;
            objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);

            int estado = 1;

            objsocio.CardCode = "julio29";
            objsocio.CardName = "julio";
            objsocio.EmailAddress = "lima";
            objsocio.AdditionalID = "111";
            objsocio.FederalTaxID = "22";
            objsocio.Phone1 = "222";



            estado = objsocio.Add();
            if (estado == 0)
            {
                MessageBox.Show("Cliente Guardado con Exito");
                //Frmcliente cliob = new Frmcliente(objcompany);
                //Brigte.cargar(objcompany);

                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show(objcompany.GetLastErrorDescription());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string oQuery = string.Format(@"SELECT top 10 * FROM ""OITM"" ");
            oRS.DoQuery(oQuery);
            dataGridView1.Rows.Clear();
            oRS.MoveFirst();
            while (!oRS.EoF)
            {
                dataGridView1.Rows.Add(oRS.Fields.Item("ItemCode").Value, oRS.Fields.Item("ItemName").Value);

                oRS.MoveNext();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.BusinessPartners objsocio = null;
            objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            if (objsocio.GetByKey(textBox1.Text))
            {
                textBox1.Text = objsocio.CardCode;
                textBox2.Text = objsocio.CardName;

            }
        }
    }
}
