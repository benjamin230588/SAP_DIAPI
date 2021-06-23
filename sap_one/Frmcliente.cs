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
    public partial class Frmcliente : Form
    {
        SAPbobsCOM.Recordset objreset = null;
        DataTable CotizacionDet = new DataTable();
        int accion = 0;
        
        private SAPbobsCOM.Company objcompany;

        public Frmcliente(SAPbobsCOM.Company obj)
        {
            objcompany = obj;
            InitializeComponent();
        }

        private void Frmcliente_Load(object sender, EventArgs e)
        {
            creartabla();
            cargar();

          
        }
        private void creartabla()
        {
            CotizacionDet.Columns.Add("Codigo", Type.GetType("System.String"));
            CotizacionDet.Columns.Add("Nombre", Type.GetType("System.String"));
            CotizacionDet.Columns.Add("Correo", Type.GetType("System.String"));
        }

        public void cargar()
        {
           

            objreset = (SAPbobsCOM.Recordset)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sql = "select cardcode,cardname,e_mail from ocrd";
            objreset.DoQuery(sql);
            CotizacionDet.Rows.Clear();
            if (objreset.RecordCount > 0)
            {
                for (int i = 0; i < objreset.RecordCount; i++)
                {
                    DataRow row = CotizacionDet.NewRow();
                    row["codigo"] = objreset.Fields.Item("cardcode").Value.ToString();
                    row["nombre"] = objreset.Fields.Item("CardName").Value.ToString();
                    row["correo"] = objreset.Fields.Item("e_mail").Value.ToString();

                    CotizacionDet.Rows.Add(row);

                    objreset.MoveNext();
                }
            }

            dataGridView1.DataSource = CotizacionDet;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accion = 1;
            Frmnuevo frmnuevo = new Frmnuevo(objcompany,accion);

            frmnuevo.ShowDialog();

            cargar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filtro = txtfiltro.Text;
            objreset = (SAPbobsCOM.Recordset)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sql = "select cardcode,cardname,e_mail from ocrd where  cardname like '%" + filtro + "%' ";
            objreset.DoQuery(sql);
            CotizacionDet.Rows.Clear();
            if (objreset.RecordCount > 0)
            {
                for (int i = 0; i < objreset.RecordCount; i++)
                {
                    DataRow row = CotizacionDet.NewRow();
                    row["codigo"] = objreset.Fields.Item("cardcode").Value.ToString();
                    row["nombre"] = objreset.Fields.Item("CardName").Value.ToString();
                    row["correo"] = objreset.Fields.Item("e_mail").Value.ToString();

                    CotizacionDet.Rows.Add(row);

                    objreset.MoveNext();
                }
            }

            dataGridView1.DataSource = CotizacionDet;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            accion = 0;

            Frmnuevo frmnuevo =new Frmnuevo(objcompany,accion);
            string codigo, name, correo;
            codigo = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Codigo"].Value);
            name = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Nombre"].Value);
            correo = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Correo"].Value);
            frmnuevo.cargardatos(codigo, name, correo);
            frmnuevo.ShowDialog();
            cargar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string codigo;
            SAPbobsCOM.BusinessPartners   objsocio = objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            codigo = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Codigo"].Value);
            if (objsocio.GetByKey(codigo))
            {
                int estado = objsocio.Remove();
                if (estado == 0)
                {
                    MessageBox.Show("Cliente eliminado");
                    cargar();
                }
                else
                {
                   MessageBox.Show(objcompany.GetLastErrorDescription());
                }

            }
        }
    } 
}

