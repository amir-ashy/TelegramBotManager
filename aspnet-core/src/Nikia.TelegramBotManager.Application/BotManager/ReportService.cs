using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace Nikia.TelegramBotManager.BotManager
{
    public class ReportService : ApplicationService, IReportService
    {
        private readonly IRepository<Bot> botRepository;
        private readonly IRepository<File> fileRepository;
        private readonly IRepository<BotUser> botUserRepository;
        private readonly IRepository<UsageLog> usageLogRepository;
        public ReportService(IRepository<Bot> botRepository, IRepository<File> fileRepository, IRepository<BotUser> botUserRepository, IRepository<UsageLog> usageLogRepository)
        {
            this.botRepository = botRepository;
            this.fileRepository = fileRepository;
            this.botUserRepository = botUserRepository;
            this.usageLogRepository = usageLogRepository;
        }

        public List<BotStatusReportDto> GetBotStatusReportList()
        {
            var query = from bot in botRepository
                        select new BotStatusReportDto
                        {
                            Id = bot.Id,
                            BotIsActive = bot.IsActive,
                            BotName = bot.Name,
                            TenantId = bot.TenantId,
                            TotalFileCount = fileRepository.Count(file => file.BotId == bot.Id),
                            TotalBotUserCount = botUserRepository.Count(botuser => botuser.BotId == bot.Id)
                        };
            return AsyncExecuter.ToListAsync(query).Result;
        }

        public List<ReportDto> GetMostActiveUserList()
        {
            var query = from usageLog in usageLogRepository
                        join botUser in botUserRepository on usageLog.BotUserId equals botUser.Id
                        group usageLog by new { botUser.UserId, botUser.UserName, botUser.LastName, botUser.FirstName } into grp
                        orderby grp.Count() descending
                        select new ReportDto(grp.Key.UserName ?? (grp.Key.FirstName + " " + grp.Key.LastName), grp.Count());
            return AsyncExecuter.ToListAsync(query).Result;
        }

        public List<ReportDto> GetMostUsadedFileList()
        {
            var query = from file in fileRepository
                        join usageLog in usageLogRepository on file.Id equals usageLog.FileId
                        join bot in botRepository on file.BotId equals bot.Id
                        group usageLog by new { fileName = file.Name, file.Id, file.BotId, botName = bot.Name } into grp
                        orderby grp.Count()
                        select new ReportDto((grp.Key.botName + "/" + grp.Key.fileName), grp.Count());
            return AsyncExecuter.ToListAsync(query).Result;
        }
    }
}
