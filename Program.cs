using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace httpPost
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://httpbin.org/post");
            //httpWebRequest.ProtocolVersion = HttpVersion.Version10;//http1.0
            //httpWebRequest.Connection = "Close";
            httpWebRequest.ContentType = "text/json;charset=UTF-8";
            httpWebRequest.Method = "POST";
            //httpWebRequest.ContentLength = 10000;


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"key\": \"value\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }


            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.ReadKey();
            }

            Console.ReadKey();





        }
    }
}
