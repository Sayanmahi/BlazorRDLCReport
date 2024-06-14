
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
            string c = "1-Accessories";
            var detailsData = new DataTable();
            detailsData = _wyndhamService.Charges();
            var newdetails = detailsData.Select($"Code = '{code}'").CopyToDataTable();
            ReportDataSource ds = new ReportDataSource("dbMain", newdetails);
            args.DataSources.Add(ds);
        }
    }
}
