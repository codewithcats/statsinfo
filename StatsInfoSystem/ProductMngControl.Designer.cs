namespace StatsInfoSystem
{
    partial class ProductMngControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMngControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.product_listBox = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.category_cmb = new System.Windows.Forms.ComboBox();
            this.grp_cmb = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.code_txt = new System.Windows.Forms.TextBox();
            this.prict_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.description_txt = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.productImport_listBox = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.importFromXls_btn = new System.Windows.Forms.Button();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.xlsImport_btn = new System.Windows.Forms.Button();
            this.importFileName_txtBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 409);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.product_listBox);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "เพิ่มและปรับปรุงข้อมูลสินค้าทั้งหมด";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // product_listBox
            // 
            this.product_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.product_listBox.DisplayMember = "DisplayName";
            this.product_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_listBox.FormattingEnabled = true;
            this.product_listBox.Location = new System.Drawing.Point(6, 6);
            this.product_listBox.Name = "product_listBox";
            this.product_listBox.Size = new System.Drawing.Size(228, 368);
            this.product_listBox.TabIndex = 0;
            this.product_listBox.ValueMember = "Id";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.button13);
            this.groupBox7.Controls.Add(this.button12);
            this.groupBox7.Controls.Add(this.button11);
            this.groupBox7.Controls.Add(this.button10);
            this.groupBox7.Controls.Add(this.category_cmb);
            this.groupBox7.Controls.Add(this.grp_cmb);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.name_txt);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.code_txt);
            this.groupBox7.Controls.Add(this.prict_txt);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.description_txt);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(240, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(300, 368);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ข้อมูลทั่วไป";
            // 
            // button13
            // 
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(239, 263);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(54, 54);
            this.button13.TabIndex = 40;
            this.button13.Text = "ล้างข้อมูล";
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.Location = new System.Drawing.Point(179, 263);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(54, 54);
            this.button12.TabIndex = 39;
            this.button12.Text = "ลบข้อมูล";
            this.button12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.Location = new System.Drawing.Point(119, 263);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(54, 54);
            this.button11.TabIndex = 38;
            this.button11.Text = "แก้ไข";
            this.button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.Location = new System.Drawing.Point(59, 263);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(54, 54);
            this.button10.TabIndex = 37;
            this.button10.Text = "เพิ่ม";
            this.button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // category_cmb
            // 
            this.category_cmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_cmb.FormattingEnabled = true;
            this.category_cmb.Location = new System.Drawing.Point(110, 224);
            this.category_cmb.Name = "category_cmb";
            this.category_cmb.Size = new System.Drawing.Size(177, 21);
            this.category_cmb.TabIndex = 36;
            // 
            // grp_cmb
            // 
            this.grp_cmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_cmb.FormattingEnabled = true;
            this.grp_cmb.Location = new System.Drawing.Point(110, 197);
            this.grp_cmb.Name = "grp_cmb";
            this.grp_cmb.Size = new System.Drawing.Size(177, 21);
            this.grp_cmb.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 227);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "รหัสประเภทสินค้า";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(28, 200);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "รหัสกลุ่มสินค้า";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "รายละเอียดสินค้า";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "รหัสสินค้า";
            // 
            // name_txt
            // 
            this.name_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_txt.Location = new System.Drawing.Point(110, 45);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(183, 20);
            this.name_txt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ราคาขายสินค้า";
            // 
            // code_txt
            // 
            this.code_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_txt.Location = new System.Drawing.Point(110, 18);
            this.code_txt.Name = "code_txt";
            this.code_txt.Size = new System.Drawing.Size(183, 20);
            this.code_txt.TabIndex = 3;
            // 
            // prict_txt
            // 
            this.prict_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prict_txt.Location = new System.Drawing.Point(110, 71);
            this.prict_txt.Name = "prict_txt";
            this.prict_txt.Size = new System.Drawing.Size(183, 20);
            this.prict_txt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ชื่อสินค้า";
            // 
            // description_txt
            // 
            this.description_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_txt.Location = new System.Drawing.Point(110, 97);
            this.description_txt.Multiline = true;
            this.description_txt.Name = "description_txt";
            this.description_txt.Size = new System.Drawing.Size(183, 89);
            this.description_txt.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox11);
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(844, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "นำเข้าข้อมูลสินค้า";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.productImport_listBox);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(446, 17);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(392, 296);
            this.groupBox11.TabIndex = 2;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "จำนวนนำเข้าข้อมูลลูกค้า 0 รายการ";
            // 
            // productImport_listBox
            // 
            this.productImport_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productImport_listBox.FormattingEnabled = true;
            this.productImport_listBox.Location = new System.Drawing.Point(15, 25);
            this.productImport_listBox.Name = "productImport_listBox";
            this.productImport_listBox.Size = new System.Drawing.Size(369, 264);
            this.productImport_listBox.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button16);
            this.groupBox10.Controls.Add(this.importFromXls_btn);
            this.groupBox10.Controls.Add(this.textBox21);
            this.groupBox10.Controls.Add(this.label25);
            this.groupBox10.Controls.Add(this.textBox20);
            this.groupBox10.Controls.Add(this.label24);
            this.groupBox10.Controls.Add(this.textBox19);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.textBox18);
            this.groupBox10.Controls.Add(this.label22);
            this.groupBox10.Location = new System.Drawing.Point(17, 101);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(423, 174);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Image = ((System.Drawing.Image)(resources.GetObject("button16.Image")));
            this.button16.Location = new System.Drawing.Point(284, 95);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(105, 60);
            this.button16.TabIndex = 12;
            this.button16.Text = "ยกเลิก";
            this.button16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button16.UseVisualStyleBackColor = true;
            // 
            // importFromXls_btn
            // 
            this.importFromXls_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importFromXls_btn.Image = ((System.Drawing.Image)(resources.GetObject("importFromXls_btn.Image")));
            this.importFromXls_btn.Location = new System.Drawing.Point(284, 28);
            this.importFromXls_btn.Name = "importFromXls_btn";
            this.importFromXls_btn.Size = new System.Drawing.Size(105, 60);
            this.importFromXls_btn.TabIndex = 11;
            this.importFromXls_btn.Text = "นำเข้าข้อมูล";
            this.importFromXls_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.importFromXls_btn.UseVisualStyleBackColor = true;
            // 
            // textBox21
            // 
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(102, 124);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(137, 20);
            this.textBox21.TabIndex = 10;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(20, 127);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "วันที่นำเข้า :";
            // 
            // textBox20
            // 
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(102, 92);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(137, 20);
            this.textBox20.TabIndex = 8;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(20, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 7;
            this.label24.Text = "ขนาด :";
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(102, 60);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(137, 20);
            this.textBox19.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(20, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 5;
            this.label23.Text = "ชนิด :";
            // 
            // textBox18
            // 
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(102, 28);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(137, 20);
            this.textBox18.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "ชื่อไฟล์ :";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.xlsImport_btn);
            this.groupBox9.Controls.Add(this.importFileName_txtBox);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(17, 17);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(423, 78);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "รายการข้อมูล";
            // 
            // xlsImport_btn
            // 
            this.xlsImport_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xlsImport_btn.Location = new System.Drawing.Point(373, 28);
            this.xlsImport_btn.Name = "xlsImport_btn";
            this.xlsImport_btn.Size = new System.Drawing.Size(36, 31);
            this.xlsImport_btn.TabIndex = 2;
            this.xlsImport_btn.Text = "...";
            this.xlsImport_btn.UseVisualStyleBackColor = true;
            // 
            // importFileName_txtBox
            // 
            this.importFileName_txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importFileName_txtBox.Location = new System.Drawing.Point(102, 30);
            this.importFileName_txtBox.Name = "importFileName_txtBox";
            this.importFileName_txtBox.Size = new System.Drawing.Size(265, 20);
            this.importFileName_txtBox.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(20, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "เปิดข้อมูล :";
            // 
            // ProductMngControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ProductMngControl";
            this.Size = new System.Drawing.Size(556, 410);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox product_listBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox category_cmb;
        private System.Windows.Forms.ComboBox grp_cmb;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox code_txt;
        private System.Windows.Forms.TextBox prict_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox description_txt;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ListBox productImport_listBox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button importFromXls_btn;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button xlsImport_btn;
        private System.Windows.Forms.TextBox importFileName_txtBox;
        private System.Windows.Forms.Label label21;

    }
}
