using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sap_one
{
    public partial class Form2 : Form
    {
        private SAPbobsCOM.Company objcompany;
        private SAPbobsCOM.Documents objdoc;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            // grabar pedido en sap businnes one mediante di api
            try
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
                    string fecha1 = "14-06-2017";
                    DateTime fecha =Convert.ToDateTime(fecha1) ;

                    objdoc = objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
                    objdoc.DocDate = fecha;
                    objdoc.DocDueDate = fecha;
                    objdoc.CardCode = "C20000";

                    objdoc.Lines.ItemCode = "1234kk";
                    objdoc.Lines.Quantity = 10;
                    objdoc.Lines.PriceAfterVAT = 100;

                    objdoc.Lines.Add();
                    objdoc.Lines.ItemCode = "A00001";
                    objdoc.Lines.Quantity = 20;
                    objdoc.Lines.PriceAfterVAT = 200;


                    int estado = objdoc.Add();
                    if (estado == 0)
                    {
                        MessageBox.Show("Pedido creado");
                    }
                    else
                    {
                        MessageBox.Show("error al crear");
                    }

                    if (objcompany.Connected == true)
                    {
                        objcompany.Disconnect();

                    }

                }
                else
                {
                    MessageBox.Show("error en la conexion");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
