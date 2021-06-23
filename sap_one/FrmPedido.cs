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
    public partial class FrmPedido : Form
    {
        SAPbobsCOM.Recordset objreset = null;
        DataTable CotizacionDet = new DataTable();
        int accion = 0;

        private SAPbobsCOM.Company objcompany;
        public FrmPedido(SAPbobsCOM.Company obj)
        {
            InitializeComponent();
            objcompany = obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

            //int error = Conexion.conectar().Connect();
            //if (error == 0)
            //{
            //    MessageBox.Show("conexion");
            //}
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmnuevopedido frmnuevo = new Frmnuevopedido(objcompany);
            frmnuevo.ShowDialog();
        }
    }
}
