using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.API.Options
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public int ExpTime { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

    }
}
