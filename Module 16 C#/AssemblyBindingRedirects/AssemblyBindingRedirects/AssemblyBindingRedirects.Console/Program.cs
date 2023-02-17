using Sample.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBindingRedirects.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var smaple = new Sample.Assembly.Sample();
            smaple.WhoIsMe();

        }
    }
}
