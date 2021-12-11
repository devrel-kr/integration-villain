using System;
using System.Net.Http;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using Wrapper.ApiApp.Clients;

[assembly: FunctionsStartup(typeof(Wrapper.ApiApp.Startup))]

namespace Wrapper.ApiApp
{
    /// <summary>
    /// This represents the entity for the function app bootstrapping.
    /// </summary>
    public class Startup : FunctionsStartup
    {
        /// <inheritdoc/>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<IMonitorClient>(p =>
            {
                var monitor = new FakeMonitorClient(p.GetService<HttpClient>())
                {
                    BaseUrl = Environment.GetEnvironmentVariable("Monitoring__BaseUrl")
                };

                return monitor;
            });
        }
    }
}