using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class Form10 : DevExpress.XtraEditors.XtraForm
    {
        public static int insertion_modification; // 0 for insertion, 1 for modification
        public static string var_affectation, var_fonction, var_horaireT;

        public Form10()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // ✅ تحميل ComboBoxes من قاعدة البيانات
            load_affectation_data();
            load_fonction_data();
            load_horaire_travail_data();

            // ✅ وضع التعديل: تعيين القيم المحددة مسبقاً
            if (insertion_modification == 1)
            {
                if (!string.IsNullOrEmpty(var_affectation))
                    cb_affectation.SelectedValue = var_affectation;

                if (!string.IsNullOrEmpty(var_fonction))
                    cb_fonction.SelectedValue = var_fonction;

                cb_horaire_travail.SelectedIndex = -1;
                groupControl3.Visible = false;
            }
        }

        // ✅ تحميل قائمة التعيينات (Affectation)
        private void load_affectation_data()
        {
            string query = "SELECT c_affect, lib_affect FROM AFFECTATION ORDER BY lib_affect";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_affectation.DisplayMember = "lib_affect";
                cb_affectation.ValueMember = "c_affect";
                cb_affectation.DataSource = dt;
                cb_affectation.SelectedIndex = -1; // لا تحديد افتراضي
            }
        }

        // ✅ تحميل قائمة الوظائف (Fonction)
        private void load_fonction_data()
        {
            string query = "SELECT c_fonct, lib_fonction FROM FONCTION ORDER BY lib_fonction";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_fonction.DisplayMember = "lib_fonction";
                cb_fonction.ValueMember = "c_fonct";
                cb_fonction.DataSource = dt;
                cb_fonction.SelectedIndex = -1;
            }
        }

        // ✅ تحميل قائمة جداول العمل (Horaire_Travail)
        private void load_horaire_travail_data()
        {
            string query = "SELECT code, designation FROM Horaire_Travail ORDER BY designation";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_horaire_travail.DisplayMember = "designation";
                cb_horaire_travail.ValueMember = "code";
                cb_horaire_travail.DataSource = dt;
                cb_horaire_travail.SelectedIndex = -1;
            }
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification = 0; // Insertion mode

            // ✅ توليد الماتريكول التلقائي باستخدام IFNULL لـ SQLite
            string query = "SELECT IFNULL(MAX(CAST(matricule AS INTEGER)), 0) + 1 AS next_mat FROM Personnel";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["next_mat"] != DBNull.Value)
            {
                int nextMat = Convert.ToInt32(dt.Rows[0]["next_mat"]);
                txt_matricule.Text = nextMat.ToString("D5"); // Format: 00001
            }
            else
            {
                txt_matricule.Text = "00001";
            }

            // ✅ تفعيل الحقول للإضافة
            etat_champs(0);
            txt_nom.Focus(); // التركيز على أول حقل إدخال
        }

        // ✅ دالة موحدة للتحكم في حالة الحقول والأزرار
        private void etat_champs(int etat)
        {
            bool editable = (etat == 0 || etat == 1); // Insertion or Modification

            // الحقول النصية
            txt_matricule.Enabled = (etat == 0); // فقط في الوضع الافتراضي
            txt_nom.Enabled = editable;
            txt_prenom.Enabled = editable;
            txt_adresse.Enabled = editable;
            txt_tel.Enabled = editable;

            // ComboBoxes
            cb_sexe.Enabled = editable;
            cb_type.Enabled = editable;
            cb_pointage.Enabled = editable;
            cb_fonction.Enabled = editable;
            cb_affectation.Enabled = editable;
            cb_horaire_travail.Enabled = editable;

            // الأزرار
            bt_ajouter.Enabled = (etat == 2); // فقط في الوضع الافتراضي
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = editable;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";

            // العناوين
            // ✅ متوافق مع C# 2.0 فأعلى:
            switch (etat)
            {
                case 0:
                    Text = "Insertion d'un nouvel employé";
                    break;
                case 1:
                    Text = "Modification de l'employé";
                    break;
                default:
                    Text = "Gestion des Employés";
                    break;
            }

            // إعادة تعيين التحديدات عند الوضع الافتراضي
            if (etat == 2)
            {
                cb_sexe.SelectedIndex = -1;
                cb_type.SelectedIndex = -1;
                cb_pointage.SelectedIndex = -1;
                cb_fonction.SelectedIndex = -1;
                cb_affectation.SelectedIndex = -1;
                cb_horaire_travail.SelectedIndex = -1;
            }
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_matricule.Text))
            {
                XtraMessageBox.Show("Veuillez sélectionner un employé à modifier.", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            insertion_modification = 1; // Modification mode
            etat_champs(1);
            txt_nom.Focus();
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // ✅ 1. التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txt_nom.Text) ||
                string.IsNullOrWhiteSpace(txt_prenom.Text) ||
                cb_fonction.SelectedValue == null ||
                cb_affectation.SelectedValue == null)
            {
                XtraMessageBox.Show("Veuillez remplir tous les champs obligatoires.",
                                  "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //تحقق من صحة رقم الهاتف (اختياري)
            if (!string.IsNullOrWhiteSpace(txt_tel.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txt_tel.Text, @"^\d{10}$"))
            {
                XtraMessageBox.Show("Veuillez entrer un numéro de téléphone valide (10 chiffres).",
                                  "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_tel.Focus();
                return;
            }

            // ✅ 2. تحضير المعاملات (Parameters)
            var parameters = new[]
            {
                new SqliteParameter("@matricule", txt_matricule.Text.Trim()),
                new SqliteParameter("@nom", txt_nom.Text.Trim()),
                new SqliteParameter("@prenom", txt_prenom.Text.Trim()),
                new SqliteParameter("@sexe", cb_sexe.Text.Trim()),
                new SqliteParameter("@adress", txt_adresse.Text.Trim()),
                new SqliteParameter("@tel", txt_tel.Text.Trim()),
                new SqliteParameter("@type_agent", cb_type.Text.Trim()),
                new SqliteParameter("@poinatge", cb_pointage.Text.Trim()),
                new SqliteParameter("@c_fonct", cb_fonction.SelectedValue),
                new SqliteParameter("@c_affect", cb_affectation.SelectedValue)
            };

            string query;
            if (insertion_modification == 0) // ➕ Insertion
            {
                // ✅ 2.1 التحقق من عدم تكرار الماتريكول
                string checkQuery = "SELECT COUNT(*) FROM Personnel WHERE matricule = @matricule";
                var checkParam = new SqliteParameter("@matricule", txt_matricule.Text.Trim());
                DataTable dtCheck = ConnectSqlite.ExecuteSelect(checkQuery, checkParam);

                if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                {
                    XtraMessageBox.Show("Le matricule existe déjà.", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_matricule.Focus();
                    return;
                }

                query = @"INSERT INTO Personnel 
                         (matricule, nom, prenom, sexe, adress, tel, id_fonction, id_affectation, type_agent, poinatge) 
                         VALUES (@matricule, @nom, @prenom, @sexe, @adress, @tel, @c_fonct, @c_affect, @type_agent, @poinatge)";
            }
            else // ✏️ Modification
            {
                query = @"UPDATE Personnel 
                         SET nom = @nom, prenom = @prenom, sexe = @sexe, adress = @adress, tel = @tel,
                             id_fonction = @c_fonct, id_affectation = @c_affect, 
                             type_agent = @type_agent, poinatge = @poinatge
                         WHERE matricule = @matricule";
            }

            // ✅ 3. تنفيذ استعلام Personnel
            int rowsAffected = ConnectSqlite.ExecuteNonQuery(query, parameters);

            // ✅ 4. إضافة/تحديث جدول PERSONNEL_EMPLOI_TEMPS (لحالة الإضافة فقط)
            if (insertion_modification == 0 && rowsAffected > 0 && cb_horaire_travail.SelectedValue != null)
            {
                string horaireQuery = @"INSERT INTO PERSONNEL_EMPLOI_TEMPS 
                                       (matri, code, date_du, date_au) 
                                       VALUES (@matri, @code_horaire, @date_du, @date_au)";

                DateTime lastDayOfYear = new DateTime(DateTime.Now.Year, 12, 31);
                var horaireParams = new[]
                {
                    new SqliteParameter("@matri", txt_matricule.Text.Trim()),
                    new SqliteParameter("@code_horaire", cb_horaire_travail.SelectedValue),
                    //new SqliteParameter("@date_du", DateTime.Now.Date),
                    new SqliteParameter("@date_du","2015-01-01 00:00:00"),
                    new SqliteParameter("@date_au", lastDayOfYear)
                };

                ConnectSqlite.ExecuteNonQuery(horaireQuery, horaireParams);
            }

            // ✅ 5. معالجة النتيجة
            if (rowsAffected > 0)
            {
                XtraMessageBox.Show("Enregistrement effectué avec succès.", "Succès",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // ✅ إشعار النموذج الأب
                etat_champs(2); // العودة للوضع الافتراضي
            }
            else
            {
                XtraMessageBox.Show("Échec de l'opération. Veuillez réessayer.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_affectation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // يمكن إضافة منطق هنا إذا لزم
        }
    }
}