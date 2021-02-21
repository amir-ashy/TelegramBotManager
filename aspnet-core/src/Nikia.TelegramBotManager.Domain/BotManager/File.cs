using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Nikia.TelegramBotManager.BotManager
{
    public class File : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid BotId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public string ShareUrl { get; set; }
        public FileType FileType { get; set; }

        public Guid? TenantId { get; set; }

        public void SetId(Guid id) => this.Id = id;
    }
}
