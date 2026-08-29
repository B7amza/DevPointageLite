using DevExpress.XtraEditors;
using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.IO.Compression; // مكتبة التعامل مع ملفات Zip
using System.Windows.Forms;

namespace DevPointageLite
{
    public partial class Form25 : DevExpress.XtraEditors.XtraForm
    {
        public Form25()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }

        private void btbrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtdatabase.Text = dlg.SelectedPath;
                    btbackup.Enabled = true;
                }
            }
        }

        private void btbackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdatabase.Text))
            {
                MessageBox.Show("يرجى اختيار مجلد الحفظ أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tempDbPath = string.Empty;

            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string dbFileName = $"backup_DEVCORE_PN_{timestamp}.db";
                string zipFileName = $"backup_DEVCORE_PN_{timestamp}.zip";

                tempDbPath = Path.Combine(txtdatabase.Text, dbFileName);
                string finalZipPath = Path.Combine(txtdatabase.Text, zipFileName);

                // 1. تنفيذ النسخ الاحتياطي في نطاق معزول لإغلاق الاتصالات نهائياً
                CreateSqliteBackup(ConnectSqlite.ConString, tempDbPath);

                // 2. تنظيف معالجة المقابض المفتوحة في الذاكرة قبل الضغط
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // 3. ضغط الملف إلى ZIP
                using (ZipArchive zip = ZipFile.Open(finalZipPath, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(tempDbPath, dbFileName, CompressionLevel.Optimal);
                }

                // 4. حذف الملف المؤقت بعد نجاح الضغط
                if (File.Exists(tempDbPath))
                {
                    File.Delete(tempDbPath);
                }

                MessageBox.Show($"تمت عملية النسخ الاحتياطي والضغط بنجاح!\nالملف: {zipFileName}",
                                "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"خطأ: لا توجد صلاحية للوصول إلى المجلد المحدد.\n{ex.Message}",
                                "خطأ صلاحيات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // تنظيف الملف المؤقت عند حدوث استثناء
                if (!string.IsNullOrEmpty(tempDbPath) && File.Exists(tempDbPath))
                {
                    try { File.Delete(tempDbPath); } catch { }
                }

                MessageBox.Show($"حدث خطأ أثناء النسخ الاحتياطي والضغط: {ex.Message}",
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة منفصلة لضمان التخلص من مقبض الاتصال قبل العودة للدالة الرئيسية
        private void CreateSqliteBackup(string sourceConString, string destFilePath)
        {
            using (var sourceConnection = new SqliteConnection(sourceConString))
            using (var destConnection = new SqliteConnection($"Data Source={destFilePath};"))
            {
                sourceConnection.Open();
                destConnection.Open();

                sourceConnection.BackupDatabase(destConnection);

                // إغلاق صريح ومباشر للاتصالات
                destConnection.Close();
                sourceConnection.Close();
            }
            // مسح مؤقتات الاتصال من SQLite Pool
            SqliteConnection.ClearAllPools();
        }
    }
}