using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace TinyURLShortnener
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Usage: <long URL here>");
            String longURL = Console.ReadLine();
            Console.WriteLine("Tiny URL: ", getTinyUrl(longURL));
        }

        public static string getTinyUrl(string Url)
        {
            try
            {
                if (Url.Length <= 12)
                    return Url;
                if (!Url.ToLower().StartsWith("http") && !Url.ToLower().StartsWith("ftp"))
                    Url = "http://" + Url;
                WebResponse webResponse = WebRequest.Create("http://tinyurl.com/api-create.php?url=" + Url).GetResponse();
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    return reader.ReadToEnd();
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid input");
                return Url;
            }
        }
    }
}
