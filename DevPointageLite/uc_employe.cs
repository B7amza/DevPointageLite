using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;  // ✅ الاستيراد الصحيح لـ SQLite

namespace DevPointageLite
{
    public partial class uc_employe : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_employe()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            // ✅ إنشاء نموذج جديد بشكل آمن باستخدام using
            using (var frmPersonnel = new Form10())
            {
                Form10.insertion_modification = 0; // Insertion mode

                // إعداد الأزرار حسب الحاجة
                frmPersonnel.bt_ajouter.Enabled = true;
                frmPersonnel.bt_modifier.Enabled = false;

                // ✅ عرض النموذج وتحديث البيانات بعد النجاح
                if (frmPersonnel.ShowDialog() == DialogResult.OK)
                {
                    load_personnel_data();
                }
            } // ✅ التصريف التلقائي للنموذج
        }

        private void load_personnel_data()
        {
            // ✅ استعلام محسّن باستخدام JOIN الصريح (أفضل من comma join)
            string query = @"
                SELECT 
                    p.matricule AS 'Matricule',
                    p.nom AS 'Nom',
                    p.prenom AS 'Prénom',
                    p.sexe AS 'Sexe',
                    p.adress AS 'Adresse',
                    p.tel AS 'Téléphone',
                    f.lib_fonction AS 'Fonction',
                    a.lib_affect AS 'Affectation',
                    p.type_agent AS 'Type',
                    p.poinatge AS 'Pointage',
                    p.id_fonction, -- ✅ إضافة الحقول اللازمة للتعديل
                    p.id_affectation
                FROM Personnel p
                INNER JOIN fonction f ON p.id_fonction = f.c_fonct
                INNER JOIN affectation a ON p.id_affectation = a.c_affect
                ORDER BY p.matricule";

            // ✅ تحميل البيانات باستخدام ConnectSqlite (بدون SqlDataAdapter)
            DataTable dt = ConnectSqlite.ExecuteSelect(query);
            gridControl1.DataSource = dt;

            // ✅ تنسيق الشبكة (DevExpress)
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.OptionsBehavior.Editable = false;
                gridView.BestFitColumns();
                gridView.OptionsView.ColumnAutoWidth = false;
            }
        }

        private void uc_employe_Load(object sender, EventArgs e)
        {
            load_personnel_data();
        }

        private void bt_modifier_Click(object sender, EventArgs e)
        {
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null || gridView.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Veuillez sélectionner un employé à modifier.",
                                  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ إنشاء نموذج جديد للتعديل باستخدام using
            using (var frmPersonnel = new Form10())
            {
                Form10.insertion_modification = 1; // Modification mode

                // إعداد الأزرار
                frmPersonnel.bt_ajouter.Enabled = false;
                frmPersonnel.bt_modifier.Enabled = true;

                // ✅ جلب بيانات الصف المحدد بأمان
                int selectedRowHandle = gridView.GetSelectedRows()[0];
                DataRow selectedRow = gridView.GetDataRow(selectedRowHandle);

                if (selectedRow != null)
                {
                    // ✅ تعبئة الحقول الأساسية مع التحقق من DBNull
                    frmPersonnel.txt_matricule.Text = selectedRow["matricule"]?.ToString() ?? "";
                    frmPersonnel.txt_nom.Text = selectedRow["nom"]?.ToString() ?? "";
                    frmPersonnel.txt_prenom.Text = selectedRow["prénom"]?.ToString() ?? "";
                    frmPersonnel.cb_sexe.Text = selectedRow["sexe"]?.ToString() ?? "";
                    frmPersonnel.txt_adresse.Text = selectedRow["adresse"]?.ToString() ?? "";
                    frmPersonnel.txt_tel.Text = selectedRow["téléphone"]?.ToString() ?? "";

                    // ✅ تعبئة ComboBoxes مع التحقق من القيم
                    if (selectedRow["id_fonction"] != DBNull.Value)
                    {
                        frmPersonnel.cb_fonction.SelectedValue = Convert.ToInt32(selectedRow["id_fonction"]);
                        Form10.var_fonction = selectedRow["id_fonction"].ToString();
                    }

                    if (selectedRow["id_affectation"] != DBNull.Value)
                    {
                        frmPersonnel.cb_affectation.SelectedValue = Convert.ToInt32(selectedRow["id_affectation"]);
                        Form10.var_affectation = selectedRow["id_affectation"].ToString();
                    }

                    frmPersonnel.cb_type.Text = selectedRow["type"]?.ToString() ?? "";
                    frmPersonnel.cb_pointage.Text = selectedRow["pointage"]?.ToString() ?? "";
                }

                // ✅ عرض النموذج وتحديث البيانات بعد النجاح
                if (frmPersonnel.ShowDialog() == DialogResult.OK)
                {
                    load_personnel_data();
                }
            }
        }
    }
}