using DevExpress.XtraBars;
using Microsoft.Win32;
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
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {


    private const string licenseRegistryPath = @"HKEY_CURRENT_USER\Software\DevPointageLiteLicense";
    private const string licenseKeyName = "LicenseKey";


    static public string annee_en_cours;
    static public int plage_hrs = 5;
    static public int plage_retards = 15;
    static public int nbr_machine = 8;

    public RibbonForm1()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
            LoadPrincipaleUC();
        }

        static public Form4 fn_telechargement;
        static public Form10 fn_personnel;
        static public Form11 fn_affectation;
        static public Form12 fn_fonction;
        static public Form14 fn_pointage_mensuelle;
        static public Form15 fn_gestion_absence;
        static public Form16 fn_gerer_pointeuse;
        static public Form17 fn_pointage_journalier;
        static public Form20 fn_activation;
        static public Form22 fn_import_donnee;
        static public Form23 fn_temps_employee;
        static public Form24 fn_horairetravail;
        static public Form_imprission fn_imprission;


        uc_principale uc_principale1 = new uc_principale();
        uc_employe uc_employe1 = new uc_employe();
        uc_fonction uc_fonction1 = new uc_fonction();
        uc_structure uc_structure1 = new uc_structure();
        uc_typeconge uc_typeconge1 = new uc_typeconge();
        uc_utilisateur uc_utilisateur1 = new uc_utilisateur();
        uc_horairetravail uc_horairetravail1 = new uc_horairetravail();


        private void LoadUC(DevExpress.XtraEditors.XtraUserControl Page_UControle)
        {
            try
            {
                pn_continer.Controls.Clear();
                Page_UControle.Dock = DockStyle.Fill;
                pn_continer.Controls.Add(Page_UControle);

            }
            catch
            {

            }
        }
        private void bt_principale_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_principale1);
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            annee_en_cours = DateTime.Now.Year.ToString();

            // Initialize the user controls or perform any setup needed on form load
            LoadPrincipaleUC();

            if (Form1.role != "Administrateur")
            {
                //bt_gererUtilisateur.Enabled = false;
                //lbActive.Enabled = false;
                //lbDActivation.Enabled = false;
                //bt_impData.Enabled = false;
                //bt_HoraireTravail.Enabled = false;
            }
        }
        private void LoadPrincipaleUC()
        {

            LoadUC(uc_principale1);

        }

        private void bt_employe_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_employe1);
        }

        private void bt_stucture_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_structure1);
        }

        private void bt_HoraireTravail_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_horairetravail1);
        }

        private void bt_fonction_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_fonction1);
        }

        private void bt_typeconge_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_typeconge1);
        }

        private void bt_TempsEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_temps_employee = new Form23();
            fn_temps_employee.ShowDialog();
            fn_temps_employee.Dispose();
        }

        private void bt_gererPointeuse_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_gerer_pointeuse = new Form16();
            fn_gerer_pointeuse.ShowDialog();
            fn_gerer_pointeuse.Dispose();
        }

        private void bt_gererUtilisateur_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadUC(uc_utilisateur1);

        }

        private void bt_impData_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_import_donnee = new Form22();
            fn_import_donnee.ShowDialog();
            fn_import_donnee.Dispose();
        }

        private void bt_PointageJR_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_pointage_journalier = new Form17();
            fn_pointage_journalier.ShowDialog();
            fn_pointage_journalier.Dispose();
        }

        private void bt_pointageM_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_pointage_mensuelle = new Form14();
            fn_pointage_mensuelle.ShowDialog();
            fn_pointage_mensuelle.Dispose();
        }

        private void bt_absence_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_gestion_absence = new Form15();
            fn_gestion_absence.ShowDialog();
            fn_gestion_absence.Dispose();
        }

        private void bt_Telecharger_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_telechargement = new Form4();
            fn_telechargement.ShowDialog();
            fn_telechargement.Dispose();
        }

        private void lbActive_ItemClick(object sender, ItemClickEventArgs e)
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
                Application.Restart(); // Restart the application to apply the license key
                                       // button2_Click(sender, e);
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

        private void lbDActivation_ItemClick(object sender, ItemClickEventArgs e)
        {
            fn_activation = new Form20();
            fn_activation.ShowDialog();
            fn_activation.Dispose();
        }

        private void RibbonForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RibbonForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}