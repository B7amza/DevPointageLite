using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class Form12 : DevExpress.XtraEditors.XtraForm
    {
        public static int insertion_modification; // 0 pour insertion, 1 pour modification

        public Form12()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // ✅ التركيز على حقل الإدخال عند التحميل
            txt_lib_fonction.Focus();
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            this.Close(); // ✅ إغلاق النموذج
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification = 0; // Insertion mode

            // ✅ إعداد واجهة النموذج
            txt_c_fonction.Enabled = false;
            txt_lib_fonction.Enabled = true;
            txt_c_fonction.Clear();
            txt_lib_fonction.Clear();

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Ajouter une fonction";

            // ✅ توليد الكود التلقائي باستخدام ConnectSqlite و IFNULL لـ SQLite
            string query = "SELECT IFNULL(MAX(c_fonct), '00') AS c_fonct FROM FONCTION";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["c_fonct"] != DBNull.Value)
            {
                string maxCode = dt.Rows[0]["c_fonct"].ToString();
                if (int.TryParse(maxCode, out int codeValue))
                {
                    int nextCode = codeValue + 1;
                    txt_c_fonction.Text = nextCode.ToString("D2");
                }
                else
                {
                    txt_c_fonction.Text = "01";
                }
            }
            else
            {
                txt_c_fonction.Text = "01";
            }

            txt_lib_fonction.Focus();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            // ✅ التحقق من وجود كود قبل التعديل
            if (string.IsNullOrWhiteSpace(txt_c_fonction.Text))
            {
                XtraMessageBox.Show("Veuillez saisir le code de la fonction.", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            insertion_modification = 1; // Modification mode

            // ✅ إعداد واجهة النموذج
            txt_c_fonction.Enabled = false;
            txt_lib_fonction.Enabled = true;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Modifier une fonction";

            txt_lib_fonction.Focus();
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // ✅ 1. التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txt_lib_fonction.Text))
            {
                XtraMessageBox.Show("Veuillez saisir le libellé de la fonction.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_lib_fonction.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_c_fonction.Text))
            {
                XtraMessageBox.Show("Veuillez saisir le code de la fonction.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_c_fonction.Focus();
                return;
            }

            // ✅ 2. التحقق من تكرار الكود (لحالة الإضافة فقط)
            if (insertion_modification == 0)
            {
                string checkQuery = "SELECT COUNT(*) FROM FONCTION WHERE c_fonct = @c_fonct";
                var checkParam = new SqliteParameter("@c_fonct", txt_c_fonction.Text.Trim());
                DataTable dtCheck = ConnectSqlite.ExecuteSelect(checkQuery, checkParam);

                if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                {
                    XtraMessageBox.Show("Le code de la fonction existe déjà.", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_c_fonction.Focus();
                    return;
                }
            }

            // ✅ 3. تحضير الاستعلام والمعاملات
            string query;
            if (insertion_modification == 0) // Insertion
            {
                query = "INSERT INTO FONCTION (c_fonct, lib_fonction) VALUES (@c_fonct, @lib_fonction)";
            }
            else // Modification
            {
                query = "UPDATE FONCTION SET lib_fonction = @lib_fonction WHERE c_fonct = @c_fonct";
            }

            var parameters = new[]
            {
                new SqliteParameter("@c_fonct", txt_c_fonction.Text.Trim()),
                new SqliteParameter("@lib_fonction", txt_lib_fonction.Text.Trim())
            };

            // ✅ 4. تنفيذ الاستعلام عبر ConnectSqlite
            int rowsAffected = ConnectSqlite.ExecuteNonQuery(query, parameters);

            // ✅ 5. معالجة النتيجة
            if (rowsAffected > 0)
            {
                string msg = (insertion_modification == 0)
                    ? "Fonction ajoutée avec succès."
                    : "Fonction modifiée avec succès.";

                XtraMessageBox.Show(msg, "Succès",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ إعادة تعيين النموذج
                ResetForm();
            }
            else
            {
                XtraMessageBox.Show("Échec de l'opération. Veuillez réessayer.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ دالة مساعدة لإعادة تعيين النموذج (تجنب تكرار الكود)
        private void ResetForm()
        {
            txt_c_fonction.Clear();
            txt_lib_fonction.Clear();

            txt_c_fonction.Enabled = false;
            txt_lib_fonction.Enabled = true;

            bt_ajouter.Enabled = true;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = false;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Ajouter une fonction";

            insertion_modification = 0;
            txt_lib_fonction.Focus();
        }
    }
}