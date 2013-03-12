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
            var descriptiveCount = 0;
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
                    if (descriptiveCount++ > 0) continue;
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label11.Text = dataCells.ValueAt[0, 0];
                    label18.Text = dataCells.ValueAt[0, 1];
                    label19.Text = dataCells.ValueAt[0, 2];
                    label20.Text = dataCells.ValueAt[0, 3];
                    label21.Text = dataCells.ValueAt[0, 4];

                    label24.Text = dataCells.ValueAt[1, 0];
                    label31.Text = dataCells.ValueAt[1, 1];
                    label38.Text = dataCells.ValueAt[1, 2];
                    label45.Text = dataCells.ValueAt[1, 3];
                    label52.Text = dataCells.ValueAt[1, 4];

                    label25.Text = dataCells.ValueAt[2, 0];
                    label32.Text = dataCells.ValueAt[2, 1];
                    label39.Text = dataCells.ValueAt[2, 2];
                    label46.Text = dataCells.ValueAt[2, 3];
                    label53.Text = dataCells.ValueAt[2, 4];

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

                    label30.Text = dataCells.ValueAt[7, 0];
                    label37.Text = dataCells.ValueAt[7, 1];
                    label44.Text = dataCells.ValueAt[7, 2];
                    label51.Text = dataCells.ValueAt[7, 3];
                    label58.Text = dataCells.ValueAt[7, 4];

                    label63.Text = dataCells.ValueAt[8, 0];
                }
                else if (item.Label.Equals("Final Cluster Centers"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label86.Text = dataCells.ValueAt[0, 0];
                    label92.Text = dataCells.ValueAt[0, 1];
                    label82.Text = dataCells.ValueAt[0, 2];
                    label81.Text = dataCells.ValueAt[0, 3];
                    
                    label87.Text = dataCells.ValueAt[1, 0];
                    label91.Text = dataCells.ValueAt[1, 1];
                    label79.Text = dataCells.ValueAt[1, 2];
                    label70.Text = dataCells.ValueAt[1, 3];
                   
                    label89.Text = dataCells.ValueAt[2, 0];
                    label90.Text = dataCells.ValueAt[2, 1];
                    label69.Text = dataCells.ValueAt[2, 2];
                    label71.Text = dataCells.ValueAt[2, 3];
                    
                    label93.Text = dataCells.ValueAt[3, 0];
                    label88.Text = dataCells.ValueAt[3, 1];
                    label64.Text = dataCells.ValueAt[3, 2];
                    label73.Text = dataCells.ValueAt[3, 3];
                    
                    label105.Text = dataCells.ValueAt[4, 0];
                    label84.Text = dataCells.ValueAt[4, 1];
                    label65.Text = dataCells.ValueAt[4, 2];
                    label74.Text = dataCells.ValueAt[4, 3];
                   
                    label106.Text = dataCells.ValueAt[5, 0];
                    label80.Text = dataCells.ValueAt[5, 1];
                    label66.Text = dataCells.ValueAt[5, 2];
                    label75.Text = dataCells.ValueAt[5, 3];
                 
                    label107.Text = dataCells.ValueAt[6, 0];
                    label76.Text = dataCells.ValueAt[6, 1];
                    label67.Text = dataCells.ValueAt[6, 2];
                    label77.Text = dataCells.ValueAt[6, 3];
                 
                    label108.Text = dataCells.ValueAt[7, 0];
                    label72.Text = dataCells.ValueAt[7, 1];
                    label68.Text = dataCells.ValueAt[7, 2];
                    label78.Text = dataCells.ValueAt[7, 3];                  
                }
                else if (item.Label.Equals("Distances between Final Cluster Centers"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label42.Text = dataCells.ValueAt[0, 0];
                    label39.Text = dataCells.ValueAt[0, 1];
                    label36.Text = dataCells.ValueAt[0, 2];
                    
                    label38.Text = dataCells.ValueAt[1, 0];
                    label34.Text = dataCells.ValueAt[1, 1];
                    label32.Text = dataCells.ValueAt[1, 2];
                   
                    label35.Text = dataCells.ValueAt[2, 0];
                    label37.Text = dataCells.ValueAt[2, 1];
                    label28.Text = dataCells.ValueAt[2, 2];
                    
                    label31.Text = dataCells.ValueAt[3, 0];
                    label33.Text = dataCells.ValueAt[3, 1];
                    label26.Text = dataCells.ValueAt[3, 2];                   
                }
                else if (item.Label.Equals("ANOVA"))
                {
                    var table = (spsspvt.PivotTable)item.GetTableOleObject();
                    var dataCells = table.DataCellArray();
                    label177.Text = dataCells.ValueAt[0, 0];
                    label120.Text = dataCells.ValueAt[0, 1];
                    label162.Text = dataCells.ValueAt[0, 2];
                    label190.Text = dataCells.ValueAt[0, 3];
                    label160.Text = dataCells.ValueAt[0, 4];
                    label158.Text = dataCells.ValueAt[0, 5];
                    
                    label178.Text = dataCells.ValueAt[1, 0];
                    label124.Text = dataCells.ValueAt[1, 1];
                    label159.Text = dataCells.ValueAt[1, 2];
                    label191.Text = dataCells.ValueAt[1, 3];
                    label156.Text = dataCells.ValueAt[1, 4];
                    label151.Text = dataCells.ValueAt[1, 5];

                    label179.Text = dataCells.ValueAt[2, 0];
                    label130.Text = dataCells.ValueAt[2, 1];
                    label154.Text = dataCells.ValueAt[2, 2];
                    label192.Text = dataCells.ValueAt[2, 3];
                    label147.Text = dataCells.ValueAt[2, 4];
                    label140.Text = dataCells.ValueAt[2, 5];

                    label180.Text = dataCells.ValueAt[3, 0];
                    label148.Text = dataCells.ValueAt[3, 1];
                    label141.Text = dataCells.ValueAt[3, 2];
                    label193.Text = dataCells.ValueAt[3, 3];
                    label129.Text = dataCells.ValueAt[3, 4];
                    label125.Text = dataCells.ValueAt[3, 5];

                    label181.Text = dataCells.ValueAt[4, 0];
                    label157.Text = dataCells.ValueAt[4, 1];
                    label127.Text = dataCells.ValueAt[4, 2];
                    label194.Text = dataCells.ValueAt[4, 3];
                    label123.Text = dataCells.ValueAt[4, 4];
                    label121.Text = dataCells.ValueAt[4, 5];

                    label182.Text = dataCells.ValueAt[4, 0];
                    label161.Text = dataCells.ValueAt[4, 1];
                    label122.Text = dataCells.ValueAt[4, 2];
                    label195.Text = dataCells.ValueAt[5, 3];
                    label119.Text = dataCells.ValueAt[5, 4];
                    label117.Text = dataCells.ValueAt[5, 5];

                    label183.Text = dataCells.ValueAt[6, 0];
                    label163.Text = dataCells.ValueAt[6, 1];
                    label118.Text = dataCells.ValueAt[6, 2];
                    label196.Text = dataCells.ValueAt[6, 3];
                    label115.Text = dataCells.ValueAt[6, 4];
                    label112.Text = dataCells.ValueAt[6, 5];

                    label184.Text = dataCells.ValueAt[7, 0];
                    label164.Text = dataCells.ValueAt[7, 1];
                    label116.Text = dataCells.ValueAt[7, 2];
                    label197.Text = dataCells.ValueAt[7, 3];
                    label114.Text = dataCells.ValueAt[7, 4];
                    label111.Text = dataCells.ValueAt[7, 5];
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
