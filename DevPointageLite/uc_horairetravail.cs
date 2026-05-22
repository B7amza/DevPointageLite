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
    public partial class uc_horairetravail : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_horairetravail()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void uc_horairetravail_Load(object sender, EventArgs e)
        {
            load_HoraireTravail_data();
        }

        private void load_HoraireTravail_data()
        {
            // ✅ تحميل البيانات باستخدام ConnectSqlite
            //string query = "SELECT c_affect AS 'Code', lib_affect AS 'Désignation' FROM AFFECTATION ORDER BY c_affect";
            string query = "SELECT code AS 'Code', designation AS 'Désignation',SAM AS 'Samedi',DIM AS 'Dimanche',LUN AS 'Lundi',MAR AS 'Mardi',MER AS 'Mercredi',JEU AS 'Jeudi',VEN AS 'Vendredi' FROM HORAIRE_TRAVAIL ORDER BY code";
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
            // ✅ إنشاء نموذج جديد بشكل صحيح (تجنب النمط الثابت)
            using (var frmHoraireTravail = new Form24())
            {
                Form24.insertion_modification = 0; // ✅ تعيين الوضع للإضافة
                frmHoraireTravail.Text = "Ajouter un horaire de travail"; // ✅ تعيين عنوان النموذج
                
                frmHoraireTravail.bt_ajouter.Enabled = true; // ✅ تمكين زر الإضافة
                frmHoraireTravail.bt_enregistrer.Enabled = false; // ✅ تعطيل زر الحفظ (لأنه غير ضروري في وضع الإضافة)
                frmHoraireTravail.bt_modifier.Enabled = false; // ✅ تعطيل زر التعديل (لأنه غير ضروري في وضع الإضافة)
                frmHoraireTravail.bt_fermer.Enabled = true; // ✅ تمكين زر الإغلاق


                frmHoraireTravail.ShowDialog();
                
                load_HoraireTravail_data(); // ✅ إعادة تحميل البيانات بعد الإضافة
                
            }
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            // التحقق مما إذا كان هناك صف محدد في GridView الخاص بـ DevExpress
            if (gridView1.SelectedRowsCount > 0)
            {
                // الحصول على مؤشر الصف المحدد
                int rowHandle = gridView1.GetSelectedRows()[0];

                // استخراج البيانات من الصف المحدد
                string code = gridView1.GetRowCellValue(rowHandle, "Code")?.ToString();
                string designation = gridView1.GetRowCellValue(rowHandle, "Désignation")?.ToString();
                string sam = gridView1.GetRowCellValue(rowHandle, "Samedi")?.ToString();
                string dim = gridView1.GetRowCellValue(rowHandle, "Dimanche")?.ToString();
                string lun = gridView1.GetRowCellValue(rowHandle, "Lundi")?.ToString();
                string mar = gridView1.GetRowCellValue(rowHandle, "Mardi")?.ToString();
                string mer = gridView1.GetRowCellValue(rowHandle, "Mercredi")?.ToString();
                string jeu = gridView1.GetRowCellValue(rowHandle, "Jeudi")?.ToString();
                string ven = gridView1.GetRowCellValue(rowHandle, "Vendredi")?.ToString();

                // فتح form24 وتمرير البيانات إليه
                Form24 frm = new Form24();
                Form24.insertion_modification = 1; // تعيين الوضع للتعديل
               frm.Text = "Modifier l'horaire de travail"; // تعيين عنوان النموذج
                frm.bt_ajouter.Enabled = false; // تعطيل زر الإضافة (لأنه غير ضروري في وضع التعديل)
                frm.bt_enregistrer.Enabled = true; // تمكين زر الحفظ (لأنه ضروري في وضع التعديل)
                frm.bt_modifier.Enabled = false; // تعطيل زر التعديل (لأنه غير ضروري في وضع التعديل)
                frm.bt_fermer.Enabled = true; // تمكين زر الإغلاق

                frm.reset_champs(true); // إعادة تعيين الحقول وتمكينها

                // استدعاء الدالة التي أنشأناها لتمرير وتفكيك البيانات
                frm.ChargerDonnees(code, designation, sam, dim, lun, mar, mer, jeu, ven);
                
                // إظهار الفورم
                frm.ShowDialog();

                // بعد إغلاق form24، نقوم بتحديث الـ GridControl ليعرض البيانات الجديدة
                load_HoraireTravail_data();
            }
            else
            {
                // تنبيه في حال لم يقم المستخدم بتحديد أي صف
                MessageBox.Show("الرجاء تحديد صف من الجدول أولاً لتعديله.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
