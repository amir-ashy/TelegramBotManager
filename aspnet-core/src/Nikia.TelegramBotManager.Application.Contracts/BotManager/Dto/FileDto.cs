using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;

namespace Nikia.TelegramBotManager.BotManager
{
    public class FileDto : FullAuditedEntityDto<Guid>, IMultiTenant
    {
        public Guid BotId { get; set; }
        public string BotName { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string FileUrl { get; set; }
        public string ShareUrl { get; set; }
        public FileType FileType { get; set; }

        public Guid? TenantId { get; set; }
    }
}
