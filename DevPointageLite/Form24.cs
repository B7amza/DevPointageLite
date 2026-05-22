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
    public partial class Form24 : DevExpress.XtraEditors.XtraForm
    {
        public Form24()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        static public int insertion_modification; // 0: Insertion, 1: Modification

        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            vider_champs();
            reset_champs(true);
            insertion_modification = 0;
            calcule_max_code();
            bt_enregistrer.Enabled = true;
            ActiveControl = txt_designation;
        }

        public void reset_champs(Boolean etat)
        {
            
            switch (etat)
            {
                case true:
                   
                    
                    ///
                    txt_code.Enabled = false;
                    txt_designation.Enabled = true;

                    du_d.Enabled = true;
                    du_l.Enabled = true;
                    du_ma.Enabled = true;
                    du_me.Enabled = true;
                    du_j.Enabled = true;
                    du_v.Enabled = true;
                    du_s.Enabled = true;

                    au_d.Enabled = true;
                    au_l.Enabled = true;
                    au_ma.Enabled = true;
                    au_me.Enabled = true;
                    au_j.Enabled = true;
                    au_v.Enabled = true;
                    au_s.Enabled = true;


                    chk_wd.Enabled = true;
                    chk_wl.Enabled = true;
                    chk_wma.Enabled = true;
                    chk_wme.Enabled = true;
                    chk_wj.Enabled = true;
                    chk_wv.Enabled = true;
                    chk_ws.Enabled = true;

                    break;
                case false:
                    txt_code.Enabled = false;
                    txt_designation.Enabled = false;

                    du_d.Enabled = false;
                    du_l.Enabled = false;
                    du_ma.Enabled = false;
                    du_me.Enabled = false;
                    du_j.Enabled = false;
                    du_v.Enabled = false;
                    du_s.Enabled = false;

                    au_d.Enabled = false;
                    au_l.Enabled = false;
                    au_ma.Enabled = false;
                    au_me.Enabled = false;
                    au_j.Enabled = false;
                    au_v.Enabled = false;
                    au_s.Enabled = false;


                    chk_wd.Enabled = false;
                    chk_wl.Enabled = false;
                    chk_wma.Enabled = false;
                    chk_wme.Enabled = false;
                    chk_wj.Enabled = false;
                    chk_wv.Enabled = false;
                    chk_ws.Enabled = false;
                    break;
            }
            
        }

        private void calcule_max_code()
        {
            string query = "SELECT IFNULL(MAX(code), '00') AS code FROM HORAIRE_TRAVAIL";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);
            if (dt.Rows.Count > 0 && dt.Rows[0]["code"] != DBNull.Value)
            {
                string maxCode = dt.Rows[0]["code"].ToString();
                if (int.TryParse(maxCode, out int codeValue))
                {
                    int nextCode = codeValue + 1;
                    txt_code.Text = nextCode.ToString("D2");
                }
                else
                {
                    txt_code.Text = "01";
                }
            }
            else
            {
                txt_code.Text = "01";
            }
        }
        private void vider_champs()
        {
                
                txt_designation.Text = "";
                du_d.Text = "  :  ";
                du_l.Text = "  :  ";
                du_ma.Text = "  :  ";
                du_me.Text = "  :  ";
                du_j.Text = "  :  ";
                du_v.Text = "  :  ";
                du_s.Text = "  :  ";
    
                au_d.Text = "  :  ";
                au_l.Text = "  :  ";
                au_ma.Text = "  :  ";
                au_me.Text = "  :  ";
                au_j.Text = "  :  ";
                au_v.Text = "  :  ";
                au_s.Text = "  :  ";
    
                chk_wd.Checked = false;
                chk_wl.Checked = false;
                chk_wma.Checked = false;
                chk_wme.Checked = false;
                chk_wj.Checked = false;
                chk_wv.Checked = true;
                chk_ws.Checked = true;
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            insertion_modification = 1;
                reset_champs(true);
            bt_enregistrer.Enabled = true;
            ActiveControl = txt_designation;

        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            // 1. تحقق من صحة البيانات قبل الحفظ
            if (string.IsNullOrWhiteSpace(txt_designation.Text))
            {
                MessageBox.Show("الرجاء إدخال التسمية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (du_d.Text.Replace(" ", "") == ":" || du_l.Text.Replace(" ", "") == ":" || du_ma.Text.Replace(" ", "") == ":" ||
               du_me.Text.Replace(" ", "") == ":" || du_j.Text.Replace(" ", "") == ":" || du_v.Text.Replace(" ", "") == ":" ||
               du_s.Text.Replace(" ", "") == ":")
            {
                MessageBox.Show("الرجاء إدخال وقت الدخول لجميع الأيام.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (au_d.Text.Replace(" ", "") == ":" || au_l.Text.Replace(" ", "") == ":" || au_ma.Text.Replace(" ", "") == ":" ||
               au_me.Text.Replace(" ", "") == ":" || au_j.Text.Replace(" ", "") == ":" || au_v.Text.Replace(" ", "") == ":" ||
               au_s.Text.Replace(" ", "") == ":")
            {
                MessageBox.Show("الرجاء إدخال وقت الخروج لجميع الأيام.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. تجميع البيانات
            string code = txt_code.Text;
            string designation = txt_designation.Text;

            // دمج القيم لكل يوم في متغير واحد داخل C# (مثال: 08:00-16:00-O)
            string dim_value = $"{du_d.Text}-{au_d.Text}-{(chk_wd.Checked ? "O" : "N")}";
            string lun_value = $"{du_l.Text}-{au_l.Text}-{(chk_wl.Checked ? "O" : "N")}";
            string mar_value = $"{du_ma.Text}-{au_ma.Text}-{(chk_wma.Checked ? "O" : "N")}";
            string mer_value = $"{du_me.Text}-{au_me.Text}-{(chk_wme.Checked ? "O" : "N")}";
            string jeu_value = $"{du_j.Text}-{au_j.Text}-{(chk_wj.Checked ? "O" : "N")}";
            string ven_value = $"{du_v.Text}-{au_v.Text}-{(chk_wv.Checked ? "O" : "N")}";
            string sam_value = $"{du_s.Text}-{au_s.Text}-{(chk_ws.Checked ? "O" : "N")}";

            // 3. عملية الحفظ أو التعديل
            if (insertion_modification == 0) // Insertion
            {
                string insertQuery = @"INSERT INTO HORAIRE_TRAVAIL 
                               (code, designation, sam, dim, lun, mar, mer, jeu, ven) 
                               VALUES 
                               (@code, @designation, @sam, @dim, @lun, @mar, @mer, @jeu, @ven)";

                // تمرير 9 بارامترات فقط بدلاً من 23!
                SqliteParameter[] parameters = new SqliteParameter[]
                {
            new SqliteParameter("@code", code),
            new SqliteParameter("@designation", designation),
            new SqliteParameter("@sam", sam_value),
            new SqliteParameter("@dim", dim_value),
            new SqliteParameter("@lun", lun_value),
            new SqliteParameter("@mar", mar_value),
            new SqliteParameter("@mer", mer_value),
            new SqliteParameter("@jeu", jeu_value),
            new SqliteParameter("@ven", ven_value)
                };

                ConnectSqlite.ExecuteNonQuery(insertQuery, parameters);
                MessageBox.Show("تمت إضافة الجدول بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (insertion_modification == 1) // Modification
            {
                string updateQuery = @"UPDATE HORAIRE_TRAVAIL SET 
                               designation = @designation, sam = @sam, dim = @dim, lun = @lun, 
                               mar = @mar, mer = @mer, jeu = @jeu, ven = @ven
                               WHERE code = @code";

                // استخدام نفس المصفوفة المكونة من 9 بارامترات
                SqliteParameter[] parameters = new SqliteParameter[]
                {
            new SqliteParameter("@code", code),
            new SqliteParameter("@designation", designation),
            new SqliteParameter("@sam", sam_value),
            new SqliteParameter("@dim", dim_value),
            new SqliteParameter("@lun", lun_value),
            new SqliteParameter("@mar", mar_value),
            new SqliteParameter("@mer", mer_value),
            new SqliteParameter("@jeu", jeu_value),
            new SqliteParameter("@ven", ven_value)
                };

                ConnectSqlite.ExecuteNonQuery(updateQuery, parameters);
                MessageBox.Show("تم تحديث الجدول بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 4. إعادة تهيئة الواجهة
            reset_champs(false);
            bt_ajouter.Enabled = true;
            bt_modifier.Enabled = true;
            bt_enregistrer.Enabled = false;
        }

        private void du_v_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        
        public void ChargerDonnees(string code, string designation, string sam, string dim, string lun, string mar, string mer, string jeu, string ven)
        {
            // 1. تعبئة البيانات الأساسية
            txt_code.Text = code;
            txt_designation.Text = designation;

            // 2. تغيير حالة الفورم إلى "تعديل"
            insertion_modification = 1;

            // 3. تفكيك وتوزيع بيانات الأيام باستخدام دالة مساعدة
            RemplirJour(sam, du_s, au_s, chk_ws);
            RemplirJour(dim, du_d, au_d, chk_wd);
            RemplirJour(lun, du_l, au_l, chk_wl);
            RemplirJour(mar, du_ma, au_ma, chk_wma);
            RemplirJour(mer, du_me, au_me, chk_wme);
            RemplirJour(jeu, du_j, au_j, chk_wj);
            RemplirJour(ven, du_v, au_v, chk_wv);

            // 4. تفعيل/تعطيل الأزرار حسب الحاجة
            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;
        }

        // دالة مساعدة لتفكيك النص (مثال: 08:00-16:00-O) وتوزيعه
        private void RemplirJour(string dayData, MaskedTextBox txtDu, MaskedTextBox txtAu, CheckBox chk)
        {
            if (!string.IsNullOrEmpty(dayData) && dayData.Contains("-"))
            {
                // تقسيم النص بناءً على رمز "-"
                string[] parts = dayData.Split('-');

                if (parts.Length == 3)
                {
                    txtDu.Text = parts[0];         // وقت الدخول
                    txtAu.Text = parts[1];         // وقت الخروج
                    chk.Checked = (parts[2] == "O"); // حالة اليوم: إذا كانت O ستكون القيمة true
                }
            }
        }
    }
}