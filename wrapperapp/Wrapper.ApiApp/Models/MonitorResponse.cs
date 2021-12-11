using Wrapper.ApiApp.Clients;

namespace Wrapper.ApiApp.Models
{
    /// <summary>
    /// This represents the response entity for AKS cluster monitoring.
    /// </summary>
    public class MonitorResponse
    {
        /// <summary>
        /// Gets or sets the AKS cluster name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the AKS cluster power status.
        /// </summary>
        public virtual PowerState PowerState { get; set; }
    }
}