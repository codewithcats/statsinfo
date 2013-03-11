using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class ReportPCA : Form
    {
        public ReportPCA()
        {
            InitializeComponent();
            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load("..\\..\\report\\ReportPCA.rpt");
            crystalReportViewer1.ReportSource = rptDoc;
            crystalReportViewer1.Refresh();
        }
    }
}
