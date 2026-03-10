using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace DevPointageLite
{
    public partial class TrialMessageForm : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        static public int etat_expiration;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW; // Add drop shadow
                return cp;
            }
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        public TrialMessageForm(string message, string title)
        {

            InitializeComponent();
            lblMessage.Text = message; // Assuming you have a Label named lblMessage
            this.Text = title; // Set the form's title
            lblMessage.Left = (this.ClientSize.Width - lblMessage.Width) / 2;
            this.FormBorderStyle = FormBorderStyle.None; // No border
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            //this.Size = new Size(400, 300);
        }
        [STAThread]
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string url = "https://devcoredz.com/portfolio/"; // Replace with your desired URL
            if (etat_expiration == 1)
            {

                Form20 form20 = new Form20();
                form20.ShowDialog();
                return; // Exit the method if the form is shown
            }
            else
            {

                try
                {
                    // Use Process.Start to open the URL in the default web browser
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true // Important for opening the URL in the default browser
                    });
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("An error occurred while trying to open the link: " + ex.Message);
                }
            }
            this.Close();
        }

        private void TrialMessageForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private const string licenseRegistryPath = @"HKEY_CURRENT_USER\Software\DevPointageLiteLicense";
        private const string licenseKeyName = "LicenseKey";

        private void btnActivation_Click(object sender, EventArgs e)
        {
            string savedKey = Registry.GetValue(licenseRegistryPath, licenseKeyName, null)?.ToString();

            if (string.IsNullOrEmpty(savedKey) || !LicenseManager.IsLicenseValid(savedKey))
            {
                string enteredKey = PromptUserForKey();

                if (!LicenseManager.IsLicenseValid(enteredKey))
                {
                    MessageBox.Show("مفتاح التفعيل غير صحيح. سيتم إغلاق البرنامج.", "خطأ في التفعيل");
                    //this.Alert("مفتاح التفعيل غير صحيح. سيتم إغلاق البرنامج", Form_Alert.enmType.Error);

                    Environment.Exit(0);
                }
                MessageBox.Show("License key validated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Registry.SetValue(licenseRegistryPath, licenseKeyName, enteredKey);
                button2_Click(sender, e);
            }
        }
        private string PromptUserForKey()
        {
            using (LicenseForm form = new LicenseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.EnteredKey;
                }
                else
                {
                    Environment.Exit(0);
                    return null;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}