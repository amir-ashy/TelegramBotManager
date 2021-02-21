using Nikia.TelegramBotManager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Nikia.TelegramBotManager.Permissions
{
    public class TelegramBotManagerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TelegramBotManagerPermissions.GroupName, L("Permission:TelegramBotManager"));

            var botsPermission = myGroup.AddPermission(TelegramBotManagerPermissions.Bots.Default, L("Permission:Bots"));
            botsPermission.AddChild(TelegramBotManagerPermissions.Bots.Create, L("Permission:Bots.Create"));
            botsPermission.AddChild(TelegramBotManagerPermissions.Bots.Edit, L("Permission:Bots.Edit"));
            botsPermission.AddChild(TelegramBotManagerPermissions.Bots.Delete, L("Permission:Bots.Delete"));


            var filesPermission = myGroup.AddPermission(TelegramBotManagerPermissions.Files.Default, L("Permission:Files"));
            filesPermission.AddChild(TelegramBotManagerPermissions.Files.Create, L("Permission:Files.Create"));
            filesPermission.AddChild(TelegramBotManagerPermissions.Files.Edit, L("Permission:Files.Edit"));
            filesPermission.AddChild(TelegramBotManagerPermissions.Files.Delete, L("Permission:Files.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TelegramBotManagerResource>(name);
        }
    }
}
