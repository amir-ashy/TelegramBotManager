using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Nikia.TelegramBotManager.BotManager
{
    public class Bot : FullAuditedEntity<Guid>, IMultiTenant
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }
        public bool CheckMembership { get; set; }
        public string MembershipTargetId { get; set; }
        public string ServerPathId { get; set; }

        public Guid? TenantId { get; set; }
    }
}
