
using BlazorRDLCReport.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Data;

namespace BlazorRDLCReport.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WyndhamController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly WyndhamService _wyndhamService = new WyndhamService();
        public WyndhamController(IWebHostEnvironment _webHostEnvironment)
        {
            this._webHostEnvironment = _webHostEnvironment;
        }
        [HttpGet("[action]")]
        public IActionResult GetCharges()
        {
            using var report = new LocalReport();
            var data = new DataTable();
            data = _wyndhamService.Charges();
            report.DataSources.Add(new ReportDataSource("dbMain", data));
            var parameter = new[]
            {
                new ReportParameter("params","Hello")
            };
            report.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\Reports\\ReportMain.rdlc";
            report.SetParameters(parameter);

            report.SubreportProcessing += new SubreportProcessingEventHandler(SubReportProcessing);
            var pdf = report.Render("PDF");
            return File(pdf, "application/pdf", "report." + "pdf");
        }
        void SubReportProcessing(object sender,SubreportProcessingEventArgs args)
        {
            string code= args.Parameters["Code"].Values[0].ToString();
            string[] c = { "1-Accessories", "1860-State Sales Tax", "Package Amount" };
            var detailsData = new DataTable();
            detailsData = _wyndhamService.Charges();
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
            foreach (var i in c)
            {
                var newdetails1 = detailsData.Select($"Code = '{i}'").CopyToDataTable();
                foreach (DataRow row in newdetails1.Rows)
                {
                    DataRow newRow = dt.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    dt.Rows.Add(newRow);
                }
            }
            //var newdetails = detailsData.Select($"Code = '{code}'").CopyToDataTable();
            ReportDataSource ds = new ReportDataSource("dbMain", dt);
            args.DataSources.Add(ds);
        }
    }
}
