namespace StatsInfoSystem
{
    partial class OlapControl
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
            this.c1OlapPage1 = new C1.Win.Olap.C1OlapPage();
            ((System.ComponentModel.ISupportInitialize)(this.c1OlapPage1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1OlapPage1
            // 
            this.c1OlapPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1OlapPage1.Location = new System.Drawing.Point(0, 0);
            this.c1OlapPage1.Margin = new System.Windows.Forms.Padding(2);
            this.c1OlapPage1.Name = "c1OlapPage1";
            this.c1OlapPage1.Size = new System.Drawing.Size(482, 377);
            this.c1OlapPage1.TabIndex = 0;
            // 
            // OlapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c1OlapPage1);
            this.Name = "OlapControl";
            this.Size = new System.Drawing.Size(482, 377);
            ((System.ComponentModel.ISupportInitialize)(this.c1OlapPage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.Olap.C1OlapPage c1OlapPage1;
    }
}
