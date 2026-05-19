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
    public partial class Form24 : DevExpress.XtraEditors.XtraForm
    {
        public Form24()
        {
            InitializeComponent();
            ConnectSqlite.Initialize(); // ✅ تهيئة قاعدة البيانات
        }

        static public int insertion_modification; // 0: Insertion, 1: Modification

        private void Form24_Load(object sender, EventArgs e)
        {

        }

        private void bt_fermer_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ajouter_Click(object sender, EventArgs e)
        {
            reset_champs(true);
        }

        private void reset_champs(Boolean etat)
        {
            
            switch (etat)
            {
                case true:
                   
                    //txt_designation.Text = "";
                    //du_d.Text = "  :  ";
                    //du_l.Text = "  :  ";
                    //du_ma.Text = "  :  ";
                    //du_me.Text = "  :  ";
                    //du_j.Text = "  :  ";
                    //du_v.Text = "  :  ";
                    //du_s.Text = "  :  ";
                    //////////////////////
                    ///
                    txt_code.Enabled = false;
                    txt_designation.Enabled = true;
                    du_d.Enabled = true;
                    du_l.Enabled = true;
                    du_ma.Enabled = true;
                    du_me.Enabled = true;
                    du_j.Enabled = true;
                    du_v.Enabled = true;
                    du_s.Enabled = true;

                    //chk_wd.Checked = false;
                    //chk_wl.Checked = false;
                    //chk_wma.Checked = false;
                    //chk_wme.Checked = false;
                    //chk_wj.Checked = false;
                    //chk_wv.Checked = false;
                    //chk_ws.Checked = false;

                    chk_wd.Enabled = true;
                    chk_wl.Enabled = true;
                    chk_wma.Enabled = true;
                    chk_wme.Enabled = true;
                    chk_wj.Enabled = true;
                    chk_wv.Enabled = true;
                    chk_ws.Enabled = true;


                    //bt_ajouter.Enabled = false;
                    //bt_modifier.Enabled = false;
                    //bt_enregistrer.Enabled = true;
                    break;
                case false:
                    txt_code.Enabled = false;
                    txt_designation.Enabled = false;
                    du_d.Enabled = false;
                    du_l.Enabled = false;
                    du_ma.Enabled = false;
                    du_me.Enabled = false;
                    du_j.Enabled = false;
                    du_v.Enabled = false;
                    du_s.Enabled = false;
                    break;
            }
            
        }
    }
}