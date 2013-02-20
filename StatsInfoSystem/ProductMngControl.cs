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
            }
        }
    }
}
