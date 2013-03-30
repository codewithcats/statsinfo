namespace StatsInfoSystem
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ขอมลลกคาToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.factorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ระบบสารสนเทศทางสถตToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptiveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.วเคราะหการขายToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predictSaleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.regressionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.วเคราะหลกคาToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerImportantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerGroupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.oLAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.homeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConfigMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logounMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ผใชงานระบบในขณะนToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c1OlapPrintDocument1 = new C1.Win.Olap.C1OlapPrintDocument();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem,
            this.ระบบสารสนเทศทางสถตToolStripMenuItem,
            this.oLAPToolStripMenuItem,
            this.userMenu,
            this.homeMenu,
            this.configToolStripMenuItem,
            this.logounMenu,
            this.ผใชงานระบบในขณะนToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem
            // 
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ขอมลลกคาToolStripMenuItem,
            this.saleMenuItem,
            this.productMenuItem,
            this.factorMenu});
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Name = "ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem";
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Text = "ระบบเก็บรวบรวมและปรับปรุงข้อมูล";
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Click += new System.EventHandler(this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem_Click);
            // 
            // ขอมลลกคาToolStripMenuItem
            // 
            this.ขอมลลกคาToolStripMenuItem.Name = "ขอมลลกคาToolStripMenuItem";
            this.ขอมลลกคาToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ขอมลลกคาToolStripMenuItem.Text = "ข้อมูลลูกค้า";
            this.ขอมลลกคาToolStripMenuItem.Click += new System.EventHandler(this.customerMenuItem_Click);
            // 
            // saleMenuItem
            // 
            this.saleMenuItem.Name = "saleMenuItem";
            this.saleMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saleMenuItem.Text = "ข้อมูลการขายสินค้า";
            this.saleMenuItem.Click += new System.EventHandler(this.saleMenuItem_Click);
            // 
            // productMenuItem
            // 
            this.productMenuItem.Name = "productMenuItem";
            this.productMenuItem.Size = new System.Drawing.Size(163, 22);
            this.productMenuItem.Text = "ข้อมูลสินค้า";
            this.productMenuItem.Click += new System.EventHandler(this.productMenuItem_Click);
            // 
            // factorMenu
            // 
            this.factorMenu.Name = "factorMenu";
            this.factorMenu.Size = new System.Drawing.Size(163, 22);
            this.factorMenu.Text = "ข้อมูลปัจจัยภายนอก";
            this.factorMenu.Click += new System.EventHandler(this.factorMenu_Click);
            // 
            // ระบบสารสนเทศทางสถตToolStripMenuItem
            // 
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptiveMenu,
            this.วเคราะหการขายToolStripMenuItem,
            this.วเคราะหลกคาToolStripMenuItem});
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.Name = "ระบบสารสนเทศทางสถตToolStripMenuItem";
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.Text = "ระบบสารสนเทศทางสถิติ";
            // 
            // descriptiveMenu
            // 
            this.descriptiveMenu.Name = "descriptiveMenu";
            this.descriptiveMenu.Size = new System.Drawing.Size(171, 22);
            this.descriptiveMenu.Text = "วิเคราะห์ข้อมูลเบื้องต้น";
            this.descriptiveMenu.Click += new System.EventHandler(this.descriptiveMenu_Click);
            // 
            // วเคราะหการขายToolStripMenuItem
            // 
            this.วเคราะหการขายToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.predictSaleMenu,
            this.regressionMenu});
            this.วเคราะหการขายToolStripMenuItem.Name = "วเคราะหการขายToolStripMenuItem";
            this.วเคราะหการขายToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.วเคราะหการขายToolStripMenuItem.Text = "วิเคราะห์การขาย";
            // 
            // predictSaleMenu
            // 
            this.predictSaleMenu.Name = "predictSaleMenu";
            this.predictSaleMenu.Size = new System.Drawing.Size(181, 22);
            this.predictSaleMenu.Text = "พยากรณ์ยอดขายสินค้า";
            this.predictSaleMenu.Click += new System.EventHandler(this.predictSaleMenu_Click);
            // 
            // regressionMenu
            // 
            this.regressionMenu.Name = "regressionMenu";
            this.regressionMenu.Size = new System.Drawing.Size(181, 22);
            this.regressionMenu.Text = "ตัวแปรที่มีผลต่อยอดขาย";
            this.regressionMenu.Click += new System.EventHandler(this.regressionMenu_Click);
            // 
            // วเคราะหลกคาToolStripMenuItem
            // 
            this.วเคราะหลกคาToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerImportantMenuItem,
            this.customerGroupMenu});
            this.วเคราะหลกคาToolStripMenuItem.Name = "วเคราะหลกคาToolStripMenuItem";
            this.วเคราะหลกคาToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.วเคราะหลกคาToolStripMenuItem.Text = "วิเคราะห์ลูกค้า";
            // 
            // customerImportantMenuItem
            // 
            this.customerImportantMenuItem.Name = "customerImportantMenuItem";
            this.customerImportantMenuItem.Size = new System.Drawing.Size(189, 22);
            this.customerImportantMenuItem.Text = "จัดลำดับความสำคัญลูกค้า";
            this.customerImportantMenuItem.Click += new System.EventHandler(this.customerImportantMenuItem_Click);
            // 
            // customerGroupMenu
            // 
            this.customerGroupMenu.Name = "customerGroupMenu";
            this.customerGroupMenu.Size = new System.Drawing.Size(189, 22);
            this.customerGroupMenu.Text = "จัดกลุ่มลูกค้า";
            this.customerGroupMenu.Click += new System.EventHandler(this.customerGroupMenu_Click);
            // 
            // oLAPToolStripMenuItem
            // 
            this.oLAPToolStripMenuItem.Name = "oLAPToolStripMenuItem";
            this.oLAPToolStripMenuItem.Size = new System.Drawing.Size(232, 20);
            this.oLAPToolStripMenuItem.Text = "ระบบสอบถามและแสดงสารสนเทศสำหรับผู้บริหาร";
            this.oLAPToolStripMenuItem.Click += new System.EventHandler(this.oLAPToolStripMenuItem_Click);
            // 
            // userMenu
            // 
            this.userMenu.Name = "userMenu";
            this.userMenu.Size = new System.Drawing.Size(113, 20);
            this.userMenu.Text = "เกี่ยวกับผู้ใช้งานระบบ";
            this.userMenu.Click += new System.EventHandler(this.userMenu_Click);
            // 
            // homeMenu
            // 
            this.homeMenu.Name = "homeMenu";
            this.homeMenu.Size = new System.Drawing.Size(76, 20);
            this.homeMenu.Text = "กลับหน้าแรก";
            this.homeMenu.Click += new System.EventHandler(this.homeMenu_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbConfigMenu});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // dbConfigMenu
            // 
            this.dbConfigMenu.Name = "dbConfigMenu";
            this.dbConfigMenu.Size = new System.Drawing.Size(171, 22);
            this.dbConfigMenu.Text = "การเชื่อมต่อฐานข้อมูล";
            this.dbConfigMenu.Click += new System.EventHandler(this.dbConfigMenu_Click);
            // 
            // logounMenu
            // 
            this.logounMenu.Name = "logounMenu";
            this.logounMenu.Size = new System.Drawing.Size(79, 20);
            this.logounMenu.Text = "ออกจากระบบ";
            this.logounMenu.Click += new System.EventHandler(this.logounMenu_Click);
            // 
            // ผใชงานระบบในขณะนToolStripMenuItem
            // 
            this.ผใชงานระบบในขณะนToolStripMenuItem.Name = "ผใชงานระบบในขณะนToolStripMenuItem";
            this.ผใชงานระบบในขณะนToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.ผใชงานระบบในขณะนToolStripMenuItem.Text = "ผู้ใช้งานระบบในขณะนี้ :";
            // 
            // c1OlapPrintDocument1
            // 
            this.c1OlapPrintDocument1.DocumentName = "C1Olap Report";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackgroundImage = global::StatsInfoSystem.Properties.Resources.BG_PRO_2;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1028, 725);
            this.mainPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 749);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบบสารสนเทศทางสถิติเพื่อสนับสนุนงานขายและการจัดการลูกค้า";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ขอมลลกคาToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem productMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ระบบสารสนเทศทางสถตToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem วเคราะหการขายToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem predictSaleMenu;
        private System.Windows.Forms.ToolStripMenuItem วเคราะหลกคาToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerImportantMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbConfigMenu;
        private System.Windows.Forms.ToolStripMenuItem customerGroupMenu;
        private System.Windows.Forms.ToolStripMenuItem oLAPToolStripMenuItem;
        private C1.Win.Olap.C1OlapPrintDocument c1OlapPrintDocument1;
        private System.Windows.Forms.ToolStripMenuItem descriptiveMenu;
        private System.Windows.Forms.ToolStripMenuItem regressionMenu;
        private System.Windows.Forms.ToolStripMenuItem userMenu;
        private System.Windows.Forms.ToolStripMenuItem logounMenu;
        private System.Windows.Forms.ToolStripMenuItem homeMenu;
        private System.Windows.Forms.ToolStripMenuItem factorMenu;
        private System.Windows.Forms.ToolStripMenuItem ผใชงานระบบในขณะนToolStripMenuItem;





    }
}

