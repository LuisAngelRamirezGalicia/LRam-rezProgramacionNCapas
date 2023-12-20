using Microsoft.Reporting.WebForms;
using PL_MVC.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace PL_MVC.Controllers
{
    public class ReportController : Controller
    { DataSetEjemplo ds = new DataSetEjemplo();

        DataSetGrafico dsg = new DataSetGrafico();
        // GET: Report
        //DataSet1
        public ActionResult Show()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);
            var cadenaDeConexion = ConfigurationManager.ConnectionStrings["LRamirezProgramacionNCapas"].ToString();
            SqlConnection conx = new SqlConnection(cadenaDeConexion);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Empleado", conx);
            adp.Fill(ds, ds.Empleado.TableName);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportEjemplo.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetEjemplo", ds.Tables[0]));
            ViewBag.ReportViewer =  reportViewer;

            return View();
        }

        public ActionResult ShowGrafico()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(900);
            reportViewer.Height = Unit.Percentage(900);
            var cadenaDeConexion = ConfigurationManager.ConnectionStrings["LRamirezProgramacionNCapas"].ToString();
            SqlConnection conx = new SqlConnection(cadenaDeConexion);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Empleado", conx);
            adp.Fill(dsg, dsg.Empleado.TableName);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Report2.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetGrafico", dsg.Tables[0]));
            ViewBag.ReportViewer = reportViewer;

            return View();
        }
    }
}