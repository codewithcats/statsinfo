using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace StatsInfoSystem
{
    public partial class PcaControl : UserControl
    {
        public PcaControl()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();
            var key = System.DateTime.Now.Ticks.ToString();
            string output = AppDomain.CurrentDomain.BaseDirectory + "pca_source-" + key + ".sav";
            string syntax = @"
GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT Id, months, buy, buy_avg, unit, unit_avg, orders, orders_avg FROM [StatsInfoSystem.StsContext].[dbo].[CustomerOrder]"".

";
            syntax = String.Format(syntax, Config.SPSS_CONNECT);
            syntax += "SAVE OUTFILE='" + output + "'.";
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            syntax = @"
GET
    FILE='{0}'.
DESCRIPTIVES VARIABLES=months buy buy_avg unit unit_avg orders orders_avg
  /SAVE
  /STATISTICS=MEAN STDDEV MIN MAX. 
SAVE OUTFILE='{1}'.

";
            var output2 = AppDomain.CurrentDomain.BaseDirectory + "pca_std-" + key + ".sav";
            syntax = String.Format(syntax, output, output2);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            syntax = @"
GET
    FILE='{0}'.
FACTOR 
  /VARIABLES Zmonths Zbuy Zbuy_avg Zunit Zunit_avg Zorders Zorders_avg 
  /MISSING LISTWISE 
  /ANALYSIS Zmonths Zbuy Zbuy_avg Zunit Zunit_avg Zorders Zorders_avg 
  /PRINT UNIVARIATE INITIAL CORRELATION KMO EXTRACTION ROTATION 
  /FORMAT SORT BLANK(0.2) 
  /PLOT EIGEN ROTATION 
  /CRITERIA MINEIGEN(1) ITERATE(25) 
  /EXTRACTION PC 
  /CRITERIA ITERATE(25) 
  /ROTATION VARIMAX 
  /SAVE REG(ALL) 
  /METHOD=CORRELATION. 
SAVE OUTFILE='{1}'.

";
            var output3 = AppDomain.CurrentDomain.BaseDirectory + "pca_final-" + key + ".sav";
            syntax = String.Format(syntax, output2, output3);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            var outputItems = spss.GetDesignatedOutputDoc().Items;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Descriptive Statistics"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                }
            }
            spsswin.ISpssDataDoc dataDoc = spss.OpenDataDoc(output3);
            var data = dataDoc.GetTextData("Id", "FAC1_1", 1, dataDoc.GetNumberOfCases());
            using (var context = new StsContext())
            {
                context.Database.ExecuteSqlCommand("delete from PcaFactorLoading");
                var sqlTmpl = "insert into PcaFactorLoading(customer_id, fac1_1) values({0}, {1})";
                for (int j = 0; j < dataDoc.GetNumberOfCases(); j++)
                {
                    var sql = String.Format(sqlTmpl, data[0, j], data[15, j]);
                    context.Database.ExecuteSqlCommand(sql);
                }
                context.SaveChanges();
            }
            if (Config.SPSS_OUTPUT) MessageBox.Show("press ok to close SPSS");
            spss.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load("..\\..\\report\\ReportPCA.rpt");
            //reportViewer1.ReportSource = rptDoc;
            //reportViewer1.Refresh();
            tabControl1.SelectedIndex = 1;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }

        private void label199_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
    }
}
