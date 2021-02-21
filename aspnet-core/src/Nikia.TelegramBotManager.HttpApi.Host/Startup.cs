using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Volo.Abp.AspNetCore.ExceptionHandling;

namespace Nikia.TelegramBotManager
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplication<TelegramBotManagerHttpApiHostModule>();
            services.Configure<AbpExceptionHandlingOptions>(options =>
            {
                options.SendExceptionsDetailsToClients = true;
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
