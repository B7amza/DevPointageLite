using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using zkemkeeper;             // ✅ مكتبة جهاز البصمة (تبقى كما هي)

namespace DevPointageLite
{
    public partial class Form4 : XtraForm
    {
        private CZKEM zkDevice = new CZKEM(); // ✅ كائن الاتصال بالجهاز

        public Form4()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                // ✅ تحميل قائمة الأجهزة النشطة من قاعدة البيانات
                string query = "SELECT * FROM POINTEUSE WHERE etat = 'O' ORDER BY ADRESSE_IP";
                DataTable dt = ConnectSqlite.ExecuteSelect(query);

                // ✅ ربط البيانات بـ DataGridView (Windows Forms)
                tableau.DataSource = dt;

                // ✅ تنسيق الشبكة - DataGridView (Windows Forms) 🎯
               // tableau.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                tableau.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //tableau.ReadOnly = true;                    // ✅ منع التعديل المباشر
                tableau.AllowUserToAddRows = false;         // ✅ إخفاء الصف الجديد الفارغ
                tableau.AllowUserToDeleteRows = false;      // ✅ منع الحذف المباشر
                tableau.MultiSelect = false;                // ✅ تحديد صف واحد فقط
                tableau.BackgroundColor = Color.White;      // ✅ لون الخلفية

                // ✅ تنسيق رؤوس الأعمدة
                tableau.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 114, 198); // DevExpress Blue
                tableau.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                tableau.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                tableau.EnableHeadersVisualStyles = false;  // ✅ لتطبيق الألوان المخصصة

                // ✅ تنسيق الصفوف (Alternating Rows)
                tableau.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

                tableau.Columns[0].Width = 50;   // ✅ ضبط عرض عمود ID (اختياري)
                tableau.Columns[0].ReadOnly = false; // ✅ السماح بالقراءة فقط لعمود ID (اختياري)
                tableau.Columns[1].Width = 150;
                tableau.Columns[2].Width = 300;
                tableau.Columns[3].Width = 100;
                tableau.Columns[1].ReadOnly = true;
                tableau.Columns[2].ReadOnly = true;
                tableau.Columns[3].ReadOnly = true;
                tableau.Columns[4].Visible = false;
                tableau.Columns[5].Visible = false;


                

