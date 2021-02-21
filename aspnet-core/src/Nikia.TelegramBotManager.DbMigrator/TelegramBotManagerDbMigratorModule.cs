using Nikia.TelegramBotManager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Nikia.TelegramBotManager.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TelegramBotManagerEntityFrameworkCoreDbMigrationsModule),
        typeof(TelegramBotManagerApplicationContractsModule)
        )]
    public class TelegramBotManagerDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
