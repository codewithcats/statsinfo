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
            this.form_Product1 = new StatsInfoSystem.Form_Product();
            this.SuspendLayout();
            // 
            // form_Product1
            // 
            this.form_Product1.Location = new System.Drawing.Point(0, 0);
            this.form_Product1.Name = "form_Product1";
            this.form_Product1.Size = new System.Drawing.Size(1428, 871);
            this.form_Product1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 705);
            this.Controls.Add(this.form_Product1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private StatsInfoSystem.Form_Product form_Product1;
    }
}

