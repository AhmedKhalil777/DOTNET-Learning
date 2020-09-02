using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpirationDate { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
