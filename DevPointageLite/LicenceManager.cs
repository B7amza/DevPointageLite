using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevPointageLite
{
    internal class LicenseManager
    {
        // استخدم نفس المفتاح السري الذي تستخدمه في توليد الرخصة
        private static string secretKey = "MY_SECRET_KEY_2025";

        // استخرج معرف الجهاز (CPU + القرص)
        public static string GetHardwareId()
        {
            string cpuId = "";
            string diskId = "";

            try
            {
                using (var mc = new ManagementClass("Win32_Processor"))
                {
                    foreach (var mo in mc.GetInstances())
                    {
                        cpuId = mo["ProcessorId"]?.ToString();
                        break;
                    }
                }

                using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive"))
                {
                    foreach (var mo in searcher.Get())
                    {
                        diskId = mo["SerialNumber"]?.ToString();
                        break;
                    }
                }
            }
            catch
            {
                return null;
            }

            return cpuId + "-" + diskId;
        }

        // توليد الرخصة بناءً على Hardware ID
        public static string GenerateLicenseKey(string hardwareId)
        {
            string raw = hardwareId + secretKey;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
                return Convert.ToBase64String(hashBytes).Substring(0, 25).ToUpper();
            }
        }

        // التحقق من صلاحية الرخصة
        public static bool IsLicenseValid(string licenseKey)
        {
            string hardwareId = GetHardwareId();
            if (string.IsNullOrEmpty(hardwareId)) return false;

            string expectedKey = GenerateLicenseKey(hardwareId);
            return licenseKey == expectedKey;
        }
    }
}
