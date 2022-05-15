using System;

namespace RemoteSample.Lib
{
    internal class RemoteCommand
    {
        public int CommandVersion { get; set; }
        public Commands Command { get; set; }
        public Guid? ObjectId { get; set; }

        public string MemberName { get; set; }

        public object[] Parameters { get; set; }

        public Type[] ParametersTypes { get; set; }

        public Type Type { get; set; }
    }
}
