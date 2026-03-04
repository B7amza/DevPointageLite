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
using zkemkeeper;

namespace DevPointageLite
{
    public partial class Form16 : DevExpress.XtraEditors.XtraForm
    {
        public Form16()
        {
            InitializeComponent();
            ConnectSqlite.Initialize();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            loadListePointeuse();
        }
        CZKEM zkDevice = new CZKEM(); // كائن الاتصال بالجهاز
        private void loadListePointeuse()
        {
            try
            {
                string query = "SELECT * FROM POINTEUSE WHERE Etat='O'";
                DataTable dt = ConnectSqlite.ExecuteSelect(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("تنبيه: لم يتم العثور على أي أجهزة مفعلة في قاعدة البيانات.");
                    return;
                }

                // إيقاف التحديث التلقائي مؤقتاً لتحسين الأداء
                cb_pointeuse_source.DataSource = null;
                cb_pointeuse_source.DataSource = dt;
                cb_pointeuse_source.DisplayMember = "LIB_POINTEUSE";
                cb_pointeuse_source.ValueMember = "ADRESSE_IP";

                cb_pointeuse_destination.DataSource = null;
                cb_pointeuse_destination.DataSource = dt.Copy();
                cb_pointeuse_destination.DisplayMember = "LIB_POINTEUSE";
                cb_pointeuse_destination.ValueMember = "ADRESSE_IP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تحميل القائمة: " + ex.Message);
            }
        }
        private void bt_connexionP_Click(object sender, EventArgs e)
        {
            bool isConnected = false;
            int machineNumber = 1; // غالباً الجهاز يكون رقم 1
            try
            {
                // نأخذ الـ IP من الكمبو
                string ip = cb_pointeuse_source.SelectedValue?.ToString();
                int port = 4370; // المنفذ الافتراضي لأجهزة ZKTeco

                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("الرجاء اختيار جهاز من القائمة");
                    return;
                }

                // قطع الاتصال إذا كان متصل مسبقاً
                if (isConnected)
                {
                    zkDevice.Disconnect();
                    isConnected = false;
                }

                // محاولة الاتصال
                isConnected = zkDevice.Connect_Net(ip, port);

                if (isConnected)
                {


                    // جلب الوقت الحالي من الجهاز
                    int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;

                    if (zkDevice.GetDeviceTime(machineNumber, ref year, ref month, ref day, ref hour, ref minute, ref second))
                    {
                        DateTime deviceTime = new DateTime(year, month, day, hour, minute, second);
                        lb_timePointeuse.Text = deviceTime.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        lb_timePointeuse.Text = "تعذر جلب الوقت من الجهاز";
                    }
                    MessageBox.Show("تم الاتصال بنجاح مع الجهاز: " + ip);

                }
                else
                {
                    MessageBox.Show("فشل الاتصال بالجهاز: " + ip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void bt_AjousterTime_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = cb_pointeuse_source.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("يرجى اختيار جهاز Pointeuse.");
                    return;
                }

                int port = 4370;
                int machineNumber = 1;

                if (zkDevice.Connect_Net(ip, port))
                {
                    // هنا إما:
                    // 1) نضبط الوقت ليكون نفس وقت الكمبيوتر
                    if (zkDevice.SetDeviceTime(machineNumber))
                    {
                        MessageBox.Show("تم ضبط توقيت الجهاز على توقيت الحاسوب بنجاح.");
                    }
                    else
                    {
                        MessageBox.Show("فشل في ضبط توقيت الجهاز.");
                    }

                    // أو 2) نحدد وقت مخصص (مثلاً: 2025-09-16 15:30:00)
                    /*
                    int year = 2025, month = 9, day = 16, hour = 15, minute = 30, second = 0;
                    if (zkDevice.SetDeviceTime2(machineNumber, year, month, day, hour, minute, second))
                    {
                        MessageBox.Show("تم ضبط التوقيت المخصص بنجاح.");
                    }
                    else
                    {
                        MessageBox.Show("فشل في ضبط التوقيت المخصص.");
                    }
                    */

                    zkDevice.Disconnect();
                }
                else
                {
                    MessageBox.Show("تعذر الاتصال بالجهاز.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void bt_telechargerD_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = cb_pointeuse_source.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("يرجى اختيار جهاز Pointeuse أولا.");
                    return;
                }

                int port = 4370;

                if (zkDevice.Connect_Net(ip, port))
                {
                    string name = "";
                    string password = "";
                    int privilege = 0;
                    bool enabled = false;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Matricule");
                    dt.Columns.Add("Nom");
                    dt.Columns.Add("c_privilege", typeof(int));  // الرقم الأصلي
                    dt.Columns.Add("Privilege");                 // النص المعروض
                    dt.Columns.Add("c_enabled", typeof(bool));   // الحالة الأصلية
                    dt.Columns.Add("Enabled");                   // النص المعروض

                    zkDevice.ReadAllUserID(1);

                    while (zkDevice.SSR_GetAllUserInfo(1, out string enrollNumber, out name, out password, out privilege, out enabled))
                    {
                        // تحويل privilege إلى نص
                        string role;
                        switch (privilege)
                        {
                            case 0: role = "مستخدم"; break;
                            case 1: role = "مسجل بيانات"; break;
                            case 2: role = "مدير"; break;
                            case 3: role = "مشرف"; break;
                            case 14: role = "مدير النظام"; break;
                            default: role = "غير معروف"; break;
                        }

                        // إضافة السطر
                        dt.Rows.Add(enrollNumber, name, privilege, role, enabled, enabled ? "مفعل" : "معطل");
                    }

                    gridControl1.DataSource = dt;
                    MessageBox.Show("تم تحميل بيانات المستخدمين بنجاح.");
                }
                else
                {
                    MessageBox.Show("فشل الاتصال بالجهاز: " + ip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void bt_privilege_Click(object sender, EventArgs e)
        {
            try
            {
                var view = gridView1; // اسم الـ GridView المرتبط بـ gridControl1
                if (view.FocusedRowHandle < 0)
                {
                    MessageBox.Show("يرجى اختيار مستخدم من الجدول.");
                    return;
                }

                string matricule = view.GetRowCellValue(view.FocusedRowHandle, "Matricule")?.ToString();
                int currentPrivilege = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "c_privilege"));

                // قلب الصلاحية: إذا كان 0 → 3 (مشرف)، إذا كان 3 → 0 (مستخدم)
                int newPrivilege = (currentPrivilege == 0) ? 3 : 0;

                string ip = cb_pointeuse_source.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("يرجى اختيار جهاز Pointeuse.");
                    return;
                }

                int port = 4370;

                if (zkDevice.Connect_Net(ip, port))
                {
                    // جلب المعلومات القديمة للمستخدم
                    string name = "";
                    string password = "";
                    bool enabled = false;

                    if (zkDevice.SSR_GetUserInfo(1, matricule, out name, out password, out currentPrivilege, out enabled))
                    {
                        // تعديل الصلاحية
                        if (zkDevice.SSR_SetUserInfo(1, matricule, name, password, newPrivilege, enabled))
                        {
                            // تحديث الجدول في الواجهة
                            view.SetRowCellValue(view.FocusedRowHandle, "c_privilege", newPrivilege);
                            view.SetRowCellValue(view.FocusedRowHandle, "Privilege", (newPrivilege == 3) ? "مشرف" : "مستخدم");

                            MessageBox.Show("تم تغيير الصلاحية بنجاح.");
                        }
                        else
                        {
                            MessageBox.Show("فشل في تعديل الصلاحية على الجهاز.");
                        }
                    }

                    zkDevice.Disconnect();
                }
                else
                {
                    MessageBox.Show("تعذر الاتصال بالجهاز.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void bt_transfert_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceIP = cb_pointeuse_source.SelectedValue?.ToString();
                string destIP = cb_pointeuse_destination.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(sourceIP) || string.IsNullOrEmpty(destIP))
                {
                    MessageBox.Show("يرجى اختيار الجهازين.");
                    return;
                }

                if (gridView1.FocusedRowHandle < 0)
                {
                    MessageBox.Show("يرجى اختيار مستخدم.");
                    return;
                }

                string enrollNumber = gridView1.GetFocusedRowCellValue("Matricule").ToString();
                string name = gridView1.GetFocusedRowCellValue("Nom").ToString();
                int privilege = Convert.ToInt32(gridView1.GetFocusedRowCellValue("c_privilege"));
                bool enabled = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("c_enabled"));

                int port = 4370;
                int machineNumber = 1;

                progressBar1.Value = 0;

                // ===============================
                // 1️⃣ قراءة البصمات من الجهاز المصدر
                // ===============================
                if (!zkDevice.Connect_Net(sourceIP, port))
                {
                    MessageBox.Show("فشل الاتصال بالجهاز المصدر.");
                    return;
                }

                zkDevice.EnableDevice(machineNumber, false);

                List<(int fingerIndex, int flag, string tmpData)> fingerprints
                    = new List<(int, int, string)>();

                for (int i = 0; i < 10; i++)
                {
                    string tmpData = "";
                    int flag = 0;
                    int tmpLength = 0;

                    if (zkDevice.GetUserTmpExStr(machineNumber, enrollNumber, i, out flag, out tmpData, out tmpLength))
                    {
                        fingerprints.Add((i, flag, tmpData));
                    }
                }

                zkDevice.EnableDevice(machineNumber, true);
                zkDevice.Disconnect();

                // ===============================
                // 2️⃣ الاتصال بالجهاز الهدف
                // ===============================
                if (!zkDevice.Connect_Net(destIP, port))
                {
                    MessageBox.Show("فشل الاتصال بالجهاز الهدف.");
                    return;
                }

                zkDevice.EnableDevice(machineNumber, false);

                // ===============================
                // 3️⃣ فحص وجود المستخدم
                // ===============================
                string tempName = "";
                string tempPwd = "";
                int tempPriv = 0;
                bool tempEnabled = false;

                bool userExists = zkDevice.SSR_GetUserInfo(
                    machineNumber,
                    enrollNumber,
                    out tempName,
                    out tempPwd,
                    out tempPriv,
                    out tempEnabled
                );

                if (userExists)
                {
                    DialogResult dr = MessageBox.Show(
                        "المستخدم موجود في الجهاز الهدف.\nهل تريد استبداله؟",
                        "تنبيه",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (dr == DialogResult.No)
                    {
                        zkDevice.EnableDevice(machineNumber, true);
                        zkDevice.Disconnect();
                        return;
                    }

                    // حذف آمن
                    if (int.TryParse(enrollNumber, out int enrollInt))
                    {
                        zkDevice.SSR_DeleteEnrollData(machineNumber, enrollNumber, 12);
                        zkDevice.DeleteUserInfoEx(machineNumber, enrollInt);
                    }
                    else
                    {
                        MessageBox.Show("رقم المستخدم غير صالح.");
                        zkDevice.EnableDevice(machineNumber, true);
                        zkDevice.Disconnect();
                        return;
                    }
                }

                // ===============================
                // 4️⃣ إنشاء المستخدم
                // ===============================
                bool created = zkDevice.SSR_SetUserInfo(
                    machineNumber,
                    enrollNumber,
                    name,
                    "",
                    privilege,
                    enabled
                );

                if (!created)
                {
                    MessageBox.Show("فشل إنشاء المستخدم.");
                    zkDevice.EnableDevice(machineNumber, true);
                    zkDevice.Disconnect();
                    return;
                }

                // ===============================
                // 5️⃣ نقل البصمات + ProgressBar
                // ===============================
                progressBar1.Minimum = 0;
                progressBar1.Maximum = fingerprints.Count;
                progressBar1.Value = 0;

                int counter = 0;

                foreach (var fp in fingerprints)
                {
                    zkDevice.SetUserTmpExStr(
                        machineNumber,
                        enrollNumber,
                        fp.fingerIndex,
                        fp.flag,
                        fp.tmpData
                    );

                    counter++;
                    if (counter <= progressBar1.Maximum)
                        progressBar1.Value = counter;

                    Application.DoEvents();
                }

                zkDevice.RefreshData(machineNumber);
                zkDevice.EnableDevice(machineNumber, true);
                zkDevice.Disconnect();

                progressBar1.Value = 0;

                MessageBox.Show("تم نقل المستخدم مع البصمات بنجاح.. ✅");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }
        //private void bt_transfert_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sourceIP = cb_listepointeuse.SelectedValue?.ToString();
        //        string destIP = cb_destination.SelectedValue?.ToString();

        //        if (string.IsNullOrEmpty(sourceIP) || string.IsNullOrEmpty(destIP))
        //        {
        //            MessageBox.Show("يرجى اختيار الجهازين.");
        //            return;
        //        }

        //        if (gridView1.FocusedRowHandle < 0)
        //        {
        //            MessageBox.Show("يرجى اختيار مستخدم.");
        //            return;
        //        }

        //        string enrollNumber = gridView1.GetFocusedRowCellValue("Matricule").ToString();
        //        string name = gridView1.GetFocusedRowCellValue("Nom").ToString();
        //        int privilege = Convert.ToInt32(gridView1.GetFocusedRowCellValue("c_privilege"));
        //        bool enabled = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("c_enabled"));

        //        int port = 4370;

        //        // 🔹 الاتصال بالجهاز المصدر
        //        if (!zkDevice.Connect_Net(sourceIP, port))
        //        {
        //            MessageBox.Show("فشل الاتصال بالجهاز المصدر.");
        //            return;
        //        }

        //        zkDevice.EnableDevice(1, false);

        //        // قراءة البصمات
        //        List<(int fingerIndex, int flag, string tmpData)> fingerprints = new List<(int, int, string)>();

        //        for (int i = 0; i < 10; i++) // الجهاز يدعم حتى 10 بصمات
        //        {
        //            string tmpData = "";
        //            int flag = 0;
        //            int tmpLength = 0;

        //            if (zkDevice.GetUserTmpExStr(1, enrollNumber, i, out flag, out tmpData, out tmpLength))
        //            {
        //                fingerprints.Add((i, flag, tmpData));
        //            }
        //        }

        //        zkDevice.EnableDevice(1, true);
        //        zkDevice.Disconnect();

        //        // 🔹 الاتصال بالجهاز الهدف
        //        if (!zkDevice.Connect_Net(destIP, port))
        //        {
        //            MessageBox.Show("فشل الاتصال بالجهاز الهدف.");
        //            return;
        //        }

        //        zkDevice.EnableDevice(1, false);

        //        // إنشاء المستخدم
        //        bool userCreated = zkDevice.SSR_SetUserInfo(
        //            1,
        //            enrollNumber,
        //            name,
        //            "",
        //            privilege,
        //            enabled
        //        );

        //        if (!userCreated)
        //        {
        //            MessageBox.Show("فشل إنشاء المستخدم في الجهاز الهدف.");
        //            zkDevice.EnableDevice(1, true);
        //            zkDevice.Disconnect();
        //            return;
        //        }

        //        // 🔹 نقل البصمات
        //        foreach (var fp in fingerprints)
        //        {
        //            zkDevice.SetUserTmpExStr(
        //                1,
        //                enrollNumber,
        //                fp.fingerIndex,
        //                fp.flag,
        //                fp.tmpData
        //            );
        //        }

        //        zkDevice.RefreshData(1);
        //        zkDevice.EnableDevice(1, true);
        //        zkDevice.Disconnect();

        //        MessageBox.Show("تم نقل المستخدم مع جميع البصمات بنجاح ✅");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("خطأ: " + ex.Message);
        //    }
        //}
    }
}