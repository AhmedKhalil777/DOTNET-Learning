using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Monolith.Graph
{
    public class Startup
    {
		public const string GraphQlPath = "/graphql";
		public const string CustomGraphQlPath = "/custom-path";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public virtual void ConfigureGraphQl(IServiceCollection services) { }

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddMvc()
				.AddNewtonsoftJson(
					options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
				);

			ConfigureGraphQl(services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseGraphiQl();
			app.UseRouting().UseEndpoints(
				routing => routing.MapControllers()
			);
		}
	}
}
