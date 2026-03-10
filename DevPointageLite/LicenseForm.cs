using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevPointageLite
{
    public partial class LicenseForm : DevExpress.XtraEditors.XtraForm
    {
        public string EnteredKey { get; private set; }
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            EnteredKey = txtKey.Text.Trim();
            this.DialogResult = DialogResult.OK;


            this.Close();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {

        }
    }
}