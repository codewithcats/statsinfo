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
    public partial class DescriptiveControl : UserControl
    {
        public DescriptiveControl()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
        }

        private void displayInfo_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void process_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

            var syntax = @"
GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT co.*, c.Area_Id, c.Group_Id FROM [StatsInfoSystem.StsContext].[dbo].[CustomerOrder] co join [StatsInfoSystem.StsContext].[dbo].[Customers] c on co.id = c.id"".

FREQUENCIES VARIABLES=Group_Id Area_Id
  /ORDER=ANALYSIS.

GRAPH
  /BAR(SIMPLE)=COUNT BY Group_Id.

GRAPH
  /BAR(SIMPLE)=COUNT BY Area_Id.


* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Group_Id buy DISPLAY=LABEL
  /TABLE Group_Id BY buy [MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Group_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Area_Id buy DISPLAY=LABEL
  /TABLE Area_Id BY buy [S][MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Area_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Group_Id unit DISPLAY=LABEL
  /TABLE Group_Id BY unit [MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Group_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Area_Id buy DISPLAY=LABEL
  /TABLE Area_Id BY buy [S][MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Area_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT * FROM [StatsInfoSystem.StsContext].[dbo].[ProductDescriptive]"".

FREQUENCIES VARIABLES=Group_Id Category_Id
  /ORDER=ANALYSIS.

GRAPH
  /BAR(SIMPLE)=COUNT BY Group_Id.

GRAPH
  /BAR(SIMPLE)=COUNT BY Category_Id.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Group_Id SubTotal DISPLAY=LABEL
  /TABLE Group_Id BY SubTotal [MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Group_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Category_Id SubTotal DISPLAY=LABEL
  /TABLE Category_Id BY SubTotal [S][MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Category_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Group_Id Unit DISPLAY=LABEL
  /TABLE Group_Id BY Unit [MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Group_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

* Custom Tables.
CTABLES
  /VLABELS VARIABLES=Category_Id Unit DISPLAY=LABEL
  /TABLE Category_Id BY Unit [S][MEAN, MEDIAN]
  /CATEGORIES VARIABLES=Category_Id ORDER=A KEY=VALUE EMPTY=EXCLUDE.

";
            syntax = string.Format(syntax, Config.SPSS_CONNECT);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;
 
            var outputItems = spss.GetDesignatedOutputDoc().Items;
            var groupBarCount = 0;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Bar of count by Group_Id"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    if (groupBarCount++ == 0)
                    {
                        string img = "bar_of_count_by_cgroupid-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox1.ImageLocation = img;
                    }
                    else
                    {
                        string img = "bar_of_count_by_pgroupid-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox3.ImageLocation = img;
                    }
                }
                else if (item.Label.Equals("Bar of count by Area_Id"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    string img = "bar_of_count_by_careaid-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(img, "JPEG File");
                    pictureBox2.ImageLocation = img;
                }
                else if (item.Label.Equals("Bar of count by Category_Id"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    string img = "bar_of_count_by_pcatid-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(img, "JPEG File");
                    pictureBox4.ImageLocation = img;
                }
            }

            if (Config.SPSS_OUTPUT) MessageBox.Show("Press OK to Close SPSS");
            spss.Quit();
            mainTab.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = radioButton2.Checked;
            dateTimePicker2.Visible = radioButton2.Checked;
            label1.Visible = radioButton2.Checked;
            label2.Visible = radioButton2.Checked;
        }
    }
}
