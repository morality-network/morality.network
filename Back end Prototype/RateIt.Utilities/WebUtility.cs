using RateIt.Common.Models;
using RateIt.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace RateIt.Utilities
{
    public class WebUtility
    {
        public static bool MakeWebCall(string urlString)
        {
            WebRequest request = WebRequest.Create(urlString);
            var response = request.GetResponseAsync().Result;
            return ((HttpWebResponse)response).StatusCode == HttpStatusCode.OK;
        }

        public static T MakeWebCall<T>(string urlString, int throttle = 0)
        {
            WebRequest request = WebRequest.Create(urlString);
            Thread.Sleep(throttle);
            var response = AsyncHelper.RunSync(() => request.GetResponseAsync());
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                return serializer.Deserialize<T>(responseText);
            }
        }

        public static T MakePostWebCall<T>(string urlString)
        {
            var rawObj = GetStringFromUrl(urlString, RequestType.POST);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Deserialize<T>(rawObj);
        }

        private static dynamic GetStringFromUrl(string url, RequestType type = RequestType.GET)
        {
            string content = string.Empty;
            using (var client = GetClient())
            {
                if (type == RequestType.POST)
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    content = client.UploadString(url, string.Empty);
                }
                else content = client.DownloadString(url);
            }
            return content;
        }

        private static WebClient GetClient()
        {
            WebClient client = new WebClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12
                | SecurityProtocolType.Ssl3;

            return client;
        }
    }
}
