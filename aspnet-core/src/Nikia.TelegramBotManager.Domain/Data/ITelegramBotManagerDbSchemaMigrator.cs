using System.Threading.Tasks;

namespace Nikia.TelegramBotManager.Data
{
    public interface ITelegramBotManagerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
