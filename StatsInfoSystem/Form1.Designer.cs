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
            this.ระบบสารสนเทศทางสถตToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.วเคราะหการขายToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predictSaleMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.วเคราะหลกคาToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerImportantMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerGroupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.สถตToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spssText_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeSeriesSimpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSaveSavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConfigMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.oLAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.c1OlapPrintDocument1 = new C1.Win.Olap.C1OlapPrintDocument();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem,
            this.ระบบสารสนเทศทางสถตToolStripMenuItem,
            this.สถตToolStripMenuItem,
            this.configToolStripMenuItem,
            this.oLAPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem
            // 
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ขอมลลกคาToolStripMenuItem,
            this.saleMenuItem,
            this.productMenuItem});
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Name = "ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem";
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem.Text = "ระบบเก็บรวบรวมและปรับปรุงข้อมูล";
            // 
            // ขอมลลกคาToolStripMenuItem
            // 
            this.ขอมลลกคาToolStripMenuItem.Name = "ขอมลลกคาToolStripMenuItem";
            this.ขอมลลกคาToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ขอมลลกคาToolStripMenuItem.Text = "ข้อมูลลูกค้า";
            this.ขอมลลกคาToolStripMenuItem.Click += new System.EventHandler(this.customerMenuItem_Click);
            // 
            // saleMenuItem
            // 
            this.saleMenuItem.Name = "saleMenuItem";
            this.saleMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saleMenuItem.Text = "ข้อมูลการขายสินค้า";
            this.saleMenuItem.Click += new System.EventHandler(this.saleMenuItem_Click);
            // 
            // productMenuItem
            // 
            this.productMenuItem.Name = "productMenuItem";
            this.productMenuItem.Size = new System.Drawing.Size(160, 22);
            this.productMenuItem.Text = "ข้อมูลสินค้า";
            this.productMenuItem.Click += new System.EventHandler(this.productMenuItem_Click);
            // 
            // ระบบสารสนเทศทางสถตToolStripMenuItem
            // 
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.วเคราะหการขายToolStripMenuItem,
            this.วเคราะหลกคาToolStripMenuItem});
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.Name = "ระบบสารสนเทศทางสถตToolStripMenuItem";
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.ระบบสารสนเทศทางสถตToolStripMenuItem.Text = "ระบบสารสนเทศทางสถิติ";
            // 
            // วเคราะหการขายToolStripMenuItem
            // 
            this.วเคราะหการขายToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.predictSaleMenu});
            this.วเคราะหการขายToolStripMenuItem.Name = "วเคราะหการขายToolStripMenuItem";
            this.วเคราะหการขายToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.วเคราะหการขายToolStripMenuItem.Text = "วิเคราะห์การขาย";
            // 
            // predictSaleMenu
            // 
            this.predictSaleMenu.Name = "predictSaleMenu";
            this.predictSaleMenu.Size = new System.Drawing.Size(178, 22);
            this.predictSaleMenu.Text = "พยากรณ์ยอดขายสินค้า";
            this.predictSaleMenu.Click += new System.EventHandler(this.predictSaleMenu_Click);
            // 
            // วเคราะหลกคาToolStripMenuItem
            // 
            this.วเคราะหลกคาToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerImportantMenuItem,
            this.customerGroupMenu});
            this.วเคราะหลกคาToolStripMenuItem.Name = "วเคราะหลกคาToolStripMenuItem";
            this.วเคราะหลกคาToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
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
            // สถตToolStripMenuItem
            // 
            this.สถตToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spssText_MenuItem,
            this.timeSeriesSimpleToolStripMenuItem,
            this.testSaveSavToolStripMenuItem});
            this.สถตToolStripMenuItem.Name = "สถตToolStripMenuItem";
            this.สถตToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.สถตToolStripMenuItem.Text = "สถิติ";
            // 
            // spssText_MenuItem
            // 
            this.spssText_MenuItem.Name = "spssText_MenuItem";
            this.spssText_MenuItem.Size = new System.Drawing.Size(179, 22);
            this.spssText_MenuItem.Text = "ทดสอบการติดต่อ SPSS";
            this.spssText_MenuItem.Click += new System.EventHandler(this.spssText_MenuItem_Click);
            // 
            // timeSeriesSimpleToolStripMenuItem
            // 
            this.timeSeriesSimpleToolStripMenuItem.Name = "timeSeriesSimpleToolStripMenuItem";
            this.timeSeriesSimpleToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.timeSeriesSimpleToolStripMenuItem.Text = "Time Series(Simple)";
            this.timeSeriesSimpleToolStripMenuItem.Click += new System.EventHandler(this.timeSeriesSimpleToolStripMenuItem_Click);
            // 
            // testSaveSavToolStripMenuItem
            // 
            this.testSaveSavToolStripMenuItem.Name = "testSaveSavToolStripMenuItem";
            this.testSaveSavToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.testSaveSavToolStripMenuItem.Text = "test save sav";
            this.testSaveSavToolStripMenuItem.Click += new System.EventHandler(this.testSaveSavToolStripMenuItem_Click);
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
            // oLAPToolStripMenuItem
            // 
            this.oLAPToolStripMenuItem.Name = "oLAPToolStripMenuItem";
            this.oLAPToolStripMenuItem.Size = new System.Drawing.Size(232, 20);
            this.oLAPToolStripMenuItem.Text = "ระบบสอบถามและแสดงสารสนเทศสำหรับผู้บริหาร";
            this.oLAPToolStripMenuItem.Click += new System.EventHandler(this.oLAPToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(824, 537);
            this.mainPanel.TabIndex = 1;
            // 
            // c1OlapPrintDocument1
            // 
            this.c1OlapPrintDocument1.DocumentName = "C1Olap Report";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 561);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ToolStripMenuItem สถตToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spssText_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeSeriesSimpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testSaveSavToolStripMenuItem;
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





    }
}

