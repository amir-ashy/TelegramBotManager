using Microsoft.Extensions.Logging;
using Nikia.TelegramBotManager.BotManager;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace Nikia.TelegramBotManager.TelegramBot
{
    public class TelegramWorker : ITransientDependency
    {

        private readonly ILogger<TelegramService> _logger;
        private readonly IRepository<BotManager.File> _fileRepository;
        private readonly IRepository<Bot> _botRepository;
        private readonly IDataFilter _dataFilter;
        private readonly IRepository<BotUser> _botUserRepository;
        private readonly IRepository<UsageLog> _usageLogRepository;

        public TelegramWorker(ILogger<TelegramService> logger, IRepository<Bot> botRepository, IRepository<BotManager.File> fileRepository,
            IDataFilter dataFilter, IRepository<UsageLog> usageLogRepository, IRepository<BotUser> botUserRepository)
        {
            _logger = logger;
            _botRepository = botRepository;
            _fileRepository = fileRepository;
            _dataFilter = dataFilter;
            _usageLogRepository = usageLogRepository;
            _botUserRepository = botUserRepository;
        }

        public async Task Proccess(Update update, [CallerMemberName] string botServiceName = "")
        {
            try
            {
                if (update.Type != UpdateType.Message || botServiceName == null)
                    return;

                var botIndex = Convert.ToInt32(botServiceName.Replace("Service", string.Empty));
                if (botIndex == 0)
                    return;

                var message = update.Message;
                Bot bot = null;
                using (_dataFilter.Disable<IMultiTenant>())
                    bot = await _botRepository.GetAsync(b => b.ServerPathId.CompareTo(botServiceName) == 0);
                if (bot == null)
                    return;
                var telegramBotClient = new TelegramBotClient(bot.Token);
                await DoProccess(message, telegramBotClient, bot);
                _logger.LogInformation("Received Message from {0}", message.Chat.Id);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.StackTrace);
                throw;
            }
        }

        public async Task DoProccess(Message message, TelegramBotClient telegramBotClient, Bot bot)
        {
            try
            {
                if (message == null || message.Type != MessageType.Text)
                    return;
                var messagesArrayList = message.Text.Split(' ');
                if (bot.CheckMembership)
                {
                    var channelStatus = telegramBotClient.GetChatMemberAsync(bot.MembershipTargetId, message.From.Id).Result;
                    if (channelStatus.Status != ChatMemberStatus.Administrator &&
                        channelStatus.Status != ChatMemberStatus.Creator && channelStatus.Status != ChatMemberStatus.Member)
                    {
                        await NotMember(message, telegramBotClient, bot);
                        return;
                    }
                }
                switch (messagesArrayList.First())
                {
                    case "/start":
                        if (messagesArrayList.Count() == 2)
                            await SendDocument(message, telegramBotClient, bot);
                        else
                            await SendText(message, telegramBotClient, "Bad Usage");
                        break;
                    default:
                        await SendText(message, telegramBotClient, "Bad Usage");
                        break;

                }
            }
            catch (Exception exp)
            {
                await SendText(message, telegramBotClient, exp.StackTrace);
                throw;
            }
        }
        private async Task SendDocument(Message message, TelegramBotClient telegramBotClient, Bot bot)
        {
            var messages = message.Text.Split(' ');
            if (messages.Length < 2)
                return;
            var fileCodepath = messages[1];
            if (fileCodepath == null || fileCodepath.Equals(string.Empty))
                return;

            BotManager.File file = null;
            using (_dataFilter.Disable<IMultiTenant>())
                file = await _fileRepository.FindAsync(f => f.ShareUrl.Contains(fileCodepath) && f.BotId == bot.Id);
            if (file == null)
                return;

            switch (file.FileType)
            {
                case BotManager.FileType.Audio:
                    await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadAudio);
                    await telegramBotClient.SendAudioAsync(chatId: message.Chat.Id, audio: file.FileUrl);
                    break;
                case BotManager.FileType.Video:
                    await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadVideo);
                    await telegramBotClient.SendVideoAsync(chatId: message.Chat.Id, video: file.FileUrl);
                    break;
                case BotManager.FileType.Document:
                    await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadDocument);
                    await telegramBotClient.SendDocumentAsync(chatId: message.Chat.Id, document: file.FileUrl);
                    break;
                case BotManager.FileType.Image:
                    await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);
                    await telegramBotClient.SendPhotoAsync(chatId: message.Chat.Id, photo: file.FileUrl);
                    break;
                default:
                    break;
            }
            await GenerateFileLog(message, file, bot);

        }
        private async Task GenerateFileLog(Message message, BotManager.File file, Bot bot)
        {
            BotUser botUser = null;
            using (_dataFilter.Disable<IMultiTenant>())
                botUser = await _botUserRepository.FindAsync(bu => bu.BotId.CompareTo(bot.Id) == 0 && bu.UserId == message.From.Id);
            if (botUser == null)
            {
                botUser = new BotUser()
                {
                    BotId = bot.Id,
                    FirstName = message.From.FirstName,
                    IsActive = true,
                    LastName = message.From.LastName,
                    UserId = message.From.Id,
                    UserName = message.From.Username,
                    TenantId = bot.TenantId

                };
                await _botUserRepository.InsertAsync(botUser);
            }
            var usageLog = new UsageLog()
            {
                BotUserId = botUser.Id,
                FileId = file.Id,
                requestDateTime = DateTime.Now,
                RequestUrl = file.ShareUrl,//TODO
                TenantId = bot.TenantId,
                UsageResultType = UsageResultType.Done
            };
            await _usageLogRepository.InsertAsync(usageLog);
        }

        private async Task NotMember(Message message, TelegramBotClient telegramBotClient, Bot bot)
        {
            string usage = $@"You are not a member of seyed dana channel

To proceed, please join:

╭                                           ╮
  💪🏻 @{bot.MembershipTargetId} 💪🏻
╰                                           ╯

And then, try again";
            await telegramBotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: usage,
                replyMarkup: new ReplyKeyboardRemove()
            );
        }

        private async Task SendText(Message message, TelegramBotClient telegramBotClient, string text)
        {
            await telegramBotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: text,
                replyMarkup: new ReplyKeyboardRemove()
            );
        }
    }
}
