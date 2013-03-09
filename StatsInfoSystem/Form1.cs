using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpssBridge;

namespace StatsInfoSystem
{
    public partial class Form1 : Form
    {
        private LoadingIndicator loadingIndicator = new LoadingIndicator() { Dock = DockStyle.Top };
        private CustomerMngControl customerMngControl;
        private ProductMngControl productMngControl;
        private SaleMngControl saleMngControl;
        private SaleForcastControl saleForcastControl;
        private ConfigControl dbConfigControl;
        private PcaControl pcaControl;
        public Form1()
        {
            InitializeComponent();
        }

        private void customerMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (customerMngControl == null) customerMngControl = new CustomerMngControl();
            DisplayControl(customerMngControl);
        }

        private void DisplayControl(Control c)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            mainPanel.Refresh();
        }

        private void productMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (productMngControl == null) productMngControl = new ProductMngControl();
            DisplayControl(productMngControl);
        }

        private void saleMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (saleMngControl == null) saleMngControl = new SaleMngControl();
            DisplayControl(saleMngControl);
        }

        private void spssText_MenuItem_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

            string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= 'DSN=sql_server;UID=LAMBKIN;APP=SPSS For Windows;WSID=LAMBKIN;DATABASE=StatsInfoSystem.StsContext;' 'Trusted_Connection=Yes'
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""amount"" .

DATE Y 2008 M.

GRAPH
  /LINE(SIMPLE)=MEAN(amount) BY month.

            ";

            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = false;

            var outputItems = spss.GetDesignatedOutputDoc().Items;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Line of mean(amount) by month"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    chart.ExportChart("time_series.jpg", "JPEG File");
                }
            }
            spss.Quit();

            MessageBox.Show("done!");
            
        }

        private void timeSeriesSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

            string syntax = @"
GET DATA 
/TYPE=ODBC 
/CONNECT= 'DSN=sql_server;UID=LAMBKIN;APP=SPSS For Windows;WSID=LAMBKIN;DATABASE=StatsInfoSystem.StsContext;' 'Trusted_Connection=Yes'
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""amount"" .

DATE Y 2008 M.

TSMODEL
   /MODELSUMMARY  PRINT=[MODELFIT]
   /MODELSTATISTICS  DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
   /MODELDETAILS  PRINT=[ PARAMETERS FORECASTS]  PLOT=[ RESIDACF RESIDPACF]
   /SERIESPLOT OBSERVED FORECAST FIT
   /OUTPUTFILTER DISPLAY=ALLMODELS
   /SAVE  PREDICTED(Predicted) NRESIDUAL(NResidual)
   /AUXILIARY  CILEVEL=95 MAXACFLAGS=24
   /MISSING USERMISSING=EXCLUDE
   /MODEL DEPENDENT=amount
      PREFIX='Model'
   /EXSMOOTH TYPE=SIMPLE  TRANSFORM=NONE.
";
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = true;
        }

        private void testSaveSavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();
            string output = AppDomain.CurrentDomain.BaseDirectory + "sample-"+System.DateTime.Now.Ticks.ToString()+".sav";
            string syntax = @"
GET DATA 
/TYPE=ODBC 
/CONNECT= 'DSN=sql_server;UID=LAMBKIN;APP=SPSS For Windows;WSID=LAMBKIN;DATABASE=StatsInfoSystem.StsContext;' 'Trusted_Connection=Yes'
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""amount"" .

DATE Y 2008 M.
";
            syntax += "SAVE OUTFILE='" + output + "'.";
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = false;

            string syntax2 = @"
GET
  FILE='"+output+"'."+ 
@"
DATASET NAME DataSet1 WINDOW=FRONT.
PREDICT THRU YEAR 2013 MONTH 1.
* Time Series Modeler.
TSMODEL
   /MODELSUMMARY  PRINT=[MODELFIT]
   /MODELSTATISTICS  DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
   /MODELDETAILS  PRINT=[ PARAMETERS FORECASTS]  PLOT=[ RESIDACF RESIDPACF]
   /SERIESPLOT OBSERVED FORECAST FIT
   /OUTPUTFILTER DISPLAY=ALLMODELS
   /SAVE  PREDICTED(Predicted) NRESIDUAL(NResidual)
   /AUXILIARY  CILEVEL=95 MAXACFLAGS=24
   /MISSING USERMISSING=EXCLUDE
   /MODEL DEPENDENT=amount
      PREFIX='Model'
   /EXSMOOTH TYPE=SIMPLE  TRANSFORM=NONE.

";
            spss.ExecuteCommands(syntax2, true);
            spss.GetDesignatedOutputDoc().Visible = true;
            MessageBox.Show("press ok to close SPSS");
            spss.Quit();
            
        }

        private void predictSaleMenu_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (saleForcastControl == null) saleForcastControl = new SaleForcastControl();
            DisplayControl(saleForcastControl);
        }

        private void dbConfigMenu_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (dbConfigControl == null) dbConfigControl = new ConfigControl();
            DisplayControl(dbConfigControl);
        }

        private void customerImportantMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (pcaControl == null) pcaControl = new PcaControl();
            DisplayControl(pcaControl);
        }
    }
}
