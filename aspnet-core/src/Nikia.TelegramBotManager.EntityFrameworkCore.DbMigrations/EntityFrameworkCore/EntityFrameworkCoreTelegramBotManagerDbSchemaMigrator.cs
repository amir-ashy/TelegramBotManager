using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nikia.TelegramBotManager.Data;
using Volo.Abp.DependencyInjection;

namespace Nikia.TelegramBotManager.EntityFrameworkCore
{
    public class EntityFrameworkCoreTelegramBotManagerDbSchemaMigrator
        : ITelegramBotManagerDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTelegramBotManagerDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TelegramBotManagerMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TelegramBotManagerMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}