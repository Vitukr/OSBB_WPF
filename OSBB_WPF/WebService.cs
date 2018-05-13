using Newtonsoft.Json;
using OSBB_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public static IList<T> UseWebClient<T>(string url, string userName, string password) where T: class
        //{
        //    using (WebClient wc = new WebClient())
        //    {
        //        // post
        //        var values = new NameValueCollection
        //        {
        //            ["userName"] = userName,
        //            ["password"] = password
        //        };
        //        wc.Encoding = Encoding.UTF8;

        //        byte[] response = wc.UploadValues(url, values);
        //        string textjson = Encoding.Default.GetString(response);

        //        var json = JsonConvert.DeserializeObject<List<T>>(textjson);
        //        return json;
        //    }
        //}

        public static object UseWebClient<T>(string url, string userName, string password) where T : class
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

                var json = JsonConvert.DeserializeObject<List<T>>(textjson);
                return json;
            }
        }
    }
}
