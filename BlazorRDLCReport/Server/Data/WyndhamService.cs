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
            dr["Date"] = DateTime.Today.ToString("d");
            dr["Time"]= DateTime.Now.ToString("HH:mm:ss");
            dr["TransactionType"] = "Gift Shop";
            dr["RoomId"] = 310;
            dr["ReservationId"] = 0000000524931;
            dr["GuestName"] = "FVS,FVS";
            dr["Name"] = "1-Accessories SubTotal:";
            dr["Folio"] = 1;
            dr["Amount"] = "$344";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1["Code"] = "1860-State Sales Tax";
            dr1["Date"] = DateTime.Today.ToString("d");
            dr1["Time"] = DateTime.Now.ToString("HH:mm:ss");
            dr1["TransactionType"] = "Taxes";
            dr1["RoomId"] = 310;
            dr1["ReservationId"] = 0000000524931;
            dr1["GuestName"] = "FVS,FVS";
            dr1["Name"] = "1860-State Sales Tax Subtotal:";
            dr1["Folio"] = 1;
            dr1["Amount"] = "$26.66";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2["Code"] = "Package Amount";
            dr2["Date"] = DateTime.Today.ToString("d");
            dr2["Time"] = DateTime.Now.ToString("HH:mm:ss");
            dr2["TransactionType"] = "EH Package";
            dr2["RoomId"] = 516;
            dr2["ReservationId"] = 0000000524924;
            dr2["GuestName"] = "TEST,TEST";
            dr2["Name"] = "Package Amount Subtotal:";
            dr2["Folio"] = 1;
            dr2["Amount"] = "$104.00";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["Code"] = "Package Amount";
            dr3["Date"] = DateTime.Today.ToString("d");
            dr3["Time"] = DateTime.Now.ToString("HH:mm:ss");
            dr3["TransactionType"] = "EH Package";
            dr3["RoomId"] = 514;
            dr3["ReservationId"] = 0000000524927;
            dr3["GuestName"] = "TESTING,TESTING";
            dr3["Name"] = "Package Amount Subtotal:";
            dr3["Folio"] = 1;
            dr3["Amount"] = "$400.00";
            dt.Rows.Add(dr3);

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
        public DataTable SelectionCriteria()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(columnName: "StartPostDate");
            dt.Columns.Add(columnName: "EndPostDate");
            dt.Columns.Add(columnName: "Shift");
            dt.Columns.Add(columnName: "Operator");
            dt.Columns.Add(columnName: "IncludeDisabled");
            dt.Columns.Add(columnName: "LedgersToInclude");
            dt.Columns.Add(columnName: "TransactionType");
            dt.Columns.Add(columnName: "SortCriteria");
            dt.Columns.Add(columnName: "SourceSystem");

            DataRow dr = dt.NewRow();
            dr["StartPostDate"] = "3/5/2023";
            dr["EndPostDate"] = "3/5/203";
            dr["Shift"] = "All";
            dr["Operator"] = "All";
            dr["IncludeDisabled"] = "No";
            dr["LedgersToInclude"] = "All";
            dr["TransactionType"] = "All";
            dr["SortCriteria"] = "Transaction Type";
            dr["SourceSystem"] = "All";
            dt.Rows.Add(dr);
            return (dt);

        }

    }
}
