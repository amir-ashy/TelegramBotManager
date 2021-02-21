using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;

namespace Nikia.TelegramBotManager.BotManager
{
    public class ReportDto : EntityDto
    {
        public ReportDto(string name, long value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public long Value { get; set; }
    }
}
