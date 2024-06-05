using System.Data;

namespace BlazorRDLCReport.Server.Data
{
    public class EmployeeService
    {
        public DataTable GetEmployee()
        {
            var dt = new DataTable();
            dt.Columns.Add(columnName: "Empid");
            dt.Columns.Add(columnName: "EmpName");
            dt.Columns.Add(columnName: "Department");
            dt.Columns.Add(columnName: "Designation");
            dt.Columns.Add(columnName: "JoinDate");
            DataRow row1;
            for(int i=0;i<=50;i++)
            {
                row1 = dt.NewRow();
                row1["EmpId"] = i;
                row1["EmpName"] = "Robert " + i;
                row1["Department"] = "Information Technology";
                row1["Designation"] = "Software Engineer";
                row1["JoinDate"] = DateTime.Now.AddYears(-30).AddDays(i);
                dt.Rows.Add(row1);
            }
            return (dt);
        }
    }
}
