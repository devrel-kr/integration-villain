using Microsoft.AspNetCore.Components;

using Wrapper.WasmApp.Clients;

namespace Wrapper.WasmApp.Pages
{
    /// <summary>
    /// This represents the "index" page.
    /// </summary>
    public partial class Index : ComponentBase
    {
        /// <summary>
        /// Gets or sets the <see cref="IProxyClient"/> instance as the injected dependency.
        /// </summary>
        [Inject]
        public virtual IProxyClient? Proxy { get; set; }

        /// <summary>
        /// Gets or sets the AKS cluster name.
        /// </summary>
        protected virtual string? AksClusterName { get; set; }

        /// <summary>
        /// Gets or sets the AKS cluster status.
        /// </summary>
        protected virtual string? AksClusterStatus { get; set; }

        /// <summary>
        /// Checks the AKS cluster status.
        /// </summary>
        protected virtual async Task CheckAksClusterStatusAsync()
        {
            var result = await this.Proxy.Status_GetAsync(this.AksClusterName).ConfigureAwait(false);

            this.AksClusterStatus = result.PowerState;
        }
    }
}