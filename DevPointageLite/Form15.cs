using DevExpress.XtraEditors;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace DevPointageLite
{
    public partial class Form15 : DevExpress.XtraEditors.XtraForm
    {
        public static int insertion_modification;
        public decimal n_jours;
        public decimal temps;
        public bool vergule;  // ✅ استخدام bool بدلاً من Boolean (C# style)
        public char Separateur = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        public Form15()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            insertion_modification = 0; // Insertion mode

            // ✅ إعادة تعيين الحقول
            txt_matricule.Text = "";
            lb_nom_prenom.Text = "Nom et prénom";
            dt_du.Value = DateTime.Now;
            dt_au.Value = DateTime.Now;
            cb_horaire.SelectedIndex = -1;
            cb_type.SelectedIndex = -1;
            txt_nbrABS.Text = "";
            txt_observation.Text = "";

            // ✅ تفعيل الحقول للإضافة
            txt_matricule.Enabled = true;
            dt_du.Enabled = true;
            dt_au.Enabled = true;
            cb_horaire.Enabled = true;
            chk_periodique.Enabled = true;
            cb_type.Enabled = true;
            txt_nbrABS.Enabled = false;
            txt_observation.Enabled = true;

            // ✅ إعداد الأزرار
            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = true;

            // ✅ تحميل البيانات المساعدة
            load_horaire();
            load_type_conge("N");
            chk_periodique_CheckedChanged(sender, e);
            UpdateAbsenceDuration();
            LoadAllAbsences();

            ActiveControl = txt_matricule;
        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_apercu_Click(object sender, EventArgs e)
        {
            // يمكن إضافة كود المعاينة لاحقاً
        }

        private void dt_au_ValueChanged(object sender, EventArgs e)
        {
            if (dt_au.Enabled)
            {
                n_jours = (dt_au.Value.Date - dt_du.Value.Date).Days + 1;
                txt_nbrABS.Text = n_jours.ToString();
                temps = 0;
            }
            else
            {
                n_jours = 0;
            }
            UpdateAbsenceDuration();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            insertion_modification = 1; // Modification mode

            // ✅ تفعيل الحقول للتعديل
            txt_matricule.Enabled = false; // الماتريكول جزء من المفتاح
            dt_du.Enabled = false;         // تاريخ البداية جزء من المفتاح
            dt_au.Enabled = !chk_periodique.Checked; // تاريخ النهاية فقط للـ Congé

            cb_horaire.Enabled = true;
            cb_type.Enabled = true;
            txt_nbrABS.Enabled = true;
            txt_observation.Enabled = true;

            // ✅ إعداد الأزرار
            bt_enregistrer.Enabled = true;
            bt_ajouter.Enabled = false;
            bt_modifier.Enabled = false;

            //txt_nbrABS.Focus();
            if (chk_periodique.Checked)
            {
                txt_nbrABS.Focus();
            }
            else
            {
                txt_nbrABS.Enabled = false;
                dt_au.Focus();
            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            txt_annee.Text = Form2.annee_en_cours;
            liste_mois.SelectedIndex = DateTime.Now.Month - 1;
            load_horaire();
            load_type_conge("N");
            LoadAllAbsences();
            ResetUI();
        }

        // ✅ تحميل بيانات الموظف باستخدام SQLite
        private void load_personnel_details()
        {
            string matricule = txt_matricule.Text.Trim();
            if (string.IsNullOrEmpty(matricule)) return;

            // ✅ SQLite: استخدام || للدمج بدلاً من +
            string query = @"SELECT nom, prenom, fonction.lib_fonction, affectation.lib_affect 
                            FROM Personnel 
                            INNER JOIN fonction ON personnel.id_fonction = fonction.c_fonct 
                            INNER JOIN affectation ON personnel.id_affectation = affectation.c_affect 
                            WHERE matricule = @matricule";

            var parameters = new[] { new SqliteParameter("@matricule", matricule) };
            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lb_nom_prenom.Text = $"{row["nom"]} {row["prenom"]}";
                lb_nom_prenom.Visible = true;
            }
            else
            {
                lb_nom_prenom.Text = "";
                lb_nom_prenom.Visible = false;
                XtraMessageBox.Show("المستخدم غير موجود", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        }

        // ✅ تحميل جداول العمل باستخدام SQLite
        private void load_horaire()
        {
            string query = "SELECT code, designation FROM horaire_travail ORDER BY designation";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_horaire.DataSource = dt;
                cb_horaire.DisplayMember = "designation";
                cb_horaire.ValueMember = "code";
                cb_horaire.SelectedIndex = -1;
            }
        }

        // ✅ تحميل أنواع الغياب باستخدام SQLite
        private void load_type_conge(string prd)
        {
            string query = "SELECT code, lib FROM type_conge WHERE PERIODIQUE = @periodique ORDER BY lib";
            var parameters = new[] { new SqliteParameter("@periodique", prd ?? (object)DBNull.Value) };
            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_type.DataSource = dt;
                cb_type.DisplayMember = "lib";
                cb_type.ValueMember = "code";
                cb_type.SelectedIndex = -1;
            }
        }

        private void chk_periodique_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_periodique.Checked)
            {
                load_type_conge("N");
                chk_periodique.Text = "Bon Sortie";
                lb_nbrABS.Text = "Nbr Heurs :";
                dt_au.Enabled = false;
                txt_nbrABS.Enabled = true;
            }
            else
            {
                load_type_conge("O");
                chk_periodique.Text = "Conge";
                lb_nbrABS.Text = "Nbr Jours";
                dt_au.Enabled = true;
                txt_nbrABS.Enabled = false;
            }
            UpdateAbsenceDuration();
            CalculateDays();
        }

        private void txt_nbrABS_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_nbrABS.Text, out decimal val))
            {
                if (val < 0 || val > 8)
                {
                    XtraMessageBox.Show("Veuillez vérifier vos données?", "DevPointage",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_nbrABS.Text = "0";
                    txt_nbrABS.Focus();
                    temps = 0;
                    n_jours = 0;
                }
                else
                {
                    temps = val;
                }
            }
            else
            {
                txt_nbrABS.Text = "0";
                temps = 0;
            }
        }

        private void CalculateDays()
        {
            if (dt_au.Enabled)
            {
                if (dt_au.Value.Date < dt_du.Value.Date)
                {
                    dt_au.Value = dt_du.Value;
                }
                n_jours = (dt_au.Value.Date - dt_du.Value.Date).Days + 1;
                txt_nbrABS.Text = n_jours.ToString();
            }
            else
            {
                n_jours = 0;
                txt_nbrABS.Text = "0";
                dt_au.Value = dt_du.Value;
            }
        }

        private void dt_du_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_matricule.Text)) return;

            string code = get_personnel_emploi_code(txt_matricule.Text, dt_du.Value);

            if (string.IsNullOrWhiteSpace(code))
            {
                cb_horaire.SelectedIndex = -1;
            }
            else
            {
                cb_horaire.SelectedValue = code.Trim();
                bt_enregistrer.Enabled = true;
            }

            CalculateDays();
            UpdateAbsenceDuration();
        }

        // ✅ جلب كود جدول العمل باستخدام SQLite
        private string get_personnel_emploi_code(string matricule, DateTime date_jr)
        {
            if (string.IsNullOrEmpty(matricule)) return "";

            string query = @"SELECT code FROM Personnel_emploi_temps 
                            WHERE matri = @matricule 
                            AND @date_jr >= date_du AND @date_jr <= date_au";

            var parameters = new[]
            {
                new SqliteParameter("@matricule", matricule),
                new SqliteParameter("@date_jr", date_jr.Date)
            };

            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0]["code"].ToString() : "";
        }

        private void UpdateAbsenceDuration()
        {
            if (!chk_periodique.Checked)
            {
                if (dt_au.Value.Date < dt_du.Value.Date)
                {
                    XtraMessageBox.Show("تاريخ النهاية لا يمكن أن يكون أصغر من تاريخ البداية",
                                      "خطأ في التاريخ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dt_au.Value = dt_du.Value;
                }
                n_jours = (dt_au.Value.Date - dt_du.Value.Date).Days + 1;
                txt_nbrABS.Text = n_jours.ToString();
                temps = 0;
            }
            else
            {
                n_jours = 0;
            }
        }

        // ✅ توليد رقم البون التالي باستخدام IFNULL لـ SQLite
        //private string GetNextNumBon(string matri, DateTime date1)
        // {
        //old code ...
        //
        //// ✅ SQLite: استخدام IFNULL بدلاً من ISNULL، وCAST(... AS INTEGER)
        //string query = "SELECT IFNULL(MAX(CAST(NUM_BON AS INTEGER)), 0) + 1 FROM [ABS] WHERE MATRI = @matri AND DATE1 = @date1";

        //var parameters = new[]
        //{
        //    new SqliteParameter("@matri", matri),
        //    new SqliteParameter("@date1", date1.Date)
        //};

        //DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);
        //return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "1";

        // ✅ تحسين: توليد NUM_BON بناءً على السنة والشهر لتجنب التعارضات
        //string yearMonth = date1.ToString("yyyyMM");
        //string query = @"SELECT IFNULL(MAX(CAST(SUBSTR(NUM_BON, 7) AS INTEGER)), 0) + 1 
        //                 FROM [ABS] 
        //                 WHERE  SUBSTR(NUM_BON, 1, 6) = @yearMonth";
        //var parameters = new[]
        //{
        //    new SqliteParameter("@matri", matri),
        //    new SqliteParameter("@yearMonth", yearMonth)
        //};
        //DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);
        //int nextNum = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 1;
        // }
        private string GetNextNumBon(string matri, DateTime date1)
        {
            // 1. تحضير مفتاح السنة والشهر (مثلاً: 202405)
            string yearMonth = date1.ToString("yyyyMM");

            // 2. الاستعلام: استخراج الجزء الرقمي بعد أول 6 خانات (تاريخ)
            // أضفنا شرط MATRI إذا كان ضرورياً لفصل الأرقام
            string query = @"SELECT IFNULL(MAX(CAST(SUBSTR(NUM_BON, 7) AS INTEGER)), 0) + 1 
                     FROM [ABS] 
                     WHERE SUBSTR(NUM_BON, 1, 6) = @yearMonth AND MATRI = @matri";

            var parameters = new[]
            {
        new SqliteParameter("@yearMonth", yearMonth),
        new SqliteParameter("@matri", matri)
    };

            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

            // 3. استخراج الرقم التالي
            int nextId = 1;
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                nextId = Convert.ToInt32(dt.Rows[0][0]);
            }

            // 4. إرجاع الرقم بتنسيق كامل (مثلاً: 202405001)
            // استخدم PadLeft لضمان أن الجزء التسلسلي له طول ثابت (3 خانات مثلاً)
            return yearMonth + nextId.ToString().PadLeft(3, '0');
        }
        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            string matricule = txt_matricule.Text.Trim();
            DateTime du = dt_du.Value.Date;
            DateTime au = dt_au.Value.Date;
            string currentNumBon = "";

            // إذا كنا في وضع التعديل (1) نجلب الرقم الحالي
            if (insertion_modification != 0)
            {
                currentNumBon = gridView1.GetFocusedRowCellValue("NUM_BON")?.ToString() ?? "";
            }
            if (!chk_periodique.Checked)
            {
                // الفحص
                if (existe_absence(matricule, du, au, currentNumBon))
                {
                    XtraMessageBox.Show("عذراً، يوجد تداخل مع غياب آخر مسجل لهذا الموظف!", "تنبيه",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            SaveAbsence();
        }
        private void SaveAbsence()
        {
            // يمكن إضافة كود الحفظ هنا باستخدام ConnectSqlite.ExecuteNonQuery
            if (string.IsNullOrEmpty(txt_matricule.Text) || cb_type.SelectedValue == null)
            {
                XtraMessageBox.Show("Veuillez remplir les champs obligatoires", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string numBon;
                string query;

                if (insertion_modification == 0) // ➕ Insertion
                {
                    numBon = GetNextNumBon(txt_matricule.Text.Trim(), dt_du.Value);

                    query = @"INSERT INTO [ABS] 
                              (MATRI, C_CONGE, DATE1, DATE2, JOUR, HEURE, NATURE, OBS, NUM_BON, CLOT) 
                              VALUES 
                              (@matri, @c_conge, @date1, @date2, @jour, @heure, @nature, @obs, @num_bon, 'N')";
                }
                else // ✏️ Modification
                {
                    // ✅ التأكد من وجود صف محدد
                    if (gridView1.FocusedRowHandle < 0)
                    {
                        XtraMessageBox.Show("Veuillez sélectionner un enregistrement à modifier.", "Erreur",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    numBon = gridView1.GetFocusedRowCellValue("NUM_BON")?.ToString() ?? "";

                    query = @"UPDATE [ABS] SET 
                              C_CONGE = @c_conge, DATE2 = @date2, JOUR = @jour, HEURE = @heure, 
                              NATURE = @nature, OBS = @obs 
                              WHERE MATRI = @matri AND DATE1 = @date1 AND NUM_BON = @num_bon";
                }

                var parameters = new[]
                {
                    new SqliteParameter("@matri", txt_matricule.Text.Trim()),
                    new SqliteParameter("@c_conge", cb_type.SelectedValue?.ToString() ?? ""),
                    new SqliteParameter("@date1", dt_du.Value.Date),
                    new SqliteParameter("@date2",/* chk_periodique.Checked ? (object)DBNull.Value :*/ dt_au.Value.Date),
                    new SqliteParameter("@jour", chk_periodique.Checked ? 0 : Convert.ToDecimal(txt_nbrABS.Text)),
                    new SqliteParameter("@heure", chk_periodique.Checked ? Convert.ToDecimal(txt_nbrABS.Text) : 0),
                    new SqliteParameter("@nature", chk_periodique.Checked ? "S" : "C"),
                    new SqliteParameter("@obs", txt_observation.Text.Trim()),
                    new SqliteParameter("@num_bon", numBon)
                };

                int rowsAffected = ConnectSqlite.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    XtraMessageBox.Show($"Enregistré avec succès ! Numéro de bon: {numBon}", "Succès",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllAbsences();
                    ResetUI();
                }
                else
                {
                    XtraMessageBox.Show("Échec de l'enregistrement.", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erreur: " + ex.Message, "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // ✅ تحميل الغيابات باستخدام دوال SQLite (strftime بدلاً من MONTH/YEAR)
        private void LoadAllAbsences()
        {
            try
            {
                int month = liste_mois.SelectedIndex + 1;
                string year = txt_annee.Text.Trim();

                if (string.IsNullOrEmpty(year))
                {
                    XtraMessageBox.Show("Veuillez saisir l'année");
                    return;
                }

                // ✅ SQLite: استخدام strftime('%m', ...) و strftime('%Y', ...)
                // ✅ استخدام || للدمج بدلاً من +
                string query = @"SELECT A.MATRI, P.NOM || ' ' || P.PRENOM AS [Nom & Prénom], 
                                       A.DATE1, A.DATE2, A.NUM_BON, A.C_CONGE, 
                                       A.JOUR, A.HEURE, A.NATURE,T.LIB As 'Conge', A.OBS 
                                FROM [ABS] A
                                INNER JOIN [PERSONNEL] P ON A.MATRI = P.MATRICULE 
                                INNER JOIN [TYPE_CONGE] T ON A.C_CONGE = T.CODE
                                WHERE strftime('%m', A.DATE1) = @month 
                                AND strftime('%Y', A.DATE1) = @year
                                ORDER BY A.DATE1 DESC, A.MATRI ASC";

                var parameters = new[]
                {
                    new SqliteParameter("@month", month.ToString("D2")), // ✅ شهر كنص ثنائي الرقم
                    new SqliteParameter("@year", year)
                };

                DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

                if (dt != null)
                {
                    gridControl1.DataSource = dt;
                    gridView1?.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erreur lors du chargement : " + ex.Message, "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void liste_mois_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllAbsences();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ResetUI();

            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                if (row != null)
                {
                    txt_matricule.Text = row["MATRI"]?.ToString() ?? "";
                    load_personnel_details();

                    if (row["DATE1"] != DBNull.Value)
                        dt_du.Value = Convert.ToDateTime(row["DATE1"]);

                    if (row["NATURE"]?.ToString() == "S") // Sortie/ساعات
                    {
                        chk_periodique.Checked = true;
                        txt_nbrABS.Text = row["HEURE"]?.ToString() ?? "0";
                        dt_au.Enabled = false;
                    }
                    else // Congé/أيام
                    {
                        chk_periodique.Checked = false;
                        txt_nbrABS.Text = row["JOUR"]?.ToString() ?? "0";
                        if (row["DATE2"] != DBNull.Value)
                            dt_au.Value = Convert.ToDateTime(row["DATE2"]);
                        dt_au.Enabled = true;
                    }

                    if (row["C_CONGE"] != null)
                        cb_type.SelectedValue = row["C_CONGE"].ToString();

                    txt_observation.Text = row["OBS"]?.ToString() ?? "";

                    bt_ajouter.Enabled = true;
                    bt_modifier.Enabled = true;
                    bt_enregistrer.Enabled = false;
                }
            }
        }

        private void ResetUI()
        {
            txt_matricule.Text = "";
            lb_nom_prenom.Text = "";
            txt_nbrABS.Text = "0";
            txt_observation.Text = "";
            dt_du.Value = DateTime.Now;
            dt_au.Value = DateTime.Now;
            chk_periodique.Checked = true;
            cb_horaire.SelectedIndex = -1;
            cb_type.SelectedIndex = -1;

            txt_matricule.Enabled = false;
            dt_du.Enabled = false;
            dt_au.Enabled = false;
            cb_horaire.Enabled = false;
            cb_type.Enabled = false;
            txt_nbrABS.Enabled = false;
            txt_observation.Enabled = false;

            bt_ajouter.Enabled = true;
            bt_modifier.Enabled = false;
            bt_enregistrer.Enabled = false;
        }



        private bool existe_absence(string matricule, DateTime date_debut, DateTime date_fin, string num_bon_actuel = "")
        {
            try
            {
                if (string.IsNullOrEmpty(matricule)) return false;

                // تحويل التواريخ لصيغة SQLite القياسية
                string d1 = date_debut.ToString("yyyy-MM-dd");
                string d2 = date_fin.ToString("yyyy-MM-dd");

                // الاستعلام: نبحث عن أي سجل يبدأ قبل نهاية الفترة الجديدة وينتهي بعد بدايتها
                string query = @"SELECT COUNT(*) FROM [ABS] 
                        WHERE MATRI = @matri 
                        AND date(DATE1) <= date(@d_fin) 
                        AND date(DATE2) >= date(@d_debut)";

                // إذا كنا في وضع التعديل، نستثني السجل الحالي من الفحص
                if (!string.IsNullOrEmpty(num_bon_actuel))
                {
                    query += " AND NUM_BON <> @num_bon";
                }

                var parameters = new List<SqliteParameter>
        {
            new SqliteParameter("@matri", matricule),
            new SqliteParameter("@d_debut", d1),
            new SqliteParameter("@d_fin", d2)
        };

                if (!string.IsNullOrEmpty(num_bon_actuel))
                {
                    parameters.Add(new SqliteParameter("@num_bon", num_bon_actuel));
                }

                DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters.ToArray());

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0][0]);
                    return count > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ في فحص التداخل: " + ex.Message);
                return false;
            }
        }

        private void bt_exportexcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sd.FilterIndex = 2;
            sd.RestoreDirectory = true;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(sd.FileName);
                Process.Start(sd.FileName);
            }
        }

        private void bt_exportpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Pdf files (*.pdf)|*.pdf";
            sd.FilterIndex = 2;
            sd.RestoreDirectory = true;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToPdf(sd.FileName);
                Process.Start(sd.FileName);
            }
        }
    }
}