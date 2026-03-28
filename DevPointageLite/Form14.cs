using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace DevPointageLite
{
    public partial class Form14 : DevExpress.XtraEditors.XtraForm
    {
        public TimeSpan hr_entree, hr_sortie;

        public Form14()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            txt_annee.Text = Form2.annee_en_cours;
            ActiveControl = txt_matricule;
            liste_mois.SelectedIndex = DateTime.Now.Month - 1;

            // ✅ تهيئة DataGridView entet2
            InitializeEntet2Grid();
        }

        // ✅ دالة لتهيئة شبكة entet2 (تجنب أخطاء القيود)
        private void InitializeEntet2Grid()
        {
            entet2.AllowUserToAddRows = false;
            entet2.AllowUserToDeleteRows = false;
            entet2.ReadOnly = true;
            //entet2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           // entet2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ✅ السماح بقيم null في الخلايا
            foreach (DataGridViewColumn col in entet2.Columns)
            {
                col.DefaultCellStyle.NullValue = null;
            }
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
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            // ✅ تفريغ entet2 بشكل آمن
            entet2.Rows.Clear();
        }

        private void txt_matricule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_matricule_Leave(sender, e);
            }
        }

        private void Vue_Pointage_mensuelle(string matri)
        {
            if (liste_mois.SelectedIndex == -1)
            {
                XtraMessageBox.Show("الرجاء اختيار الشهر.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_annee.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال السنة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int mois = liste_mois.SelectedIndex + 1;
            string annee = txt_annee.Text.Trim();

            string query = @"
                SELECT LeJour, JourSemaine, HeureEntree, HeureSortie
                FROM Vue_Pointage_mensuelle 
                WHERE MATRI = @matri 
                  AND strftime('%m', LeJour) = @mois 
                  AND strftime('%Y', LeJour) = @annee
                ORDER BY LeJour";

            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@matri", matri),
                new SqliteParameter("@mois", mois.ToString("D2")),
                new SqliteParameter("@annee", annee)
            };

            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);
            dataGridView1.DataSource = dt;

            // ✅ تنسيق الأعمدة
            if (dataGridView1.Columns.Contains("LeJour"))
                dataGridView1.Columns["LeJour"].HeaderText = "التاريخ";
            if (dataGridView1.Columns.Contains("JourSemaine"))
                dataGridView1.Columns["JourSemaine"].HeaderText = "اليوم";
            if (dataGridView1.Columns.Contains("HeureEntree"))
                dataGridView1.Columns["HeureEntree"].HeaderText = "وقت الدخول";
            if (dataGridView1.Columns.Contains("HeureSortie"))
                dataGridView1.Columns["HeureSortie"].HeaderText = "وقت الخروج";
        }

        private void chargement_donnee_pointage_mensuelle(string matri)
        {
            Vue_Pointage_mensuelle(matri);

            // ✅ تفريغ الشبكة
            entet2.Rows.Clear();

            int nbr_jour = DateTime.DaysInMonth(Convert.ToInt32(txt_annee.Text.Trim()), liste_mois.SelectedIndex + 1);

            for (int i = 1; i <= nbr_jour; i++)
            {
                int rowIndex = entet2.Rows.Add();
                DataGridViewRow row = entet2.Rows[rowIndex];

                row.Cells[1].Value = i.ToString();

                DateTime d_jour = new DateTime(Convert.ToInt32(txt_annee.Text.Trim()), liste_mois.SelectedIndex + 1, i);

                var result = get_personnel_emploi_code(txt_matricule.Text, d_jour);

                if (string.IsNullOrWhiteSpace(result?.ToString()))
                {
                    row.Cells[0].Value = "غير محدد";
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    continue;
                }

                string horaire_trv = result.ToString().Trim();
                row.Cells[0].Value = horaire_trv;

                string s_horaire = "";
                DataTable dt_horaire = get_horaire_travail(horaire_trv);

                if (dt_horaire != null && dt_horaire.Rows.Count > 0)
                {
                    DataRow rowH = dt_horaire.Rows[0];
                    string dayName = d_jour.DayOfWeek.ToString();

                    switch (dayName)
                    {
                        case "Friday":
                            s_horaire = rowH["VEN"]?.ToString() ?? "";
                            row.DefaultCellStyle.BackColor = SystemColors.ActiveBorder;
                            break;
                        case "Monday":
                            s_horaire = rowH["LUN"]?.ToString() ?? "";
                            break;
                        case "Saturday":
                            s_horaire = rowH["SAM"]?.ToString() ?? "";
                            row.DefaultCellStyle.BackColor = SystemColors.ActiveBorder;
                            break;
                        case "Tuesday":
                            s_horaire = rowH["MAR"]?.ToString() ?? "";
                            break;
                        case "Wednesday":
                            s_horaire = rowH["MER"]?.ToString() ?? "";
                            break;
                        case "Thursday":
                            s_horaire = rowH["JEU"]?.ToString() ?? "";
                            break;
                        case "Sunday":
                            s_horaire = rowH["DIM"]?.ToString() ?? "";
                            break;
                    }
                }

                // ✅ معالجة آمنة للأوقات - استخدام null بدلاً من DBNull.Value
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
                            row.Cells[3].Value = partie[0].Trim(); // ✅ لا نستخدم DBNull
                        }
                        else
                        {
                            row.Cells[3].Value = null; // ✅ استخدام null بدلاً من DBNull.Value
                        }

                        if (TimeSpan.TryParse(partie[1].Trim(), out TimeSpan parsedSortie))
                        {
                            hr_sortie = parsedSortie;
                            row.Cells[7].Value = partie[1].Trim(); // ✅ لا نستخدم DBNull
                        }
                        else
                        {
                            row.Cells[7].Value = null; // ✅ استخدام null بدلاً من DBNull.Value
                        }
                    }
                }
                else
                {
                    row.Cells[3].Value = null; // ✅
                    row.Cells[7].Value = null; // ✅
                }

                // ✅ نقطة الحضور اليومية
                TimeSpan hr_pointage = TimeSpan.Zero;
                int nbr_poitage = 0;

                DataTable dtJ = chargement_pointage_journaliere(matri, d_jour, ref nbr_poitage);

                int position = 5;

                if (nbr_poitage > 0 && dtJ != null && dtJ.Rows.Count > 0)
                {
                    for (int j = 0; j < nbr_poitage && j < dtJ.Rows.Count; j++)
                    {
                        string heureStr = dtJ.Rows[j]["heurs_pointage"]?.ToString()?.Trim();

                        if (!TimeSpan.TryParse(heureStr, out hr_pointage))
                        {
                            continue;
                        }

                        if (hr_pointage <= hr_entree)
                        {
                            row.Cells[2].Value = hr_pointage.ToString();
                        }
                        else if (hr_pointage >= hr_sortie && hr_sortie > TimeSpan.Zero)
                        {
                            row.Cells[8].Value = hr_pointage.ToString();
                            if ((hr_pointage - hr_sortie).Minutes >= Form2.plage_hrs)
                            {
                                double heuresSupp = hr_pointage.TotalMinutes - hr_sortie.TotalMinutes;
                                row.Cells[9].Value = TimeSpan.FromMinutes(heuresSupp).ToString();
                            }
                        }
                        else if (hr_entree > TimeSpan.Zero && hr_pointage >= hr_entree && hr_pointage <= hr_sortie)
                        {
                            double retardMinutes = (hr_pointage - hr_entree).TotalMinutes;
                            if (retardMinutes <= Form2.plage_retards)
                            {
                                row.Cells[2].Value = hr_pointage.ToString();
                                row.Cells[4].Value = retardMinutes.ToString("0");
                            }
                            else
                            {
                                if (position < row.Cells.Count)
                                {
                                    row.Cells[position].Value = hr_pointage.ToString();
                                    position++;
                                }
                            }
                        }
                    }
                }

                // ✅ الغيابات - معالجة آمنة
                DataTable dtABS = new DataTable();
                LoadAbsences(matri, d_jour, dtABS);

                if (dtABS.Rows.Count > 0 && dtABS.Rows[0]["lib"] != null && dtABS.Rows[0]["lib"] != DBNull.Value)
                {
                    string lib_conge = dtABS.Rows[0]["lib"].ToString();
                    if (!string.IsNullOrEmpty(lib_conge))
                    {
                        row.Cells[10].Value = lib_conge;
                    }
                    else
                    {
                        row.Cells[10].Value = null; // ✅ لا نستخدم DBNull
                    }
                }
                else
                {
                    row.Cells[10].Value = null; // ✅
                }
            }
        }

        private DataTable get_horaire_travail(string code)
        {
            string query = @"SELECT Code, Designation, SAM, DIM, LUN, MAR, MER, JEU, VEN 
                            FROM HORAIRE_TRAVAIL 
                            WHERE code = @code";

            var parameters = new SqliteParameter[] { new SqliteParameter("@code", code) };
            return ConnectSqlite.ExecuteSelect(query, parameters);
        }

        private string get_personnel_emploi_code(string matricule, DateTime date_jr)
        {
            if (string.IsNullOrEmpty(matricule)) return "";

            string query = @"SELECT code FROM Personnel_emploi_temps 
                            WHERE matri = @matricule 
                            AND @date_jr >= date_du AND @date_jr <= date_au";

            var parameters = new SqliteParameter[]
            {
                new SqliteParameter("@matricule", matricule),
                new SqliteParameter("@date_jr", date_jr.Date.ToString("yyyy-MM-dd"))
            };

            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);
            return (dt.Rows.Count > 0 && dt.Rows[0]["code"] != DBNull.Value)
                ? dt.Rows[0]["code"].ToString()
                : "";
        }

        private void bt_apercu_Click(object sender, EventArgs e)
        {
            string matricule = txt_matricule.Text.Trim();
            if (string.IsNullOrEmpty(matricule))
            {
                XtraMessageBox.Show("الرجاء إدخال الرقم الوظيفي (الماتريكول).", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_matricule.Focus();
                return;
            }
            chargement_donnee_pointage_mensuelle(matricule);
        }

        //private void chargement_pointage_journaliere(string matricule, DateTime date_jr, ref int nb_pointage, DataTable dtJ)
        //{
        //    string query = @"SELECT COUNT(*) as total_count, MATRI, DATE_POINTAGE, HEURS_POINTAGE 
        //             FROM CHARGEMENT_POITEUSE  
        //             WHERE MATRI = @matricule 
        //               AND DATE_POINTAGE >= @date_debut 
        //               AND DATE_POINTAGE < @date_fin";

        //    var parameters = new SqliteParameter[]
        //    {
        //        new SqliteParameter("@matricule", matricule),
        //        new SqliteParameter("@date_debut", date_jr.Date.ToString("yyyy-MM-dd")),
        //        new SqliteParameter("@date_fin", date_jr.AddDays(1).Date.ToString("yyyy-MM-dd"))
        //    };

        //    DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

        //    if (dt.Rows.Count > 0)
        //    {
        //        dtJ.Merge(dt);
        //        if (dt.Rows[0]["total_count"] != DBNull.Value)
        //        {
        //            nb_pointage = Convert.ToInt32(dt.Rows[0]["total_count"]);
        //        }
        //    }
        //}
        private DataTable chargement_pointage_journaliere(string matricule, DateTime date_jr, ref int nb_pointage)
        {
            // ✅ استعلام واحد بدون COUNT - نجلب كل البيانات
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

            DataTable dt = ConnectSqlite.ExecuteSelect(query, parameters);

            // ✅ العدد هو عدد الصفوف الفعلية
            nb_pointage = (dt != null) ? dt.Rows.Count : 0;

            // ✅ نرجع الجدول كما هو (فارغ إذا لم توجد بيانات)
            return dt ?? new DataTable();
        }


        public DataSet ds;
        public Reports.XtraReport_PointageM XtraReport_PointageM1 = new Reports.XtraReport_PointageM();

        private void bt_imprimer_Click(object sender, EventArgs e)
        {
            Form2.fn_imprission = new Form_imprission();
            ds = new DataSet1();
            ds.Tables["dts_pointage"]?.Clear();

            for (int i = 0; i < entet2.Rows.Count; i++)
            {
                ds.Tables["dts_pointage"]?.Rows.Add(
                    GetCellValue(entet2, i, 1), GetCellValue(entet2, i, 2), GetCellValue(entet2, i, 3),
                    GetCellValue(entet2, i, 4), GetCellValue(entet2, i, 5), GetCellValue(entet2, i, 6),
                    GetCellValue(entet2, i, 7), GetCellValue(entet2, i, 8), GetCellValue(entet2, i, 9),
                    GetCellValue(entet2, i, 10), txt_matricule.Text, lb_nom_prenom.Text,
                    liste_mois.SelectedItem?.ToString() ?? "", txt_annee.Text
                );
            }

            XtraReport_PointageM1.DataSource = ds;
            XtraReport_PointageM1.RequestParameters = false;

            if (Form2.fn_imprission?.documentViewer1 != null)
            {
                Form2.fn_imprission.documentViewer1.DocumentSource = XtraReport_PointageM1;
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

        private void entet2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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
    }
}