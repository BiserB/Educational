using System;
using System.Net;

namespace t02_ValidateURL
{
    public class Program
    {
        private static readonly string HTTP = "http";
        private static readonly string HTTPS = "https";

        private static readonly int HTTP_PORT = 80;
        private static readonly int HTTPS_PORT = 443;

        public static void Main()
        {   
            try
            {
                string input = Console.ReadLine();

                Uri uri = new Uri(input);

                ValidateURI(uri);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");                
            }
            
        }

        private static void ValidateURI(Uri uri)
        {
            //  protocol://host:port/path?query#fragment

            string protocol = uri.Scheme;
            string host = uri.Host;
            int port = uri.Port;
            string path = uri.AbsolutePath;
            string queryPart = uri.Query; 
            string fragmentPart = uri.Fragment;             

            if (protocol != HTTP && protocol != HTTPS)
            {
                throw new UriFormatException();
            }
            if (protocol == HTTP && port != HTTP_PORT)
            {
                throw new UriFormatException();
            }
            if (protocol == HTTPS && port != HTTPS_PORT)
            {
                throw new UriFormatException();
            }

            Console.WriteLine("Protocol: {0}", protocol);
            Console.WriteLine("Host: {0}", host);
            Console.WriteLine("Port: {0}", port);
            Console.WriteLine("Path: {0}", WebUtility.UrlDecode(path));

            if (!String.IsNullOrEmpty(queryPart))
            {                
                string decodedQuery = WebUtility.UrlDecode(queryPart.ToString());
                string query = decodedQuery.Substring(1, decodedQuery.Length - 1);
                Console.WriteLine("Query: {0}", query);
            }

            if (!String.IsNullOrEmpty(fragmentPart))
            {
                string decodedFragment = WebUtility.UrlDecode(fragmentPart);
                string fragment = decodedFragment.Substring(1, decodedFragment.Length - 1);
                Console.WriteLine("Fragment: {0}", fragment);
            }
            
        }        

    }    
}
