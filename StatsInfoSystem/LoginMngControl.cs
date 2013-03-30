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
    public partial class LoginMngControl : UserControl
    {
        private Form1 form;
        public LoginMngControl(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;
            using (var context = new StsContext())
            {
                var query = from emp in context.Employees where emp.Username == username && emp.Password == password select emp;
                Employee user;
                try
                {
                    user = query.Single();
                    if (user != null)
                    {
                        form.loginSuccess(user);
                    }
                    else
                    {
                        MessageBox.Show("กรุณาตรวจสอบชื่อผู้ใช้งานและรหัสผ่านของท่านอีกครั้ง");
                    }
                }
                catch
                {
                    MessageBox.Show("กรุณาตรวจสอบชื่อผู้ใช้งานและรหัสผ่านของท่านอีกครั้ง");
                }
            }
        }

    }
}
