namespace StatsInfoSystem
{
    partial class OLAP
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
            this.components = new System.ComponentModel.Container();
            this.c1OlapPage1 = new C1.Win.Olap.C1OlapPage();
            this._StatsInfoSystem_StsContextDataSet = new StatsInfoSystem._StatsInfoSystem_StsContextDataSet();
            this.saleAnalysisFactBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleAnalysisFactTableAdapter = new StatsInfoSystem._StatsInfoSystem_StsContextDataSetTableAdapters.SaleAnalysisFactTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.c1OlapPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatsInfoSystem_StsContextDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleAnalysisFactBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // c1OlapPage1
            // 
            this.c1OlapPage1.DataSource = this.saleAnalysisFactBindingSource;
            this.c1OlapPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1OlapPage1.Location = new System.Drawing.Point(0, 0);
            this.c1OlapPage1.Margin = new System.Windows.Forms.Padding(2);
            this.c1OlapPage1.Name = "c1OlapPage1";
            this.c1OlapPage1.Size = new System.Drawing.Size(573, 427);
            this.c1OlapPage1.TabIndex = 0;
            // 
            // _StatsInfoSystem_StsContextDataSet
            // 
            this._StatsInfoSystem_StsContextDataSet.DataSetName = "_StatsInfoSystem_StsContextDataSet";
            this._StatsInfoSystem_StsContextDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saleAnalysisFactBindingSource
            // 
            this.saleAnalysisFactBindingSource.DataMember = "SaleAnalysisFact";
            this.saleAnalysisFactBindingSource.DataSource = this._StatsInfoSystem_StsContextDataSet;
            // 
            // saleAnalysisFactTableAdapter
            // 
            this.saleAnalysisFactTableAdapter.ClearBeforeFill = true;
            // 
            // OLAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 427);
            this.Controls.Add(this.c1OlapPage1);
            this.Name = "OLAP";
            this.Text = "OLAP";
            this.Load += new System.EventHandler(this.OLAP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1OlapPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._StatsInfoSystem_StsContextDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleAnalysisFactBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.Olap.C1OlapPage c1OlapPage1;
        private _StatsInfoSystem_StsContextDataSet _StatsInfoSystem_StsContextDataSet;
        private System.Windows.Forms.BindingSource saleAnalysisFactBindingSource;
        private _StatsInfoSystem_StsContextDataSetTableAdapters.SaleAnalysisFactTableAdapter saleAnalysisFactTableAdapter;
    }
}