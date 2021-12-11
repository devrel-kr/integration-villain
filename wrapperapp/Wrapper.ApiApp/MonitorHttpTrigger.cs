using System.Net;
using System.Threading.Tasks;

using Aliencube.AzureFunctions.Extensions.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Wrapper.ApiApp.Clients;
using Wrapper.ApiApp.Models;

namespace Wrapper.ApiApp
{
    /// <summary>
    /// This represents the HTTP trigger entity for proxy to the AKS monitoring API.
    /// </summary>
    public class MonitorHttpTrigger
    {
        private readonly ILogger<MonitorHttpTrigger> _logger;
        private readonly IMonitorClient _monitor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorHttpTrigger"/> class.
        /// </summary>
        /// <param name="log"><see cref="ILogger{MonitorHttpTrigger}"/> instance.</param>
        /// <param name="monitor"><see cref="IMonitorClient"/> instance.</param>
        public MonitorHttpTrigger(ILogger<MonitorHttpTrigger> log, IMonitorClient monitor)
        {
            this._logger = log.ThrowIfNullOrDefault();
            this._monitor = monitor.ThrowIfNullOrDefault();
        }

        /// <summary>
        /// Gets the current AKS cluster status.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="name">AKS cluster name.</param>
        /// <returns>Returns the <see cref="PowerState"/> value.</returns>
        [FunctionName(nameof(MonitorHttpTrigger.GetStatusAsync))]
        [OpenApiOperation(operationId: "Status.Get", tags: new[] { "status" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: ContentTypes.ApplicationJson, bodyType: typeof(MonitorResponse), Description = "The current power status")]
        public async Task<IActionResult> GetStatusAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, HttpVerbs.GET, Route = "status/{name}")] HttpRequest req,
            string name)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var result = await this._monitor.GetAsync(name).ConfigureAwait(false);
            var res = new MonitorResponse() { Name = name, PowerState = result.Code.ToString() };

            return new OkObjectResult(res);
        }
    }
}