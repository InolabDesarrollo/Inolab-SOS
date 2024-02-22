using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TestSpire
{
    public partial class Reporte : MaterialForm
    {
        private string CONNECTION = "http://INOLABSERVER01/Reportes_Inolab";
        private string Report;

        public string Report1 { get => Report; set => Report = value; }

        public void Ver(ReportViewer reportViewer1, string reporte, bool show)
        {

            System.Net.NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            //MessageBox.Show("DatosReales");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri(CONNECTION);
            reportViewer1.ServerReport.ReportPath = "/Servicio/" + reporte;
            reportViewer1.ShowParameterPrompts = show;
            //ReportParameter parameter1 = new ReportParameter();
            //parameter1.Name = "ident";
            //parameter1.Values.Add(ident);

            //reportViewer1.ServerReport.SetParameters(new ReportParameter[] { parameter1 });

            reportViewer1.RefreshReport();
        }

        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
            Ver(reportViewer1, Report1, true);
            /* switch (Report1)
             {
                 case "Eqs":
                     Ver(reportViewer1, Report1, true);
                     break;

                 default:
                     Close();
                     break;
             }*/
        }
    }
}