using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite
using System.Collections.Generic;

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
            if (cb_horaire_travail.Items.Count > 0)
                cb_horaire_travail.SelectedIndex = 0;
            // ✅ تهيئة DataGridViews
            ConfigureDataGridView(tableau);
            ConfigureDataGridView(entet2);
        }

        // ✅ منع الفرز: الشبكتان مرتبطتان بالفهرس، و الفرز يفسد المطابقة بين الاسم و التمريرات
        private void ConfigureDataGridView(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            if (string.IsNullOrEmpty(matricule))
            {
                lb_nom_prenom.Text = "";
                lb_nom_prenom.Visible = false;
                return;
            }

            string query = "SELECT nom, prenom FROM Personnel WHERE matricule = @matricule";
            var parameters = new SqliteParameter[] { new SqliteParameter("@matricule", matricule) };
            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lb_nom_prenom.Text = $"{row["nom"]} {row["prenom"]}".Trim();
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
                e.SuppressKeyPress = true;   // بدون صوت التنبيه
                bt_apercu.Focus();           // نقل التركيز => Leave مرة واحدة فقط
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
            entet2.Rows.Clear();           // ✅ لا تبقى صفوف قديمة عند أي توقف مبكر
            DataTable dtPersonnel = null;

            // ✅ تحقق: جدول العمل مختار؟ (بدونه تُتجاهل كل التمريرات)
            if (cb_horaire_travail.SelectedValue == null)
            {
                XtraMessageBox.Show("الرجاء اختيار جدول العمل", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ تحقق: نوع القائمة مختار؟
            if (!ch_structure.Checked && !ch_matricule.Checked && !ch_tous.Checked)
            {
                XtraMessageBox.Show("الرجاء اختيار: الكل أو هيكل أو مصفوفة", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ch_structure.Checked)
            {
                if (cb_structure.SelectedIndex == -1)
                {
                    XtraMessageBox.Show("الرجاء اختيار الهيكل", "تنبيه",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string c_affect = cb_structure.SelectedValue?.ToString() ?? "";

                // ✅ SQLite: استخدام || للدمج و IFNULL بدلاً من ISNULL
                string query = @"SELECT matricule, IFNULL(nom, '') || ' ' || IFNULL(prenom, '') as nom 
                                FROM Personnel WHERE id_affectation = @c_affect and LOWER(TRIM(IFNULL(type_agent, ''))) != 'bloque' ORDER BY nom";
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
                                FROM Personnel where LOWER(TRIM(IFNULL(type_agent, ''))) != 'bloque' ORDER BY nom";
                dtPersonnel = ConnectSqlite.ExecuteSelect(query);
            }

            if (dtPersonnel == null || dtPersonnel.Rows.Count == 0)
            {
                XtraMessageBox.Show("لا يوجد موظفون مطابقون", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtPersonnel != null)
            {
                tableau.DataSource = dtPersonnel;
                if (tableau.Columns.Contains("nom"))
                {
                    tableau.Columns["nom"].Width = 250;
                    tableau.Columns["nom"].HeaderText = "الاسم واللقب";
                }
                ConfigureDataGridView(tableau);
            }

            //new code 
            // ✅ معالجة بيانات الحضور لكل موظف
            entet2.Rows.Clear();
            DateTime date_jour = this.date_jour.Value.Date;

            // ✅ جدول العمل ثابت لكل القائمة: يُجلب مرة واحدة خارج الحلقة
            LoadHoraireForDate(date_jour);

            // ✅ كل تمريرات اليوم و كل غياباته دفعة واحدة (استعلامان بدل استعلامين لكل موظف)
            Dictionary<string, List<TimeSpan>> pointages = ChargerPointagesDuJour(date_jour);
            Dictionary<string, string> absences = ChargerAbsencesDuJour(date_jour);

            // ✅ عطلة رسمية في هذا اليوم؟ (استعلام واحد)
            string libFerie = ChargerFerieDuJour(date_jour);

            // ✅ آخر يوم تم تحميل تمريراته: لا نعلّم "Absent" إلا على الأيام التي سبقته
            DateTime derniereDate = ChargerDerniereDatePointage();

            // ✅ الموظفون غير الملزمين بالتمرير (poinatge = Non): لا "Absent" عليهم
            HashSet<string> nonSoumis = ChargerNonSoumis();

            // يوم عمل = له ساعات في الجدول المختار و ليس الجمعة أو السبت
            bool jourTravaille = hr_entree > TimeSpan.Zero && hr_sortie > TimeSpan.Zero
                                 && date_jour.DayOfWeek != DayOfWeek.Friday
                                 && date_jour.DayOfWeek != DayOfWeek.Saturday;
            bool peutMarquerAbsent = jourTravaille && libFerie == null
                                     && date_jour < DateTime.Today && date_jour < derniereDate;

            foreach (DataGridViewRow row in tableau.Rows)
            {
                if (row.IsNewRow) continue;

                string matricule = row.Cells[0].Value?.ToString()?.Trim();
                if (string.IsNullOrEmpty(matricule)) continue;

                // ✅ إضافة صف جديد في entet2
                int entetIndex = entet2.Rows.Add();
                DataGridViewRow entetRow = entet2.Rows[entetIndex];

                // ✅ أوقات الجدول المطبَّق: تظهر في الشبكة و في التقرير المطبوع
                if (hr_entree > TimeSpan.Zero) entetRow.Cells[1].Value = hr_entree.ToString(@"hh\:mm");
                if (hr_sortie > TimeSpan.Zero) entetRow.Cells[5].Value = hr_sortie.ToString(@"hh\:mm");

                int position = 3;            // الخانتان 3 و 4 فقط للتمريرات الوسطية
                bool entreeFaite = false;

                // ✅ معالجة البصمات (مرتّبة حسب الساعة)
                List<TimeSpan> liste;
                if (pointages.TryGetValue(matricule, out liste))
                {
                    foreach (TimeSpan hr_pointage in liste)
                    {
                        if (hr_pointage <= hr_entree)
                        {
                            // دخول في الوقت أو قبله: نحتفظ بأول تمريرة
                            if (!entreeFaite)
                            {
                                entetRow.Cells[0].Value = hr_pointage.ToString(@"hh\:mm");
                                entreeFaite = true;
                            }
                        }
                        else if (hr_sortie > TimeSpan.Zero && hr_pointage >= hr_sortie)
                        {
                            // خروج: آخر تمريرة هي التي تبقى
                            entetRow.Cells[6].Value = hr_pointage.ToString(@"hh\:mm");

                            double extra = (hr_pointage - hr_sortie).TotalMinutes;
                            entetRow.Cells[7].Value = extra >= RibbonForm1.plage_hrs
                                ? TimeSpan.FromMinutes(extra).ToString(@"hh\:mm")
                                : null;
                        }
                        else if (hr_entree > TimeSpan.Zero)
                        {
                            // بين الدخول و الخروج
                            double retard = (hr_pointage - hr_entree).TotalMinutes;

                            if (!entreeFaite && retard <= RibbonForm1.plage_retards)
                            {
                                entetRow.Cells[0].Value = hr_pointage.ToString(@"hh\:mm");
                                entetRow.Cells[2].Value = retard.ToString("0");
                                entreeFaite = true;
                            }
                            else if (position <= 4)
                            {
                                entetRow.Cells[position].Value = hr_pointage.ToString(@"hh\:mm");
                                position++;
                            }
                        }
                    }
                }

                // ✅ الغيابات و العطل
                string obs;
                bool aAbsence = absences.TryGetValue(matricule, out obs);

                if (libFerie != null)
                {
                    // عطلة رسمية: كل الصفوف خضراء، و تُضاف إليها الإجازة إن وجدت
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 200);
                    entetRow.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 200);
                    string texteFerie = "Férié : " + libFerie;
                    entetRow.Cells[8].Value = aAbsence ? texteFerie + " | " + obs : texteFerie;
                }
                else if (aAbsence)
                {
                    entetRow.Cells[8].Value = obs;
                }
                else if (peutMarquerAbsent && !pointages.ContainsKey(matricule) && !nonSoumis.Contains(matricule))
                {
                    // يوم عمل مضى، بلا تمريرة و بلا غياب مبرَّر
                    entetRow.Cells[8].Value = "Absent";
                    entetRow.Cells[8].Style.ForeColor = Color.Red;
                }
            }

            // ✅ نحفظ معطيات هذه المعاينة: الطباعة تعتمد عليها لا على الحقول الحالية
            dateApercu = date_jour;
            structureApercu = ch_structure.Checked ? cb_structure.Text : "";
        }
        // ✅ اسم العطلة الرسمية في هذا اليوم (null إن لم يكن عطلة)
        private string ChargerFerieDuJour(DateTime date_jr)
        {
            DataTable dt = ConnectSqlite.ExecuteSelect(
                "SELECT LIB FROM JOUR_FERIE WHERE DATE_F >= @d1 AND DATE_F < @d2",
                new SqliteParameter("@d1", date_jr.Date.ToString("yyyy-MM-dd")),
                new SqliteParameter("@d2", date_jr.AddDays(1).Date.ToString("yyyy-MM-dd")));

            if (dt.Rows.Count == 0) return null;

            string lib = dt.Rows[0]["LIB"]?.ToString()?.Trim();
            return string.IsNullOrEmpty(lib) ? "Jour férié" : lib;
        }

        // ✅ آخر تاريخ تمريرات محمَّل في الجدول (MinValue إن كان الجدول فارغاً)
        private DateTime ChargerDerniereDatePointage()
        {
            DataTable dt = ConnectSqlite.ExecuteSelect(
                "SELECT MAX(DATE_POINTAGE) AS d FROM CHARGEMENT_POITEUSE");

            DateTime dm;
            if (dt.Rows.Count > 0 && DateTime.TryParse(dt.Rows[0]["d"]?.ToString(), out dm))
                return dm.Date;

            return DateTime.MinValue;
        }

        // ✅ ماتريكول الموظفين غير الملزمين بالتمرير (poinatge = Non)
        private HashSet<string> ChargerNonSoumis()
        {
            var res = new HashSet<string>();

            DataTable dt = ConnectSqlite.ExecuteSelect(
                "SELECT matricule FROM Personnel WHERE LOWER(TRIM(IFNULL(poinatge, ''))) = 'non'");

            foreach (DataRow r in dt.Rows)
            {
                string m = r["matricule"]?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(m)) res.Add(m);
            }
            return res;
        }

        // ✅ تمريرات اليوم لكل الموظفين في استعلام واحد: ماتريكول => أوقات مرتبة
        private Dictionary<string, List<TimeSpan>> ChargerPointagesDuJour(DateTime date_jr)
        {
            var res = new Dictionary<string, List<TimeSpan>>();

            DataTable dt = ConnectSqlite.ExecuteSelect(
                @"SELECT MATRI, HEURS_POINTAGE
                  FROM CHARGEMENT_POITEUSE
                  WHERE DATE_POINTAGE >= @debut AND DATE_POINTAGE < @fin
                  ORDER BY MATRI, DATE_POINTAGE, HEURS_POINTAGE",
                new SqliteParameter("@debut", date_jr.Date.ToString("yyyy-MM-dd")),
                new SqliteParameter("@fin", date_jr.AddDays(1).Date.ToString("yyyy-MM-dd")));

            foreach (DataRow r in dt.Rows)
            {
                string matri = r["MATRI"]?.ToString()?.Trim();
                if (string.IsNullOrEmpty(matri)) continue;

                TimeSpan h;
                if (!TimeSpan.TryParse(r["HEURS_POINTAGE"]?.ToString()?.Trim(), out h)) continue;

                List<TimeSpan> liste;
                if (!res.TryGetValue(matri, out liste))
                {
                    liste = new List<TimeSpan>();
                    res[matri] = liste;
                }
                liste.Add(h);
            }
            return res;
        }

        // ✅ غيابات اليوم لكل الموظفين في استعلام واحد: ماتريكول => نص الملاحظة (يجمع عدة سجلات)
        private Dictionary<string, string> ChargerAbsencesDuJour(DateTime date_jr)
        {
            var res = new Dictionary<string, string>();

            DataTable dt = ConnectSqlite.ExecuteSelect(
                @"SELECT A.MATRI, T.LIB, A.OBS
                  FROM [ABS] A
                  INNER JOIN [type_conge] T ON A.C_CONGE = T.CODE
                  WHERE DATE(A.DATE1) <= @date_jr
                    AND DATE(COALESCE(NULLIF(A.DATE2, ''), A.DATE1)) >= @date_jr
                  ORDER BY A.MATRI, A.H_DEBUT",
                new SqliteParameter("@date_jr", date_jr.Date.ToString("yyyy-MM-dd")));

            foreach (DataRow r in dt.Rows)
            {
                string matri = r["MATRI"]?.ToString()?.Trim();
                string lib = r["LIB"]?.ToString()?.Trim();
                if (string.IsNullOrEmpty(matri) || string.IsNullOrEmpty(lib)) continue;

                string obs = r["OBS"]?.ToString()?.Trim();
                string texte = string.IsNullOrEmpty(obs) ? lib : lib + " " + obs;

                string existant;
                res[matri] = res.TryGetValue(matri, out existant) ? existant + " | " + texte : texte;
            }
            return res;
        }
        //fin new code 
        //    // ✅ معالجة بيانات الحضور لكل موظف
        //    entet2.Rows.Clear();
        //    DateTime date_jour = this.date_jour.Value.Date;

        //    // ✅ جدول العمل ثابت لكل القائمة: يُجلب مرة واحدة خارج الحلقة
        //    LoadHoraireForDate(date_jour);

        //    foreach (DataGridViewRow row in tableau.Rows)
        //    {
        //        if (row.IsNewRow) continue;

        //        string matricule = row.Cells[0].Value?.ToString()?.Trim();
        //        if (string.IsNullOrEmpty(matricule)) continue;

        //        // ✅ إضافة صف جديد في entet2
        //        int entetIndex = entet2.Rows.Add();
        //        DataGridViewRow entetRow = entet2.Rows[entetIndex];

        //        // ✅ أوقات الجدول المطبَّق: تظهر في الشبكة و في التقرير المطبوع
        //        if (hr_entree > TimeSpan.Zero) entetRow.Cells[1].Value = hr_entree.ToString(@"hh\:mm");
        //        if (hr_sortie > TimeSpan.Zero) entetRow.Cells[5].Value = hr_sortie.ToString(@"hh\:mm");

        //        // ✅ جلب بصمات الموظف - الحل 2: إرجاع DataTable مباشرة
        //        int nbr_poitage = 0;
        //        DataTable dtJ = chargement_pointage_journaliere(matricule, date_jour, ref nbr_poitage);

        //        //int position = 3;

        //        //// ✅ معالجة البصمات بأمان
        //        //if (nbr_poitage > 0 && dtJ != null && dtJ.Rows.Count > 0)
        //        //{
        //        //    for (int j = 0; j < nbr_poitage && j < dtJ.Rows.Count; j++)
        //        //    {
        //        //        string heureStr = dtJ.Rows[j]["HEURS_POINTAGE"]?.ToString()?.Trim();

        //        //        if (!TimeSpan.TryParse(heureStr, out TimeSpan hr_pointage))
        //        //            continue;

        //        //        if (hr_pointage <= hr_entree)
        //        //        {
        //        //            entetRow.Cells[0].Value = hr_pointage.ToString();
        //        //        }
        //        //        else if (hr_pointage >= hr_sortie && hr_sortie > TimeSpan.Zero)
        //        //        {
        //        //            entetRow.Cells[6].Value = hr_pointage.ToString();
        //        //            if ((hr_pointage - hr_sortie).TotalMinutes >= RibbonForm1.plage_hrs)
        //        //            {
        //        //                double heuresSupp = hr_pointage.TotalMinutes - hr_sortie.TotalMinutes;
        //        //                entetRow.Cells[7].Value = TimeSpan.FromMinutes(heuresSupp).ToString();
        //        //            }
        //        //        }
        //        //        else if (hr_entree > TimeSpan.Zero && hr_pointage >= hr_entree && hr_pointage <= hr_sortie)
        //        //        {
        //        //            double retardMinutes = (hr_pointage - hr_entree).TotalMinutes;
        //        //            if (retardMinutes <=    RibbonForm1.plage_retards)
        //        //            {
        //        //                entetRow.Cells[0].Value = hr_pointage.ToString();
        //        //                entetRow.Cells[2].Value = retardMinutes.ToString("0");
        //        //            }
        //        //            else
        //        //            {
        //        //                if (position < entetRow.Cells.Count)
        //        //                {
        //        //                    entetRow.Cells[position].Value = hr_pointage.ToString();
        //        //                    position++;
        //        //                }
        //        //            }
        //        //        }
        //        //    }
        //        //}

        //        int position = 3;            // الخانتان 3 و 4 فقط للتمريرات الوسطية
        //        bool entreeFaite = false;

        //        // ✅ معالجة البصمات (مرتّبة حسب الساعة)
        //        if (dtJ != null)
        //        {
        //            foreach (DataRow pr in dtJ.Rows)
        //            {
        //                if (!TimeSpan.TryParse(pr["HEURS_POINTAGE"]?.ToString()?.Trim(), out TimeSpan hr_pointage))
        //                    continue;

        //                if (hr_pointage <= hr_entree)
        //                {
        //                    // دخول في الوقت أو قبله: نحتفظ بأول تمريرة
        //                    if (!entreeFaite)
        //                    {
        //                        entetRow.Cells[0].Value = hr_pointage.ToString(@"hh\:mm");
        //                        entreeFaite = true;
        //                    }
        //                }
        //                else if (hr_sortie > TimeSpan.Zero && hr_pointage >= hr_sortie)
        //                {
        //                    // خروج: آخر تمريرة هي التي تبقى
        //                    entetRow.Cells[6].Value = hr_pointage.ToString(@"hh\:mm");

        //                    double extra = (hr_pointage - hr_sortie).TotalMinutes;
        //                    entetRow.Cells[7].Value = extra >= RibbonForm1.plage_hrs
        //                        ? TimeSpan.FromMinutes(extra).ToString(@"hh\:mm")
        //                        : null;
        //                }
        //                else if (hr_entree > TimeSpan.Zero)
        //                {
        //                    // بين الدخول و الخروج
        //                    double retard = (hr_pointage - hr_entree).TotalMinutes;

        //                    if (!entreeFaite && retard <= RibbonForm1.plage_retards)
        //                    {
        //                        entetRow.Cells[0].Value = hr_pointage.ToString(@"hh\:mm");
        //                        entetRow.Cells[2].Value = retard.ToString("0");
        //                        entreeFaite = true;
        //                    }
        //                    else if (position <= 4)
        //                    {
        //                        entetRow.Cells[position].Value = hr_pointage.ToString(@"hh\:mm");
        //                        position++;
        //                    }
        //                }
        //            }
        //        }

        //        // ✅ معالجة الغيابات
        //        DataTable dtABS = new DataTable();
        //        LoadAbsences(matricule, date_jour, dtABS);

        //        if (dtABS.Rows.Count > 0 && dtABS.Rows[0]["lib"] != DBNull.Value)
        //        {
        //            string lib_conge = dtABS.Rows[0]["lib"].ToString() +" "+ dtABS.Rows[0]["OBS"].ToString();
        //            if (!string.IsNullOrEmpty(lib_conge))
        //            {
        //                // ✅ التأكد من وجود العمود قبل التعيين
        //                if (entetRow.Cells.Count > 10)
        //                    entetRow.Cells[8].Value = lib_conge;
        //            }
        //        }
        //    }
        //}

        // ✅ تحميل الغيابات باستخدام SQLite
        private void LoadAbsences(string matricule, DateTime date_jr, DataTable dtABS)
        {
            try
            {
                if (string.IsNullOrEmpty(matricule)) return;

                string query = @"SELECT A.C_CONGE, T.LIB , A.OBS
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
                               AND DATE_POINTAGE < @date_fin
                                ORDER BY DATE_POINTAGE, HEURS_POINTAGE";

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

            cb_horaire_travail.DisplayMember = "designation";
            cb_horaire_travail.ValueMember = "code";
            cb_horaire_travail.DataSource = dt;      // حتى لو فارغ: يمسح "Oui/Non" الثابتين
            cb_horaire_travail.SelectedIndex = -1;
        }

        private void cb_horaire_travail_SelectedIndexChanged(object sender, EventArgs e)
        {
            chargement_horaire_travail();
        }

        private void entet2_Scroll(object sender, ScrollEventArgs e)
        {
            int idx = entet2.FirstDisplayedScrollingRowIndex;
            if (idx >= 0 && idx < tableau.Rows.Count && tableau.FirstDisplayedScrollingRowIndex != idx)
                tableau.FirstDisplayedScrollingRowIndex = idx;
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
            int idx = tableau.FirstDisplayedScrollingRowIndex;
            if (idx >= 0 && idx < entet2.Rows.Count && entet2.FirstDisplayedScrollingRowIndex != idx)
                entet2.FirstDisplayedScrollingRowIndex = idx;
        }

        public DataSet ds;
        // ✅ معطيات آخر معاينة (الطباعة تعتمد عليها)
        private DateTime dateApercu;
        private string structureApercu = "";
        private void bt_imprimer_Click(object sender, EventArgs e)
        {
            // ✅ لا طباعة قبل معاينة
            if (entet2.Rows.Count == 0)
            {
                XtraMessageBox.Show("الرجاء إجراء معاينة أولاً", "تنبيه",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ds = new DataSet1();
            ds.Tables["dts_pointage"]?.Clear();

            for (int i = 0; i < entet2.Rows.Count; i++)
            {
                ds.Tables["dts_pointage"]?.Rows.Add(
                    GetCellValue(entet2, i, 0), GetCellValue(entet2, i, 1), GetCellValue(entet2, i, 2),
                    GetCellValue(entet2, i, 3), GetCellValue(entet2, i, 4), GetCellValue(entet2, i, 5),
                    GetCellValue(entet2, i, 6), GetCellValue(entet2, i, 7), GetCellValue(entet2, i, 8),
                    structureApercu,
                    GetCellValue(tableau, i, 0), GetCellValue(tableau, i, 1),
                    dateApercu.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    dateApercu.ToString("MMMM", System.Globalization.CultureInfo.GetCultureInfo("fr-FR"))
                );
            }

            
            // ✅ تقرير جديد في كل مرة
            var report = new Reports.XtraReport_PointageJR();
            report.DataSource = ds;
            report.RequestParameters = false;

            // ✅ نافذة طباعة جديدة أيضاً
            using (var frm = new Form_imprission())
            {
                RibbonForm1.fn_imprission = frm;
                frm.documentViewer1.DocumentSource = report;
                report.CreateDocument();           // يفرض إعادة بناء المستند بالبيانات الحالية
                frm.ShowDialog();
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
            hr_entree = TimeSpan.Zero;
            hr_sortie = TimeSpan.Zero;
            if (entet2.Columns.Count > 5)
            {
                entet2.Columns[1].HeaderText = "Entrée prév.";
                entet2.Columns[5].HeaderText = "Sortie prév.";
            }
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
            hr_entree = TimeSpan.Zero;
            hr_sortie = TimeSpan.Zero;
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