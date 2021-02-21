using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Nikia.TelegramBotManager
{
    [Dependency(ReplaceServices = true)]
    public class TelegramBotManagerBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "TelegramBotManager";
    }
}
