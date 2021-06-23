using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sap_one
{
    class Conexion
    {
        private static string server = "LAPTOP-ICLC5GJE";
        private static string basededatos = "SBODemoCL";
        private static string user= "manager";
        private static string pasword = "manager";

        
       public static SAPbobsCOM.Company conectar()
        {
           SAPbobsCOM.Company objcompany  = new SAPbobsCOM.Company();
            objcompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            objcompany.Server = server;
            objcompany.CompanyDB = basededatos;
            objcompany.UserName = user;
            objcompany.Password = pasword;
            objcompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

            return objcompany;
        }
    }
}
