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
        private const int trialDurationInMinutes = 80640; // Trial period is now 1 minute---20160=15jours
        private Timer trialTimer; // Declare timer as a class-level variable
        private bool hasExpiredMessageShown = false; // Flag to ensure expiration message is shown only once

        public Form1()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
            CheckLicenseAndTrial(); // Check license and trial status on startup
        }
        static public Form2 Form_principale;


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
                Registry.SetValue(registryKeyPath, firstLaunchKey, DateTime.Now.ToString());
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
                DateTime firstLaunchTime = DateTime.Parse(firstLaunch.ToString());
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




        static public string matricule, nom, fonction, manager, role, password;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_connexion_Click(object sender, EventArgs e)
        {
            // تحقق من صحة الإدخالات قبل محاولة الاتصال
            if (string.IsNullOrWhiteSpace(txt_user.Text) || string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                XtraMessageBox.Show("Veuillez entrer votre nom d'utilisateur et mot de passe.", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if nom d'utilisateur et mot de passe sont corrects
            if (txt_user.Text == matricule && txt_pass.Text == password)
                {
                    Form_principale = new Form2();
                    Form_principale.ShowDialog();
                    Form_principale.Dispose();
                }
                else
                {
                    XtraMessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            //if(DateTime.Now<new DateTime(2026, 6, 30))
            //{
            //    if (txt_user.Text == "admin" && txt_pass.Text == "admin")
            //    {
            //        Form_principale = new Form2();
            //        Form_principale.ShowDialog();
            //        Form_principale.Dispose();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("La période d'essai est expirée. Veuillez contacter le support pour obtenir une licence valide.", "Période d'essai expirée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_user_Leave(sender, e);
            }
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            load_user_details();
            
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_pass_Leave(sender, e);
            }
        }

        private void txt_pass_Leave(object sender, EventArgs e)
        {
            bt_connexion_Click(sender, e);
        }
        private void load_user_details()
        {
            // This method can be used to load user details from the database if needed
            string query = "SELECT matricule,nom,fonction,manager,role,password FROM utilisateur WHERE matricule = @matricule";

           DataTable dt = ConnectSqlite.ExecuteSelect(query, new SqliteParameter("@matricule", txt_user.Text));
            if (dt.Rows.Count > 0)
            {
                matricule = dt.Rows[0]["matricule"].ToString();
                nom = dt.Rows[0]["nom"].ToString();
                fonction = dt.Rows[0]["fonction"].ToString();
                manager = dt.Rows[0]["manager"].ToString();
                role = dt.Rows[0]["role"].ToString();
                password = dt.Rows[0]["password"].ToString();

                lb_nom_prenom.Text = nom;
                lb_nom_prenom.Visible = true;
                ActiveControl = txt_pass;
            }
            else
            {
                XtraMessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = txt_user;
            }

        }
    }
}