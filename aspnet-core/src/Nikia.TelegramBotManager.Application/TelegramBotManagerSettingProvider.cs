using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Settings;

namespace Nikia.TelegramBotManager
{
    class TelegramBotManagerSettingProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition("TelegramBotManager.Server.Url", "localhost"));
        }
    }
}
