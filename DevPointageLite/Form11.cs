using DevExpress.XtraEditors;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevPointageLite
{
    public partial class Form11 : DevExpress.XtraEditors.XtraForm
    {
        public Form11()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }
        static public int insertion_modification; // 0: Insertion, 1: Modification

        private void Form11_Load(object sender, EventArgs e)
        {
            if (insertion_modification == 0)
            {
                // إعدادات لعملية الإدراج
                this.Text = "Ajouter une Affectation";
                // يمكنك تهيئة الحقول هنا إذا لزم الأمر
            }
            else if (insertion_modification == 1)
            {
                // إعدادات لعملية التعديل
                this.Text = "Modifier une Affectation";
                // يمكنك تحميل بيانات الموظف الحالي إلى الحقول هنا
            }
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification = 0; // Insertion mode

            // إعداد واجهة المستخدم
            txt_c_affectation.Enabled = false;
            txt_lib_affectation.Enabled = true;
            txt_lib_affectation.Text = string.Empty;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Ajouter une affectation";

            // ✅ توليد الكود التلقائي باستخدام كلاس ConnectSqlite
            string query = "SELECT IFNULL(MAX(c_affect), '00') AS c_affect FROM AFFECTATION";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["c_affect"] != DBNull.Value)
            {
                string maxCode = dt.Rows[0]["c_affect"].ToString();
                int nextCode = Convert.ToInt32(maxCode) + 1;
                txt_c_affectation.Text = nextCode.ToString("D2");
            }
            else
            {
                txt_c_affectation.Text = "01";
            }
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_c_affectation.Text))
            {
                MessageBox.Show("Veuillez sélectionner une affectation à modifier.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            insertion_modification = 1; // Modification mode

            txt_c_affectation.Enabled = false; // لا يمكن تعديل الكود
            txt_lib_affectation.Enabled = true;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Modifier une affectation";

            txt_lib_affectation.Focus();
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // ✅ التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txt_lib_affectation.Text))
            {
                MessageBox.Show("Veuillez saisir la désignation de l'affectation.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_lib_affectation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_c_affectation.Text))
            {
                MessageBox.Show("Veuillez saisir le code de l'affectation.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_c_affectation.Focus();
                return;
            }

            // ✅ التحقق من وجود الكود مسبقاً (لحالة الإضافة فقط)
            if (insertion_modification == 0) // Insertion
            {
                string checkQuery = "SELECT COUNT(*) FROM AFFECTATION WHERE c_affect = @c_affect";
                var checkParam = new SqliteParameter("@c_affect", txt_c_affectation.Text.Trim());

                DataTable dtCheck = ConnectSqlite.ExecuteSelect(checkQuery, checkParam);

                if (dtCheck.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dtCheck.Rows[0][0]);
                    if (count > 0)
                    {
                        MessageBox.Show("Le code d'affectation existe déjà.", "Erreur",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_c_affectation.Focus();
                        return;
                    }
                }
            }

            // ✅ تنفيذ الإدخال أو التعديل
            string query;
            if (insertion_modification == 0) // Insertion
            {
                query = "INSERT INTO AFFECTATION (c_affect, lib_affect) VALUES (@c_affect, @lib_affect)";
            }
            else // Modification
            {
                query = "UPDATE AFFECTATION SET lib_affect = @lib_affect WHERE c_affect = @c_affect";
            }

            var parameters = new[]
            {
        new SqliteParameter("@c_affect", txt_c_affectation.Text.Trim()),
        new SqliteParameter("@lib_affect", txt_lib_affectation.Text.Trim())
    };

            int rowsAffected = ConnectSqlite.ExecuteNonQuery(query, parameters);

            // ✅ عرض رسالة النجاح
            if (rowsAffected > 0)
            {
                if (insertion_modification == 0)
                {
                    MessageBox.Show("Affectation ajoutée avec succès.", "Information",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Affectation modifiée avec succès.", "Information",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // ✅ إعادة تعيين النموذج
                ResetForm();
            }
            else
            {
                MessageBox.Show("Échec de l'opération. Veuillez réessayer.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ✅ أضف هذه الدالة لتجنب تكرار الكود
        private void ResetForm()
        {
            txt_lib_affectation.Clear();
            txt_c_affectation.Clear();

            txt_c_affectation.Enabled = false;
            txt_lib_affectation.Enabled = true;

            bt_ajouter.Enabled = true;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = false;
            bt_fermer.Enabled = true;

            bt_fermer.Text = "Fermer";
            Text = "Gestion des Affectations"; // أو العنوان الافتراضي
        }
    }
}