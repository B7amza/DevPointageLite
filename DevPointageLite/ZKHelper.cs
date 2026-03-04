using System;
using System.Data;
using System.Runtime.InteropServices;
using zkemkeeper; // بعد إضافة المرجع zkemkeeper.dll من SDK

namespace DevPointageLite
{
    internal class ZKHelper
    {
        private readonly CZKEM axCZKEM = new CZKEM();
        private readonly int machineNumber = 1; // الرقم الافتراضي للجهاز

        /// <summary>
        /// الاتصال بالجهاز عبر IP وPort
        /// </summary>
        public bool Connect(string ip, int port = 4370)
        {
            try
            {
                bool connected = axCZKEM.Connect_Net(ip, port);
                return connected;
            }
            catch (COMException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                axCZKEM.Disconnect();
            }
            catch { }
        }

        /// <summary>
        /// قراءة سجلات الحضور وإرجاعها في DataTable
        /// </summary>
        public DataTable ReadAttendanceLogs(string ip, int port = 4370)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EnrollNumber", typeof(string));
            dt.Columns.Add("DateTime", typeof(DateTime));
            dt.Columns.Add("VerifyMode", typeof(int));
            dt.Columns.Add("InOutMode", typeof(int));
            dt.Columns.Add("WorkCode", typeof(int));

            if (!Connect(ip, port))
                return dt;

            try
            {
                axCZKEM.EnableDevice(machineNumber, false);

                if (!axCZKEM.ReadGeneralLogData(machineNumber))
                    return dt;

                string enrollNumber = "";
                int verifyMode = 0, inOutMode = 0;
                int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
                int workcode = 0;

                while (axCZKEM.SSR_GetGeneralLogData(
                    machineNumber,
                    out enrollNumber,
                    out verifyMode,
                    out inOutMode,
                    out year,
                    out month,
                    out day,
                    out hour,
                    out minute,
                    out second,
                    ref workcode))
                {
                    DateTime dtLog = new DateTime(year, month, day, hour, minute, second);
                    dt.Rows.Add(enrollNumber, dtLog, verifyMode, inOutMode, workcode);
                }
            }
            catch
            {
                // تجاهل الأخطاء الفردية
            }
            finally
            {
                axCZKEM.EnableDevice(machineNumber, true);
                Disconnect();
            }

            return dt;
        }
    }
}
