using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ استيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class uc_typeconge : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_typeconge()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void load_typeconge_data()
        {
            // ✅ تحميل البيانات باستخدام ConnectSqlite
            string query = "SELECT code AS 'Code', lib AS 'Désignation',PERIODIQUE AS 'Type',jour AS 'Jour' FROM TYPE_CONGE ORDER BY code";
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

        private void uc_typeconge_Load(object sender, EventArgs e)
        {
            load_typeconge_data();
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            // ✅ إنشاء نموذج جديد بشكل صحيح (تجنب النمط الثابت)
            using (var frmTypeconge = new Form19())
            {
                Form19.insertion_modification = 0; // Insertion mode

                // إعداد واجهة النموذج
                frmTypeconge.txt_code.Enabled = false;
                frmTypeconge.txt_lib_conge.Enabled = true;

                frmTypeconge.txt_lib_conge.Clear();

                frmTypeconge.bt_ajouter.Enabled = false;
                frmTypeconge.bt_modifier.Enabled = false;
                frmTypeconge.bt_enregistrer.Enabled = true;
                frmTypeconge.bt_fermer.Enabled = true;
                frmTypeconge.bt_fermer.Text = "Fermer";
                frmTypeconge.Text = "Ajouter un type congé";

                // ✅ توليد الكود التلقائي باستخدام ConnectSqlite و IFNULL لـ SQLite
                string query = "SELECT IFNULL(MAX(code), '00') AS code FROM TYPE_CONGE";
                DataTable dt = ConnectSqlite.ExecuteSelect(query);

                if (dt.Rows.Count > 0 && dt.Rows[0]["code"] != DBNull.Value)
                {
                    string maxCode = dt.Rows[0]["code"].ToString();
                    if (int.TryParse(maxCode, out int codeValue))
                    {
                        int nextCode = codeValue + 1;
                        frmTypeconge.txt_code.Text = nextCode.ToString("D2");
                    }
                    else
                    {
                        frmTypeconge.txt_code.Text = "01";
                    }
                }
                else
                {
                    frmTypeconge.txt_code.Text = "01";
                }

                // ✅ عرض النموذج وتحديث البيانات بعد الإغلاق
                if (frmTypeconge.ShowDialog() == DialogResult.OK)
                {
                    load_typeconge_data();
                }
            } // ✅ التصريف التلقائي للنموذج
            load_typeconge_data(); // ✅ تحديث البيانات بعد التعديل
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner un type à modifier.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ إنشاء نموذج جديد للتعديل
            using (var frmTypeconge = new Form19())
            {
                Form19.insertion_modification = 1; // Modification mode

                frmTypeconge.txt_code.Enabled = false;
                frmTypeconge.txt_lib_conge.Enabled = true;

                // ✅ جلب بيانات الصف المحدد
                int[] selectedRows = gridView.GetSelectedRows();

                if (selectedRows != null && selectedRows.Length > 0 && selectedRows[0] >= 0)
                {
                    int rowHandle = selectedRows[0];

                    // ✅ جلب القيم مباشرة بدون DataRow
                    string code = gridView.GetRowCellValue(rowHandle, "Code")?.ToString() ?? "";
                    string lib = gridView.GetRowCellValue(rowHandle, "Désignation")?.ToString() ?? "";
                    string type = gridView.GetRowCellValue(rowHandle, "Type")?.ToString() ?? "";
                    string jour = gridView.GetRowCellValue(rowHandle, "Jour")?.ToString() ?? "";

                    frmTypeconge.txt_code.Text = code;
                    frmTypeconge.txt_lib_conge.Text = lib;

                    frmTypeconge.chk_periodique.Checked = (type == "O");
                    frmTypeconge.chk_periodique.Text = (type == "O") ? "Congé" : "Bon Sortie";
                    frmTypeconge.lb_nbrABS.Text= (type == "O") ? "Nbr jours :" : "N/A :";
                    frmTypeconge.txt_nbrABS.Enabled = (type == "O"); // تمكين حقل عدد الأيام فقط إذا كانت إجازة دورية
                    frmTypeconge.txt_nbrABS.Text = jour;
                    Form19.var_periodique = (type == "O") ? "O" : "N"; // تخزين نوع الإجازة في متغير ثابت لاستخدامه في النموذج الفرعي
                }

                // إعداد الأزرار والعنوان
                frmTypeconge.bt_ajouter.Enabled = false;
                frmTypeconge.bt_modifier.Enabled = false;
                frmTypeconge.bt_enregistrer.Enabled = true;
                frmTypeconge.bt_fermer.Enabled = true;
                frmTypeconge.bt_fermer.Text = "Fermer";
                frmTypeconge.Text = "Modifier un Type de congé";

                // ✅ عرض النموذج وتحديث البيانات
                if (frmTypeconge.ShowDialog() == DialogResult.OK)
                {
                    load_typeconge_data();
                }

                load_typeconge_data(); // ✅ تحديث البيانات بعد التعديل
            }
        }
    }
}
