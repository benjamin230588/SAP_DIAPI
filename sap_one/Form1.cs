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
    public partial class Form1 : Form
    {
        private SAPbobsCOM.Company objcompany;
        private SAPbobsCOM.BusinessPartners objsocio;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    objsocio.CardCode = "nuevobenja";
                    objsocio.CardName = "benjamin huaman";
                    objsocio.AdditionalID = "CE";
                    objsocio.FederalTaxID = "00000";
                    objsocio.Phone1 = "55555";

                   int estado= objsocio.Add();
                    if(estado==0)
                    {
                        MessageBox.Show("Cliente creado");
                    }
                    else
                    {
                        MessageBox.Show("error al crear");
                    }

                    if(objcompany.Connected==true)
                    {
                        objcompany.Disconnect();

                    }
                    
            }
            else
            {
                MessageBox.Show("error en la conexion");

            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string codigo = "nuevobenja";
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
                    objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    if(objsocio.GetByKey(codigo))
                    {
                        textBox1.Text = objsocio.CardCode;
                        textBox2.Text = objsocio.CardName;

                    }
                    //objsocio.CardCode = "nuevobenja";
                    //objsocio.CardName = "benjamin huaman";
                    //objsocio.AdditionalID = "CE";
                    //objsocio.FederalTaxID = "00000";
                    //objsocio.Phone1 = "55555";

                    //int estado = objsocio.Add();
                    //if (estado == 0)
                    //{
                    //    MessageBox.Show("Cliente creado");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("error al crear");
                    //}

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string codigo = "nuevobenja";
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
                    objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    if (objsocio.GetByKey(codigo))
                    {
                        objsocio.CardName = "cambio hoy";
                       
                        int estado = objsocio.Update();
                        if (estado == 0)
                        {
                            MessageBox.Show("Cliente modificado");
                        }
                        else
                        {
                            MessageBox.Show("error al modificar");
                        }

                    }
                    //objsocio.CardCode = "nuevobenja";
                    //objsocio.CardName = "benjamin huaman";
                    //objsocio.AdditionalID = "CE";
                    //objsocio.FederalTaxID = "00000";
                    //objsocio.Phone1 = "55555";



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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                string codigo = "nuevobenja";
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
                    objsocio = (SAPbobsCOM.BusinessPartners)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                    if (objsocio.GetByKey(codigo))
                    {


                        int estado = objsocio.Remove();
                        if (estado == 0)
                        {
                            MessageBox.Show("Cliente eliminado");
                        }
                        else
                        {
                            MessageBox.Show("error al modificar");
                        }

                    }
                    //objsocio.CardCode = "nuevobenja";
                    //objsocio.CardName = "benjamin huaman";
                    //objsocio.AdditionalID = "CE";
                    //objsocio.FederalTaxID = "00000";
                    //objsocio.Phone1 = "55555";



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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
