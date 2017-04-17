using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> list = new List<string>();
            using (var fs = new FileStream("urls.txt", FileMode.Open, FileAccess.Read))
            using (var sr = new System.IO.StreamReader(fs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Add sku to list
                    list.Add(line);
                    // Download task                
                    ReadPage(line);             
                    Thread.Sleep(5000); 
                }
            }
        }
        static async void ReadPage(string link)
        {
            var r = await DownloadPage(link);            
            Console.WriteLine(r);
        }
        static async Task<string> DownloadPage(string url)
        {            
            using (var client = new HttpClient())
            {                
                client.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
                using (var r = await client.GetAsync(new Uri(url)))
                {                    
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}