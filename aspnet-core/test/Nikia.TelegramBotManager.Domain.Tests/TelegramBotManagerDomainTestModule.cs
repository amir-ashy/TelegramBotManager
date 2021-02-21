using Nikia.TelegramBotManager.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Nikia.TelegramBotManager
{
    [DependsOn(
        typeof(TelegramBotManagerEntityFrameworkCoreTestModule)
        )]
    public class TelegramBotManagerDomainTestModule : AbpModule
    {

    }
}