using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace StatsInfoSystem
{
    public partial class CustomerMngControl : UserControl
    {
        public CustomerMngControl()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                RefreshCustomer(context);
                RefreshCustomerGroup(context);
            }
        }

        private void RefreshCustomerGroup(StsContext context)
        {
            var ds = context.CustomerGroups.ToArray();
            customerGrp_list.DataSource = ds;
            customerGrp_cmb.DataSource = ds;
        }

        private void RefreshCustomer(StsContext context)
        {
            customer_list.DataSource = context.Customers.ToArray();
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
                        var sheet = workbooks.Sheets["cusarea"];
                        var range = sheet.UsedRange;
                        var i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            string areaCode = row.Cells[1, 1].Value.ToString();
                            var areq = from ac in context.CustomerAreas where ac.Code.Equals(areaCode) select ac;
                            if (areq.Count() > 0) continue;
                            var area = new CustomerArea
                            {
                                Code = areaCode,
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.CustomerAreas.Add(area);
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["cusgroup"];
                        range = sheet.UsedRange;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            string grpCode = row.Cells[1, 1].Value.ToString();
                            var grpq = from grp in context.CustomerGroups where grp.Code.Equals(grpCode) select grp;
                            if(grpq.Count() > 0) continue;
                            var group = new CustomerGroup
                            {
                                Code = grpCode,
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.CustomerGroups.Add(group);
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["customer"];
                        range = sheet.UsedRange;
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            try
                            {
                                string code = row.Cells[1, 1].Value.ToString();

                                var codeq = from c in context.Customers where c.Code.Equals(code) select c;
                                if (codeq.Count() > 0) continue;

                                var name = row.Cells[1, 2].Value.ToString();
                                var cname = row.Cells[1, 3].Value == null ? null : row.Cells[1, 3].Value.ToString();
                                var address = row.Cells[1, 4].Value == null ? null : row.Cells[1, 4].Value.ToString();
                                var phone = row.Cells[1, 5].Value == null ? null : row.Cells[1, 5].Value.ToString();
                                var fax = row.Cells[1, 6].Value == null ? null : row.Cells[1, 6].Value.ToString();
                                var email = row.Cells[1, 7].Value == null ? null : row.Cells[1, 7].Value.ToString();
                                //var orderAverage = row.Cells[1, 10].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 10].Value.ToString());
                                var startDate = row.Cells[1, 8].Value == null ? new Decimal(0) : DateTime.Parse(row.Cells[1, 8].Value.ToString());
                                //var buy = row.Cells[1, 11].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 11].Value.ToString());
                                //var buyAv = row.Cells[1, 12].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 12].Value.ToString());
                                //var qbuy = row.Cells[1, 13].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 13].Value.ToString());
                                //var qbuyAv = row.Cells[1, 14].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 14].Value.ToString());
                                //var month = row.Cells[1, 15].Value == null ? 0 : Convert.ToInt32(row.Cells[1, 15].Value.ToString());
                                var late = row.Cells[1, 17].Value == null ? 0 : Convert.ToInt32(row.Cells[1, 17].Value.ToString());
                                var customer = new Customer
                                {
                                    Code = code,
                                    Name = name,
                                    ContactName = cname,
                                    Address = address,
                                    Phone = phone,
                                    Fax = fax,
                                    Email = email,
                                    StartDate = startDate,
                                    Order = row.Cells[1, 9].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 9].Value.ToString()),
                                    //OrderAverage = orderAverage,
                                    //Buy = buy,
                                    //BuyAverage = buyAv,
                                    //QuanBuy = qbuy,
                                    //QuanBuyAverage = qbuyAv,
                                    //ContactMonth = month,
                                    CreditLimit = row.Cells[1, 16].Value == null ? null : row.Cells[1, 16].Value.ToString(),
                                    Late = late
                                };
                                if (row.Cells[1, 18].Value == null)
                                {
                                    customer.Group = null;
                                }
                                else
                                {
                                    string groupId = row.Cells[1, 18].Value.ToString();
                                    var grpQuery = from g in context.CustomerGroups
                                                   where g.Code == groupId
                                                   select g;
                                    var group = grpQuery.Single();
                                    customer.Group = group;
                                }
                                if (row.Cells[1, 19].Value == null)
                                {
                                    customer.Area = null;
                                }
                                else
                                {
                                    string areaId = row.Cells[1, 19].Value.ToString();
                                    var areaQuery = from a in context.CustomerAreas
                                                    where a.Code == areaId
                                                    select a;
                                    var area = areaQuery.Single();
                                    customer.Area = area;
                                }
                                context.Customers.Add(customer);
                                context.SaveChanges();
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        RefreshCustomer(context);
                        RefreshCustomerGroup(context);
                    }
                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void showProduct_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void showGrp_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void showCat_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }
    }
}
