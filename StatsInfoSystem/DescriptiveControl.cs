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

";
            syntax = string.Format(syntax, Config.SPSS_CONNECT);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

             var outputItems = spss.GetDesignatedOutputDoc().Items;
             for (int i = 0; i < outputItems.Count; i++)
             {
                 var item = outputItems.GetItem(i);
                 if (item.Label.Equals("Bar of count by Group_Id"))
                 {
                     var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                     string img = "bar_of_count_by_groupid-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                     chart.ExportChart(img, "JPEG File");
                     pictureBox1.ImageLocation = img;
                 }
                 if (item.Label.Equals("Bar of count by Area_Id"))
                 {
                     var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                     string img = "bar_of_count_by_areaid-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                     chart.ExportChart(img, "JPEG File");
                     pictureBox2.ImageLocation = img;
                 }
             }

            if (Config.SPSS_OUTPUT) MessageBox.Show("press ok to close SPSS");
            spss.Quit();
        }
    }
}
