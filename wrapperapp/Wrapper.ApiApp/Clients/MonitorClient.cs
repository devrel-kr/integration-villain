using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wrapper.ApiApp.Clients
{
    /// <summary>
    /// This provides interfaces to the AKS cluster monitoring client.
    /// </summary>
    public interface IMonitorClient
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to read the response as string or not.
        /// </summary>
        bool ReadResponseAsString { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PowerState"/> value.
        /// </summary>
        /// <param name="name">AKS cluster name.</param>
        /// <returns>Returns the <see cref="PowerState"/> value.</returns>
        Task<PowerState> GetAsync(string name);
    }

    /// <summary>
    /// This represents the entity for the AKS cluster monitoring app.
    /// </summary>
    public partial class MonitorClient : IMonitorClient
    {
    }

    /// <summary>
    /// This represents the fake entity for the AKS cluster monitoring app.
    /// </summary>
    public class FakeMonitorClient : IMonitorClient
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeMonitorClient"/> class.
        /// </summary>
        /// <param name="http"><see cref="HttpClient"/> instance.</param>
        public FakeMonitorClient(HttpClient http)
        {
        }

        /// <inheritdoc/>
        public string BaseUrl { get; set; }

        /// <inheritdoc/>
        public bool ReadResponseAsString { get; set; }

        /// <inheritdoc/>
        public Task<PowerState> GetAsync(string name)
        {
            var code = random.Next(100) % 2;
            var result = new PowerState() { Code = (PowerStateCode)code };

            return Task.FromResult(result);
        }
    }
}