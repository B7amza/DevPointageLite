using DevExpress.XtraEditors;
using Microsoft.Data.Sqlite;
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
    public partial class Form21 : DevExpress.XtraEditors.XtraForm
    {
        public Form21()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }

        static public int insertion_modification;
        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification= 0; // وضع الإدراج
            // إعداد واجهة المستخدم
            txt_matricule.Enabled = true;
            txt_nom_prenom.Enabled = true;
            txt_password.Enabled = true;
            cb_role.Enabled = true;
            cb_role.SelectedIndex = -1; // إعادة تعيين اختيار الدور

            txt_matricule.Text = string.Empty;
            txt_nom_prenom.Text = string.Empty;
            txt_password.Text = string.Empty;


            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_matricule.Text))
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à modifier.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            insertion_modification = 1; // Modification mode

            txt_matricule.Enabled = false; // لا يمكن تعديل الكود
            txt_nom_prenom.Enabled = true;
            txt_password.Enabled = true;
            cb_role.Enabled = true;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Modifier un Utilisateur";

            txt_nom_prenom.Focus();
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // ✅ التحقق من صحة الإدخال
            if (string.IsNullOrWhiteSpace(txt_matricule.Text) ||
                string.IsNullOrWhiteSpace(txt_nom_prenom.Text) ||
                string.IsNullOrWhiteSpace(txt_password.Text) ||
                cb_role.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez remplir tous les champs et sélectionner un rôle.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ✅ تنفيذ عملية الإدراج أو التعديل بناءً على الوضع الحالي
            if (insertion_modification == 0)
            {
                // عملية الإدراج
                string insertQuery = "INSERT INTO UTILISATEUR (matricule, nom, password, role,fonction,manager) " +
                                     "VALUES (@matricule, @nom_prenom, @password, @role,'RAS','O')";
                var parameters = new SqliteParameter[]
                {
                        new SqliteParameter("@matricule", txt_matricule.Text),
                        new SqliteParameter("@nom_prenom", txt_nom_prenom.Text),
                        new SqliteParameter("@password", txt_password.Text),
                        new SqliteParameter("@role", cb_role.SelectedItem.ToString())
                    
                };
                ConnectSqlite.ExecuteNonQuery(insertQuery, parameters);
                MessageBox.Show("Utilisateur ajouté avec succès.", "Succès",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (insertion_modification == 1)
            {
                // عملية التعديل
                string updateQuery = "UPDATE UTILISATEUR SET nom = @nom_prenom, " +
                                      "password = @password, role = @role WHERE matricule = @matricule";
                var parameters = new SqliteParameter[]
                {
                        new SqliteParameter("@matricule", txt_matricule.Text),
                        new SqliteParameter("@nom_prenom", txt_nom_prenom.Text),
                        new SqliteParameter("@password", txt_password.Text),
                        new SqliteParameter("@role", cb_role.SelectedItem.ToString())

                    
                };
                ConnectSqlite.ExecuteNonQuery(updateQuery, parameters);
                MessageBox.Show("Utilisateur modifié avec succès.", "Succès",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();



        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            if (insertion_modification == 0)
            {
                // إعدادات لعملية الإدراج
                this.Text = "Ajouter un Utilisateur";
                // يمكنك تهيئة الحقول هنا إذا لزم الأمر
            }
            else if (insertion_modification == 1)
            {
                // إعدادات لعملية التعديل
                this.Text = "Modifier un Utilisateur";
                // يمكنك تحميل بيانات الموظف الحالي إلى الحقول هنا
            }
        }
    }
}