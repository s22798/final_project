using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;
using final_project.Client.Services.News;
using final_project.Client.Services.Charts;
using final_project.Client.Services.Company;

namespace final_project.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("final_project.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("final_project.ServerAPI"));
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<IChartService, ChartService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

            builder.Services.AddApiAuthorization();


            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjU3ODI4QDMyMzAyZTMxMmUzMGNTbnFhZUJYUlZDYm15MUNzREtrc2NQSzhyYW0vaHJDako3ZG1zbnZKUHc9");
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

            await builder.Build().RunAsync();
        }
    }
}
