using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevPointageLite
{
    public partial class uc_principale : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_principale()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_datetime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
