﻿
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
            
            var dt = new DataTable();
            dt.Columns.Add(columnName: "Transcode");
            dt.Columns.Add(columnName: "SumTotal");
            string[] c = { "1-Accessories", "1860-State Sales Tax", "Package Amount" };
            string[] subTotal = { "$344.00", "$26.66", "$504.00" };
            int p = 0;
            foreach(var i in c)
            {
                DataRow dr = dt.NewRow();
                dr["Transcode"] = i;
                dr["SumTotal"] = subTotal[p];
                dt.Rows.Add(dr);
                p = p + 1;
            }
            report.DataSources.Add(new ReportDataSource("dbAnother", dt));
            report.SubreportProcessing += new SubreportProcessingEventHandler(SubReportHeader);
            report.SubreportProcessing += new SubreportProcessingEventHandler(SubReportProcessing);

            var pdf = report.Render("PDF");
            return File(pdf, "application/pdf", "report." + "pdf");
        }
        void SubReportBody(object sender, SubreportProcessingEventArgs e)
        {
            string[] c = { "1-Accessories", "1860-State Sales Tax", "Package Amount" };
            string[] subTotal = { "$344.00", "$26.66", "$504.00" };
            var dt = new DataTable();
            dt.Columns.Add(columnName:"Transcode");
            dt.Columns.Add(columnName: "SubTotal");
            int p = 0;
            foreach (var i in c)
            {
                using var report = new LocalReport();
                DataRow dr = dt.NewRow();
                dr["Transcode"] = i;
                dr["SubTotal"] = subTotal[p];
                dt.Rows.Add(dr);
                DataTable dd = new DataTable();
                dd = dt;
                p = p + 1;
                ReportDataSource ds = new ReportDataSource("dbSubReportBody", dd);
                e.DataSources.Add(ds);
                report.SubreportProcessing += new SubreportProcessingEventHandler(demosubsubreport);

            }

        }
        void demosubsubreport(object sender, SubreportProcessingEventArgs args)
        {
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
            string code = args.Parameters["Code"].Values[0].ToString();
            var newdetails1 = detailsData.Select($"Code = '{code}'").CopyToDataTable();
            foreach (DataRow row in newdetails1.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow.ItemArray = row.ItemArray;
                dt.Rows.Add(newRow);
            }
            ReportDataSource ds = new ReportDataSource("dbMain", dt);
            args.DataSources.Add(ds);
        }
        void SubReportHeader(object sender, SubreportProcessingEventArgs args)
        {
            var dt = new DataTable();
            dt = _wyndhamService.SelectionCriteria();
            ReportDataSource ds = new ReportDataSource("dbSelection",dt);
            args.DataSources.Add(ds);

        }
        void SubReportProcessing(object sender,SubreportProcessingEventArgs args)
        {
            try
            {
                string code = args.Parameters["Code"].Values[0].ToString();
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
                var newdetails1 = detailsData.Select($"Code = '{code}'").CopyToDataTable();
                foreach (DataRow row in newdetails1.Rows)
                {
                    DataRow newRow = dt.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    dt.Rows.Add(newRow);
                }
                //var newdetails = detailsData.Select($"Code = '{code}'").CopyToDataTable();
                ReportDataSource ds = new ReportDataSource("dbMain", dt);
                args.DataSources.Add(ds);
            }catch(Exception e)
            {

            }

        }
    }
}
