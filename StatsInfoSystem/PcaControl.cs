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
            var descriptiveCount = 0;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Descriptive Statistics"))
                {
                    if (descriptiveCount++ > 0) continue;
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label11.Text = dataCells.ValueAt[0, 0];
                    label18.Text = dataCells.ValueAt[0, 1];
                    label19.Text = dataCells.ValueAt[0, 2];
                    label20.Text = dataCells.ValueAt[0, 3];
                    label21.Text = string.Format("{0:N2}", Convert.ToDecimal(dataCells.ValueAt[0, 4]));

                    label24.Text = dataCells.ValueAt[1, 0];
                    label31.Text = dataCells.ValueAt[1, 1];
                    label38.Text = dataCells.ValueAt[1, 2];
                    label45.Text = dataCells.ValueAt[1, 3];
                    label52.Text = dataCells.ValueAt[1, 4];

                    label25.Text = dataCells.ValueAt[2, 0];
                    label32.Text = dataCells.ValueAt[2, 1];
                    label39.Text = dataCells.ValueAt[2, 2];
                    label46.Text = dataCells.ValueAt[2, 3];
                    label21.Text = dataCells.ValueAt[2, 4];

                    label26.Text = dataCells.ValueAt[3, 0];
                    label33.Text = dataCells.ValueAt[3, 1];
                    label40.Text = dataCells.ValueAt[3, 2];
                    label47.Text = dataCells.ValueAt[3, 3];
                    label54.Text = dataCells.ValueAt[3, 4];

                    label27.Text = dataCells.ValueAt[4, 0];
                    label34.Text = dataCells.ValueAt[4, 1];
                    label41.Text = dataCells.ValueAt[4, 2];
                    label48.Text = dataCells.ValueAt[4, 3];
                    label55.Text = dataCells.ValueAt[4, 4];

                    label28.Text = dataCells.ValueAt[5, 0];
                    label35.Text = dataCells.ValueAt[5, 1];
                    label42.Text = dataCells.ValueAt[5, 2];
                    label49.Text = dataCells.ValueAt[5, 3];
                    label56.Text = dataCells.ValueAt[5, 4];

                    label29.Text = dataCells.ValueAt[6, 0];
                    label36.Text = dataCells.ValueAt[6, 1];
                    label43.Text = dataCells.ValueAt[6, 2];
                    label50.Text = dataCells.ValueAt[6, 3];
                    label57.Text = dataCells.ValueAt[6, 4];

                    label6.Text = dataCells.ValueAt[7, 0];
                }
                else if (item.Label.Equals("Correlation Matrix"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label112.Text = dataCells.ValueAt[0, 0];
                    label92.Text = dataCells.ValueAt[0, 1];
                    label61.Text = dataCells.ValueAt[0, 2];
                    label69.Text = dataCells.ValueAt[0, 3];
                    label79.Text = dataCells.ValueAt[0, 4];
                    label170.Text = dataCells.ValueAt[0, 5];
                    label172.Text = dataCells.ValueAt[0, 6];

                    label111.Text = dataCells.ValueAt[1, 0];
                    label91.Text = dataCells.ValueAt[1, 1];
                    label62.Text = dataCells.ValueAt[1, 2];
                    label70.Text = dataCells.ValueAt[1, 3];
                    label81.Text = dataCells.ValueAt[1, 4];
                    label174.Text = dataCells.ValueAt[1, 5];
                    label176.Text = dataCells.ValueAt[1, 6];

                    label110.Text = dataCells.ValueAt[2, 0];
                    label90.Text = dataCells.ValueAt[2, 1];
                    label63.Text = dataCells.ValueAt[2, 2];
                    label71.Text = dataCells.ValueAt[2, 3];
                    label82.Text = dataCells.ValueAt[2, 4];
                    label178.Text = dataCells.ValueAt[2, 5];
                    label183.Text = dataCells.ValueAt[2, 6];

                    label109.Text = dataCells.ValueAt[3, 0];
                    label88.Text = dataCells.ValueAt[3, 1];
                    label64.Text = dataCells.ValueAt[3, 2];
                    label73.Text = dataCells.ValueAt[3, 3];
                    label83.Text = dataCells.ValueAt[3, 4];
                    label191.Text = dataCells.ValueAt[3, 5];
                    label192.Text = dataCells.ValueAt[3, 6];

                    label108.Text = dataCells.ValueAt[4, 0];
                    label84.Text = dataCells.ValueAt[4, 1];
                    label65.Text = dataCells.ValueAt[4, 2];
                    label74.Text = dataCells.ValueAt[4, 3];
                    label85.Text = dataCells.ValueAt[4, 4];
                    label193.Text = dataCells.ValueAt[4, 5];
                    label194.Text = dataCells.ValueAt[4, 6];

                    label107.Text = dataCells.ValueAt[5, 0];
                    label80.Text = dataCells.ValueAt[5, 1];
                    label66.Text = dataCells.ValueAt[5, 2];
                    label75.Text = dataCells.ValueAt[5, 3];
                    label86.Text = dataCells.ValueAt[5, 4];
                    label195.Text = dataCells.ValueAt[5, 5];
                    label196.Text = dataCells.ValueAt[5, 6];

                    label106.Text = dataCells.ValueAt[6, 0];
                    label76.Text = dataCells.ValueAt[6, 1];
                    label67.Text = dataCells.ValueAt[6, 2];
                    label77.Text = dataCells.ValueAt[6, 3];
                    label87.Text = dataCells.ValueAt[6, 4];
                    label197.Text = dataCells.ValueAt[6, 5];
                    label201.Text = dataCells.ValueAt[6, 6];

                }
                else if (item.Label.Equals("KMO and Bartlett's Test"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label115.Text = dataCells.ValueAt[0, 0];
                    label116.Text = dataCells.ValueAt[1, 0];
                    label117.Text = dataCells.ValueAt[2, 0];
                    label118.Text = dataCells.ValueAt[3, 0];
                }
                else if (item.Label.Equals("Total Variance Explained"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label120.Text = dataCells.ValueAt[0, 0];
                    label124.Text = dataCells.ValueAt[0, 1];
                    label151.Text = dataCells.ValueAt[0, 2];
                    label162.Text = dataCells.ValueAt[0, 3];
                    label163.Text = dataCells.ValueAt[0, 4];
                    label165.Text = dataCells.ValueAt[0, 5];

                    label121.Text = dataCells.ValueAt[1, 0];
                    label145.Text = dataCells.ValueAt[1, 1];
                    label152.Text = dataCells.ValueAt[1, 2];

                    label123.Text = dataCells.ValueAt[2, 0];
                    label147.Text = dataCells.ValueAt[2, 1];
                    label154.Text = dataCells.ValueAt[2, 2];

                    label142.Text = dataCells.ValueAt[3, 0];
                    label148.Text = dataCells.ValueAt[3, 1];
                    label155.Text = dataCells.ValueAt[3, 2];

                    label122.Text = dataCells.ValueAt[4, 0];
                    label146.Text = dataCells.ValueAt[4, 1];
                    label153.Text = dataCells.ValueAt[4, 2];

                    label143.Text = dataCells.ValueAt[5, 0];
                    label149.Text = dataCells.ValueAt[5, 1];
                    label156.Text = dataCells.ValueAt[5, 2];

                    label144.Text = dataCells.ValueAt[6, 0];
                    label150.Text = dataCells.ValueAt[6, 1];
                    label157.Text = dataCells.ValueAt[6, 2];
                }
                else if (item.Label.Equals("Component Matrix"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label180.Text = dataCells.ValueAt[0, 0];
                    label179.Text = dataCells.ValueAt[1, 0];
                    label177.Text = dataCells.ValueAt[2, 0];
                    label175.Text = dataCells.ValueAt[3, 0];
                    label173.Text = dataCells.ValueAt[4, 0];
                    label171.Text = dataCells.ValueAt[5, 0];
                    label169.Text = dataCells.ValueAt[6, 0];
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
            if (Config.SPSS_OUTPUT) MessageBox.Show("Press OK to Close SPSS");
            spss.Quit();
            reportPCATableAdapter.Fill(reportPCA_DataSet1.ReportPCA);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var report = new ReportPCA();
            report.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }
    }
}
