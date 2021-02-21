using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Volo.Abp.Application.Services;

namespace Nikia.TelegramBotManager.BotManager
{
    public interface IReportService : IApplicationService
    {
        List<BotStatusReportDto> GetBotStatusReportList();

        List<ReportDto> GetMostUsadedFileList();

        List<ReportDto> GetMostActiveUserList();
    }
}
