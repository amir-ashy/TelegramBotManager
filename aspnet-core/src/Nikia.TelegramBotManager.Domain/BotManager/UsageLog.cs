using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Nikia.TelegramBotManager.BotManager
{
    public class UsageLog : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid BotUserId { get; set; }
        public Guid FileId { get; set; }
        public string RequestUrl { get; set; }
        public UsageResultType UsageResultType { get; set; }
        public DateTime requestDateTime { get; set; }


        public Guid? TenantId { get; set; }
    }
}
