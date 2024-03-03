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
    public partial class Login : Form
    {
        private SAPbobsCOM.Company objcompany;
      
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // diferenciar estructura de base de datos(Tablas)
                // propiedades del di api 
                // que son distintas
                // en el ejemplo del sdk la tabla del objeto(base de datos) solo tiene prooiedades de los campos
                // de la tabla no de las tablas detalle
                // como accedo al detalle de las tablas observando la estructura del objeto en el sdk
                //SAPbobsCOM.Company objcompany23 = (SAPbobsCOM.Company)new Object() ;
                //if (objcompany23 == null)
                //{

                //}
                SAPbobsCOM.Company objcompany = new SAPbobsCOM.Company();
                objcompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
                objcompany.Server = "LAPTOP-ICLC5GJE";
                objcompany.CompanyDB = "SBODemoCL";
                objcompany.UserName = "manager";
                objcompany.Password = "manager";
                objcompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

                int error = objcompany.Connect();
                if (error == 0)
                {
                    Principal frm = new Principal(objcompany);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(objcompany.GetLastErrorDescription());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
