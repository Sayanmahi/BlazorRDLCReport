using AspNetCore.Reporting;
using BlazorRDLCReport.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace BlazorRDLCReport.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmployeeService _employeeService=new EmployeeService();
        private readonly WyndhamService _wyndhamService=new WyndhamService();
        public ReportController(IWebHostEnvironment _webHostEnvironment)
        {
            this._webHostEnvironment = _webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        [HttpGet("[action]")]
        public IActionResult GetReport(int reportType)
        {
            var dt = new DataTable();
            dt = _employeeService.GetEmployee();
            string mimeType = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";

            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("params", "RDLC Report in Blazor web Assembly");
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource(dataSetName: "dsEmployee", dt);

            //PDF Generation
            if(reportType==1)
            {
                var result = localReport.Execute(RenderType.Pdf, extension, parameter, mimeType);
                return (File(result.MainStream, contentType: "application/pdf"));
            }
            else
            {
                var result = localReport.Execute(RenderType.Excel,extension,parameter,mimeType);
                return (File(result.MainStream, contentType: "application/xls",fileDownloadName:"MyFile.xls"));
            }
        }
        [HttpGet("[action]")]
        public IActionResult GetCharges()
        {
            var dt = new DataTable();
            dt = _wyndhamService.Charges();
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\ReportMain.rdlc";
            LocalReport report = new LocalReport(path);
            report.AddDataSource(dataSetName: "dbMain", dt);

            
            return Ok(dt);
        }
        void SubReportProcessing()
        {

        }
        [HttpGet("[action]")]
        public IActionResult GetPayment()
        {
            var dt = new DataTable();
            dt = _wyndhamService.Payment();
            return Ok(dt);
        }
    }
}
