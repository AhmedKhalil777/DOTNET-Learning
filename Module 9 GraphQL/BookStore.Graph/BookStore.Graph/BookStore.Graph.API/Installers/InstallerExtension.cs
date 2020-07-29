using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Graph.API.Installers
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssemblies(this IServiceCollection  services, IConfiguration configuration)
        {
            //هبد التنين 
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
            installers.ForEach(installer =>
            {
                installer.InstallServices(services, configuration);
            });
        }
    }
}
