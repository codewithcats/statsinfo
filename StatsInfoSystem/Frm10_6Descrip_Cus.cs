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
    public partial class Frm10_6Descrip_Cus : UserControl
    {
        public Frm10_6Descrip_Cus()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                customer_gridView.DataSource = context.Customers.ToArray();

            }
        }

        private void displayInfo_btn_Click(object sender, EventArgs e)
        {
            mainTab.SelectedIndex = 0;
            customerInfo_grid_panel.Visible = true;
        }

        private void process_btn_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            mainTab.SelectedIndex = 1;
        }
    }
}
