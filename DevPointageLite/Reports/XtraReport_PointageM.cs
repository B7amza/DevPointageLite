using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace DevPointageLite.Reports
{
    public partial class XtraReport_PointageM : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_PointageM()
        {
            InitializeComponent();
        }
        public string DernierTelechargement
        {
            get { return lb_dernier_tel.Text; }
            set { lb_dernier_tel.Text = value; }
        }
    }
}
