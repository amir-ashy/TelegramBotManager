using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Volo.Abp.Application.Services;

namespace Nikia.TelegramBotManager.TelegramBot
{
    public interface IReportService : IApplicationService
    {
        Task Service1(Update update);
        Task Service2(Update update);
        Task Service3(Update update);
        Task Service4(Update update);
        Task Service5(Update update);
        Task Service6(Update update);
        Task Service7(Update update);
        Task Service9(Update update);
        Task Service8(Update update);

        Task<string> GetInitTelegramService();
    }
}
