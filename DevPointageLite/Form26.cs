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
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite


namespace DevPointageLite
{
    public partial class Form26 : DevExpress.XtraEditors.XtraForm
    {
        public static int insertion_modification; // 0 pour insertion, 1 pour modification

        public Form26()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            // ✅ ضبط صيغة التاريخ لعرض yyyy-MM-dd (يطابق ما يُخزن في SQLite)
            date_ferier.Format = DateTimePickerFormat.Custom;
            date_ferier.CustomFormat = "yyyy-MM-dd";

            // ✅ التركيز على حقل الإدخال عند التحميل
            txt_lib.Focus();
            ActiveControl = txt_lib;
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            this.Close(); // ✅ إغلاق النموذج
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification = 0; // Insertion mode

            // ✅ إعداد واجهة النموذج
            date_ferier.Enabled = false;
            txt_lib.Enabled = true;
            date_ferier.Value = DateTime.Now;
            txt_lib.Clear();

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Ajouter une date Feriée";

            

            txt_lib.Focus();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
           

            insertion_modification = 1; // Modification mode

            // ✅ إعداد واجهة النموذج
            date_ferier.Enabled = false;
            txt_lib.Enabled = true;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Modifier une date Feriée";

            txt_lib.Focus();
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // ✅ 1. التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txt_lib.Text))
            {
                XtraMessageBox.Show("Veuillez saisir le libellé de la Journier Feriée.", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_lib.Focus();
                return;
            }

            // ✅ الصيغة الموحدة للتاريخ (yyyy-MM-dd) — تطابق ما يُخزن ويُقارن
            string dateStr = date_ferier.Value.ToString("yyyy-MM-dd");

            // ✅ 2. التحقق من تكرار الكود (لحالة الإضافة فقط)
            if (insertion_modification == 0)
            {
                string checkQuery = "SELECT COUNT(*) FROM JOUR_FERIE WHERE date_f = @date_f";
                var checkParam = new SqliteParameter("@date_f", date_ferier.Text.Trim());
                DataTable dtCheck = ConnectSqlite.ExecuteSelect(checkQuery, checkParam);

                if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
                {
                    XtraMessageBox.Show("la Journier existe déjà.", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    date_ferier.Focus();
                    return;
                }
            }

            // ✅ 3. تحضير الاستعلام والمعاملات
            string query;
            if (insertion_modification == 0) // Insertion
            {
                query = "INSERT INTO JOUR_FERIE (date_f, lib) VALUES (@date_f, @lib)";
            }
            else // Modification
            {
                query = "UPDATE JOUR_FERIE SET lib = @lib WHERE date_f = @date_f";
            }

            var parameters = new[]
            {
                new SqliteParameter("@date_f", dateStr),           // ✅ صحيح
                new SqliteParameter("@lib",    txt_lib.Text.Trim()) // ✅ صحيح
            };

            // ✅ 4. تنفيذ الاستعلام عبر ConnectSqlite
            int rowsAffected = ConnectSqlite.ExecuteNonQuery(query, parameters);

            // ✅ 5. معالجة النتيجة
            if (rowsAffected > 0)
            {
                string msg = (insertion_modification == 0)
                     ? "La date fériée a été ajoutée avec succès."
                    : "La date fériée a été modifiée avec succès.";


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
            date_ferier.Value = DateTime.Now;
            txt_lib.Clear();

            date_ferier.Enabled = false;
            txt_lib.Enabled = true;

            bt_ajouter.Enabled = true;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = false;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Journée Fériée";

            insertion_modification = 0;
            txt_lib.Focus();
        }
    }
}