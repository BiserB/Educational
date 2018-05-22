using System;
using System.Net;

namespace t01_URL_Decode
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string decodedInput = WebUtility.UrlDecode(input);

            Console.WriteLine(decodedInput);
        }
    }
}
