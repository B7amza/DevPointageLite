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
using Microsoft.Data.Sqlite;

namespace DevPointageLite
{
    public partial class Form23 : DevExpress.XtraEditors.XtraForm
    {
        public Form23()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }

        static public int insertion_modification; // 0: insertion, 1: modification
        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void dt_au_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_matricule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_matricule_Leave(sender, e);
            }
        }

        private void txt_matricule_Leave(object sender, EventArgs e)
        {
            load_personnel_details();


            
            load_personnel_emploi_temps_data();
        }
        private void load_personnel_details()
        {
            string matricule = txt_matricule.Text.Trim();
            if (string.IsNullOrEmpty(matricule)) return;

            string query = @"SELECT nom, prenom, fonction.lib_fonction, affectation.lib_affect 
                            FROM Personnel 
                            INNER JOIN fonction ON personnel.id_fonction = fonction.c_fonct 
                            INNER JOIN affectation ON personnel.id_affectation = affectation.c_affect 
                            WHERE matricule = @matricule";

            var parameters = new SqliteParameter[] { new SqliteParameter("@matricule", matricule) };
            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

            if (dt.Rows.Count > 0 && dt.Rows[0]["nom"] != DBNull.Value)
            {
                DataRow row = dt.Rows[0];
                string nom = row["nom"]?.ToString() ?? "";
                string prenom = row["prenom"]?.ToString() ?? "";
                txt_nom_prenom.Text = $"{nom} {prenom}";
                
            }
            else
            {
                txt_nom_prenom.Text = "";
                
                XtraMessageBox.Show("المستخدم غير موجود", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification = 0; // تعيين العملية إلى إدراج
            
            txt_matricule.Text = "";
            txt_nom_prenom.Text = "";
            cb_horaire_travail.SelectedIndex = -1;
            

            txt_matricule.Enabled = true;
            cb_horaire_travail.Enabled = true;
            dt_du.Enabled =false;
            dt_au.Enabled = true;

            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
            ActiveControl=txt_matricule;
        }

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

        private void Form23_Load(object sender, EventArgs e)
        {
            load_horaire_travail_data();
        }

        private void load_personnel_emploi_temps_data()
        {
            string query = "SELECT matri, code,date_du,date_au FROM personnel_emploi_temps where matri=@matri ORDER BY date_du";
            var parameters = new SqliteParameter[]
             {
                new SqliteParameter("@matri", txt_matricule.Text)
             };
            DataTable dt = ConnectSqlite.ExecuteSelect(query,parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                
                tableau_horaire.DataSource = dt;
            }
        }

        private void tableau_horaire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           cb_horaire_travail.SelectedValue = tableau_horaire.CurrentRow.Cells["code"].Value.ToString();
            dt_du.Value = Convert.ToDateTime(tableau_horaire.CurrentRow.Cells["date_du"].Value);
            dt_au.Value = Convert.ToDateTime(tableau_horaire.CurrentRow.Cells["date_au"].Value);
            //txt_matricule.Enabled = false;
            //cb_horaire_travail.Enabled = true;
            //dt_du.Enabled = true;
            //dt_au.Enabled = true;
            bt_modifier.Enabled = true;
            bt_enregistrer.Enabled = false;

           
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            insertion_modification = 1; // تعيين العملية إلى تعديل
            txt_matricule.Enabled = false;
            cb_horaire_travail.Enabled = true;
            dt_du.Enabled = true;
            dt_au.Enabled = true;
            bt_enregistrer.Enabled = true;
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // التحقق من صحة الإدخال
            if (string.IsNullOrEmpty(txt_matricule.Text.Trim()))
            {
                XtraMessageBox.Show("الرجاء إدخال الرقم التسلسلي", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // تنفيذ عملية الإدراج أو التعديل بناءً على القيمة الحالية لـ insertion_modification
            if (insertion_modification == 0) // إدراج
            {
                string insertQuery = @"INSERT INTO personnel_emploi_temps (matri, code, date_du, date_au) 
                                       VALUES (@matri, @code, @date_du, @date_au)";
                var parameters = new SqliteParameter[]
                {
                    new SqliteParameter("@matri", txt_matricule.Text.Trim()),
                    new SqliteParameter("@code", cb_horaire_travail.SelectedValue),
                    new SqliteParameter("@date_du", dt_du.Value.Date),
                    new SqliteParameter("@date_au", dt_au.Value.Date)
                };
                ConnectSqlite.ExecuteNonQuery(insertQuery, parameters);
                XtraMessageBox.Show("تمت إضافة الجدول الزمني بنجاح", "نجاح",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (insertion_modification == 1) // تعديل
            {
                string updateQuery = @"UPDATE personnel_emploi_temps 
                                       SET code = @code, date_du = @date_du, date_au = @date_au 
                                       WHERE matri = @matri AND date_du = @original_date_du";
                var parameters = new SqliteParameter[]
                {
                    new SqliteParameter("@code", cb_horaire_travail.SelectedValue),
                    new SqliteParameter("@date_du", dt_du.Value.Date),
                    new SqliteParameter("@date_au", dt_au.Value.Date),
                    new SqliteParameter("@matri", txt_matricule.Text.Trim()),
                    new SqliteParameter("@original_date_du", Convert.ToDateTime(tableau_horaire.CurrentRow.Cells["date_du"].Value).Date)
                };
                ConnectSqlite.ExecuteNonQuery(updateQuery, parameters);
                XtraMessageBox.Show("تم تحديث الجدول الزمني بنجاح", "نجاح",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            vider_champs();
            bt_ajouter.Enabled = true;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = false;

        }
        private void vider_champs()
        {
            txt_matricule.Text = "";
            txt_nom_prenom.Text = "";
            cb_horaire_travail.SelectedIndex = -1;
            dt_du.Value = DateTime.Now;
            dt_au.Value = DateTime.Now;
        }
    }
}