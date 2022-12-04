using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class OptionManager
    {
        public static string OPTIONFILEDIRLOCATION = @"C:\FileTransfer";
        public static string OPTIONFILENAME = @"\options.txt";
        public static string SAVETARGETDIR { get; set; }
        public static EPreset PRESET1 = new EPreset();
        public static EPreset PRESET2 = new EPreset();
        public static EPreset PRESET3 = new EPreset();
        public static EPreset PRESET4 = new EPreset();
        public static EPreset PRESET5 = new EPreset();

        public static void Load()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(OPTIONFILEDIRLOCATION);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                if (!File.Exists(OPTIONFILEDIRLOCATION + OPTIONFILENAME))
                {
                    Clear();
                    Save();
                }    

                string optionStr = File.ReadAllText(OPTIONFILEDIRLOCATION + OPTIONFILENAME);
                string[] optionLines = optionStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                string optionName, optionValue;

                foreach (string option in optionLines)
                {
                    if (option.StartsWith("#"))
                        continue;

                    string[] optionSplit = option.Split(new string[] { "=" }, StringSplitOptions.None);
                    optionName = optionSplit[0];
                    optionValue = optionSplit[1];
                    
                    switch (optionSplit.Length)
                    {
                        case 2:
                            switch (optionName.ToUpper())
                            {
                                case "SAVETARGETDIR":
                                    SAVETARGETDIR = optionValue;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case 3:
                            string[] presetData = optionValue.Split(new string[] { "|" }, StringSplitOptions.None);
                            string presetName = presetData[0];
                            string ipAddr = presetData[1];
                            string port = presetData[2];

                            switch (optionName.ToUpper())
                            {
                                case "PRESET1":
                                    PRESET1.PRESETNAME = presetName;
                                    PRESET1.IPADDR = ipAddr;
                                    PRESET1.PORT = port;
                                    break;

                                case "PRESET2":
                                    PRESET2.PRESETNAME = presetName;
                                    PRESET2.IPADDR = ipAddr;
                                    PRESET2.PORT = port;
                                    break;

                                case "PRESET3":
                                    PRESET3.PRESETNAME = presetName;
                                    PRESET3.IPADDR = ipAddr;
                                    PRESET3.PORT = port;
                                    break;

                                case "PRESET4":
                                    PRESET4.PRESETNAME = presetName;
                                    PRESET4.IPADDR = ipAddr;
                                    PRESET4.PORT = port;
                                    break;

                                case "PRESET5":
                                    PRESET5.PRESETNAME = presetName;
                                    PRESET5.IPADDR = ipAddr;
                                    PRESET5.PORT = port;
                                    break;

                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
            }
        }

        public static void Save()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("# 파일위치를 옮기거나 삭제하지 말것.");
                sb.AppendLine("SAVETARGETDIR=" + SAVETARGETDIR);
                sb.AppendLine("PRESET1=" + string.Join("|", PRESET1.PRESETNAME, PRESET1.IPADDR, PRESET1.PORT));
                sb.AppendLine("PRESET2=" + string.Join("|", PRESET2.PRESETNAME, PRESET2.IPADDR, PRESET2.PORT));
                sb.AppendLine("PRESET3=" + string.Join("|", PRESET3.PRESETNAME, PRESET3.IPADDR, PRESET3.PORT));
                sb.AppendLine("PRESET4=" + string.Join("|", PRESET4.PRESETNAME, PRESET4.IPADDR, PRESET4.PORT));
                sb.Append("PRESET5=" + string.Join("|", PRESET5.PRESETNAME, PRESET5.IPADDR, PRESET5.PORT));

                File.WriteAllText(OPTIONFILEDIRLOCATION + OPTIONFILENAME, sb.ToString());
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
            }
        }

        public static void Clear()
        {
            try
            {
                SAVETARGETDIR = @"C:/FileTransfer/Download";
                PRESET1.Clear();
                PRESET2.Clear();
                PRESET3.Clear();
                PRESET4.Clear();
                PRESET5.Clear();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
            }
        }
    }
}
