using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddHttpClient("Default",
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddTransient(
                sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));
            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTelerikBlazor();
            await builder.Build().RunAsync();
        }
    }
}
