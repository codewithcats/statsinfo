using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace StatsInfoSystem
{
    public partial class Form_Main : Form
    {
        private ArrayList form_list = new ArrayList();
        public Form_Main()
        {
            InitializeComponent();
            changeVisible(false);
            setNewLogin();
        }
        private void setNewLogin()
        {
            form_list.Clear();
            this.Hide();
            (new Form_Login(this)).Show();
        }
        public void setCurrentUser(User user)
        {
            //todo
        }
        private void toolStripLabel4_Click(object sender, EventArgs e)
        {   //ออกจากระบบ
            if (MessageBox.Show("คุณต้องการออกจากระบบ ใช่หรือไม่", "ยืนยันการออกจากระบบ", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No) return;
            setNewLogin();
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
        }
        //เปลี่ยนรหัสผ่านใหม่
        private void toolStripLabel1_Click(object sender, EventArgs e) 
        { 
            //new Form_ChangePsw(currentUser); 
        }
        private void กำหนดสทธผใชงานToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            //showPage(new Main_FormatForm()); 
        }
        private void showPage(Control c)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(c);
            changeVisible(true);
        }
        public void back()
        {
            this.changeVisible(false);
            panel1.Controls.Clear();
        }
        private void changeVisible(Boolean value)
        {
            toolStrip1.Items[0].Visible = value;
            toolStrip1.Items[1].Visible = value;
        }
        private void toolStripLabel8_Click(object sender, EventArgs e) { this.changeVisible(false); }
        private void customerMenuItem_Click(object sender, EventArgs e) 
        { 
            showPage(new Form_Customer()); 
        }
        private void toolStripLabel5_Click(object sender, EventArgs e)
        {

        }
        private void ขอมลการขายสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //showPage(new Form_Sale2(currentUser)); 
        }
        private void productMenuItem_Click(object sender, EventArgs e) 
        {
            showPage(new Form_Product());
        }
        private void ระบบพยากรณยอดขายสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showPage(new Form_Forcast_Sale());
            ////comment
            //ArrayList listCat = ProductCategory.getList();
            //int num = listCat.Count;
            //int mon = 6;
            //double[,] table = new double[mon, num + 1];
            //TimeIndex[] listMon = new TimeIndex[mon];
            //for (int i = 0; i < mon; i++)
            //{
            //    for (int j = 0; j <= num + 1; j++) table[i, j] = 0;
            //    listMon[i] = TimeIndex.previousTimeIndex(i);
            //    ArrayList listSale = Sale.searchByTimeIndex(listMon[i]);
            //    foreach (Sale s in listSale) foreach (SaleLineItem sli in s.getItemList())
            //        {
            //            int index = ProductCategory.getIndex(sli.getProduct().getCategory());
            //            if (index == -1) continue;
            //            table[i, index] += sli.getSubTotal();
            //            table[i, num] += sli.getSubTotal();
            //        }
            //}
            //String[] head = new String[num + 1];
            //head[0] = "Month";
            //for (int i = 1; i < num + 1; i++) head[i] = ((ProductCategory)listCat[i - 1]).getName();
            //String[,] data = new String[mon, num + 1];
            //for (int i = 0; i < mon; i++)
            //{
            //    data[i, 0] = listMon[i].toString();
            //    for (int j = 0; j < num; j++) data[i, j + 1] = table[i, j] + "";
            //}
            //String file = "c:\\test.xlsx";
            //ArrayList listCMD = new ArrayList();
            //listCMD.Add("GET FILE = '" + file + "'");
            //String line2 = "";
            //foreach (ProductCategory pc in listCat) line2 += " " + pc.getName();
            //listCMD.Add("TSPLOT VARIABLES=" + line2 + "/NOLOG.");
            //listCMD.Add("execute.");
            //showPage(new Form_Forcast((String[])listCMD.ToArray(typeof(String))));
        }
        private void ระบบวเคราะหจดกลมลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //showPage(new Form_Forcast_Cluster()); 
        }
        private void ขอมลปจจยภายนอกToolStripMenuItem_Click(object sender, EventArgs e) 
        { 
            //showPage(new Form_Factor()); 
        }
        private void changeUserMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("คุณต้องการเปลี่ยนผู้ใช้งานระบบ ใช่หรือไม่", "ยืนยันการเปลี่ยนผู้ใช้งานระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            else if (result == DialogResult.Yes)
            {
                setNewLogin();
            }
        }
        private void ระบบวเคราะหจดสำดบคสคของลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //showPage(new Form_Forcast_Order()); 
        }
        private void userFormMenu_click(object sender, EventArgs e) 
        { 
            showPage(new Form_Employee()); 
        }

        private void basicAnalysisMenu_Click(object sender, EventArgs e)
        {
            showPage(new Frm10_6Descrip_Cus());
        }

        private void sellAnalysisMenu_Click(object sender, EventArgs e)
        {
            showPage(new Frm10_3Reg());
        }

        private void ระบบสอบถามและแสดงสารสนเทศสำหรบผบรหารToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //showPage(new frmOLAP());
        }
    }
}
