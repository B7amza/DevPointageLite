using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DevPointageLite
{
    public partial class Form20 : DevExpress.XtraEditors.XtraForm
    {
        private const string licenseRegistryPath = @"HKEY_CURRENT_USER\Software\DevPointageLiteLicense";
        private const string licenseKeyName = "LicenseKey";
        public Form20()
        {
            InitializeComponent();

        }

        private void btnDActivation_Click(object sender, EventArgs e)
        {
            string HDID = LicenseManager.GetHardwareId();
            string subject = $"Activation de DevPointageLite : ";
            string body = $"Demande d'activation de DevPointageLite\n\n" +
                          $"ID Matériel : {HDID}\n" +
                          $"Nom arabe   : {nom_arab.Text.Trim()}\n" +
                          $"Email       : {email.Text.Trim()}";

            string fromEmail = "devcore.dz@gmail.com";
            string fromPassword = "syjvcbfvvqxxarmf"; // تأكد من أنه app password
            string toEmail = "b.7amza@gmail.com".Trim();

            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(fromEmail);
                message.To.Add(toEmail);
                message.Subject = subject;
                message.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);

                    try
                    {
                        smtp.Send(message);
                        this.Alert("تم إرسال الطلب بنجاح", Form_Alert.enmType.Success);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حدث خطأ أثناء الإرسال: " + ex.Message);
                    }
                }
            }
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            string savedKey = Registry.GetValue(licenseRegistryPath, licenseKeyName, null)?.ToString();

            if (!string.IsNullOrEmpty(savedKey) && LicenseManager.IsLicenseValid(savedKey))
            {
                // مفعل بنجاح، لا داعي للنسخة التجريبية
                btnDActivation.Visible = false;
                //return;
            }
            else
            {
                btnDActivation.Visible = true;
            }
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
    }
}