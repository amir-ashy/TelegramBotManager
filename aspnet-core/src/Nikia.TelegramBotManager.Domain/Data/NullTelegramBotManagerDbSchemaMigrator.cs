using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Nikia.TelegramBotManager.Data
{
    /* This is used if database provider does't define
     * ITelegramBotManagerDbSchemaMigrator implementation.
     */
    public class NullTelegramBotManagerDbSchemaMigrator : ITelegramBotManagerDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}