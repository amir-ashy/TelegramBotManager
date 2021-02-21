using System;
using Volo.Abp.Application.Services;

namespace Nikia.TelegramBotManager.BotManager
{
    public interface IBotService : ICrudAppService<BotDto, Guid>
    {

    }
}
