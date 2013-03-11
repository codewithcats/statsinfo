using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
namespace StatsInfoSystem
{
    public partial class Form_Customer : UserControl
    {
        //private Button[] listBut;
        //private Panel[] listPanel;
        //private Control[] listCon;
        //private GroupBox[] listGB;
        //private ListBox[] listLB;
        //private Customer cusChosen;
        //private CustomerGroup cusGroupChosen;
        //private CustomerArea cusAreaChosen;
        public Form_Customer()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                customer_listBox.DataSource = context.Customers.ToArray();
                customer_listBox.DisplayMember = "Name";
                customer_listBox.ValueMember = "Id";

                customerGrp_cmb.DataSource = context.CustomerGroups.ToArray();
                customerGrp_cmb.DisplayMember = "Code";
                customerGrp_cmb.ValueMember = "Id";

                customerArea_cmb.DataSource = context.CustomerAreas.ToArray();
                customerArea_cmb.DisplayMember = "Code";
                customerArea_cmb.ValueMember = "Id";
            }
        }
        //click menu, then page selected will be displayed
        private void button1_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (Button b in listBut)
            //{
            //    listPanel[i].Visible = false;
            //    if (b.Equals(sender))
            //    {
            //        listPanel[i].Visible = true;
            //        break;
            //    }
            //    i++;
            //}
        }
        ////1st part
        //click search, then search with keyword
        private void button4_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ค้นหา
            //foreach(Customer c in Customer.search(textBox1.Text,comboBox1.SelectedIndex))    listBox1.Items.Add(c);
        }
        //click cancel, then clear input search
        private void button5_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ยกเลิก
            //textBox1.Text = "";
            //comboBox1.Text = "";
            //listBox1.Items.Clear();
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {   //แสดงข้อมูลลูกค้า เมื่อเลือก
            //cusChosen = (Customer)listBox1.SelectedItem;
            //Object[] listValue = new Object[] { cusChosen.id,cusChosen.name,cusChosen.cont,cusChosen.add,cusChosen.tel,
            //    cusChosen.fax,cusChosen.email,cusChosen.startDate,cusChosen.order,cusChosen.avgorder,cusChosen.buy,
            //    cusChosen.avgbuy,cusChosen.quanbuy,cusChosen.avgquanbuy,cusChosen.contact,cusChosen.creditlimit,
            //    cusChosen.getLate,cusChosen.group,cusChosen.area};
            //for (int i = 0; i < listValue.Length; i++) listCon[i].Text = listValue[i].ToString();
        }
        private void listBox1_SizeChanged(object sender, EventArgs e){
            //int i = 0;
            //foreach (ListBox lb in listLB)
            //{
            //    if (sender.Equals(listLB[i])) break;
            //    i++;
            //}
            //GroupBox gb = listGB[i];
            //String str = gb.Text;
            //String[] listText = str.Split(' ');
            //gb.Text = listText[0] + " " + listLB[i].ItemHeight + " " + listText[2];
        }
        private void button10_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า  เพิ่ม
            //if (!(checkEmptyTextboxCustomerData() && MessageBox.Show("คุณต้องการเพิ่มข้อมูล ใช่หรือไม่", "ยืนยันการเพิ่มข้อมูลลูกค้า",
            //    MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)) return;
            //Customer.addCustomer(textBox2.Text, textBox3.Text, textBox4.Text, "", textBox5.Text, textBox6.Text,
            //    textBox9.Text, dateTimePicker1.Value, (CustomerGroup)comboBox2.SelectedItem, 
            //    (CustomerArea)comboBox3.SelectedItem);    //เพิ่มข้อมูลลูกค้า
            //MessageBox.Show("ระบบได้เพิ่มข้อมูลลูกค้าเรียบร้อยแล้ว","ผลการทำงาน",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void button11_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า  แก้ไข
            //if (!(checkEmptyTextboxCustomerData() && MessageBox.Show("คุณต้องการแก้ไขข้อมูล ใช่หรือไม่", "ยืนยันการแก้ไขข้อมูลลูกค้า",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) return; //แก้ไขข้อมูลลูกค้า
            //cusChosen.editCustomer(textBox3.Text, textBox4.Text, "", textBox5.Text, textBox6.Text, textBox9.Text,
            //    dateTimePicker1.Value, (CustomerGroup)comboBox2.SelectedItem, (CustomerArea)comboBox3.SelectedItem);
            //MessageBox.Show("ระบบได้แก้ไขข้อมูลลูกค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private Boolean checkEmptyTextboxCustomerData() {
            //foreach (Control c in listCon) {
            //    if (c.Text.Equals("")) {
            //        MessageBox.Show("กรุณาป้อนข้อมูลให้ครบถ้วน","ผลการตรวจสอบ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            return false;
        }
        private void button12_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ลบข้อมูล
            //cusChosen.delete();
            //cusChosen = null;
        }
        private void button13_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ล้างข้อมูล
            //foreach (Control c in listCon) c.Text = "";
        }
        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importFileName_txtBox.Text = openFileDialog.FileName;
            }
        }
        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String xlsName = null;
                if ((xlsName = openFileDialog.FileName) != null)
                {
                    using (var context = new StsContext())
                    {
                        var excel = new Microsoft.Office.Interop.Excel.Application();
                        var workbooks = excel.Workbooks.Open(xlsName);
                        var sheet = workbooks.Sheets["cusarea"];
                        var range = sheet.UsedRange;
                        var i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            var area = new CustomerArea
                            {
                                Code = row.Cells[1, 1].Value.ToString(),
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.CustomerAreas.Add(area);
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["cusgroup"];
                        range = sheet.UsedRange;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            var group = new CustomerGroup
                            {
                                Code = row.Cells[1, 1].Value.ToString(),
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.CustomerGroups.Add(group);
                        }
                        context.SaveChanges();

                        sheet = workbooks.Sheets["customer"];
                        range = sheet.UsedRange;
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            try
                            {
                                var code = row.Cells[1, 1].Value.ToString();
                                var name = row.Cells[1, 2].Value.ToString();
                                var cname = row.Cells[1, 3].Value == null ? null : row.Cells[1, 3].Value.ToString();
                                var address = row.Cells[1, 4].Value == null ? null : row.Cells[1, 4].Value.ToString();
                                var phone = row.Cells[1, 5].Value == null ? null : row.Cells[1, 5].Value.ToString();
                                var fax = row.Cells[1, 6].Value == null ? null : row.Cells[1, 6].Value.ToString();
                                var email = row.Cells[1, 7].Value == null ? null : row.Cells[1, 7].Value.ToString();
                                var orderAverage = row.Cells[1, 10].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 10].Value.ToString());
                                var startDate = row.Cells[1, 8].Value == null ? new Decimal(0) : DateTime.Parse(row.Cells[1, 8].Value.ToString());
                                var buy = row.Cells[1, 11].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 11].Value.ToString());
                                var buyAv = row.Cells[1, 12].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 12].Value.ToString());
                                var qbuy = row.Cells[1, 13].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 13].Value.ToString());
                                var qbuyAv = row.Cells[1, 14].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 14].Value.ToString());
                                var month = row.Cells[1, 15].Value == null ? 0 : Convert.ToInt32(row.Cells[1, 15].Value.ToString());
                                var late = row.Cells[1, 17].Value == null ? 0 : Convert.ToInt32(row.Cells[1, 17].Value.ToString());
                                var customer = new Customer
                                {
                                    Code = code,
                                    Name = name,
                                    ContactName = cname,
                                    Address = address,
                                    Phone = phone,
                                    Fax = fax,
                                    Email = email,
                                    StartDate = startDate,
                                    Order = row.Cells[1, 9].Value == null ? new Decimal(0) : Decimal.Parse(row.Cells[1, 9].Value.ToString()),
                                    OrderAverage = orderAverage,
                                    Buy = buy,
                                    BuyAverage = buyAv,
                                    QuanBuy = qbuy,
                                    QuanBuyAverage = qbuyAv,
                                    ContactMonth = month,
                                    CreditLimit = row.Cells[1, 16].Value == null ? null : row.Cells[1, 16].Value.ToString(),
                                    Late = late
                                };
                                if (row.Cells[1, 18].Value == null)
                                {
                                    customer.Group = null;
                                }
                                else
                                {
                                    string groupId = row.Cells[1, 18].Value.ToString();
                                    var grpQuery = from g in context.CustomerGroups
                                                   where g.Code == groupId
                                                   select g;
                                    var group = grpQuery.Single();
                                    customer.Group = group;
                                }
                                if (row.Cells[1, 19].Value == null)
                                {
                                    customer.Area = null;
                                }
                                else
                                {
                                    string areaId = row.Cells[1, 19].Value.ToString();
                                    var areaQuery = from a in context.CustomerAreas
                                                    where a.Code == areaId
                                                    select a;
                                    var area = areaQuery.Single();
                                    customer.Area = area;
                                }
                                context.Customers.Add(customer);
                                context.SaveChanges();
                            }
                            catch
                            {
                                continue;
                            }
                        }

                    }
                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ล้างข้อมูล
            //foreach (TextBox tb in new TextBox[] { textBox17, textBox18, textBox19, textBox20, textBox21 }) tb.Text = "";
        }
        private void button18_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า   ค้นหา
            //foreach (CustomerGroup cg in CustomerGroup.search(textBox37.Text, comboBox6.SelectedIndex)) listBox3.Items.Add(cg);
        }
        private void button17_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า ยกเลิก
            //textBox37.Text = "";
            //listBox3.Items.Clear();
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cusGroupChosen = (CustomerGroup)listBox3.SelectedItem;
            //textBox34.Text = cusGroupChosen.id;
            //textBox33.Text = cusGroupChosen.name;
        }
        private void button9_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า เพิ่ม
            //cusGroupChosen = CustomerGroup.addGroup(textBox34.Text, textBox33.Text);
        }
        private void button8_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า แก้ไข
            //cusGroupChosen.editGroup(textBox33.Text);
        }
        private void button7_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า ลบข้อมูล
            //cusGroupChosen.delete();
            //cusGroupChosen = null;
            //button6_Click(null, null);
        }
        private void button6_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า ล้างข้อมูล
            textBox34.Text = "";
            textBox33.Text = "";
        }
        private void button24_Click(object sender, EventArgs e)
        {   //พื้นที่ลุกค้า ค้นหา
            //foreach (CustomerArea ca in CustomerArea.search(textBox24.Text, comboBox4.SelectedIndex)) listBox4.Items.Add(ca);
        }
        private void button23_Click(object sender, EventArgs e)
        {   //พื้นที่ลูกค้า ยกเลิก
            textBox24.Text = "";
            comboBox4.Text = "";
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cusAreaChosen = (CustomerArea)listBox4.SelectedItem;
            //textBox23.Text = cusAreaChosen.id;
            //textBox22.Text = cusAreaChosen.name;
        }
        private void button22_Click(object sender, EventArgs e)
        {   //พื้นที่ลูกค้า เพิ่ม
            //cusAreaChosen = CustomerArea.addArea(textBox23.Text,textBox22.Text);
        }
        private void button21_Click(object sender, EventArgs e)
        {   //พื้นที่ลูกค้า แก้ไข
            //cusAreaChosen.edit(textBox22.Text);
        }
        private void button20_Click(object sender, EventArgs e)
        {   //พื้นที่ลูกค้า ลบข้อมูล
            //cusAreaChosen.delete();
            //cusAreaChosen = null;
            //button19_Click(null, null);
        }
        private void button19_Click(object sender, EventArgs e)
        {   //พื้นที่ลูกค้า ล้างข้อมูล
            textBox23.Text = "";
            textBox22.Text = "";
        }

        private void customer_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = (Customer)customer_listBox.SelectedItem;
            customerCode_txtBox.Text = customer.Code;
            customerName_txtBox.Text = customer.Name;
            customerContName_txtBox.Text = customer.ContactName;
            customerPhone_txtBox.Text = customer.Phone;
            customerFax_txtBox.Text = customer.Fax;
            customerEmail_txtBox.Text = customer.Email;
            customerStartDate_dt.Value = customer.StartDate;
            customerOrder_txtBox.Text = customer.Order.ToString();
            customerOrderAv_txtBox.Text = customer.OrderAverage.ToString();
            customerBuyAv_txtBox.Text = customer.BuyAverage.ToString();
            customerQuanBuy_txtBox.Text = customer.QuanBuy.ToString();
            customerQuanBuyAv_txtBox.Text = customer.QuanBuyAverage.ToString();
            customerMonth_txtBox.Text = customer.ContactMonth.ToString();
            customerLate_txtBox.Text = customer.Late.ToString();
            customerCredit_txtBox.Text = customer.CreditLimit;
            customerGrp_cmb.SelectedItem = customer.Group;
            customerArea_cmb.SelectedItem = customer.Area;
        }
        
    }
}
