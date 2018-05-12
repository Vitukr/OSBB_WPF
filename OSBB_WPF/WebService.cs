using Newtonsoft.Json;
using OSBB_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_WPF
{
    public static class WebService
    {
        public static byte[] DataResponce;
        public static AnnouncementApi UseWebClient(string url, string userName, string password)
        {
            using (WebClient wc = new WebClient())
            {
                // post
                var values = new NameValueCollection
                {
                    ["UserName"] = userName,
                    ["Password"] = password
                };
                //wc.Credentials = new NetworkCredential(userName, password);
                wc.Encoding = Encoding.UTF8;
                wc.DownloadDataCompleted += Wc_DownloadDataCompleted;

                //byte[] response = wc.UploadValues(url, values);
                wc.DownloadDataAsync(new Uri(url));

                string textjson = Encoding.Default.GetString(DataResponce);

                var json = JsonConvert.DeserializeObject<AnnouncementApi>(textjson);
                return json;
            }
        }

        public static IList<T> UseWebClient<T>(string url, string userName, string password) where T: class
        {
            using (WebClient wc = new WebClient())
            {
                // post
                var values = new NameValueCollection
                {
                    ["userName"] = userName,
                    ["password"] = password
                };
                wc.Encoding = Encoding.UTF8;

                byte[] response = wc.UploadValues(url, values);
                string textjson = Encoding.Default.GetString(response);

                var json = JsonConvert.DeserializeObject<IList<T>>(textjson);
                return json;
            }
        }

        private static void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            DataResponce = e.Result;
        }

        //public static DataTable ListToTable<T>(IList<T> list) where T: class
        //{
        //    DataTable dt = new DataTable();
        //    for( int i = 0; i < list.Count; i++)
        //    {
        //        dt.Columns.Add(new DataColumn())
        //    }
        //}
    }
}
