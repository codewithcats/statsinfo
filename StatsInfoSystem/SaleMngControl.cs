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
    public partial class SaleMngControl : UserControl
    {
        public SaleMngControl()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                RefreshSale(context);
            }
        }

        private void RefreshSale(StsContext context)
        {
            sale_list.DataSource = context.Sales.ToArray();
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importFileName_txtBox.Text = openFileDialog.FileName;
            }
        }

        private void import_btn_Click(object sender, EventArgs e)
        {
            try
            {
                String xlsName = null;
                if ((xlsName = openFileDialog.FileName) != null)
                {
                    using (var context = new StsContext())
                    {
                        var excel = new Microsoft.Office.Interop.Excel.Application();
                        var workbooks = excel.Workbooks.Open(xlsName);
                        var sheet = workbooks.Sheets["sale"];
                        var range = sheet.UsedRange;
                        var i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            string customerCode = row.Cells[1, 7].Value.ToString();
                            var customerq = from c in context.Customers where c.Code.Equals(customerCode) select c;
                            if (customerq.Count() > 0) continue;
                            try
                            {
                                var sale = new Sale
                                {
                                    Code = row.Cells[1, 1].Value.ToString(),
                                    Date = DateTime.Parse(row.Cells[1, 2].Value.ToString()),
                                    Vat = row.Cells[1, 4].Value == null ? null : Decimal.Parse(row.Cells[1, 4].Value.toString()),
                                    Remark = row.Cells[1, 6].Value == null ? null : row.Cells[1, 6].Value.toString(),
                                    Customer = (Customer)customerq.Single()
                                };
                                context.Sales.Add(sale);
                            }
                            catch { continue; }
                        }
                        context.SaveChanges();

                        //sheet = workbooks.Sheets["sale line"];
                        //range = sheet.UsedRange;
                        //i = 0;
                        //foreach (var row in range.Rows)
                        //{
                        //    if (i++ == 0) continue;
                        //}
                        //context.SaveChanges();

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
