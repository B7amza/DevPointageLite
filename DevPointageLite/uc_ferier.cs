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
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite


namespace DevPointageLite
{
    public partial class uc_ferier : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_ferier()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void uc_ferier_Load(object sender, EventArgs e)
        {
            load_ferier_data();
        }

        private void load_ferier_data()
        {
            // ✅ تحميل البيانات باستخدام ConnectSqlite (بدون SqlDataAdapter)
            string query = "SELECT date_f AS 'Date Ferie', lib  AS 'Nom de Jour' FROM JOUR_FERIE ORDER BY date_f";
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

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            // ✅ إنشاء نموذج جديد بشكل آمن باستخدام using
            using (var frmFerier = new Form26())
            {
                Form12.insertion_modification = 0; // Insertion mode

                // إعداد واجهة النموذج
                frmFerier.Text = "Ajouter une date fériée";
                frmFerier.date_ferier.Enabled = true;
                frmFerier.txt_lib.Enabled = true;
                frmFerier.date_ferier.Value = DateTime.Now.Date;
                frmFerier.txt_lib.Clear();
                frmFerier.bt_fermer.Enabled = true;
                frmFerier.bt_enregistrer.Enabled = true;
                frmFerier.bt_modifier.Enabled = false;
                frmFerier.bt_ajouter.Enabled = false;
                frmFerier.bt_fermer.Text = "Fermer";

                

                // ✅ عرض النموذج وتحديث البيانات بعد النجاح
                if (frmFerier.ShowDialog() == DialogResult.OK)
                {
                    load_ferier_data();
                }
            } // ✅ التصريف التلقائي للنموذج
            load_ferier_data();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner une date à modifier.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ إنشاء نموذج جديد للتعديل
            using (var frmFerier = new Form26())
            {
                Form26.insertion_modification = 1; // Modification mode

                frmFerier.Text = "Modifier une Date";
                frmFerier.date_ferier.Enabled = false;
                frmFerier.txt_lib.Enabled = true;

                // ✅ جلب بيانات الصف المحدد بأمان
                int selectedRowHandle = gridView.GetSelectedRows()[0];
                DataRow selectedRow = gridView.GetDataRow(selectedRowHandle);

                if (selectedRow != null)
                {
                    frmFerier.date_ferier.Value = Convert.ToDateTime(selectedRow["Date Ferie"]);
                    frmFerier.txt_lib.Text = selectedRow["Nom de Jour"]?.ToString() ?? "";
                }

                // إعداد الأزرار
                frmFerier.bt_ajouter.Enabled = false;
                frmFerier.bt_modifier.Enabled = false;
                frmFerier.bt_enregistrer.Enabled = true;
                frmFerier.bt_fermer.Enabled = true;
                frmFerier.bt_fermer.Text = "Fermer";
                // ✅ عرض النموذج وتحديث البيانات
                if (frmFerier.ShowDialog() == DialogResult.OK)
                {
                    load_ferier_data();
                }
            }
            load_ferier_data();
            
        }

        private void bt_supprimer_Click(object sender, EventArgs e)
        {
            // ✅ الحصول على GridView
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            // ✅ التحقق من وجود تحديد
            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner une date à supprimer.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ الحصول على التاريخ المحدد (المفتاح الأساسي)
            // ملاحظة: عمود date_f في الجدول هو المفتاح الأساسي
            string dateStr = gridView.GetFocusedRowCellValue("Date Ferie")?.ToString();
            string libStr = gridView.GetFocusedRowCellValue("Nom de Jour")?.ToString();

            if (string.IsNullOrWhiteSpace(dateStr))
            {
                XtraMessageBox.Show("La date sélectionnée est invalide.",
                                  "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ تأكيد الحذف (مع عرض البيان واليوم للحذر)
            DialogResult dr = XtraMessageBox.Show(
                $"Voulez-vous vraiment supprimer cette journée fériée ?\n\n" +
                $"📅 Date  : {dateStr}\n" +
                $"📝 Libellé : {libStr}\n\n" +
                $"Cette action est irréversible.",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);   // الافتراضي على "لا"

            if (dr != DialogResult.Yes)
                return;

            try
            {
                // ✅ حذف السجل من SQLite — WHERE date_f (المفتاح الأساسي)
                string query = "DELETE FROM JOUR_FERIE WHERE date_f = @date_f";
                var param = new Microsoft.Data.Sqlite.SqliteParameter("@date_f", dateStr);

                int rows = ConnectSqlite.ExecuteNonQuery(query, param);

                // ✅ معالجة النتيجة
                if (rows > 0)
                {
                    XtraMessageBox.Show("La journée fériée a été supprimée avec succès.",
                                      "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ✅ تحديث مصدر البيانات للـ GridView (إعادة التحميل من DB)
                    load_ferier_data();
                }
                else
                {
                    XtraMessageBox.Show("Aucune ligne n'a été supprimée. La date est peut-être déjà supprimée.",
                                      "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    load_ferier_data();   // إعادة المزامنة على أي حال
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                                  "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
