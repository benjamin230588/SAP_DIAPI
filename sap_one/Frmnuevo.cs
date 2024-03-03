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
    public partial class Frmnuevo : Form
    {
        SAPbobsCOM.Recordset objreset = null;
        SAPbobsCOM.BusinessPartners objsocio = null;

        private SAPbobsCOM.Company objcompany;
        private int accion;
        public Frmnuevo(SAPbobsCOM.Company obj, int accion)
        {
            objcompany = obj;
            this.accion = accion;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            var cadena=objsocio.GetType();
            //if (objsocio.GetType)
            //{

            //}
            int correlativo = 0;
            int estado = 1;
            if (accion == 1)
            {
                objsocio.CardCode = txtcodigo.Text;
                objsocio.CardName = txtname.Text;
                objsocio.EmailAddress = txtcorreo.Text;
                objsocio.AdditionalID = "CE";
                objsocio.FederalTaxID = "00000";
                objsocio.Phone1 = "9999";

                // detalle de direcciones de cliente

                for (int i = 0; i < dgdireccion.RowCount; i++)
                {
                    objsocio.Addresses.AddressName = dgdireccion.Rows[i].Cells["gdireccion"].Value.ToString();
                    objsocio.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                    objsocio.Addresses.Street = dgdireccion.Rows[i].Cells["gcalle"].Value.ToString();
                    objsocio.Addresses.Country = "PE";


                    objsocio.Addresses.Add();

                }

                //objsocio.Addresses.AddressName = "Lima";
                //objsocio.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                //objsocio.Addresses.Street = "Benjamin 1";
                //objsocio.Addresses.Country = "PE";

                //objsocio.Addresses.Add();
                //objsocio.Addresses.AddressName = "otro";
                //objsocio.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                //objsocio.Addresses.Street = "Benjamin 2";
                //objsocio.Addresses.Country = "PE";

                estado = objsocio.Add();
            }
            else
            {
                if (objsocio.GetByKey(txtcodigo.Text))
                {
                    objsocio.CardName = txtname.Text;
                    objsocio.EmailAddress = txtcorreo.Text;

                    objsocio.AdditionalID = "CE";
                    objsocio.FederalTaxID = "00000";
                    objsocio.Phone1 = "9999";

                    for (int i = 0; i < dgdireccion.RowCount; i++)
                    {
                        correlativo = Convert.ToInt32(dgdireccion.Rows[i].Cells["index"].Value) - 1;

                        if (correlativo >= 0)
                        {
                            objsocio.Addresses.SetCurrentLine(correlativo);
                            objsocio.Addresses.AddressName = dgdireccion.Rows[i].Cells["gdireccion"].Value.ToString();
                            objsocio.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                            objsocio.Addresses.Street = dgdireccion.Rows[i].Cells["gcalle"].Value.ToString();
                            objsocio.Addresses.Country = "PE";


                        }
                        else
                        {
                            objsocio.Addresses.Add();
                            objsocio.Addresses.AddressName = dgdireccion.Rows[i].Cells["gdireccion"].Value.ToString();
                            objsocio.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                            objsocio.Addresses.Street = dgdireccion.Rows[i].Cells["gcalle"].Value.ToString();
                            objsocio.Addresses.Country = "PE";


                        }


                        //objsocio.Addresses.Add();

                    }


                    // para eliminar
                    //objsocio.Addresses.SetCurrentLine(2);
                    //objsocio.Addresses.Street = "cambio hoy";
                    //oBP.Addresses.SetCurrentLine(2);
                    //oBP.Addresses.Delete();
                    //oBP.Update();


                    //.Update era final
                    //objsocio.Addresses.SetCurrentLine(0);
                    //objsocio.Addresses.Street = "final delia";


                    //objsocio.Addresses.SetCurrentLine(1);
                    //objsocio.Addresses.Street = "verdad 2";

                    //objsocio.Addresses.Add();
                    //objsocio.Addresses.AddressName = "Trujillo 7";
                    //objsocio.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo;
                    //objsocio.Addresses.Street = "Benjamin 7";
                    //objsocio.Addresses.Country = "PE";

                    estado = objsocio.Update();


                }
            }

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

        private void Frmnuevo_Load(object sender, EventArgs e)
        {

        }

        public void cargardatos(string codigo, string name, string correo)
        {
            txtcodigo.Text = codigo;
            txtname.Text = name;
            txtcorreo.Text = correo;
            cargardirecciones();

        }

        void cargardirecciones()
        {
            objreset = (SAPbobsCOM.Recordset)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sql = "select ROW_NUMBER() OVER(ORDER BY address ASC) correlativo, Address,Street from crd1 where  cardcode=" + "'" + txtcodigo.Text + "'";
            objreset.DoQuery(sql);
            //CotizacionDet.Rows.Clear();
            if (objreset.RecordCount > 0)
            {
                for (int i = 0; i < objreset.RecordCount; i++)
                {

                    dgdireccion.Rows.Add(objreset.Fields.Item("correlativo").Value.ToString(), objreset.Fields.Item("Address").Value.ToString(), objreset.Fields.Item("Street").Value.ToString());

                    objreset.MoveNext();
                }
            }

            //dataGridView1.DataSource = CotizacionDet;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dire, calle;
            dire = txtdireccion.Text;
            calle = txtcalle.Text;


            dgdireccion.Rows.Add(0, dire, calle);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int correlativo = Convert.ToInt32(dgdireccion.CurrentRow.Cells["index"].Value) - 1;
            int estado = 0;
            objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
            if (objsocio.GetByKey(txtcodigo.Text))
            {
                //objsocio.Addresses.SetCurrentLine(correlativo);
                //objsocio.Addresses.Delete();
                //estado=  objsocio.Update();
            }

            //if (estado == 0)
            //{
            //    MessageBox.Show("Direccion Eliminado con Exito");
            //    //Frmcliente cliob = new Frmcliente(objcompany);
            //    //Brigte.cargar(objcompany);

               
            //}
            //else
            //{
            //    MessageBox.Show(objcompany.GetLastErrorDescription());
            //}

            SAPbobsCOM.BPAddresses objdire = null;
            objdire = objsocio.Addresses;
            objdire.SetCurrentLine(correlativo);
            objdire.Delete();
            estado=  objsocio.Update();

            if (estado == 0)
            {
                MessageBox.Show("Direccion Eliminado con Exito");
                //Frmcliente cliob = new Frmcliente(objcompany);
                //Brigte.cargar(objcompany);


            }
            else
            {
                MessageBox.Show(objcompany.GetLastErrorDescription());
            }
        }
    }
}
