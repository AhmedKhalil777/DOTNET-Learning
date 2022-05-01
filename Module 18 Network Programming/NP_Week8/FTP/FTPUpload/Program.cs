using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Net;
using System.IO;

namespace FTPUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an upload request to the FTP server
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://speedtest.tele2.net/upload/test.txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Login as anonymous
            request.Credentials = new NetworkCredential("anonymous", "anonymous");

            // Copy the contents of the file to the request stream.
            // read the local file's contents as a stream
            StreamReader sourceStream = new StreamReader(Directory.GetCurrentDirectory()+"\\testfile.txt");
            // create a byte array of the file contents
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            
            // specify the request length
            request.ContentLength = fileContents.Length;

            // The using block helps manage resources. 
            // It protects the whole system's resources by specifying the scope of the usage of the resource.

            // get the request stream
            using (Stream requestStream = request.GetRequestStream())
            {
                // write the byte[] array on the request stream to begin the upload process
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            // get the reponse from the server
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                // print the response status line to the console
                Console.WriteLine("Upload File Complete, status"+ response.StatusDescription);
            }

            
            Console.ReadKey();
        }
    }
}
