using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Nikia.TelegramBotManager.BotManager
{
    public class BotUser : FullAuditedEntity<Guid>, IMultiTenant
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public Guid BotId { get; set; }

        public int UserId { get; set; }

        public Guid? TenantId { get; set; }
    }
}
