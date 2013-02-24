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
            this.customerMngControl1 = new StatsInfoSystem.CustomerMngControl();
            this.SuspendLayout();
            // 
            // customerMngControl1
            // 
            this.customerMngControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerMngControl1.Location = new System.Drawing.Point(0, 0);
            this.customerMngControl1.Name = "customerMngControl1";
            this.customerMngControl1.Size = new System.Drawing.Size(664, 533);
            this.customerMngControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 533);
            this.Controls.Add(this.customerMngControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomerMngControl customerMngControl1;




    }
}

