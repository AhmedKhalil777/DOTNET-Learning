using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Net;
using System.IO;

namespace HTTPWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:5000/main.html";
            WebClient client = new WebClient();
           
            // Download page's source code
            string request = client.DownloadString(uri);
            Console.WriteLine(request);
            // Download files
            client.DownloadFile("http://localhost:5000/download.txt", "test.txt");
            Console.WriteLine("Download Complete");

            byte[] response = client.UploadFile("http://localhost:5000/testupload.txt", "", Directory.GetCurrentDirectory() + "\\upload.txt");
            Console.WriteLine("response:"+Encoding.ASCII.GetString(response));
            
            Console.ReadKey();
        }
    }
}
