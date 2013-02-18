using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace StatsInfoSystem
{
    public partial class Form_Product : UserControl
    {
        //private Button[] listBut;
        //private Panel[] listPanel;
        //private Control[] listCon;
        //private GroupBox[] listGB;
        //private ListBox[] listLB;
        //private Product productSelected;
        //private ProductGroup progroupselectecd;
        //private ProductCategory procatselected;
        public Form_Product()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                productCat_listBox.DataSource = context.ProductCategories.ToArray();
                productCat_listBox.DisplayMember = "DisplayName";
                productCat_listBox.ValueMember = "Id";
            }
        }
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
        private void button4_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ค้นหา
            //ArrayList listPro = Product.search(textBox1.Text, comboBox1.SelectedIndex);
            //foreach (Product p in listPro) listBox1.Items.Add(p);
        }
        private void button5_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ยกเลิก
            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {   //แสดงข้อมูลลูกค้า เมื่อเลือก
            //productSelected = (Product)listBox1.SelectedItem;
            //textBox2.Text = productSelected.getID();
            //textBox3.Text = productSelected.getName();
            //textBox4.Text = productSelected.getPrice()+"";
            //textBox5.Text = productSelected.getDesc();
            //comboBox2.SelectedItem = productSelected.getGroup();
            //comboBox3.SelectedItem = productSelected.getCategory();
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
            //Product.addProduct(textBox2.Text, textBox3.Text, System.Convert.ToDouble(textBox4.Text), textBox4.Text,
            //    (ProductGroup)comboBox2.SelectedItem, (ProductCategory)comboBox3.SelectedItem);//เพิ่มข้อมูลลูกค้า
            //MessageBox.Show("ระบบได้เพิ่มข้อมูลลูกค้าเรียบร้อยแล้ว","ผลการทำงาน",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void button11_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า  แก้ไข
            //if (!(checkEmptyTextboxCustomerData() && MessageBox.Show("คุณต้องการแก้ไขข้อมูล ใช่หรือไม่", "ยืนยันการแก้ไขข้อมูลลูกค้า",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)) return;
            //productSelected.editProduct(textBox2.Text,System.Convert.ToDouble(textBox3.Text),textBox4.Text,
            //    (ProductGroup)comboBox2.SelectedItem,(ProductCategory)comboBox3.SelectedItem);//แก้ไขข้อมูลลูกค้า
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
            //productSelected.delete();
            //productSelected = null;
            //button13_Click(null,null);
        }
        private void button13_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ล้างข้อมูล
            //Control[] listCon = new Control[] { textBox2,textBox3,textBox4,textBox5,comboBox2,comboBox3};
            //foreach (Control c in listCon) c.Text = "";
        }
        private void button14_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า ...
            //String filename;
            //do{
            //    if(openFileDialog1.ShowDialog()!=DialogResult.OK)   return;
            //    filename = openFileDialog1.FileName;
            //} while (!(ExcelImportor.isExcelType(filename) && (filename!=null && !filename.Equals(""))));
            //textBox17.Text = filename;
            //FileInfo fileinfo = new FileInfo(filename);
            //textBox18.Text = fileinfo.Name;
            //textBox19.Text = fileinfo.GetType().ToString();
            //double filesize = (double)fileinfo.Length;
            //String[] metre = new String[] { "bytes", "KB", "MB", "GB", "TB" };
            //String fullSize="";
            //foreach (String m in metre) {
            //    if (!(filesize > 0 && filesize < 1024)) {
            //        fullSize = String.Format("{0,-10:000.00}", filesize) + " " + m;
            //        break;
            //    }
            //    filesize = filesize / 1024;
            //}
            //textBox20.Text = fullSize;
            //textBox21.Text = String.Format("{0:MM/dd/yyyy}", fileinfo.LastAccessTime);
        }
        private void button15_Click(object sender, EventArgs e)
        {   //ข้อมูลลูกค้า นำเข้าข้อมูล
            //String[,] table = ExcelImportor.readFile(textBox17.Text);
            //if (table == null)
            //{
            //    MessageBox.Show("ระบบไม่สามารถนำเข้าข้อมูลได้ มีรายการซ้ำกับข้อมูลเดิม", "ผลการตรวจสอบ", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    return;
            //}
            //for (int i = 1; i <= table.GetUpperBound(0); i++)   listBox2.Items.Add(Product.addProduct(table[i, 0], table[i, 1],
            //    System.Convert.ToDouble(table[i, 2]), table[i, 3], table[i, 4], table[i, 5]));
            //MessageBox.Show("ระบบนำเข้าข้อมูลได้ครบถ้วน", "ยืนยันผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button16_Click(object sender, EventArgs e)
        {   //ข้อมูลสินค้า นำเข้าข้อมูลสินค้า ยกเลิก
            //TextBox[] listCon = new TextBox[] { textBox17, textBox18, textBox19, textBox20, textBox21 };
            //foreach (TextBox tb in listCon) tb.Text = "";
            //listBox2.Items.Clear();
        }
        private void button18_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า ค้นหา
            //foreach(ProductGroup pg in ProductGroup.search(textBox37.Text,comboBox6.SelectedIndex))  listBox3.Items.Add(pg);
        }
        private void button9_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า เพิ่ม
            //progroupselectecd = ProductGroup.addGroup(textBox34.Text, textBox33.Text);
        }
        private void button17_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า ยกเลิก
            //textBox37.Text = "";
            //comboBox6.Text = "";
        }
        private void listBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            //progroupselectecd = (ProductGroup)listBox3.SelectedItem;
            //textBox34.Text = progroupselectecd.getID();
            //textBox33.Text = progroupselectecd.getName();
        }
        private void button8_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า แก้ไข
            //progroupselectecd.setName(textBox33.Text);
        }
        private void button7_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า   ลบ
            //progroupselectecd = null;
            //button6_Click(null, null);
        }
        private void button6_Click(object sender, EventArgs e)
        {   //กลุ่มลูกค้า ล้างข้อมูล
            //textBox34.Text = "";
            //textBox33.Text = "";
        }
        private void button24_Click(object sender, EventArgs e)
        {
            //foreach (ProductCategory gc in ProductCategory.search(textBox24.Text, comboBox4.SelectedIndex))
            //    listBox4.Items.Add(gc);
        }
        private void button23_Click(object sender, EventArgs e)
        {   //ประเภทสินค้า    ยกเลิก
            //textBox24.Text = "";
            //comboBox4.Text = "";
            //listBox4.Items.Clear();
        }
        private void button22_Click(object sender, EventArgs e)
        {   //ประเภทสินค้า เพิ่ม
            //procatselected = ProductCategory.addCategory(textBox23.Text, textBox22.Text);
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //procatselected = (ProductCategory)listBox4.SelectedItem;
            //textBox23.Text = procatselected.getID();
            //textBox22.Text = procatselected.getName();
        }
        private void button21_Click(object sender, EventArgs e)
        {   //ประเภทสินค้า แก้ไข
            //procatselected.setName(textBox22.Text);
        }
        private void button20_Click(object sender, EventArgs e)
        {   //ประเภทสินค้า ลบข้อมูล
            //procatselected.delete();
            //procatselected = null;
            //button19_Click(null, null);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            //textBox23.Text = "";
            //textBox22.Text = "";
        }

        private void OpenXlsImportOpenFileDialog(object sender, EventArgs e)
        {
            if (xlsImport_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Excel.Workbook
            }
            
        }

        private void addProductCat(object sender, EventArgs e)
        {
            var category = new ProductCategory
            {
                Code = productCatCode_txtBox.Text,
                Name = productCatName_txtBox.Text
            };
            using (var context = new StsContext())
            {
                context.ProductCategories.Add(category);
                context.SaveChanges();
                productCat_listBox.DataSource = context.ProductCategories.ToArray();
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
        }

        private void productCat_listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var category = (ProductCategory)productCat_listBox.SelectedItem;
            productCatCode_txtBox.Text = category.Code;
            productCatName_txtBox.Text = category.Name;
        }

        private void updateProductCat_btn_Click(object sender, EventArgs e)
        {
            var category = (ProductCategory)productCat_listBox.SelectedItem;
            using (var context = new StsContext())
            {
                var c = context.ProductCategories.Find(category.Id);
                c.Code = productCatCode_txtBox.Text;
                c.Name = productCatName_txtBox.Text;
                context.SaveChanges();
                productCat_listBox.DataSource = context.ProductCategories.ToArray();
            }
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
        }

        private void deleteProductCat_btn_Click(object sender, EventArgs e)
        {
            var category = (ProductCategory)productCat_listBox.SelectedItem;
            using (var context = new StsContext())
            {
                var c = context.ProductCategories.Find(category.Id);
                context.ProductCategories.Remove(c);
                context.SaveChanges();
                productCat_listBox.DataSource = context.ProductCategories.ToArray();
            }
        }

        private void productCatSearchCancel_btn_Click(object sender, EventArgs e)
        {
            productCatSearchKey_txtBox.Clear();
            using (var context = new StsContext())
            {
                productCat_listBox.DataSource = context.ProductCategories.ToArray();
            }
        }

        private void productCatSearchSubmit_btn_Click(object sender, EventArgs e)
        {
            var keyword = productCatSearchKey_txtBox.Text;
            var index = productCatSearchIndex_cmb.SelectedIndex;
            using (var context = new StsContext())
            {
                if (index == 0)
                {
                    var query = from c in context.ProductCategories
                                where c.Code.Contains(keyword) || c.Name.Contains(keyword)
                                select c;
                    productCat_listBox.DataSource = query.ToArray();
                }
                else if (index == 1)
                {
                    var query = from c in context.ProductCategories
                                where c.Code.Contains(keyword)
                                select c;
                    productCat_listBox.DataSource = query.ToArray();
                }
                else if (index == 2)
                {
                    var query = from c in context.ProductCategories
                                where c.Name.Contains(keyword)
                                select c;
                    productCat_listBox.DataSource = query.ToArray();
                }
            }
        }
    }
}