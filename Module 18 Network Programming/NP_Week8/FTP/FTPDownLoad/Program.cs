using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace FTPDownLoad
{
    class Program
    {
        static void Main(string[] args)
        {
             // create a Download request 
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://speedtest.tele2.net/512KB.zip");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // Login to the FTP server as anonymous
            request.Credentials = new NetworkCredential("anonymous", "anonymous");

            // Get the respose of the download request
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            // Read the response stream
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            // write the resonse status to the console
            Console.WriteLine("Download Complete, status" + response.StatusDescription);
            
            Console.ReadKey();
            reader.Close();
            response.Close();
        }
    }
}
