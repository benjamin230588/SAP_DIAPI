using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIBENJA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        public static SAPbouiCOM.Application SBO_Application = null;
        public static SAPbobsCOM.Company oCompany = null;
        static void Main(string[] args)
        {
            ConexionUIAPI();
            //agregarmenus();
            // benjamin huama soto

            //Menus();
            //SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_sistema);

            //SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
            //SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_Application_MenuEvent);
            System.Windows.Forms.Application.Run();
        }

        public static void ConexionUIAPI()
        {
            try
            {
                SboGuiApi oSboGuiApi = new SboGuiApi();
                string sConnStr = Environment.GetCommandLineArgs().GetValue(1).ToString();
                oSboGuiApi.Connect(sConnStr);

                SBO_Application = oSboGuiApi.GetApplication(-1);
                oCompany = (SAPbobsCOM.Company)SBO_Application.Company.GetDICompany();
                SBO_Application.StatusBar.SetText("EXITO - Conexion UI API Exitosa", BoMessageTime.bmt_Medium, BoStatusBarMessageType.smt_Success);
                oSboGuiApi = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

    }
}
