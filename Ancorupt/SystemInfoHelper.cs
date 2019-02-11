using System;
using System.Management;
using System.IO;
using SimpleJSON;
using System.Diagnostics;

namespace Ancorupt
{
    static class SystemInfoHelper
    {
        private static SystemInfo System { get; set; }

        // Метод считывает харакетристики компьютера 
        // по классу компонента (wmiClass) и его свойству (wmiProperty)
        private static string GetInfo(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass managmentClass = new ManagementClass(wmiClass);
            ManagementObjectCollection managementObjectCollection = managmentClass.GetInstances();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                if (result == "")
                {
                    try
                    {
                        result = managementObject[wmiProperty].ToString();
                        break;
                    }
                    catch { }
                }
            }
            return result;
        }

        // Информация о процессоре
        public static string Cpu()
        {
            string result = (GetInfo("Win32_Processor", "UniqueId") 
                + GetInfo("Win32_Processor", "ProcessorId") 
                + GetInfo("Win32_Processor", "Name")
                + GetInfo("Win32_Processor", "Manufacturer")
                + GetInfo("Win32_Processor", "SerialNumber")).Replace(" ", "");
            return result.Substring(0, result.Length >= 25 ? 25 : result.Length);
        }

        // Информация о биосе
        public static string Bios()
        {
            string result = (GetInfo("Win32_BIOS", "Manufacturer")
            + GetInfo("Win32_BIOS", "SMBIOSBIOSVersion")
            + GetInfo("Win32_BIOS", "IdentificationCode")
            + GetInfo("Win32_BIOS", "SerialNumber")
            + GetInfo("Win32_BIOS", "ReleaseDate")
            + GetInfo("Win32_BIOS", "Version")).Replace(" ", "");
            return result.Substring(0, result.Length >= 25 ? 25 : result.Length);
        }

        // Информация о диске
        public static string Disk()
        {
            string result = (GetInfo("Win32_DiskDrive", "Model")
            + GetInfo("Win32_DiskDrive", "SerialNumber")).Replace(" ", "");
            return result.Substring(0, result.Length >= 25 ? 25 : result.Length);
        }

        // Информация о материнской плате
        public static string BaseBoard()
        {
            string result = (GetInfo("Win32_BaseBoard", "Product")
                + GetInfo("Win32_BaseBoard", "Name")
                + GetInfo("Win32_BaseBoard", "SerialNumber")).Replace(" ", "");
            return result.Substring(0, result.Length >= 25 ? 25 : result.Length);
        }

        /// <summary>
        /// Считывает информацию с файла лицензии
        /// </summary>
        public static bool LoadFromLicenseFile()
        {
            if (File.Exists("license.dat"))
            {
                try
                {
                    string content = File.ReadAllText("license.dat");
                    RSAHelper rsa = new RSAHelper();
                    var info = JSON.Parse(rsa.Decrypt(content, true));
                    System = new SystemInfo(info["cpu"], info["bios"], info["disk"], info["baseboard"]);
                    return true;
                }
                catch (Exception) { return false; }
            }
            else
            {
                System = new SystemInfo("null", "null", "null", "null");
                return false;
            }
        }

        /// <summary>
        /// Cравнивает характеристики, записанные в файле лицензии
        /// с характеристиками считанными из системы
        /// </summary>
        /// <returns>Возвращает результат сравнения в виде True, False</returns>
        public static bool CheckLicense()
        {
            try
            {
                LoadFromLicenseFile();
                return Cpu().Equals(System.Cpu) ? Bios().Equals(System.Bios) ? Disk().Equals(System.Disk) ? BaseBoard().Equals(System.BaseBoard) ? true : false : false : false : false;
            } catch (Exception) { return false; }
        }
    }
}
