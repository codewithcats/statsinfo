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
                product_listBox.DataSource = context.Products.ToArray();
                category_cmb.DataSource = context.ProductCategories.ToArray();
                productCat_listBox.DataSource = context.ProductCategories.ToArray();
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
    }
}
