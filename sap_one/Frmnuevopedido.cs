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
    public partial class Frmnuevopedido : Form
    {
        SAPbobsCOM.Recordset objreset = null;
        SAPbobsCOM.Documents objdoc=null;

        private SAPbobsCOM.Company objcompany;
        private int accion;
        public Frmnuevopedido(SAPbobsCOM.Company obj)
        {
            InitializeComponent();
            objcompany = obj;
        }

        private void Frmnuevopedido_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string docentry;
            objdoc = objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);
            string fecha1 = "14-06-2017";
            DateTime fecha = Convert.ToDateTime(fecha1);
            objdoc.DocDate = fecha;
            objdoc.DocDueDate = fecha;
            objdoc.CardCode = "C20000";
            //objdoc.DocumentStatus = SAPbobsCOM.BoStatus.bost_Open;
            // PRUEBA
            objdoc.Lines.ItemCode = "1234kk";
            objdoc.Lines.Quantity = 7;
            objdoc.Lines.PriceAfterVAT = 100;

            objdoc.Lines.Add();
            objdoc.Lines.ItemCode = "A00001";
            objdoc.Lines.Quantity = 7;
            objdoc.Lines.PriceAfterVAT = 200;


            int estado = objdoc.Add();
            if (estado == 0)
            {
                docentry = objcompany.GetNewObjectKey();
                MessageBox.Show("Pedido creado nro" + docentry);
            }
            else
            {
                MessageBox.Show("error al crear");
            }

        }
    }
}
