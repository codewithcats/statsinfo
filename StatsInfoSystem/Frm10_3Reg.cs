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
    public partial class Frm10_3Reg : UserControl
    {
        public Frm10_3Reg()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            tabControl1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var index = Double.Parse(textBox5.Text);
            var result = 13696858.47 - 169822.984 * index;
            textBox1.Text = result.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox1.Clear();
        }
    }
}
