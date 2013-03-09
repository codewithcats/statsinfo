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
                            if (customerq.Count() < 1) continue;

                            string code = row.Cells[1, 1].Value.ToString();
                            var saleq = from s in context.Sales where s.Code.Equals(code) select s;
                            if (saleq.Count() > 0) continue;
                            try
                            {
                                var date = DateTime.Parse(row.Cells[1, 2].Value.ToString());
                                var customer = (Customer)customerq.Single();
                                var vat = new Decimal(row.Cells[1, 4].Value);
                                var sale = new Sale
                                {
                                    Code = code,
                                    Date = date,
                                    Vat = vat,
                                    Remark = row.Cells[1, 6].Value == null ? null : row.Cells[1, 6].Value.toString(),
                                    Customer = customer
                                };
                                context.Sales.Add(sale);
                            }
                            catch (Exception ex) { continue; }
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["sale line"];
                        range = sheet.UsedRange;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            try
                            {
                                if (i++ == 0) continue;
                                string pcode = row.Cells[1, 8].Value.ToString();
                                var pq = from p in context.Products where p.Code.Equals(pcode) select p;
                                if (pq.Count() < 1) continue;
                                var product = (Product)pq.Single();

                                string scode = row.Cells[1, 2].Value.ToString();
                                var saleq = from s in context.Sales where s.Code.Equals(scode) select s;
                                if (saleq.Count() < 1) continue;
                                var sale = (Sale)saleq.Single();

                                string code = row.Cells[1, 1].Value.ToString();
                                var slq = from sl in context.SaleLines where sl.Code.Equals(code) select sl;
                                if (slq.Count() > 0) continue;

                                var unit = row.Cells[1, 4].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 4].Value.ToString());
                                var unitPrice = row.Cells[1, 5].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 5].Value.ToString());
                                var discount = row.Cells[1, 6].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 6].Value.ToString());

                                var saleLine = new SaleLine()
                                {
                                    Code = code,
                                    Unit = unit,
                                    UnitPrice = unitPrice,
                                    Discount = discount,
                                    Sale = sale,
                                    Product = product
                                };
                                context.SaleLines.Add(saleLine);
                                sale.Amount += saleLine.SubTotal;
                            }
                            catch { continue; }
                            context.SaveChanges();
                        }
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
