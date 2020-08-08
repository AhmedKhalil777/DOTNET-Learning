using GraphiQl;
using GraphQL;
using GraphQL.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BookStore.Graph.API.Installers
{
    public class ViewInstaller : IInstaller
    {
        public virtual void ConfigureGraphQl(IServiceCollection services) { }
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc()
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            ConfigureGraphQl(services);
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
        }
    }
}
