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
    public partial class ProductMngControl : UserControl
    {
        public ProductMngControl()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                RefreshProduct(context);
                RefreshProductCategory(context);
                RefreshProductGroup(context);
            }
        }

        private void product_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = (Product)product_listBox.SelectedItem;
            code_txt.Text = product.Code;
            name_txt.Text = product.NameTh;
            prict_txt.Text = product.Price.ToString();
            description_txt.Text = product.Description;
            category_cmb.SelectedItem = product.Category;
            grp_cmb.SelectedItem = product.Group;
        }

        private void productGrp_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            var group = (ProductGroup)productGrp_list.SelectedItem;
            grpCode_txt.Text = group.Code;
            grpName_txt.Text = group.Name;
        }

        private void delGrp_btn_Click(object sender, EventArgs e)
        {
            var g = (ProductGroup)productGrp_list.SelectedItem;
            using (var context = new StsContext())
            {
                var pq = from p in context.Products where p.Group.Id == g.Id select p;
                var pcount = pq.Count();
                if (pcount > 0)
                {
                    MessageBox.Show("ไม่สามารถลบกลุ่มนี้ได้ เนื่องจากมีสินค้าที่ถูกจัดอยู่ในกลุ่มนี้");
                    return;
                }
                g = context.ProductGroups.Find(g.Id);
                context.ProductGroups.Remove(g);
                context.SaveChanges();
                RefreshProductGroup(context);
            }
        }

        private void RefreshProductGroup(StsContext context)
        {
            grp_cmb.DataSource = context.ProductGroups.ToArray();
            productGrp_list.DataSource = context.ProductGroups.ToArray();
        }

        private void addGrp_btn_Click(object sender, EventArgs e)
        {
            var g = new ProductGroup { Code = grpCode_txt.Text, Name = grpName_txt.Text };
            using (var context = new StsContext())
            {
                var gq = from _g in context.ProductGroups where _g.Code.Equals(g.Code) select _g;
                var gcount = gq.Count();
                if (gcount > 0)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มกลุ่มสินค้าได้ เนื่องจากรหัสกลุ่มนี้มีอยู่ในฐานข้อมูลแล้ว");
                    return;
                }
                context.ProductGroups.Add(g);
                context.SaveChanges();
                RefreshProductGroup(context);
            }
        }

        private void editGrp_btn_Click(object sender, EventArgs e)
        {
            var g = (ProductGroup)productGrp_list.SelectedItem;
            using (var context = new StsContext())
            {
                g = context.ProductGroups.Find(g.Id);
                g.Code = grpCode_txt.Text;
                g.Name = grpName_txt.Text;
                context.SaveChanges();
                RefreshProductGroup(context);
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
            tabControl1.SelectedIndex = 2;
        }

        private void productCat_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cat = (ProductCategory)productCat_listBox.SelectedItem;
            productCatCode_txtBox.Text = cat.Code;
            productCatName_txtBox.Text = cat.Name;
        }

        private void addProductCat_btn_Click(object sender, EventArgs e)
        {
            var c = new ProductCategory { Code = productCatCode_txtBox.Text, Name = productCatName_txtBox.Text };
            using (var context = new StsContext())
            {
                var cq = from _c in context.ProductCategories where _c.Code.Equals(c.Code) select _c;
                var ccount = cq.Count();
                if (ccount > 0)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มประเภทสินค้าได้ เนื่องจากรหัสประเภทนี้มีอยู่ในฐานข้อมูลแล้ว");
                    return;
                }
                context.ProductCategories.Add(c);
                context.SaveChanges();
                RefreshProductCategory(context);
            }
        }

        private void RefreshProductCategory(StsContext context)
        {
            category_cmb.DataSource = context.ProductCategories.ToArray();
            productCat_listBox.DataSource = context.ProductCategories.ToArray(); 
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importFileName_txtBox.Text = openFileDialog.FileName;
            }
        }

        private void importFromXls_btn_Click(object sender, EventArgs e)
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
                        var sheet = workbooks.Sheets["prodcat"];
                        var range = sheet.UsedRange;
                        var i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            string code = row.Cells[1, 1].Value.ToString();
                            var catq = from c in context.ProductCategories where c.Code.Equals(code) select c;
                            if (catq.Count() > 0) continue;
                            var cat = new ProductCategory() { 
                                Code = code,
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.ProductCategories.Add(cat);
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["prodgroup"];
                        range = sheet.UsedRange;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            string code = row.Cells[1, 1].Value.ToString();
                            var grpq = from g in context.ProductGroups where g.Code.Equals(code) select g;
                            if (grpq.Count() > 0) continue;
                            var grp = new ProductGroup()
                            {
                                Code = code,
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.ProductGroups.Add(grp);
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["product"];
                        range = sheet.UsedRange;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            string code = row.Cells[1, 1].Value.ToString();
                            var pq = from p in context.Products where p.Code.Equals(code) select p;
                            if (pq.Count() > 0) continue;
                            try
                            {
                                var product = new Product()
                                {
                                    Code = code,
                                    NameTh = row.Cells[1, 2].Value.ToString(),
                                    NameEn = row.Cells[1, 3].Value.ToString(),
                                    Price = Decimal.Parse(row.Cells[1, 4].Value.ToString()),
                                    Description = row.Cells[1, 5].Value == null ? null : row.Cells[1, 4].Value.ToString()
                                };
                                string groupId = row.Cells[1, 6].Value.ToString();
                                var grpQuery = from g in context.ProductGroups
                                               where g.Code == groupId
                                               select g;
                                var group = grpQuery.Single();
                                product.Group = group;
                                string catId = row.Cells[1, 7].Value.ToString();
                                var catQuery = from c in context.ProductCategories
                                               where c.Code == catId
                                               select c;
                                var category = catQuery.Single();
                                product.Category = category;
                                context.Products.Add(product);
                            }
                            catch { continue; }
                        }
                        context.SaveChanges();

                        RefreshProductCategory(context);
                        RefreshProductGroup(context);
                        RefreshProduct(context);
                    }
                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void RefreshProduct(StsContext context)
        {
            product_listBox.DataSource = context.Products.ToArray();
        }
    }
}
