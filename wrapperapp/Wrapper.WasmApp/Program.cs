using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Wrapper.WasmApp;
using Wrapper.WasmApp.Clients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProxyClient>(sp => new ProxyClient(sp.GetService<HttpClient>()) { BaseUrl = builder.HostEnvironment.BaseAddress });

await builder.Build().RunAsync();