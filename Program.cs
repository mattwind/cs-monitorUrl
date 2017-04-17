using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> list = new List<string>();
            using (var fs = new FileStream("skus.txt", FileMode.Open, FileAccess.Read))
            using (var sr = new System.IO.StreamReader(fs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line); 
                    Console.WriteLine(line);
                }
            }
        }
    }
}