using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ استيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class uc_structure : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_structure()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            // ✅ إنشاء نموذج جديد بشكل صحيح (تجنب النمط الثابت)
            using (var frmAffectation = new Form11())
            {
                Form11.insertion_modification = 0; // Insertion mode

                // إعداد واجهة النموذج
                frmAffectation.txt_c_affectation.Enabled = false;
                frmAffectation.txt_lib_affectation.Enabled = true;
                frmAffectation.txt_lib_affectation.Clear();

                frmAffectation.bt_ajouter.Enabled = false;
                frmAffectation.bt_modifier.Enabled = false;
                frmAffectation.bt_enregistrer.Enabled = true;
                frmAffectation.bt_fermer.Enabled = true;
                frmAffectation.bt_fermer.Text = "Fermer";
                frmAffectation.Text = "Ajouter une affectation";

                // ✅ توليد الكود التلقائي باستخدام ConnectSqlite و IFNULL لـ SQLite
                string query = "SELECT IFNULL(MAX(c_affect), '00') AS c_affect FROM AFFECTATION";
                DataTable dt = ConnectSqlite.ExecuteSelect(query);

                if (dt.Rows.Count > 0 && dt.Rows[0]["c_affect"] != DBNull.Value)
                {
                    string maxCode = dt.Rows[0]["c_affect"].ToString();
                    if (int.TryParse(maxCode, out int codeValue))
                    {
                        int nextCode = codeValue + 1;
                        frmAffectation.txt_c_affectation.Text = nextCode.ToString("D2");
                    }
                    else
                    {
                        frmAffectation.txt_c_affectation.Text = "01";
                    }
                }
                else
                {
                    frmAffectation.txt_c_affectation.Text = "01";
                }

                // ✅ عرض النموذج وتحديث البيانات بعد الإغلاق
                if (frmAffectation.ShowDialog() == DialogResult.OK)
                {
                    load_affectation_data();
                }
            } // ✅ التصريف التلقائي للنموذج
            load_affectation_data(); // ✅ تحديث البيانات بعد التعديل
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner une affectation à modifier.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ إنشاء نموذج جديد للتعديل
            using (var frmAffectation = new Form11())
            {
                Form11.insertion_modification = 1; // Modification mode

                frmAffectation.txt_c_affectation.Enabled = false;
                frmAffectation.txt_lib_affectation.Enabled = true;

                // ✅ جلب بيانات الصف المحدد
                int selectedRowHandle = gridView.GetSelectedRows()[0];
                DataRow selectedRow = gridView.GetDataRow(selectedRowHandle);

                if (selectedRow != null)
                {
                    frmAffectation.txt_c_affectation.Text = selectedRow["code"]?.ToString() ?? "";
                    frmAffectation.txt_lib_affectation.Text = selectedRow["Désignation"]?.ToString() ?? "";
                }

                // إعداد الأزرار والعنوان
                frmAffectation.bt_ajouter.Enabled = false;
                frmAffectation.bt_modifier.Enabled = false;
                frmAffectation.bt_enregistrer.Enabled = true;
                frmAffectation.bt_fermer.Enabled = true;
                frmAffectation.bt_fermer.Text = "Fermer";
                frmAffectation.Text = "Modifier une affectation";

                // ✅ عرض النموذج وتحديث البيانات
                if (frmAffectation.ShowDialog() == DialogResult.OK)
                {
                    load_affectation_data();
                }

                load_affectation_data(); // ✅ تحديث البيانات بعد التعديل
            }
        }

        private void load_affectation_data()
        {
            // ✅ تحميل البيانات باستخدام ConnectSqlite
            string query = "SELECT c_affect AS 'Code', lib_affect AS 'Désignation' FROM AFFECTATION ORDER BY c_affect";
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

        private void uc_structure_Load(object sender, EventArgs e)
        {
            load_affectation_data();
        }
    }
}