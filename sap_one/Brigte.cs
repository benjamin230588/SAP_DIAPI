using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sap_one
{
    public class Brigte
    {
        public static DataTable cargar(SAPbobsCOM.Company objcompany)
        {
            DataTable CotizacionDet = new DataTable();
            CotizacionDet.Columns.Add("Codigo", Type.GetType("System.String"));
            CotizacionDet.Columns.Add("Nombre", Type.GetType("System.String"));
            CotizacionDet.Columns.Add("Correo", Type.GetType("System.String"));

            SAPbobsCOM.Recordset objreset = (SAPbobsCOM.Recordset)objcompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string sql = "select cardcode,cardname,e_mail from ocrd";
            objreset.DoQuery(sql);
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

            return CotizacionDet;
        }

    }
}
