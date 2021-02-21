using System.Collections.Generic;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Json;
using Volo.Abp.Json.SystemTextJson;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.FluentValidation;

namespace Nikia.TelegramBotManager
{
    [DependsOn(
        typeof(TelegramBotManagerDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(TelegramBotManagerApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    [DependsOn(typeof(AbpFluentValidationModule))]
    public class TelegramBotManagerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpSystemTextJsonSerializerOptions>(options =>
            {
                options.UnsupportedTypes.AddIfNotContains(typeof(Telegram.Bot.Types.Update));
                options.UnsupportedTypes.AddIfNotContains(typeof(Telegram.Bot.Types.Message));
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<TelegramBotManagerApplicationModule>();
            });
        }
    }
}
