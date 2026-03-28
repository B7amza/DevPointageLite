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
    public partial class Form18 : DevExpress.XtraEditors.XtraForm
    {
        public Form18()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }
        static public int insertion_modification; // 0: Insertion, 1: Modification
        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            txt_ip.Enabled = true;
            txt_ip.Text = string.Empty;
            txt_ip.Focus();

            txt_lib.Enabled = true;
            txt_lib.Text = string.Empty;

        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // ✅ التحقق من صحة الإدخال
            if (string.IsNullOrWhiteSpace(txt_ip.Text))
            {
                MessageBox.Show("Veuillez entrer une adresse IP valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ip.Focus();
                return;
            }
            // ✅ استخدام استعلامات معلمات لتجنب SQL Injection
            string query = insertion_modification == 0
                ? "INSERT INTO POINTEUSE (adresse_ip, lib_pointeuse,N_PORT,N_MACHINE,ETAT) VALUES (@ip, @lib,'4370','1','O')"
                : "UPDATE POINTEUSE SET adresse_ip = @ip, lib_pointeuse = @lib WHERE adresse_ip = @ip";
            // ✅ إعداد المعلمات
            var parameters = new[]
            {
                new SqliteParameter("@ip", txt_ip.Text.Trim()),
                new SqliteParameter("@lib", txt_lib.Text.Trim())
            };
            // ✅ تنفيذ الاستعلام
            int result = ConnectSqlite.ExecuteNonQuery(query, parameters);
            if (result > 0)
            {
                MessageBox.Show("Opération réussie.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Une erreur s'est produite lors de l'enregistrement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            if (insertion_modification == 0)
            {
                // إعدادات لعملية الإدراج
                this.Text = "Ajouter une adresse IP";
                txt_ip.Enabled = true;
                txt_lib.Enabled = true;

                bt_ajouter.Enabled = true;
                bt_modifier.Enabled = false;
                bt_enregistrer.Enabled = true;
            }
            else if (insertion_modification == 1)
            {
                // إعدادات لعملية التعديل
                this.Text = "Modifier une adresse IP";
                // يمكنك تحميل بيانات العنوان الحالي إلى الحقول هنا إذا لزم الأمر
            }
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {

        }
    }
}