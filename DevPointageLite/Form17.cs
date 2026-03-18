using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class Form17 : DevExpress.XtraEditors.XtraForm
    {
        public TimeSpan hr_entree, hr_sortie;

        public Form17()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            LoadHoraire_travail();
            load_affectation_data();
            cb_structure.SelectedIndex = -1;
            cb_horaire_travail.SelectedIndex = 0;
            // ✅ تهيئة DataGridViews
            ConfigureDataGridView(tableau);
            ConfigureDataGridView(entet2);
        }

        // ✅ دالة مساعدة لتهيئة DataGridView
        private void ConfigureDataGridView(DataGridView dgv)
        {
        //    dgv.AllowUserToAddRows = false;
        //    dgv.AllowUserToDeleteRows = false;
        //    dgv.ReadOnly = true;
        //    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    foreach (DataGridViewColumn col in dgv.Columns)
        //    {
        //        col.DefaultCellStyle.NullValue = null;
        //    }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void labelControl2_Click(object sender, EventArgs e) { }
        private void groupControl1_Paint(object sender, PaintEventArgs e) { }

        private void ch_tous_CheckedChanged(object sender, EventArgs e)
        {
            cb_structure.Enabled = !ch_tous.Checked;
            txt_matricule.Enabled = !ch_tous.Checked;
            lb_nom_prenom.Visible = !ch_tous.Checked;

            if (ch_tous.Checked)
            {
                cb_structure.SelectedIndex = -1;
                txt_matricule.Text = "";
            }

            ch_structure.Enabled = !ch_tous.Checked;
            ch_matricule.Enabled = !ch_tous.Checked;
            ch_structure.Checked = false;
            ch_matricule.Checked = false;
        }

        // ✅ تحميل بيانات الموظف باستخدام SQLite
        private void load_personnel_details()
        {
            string matricule = txt_matricule.Text.Trim();
            if (string.IsNullOrEmpty(matricule)) return;

            // ✅ SQLite: استخدام || للدمج بدلاً من CONCAT، وIFNULL بدلاً من ISNULL
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
                lb_nom_prenom.Text = $"{nom} {prenom}";
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

        private void txt_matricule_Leave(object sender, EventArgs e)
        {
            load_personnel_details();
            tableau.DataSource = null;
            tableau.Rows.Clear();
            tableau.Refresh();
            entet2.Rows.Clear(); // ✅ Rows.Clear() بدلاً من RowCount = 0
        }

        private void txt_matricule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_matricule_Leave(sender, e);
            }
        }

        // ✅ تحميل قائمة التعيينات باستخدام SQLite
        private void load_affectation_data()
        {
            string query = "SELECT c_affect, lib_affect FROM AFFECTATION ORDER BY lib_affect";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_structure.DisplayMember = "lib_affect";
                cb_structure.ValueMember = "c_affect";
                cb_structure.DataSource = dt;
                cb_structure.SelectedIndex = -1;
            }
        }

        private void cb_structure_SelectedIndexChanged(object sender, EventArgs e) { }

        private void ch_structure_CheckedChanged(object sender, EventArgs e)
        {
            cb_structure.Enabled = ch_structure.Checked;
            txt_matricule.Enabled = !ch_structure.Checked;
            lb_nom_prenom.Visible = !ch_structure.Checked;

            if (!ch_structure.Checked)
            {
                cb_structure.SelectedIndex = -1;
                txt_matricule.Text = "";
            }

            ch_tous.Enabled = !ch_structure.Checked;
            ch_tous.Checked = false;
            ch_matricule.Enabled = !ch_structure.Checked;
            ch_matricule.Checked = false;
        }

        private void ch_matricule_CheckedChanged(object sender, EventArgs e)
        {
            cb_structure.Enabled = !ch_matricule.Checked;
            txt_matricule.Enabled = ch_matricule.Checked;
            lb_nom_prenom.Visible = ch_matricule.Checked;

            if (!ch_matricule.Checked)
            {
                cb_structure.SelectedIndex = -1;
                txt_matricule.Text = "";
            }

            ch_tous.Enabled = !ch_matricule.Checked;
            ch_tous.Checked = false;
            ch_structure.Enabled = !ch_matricule.Checked;
            ch_structure.Checked = false;
        }

        // ✅ عرض المعاينة باستخدام SQLite
        private void bt_apercu_Click(object sender, EventArgs e)
        {
            tableau.DataSource = null;
            DataTable dtPersonnel = null;

            if (ch_structure.Checked)
            {
                if (cb_structure.SelectedIndex == -1) return;
                string c_affect = cb_structure.SelectedValue?.ToString() ?? "";

                // ✅ SQLite: استخدام || للدمج و IFNULL بدلاً من ISNULL
                string query = @"SELECT matricule, IFNULL(nom, '') || ' ' || IFNULL(prenom, '') as nom 
                                FROM Personnel WHERE id_affectation = @c_affect ORDER BY nom";
                var parameters = new SqliteParameter[] { new SqliteParameter("@c_affect", c_affect) };
                dtPersonnel = ConnectSqlite.ExecuteSelect(query, parameters);
            }
            else if (ch_matricule.Checked)
            {
                if (string.IsNullOrEmpty(txt_matricule.Text.Trim()))
                {
                    XtraMessageBox.Show("الرجاء إدخال رقم المستخدم", "تنبيه",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = @"SELECT matricule, IFNULL(nom, '') || ' ' || IFNULL(prenom, '') as nom 
                                FROM Personnel WHERE matricule = @matricule";
                var parameters = new SqliteParameter[] { new SqliteParameter("@matricule", txt_matricule.Text.Trim()) };
                dtPersonnel = ConnectSqlite.ExecuteSelect(query, parameters);
            }
            else if (ch_tous.Checked)
            {
                string query = @"SELECT matricule, IFNULL(nom, '') || ' ' || IFNULL(prenom, '') as nom 
                                FROM Personnel ORDER BY nom";
                dtPersonnel = ConnectSqlite.ExecuteSelect(query);
            }

            if (dtPersonnel != null)
            {
                tableau.DataSource = dtPersonnel;
                if (tableau.Columns.Contains("nom"))
                {
                    tableau.Columns["nom"].Width = 250;
                    tableau.Columns["nom"].HeaderText = "الاسم واللقب";
                }
            }

            // ✅ معالجة بيانات الحضور لكل موظف
            entet2.Rows.Clear();
            DateTime date_jour = this.date_jour.Value.Date;

            foreach (DataGridViewRow row in tableau.Rows)
            {
                if (row.IsNewRow) continue;

                string matricule = row.Cells[0].Value?.ToString()?.Trim();
                if (string.IsNullOrEmpty(matricule)) continue;

                // ✅ إضافة صف جديد في entet2
                int entetIndex = entet2.Rows.Add();
                DataGridViewRow entetRow = entet2.Rows[entetIndex];

                // ✅ جلب جدول العمل وتحديد أوقات الدخول/الخروج
                LoadHoraireForDate(date_jour);

                // ✅ جلب بصمات الموظف - الحل 2: إرجاع DataTable مباشرة
                int nbr_poitage = 0;
                DataTable dtJ = chargement_pointage_journaliere(matricule, date_jour, ref nbr_poitage);

                int position = 3;

                // ✅ معالجة البصمات بأمان
                if (nbr_poitage > 0 && dtJ != null && dtJ.Rows.Count > 0)
                {
                    for (int j = 0; j < nbr_poitage && j < dtJ.Rows.Count; j++)
                    {
                        string heureStr = dtJ.Rows[j]["HEURS_POINTAGE"]?.ToString()?.Trim();

                        if (!TimeSpan.TryParse(heureStr, out TimeSpan hr_pointage))
                            continue;

                        if (hr_pointage <= hr_entree)
                        {
                            entetRow.Cells[0].Value = hr_pointage.ToString();
                        }
                        else if (hr_pointage >= hr_sortie && hr_sortie > TimeSpan.Zero)
                        {
                            entetRow.Cells[6].Value = hr_pointage.ToString();
                            if ((hr_pointage - hr_sortie).Minutes >= Form2.plage_hrs)
                            {
                                double heuresSupp = hr_pointage.TotalMinutes - hr_sortie.TotalMinutes;
                                entetRow.Cells[7].Value = TimeSpan.FromMinutes(heuresSupp).ToString();
                            }
                        }
                        else if (hr_entree > TimeSpan.Zero && hr_pointage >= hr_entree && hr_pointage <= hr_sortie)
                        {
                            double retardMinutes = (hr_pointage - hr_entree).TotalMinutes;
                            if (retardMinutes <= Form2.plage_retards)
                            {
                                entetRow.Cells[0].Value = hr_pointage.ToString();
                                entetRow.Cells[2].Value = retardMinutes.ToString("0");
                            }
                            else
                            {
                                if (position < entetRow.Cells.Count)
                                {
                                    entetRow.Cells[position].Value = hr_pointage.ToString();
                                    position++;
                                }
                            }
                        }
                    }
                }

                // ✅ معالجة الغيابات
                DataTable dtABS = new DataTable();
                LoadAbsences(matricule, date_jour, dtABS);

                if (dtABS.Rows.Count > 0 && dtABS.Rows[0]["lib"] != DBNull.Value)
                {
                    string lib_conge = dtABS.Rows[0]["lib"].ToString();
                    if (!string.IsNullOrEmpty(lib_conge))
                    {
                        // ✅ التأكد من وجود العمود قبل التعيين
                        if (entetRow.Cells.Count > 10)
                            entetRow.Cells[8].Value = lib_conge;
                    }
                }
            }
        }

        // ✅ تحميل الغيابات باستخدام SQLite
        private void LoadAbsences(string matricule, DateTime date_jr, DataTable dtABS)
        {
            try
            {
                if (string.IsNullOrEmpty(matricule)) return;

                string query = @"SELECT A.C_CONGE, T.LIB
                                FROM [ABS] A
                                INNER JOIN [type_conge] T ON A.C_CONGE = T.CODE
                                WHERE DATE(A.DATE1) <= @date_jr and DATE(A.DATE2) >= @date_jr 
                                  AND A.MATRI = @matricule";

                var parameters = new SqliteParameter[]
                {
                    new SqliteParameter("@date_jr", date_jr.Date.ToString("yyyy-MM-dd")),
                    new SqliteParameter("@matricule", matricule)
                };

                DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dtABS.Merge(dt);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erreur lors du chargement : " + ex.Message, "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ الحل 2: إرجاع DataTable مباشرة بدلاً من Merge
        private DataTable chargement_pointage_journaliere(string matricule, DateTime date_jr, ref int nb_pointage)
        {
            // ✅ SQLite: استعلام بسيط بدون COUNT(*) مع أعمدة
            string query = @"SELECT MATRI, DATE_POINTAGE, HEURS_POINTAGE 
                             FROM CHARGEMENT_POITEUSE  
                             WHERE MATRI = @matricule 
                               AND DATE_POINTAGE >= @date_debut 
                               AND DATE_POINTAGE < @date_fin";

            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@matricule", matricule),
                new SqliteParameter("@date_debut", date_jr.Date.ToString("yyyy-MM-dd")),
                new SqliteParameter("@date_fin", date_jr.AddDays(1).Date.ToString("yyyy-MM-dd"))
            };

            try
            {
                DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

                // ✅ العدد = عدد الصفوف الفعلية
                nb_pointage = (dt != null) ? dt.Rows.Count : 0;

                // ✅ نرجع الجدول (فارغ إذا لم توجد بيانات)
                return dt ?? new DataTable();
            }
            catch (Exception ex)
            {
                nb_pointage = 0;
                XtraMessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }
        }

        private void chargement_donnee_pointage(string matri)
        {
            // ✅ هذه الدالة محفوظة للرجوع إليها لاحقاً إذا لزم
        }

        // ✅ تحميل جداول العمل باستخدام SQLite
        private void LoadHoraire_travail()
        {
            string query = "SELECT code, designation FROM HORAIRE_TRAVAIL ORDER BY designation";
            DataTable dt = ConnectSqlite.ExecuteSelect(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cb_horaire_travail.DisplayMember = "designation";
                cb_horaire_travail.ValueMember = "code";
                cb_horaire_travail.DataSource = dt;
                cb_horaire_travail.SelectedIndex = -1;
            }
        }

        private void cb_horaire_travail_SelectedIndexChanged(object sender, EventArgs e)
        {
            chargement_horaire_travail();
        }

        private void entet2_Scroll(object sender, ScrollEventArgs e)
        {
            if (tableau.Rows.Count > e.NewValue)
                tableau.FirstDisplayedScrollingRowIndex = e.NewValue;
        }

        private void entet2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tableau.Rows.Count > e.RowIndex)
                tableau.Rows[e.RowIndex].Selected = true;
        }

        private void tableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && entet2.Rows.Count > e.RowIndex)
            {
                entet2.CurrentCell = entet2.Rows[e.RowIndex].Cells[0];
                entet2.Rows[e.RowIndex].Selected = true;
            }
        }

        private void tableau_Scroll(object sender, ScrollEventArgs e)
        {
            if (entet2.Rows.Count > e.NewValue)
                entet2.FirstDisplayedScrollingRowIndex = e.NewValue;
        }

        public DataSet ds;
        public Reports.XtraReport_PointageJR XtraReport_PointageJR1 = new Reports.XtraReport_PointageJR();

        private void bt_imprimer_Click(object sender, EventArgs e)
        {
            Form2.fn_imprission = new Form_imprission();
            ds = new DataSet1();
            ds.Tables["dts_pointage"]?.Clear();

            for (int i = 0; i < entet2.Rows.Count; i++)
            {
                ds.Tables["dts_pointage"]?.Rows.Add(
                    GetCellValue(entet2, i, 0), GetCellValue(entet2, i, 1), GetCellValue(entet2, i, 2),
                    GetCellValue(entet2, i, 3), GetCellValue(entet2, i, 4), GetCellValue(entet2, i, 5),
                    GetCellValue(entet2, i, 6), GetCellValue(entet2, i, 7), GetCellValue(entet2, i, 8),
                    cb_structure.Text,
                    GetCellValue(tableau, i, 0), GetCellValue(tableau, i, 1),
                    date_jour.Value.ToString("d"),
                    date_jour.Value.ToString("MMMM", new System.Globalization.CultureInfo("ar-AR"))
                );
            }

            XtraReport_PointageJR1.DataSource = ds;
            XtraReport_PointageJR1.RequestParameters = false;

            if (Form2.fn_imprission?.documentViewer1 != null)
            {
                Form2.fn_imprission.documentViewer1.DocumentSource = XtraReport_PointageJR1;
                Form2.fn_imprission.ShowDialog();
            }
        }

        private string GetCellValue(DataGridView dgv, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgv.Rows.Count || colIndex < 0 || colIndex >= dgv.Columns.Count)
                return ".";

            var value = dgv.Rows[rowIndex].Cells[colIndex].Value;
            return value != null && value != DBNull.Value ? value.ToString() : ".";
        }

        // ✅ تحميل جدول العمل ليوم محدد باستخدام SQLite
        private void chargement_horaire_travail()
        {
            if (cb_horaire_travail.SelectedValue == null) return;

            string horaire_trv = cb_horaire_travail.SelectedValue.ToString();
            string s_horaire = "";

            string query = "SELECT Code, Designation, SAM, DIM, LUN, MAR, MER, JEU, VEN FROM HORAIRE_TRAVAIL WHERE code = @code";
            var parameters = new SqliteParameter[] { new SqliteParameter("@code", horaire_trv) };
            DataTable dt_horaire = ConnectSqlite.ExecuteSelect(query, parameters);

            if (dt_horaire != null && dt_horaire.Rows.Count > 0)
            {
                DataRow rowH = dt_horaire.Rows[0];
                string dayName = date_jour.Value.DayOfWeek.ToString();

                // ✅ الوصول الآمن للقيم
                switch (dayName)
                {
                    case "Friday": s_horaire = rowH["VEN"]?.ToString() ?? ""; break;
                    case "Monday": s_horaire = rowH["LUN"]?.ToString() ?? ""; break;
                    case "Saturday": s_horaire = rowH["SAM"]?.ToString() ?? ""; break;
                    case "Tuesday": s_horaire = rowH["MAR"]?.ToString() ?? ""; break;
                    case "Wednesday": s_horaire = rowH["MER"]?.ToString() ?? ""; break;
                    case "Thursday": s_horaire = rowH["JEU"]?.ToString() ?? ""; break;
                    case "Sunday": s_horaire = rowH["DIM"]?.ToString() ?? ""; break;
                }
            }

            // ✅ معالجة آمنة للأوقات
            hr_entree = TimeSpan.Zero;
            hr_sortie = TimeSpan.Zero;

            if (!string.IsNullOrEmpty(s_horaire) && s_horaire.Contains("-"))
            {
                string[] partie = s_horaire.Split('-');
                if (partie.Length >= 2)
                {
                    if (TimeSpan.TryParse(partie[0].Trim(), out TimeSpan parsedEntree))
                    {
                        hr_entree = parsedEntree;
                        if (entet2.Columns.Count > 1)
                            entet2.Columns[1].HeaderText = partie[0].Trim();
                    }
                    if (TimeSpan.TryParse(partie[1].Trim(), out TimeSpan parsedSortie))
                    {
                        hr_sortie = parsedSortie;
                        if (entet2.Columns.Count > 5)
                            entet2.Columns[5].HeaderText = partie[1].Trim();
                    }
                }
            }
        }

        private void date_jour_ValueChanged(object sender, EventArgs e)
        {
            cb_horaire_travail_SelectedIndexChanged(sender, e);
        }

        // ✅ دالة مساعدة لتحميل جدول العمل لتاريخ معين
        private void LoadHoraireForDate(DateTime date)
        {
            if (cb_horaire_travail.SelectedValue == null) return;

            string horaire_trv = cb_horaire_travail.SelectedValue.ToString();
            string s_horaire = "";

            string query = "SELECT SAM, DIM, LUN, MAR, MER, JEU, VEN FROM HORAIRE_TRAVAIL WHERE code = @code";
            var parameters = new SqliteParameter[] { new SqliteParameter("@code", horaire_trv) };
            DataTable dt_horaire = ConnectSqlite.ExecuteSelect(query, parameters);

            if (dt_horaire != null && dt_horaire.Rows.Count > 0)
            {
                DataRow rowH = dt_horaire.Rows[0];
                string dayName = date.DayOfWeek.ToString();

                switch (dayName)
                {
                    case "Friday": s_horaire = rowH["VEN"]?.ToString() ?? ""; break;
                    case "Monday": s_horaire = rowH["LUN"]?.ToString() ?? ""; break;
                    case "Saturday": s_horaire = rowH["SAM"]?.ToString() ?? ""; break;
                    case "Tuesday": s_horaire = rowH["MAR"]?.ToString() ?? ""; break;
                    case "Wednesday": s_horaire = rowH["MER"]?.ToString() ?? ""; break;
                    case "Thursday": s_horaire = rowH["JEU"]?.ToString() ?? ""; break;
                    case "Sunday": s_horaire = rowH["DIM"]?.ToString() ?? ""; break;
                }
            }

            hr_entree = TimeSpan.Zero;
            hr_sortie = TimeSpan.Zero;

            if (!string.IsNullOrEmpty(s_horaire) && s_horaire.Contains("-"))
            {
                string[] partie = s_horaire.Split('-');
                if (partie.Length >= 2)
                {
                    TimeSpan.TryParse(partie[0].Trim(), out hr_entree);
                    TimeSpan.TryParse(partie[1].Trim(), out hr_sortie);
                }
            }
        }
    }
}