using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.SettingManagement;

namespace Nikia.TelegramBotManager.TelegramBot
{
    public class TelegramService : ApplicationService, IReportService
    {
        private readonly TelegramWorker _telegramWorker;
        private readonly IRepository<BotManager.Bot> botRepository;
        private readonly ISettingManager _settingManager;

        public TelegramService(TelegramWorker telegramWorker, ISettingManager settingManager, IRepository<BotManager.Bot> botRepository)
        {
            _telegramWorker = telegramWorker;
            _settingManager = settingManager;
            this.botRepository = botRepository;
        }

        public async Task<string> GetInitTelegramService()
        {
            var botList = await botRepository.GetListAsync();
            botList = botList.Where(bot => bot.IsActive).ToList();
            foreach (var bot in botList)
            {
                var serviceIndex = Convert.ToInt32(bot.ServerPathId.Replace("Service", string.Empty));
                var botClient = new TelegramBotClient(bot.Token);
                var serverUrl = await _settingManager.GetOrNullGlobalAsync("TelegramBotManager.Server.Url");
                serverUrl = string.Format(serverUrl, serviceIndex.ToString());
                var webhookData = await botClient.GetWebhookInfoAsync();
                if (webhookData.Url.CompareTo(serverUrl) != 0)
                    await botClient.SetWebhookAsync(serverUrl);
            }
            return await Task.FromResult("initiation done");
        }

        public async Task Service1(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service2(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service3(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service4(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service5(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service6(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service7(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service8(Update update) => await _telegramWorker.Proccess(update);

        public async Task Service9(Update update) => await _telegramWorker.Proccess(update);
    }
}