using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using ExcelDataReader;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DevPointageLite
{
    public partial class Form22 : DevExpress.XtraEditors.XtraForm
    {
        public Form22()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }

       

    private void bt_ouvrir_Click(object sender, EventArgs e)
    {
            if(tableau_source.DataSource != null)
            {
                // تأكيد قبل مسح البيانات الحالية
                var result = MessageBox.Show("هل تريد فتح ملف جديد؟ سيتم مسح البيانات الحالية.", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return; // إذا اختار المستخدم "لا"، لا نفعل شيئاً
            }
            if(cb_type.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار نوع الملف أولاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.xlsb";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                    // إنشاء القارئ بناءً على نوع الملف تلقائياً
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                        // تحويل البيانات إلى DataSet
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true // اعتبار الصف الأول كعناوين للأعمدة
                            }
                        });

                        // الحصول على الجدول الأول (الورقة الأولى)
                        DataTable dt = result.Tables[0];

                        // عرض البيانات في الـ DataGridView الخاص بك
                        tableau_source.DataSource = dt;
                        }
                     }
                 }
                catch (Exception ex)
                {
                MessageBox.Show("خطأ في قراءة الملف: " + ex.Message);
                }
        }
    }

        private void Form22_Load(object sender, EventArgs e)
        {           

            //هذا السطر يضمن دعم جميع أنواع النصوص واللغات
            // في بعض الأحيان، قد تحتاج إلى تسجيل مزود الترميز يدويًا لدعم أنواع معينة من الملفات أو النصوص، خاصة إذا كنت تعمل مع ملفات Excel تحتوي على نصوص غير لاتينية.
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

           
        }

        private void bt_enregistrer_Click(object sender, EventArgs e)
        {
            if (tableau_source.DataSource == null)
            {
                XtraMessageBox.Show("لا توجد بيانات لحفظها.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cb_type.SelectedItem == null)
            {
                XtraMessageBox.Show("يرجى اختيار نوع الملف أولاً.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = (DataTable)tableau_source.DataSource;
            if (dt.Rows.Count == 0) return;

            int savedCount = 0;
            int skippedCount = 0;

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = dt.Rows.Count;

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    string query = "";
                    List<SqliteParameter> parameters = new List<SqliteParameter>();
                    string typeLabel = "";

                    // --- الحالة 0: الوظائف ---
                    if (cb_type.SelectedIndex == 0)
                    {
                        string c_fonct = row["c_fonct"]?.ToString().Trim();
                        string lib_fonct = row["lib_fonction"]?.ToString().Trim();
                        if (string.IsNullOrEmpty(c_fonct)) continue;

                        query = "INSERT OR IGNORE INTO FONCTION (C_FONCT, LIB_FONCTION) VALUES (@c, @l)";
                        parameters.Add(new SqliteParameter("@c", c_fonct));
                        parameters.Add(new SqliteParameter("@l", lib_fonct));
                        typeLabel = "وظائف";
                    }
                    // --- الحالة 1: المديريات ---
                    else if (cb_type.SelectedIndex == 1)
                    {
                        string c_affect = row["c_affect"]?.ToString().Trim();
                        string lib_affect = row["lib_affect"]?.ToString().Trim();
                        if (string.IsNullOrEmpty(c_affect)) continue;

                        query = "INSERT OR IGNORE INTO AFFECTATION (C_AFFECT, LIB_AFFECT) VALUES (@c, @l)";
                        parameters.Add(new SqliteParameter("@c", c_affect));
                        parameters.Add(new SqliteParameter("@l", lib_affect));
                        typeLabel = "مديريات";
                    }
                    // --- الحالة 2: الموظفين (مع الربط التلقائي) ---
                    else if (cb_type.SelectedIndex == 2)
                    {
                        string mat = row["matricule"]?.ToString().Trim();
                        if (string.IsNullOrEmpty(mat)) continue;

                        query = @"INSERT OR IGNORE INTO personnel (
                            matricule, nom, prenom, sexe, adress, tel, 
                            id_fonction, id_affectation, type_agent, poinatge
                          ) 
                          VALUES (
                            @mat, @nom, @pre, @sexe, @adr, @tel,
                            (SELECT c_fonct FROM FONCTION WHERE LIB_FONCTION = @l_fonct LIMIT 1),
                            (SELECT c_affect FROM AFFECTATION WHERE LIB_AFFECT = @l_aff LIMIT 1),
                            @type, @poi
                          )";

                        parameters.Add(new SqliteParameter("@mat", mat));
                        parameters.Add(new SqliteParameter("@nom", row["nom"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@pre", row["prenom"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@sexe", row["sexe"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@adr", row["adress"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@tel", row["tel"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@l_fonct", row["lib_fonction"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@l_aff", row["lib_affect"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@type", row["type_agent"]?.ToString().Trim()));
                        parameters.Add(new SqliteParameter("@poi", row["poinatge"]?.ToString().Trim()));
                        typeLabel = "موظفين";
                        // تنفيذ إضافة الموظف أولاً
                        int res = ConnectSqlite.ExecuteNonQuery(query, parameters.ToArray());

                        if (res > 0)
                        {
                            savedCount++; // الموظف جديد وتمت إضافته

                            // 2. استعلام إضافة جدول المواعيد (يُنفذ فقط إذا نجحت إضافة الموظف)
                            string horaireQuery = @"INSERT OR IGNORE INTO PERSONNEL_EMPLOI_TEMPS 
                                (matri, code, date_du, date_au) 
                                VALUES (@matri, '11', '2015-01-01 00:00:00', '2028-01-01 00:00:00')";

                            var horaireParams = new[] { new SqliteParameter("@matri", mat) };
                            ConnectSqlite.ExecuteNonQuery(horaireQuery, horaireParams);
                        }
                        else
                        {
                            skippedCount++; // الموظف مكرر فلم يتم إضافة جدول مواعيد جديد له
                        }

                        // تصفير الاستعلام لمنع التكرار في نهاية الحلقة
                        query = "";
                    }

                    // تنفيذ العملية
                    if (!string.IsNullOrEmpty(query))
                    {
                        int res = ConnectSqlite.ExecuteNonQuery(query, parameters.ToArray());
                        if (res > 0) savedCount++;
                        else skippedCount++;
                    }

                    progressBar1.PerformStep();
                    Application.DoEvents();
                }

                XtraMessageBox.Show($"✅ تم الحفظ بنجاح!\nالنوع: {cb_type.Text}\n✔ مضاف جديد: {savedCount}\n✖ مكرر/متجاهل: {skippedCount}",
                    "النتيجة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("خطأ أثناء الحفظ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }
    }
}