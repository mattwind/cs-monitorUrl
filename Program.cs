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
        static async void ReadPage(string url)
        {
            var r = await DownloadPage(url);            
            Console.WriteLine(r.Substring(0, 50));
        }
        static async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}