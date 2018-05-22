using System;
using System.Collections.Generic;
using System.Text;

namespace t03_RequestParser
{
    public class Program
    {
        public static void Main()
        {
            var urls = ReadURLs();

            ReadRequest(urls);
        }

        private static Dictionary<string, List<string>> ReadURLs()
        {
            Dictionary<string, List<string>> urls = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                string path = "/" + data[0].ToLower() ;
                string method = data[1].ToLower();

                if (!urls.ContainsKey(path))
                {
                    urls[path] = new List<string>();
                }

                urls[path].Add(method);

                input = Console.ReadLine();
            }

            return urls;
        }

        private static void ReadRequest(Dictionary<string, List<string>> urls)
        {
            string[] input = Console.ReadLine().Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries);            

            string method = input[0].ToLower();
            string path = input[1].ToLower();
            string scheme = input[2];
            string statusText = "OK";

            if (urls.ContainsKey(path) && urls[path].Contains(method))
            {
                Console.WriteLine($"{scheme} 200 OK");
            }
            else
            {
                statusText = "Not Found";
                Console.WriteLine($"{scheme} 404 NotFound");
            }
            
            Console.WriteLine($"Content-Length: {statusText.Length}");
            Console.WriteLine("Content-Type: text/plain\n");
            Console.WriteLine($"{statusText}");
        }
    }
}
