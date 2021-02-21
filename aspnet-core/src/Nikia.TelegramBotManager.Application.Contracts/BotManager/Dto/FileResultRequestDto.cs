using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Nikia.TelegramBotManager.BotManager
{
    public class FileResultRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? BotId { get; set; }
    }
}
