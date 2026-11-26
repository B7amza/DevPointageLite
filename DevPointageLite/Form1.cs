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
using System.Globalization;
using Microsoft.Data.Sqlite;
using Microsoft.Win32; // For accessing the registry

namespace DevPointageLite
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private const string licenseRegistryPath = @"HKEY_CURRENT_USER\Software\DevPointageLiteLicense";
        private const string licenseKeyName = "LicenseKey";



        // Define the registry key where the trial data will be stored
        private const string registryKeyPath = @"HKEY_CURRENT_USER\Software\DevPointageLiteTrial";
        private const string firstLaunchKey = "FirstLaunchTime";
        private const int trialDurationInMinutes = 15 * 24 * 60;//يوم*ساعة*دقيقة // Trial period is now 15 days
        private Timer trialTimer; // Declare timer as a class-level variable
        private bool hasExpiredMessageShown = false; // Flag to ensure expiration message is shown only once

        public Form1()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
            CheckLicenseAndTrial(); // Check license and trial status on startup
        }
        static public Form2 Form_principale;
        static public RibbonForm1 fn_ribbonform1;

        //private void pass_new_ribbon()
        //{
        //    RibbonForm1 fn_ribbonform1 = new RibbonForm1();
        //    fn_ribbonform1.ShowDialog();
        //    fn_ribbonform1.Dispose();
        //}
        // ---- النقطة 3 ----
        private void pass_new_ribbon()
        {
            fn_ribbonform1 = new RibbonForm1(); // on utilise le champ statique
            try
            {
                fn_ribbonform1.ShowDialog(this);
            }
            finally
            {
                fn_ribbonform1.Dispose();
                fn_ribbonform1 = null;
            }
        }
        private void CheckLicenseAndTrial()
        {
            string savedKey = Registry.GetValue(licenseRegistryPath, licenseKeyName, null)?.ToString();

            if (!string.IsNullOrEmpty(savedKey) && LicenseManager.IsLicenseValid(savedKey))
            {
                // مفعل بنجاح، لا داعي للنسخة التجريبية

                return;
            }

            // لم يتم التفعيل، نبدأ النسخة التجريبية
            CheckTrialStatus();
        }

        private void CheckTrialStatus()
        {
            // Check if the first launch time exists in the registry
            object firstLaunch = Registry.GetValue(registryKeyPath, firstLaunchKey, null);

            if (firstLaunch == null) // This means it's the first time the app is being launched
            {
                // Store the current date and time as the first launch time
                Registry.SetValue(registryKeyPath, firstLaunchKey, DateTime.Now.ToString("o", CultureInfo.InvariantCulture));
                //MessageBox.Show("Welcome to the trial version! You have 1 minute of usage.", "Trial Started");
                using (TrialMessageForm msgBox = new TrialMessageForm("مرحبا في النسخة التجريبية مدتها 15 يوم ...", "مرحبا"))
                {
                    msgBox.ShowDialog(this); // Show the custom message box
                }
                StartTrialTimer(DateTime.Now); // Start timer immediately on first launch
            }
            else
            {
                // Parse the stored launch time
                string stored = firstLaunch.ToString();
                DateTime firstLaunchTime = ParseFirstLaunch(stored);

                // ✅ ترحيل القيمة القديمة (صيغة محلية) إلى الصيغة الثابتة
                string iso = firstLaunchTime.ToString("o", CultureInfo.InvariantCulture);
                if (stored != iso) Registry.SetValue(registryKeyPath, firstLaunchKey, iso);

                TimeSpan timeElapsed = DateTime.Now - firstLaunchTime;

                // Check if the trial period has expired
                if (timeElapsed.TotalMinutes > trialDurationInMinutes)
                {
                    ShowExpirationMessage();
                }
                else
                {
                    StartTrialTimer(firstLaunchTime); // Start timer for ongoing use
                }
            }
        }

        // ✅ قراءة تاريخ أول تشغيل بشكل لا يتأثر بالإعدادات الإقليمية لـ Windows
        private static DateTime ParseFirstLaunch(string s)
        {
            DateTime dt;

            // الصيغة الجديدة الثابتة
            if (DateTime.TryParseExact(s, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt))
                return dt;

            // قيم قديمة بصيغة محلية: نجرب الثقافة الحالية أولاً (كما كان سابقاً) ثم بدائل شائعة،
            // و نرفض أي تاريخ في المستقبل (أول تشغيل لا يمكن أن يكون بعد اليوم)
            CultureInfo[] cultures =
            {
                CultureInfo.CurrentCulture,
                new CultureInfo("fr-FR"),
                new CultureInfo("en-US"),
                CultureInfo.InvariantCulture
            };
            foreach (CultureInfo c in cultures)
            {
                if (DateTime.TryParse(s, c, DateTimeStyles.None, out dt) && dt <= DateTime.Now.AddDays(1))
                    return dt;
            }

            // غير قابل للقراءة (تالف): نعتبر التجربة منتهية بدل أن يتعطل البرنامج عند الإقلاع
            return DateTime.MinValue;
        }

        private void StartTrialTimer(DateTime firstLaunchTime)
        {
            // Create a timer to run every second (1000 milliseconds)
            trialTimer = new Timer();
            trialTimer.Interval = 1000; // 1 second interval

            // Event handler for each tick of the timer
            trialTimer.Tick += (s, args) =>
            {
                // Calculate how much time has passed since the first launch
                TimeSpan timeElapsed = DateTime.Now - firstLaunchTime;

                // Check if the trial period has expired
                if (timeElapsed.TotalMinutes > trialDurationInMinutes && !hasExpiredMessageShown)
                {
                    ShowExpirationMessage();
                }
            };

            trialTimer.Start(); // Start the timer
        }

        private void ShowExpirationMessage()
        {
            if (!hasExpiredMessageShown) // Ensure the message is shown only once
            {
                hasExpiredMessageShown = true; // Set the flag to true before showing the message
                using (TrialMessageForm msgBox = new TrialMessageForm("للأسف انتهت مدة النسخة التجريبية", "انتهاء النسخة"))
                {
                    TrialMessageForm.etat_expiration = 1; // Set the expiration state
                    msgBox.ShowDialog(this); // Show the custom message box
                }

                Registry.SetValue(registryKeyPath, firstLaunchKey, DateTime.MinValue.ToString()); // Mark as expired
                Environment.Exit(0); // Close the app
            }
        }




        //static public string matricule, nom, fonction, manager, role, password;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static public string matricule, nom, fonction, manager, role, password;

        private void ResetUserDetails()
        {
            matricule = nom = fonction = manager = role = password = null;
            lb_nom_prenom.Text = string.Empty;
            lb_nom_prenom.Visible = false;
        }

        private bool load_user_details()
        {
            ResetUserDetails();

            string query = "SELECT matricule, nom, fonction, manager, role, password " +
                           "FROM utilisateur WHERE matricule = @matricule";

            DataTable dt = ConnectSqlite.ExecuteSelect(
                query, new SqliteParameter("@matricule", txt_user.Text.Trim()));

            if (dt == null || dt.Rows.Count == 0)
                return false;

            DataRow r = dt.Rows[0];
            matricule = Convert.ToString(r["matricule"]);
            nom = Convert.ToString(r["nom"]);
            fonction = Convert.ToString(r["fonction"]);
            manager = Convert.ToString(r["manager"]);
            role = Convert.ToString(r["role"]);
            password = Convert.ToString(r["password"]);

            lb_nom_prenom.Text = nom;
            lb_nom_prenom.Visible = true;
            return true;
        }

        private void bt_connexion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_user.Text) || string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                XtraMessageBox.Show("Veuillez entrer votre nom d'utilisateur et mot de passe.",
                    "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!load_user_details() || txt_pass.Text != password)
            {
                ResetUserDetails();
                XtraMessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.",
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_pass.Clear();
                ActiveControl = txt_user;
                return;
            }

            txt_pass.Clear();
            pass_new_ribbon();
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ActiveControl = txt_pass;
            }
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                bt_connexion_Click(sender, EventArgs.Empty);
            }
        }
       








    }
}