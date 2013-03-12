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

        private void button4_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();
            var key = System.DateTime.Now.Ticks.ToString();
            string output = AppDomain.CurrentDomain.BaseDirectory + "reg_1-" + key + ".sav";
            string syntax = @"
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
            string input = AppDomain.CurrentDomain.BaseDirectory + "Regstep.sav";
            syntax = String.Format(syntax, input, output);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            string syntax2 = @"
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
            syntax2 = string.Format(syntax2, input);
            spss.ExecuteCommands(syntax2, true);
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
            if (Config.SPSS_OUTPUT) MessageBox.Show("press ok to close SPSS");
            spss.Quit();
            tabControl1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox1.Clear();
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
    }
}
