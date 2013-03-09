using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsInfoSystem
{
    public class Config
    {
        public static string SPSS_DNS = "sql_server";
        public static string SPSS_UID = "LAMBKIN";
        public static string SPSS_CONNECT
        {
            get { return String.Format("'DSN={0};UID={1};APP=SPSS For Windows;WSID={1};DATABASE=StatsInfoSystem.StsContext;' 'Trusted_Connection=Yes'", SPSS_DNS, SPSS_UID); }
        }
    }
}
