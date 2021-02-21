using Volo.Abp.Modularity;

namespace Nikia.TelegramBotManager
{
    [DependsOn(
        typeof(TelegramBotManagerApplicationModule),
        typeof(TelegramBotManagerDomainTestModule)
        )]
    public class TelegramBotManagerApplicationTestModule : AbpModule
    {

    }
}