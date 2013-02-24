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
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importFileName_txtBox.Text = openFileDialog.FileName;
            }
        }
    }
}
