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
    public partial class FactorMngControl : UserControl
    {
        public FactorMngControl()
        {
            InitializeComponent();
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                importFileName_txtBox.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String xlsName = null;
                if ((xlsName = openFileDialog1.FileName) != null)
                {
                    using (var context = new StsContext())
                    {
                        var excel = new Microsoft.Office.Interop.Excel.Application();
                        var workbooks = excel.Workbooks.Open(xlsName);
                        var sheet = workbooks.Sheets["factor"];
                        var range = sheet.UsedRange;
                        var i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            try
                            {
                                var month = row.Cells[1, 1].Value.ToString();
                                var year = row.Cells[1, 2].Value.ToString();
                                var CurExcRate = row.Cells[1, 3].Value.ToString();
                                var ConPriceIndex = row.Cells[1, 4].Value.ToString();
                                var ConPriceIndexMat = row.Cells[1, 5].Value.ToString();
                                var ProductIndex = row.Cells[1, 6].Value.ToString();
                                var ProductionRate = row.Cells[1, 7].Value.ToString();

                                var sql = @"
                                insert into Factors(Month, Year, CurExcRate, ConPriceIndex, ConPriceIndexMat, ProductIndex, ProductionRate)
                                values({0}, {1}, {2}, {3}, {4}, {5}, {6})
                                ";
                                sql = string.Format(sql, month, year, CurExcRate, ConPriceIndex, ConPriceIndexMat, ProductIndex, ProductionRate);
                                context.Database.ExecuteSqlCommand(sql);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        context.SaveChanges();
                    }
                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
}
