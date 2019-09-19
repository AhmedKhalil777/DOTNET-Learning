using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company1.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";

        public const string Base = Root + "/" + Version;
        public static class Employee
        {

            public const string GetAll = Base +"/employee";
            public const string Get = Base + "/employee/{Id}";
            public const string Update = Base + "/employee/{Id}";
            public const string Create = Base + "/employee";
            public const string Delete = Base + "/employee/{Id}";
        }
    }
}
