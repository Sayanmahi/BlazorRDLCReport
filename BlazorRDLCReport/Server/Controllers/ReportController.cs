﻿using AspNetCore.Reporting;
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
        private readonly EmployeeService _employeeService;
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
            parameter.Add("param", "RDLC Report in Blazor web Assembly");
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
                return (File(result.MainStream, contentType: "application/xls"));
            }
        }
    }
}