using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHook.Sample.Framework
{
    public class WebhookOptions
    {
        public string RoutePrefix { get; set; } = "webhooks";
    }
    public static class WebHooksExtensions
    {


        public static IServiceCollection AddWebhooks(
            this IServiceCollection services,
            Action<WebhookOptions> spaceAction = null)
        {
            var options = new WebhookOptions();

            services.Configure<RouteOptions>(opt =>
            {
                opt.ConstraintMap.Add("webhookRoutePrefix", typeof(WebhookRoutePrefixConstraint));
            });
            spaceAction?.Invoke(options);
            services.AddSingleton(options);

            return services;
        }
    }
}
