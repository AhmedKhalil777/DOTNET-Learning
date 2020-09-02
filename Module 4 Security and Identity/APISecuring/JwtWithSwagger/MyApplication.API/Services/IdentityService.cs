using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyApplication.API.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.API.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        public IdentityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateSecurityToken(string Username, string Email, string Role)
        {
            var jwtOptions = new JwtOptions();
            _configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptoer = new SecurityTokenDescriptor()
            {
                Audience = jwtOptions.Audience,
                Issuer = jwtOptions.Issuer,
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name ,  Username),
                    new Claim(ClaimTypes.Email,  Email),
                    new Claim(ClaimTypes.Role ,  Role)
                }),
                Expires =  DateTime.Now.AddMinutes(jwtOptions.ExpTime),
                SigningCredentials =  new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),SecurityAlgorithms.HmacSha256 )
            };
            var token = tokenHandler.CreateToken(tokenDescriptoer);
            return tokenHandler.WriteToken(token);
        }
    }
}
