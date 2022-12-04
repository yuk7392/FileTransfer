using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileTransfer
{
    public class LogManager
    {
        private static string logDirPath = string.Empty;
        private static string logFileName = string.Empty;

        private static void CheckBasicFiles()
        {
            logDirPath = @"C:\FileTransfer\log";
            logFileName = @"\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            DirectoryInfo dirInfo = new DirectoryInfo(logDirPath);

            if (!dirInfo.Exists)
                dirInfo.Create();
        }

        public static void WriteLog(Exception pException)
        {
            CheckBasicFiles();

            File.WriteAllText(logDirPath + logFileName, "["+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"] " +
                                                         pException.Message + Environment.NewLine +
                                                         "Source : " + pException.Source + Environment.NewLine +
                                                         "Method Name : " + pException.TargetSite + Environment.NewLine +
                                                         "StackTrace : " + pException.StackTrace + Environment.NewLine);
        }

        public static void WriteLog(string pString, bool pTimeFormat = true, bool pNewLine = true)
        {
            CheckBasicFiles();

            string appendText = pTimeFormat
                                    ? "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] "
                                    : string.Empty;

            appendText += pNewLine
                              ? Environment.NewLine
                              : string.Empty;
                                  

            File.WriteAllText(logDirPath + logFileName, appendText + pString);
        }

    }
}
