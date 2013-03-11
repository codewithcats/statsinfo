using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class OLAP : Form
    {
        public OLAP()
        {
            InitializeComponent();
        }

        private void OLAP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_StatsInfoSystem_StsContextDataSet.SaleAnalysisFact' table. You can move, or remove it, as needed.
            this.saleAnalysisFactTableAdapter.Fill(this._StatsInfoSystem_StsContextDataSet.SaleAnalysisFact);

        }
    }
}
