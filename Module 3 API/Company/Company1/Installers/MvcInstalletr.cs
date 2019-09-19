using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Company1.Installers
{
    public class MvcInstalletr : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {

            #region MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
            });
            #endregion
        }
    }
}
