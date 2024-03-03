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
    public partial class HANADIAPICONEXION : Form
    {
        public HANADIAPICONEXION()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.Company objcompany = new SAPbobsCOM.Company();
            objcompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
            objcompany.Server = "KPL@kpl-sap.koplastindustrial.com:30013";

            objcompany.LicenseServer = "192.168.5.226:40000";
            objcompany.SLDServer = "192.168.5.226:40000";
            objcompany.DbUserName = "KPLSAP";
            objcompany.DbPassword = "Soporte01$";
            objcompany.CompanyDB = "KOPLAST_INDUSTRIAL";
            objcompany.UserName = "manager";
            objcompany.Password = "koplast19";



            //  oCompany = (Company)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("632F4591-AA62-4219-8FB6-22BCF5F60100")));
            //objcompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

            int error = objcompany.Connect();
        }
    }
}
