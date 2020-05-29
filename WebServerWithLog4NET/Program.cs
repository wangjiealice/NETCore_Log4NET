using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebServerWithLog4NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   string url = @"http://" + GetAddressIP() + ":5000";
                   Console.WriteLine("URL is: " + url);

                   webBuilder.UseUrls(url)
                   .UseStartup<Startup>();
               });

        /// <summary>
        /// ��ȡ����IP��ַ��Ϣ
        /// </summary>
        private static string GetAddressIP()
        {
            ///��ȡ���ص�IP��ַ
            string addressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    addressIP = _IPAddress.ToString();
                }
            }
            return addressIP;
        }
    }
}
