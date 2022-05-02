using System;
using System.Net;
namespace PreviewJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetDataFromURL("https://api.github.com/users/omarshatta98/repos?fbclid=IwAR0OMpxDLqoSG6geaP6rRQg7T0OWOprZstEslRgvCaEq51XA6adSP9FRUzY"));
        }
        public static string GetDataFromURL( string url)
        {
            string data;
            using(var client = new WebClient())
            {
                client.Headers.Add("User-Agent: Other");
                try
                {
                    data = client.DownloadString(url);
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            return data;
        }
    }
}
