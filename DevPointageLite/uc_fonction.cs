using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class uc_fonction : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_fonction()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            // ✅ إنشاء نموذج جديد بشكل آمن باستخدام using
            using (var frmFonction = new Form12())
            {
                Form12.insertion_modification = 0; // Insertion mode

                // إعداد واجهة النموذج
                frmFonction.Text = "Ajouter une fonction";
                frmFonction.txt_c_fonction.Enabled = false;
                frmFonction.txt_lib_fonction.Enabled = true;
                frmFonction.txt_c_fonction.Clear();
                frmFonction.txt_lib_fonction.Clear();

                frmFonction.bt_fermer.Enabled = true;
                frmFonction.bt_enregistrer.Enabled = true;
                frmFonction.bt_modifier.Enabled = false;
                frmFonction.bt_ajouter.Enabled = false;
                frmFonction.bt_fermer.Text = "Fermer";

                // ✅ توليد الكود التلقائي باستخدام ConnectSqlite و IFNULL لـ SQLite
                string query = "SELECT IFNULL(MAX(c_fonct), '00') AS c_fonct FROM FONCTION";
                DataTable dt = ConnectSqlite.ExecuteSelect(query);

                if (dt.Rows.Count > 0 && dt.Rows[0]["c_fonct"] != DBNull.Value)
                {
                    string maxCode = dt.Rows[0]["c_fonct"].ToString();
                    if (int.TryParse(maxCode, out int codeValue))
                    {
                        int nextCode = codeValue + 1;
                        frmFonction.txt_c_fonction.Text = nextCode.ToString("D2");
                    }
                    else
                    {
                        frmFonction.txt_c_fonction.Text = "01";
                    }
                }
                else
                {
                    frmFonction.txt_c_fonction.Text = "01";
                }

                // ✅ عرض النموذج وتحديث البيانات بعد النجاح
                if (frmFonction.ShowDialog() == DialogResult.OK)
                {
                    load_fonction_data();
                }
            } // ✅ التصريف التلقائي للنموذج
            load_fonction_data();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner une fonction à modifier.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ إنشاء نموذج جديد للتعديل
            using (var frmFonction = new Form12())
            {
                Form12.insertion_modification = 1; // Modification mode

                frmFonction.Text = "Modifier une fonction";
                frmFonction.txt_c_fonction.Enabled = false;
                frmFonction.txt_lib_fonction.Enabled = true;

                // ✅ جلب بيانات الصف المحدد بأمان
                int selectedRowHandle = gridView.GetSelectedRows()[0];
                DataRow selectedRow = gridView.GetDataRow(selectedRowHandle);

                if (selectedRow != null)
                {
                    frmFonction.txt_c_fonction.Text = selectedRow["Code"]?.ToString() ?? "";
                    frmFonction.txt_lib_fonction.Text = selectedRow["Fonction"]?.ToString() ?? "";
                }

                // إعداد الأزرار
                frmFonction.bt_ajouter.Enabled = false;
                frmFonction.bt_modifier.Enabled = false;
                frmFonction.bt_enregistrer.Enabled = true;
                frmFonction.bt_fermer.Enabled = true;
                frmFonction.bt_fermer.Text = "Fermer";

                // ✅ عرض النموذج وتحديث البيانات
                if (frmFonction.ShowDialog() == DialogResult.OK)
                {
                    load_fonction_data();
                }
            }
            load_fonction_data();
            // ❌ تم حذف load_fonction_data() المكررة
        }

        private void load_fonction_data()
        {
            // ✅ تحميل البيانات باستخدام ConnectSqlite (بدون SqlDataAdapter)
            string query = "SELECT c_fonct AS 'Code', lib_fonction AS 'Fonction' FROM FONCTION ORDER BY c_fonct";
            DataTable dataTable = ConnectSqlite.ExecuteSelect(query);
            gridControl1.DataSource = dataTable;

            // ✅ تنسيق الشبكة إن لزم (DevExpress)
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.OptionsBehavior.Editable = false;
                gridView.BestFitColumns();
            }
        }

        private void uc_fonction_Load(object sender, EventArgs e)
        {
            load_fonction_data();
        }
    }
}