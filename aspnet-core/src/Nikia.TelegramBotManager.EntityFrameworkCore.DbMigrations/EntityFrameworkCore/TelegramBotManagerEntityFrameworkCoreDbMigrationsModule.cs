using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Nikia.TelegramBotManager.EntityFrameworkCore
{
    [DependsOn(
        typeof(TelegramBotManagerEntityFrameworkCoreModule)
        )]
    public class TelegramBotManagerEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TelegramBotManagerMigrationsDbContext>();
        }
    }
}
