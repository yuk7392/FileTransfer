using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    public class Common
    {
        public static bool IsInternetConnected()
        {
            try
            {
                string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
                string NCSI_TEST_RESULT = "Microsoft NCSI";
                string NCSI_DNS = "dns.msftncsi.com";
                string NCSI_DNS_IP_ADDRESS = "131.107.255.255";
                string result = string.Empty;

                // Check NCSI test link
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadString(NCSI_TEST_URL);
                }

                if (result != NCSI_TEST_RESULT)
                    return false;

                var dnsHost = Dns.GetHostEntry(NCSI_DNS);

                if (dnsHost.AddressList.Count() < 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                return false;
            }
        }
    }
}
