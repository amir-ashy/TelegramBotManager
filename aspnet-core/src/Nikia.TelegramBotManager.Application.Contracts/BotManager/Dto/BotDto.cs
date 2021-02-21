using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;

namespace Nikia.TelegramBotManager.BotManager
{
    public class BotDto : FullAuditedEntityDto<Guid>, IMultiTenant
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
