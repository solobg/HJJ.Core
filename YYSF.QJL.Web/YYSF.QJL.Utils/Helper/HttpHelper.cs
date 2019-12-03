using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace YYSF.QJL.Utils.Helper
{
    public class HttpHelper
    {
        public static string Post(string url, string postData, string contentType = "application/json", Dictionary<string, string> headers = null, int timeOut = 30000)
        {
            return RequestData("post", url, postData, contentType, headers, timeOut);
        }

        public static string Get(string url, Dictionary<string, string> headers = null, int timeOut = 30000)
        {
            return RequestData("get", url, "", "", headers, timeOut);
        }

        public static string RequestData(string method, string url, string postData, string contentType, Dictionary<string, string> headers, int timeOut)
        {
            //Add Log
            try
            {

                if (string.IsNullOrEmpty(url))
                {
                    throw new Exception("url can not be  empty");

                }
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, timeOut);
                    if (!string.IsNullOrEmpty(contentType))
                    {
                        client.DefaultRequestHeaders.Add("ContentType", contentType);
                    }
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    switch (method?.ToLower())
                    {

                        case "get": return client.GetStringAsync(url).Result;
                        case "post": return client.PostAsync(url, new StringContent(postData, Encoding.UTF8)).Result.Content.ReadAsStringAsync().Result;
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
