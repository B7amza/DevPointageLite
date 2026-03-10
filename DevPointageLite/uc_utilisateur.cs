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
using Microsoft.Data.Sqlite;  // ✅ استيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class uc_utilisateur : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_utilisateur()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        string matricule, nom_prenom, password, role;
        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            // ✅ إنشاء نموذج جديد بشكل صحيح (تجنب النمط الثابت)
            using (var frmUsers = new Form21())
            {
                Form21.insertion_modification = 0; // Insertion mode

                // إعداد واجهة النموذج
                frmUsers.txt_matricule.Enabled = true;
                frmUsers.txt_nom_prenom.Enabled = true;
                frmUsers.txt_password.Enabled = true;
                frmUsers.cb_role.Enabled = true;

                frmUsers.cb_role.SelectedIndex = -1; // Reset role selection    
                frmUsers.txt_nom_prenom.Clear();

                frmUsers.bt_ajouter.Enabled = false;
                frmUsers.bt_modifier.Enabled = false;
                frmUsers.bt_enregistrer.Enabled = true;
                frmUsers.bt_fermer.Enabled = true;
                frmUsers.bt_fermer.Text = "Fermer";
                frmUsers.Text = "Ajouter un Utilisateur";

                

                // ✅ عرض النموذج وتحديث البيانات بعد الإغلاق
                if (frmUsers.ShowDialog() == DialogResult.OK)
                {
                    load_users_data();
                }
            } // ✅ التصريف التلقائي للنموذج
            load_users_data(); // ✅ تحديث البيانات بعد التعديل
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner un Utilisateur à modifier.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ إنشاء نموذج جديد للتعديل
            using (var frmUsers = new Form21())
            {
                Form21.insertion_modification = 1; // Modification mode

                frmUsers.txt_matricule.Enabled = false;
                frmUsers.txt_nom_prenom.Enabled = true;
                frmUsers.txt_password.Enabled = true;
                frmUsers.cb_role.Enabled = true;

                // ✅ جلب بيانات الصف المحدد
                int[] selectedRows = gridView.GetSelectedRows();

                if (selectedRows != null && selectedRows.Length > 0 && selectedRows[0] >= 0)
                {
                    int rowHandle = selectedRows[0];

                    // ✅ جلب القيم مباشرة بدون DataRow
                    string matricule = gridView.GetRowCellValue(rowHandle, "Matricule")?.ToString() ?? "";
                    string nom_prenom = gridView.GetRowCellValue(rowHandle, "Nom")?.ToString() ?? "";
                    string role = gridView.GetRowCellValue(rowHandle, "Role")?.ToString() ?? "";
                    string password = gridView.GetRowCellValue(rowHandle, "Password")?.ToString() ?? "";

                    frmUsers.txt_matricule.Text = matricule;
                    frmUsers.txt_nom_prenom.Text = nom_prenom;
                    frmUsers.cb_role.SelectedItem = role; // Assuming cb_role is a ComboBox
                    frmUsers.txt_password.Text = password;



                   
                    
                }

                // إعداد الأزرار والعنوان
                frmUsers.bt_ajouter.Enabled = false;
                frmUsers.bt_modifier.Enabled = false;
                frmUsers.bt_enregistrer.Enabled = true;
                frmUsers.bt_fermer.Enabled = true;
                frmUsers.bt_fermer.Text = "Fermer";
                frmUsers.Text = "Modifier un Utilisateur";

                // ✅ عرض النموذج وتحديث البيانات
                if (frmUsers.ShowDialog() == DialogResult.OK)
                {
                    load_users_data();
                }

                load_users_data(); // ✅ تحديث البيانات بعد التعديل
            }
        }

        private void uc_utilisateur_Load(object sender, EventArgs e)
        {
            load_users_data();
        }
        private void load_users_data()
        {
            // ✅ تحميل البيانات باستخدام ConnectSqlite
            string query = "SELECT Matricule AS 'Matricule' ,Nom AS 'Nom',Role AS 'Role',Password AS 'Password' FROM UTILISATEUR ORDER BY matricule";
            DataTable dataTable = ConnectSqlite.ExecuteSelect(query);
            gridControl1.DataSource = dataTable;

            // ✅ تنسيق الشبكة إن لزم (DevExpress)
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.OptionsBehavior.Editable = false;
                gridView.BestFitColumns();
                gridView.OptionsView.ColumnAutoWidth=true;

                gridView1.Columns["Password"].Visible = false; // إخفاء عمود كلمة المرور
            }
        }
    }
}
