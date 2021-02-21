using Nikia.TelegramBotManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Nikia.TelegramBotManager.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TelegramBotManagerController : AbpController
    {
        protected TelegramBotManagerController()
        {
            LocalizationResource = typeof(TelegramBotManagerResource);
        }
    }
}