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
                grp_cmb.DataSource = context.ProductGroups.ToArray();
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
    }
}