                // ✅ تعديل عناوين الأعمدة للعرض (اختياري)
                if (tableau.Columns.Contains("LIB_POINTEUSE"))
                    tableau.Columns["LIB_POINTEUSE"].HeaderText = "Appareil";
                if (tableau.Columns.Contains("ADRESSE_IP"))
                    tableau.Columns["ADRESSE_IP"].HeaderText = "Adresse IP";
                if (tableau.Columns.Contains("N_PORT"))
                    tableau.Columns["N_PORT"].HeaderText = "Port";
                if (tableau.Columns.Contains("N_MACHINE"))
                    tableau.Columns["N_MACHINE"].HeaderText = "N_MACHINE";
                if (tableau.Columns.Contains("etat"))
                    tableau.Columns["etat"].HeaderText = "État";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erreur lors du chargement des données : " + ex.Message,
                                  "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(tableau.Rows.Count >= Form2.nbr_machine)
            {
                bt_ajouter.Enabled= false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_telechargerD_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            gridView1?.RefreshData();

            DataTable allData = new DataTable();
            allData.Columns.Add("Matricule", typeof(string));
            allData.Columns.Add("Date_Pointage", typeof(string));
            allData.Columns.Add("Heure_Pointage", typeof(string));

            // ✅ إعداد ProgressBar
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            // ✅ عد الأجهزة النشطة (etat = 'O')
            int deviceCount = 0;
            foreach (DataGridViewRow row in tableau.Rows)
            {
                if (row.IsNewRow) continue;
                string etat = row.Cells["etat"]?.Value?.ToString()?.Trim().ToUpper();
                if (etat == "O") deviceCount++;
            }
            progressBar1.Maximum = Math.Max(deviceCount, 1);

            // ✅ التكرار على الأجهزة النشطة للاتصال بها
            foreach (DataGridViewRow row in tableau.Rows)
            {
                if (row.IsNewRow) continue;

                string check = row.Cells[0]?.Value?.ToString()?.Trim().ToUpper();
                if (check != "O") continue;  // ✅ تخطي الأجهزة غير النشطة

                string ip = row.Cells["ADRESSE_IP"]?.Value?.ToString()?.Trim();
                string portStr = row.Cells["N_PORT"]?.Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(ip) || !int.TryParse(portStr, out int port))
                {
                    XtraMessageBox.Show($"⚠️ بيانات الاتصال غير صحيحة", "Attention",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                // ✅ الاتصال بالجهاز عبر ZKEM SDK
                if (!zkDevice.Connect_Net(ip, port))
                {
                    int err = 0;
                    zkDevice.GetLastError(ref err);
                    XtraMessageBox.Show($"❌ فشل الاتصال بـ {ip}:{port} | Error: {err}", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                try
                {
                    zkDevice.EnableDevice(1, false);
                    zkDevice.ReadGeneralLogData(1);

                    string sEnrollNumber;
                    int idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay;
                    int idwHour, idwMinute, idwSecond, idwWorkcode = 0;

                    while (zkDevice.SSR_GetGeneralLogData(1, out sEnrollNumber, out idwVerifyMode, out idwInOutMode,
                                                          out idwYear, out idwMonth, out idwDay,
                                                          out idwHour, out idwMinute, out idwSecond,
                                                          ref idwWorkcode))
                    {
                        DateTime dateTime = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                        allData.Rows.Add(
                            sEnrollNumber.Trim(),
                            dateTime.ToString("yyyy-MM-dd"),
                            dateTime.ToString("HH:mm:ss")
                        );
                    }

                    // ✅ تمييز الصف بأنه تم معالجته
                    row.Cells["etat"].Value = "T";  // أو عمود آخر للتمييز
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطأ في الجهاز {ip}: {ex.Message}", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    zkDevice.EnableDevice(1, true);
                    zkDevice.Disconnect();
                }

                progressBar1.Value++;
                Application.DoEvents();
            }

            
        
    

            // ✅ عرض البيانات المجمعة
            gridControl1.DataSource = allData;
            gridView1?.BestFitColumns();

            // ✅ حفظ البيانات في قاعدة البيانات (SQLite)
            if (allData.Rows.Count > 0)
            {
                int savedCount = 0;
                int skippedCount = 0;

                progressBar1.Value = 0;
                progressBar1.Maximum = allData.Rows.Count;

                foreach (DataRow row in allData.Rows)
                {
                    string matricule = row["Matricule"]?.ToString().Trim();
                    string dateP = row["Date_Pointage"]?.ToString();
                    string hourP = row["Heure_Pointage"]?.ToString();

                    if (string.IsNullOrEmpty(matricule) || string.IsNullOrEmpty(dateP))
                        continue;

                    // ✅ SQLite: استخدام INSERT OR IGNORE لمنع التكرار
                    // أو: INSERT ... ON CONFLICT DO NOTHING
                    string query = @"INSERT OR IGNORE INTO CHARGEMENT_POITEUSE 
                                    (MATRI, DATE_POINTAGE, HEURS_POINTAGE, DATE_TELECHARGEMENT) 
                                    VALUES (@matri, @dateP, @hourP, datetime('now'))";

                    var parameters = new[]
                    {
                        new SqliteParameter("@matri", matricule),
                        new SqliteParameter("@dateP", dateP),
                        new SqliteParameter("@hourP", hourP)
                    };

                    int result = ConnectSqlite.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                        savedCount++;
                    else
                        skippedCount++; // سجل مكرر تم تجاهله

                    progressBar1.PerformStep();
                    Application.DoEvents();
                }

                progressBar1.Visible = false;
                XtraMessageBox.Show($"✅ العملية مكتملة!\n✔ سجلات جديدة: {savedCount}\n✖ سجلات مكررة: {skippedCount}",
                                  "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                progressBar1.Visible = false;
                XtraMessageBox.Show("⚠️ لا توجد بيانات جديدة لتحميلها من الأجهزة المحددة.", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_telechargerAttlog_Click(object sender, EventArgs e)
        {
            // ✅ فتح نافذة اختيار الملف
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DAT Files (*.dat)|*.dat|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Sélectionner le fichier des pointages (attlog)"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dt = new DataTable();
                dt.Columns.Add("Matricule", typeof(string));
                dt.Columns.Add("Date_Pointage", typeof(string));
                dt.Columns.Add("Heure_Pointage", typeof(string));

                try
                {
                    // ✅ قراءة الملف وإعداد ProgressBar
                    var lignes = File.ReadAllLines(filePath, System.Text.Encoding.UTF8);
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = lignes.Length;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;

                    // المرحلة 1: تحليل الملف وملء DataTable
                    foreach (string ligne in lignes)
                    {
                        if (string.IsNullOrWhiteSpace(ligne)) continue;

                        // ✅ تنسيق attlog النموذجي: "Matricule YYYY-MM-DD HH:MM:SS"
                        string[] parties = ligne.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parties.Length >= 3)
                        {
                            string matricule = parties[0].Trim();
                            string dateStr = parties[1].Trim();
                            string timeStr = parties[2].Trim();

                            if (DateTime.TryParse($"{dateStr} {timeStr}", out DateTime dateHeure))
                            {
                                dt.Rows.Add(
                                    matricule,
                                    dateHeure.ToString("yyyy-MM-dd"),
                                    dateHeure.ToString("HH:mm:ss")
                                );
                            }
                        }

                        progressBar1.PerformStep();
                        Application.DoEvents();
                    }

                    // ✅ عرض البيانات في الشبكة
                    gridControl1.DataSource = dt;
                    gridView1?.BestFitColumns();

                    // المرحلة 2: الحفظ في قاعدة البيانات (SQLite)
                    int savedCount = 0;
                    int skippedCount = 0;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = dt.Rows.Count;

                    foreach (DataRow row in dt.Rows)
                    {
                        string matricule = row["Matricule"]?.ToString().Trim();
                        string dateP = row["Date_Pointage"]?.ToString();
                        string hourP = row["Heure_Pointage"]?.ToString();

                        if (string.IsNullOrEmpty(matricule) || string.IsNullOrEmpty(dateP))
                            continue;

                        // ✅ SQLite: INSERT OR IGNORE لمنع التكرار
                        string query = @"INSERT OR IGNORE INTO CHARGEMENT_POITEUSE 
                                        (MATRI, DATE_POINTAGE, HEURS_POINTAGE, DATE_TELECHARGEMENT) 
                                        VALUES (@matri, @dateP, @hourP, datetime('now'))";

                        var parameters = new[]
                        {
                            new SqliteParameter("@matri", matricule),
                            new SqliteParameter("@dateP", dateP),
                            new SqliteParameter("@hourP", hourP)
                        };

                        int result = ConnectSqlite.ExecuteNonQuery(query, parameters);

                        if (result > 0)
                            savedCount++;
                        else
                            skippedCount++;

                        progressBar1.PerformStep();
                        Application.DoEvents();
                    }

                    progressBar1.Visible = false;
                    XtraMessageBox.Show($"✅ تم تحميل الملف: {Path.GetFileName(filePath)}\n✔ جديد: {savedCount} | ✖ مكرر: {skippedCount}",
                                      "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    progressBar1.Visible = false;
                    XtraMessageBox.Show($"خطأ أثناء المعالجة: {ex.Message}", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ✅ دالة مساعدة: التحقق من وجود سجل قبل الإدخال (بديل لـ INSERT OR IGNORE)
        private bool RecordExists(string matricule, string dateP, string hourP)
        {
            string query = "SELECT COUNT(*) FROM CHARGEMENT_POITEUSE WHERE MATRI = @matri AND DATE_POINTAGE = @dateP AND HEURS_POINTAGE = @hourP";
            var param = new SqliteParameter("@matri", matricule);
            var param2 = new SqliteParameter("@dateP", dateP);
            var param3 = new SqliteParameter("@hourP", hourP);

            DataTable dt = ConnectSqlite.ExecuteSelect(query, param, param2, param3);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // ✅ تنظيف الموارد عند إغلاق النموذج
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { zkDevice?.Disconnect(); } catch { }
            base.OnFormClosing(e);
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            Form18 fn_ajouterpointeuse = new Form18();
            Form18.insertion_modification = 0; // وضع الإدراج
            fn_ajouterpointeuse.ShowDialog();
            fn_ajouterpointeuse.Dispose();
            Form4_Load(null, null); // إعادة تحميل البيانات بعد الإضافة
        }

        private void btnSupprimerLogs_Click(object sender, EventArgs e)
        {
            // ✅ تأكيد الحذف
            var result = XtraMessageBox.Show("هل أنت متأكد أنك تريد حذف سجلات الحضور من الجهاز؟",
                                              "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            foreach (DataGridViewRow row in tableau.Rows)
            {
                if (row.Cells[0].Value?.ToString().Trim().ToUpper() == "O")
                {
                    if (zkDevice.ClearGLog(1)) // رقم الجهاز غالبًا 1
                    {
                        zkDevice.RefreshData(1); // لتحديث البيانات داخل الجهاز بعد الحذف
                        row.Cells[0].ReadOnly = true;
                        row.DefaultCellStyle.BackColor = Color.Lime;

                        MessageBox.Show("✅ تم حذف سجلات الحضور من الجهاز بنجاح");
                    }
                    else
                    {
                        row.Cells[0].ReadOnly = true;
                        row.DefaultCellStyle.BackColor = Color.Lime;

                        MessageBox.Show("❌ فشل في حذف سجلات الحضور");
                    }
                }
            }
        }

        private void btnSupprimerLogs_MouseHover(object sender, EventArgs e)
        {
            // ✅ عرض تلميح عند المرور فوق زر الحذف
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnSupprimerLogs, "احذر! هذا سيؤدي إلى حذف جميع سجلات الحضور من الجهاز المحدد.");    

        }

        private void bt_telechargerD_MouseHover(object sender, EventArgs e)
        {
            // ✅ عرض تلميح عند المرور فوق زر التحميل
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(bt_telechargerD, "تحميل سجلات الحضور من الأجهزة النشطة وعرضها في الشبكة.");
        }

        private void bt_ajouter_MouseHover(object sender, EventArgs e)
        {
            // ✅ عرض تلميح عند المرور فوق زر الإضافة
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(bt_ajouter, "إضافة جهاز بصمة جديد إلى القائمة.");
        }

        private void bt_telechargerAttlog_MouseHover(object sender, EventArgs e)
        {
            // ✅ عرض تلميح عند المرور فوق زر تحميل ملف attlog
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(bt_telechargerAttlog, "تحميل سجلات الحضور من ملف attlog وعرضها في الشبكة.");
        }

        private void tableau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form18 fn_ajouterpointeuse = new Form18();
            Form18.insertion_modification = 1; // وضع التعديل
            fn_ajouterpointeuse.txt_ip.Text = tableau.Rows[e.RowIndex].Cells["ADRESSE_IP"].Value.ToString();
            fn_ajouterpointeuse.txt_lib.Text = tableau.Rows[e.RowIndex].Cells["LIB_POINTEUSE"].Value.ToString();
            fn_ajouterpointeuse.txt_ip.Enabled = false; // منع تعديل IP أثناء التعديل
            fn_ajouterpointeuse.txt_lib.Enabled = true; // السماح بتعديل الاسم
            fn_ajouterpointeuse.ShowDialog();
            fn_ajouterpointeuse.Dispose();
            Form4_Load(null, null); // إعادة تحميل البيانات بعد الإضافة
        }

        private void bt_supprimer_Click(object sender, EventArgs e)
        {
            supprimerPointeuse(tableau.CurrentRow.Cells["ADRESSE_IP"].Value.ToString());
            Form4_Load(null, null); // إعادة تحميل البيانات بعد الحذف
        }
        private void supprimerPointeuse(string ip)
        {
            // ✅ تأكيد الحذف
            var result = XtraMessageBox.Show($"هل أنت متأكد أنك تريد حذف الجهاز {ip}؟",
                                              "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;
            string query = "DELETE FROM POINTEUSE WHERE ADRESSE_IP = @ip";
            var param = new SqliteParameter("@ip", ip);
            int rowsAffected = ConnectSqlite.ExecuteNonQuery(query, param);
            if (rowsAffected > 0)
            {
                XtraMessageBox.Show("✅ تم حذف الجهاز بنجاح.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form4_Load(null, null); // إعادة تحميل البيانات بعد الحذف
            }
            else
            {
                XtraMessageBox.Show("❌ فشل في حذف الجهاز. قد يكون غير موجود.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_supprimer_MouseHover(object sender, EventArgs e)
        {
            // ✅ عرض تلميح عند المرور فوق زر الحذف
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(bt_supprimer, "احذر! هذا سيؤدي إلى حذف الجهاز المحدد من القائمة.");

        }
    }   
}