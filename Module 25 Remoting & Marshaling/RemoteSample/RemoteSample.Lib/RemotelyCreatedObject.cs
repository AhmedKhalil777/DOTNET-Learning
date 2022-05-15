using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSample.Lib
{
    internal class RemotelyCreatedObject
    {
        public int RefCount;
        public object Value { get; set; }
    }
}
