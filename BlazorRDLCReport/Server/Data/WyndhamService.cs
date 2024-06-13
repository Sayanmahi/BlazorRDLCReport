using System.Data;

namespace BlazorRDLCReport.Server.Data
{
    public class WyndhamService
    {
        public DataTable Charges()
        {
            var dt= new DataTable();
            dt.Columns.Add(columnName:"Code");
            dt.Columns.Add(columnName: "Date");
            dt.Columns.Add(columnName: "Time");
            dt.Columns.Add(columnName: "TransactionType");
            dt.Columns.Add(columnName: "RoomId");
            dt.Columns.Add(columnName: "ReservationId");
            dt.Columns.Add(columnName: "GuestName");
            dt.Columns.Add(columnName: "Name");
            dt.Columns.Add(columnName: "Folio");
            dt.Columns.Add(columnName: "Amount");
            DataRow dr=dt.NewRow();
            dr["Code"] = "1-Accessories";
            dr["Date"] = DateTime.Now.Date.ToString();
            dr["Time"]=DateTime.Now.TimeOfDay.ToString();
            dr["TransactionType"] = "Gift Shop";
            dr["RoomId"] = 310;
            dr["ReservationId"] = 0000000524931;
            dr["GuestName"] = "FVS,FVS";
            dr["Name"] = "1-Accessories SubTotal:";
            dr["Folio"] = 1;
            dr["Amount"] = "$344";
            dt.Rows.Add(dr);

            dr["Code"] = "1860-State Sales Tax";
            dr["Date"] = DateTime.Now.Date.ToString();
            dr["Time"] = DateTime.Now.TimeOfDay.ToString();
            dr["TransactionType"] = "Taxes";
            dr["RoomId"] = 310;
            dr["ReservationId"] = 0000000524931;
            dr["GuestName"] = "FVS,FVS";
            dr["Name"] = "1860-State Sales Tax Subtotal:";
            dr["Folio"] = 1;
            dr["Amount"] = "$26.66";
            dt.Rows.Add(dr);

            return (dt);

        }
        public DataTable Payment()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columnName: "Code");
            dt.Columns.Add(columnName: "Date");
            dt.Columns.Add(columnName: "Time");
            dt.Columns.Add(columnName: "TransactionType");
            dt.Columns.Add(columnName: "RoomId");
            dt.Columns.Add(columnName: "ReservationId");
            dt.Columns.Add(columnName: "GuestName");
            dt.Columns.Add(columnName: "Name");
            dt.Columns.Add(columnName: "Folio");
            dt.Columns.Add(columnName: "Amount");
            DataRow dr = dt.NewRow();
            dr["Code"] = "1-Accessories";
            dr["Date"] = DateTime.Now.Date.ToString();
            dr["Time"] = DateTime.Now.TimeOfDay.ToString();
            dr["TransactionType"] = "Payment";
            dr["RoomId"] = 516;
            dr["ReservationId"] = 0000000524924;
            dr["GuestName"] = "Test,Test";
            dr["Folio"] = 1;
            dr["Amount"] = "$104";
            dt.Rows.Add(dr);
            return (dt);
        }
    }
}
