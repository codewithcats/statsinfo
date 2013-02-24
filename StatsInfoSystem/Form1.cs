using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class Form1 : Form
    {
        private LoadingIndicator loadingIndicator = new LoadingIndicator() { Dock = DockStyle.Top };
        private CustomerMngControl customerMngControl;
        private ProductMngControl productMngControl;
        public Form1()
        {
            InitializeComponent();
        }

        private void customerMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (customerMngControl == null) customerMngControl = new CustomerMngControl();
            DisplayControl(customerMngControl);
        }

        private void DisplayControl(Control c)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            mainPanel.Refresh();
        }

        private void productMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(loadingIndicator);
            if (productMngControl == null) productMngControl = new ProductMngControl();
            DisplayControl(productMngControl);
        }
    }
}
