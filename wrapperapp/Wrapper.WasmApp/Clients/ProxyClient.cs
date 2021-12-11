namespace Wrapper.WasmApp.Clients
{
    /// <summary>
    /// This provides interfaces to the proxy API client.
    /// </summary>
    public interface IProxyClient
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
        /// Gets the AKS cluster status.
        /// </summary>
        /// <param name="name">AKS cluster name.</param>
        /// <returns>Returns the <see cref="MonitorResponse"/> object.</returns>
        Task<MonitorResponse> Status_GetAsync(string name);
    }

    /// <summary>
    /// This represents the entity for the proxy API client.
    /// </summary>
    public partial class ProxyClient : IProxyClient
    {
    }
}