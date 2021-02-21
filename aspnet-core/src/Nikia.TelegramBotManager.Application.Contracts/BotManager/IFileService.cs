using System;
using Volo.Abp.Application.Services;

namespace Nikia.TelegramBotManager.BotManager
{
    public interface IFileService : ICrudAppService<FileDto, Guid, FileResultRequestDto>
    {

    }
}
