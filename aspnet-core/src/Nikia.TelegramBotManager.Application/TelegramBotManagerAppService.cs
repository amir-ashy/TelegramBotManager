using System;
using System.Collections.Generic;
using System.Text;
using Nikia.TelegramBotManager.Localization;
using Volo.Abp.Application.Services;

namespace Nikia.TelegramBotManager
{
    /* Inherit your application services from this class.
     */
    public abstract class TelegramBotManagerAppService : ApplicationService
    {
        protected TelegramBotManagerAppService()
        {
            LocalizationResource = typeof(TelegramBotManagerResource);
        }
    }
}
