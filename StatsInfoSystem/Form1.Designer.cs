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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.productMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ระบบเกบรวบรวมและปรบปรงขอมลToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
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
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(784, 537);
            this.mainPanel.TabIndex = 1;
            // 
            // productMenuItem
            // 
            this.productMenuItem.Name = "productMenuItem";
            this.productMenuItem.Size = new System.Drawing.Size(160, 22);
            this.productMenuItem.Text = "ข้อมูลสินค้า";
            this.productMenuItem.Click += new System.EventHandler(this.productMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
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





    }
}

