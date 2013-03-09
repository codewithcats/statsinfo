using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class DbConfigControl : UserControl
    {
        public DbConfigControl()
        {
            InitializeComponent();
            dnsText.Text = Config.SPSS_DNS;
            uidText.Text = Config.SPSS_UID;
            spssConnectLbl.Text = Config.SPSS_CONNECT;
        }
    }
}
