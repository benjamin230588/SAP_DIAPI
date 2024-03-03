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
    public partial class FormTIPOCAMBIO : Form
    {
        private SAPbobsCOM.Company objcompany;
        public FormTIPOCAMBIO(SAPbobsCOM.Company obj)
        {
            objcompany = obj;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			string _res = string.Empty;
            SAPbobsCOM.SBObob oRate = (SAPbobsCOM.SBObob)(dynamic)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
			string tipo = textBox1.Text;
			double convertido = Convert.ToDouble(tipo);
			try
			{
				oRate.SetCurrencyRate("USD", DateTime.Now,convertido , Update: true);
				MessageBox.Show("grabado con exito");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
	   }
		
    }
}
