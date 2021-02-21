namespace Nikia.TelegramBotManager.Permissions
{
    public static class TelegramBotManagerPermissions
    {
        public const string GroupName = "TelegramBotManager";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";


        public static class Files
        {
            public const string Default = GroupName + ".Files";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Bots
        {
            public const string Default = GroupName + ".Bots";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}