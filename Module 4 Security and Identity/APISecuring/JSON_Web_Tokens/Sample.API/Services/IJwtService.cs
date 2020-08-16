using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Services
{
    public interface IJwtService
    {
        public string GetSecurityToken(string Email, string Username, string Role);
    }
}
