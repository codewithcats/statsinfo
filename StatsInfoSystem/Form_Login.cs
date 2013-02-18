using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class Form_Login : Form
    {
        private Form_Main main;
        public Form_Login(Form_Main fm)
        {
            InitializeComponent();
            main = fm;
        }
        private void Form_Login_FormClosed(object sender, FormClosedEventArgs e){   main.Close();   }
        private void ok_btn_Click(object sender, EventArgs e)
        {
            using (var context = new StsContext())
            {
                var userQuery = from u in context.Users
                                where u.Username == username_txtBox.Text
                                && u.Password == password_txtBox.Text
                                select u;
                try
                {
                    var user = userQuery.Single();
                    main.setCurrentUser(user);
                    main.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("รหัสผู้ใช้หรือรหัสผ่านไม่ถูกต้อง โปรดตรวจสอบข้อมูลของท่านอีกครั้ง!!!(จะแสดงเฉพาะกรณีที่ผิดพลาด)", "คำเตือน",
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) { Form_Login_FormClosed(null, null); }
    }
}
