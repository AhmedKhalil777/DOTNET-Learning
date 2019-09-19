using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company1.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallerServicesInAssemply(this IServiceCollection services , IConfiguration Configuration)
        {
            var Installers = typeof(Startup).Assembly.ExportedTypes
          .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
          .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            Installers.ForEach(Installer => Installer.InstallServices(services, Configuration));

        }
    }
}
