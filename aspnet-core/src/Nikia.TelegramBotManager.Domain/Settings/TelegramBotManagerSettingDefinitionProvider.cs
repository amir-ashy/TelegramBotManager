using Volo.Abp.Settings;

namespace Nikia.TelegramBotManager.Settings
{
    public class TelegramBotManagerSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TelegramBotManagerSettings.MySetting1));
        }
    }
}
