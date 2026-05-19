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
                if (frmHoraireTravail.DialogResult == DialogResult.OK)
                {
                    load_HoraireTravail_data(); // ✅ إعادة تحميل البيانات بعد الإضافة
                }
            }
        }
    }
}
