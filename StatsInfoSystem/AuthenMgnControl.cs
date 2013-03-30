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
    public partial class AuthenMgnControl : UserControl
    {
        public AuthenMgnControl()
        {
            InitializeComponent();
            category_cmb.SelectedIndex = 0;
        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void category_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text,
                FirstName = TextBox2.Text,
                LastName = textBox3.Text
            };
            var depId = category_cmb.SelectedIndex + 1;
            using (var context = new StsContext())
            {
                var dep = context.Departments.Find(depId);
                emp.Department = dep;
                context.Employees.Add(emp);
                context.SaveChanges();
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
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

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
            checkBox9.Checked = true;
            checkBox10.Checked = true;
            checkBox11.Checked = true;
            checkBox12.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
        }
    }
}
