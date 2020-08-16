using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sample.API.Services;
using Sample.API.Settings;
using System.Text;


namespace Sample.API.Middleware
{
    public static class JwtMiddileware
    {
        public static IServiceCollection AddTokenAuthintication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<JwtSettings>();
            var jwtSettings = new JwtSettings();
            configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
       
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(settings => {
                settings.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new  SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience= jwtSettings.Audience,
                    ValidIssuer =  jwtSettings.Issuer  
                };
            });

            return services;

        }
    }
}
