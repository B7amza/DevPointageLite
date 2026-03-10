using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Html;
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

namespace DevPointageLite
{
    public partial class Form19 : DevExpress.XtraEditors.XtraForm
    {
        public Form19()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }
        static public string var_periodique="O";
        static public int insertion_modification;
        private void Form19_Load(object sender, EventArgs e)
        {
            if (insertion_modification == 0)
            {
                // إعدادات لعملية الإدراج
                this.Text = "Ajouter un type de Congé";
                // يمكنك تهيئة الحقول هنا إذا لزم الأمر
            }
            else if (insertion_modification == 1)
            {
                // إعدادات لعملية التعديل
                this.Text = "Modifier un type de congé";
                // يمكنك تحميل بيانات الموظف الحالي إلى الحقول هنا
            }
            
        }
        private void chk_periodique_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_periodique.Checked)
            {
                
                chk_periodique.Text = "Congé";
                lb_nbrABS.Text = "Nbr Jours";
                txt_nbrABS.Enabled = true;
                var_periodique = "O";

            }
            else
            {
                
                chk_periodique.Text = "Bon Sortie";
                lb_nbrABS.Text = "N/A";
                txt_nbrABS.Enabled = false;
                txt_nbrABS.Text = "0";
                var_periodique = "N";
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
            txt_code.Enabled = false;
            txt_lib_conge.Enabled = true;
            txt_lib_conge.Text = string.Empty;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Ajouter un type de Congé";

            // ✅ توليد الكود التلقائي باستخدام كلاس ConnectSqlite
            string query = "SELECT IFNULL(MAX(code), '00') AS c_conge FROM TYPE_CONGE";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["c_conge"] != DBNull.Value)
            {
                string maxCode = dt.Rows[0]["c_conge"].ToString();
                int nextCode = Convert.ToInt32(maxCode) + 1;
                txt_code.Text = nextCode.ToString("D2");
            }
            else
            {
                txt_code.Text = "01";
            }
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_code.Text))
            {
                MessageBox.Show("Veuillez sélectionner un type de congé à modifier.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            insertion_modification = 1; // Modification mode

            txt_code.Enabled = false; // لا يمكن تعديل الكود
            txt_lib_conge.Enabled = true;

            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            bt_fermer.Enabled = true;
            bt_fermer.Text = "Fermer";
            Text = "Modifier un type de congé";

            txt_lib_conge.Focus();
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // تحقق من صحة الإدخال
            if (string.IsNullOrWhiteSpace(txt_lib_conge.Text))
            {
                MessageBox.Show("Veuillez entrer la désignation du type de congé.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (var_periodique == "O" && (string.IsNullOrWhiteSpace(txt_nbrABS.Text) || !int.TryParse(txt_nbrABS.Text, out _)))
            {
                MessageBox.Show("Veuillez entrer un nombre de jours valide pour le type de congé périodique.", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // تنفيذ عملية الإدراج أو التعديل في قاعدة البيانات
            if (insertion_modification == 0)
            {
                // عملية الإدراج
                string insertQuery = "INSERT INTO TYPE_CONGE (code, lib,paye,jour,type,bloc_pa,fixe,sur_solde,periodique,abv,pannier,transport,wend) VALUES (@code, @lib_conge,'N', @jour, '0','N','N','N',@periodique,'N','N','N','N')";
                var parameters = new SqliteParameter[]
                {
                    new SqliteParameter( "@code", txt_code.Text ),
                    new SqliteParameter( "@lib_conge", txt_lib_conge.Text ),
                    new SqliteParameter( "@periodique", var_periodique ),
                    new SqliteParameter( "@jour", var_periodique == "O" ? txt_nbrABS.Text : "0" )
                };
                ConnectSqlite.ExecuteNonQuery(insertQuery, parameters);
                MessageBox.Show("Type de congé ajouté avec succès.", "Succès",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (insertion_modification == 1)
            {
                // عملية التعديل
                string updateQuery = "UPDATE TYPE_CONGE SET lib = @lib_conge, periodique = @periodique, jour = @jour WHERE code = @code";
                var parameters = new SqliteParameter[]
                {
                    new SqliteParameter( "@code", txt_code.Text ),
                    new SqliteParameter("@lib_conge", txt_lib_conge.Text ),
                    new SqliteParameter("@periodique", var_periodique ),
                    new SqliteParameter( "@jour", var_periodique == "O" ? txt_nbrABS.Text : "0" )
                };
                ConnectSqlite.ExecuteNonQuery(updateQuery, parameters);
                MessageBox.Show("Type de congé modifié avec succès.", "Succès",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }
    }
}