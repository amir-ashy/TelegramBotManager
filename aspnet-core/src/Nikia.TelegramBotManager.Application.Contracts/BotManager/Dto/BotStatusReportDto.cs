using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;

namespace Nikia.TelegramBotManager.BotManager
{
    public class BotStatusReportDto : EntityDto<Guid>, IMultiTenant
    {
        public string BotName { get; set; }
        public bool BotIsActive { get; set; }
        public int TotalFileCount { get; set; }
        public int TotalBotUserCount { get; set; }
        public Guid? TenantId { get; set; }
    }
}
