using System.Data;

namespace BlazorRDLCReport.Server.Data
{
    public class NextService
    {
        public DataTable Headerfunc()
        {
            var dt = new DataTable();
            dt.Columns.Add("ArrivalBeginDate");
            dt.Columns.Add("ArrivalEndDate");
            dt.Columns.Add("Guesttype");
            dt.Columns.Add("AssociationRangeFrom");
            dt.Columns.Add("AssociationRangeTo");
            dt.Columns.Add("GroupName");
            dt.Columns.Add("VipsOnly");
            dt.Columns.Add("LockoffsOnly");
            dt.Columns.Add("IncludeCancels");
            dt.Columns.Add("Priority1Only");
            dt.Columns.Add("ResHasPreCheckinupdates");
            dt.Columns.Add("Excludeinhouse");
            dt.Columns.Add("Club");
            dt.Columns.Add("Sortcriteria");
            dt.Columns.Add("Building");
            dt.Columns.Add("Notourflag");
            dt.Columns.Add("RunBy");
            DataRow dr = dt.NewRow();
            dr["ArrivalBeginDate"]= DateTime.Today.ToString("d");
            dr["ArrivalEndDate"]= DateTime.Today.ToString("d");
            dr["Guesttype"] = "All";
            dr["AssociationRangeFrom"] = "";
            dr["AssociationRangeTo"] = "";
            dr["GroupName"] = "All";
            dr["VipsOnly"] = "No";
            dr["LockoffsOnly"] = "No";
            dr["IncludeCancels"] = "No";
            dr["Priority1Only"] = "No";
            dr["ResHasPreCheckinupdates"] = "No";
            dr["Excludeinhouse"] = "No";
            dr["Club"] = "";
            dr["Sortcriteria"] = "Guest Name";
            dr["Building"] = "";
            dr["Notourflag"] = "All";
            dr["RunBy"] = "C45271";
            dt.Rows.Add();
            return (dt);

        }
        public DataTable BodyPart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GuestName");
            dt.Columns.Add("Reservation");
            dt.Columns.Add("GuestType");
            dt.Columns.Add("Acct");
            dt.Columns.Add("StartDate");
            dt.Columns.Add("EndDate");
            dt.Columns.Add("ArrivalTime");
            dt.Columns.Add("Status");
            dt.Columns.Add("Room");
            dt.Columns.Add("unitType");
            dt.Columns.Add("SpecialNeeds");
            dt.Columns.Add("DepReq");
            dt.Columns.Add("DepPaid");
            dt.Columns.Add("HomePhone");
            dt.Columns.Add("CellPhone");
            dt.Columns.Add("VIP");
            dt.Columns.Add("Priority");

            DataRow dr = dt.NewRow();
            dr["GuestName"] = "Aherm,Gregory Stephen";
            dr["Reservation"] = "RC0026123970BR";
            dr["GuestType"] = "Owner/ClubWyndham Access";
            dr["Acct"] = "00203244839";
            dr["StartDate"]= DateTime.Today.ToString("d");
            dr["EndDate"] = "";
            dr["ArrivalTime"]= DateTime.Now.TimeOfDay.ToString();
            dr["Status"] = "Reserved";
            dr["Room"] = "";
            dr["unitType"] = "1 Bedroom Deluxe";
            dr["SpecialNeeds"] = "";
            dr["DepReq"] = "$0.00";
            dr["DepPaid"] = "$0.00";
            dr["HomePhone"] = "1-210-5602191";
            dr["CellPhone"] = "";
            dr["VIP"] = "G";
            dr["Priority"] = "Y";
            dt.Rows.Add(dr);


