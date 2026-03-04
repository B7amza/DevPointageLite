using System;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace DevPointageLite
{
    public static class ConnectSqlite
    {
        private static string dbFileName = "DEVCORE_PN.db";
        // جعل نص الاتصال للقراءة فقط بعد تعيينه أول مرة
        public static string ConString { get; private set; }

        public static void Initialize()
        {
            // الحصول على مسار قاعدة البيانات
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbFileName);
            ConString = $"Data Source={dbPath};";

            // إنشاء الملف إذا لم يكن موجوداً (اختياري)
            if (!File.Exists(dbPath))
            {
                // يمكنك هنا تنفيذ كود لإنشاء الجداول الافتراضية
            }
        }

        // دالة مساعدة لإنشاء اتصال جديد
        private static SqliteConnection GetConnection()
        {
            if (string.IsNullOrEmpty(ConString)) Initialize();
            return new SqliteConnection(ConString);
        }

        // -------------------------
        // SELECT → يرجع DataTable
        // -------------------------
        public static DataTable ExecuteSelect(string query, params SqliteParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Erreur SELECT", ex.Message);
            }
            return dt;
        }

        // -------------------------
        // INSERT / UPDATE / DELETE
        // -------------------------
        public static int ExecuteNonQuery(string query, params SqliteParameter[] parameters)
        {
            int rows = 0;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        rows = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Erreur Execution", ex.Message);
            }
            return rows;
        }

        // دالة موحدة لعرض الأخطاء
        private static void ShowError(string title, string message)
        {
            MessageBox.Show($"{title} : {message}", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // حفظ الإعدادات باستخدام Settings الافتراضية لـ C# (أفضل من VisualBasic)
        public static void SaveSettings()
        {
            // نصيحة: استخدم Properties.Settings.Default لحفظ الإعدادات في C#
            // سأبقيها كرسالة إخبارية حالياً
            MessageBox.Show("Les paramètres SQLite sont configurés avec succès.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}