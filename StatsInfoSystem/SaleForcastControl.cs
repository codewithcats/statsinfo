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
    public partial class SaleForcastControl : UserControl
    {
        public SaleForcastControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

            string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""amount"" .

DATE Y 2008 M.

GRAPH
/LINE(SIMPLE)=MEAN(amount) BY month.

GRAPH
/LINE(MULTIPLE)=MEAN(amount) BY MONTH_ BY YEAR_.

ACF VARIABLES=amount
/NOLOG
/MXAUTO 16
/SERROR=IND
/PACF.

            ";
            syntax = String.Format(syntax, Config.SPSS_CONNECT);

            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            var outputItems = spss.GetDesignatedOutputDoc().Items;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("Line of mean(amount) by month"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    string lineOfMeanMonthImg = "line_of_mean_by_month-"+System.DateTime.Now.Ticks.ToString()+".jpg";
                    chart.ExportChart(lineOfMeanMonthImg, "JPEG File");
                    lineOfMeanMonthPic.ImageLocation = lineOfMeanMonthImg;
                }
                else if (item.Label.Equals("Line of mean(amount) by MONTH_ YEAR_"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    string lineOfMeanMonthYearImg = "line_of_mean_by_MONTH_YEAR-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(lineOfMeanMonthYearImg, "JPEG File");
                    lineOfMeanMonthYearPic.ImageLocation = lineOfMeanMonthYearImg;
                }
                else if (item.Label.Equals("ACF"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    if (chart == null) continue;
                    string acfImg = "ACF-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(acfImg, "JPEG File");
                    acfPic.ImageLocation = acfImg;
                }
                else if (item.Label.Equals("PACF"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    if (chart == null) continue;
                    string pacfImg = "PACF-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(pacfImg, "JPEG File");
                    pacfPic.ImageLocation = pacfImg;
                }
            }
            if(Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
            spss.Quit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (simpleRadio.Checked)
            {
                SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
                spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

                string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""SaleAmount"" .

DATE Y 2008 M.

PREDICT THRU YEAR 2013 MONTH 1.

* Time Series Modeler.

TSMODEL
/MODELSUMMARY PRINT=[MODELFIT]
/MODELSTATISTICS DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
/MODELDETAILS PRINT=[ PARAMETERS FORECASTS] PLOT=[ RESIDACF RESIDPACF]
/SERIESPLOT OBSERVED FORECAST FIT
/OUTPUTFILTER DISPLAY=ALLMODELS
/SAVE PREDICTED(Predicted) NRESIDUAL(NResidual)
/AUXILIARY CILEVEL=95 MAXACFLAGS=24
/MISSING USERMISSING=EXCLUDE
/MODEL DEPENDENT=amount
PREFIX='Model'
/EXSMOOTH TYPE=SIMPLE TRANSFORM=NONE.

            ";
                syntax = String.Format(syntax, Config.SPSS_CONNECT);
                spss.ExecuteCommands(syntax, true);
                spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

                var outputItems = spss.GetDesignatedOutputDoc().Items;
                for (int i = 0; i < outputItems.Count; i++)
                {
                    var item = outputItems.GetItem(i);
                    if (item.Label.Equals("Series Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "simple_series_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        simpleSeriesChartPic.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Residual ACF/PACF Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "simple_residual_acf_pacf_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        simpleResidualAcfPacfChartPic.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Forecast"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        simpleForecastLbl.Text = cells.ValueAt[0, 0];
                        simpleForecastUclLbl.Text = cells.ValueAt[1, 0];
                        simpleForecastLclLbl.Text = cells.ValueAt[2, 0];
                        //MessageBox.Show("rows: " + cells.NumRows + ", cols: " + cells.NumColumns);
                        //for (int j = 0; j < cells.NumRows; j++)
                        //{
                        //    MessageBox.Show(cells.ValueAt[j, 0].ToString());
                        //}
                        //var labels = table.RowLabelArray();
                        //for (int j = 0; j < labels.NumRows; j++)
                        //{
                        //    for (int k = 0; k < labels.NumColumns; k++)
                        //    {
                        //        MessageBox.Show(String.Format("[{0},{1}] => {2}", j, k, labels.ValueAt[j, k].ToString()));
                        //    }
                        //}
                    }
                    else if (item.Label.Equals("Model Statistics"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        rmseTxt.Text = cells.ValueAt[0, 3].ToString();
                        mapeTxt.Text = cells.ValueAt[0, 4].ToString();
                    }
                    else if (item.Label.Equals("Exponential Smoothing Model Parameters"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        alpahLvLbl.Text = cells.ValueAt[0, 0].ToString();
                    }
                }
                if (Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
                spss.Quit();
                textBox1.Visible = true;
                tabControl1.SelectedIndex = 2;
            }
            else if (holtRadio.Checked)
            {
                SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
                spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

                string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""SaleAmount"" .

DATE Y 2008 M.

PREDICT THRU YEAR 2013 MONTH 1.

* Time Series Modeler.

TSMODEL
/MODELSUMMARY PRINT=[MODELFIT]
/MODELSTATISTICS DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
/MODELDETAILS PRINT=[ PARAMETERS FORECASTS] PLOT=[ RESIDACF RESIDPACF]
/SERIESPLOT OBSERVED FORECAST FIT
/OUTPUTFILTER DISPLAY=ALLMODELS
/SAVE PREDICTED(Predicted) NRESIDUAL(NResidual)
/AUXILIARY CILEVEL=95 MAXACFLAGS=24
/MISSING USERMISSING=EXCLUDE
/MODEL DEPENDENT=amount
PREFIX='Model'
/EXSMOOTH TYPE=HOLT TRANSFORM=NONE.

            ";
                syntax = String.Format(syntax, Config.SPSS_CONNECT);
                spss.ExecuteCommands(syntax, true);
                spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

                var outputItems = spss.GetDesignatedOutputDoc().Items;
                for (int i = 0; i < outputItems.Count; i++)
                {
                    var item = outputItems.GetItem(i);
                    if (item.Label.Equals("Series Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "holt_series_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        holtSeriesChartPic.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Residual ACF/PACF Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "holt_residual_acf_pacf_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        holtResidualAcfPacfChartPic.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Forecast"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label51.Text = cells.ValueAt[0, 0];
                        label49.Text = cells.ValueAt[1, 0];
                        label47.Text = cells.ValueAt[2, 0];
                        //MessageBox.Show("rows: " + cells.NumRows + ", cols: " + cells.NumColumns);
                        //for (int j = 0; j < cells.NumRows; j++)
                        //{
                        //    MessageBox.Show(cells.ValueAt[j, 0].ToString());
                        //}
                        //var labels = table.RowLabelArray();
                        //for (int j = 0; j < labels.NumRows; j++)
                        //{
                        //    for (int k = 0; k < labels.NumColumns; k++)
                        //    {
                        //        MessageBox.Show(String.Format("[{0},{1}] => {2}", j, k, labels.ValueAt[j, k].ToString()));
                        //    }
                        //}
                    }
                    else if (item.Label.Equals("Model Statistics"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label45.Text = cells.ValueAt[0, 3].ToString();
                        label43.Text = cells.ValueAt[0, 4].ToString();
                    }
                    else if (item.Label.Equals("Exponential Smoothing Model Parameters"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label41.Text = cells.ValueAt[0, 0].ToString();
                        label34.Text = cells.ValueAt[1, 0].ToString();
                    }
                }
                if (Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
                spss.Quit();
                tabControl1.SelectedIndex = 3;
            }
            else if (winterRadio.Checked)
            {
                SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
                spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

                string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""SaleAmount"" .

DATE Y 2008 M.

PREDICT THRU YEAR 2013 MONTH 1.

* Time Series Modeler.

TSMODEL
/MODELSUMMARY PRINT=[MODELFIT]
/MODELSTATISTICS DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
/MODELDETAILS PRINT=[ PARAMETERS FORECASTS] PLOT=[ RESIDACF RESIDPACF]
/SERIESPLOT OBSERVED FORECAST FIT
/OUTPUTFILTER DISPLAY=ALLMODELS
/SAVE PREDICTED(Predicted) NRESIDUAL(NResidual)
/AUXILIARY CILEVEL=95 MAXACFLAGS=24
/MISSING USERMISSING=EXCLUDE
/MODEL DEPENDENT=amount
PREFIX='Model'
/EXSMOOTH TYPE=WINTERSMULTIPLICATIVE TRANSFORM=NONE.

            ";
                syntax = String.Format(syntax, Config.SPSS_CONNECT);
                spss.ExecuteCommands(syntax, true);
                spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

                var outputItems = spss.GetDesignatedOutputDoc().Items;
                for (int i = 0; i < outputItems.Count; i++)
                {
                    var item = outputItems.GetItem(i);
                    if (item.Label.Equals("Series Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "winter_series_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox2.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Residual ACF/PACF Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "winter_residual_acf_pacf_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox1.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Forecast"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label64.Text = cells.ValueAt[0, 0];
                        label62.Text = cells.ValueAt[1, 0];
                        label60.Text = cells.ValueAt[2, 0];
                    }
                    else if (item.Label.Equals("Model Statistics"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label58.Text = cells.ValueAt[0, 3].ToString();
                        label56.Text = cells.ValueAt[0, 4].ToString();
                    }
                    else if (item.Label.Equals("Exponential Smoothing Model Parameters"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label54.Text = cells.ValueAt[0, 0].ToString();
                        label12.Text = cells.ValueAt[1, 0].ToString();
                        label70.Text = cells.ValueAt[2, 0].ToString();
                    }
                }
                if (Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
                spss.Quit();
                tabControl1.SelectedIndex = 4;
            }
            else if (arimaRadio.Checked)
            {
                SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
                spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();
                var key = System.DateTime.Now.Ticks.ToString();
                string output = AppDomain.CurrentDomain.BaseDirectory + "arima-" + key + ".sav";
                string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""SaleAmount"" .

DATE Y 2008 M.

PREDICT THRU YEAR 2013 MONTH 1.

* Time Series Modeler.

TSMODEL
/MODELSUMMARY PRINT=[MODELFIT]
/MODELSTATISTICS DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
/MODELDETAILS PRINT=[ PARAMETERS FORECASTS] PLOT=[ RESIDACF RESIDPACF]
/SERIESPLOT OBSERVED FORECAST FIT
/OUTPUTFILTER DISPLAY=ALLMODELS
/SAVE PREDICTED(Predicted) NRESIDUAL(NResidual)
/AUXILIARY CILEVEL=95 MAXACFLAGS=24
/MISSING USERMISSING=EXCLUDE
/MODEL DEPENDENT=amount
PREFIX='Model'
/ARIMA AR=[{1},1] DIFF={2} MA=[{3},1] ARSEASONAL=[0] DIFFSEASONAL=0 MASEASONAL=[0]
TRANSFORM=NONE CONSTANT=YES
/AUTOOUTLIER DETECT=OFF.
SAVE OUTFILE='{4}'.

            ";
                syntax = String.Format(syntax, Config.SPSS_CONNECT, label72.Text, label71.Text, label90.Text, output);
                spss.ExecuteCommands(syntax, true);
                spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

                var outputItems = spss.GetDesignatedOutputDoc().Items;
                for (int i = 0; i < outputItems.Count; i++)
                {
                    var item = outputItems.GetItem(i);
                    if (item.Label.Equals("Series Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "arima_series_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox4.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Residual ACF/PACF Chart"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        string img = "arima_residual_acf_pacf_chart-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox3.ImageLocation = img;
                    }
                    else if (item.Label.Equals("Forecast"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label85.Text = cells.ValueAt[0, 0];
                        label83.Text = cells.ValueAt[1, 0];
                        label81.Text = cells.ValueAt[2, 0];
                    }
                    else if (item.Label.Equals("Model Statistics"))
                    {
                        var table = (spsspvt.PivotTable)item.GetTableOleObject();
                        var cells = table.DataCellArray();
                        label79.Text = cells.ValueAt[0, 3].ToString();
                        label77.Text = cells.ValueAt[0, 4].ToString();
                    }
                }

                syntax = @"
GET
    FILE='{0}'.
ACF VARIABLES=NResidual_amount_Model_1
  /NOLOG
  /MXAUTO 16
  /SERROR=IND
  /PACF.
";
                syntax = String.Format(syntax, output);
                spss.ExecuteCommands(syntax, true);
                outputItems = spss.GetDesignatedOutputDoc().Items;
                for (int i = 0; i < outputItems.Count; i++)
                {
                    var item = outputItems.GetItem(i);
                    if (item.Label.Equals("ACF"))
                    {
                        var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                        if (chart == null) continue;
                        string img = "arima_acf-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                        chart.ExportChart(img, "JPEG File");
                        pictureBox5.ImageLocation = img;
                    }
                }
                if (Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
                spss.Quit();
                tabControl1.SelectedIndex = 5;
            }
        }

        private void alternativeAcfBtn_Click(object sender, EventArgs e)
        {
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

            string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""amount"" .

DATE Y 2008 M.

ACF VARIABLES=amount
/NOLOG
/DIFF={1}
/SDIFF={2}
/MXAUTO 16
/SERROR=IND
/PACF.

            ";
            syntax = String.Format(syntax, Config.SPSS_CONNECT, textBox14.Text, textBox15.Text);

            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;

            var outputItems = spss.GetDesignatedOutputDoc().Items;
            for (int i = 0; i < outputItems.Count; i++)
            {
                var item = outputItems.GetItem(i);
                if (item.Label.Equals("ACF"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    if (chart == null) continue;
                    string acfImg = "ACF-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(acfImg, "JPEG File");
                    acfPic.ImageLocation = acfImg;
                }
                else if (item.Label.Equals("PACF"))
                {
                    var chart = (VISCHARTLib.ISpssChart)item.GetOleObject();
                    if (chart == null) continue;
                    string pacfImg = "PACF-" + System.DateTime.Now.Ticks.ToString() + ".jpg";
                    chart.ExportChart(pacfImg, "JPEG File");
                    pacfPic.ImageLocation = pacfImg;
                }
            }
            if (Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
            spss.Quit();
        }

        private void arimaRadio_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = arimaRadio.Checked;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label72.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label71.Text = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label90.Text = textBox4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            SpssBridge.SpssBridge bridge = new SpssBridge.SpssBridge();
            spsswinLib.Application16 spss = (spsswinLib.Application16)bridge.GetSpss();

            string syntax = @"

GET DATA 
/TYPE=ODBC 
/CONNECT= {0}
/SQL = "" SELECT [month] ,[amount] FROM [StatsInfoSystem.StsContext].[dbo].[SaleAmountPerMonth] WHERE [month]>'2007-12-31' ORDER BY [month]"".

VARIABLE LABEL month ""month""
  amount ""amount"" .

DATE Y 2008 M.

PREDICT THRU YEAR 2013 MONTH 1.
* Time Series Modeler.
TSMODEL
   /MODELSUMMARY  PRINT=[NONE]
   /MODELSTATISTICS  DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
   /MODELDETAILS  PRINT=[ FORECASTS]
   /OUTPUTFILTER DISPLAY=ALLMODELS
   /AUXILIARY  CILEVEL=95 MAXACFLAGS=24
   /MISSING USERMISSING=EXCLUDE
   /MODEL DEPENDENT=amount
      PREFIX='Model'
   /EXSMOOTH TYPE=SIMPLE  TRANSFORM=NONE.
PREDICT THRU YEAR 2013 MONTH 1.
* Time Series Modeler.
TSMODEL
   /MODELSUMMARY  PRINT=[NONE]
   /MODELSTATISTICS  DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
   /MODELDETAILS  PRINT=[ FORECASTS]
   /OUTPUTFILTER DISPLAY=ALLMODELS
   /AUXILIARY  CILEVEL=95 MAXACFLAGS=24
   /MISSING USERMISSING=EXCLUDE
   /MODEL DEPENDENT=amount
      PREFIX='Model'
   /EXSMOOTH TYPE=HOLT  TRANSFORM=NONE.
PREDICT THRU YEAR 2013 MONTH 1.
* Time Series Modeler.
TSMODEL
   /MODELSUMMARY  PRINT=[NONE]
   /MODELSTATISTICS  DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
   /MODELDETAILS  PRINT=[ FORECASTS]
   /OUTPUTFILTER DISPLAY=ALLMODELS
   /AUXILIARY  CILEVEL=95 MAXACFLAGS=24
   /MISSING USERMISSING=EXCLUDE
   /MODEL DEPENDENT=amount
      PREFIX='Model'
   /EXSMOOTH TYPE=WINTERSMULTIPLICATIVE  TRANSFORM=NONE.
PREDICT THRU YEAR 2013 MONTH 1.
* Time Series Modeler.
TSMODEL
   /MODELSUMMARY  PRINT=[NONE]
   /MODELSTATISTICS  DISPLAY=YES MODELFIT=[ SRSQUARE RSQUARE RMSE MAPE MAE]
   /MODELDETAILS  PRINT=[ FORECASTS]
   /OUTPUTFILTER DISPLAY=ALLMODELS
   /AUXILIARY  CILEVEL=95 MAXACFLAGS=24
   /MISSING USERMISSING=EXCLUDE
   /MODEL DEPENDENT=amount
      PREFIX='Model'
   /ARIMA AR=[{1},1]  DIFF={2}  MA=[{3},1]  ARSEASONAL=[0]  DIFFSEASONAL=0  MASEASONAL=[0]
      TRANSFORM=NONE  CONSTANT=YES
   /AUTOOUTLIER DETECT=OFF.
            ";
            syntax = string.Format(syntax, Config.SPSS_CONNECT, textBox13.Text, textBox12.Text, textBox11.Text);
            spss.ExecuteCommands(syntax, true);
            spss.GetDesignatedOutputDoc().Visible = Config.SPSS_OUTPUT;
            if (Config.SPSS_OUTPUT) MessageBox.Show("click to close SPSS.");
            spss.Quit();
        }
    }
}