            DataRow dr1 = dt.NewRow();
            dr1["GuestName"] = "Elkin, Cager";
            dr1["Reservation"] = "RC0026869138BR";
            dr1["GuestType"] = "Owner/ClubWyndham Access";
            dr1["Acct"] = "00010036810";
            dr1["StartDate"] = DateTime.Today.ToString("d");
            dr1["EndDate"] = DateTime.Today.ToString("d");
            dr1["ArrivalTime"] = DateTime.Now.TimeOfDay.ToString();
            dr1["Status"] = "In-House";
            dr1["Room"] = "295";
            dr1["unitType"] = "1 Bedroom Deluxe";
            dr1["SpecialNeeds"] = "";
            dr1["DepReq"] = "$0.00";
            dr1["DepPaid"] = "$0.00";
            dr1["HomePhone"] = "1-386-624866";
            dr1["CellPhone"] = "13868030483";
            dr1["VIP"] = "";
            dr1["Priority"] = "";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["GuestName"] = "Aherm,Gregory Stephen";
            dr2["Reservation"] = "RC0026123970BR";
            dr2["GuestType"] = "Owner/ClubWyndham Access";
            dr2["Acct"] = "00203244839";
            dr2["StartDate"] = DateTime.Today.ToString("d");
            dr2["EndDate"] = DateTime.Today.ToString("d");
            dr2["ArrivalTime"] = DateTime.Now.TimeOfDay.ToString();
            dr2["Status"] = "Reserved";
            dr2["Room"] = "";
            dr2["unitType"] = "1 Bedroom Deluxe";
            dr2["SpecialNeeds"] = "";
            dr2["DepReq"] = "$0.00";
            dr2["DepPaid"] = "$0.00";
            dr2["HomePhone"] = "1-210-5602191";
            dr2["CellPhone"] = "";
            dr2["VIP"] = "G";
            dr2["Priority"] = "Y";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["GuestName"] = "Nappa, Kimberly";
            dr3["Reservation"] = "5304942601";
            dr3["GuestType"] = "Rental/Extra Holidays";
            dr3["Acct"] = "3105042001";
            dr3["StartDate"] = DateTime.Today.ToString("d");
            dr3["EndDate"] = DateTime.Today.ToString("d");
            dr3["ArrivalTime"] = DateTime.Now.TimeOfDay.ToString();
            dr3["Status"] = "In-House";
            dr3["Room"] = "885";
            dr3["unitType"] = "1 Bedroom Deluxe";
            dr3["SpecialNeeds"] = "";
            dr3["DepReq"] = "$204.00";
            dr3["DepPaid"] = "$0.00";
            dr3["HomePhone"] = "1-5189294537";
            dr3["CellPhone"] = "";
            dr3["VIP"] = "";
            dr3["Priority"] = "";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["GuestName"] = "Pudlo, Susan Lee";
            dr4["Reservation"] = "RC00025306350BR";
            dr4["GuestType"] = "Owner/ClubWyndham Access";
            dr4["Acct"] = "00201070287";
            dr4["StartDate"] = DateTime.Today.ToString("d");
            dr4["EndDate"] = DateTime.Today.ToString("d");
            dr4["ArrivalTime"] = "";
            dr4["Status"] = "Reserved";
            dr4["Room"] = "";
            dr4["unitType"] = "4 Bedroom Presedential";
            dr4["SpecialNeeds"] = "";
            dr4["DepReq"] = "$0.00";
            dr4["DepPaid"] = "($90.00)";
            dr4["HomePhone"] = "--";
            dr4["CellPhone"] = "1248310580";
            dr4["VIP"] = "V";
            dr4["Priority"] = "";
            dt.Rows.Add(dr4);
            return (dt);

        }
        public DataTable Footerfunc()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Reserved");
            dt.Columns.Add("Cancelled");
            dt.Columns.Add("Inhouse");
            dt.Columns.Add("Checkedout");
            dt.Columns.Add("NoShow");

            DataRow dr = dt.NewRow();
            dr["Reserved"] = "3";
            dr["Cancelled"] = "0";
            dr["Inhouse"] = "2";
            dr["Checkedout"] = "0";
            dr["NoShow"] = "0";
            dt.Rows.Add(dr);

            return (dt);
        }
    }
}
