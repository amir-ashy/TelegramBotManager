using AutoMapper;
using Nikia.TelegramBotManager.BotManager;

namespace Nikia.TelegramBotManager
{
    public class TelegramBotManagerApplicationAutoMapperProfile : Profile
    {
        public TelegramBotManagerApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Bot, BotDto>();
            CreateMap<BotDto, Bot>();
            CreateMap<File, FileDto>();
            CreateMap<FileDto, File>();
        }
    }
}
