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
    public partial class ClusterControl : UserControl
    {
        public ClusterControl()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();
            var key = System.DateTime.Now.Ticks.ToString();
            string output = AppDomain.CurrentDomain.BaseDirectory + "cluster_source-" + key + ".sav";
            string syntax = @"
GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT * FROM [StatsInfoSystem.StsContext].[dbo].[CustomerOrder]"".

";
            syntax = String.Format(syntax, Config.SPSS_CONNECT);
            syntax += "SAVE OUTFILE='" + output + "'.";
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            syntax = @"
GET
    FILE='{0}'.
DESCRIPTIVES VARIABLES=months buy buy_avg unit unit_avg orders orders_avg late
  /SAVE
  /STATISTICS=MEAN STDDEV MIN MAX. 
SAVE OUTFILE='{1}'.

";
            var output2 = AppDomain.CurrentDomain.BaseDirectory + "cluster_std-" + key + ".sav";
            syntax = String.Format(syntax, output, output2);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            syntax = @"
GET
    FILE='{0}'.
QUICK CLUSTER Zmonths Zbuy Zbuy_avg Zunit Zunit_avg Zorders Zorders_avg Zlate
  /MISSING=LISTWISE
  /CRITERIA=CLUSTER(4) MXITER(10) CONVERGE(1)
  /METHOD=KMEANS(UPDATE)
  /SAVE CLUSTER DISTANCE
  /PRINT ID(Id) INITIAL ANOVA CLUSTER DISTAN
 
SAVE OUTFILE='{1}'.

";
            var output3 = AppDomain.CurrentDomain.BaseDirectory + "cluster_final-" + key + ".sav";
            syntax = String.Format(syntax, output2, output3);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            syntax = @"
GET
    FILE='{0}'.
GRAPH
  /PIE=COUNT BY QCL_1.
";
            syntax = String.Format(syntax, output3);
            spss.ExecuteCommands(syntax, true);
            var outputItems = spss.GetDesignatedOutputDoc().Items;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Pie of count by QCL_1"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    var img = "pie_of_count_by_QCL_1.jpg";
                    chart.ExportChart(img, "JPEG File");
                    pictureBox1.ImageLocation = img;
                }
                if (item.Label.Equals("Descriptive Statistic"))
                {
                    var table = item.GetTableOleObject();
                    if (table == null) continue;
                    //var pivot = (spsspvt.PivotTable)table;
                    
                }
            }
            spsswin.ISpssDataDoc dataDoc = spss.OpenDataDoc(output3);
            var data = dataDoc.GetTextData("Id", "QCL_1", 1, dataDoc.GetNumberOfCases());
            using (var context = new StsContext())
            {
                List<Customer> customers = new List<Customer>();
                for (int j = 0; j < dataDoc.GetNumberOfCases(); j++)
                {
                    string id = data[0, j];
                    var customer = context.Customers.Find(Convert.ToInt32(id));
                    if (customer != null) customers.Add(customer);
                }
                customerList.DataSource = customers;
            }
            
            if (Config.SPSS_OUTPUT) MessageBox.Show("press ok to close SPSS");
            spss.Quit();
        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label110_Click(object sender, EventArgs e)
        {

        }

        private void label185_Click(object sender, EventArgs e)
        {

        }

        private void label168_Click(object sender, EventArgs e)
        {

        }
    }
}
