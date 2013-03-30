using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class RegControl : UserControl
    {
private  int descriptiveCount;
        public RegControl()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
        }

        private void run_regression(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();
            var key = System.DateTime.Now.Ticks.ToString();
            string output = AppDomain.CurrentDomain.BaseDirectory + "reg_step_1-" + key + ".sav";
            string syntax = @"
GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT * FROM [StatsInfoSystem.StsContext].[dbo].[RegStep]"".
SAVE OUTFILE='{1}'.
";
            syntax = String.Format(syntax, Config.SPSS_CONNECT, output);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;
            syntax = @"
GET
    FILE='{0}'.

REGRESSION
  /DESCRIPTIVES MEAN STDDEV CORR SIG N
  /MISSING LISTWISE
  /STATISTICS COEFF OUTS R ANOVA COLLIN TOL ZPP
  /CRITERIA=PIN(.05) POUT(.10) CIN(95)
  /NOORIGIN
  /DEPENDENT SaleAmount
  /METHOD=STEPWISE CurExcRate ConPriceIndex ConPriceIndexMat ProductIndex ProductionRate
  /SCATTERPLOT=(*ZRESID ,*ZPRED)
  /RESIDUALS DURBIN NORMPROB(ZRESID)
  /SAVE PRED MCIN RESID.

SAVE OUTFILE='{1}'.

";
            string output2 = AppDomain.CurrentDomain.BaseDirectory + "reg_step_2-" + key + ".sav";
            syntax = String.Format(syntax, output, output2);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            syntax = @"
GET
    FILE='{0}'.
EXAMINE VARIABLES=RES_1
  /PLOT BOXPLOT STEMLEAF NPPLOT
  /COMPARE GROUPS
  /STATISTICS DESCRIPTIVES
  /CINTERVAL 95
  /MISSING LISTWISE
  /NOTOTAL.

GRAPH
  /LINE(MULTIPLE)=MEAN(SaleAmount) MEAN(PRE_1) BY month
  /MISSING=LISTWISE.

";
            syntax = string.Format(syntax, output2);
            spss.ExecuteCommands(syntax, true);
            var outputItems = spss.GetDesignatedOutputDoc().Items;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Line of mean(SaleAmount, PRE_1) by month"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    var img = "Line_of_mean(SaleAmount_PRE_1)_by_month.jpg";
                    chart.ExportChart(img, "JPEG File");
                    pictureBox1.ImageLocation = img;
                }
                else if (item.Label.Equals("*zresid by *zpred Scatterplot"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    var img = "zresid_by_zpred_Scatterplot.jpg";
                    chart.ExportChart(img, "JPEG File");
                    pictureBox2.ImageLocation = img;
                }
            }
            if (Config.SPSS_OUTPUT) MessageBox.Show("Press OK to Close SPSS");
            spss.Quit();
            tabControl1.Visible = true;
        }

          private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegControl_Load(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
