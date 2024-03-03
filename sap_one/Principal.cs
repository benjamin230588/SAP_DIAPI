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
    public partial class Principal : Form
    {
        private SAPbobsCOM.Company objcompany;
        public Principal(SAPbobsCOM.Company obj)
        {
            objcompany = obj;
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmcliente frmcli = new Frmcliente(objcompany);
            frmcli.MdiParent = this;
            frmcli.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPedido frmped = new FrmPedido(objcompany);
            frmped.MdiParent = this;
            frmped.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            if (objcompany.Connected == true)
            {
                objcompany.Disconnect();

            }
        }

        private void tipoCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTIPOCAMBIO frmcli = new FormTIPOCAMBIO(objcompany);
            frmcli.MdiParent = this;
            frmcli.Show();
            
        }
    }
}
