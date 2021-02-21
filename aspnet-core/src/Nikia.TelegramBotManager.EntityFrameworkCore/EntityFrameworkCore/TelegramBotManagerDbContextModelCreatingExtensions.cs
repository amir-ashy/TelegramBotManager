using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Nikia.TelegramBotManager.EntityFrameworkCore
{
    public static class TelegramBotManagerDbContextModelCreatingExtensions
    {
        public static void ConfigureTelegramBotManager(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<BotManager.Bot>(b =>
            {
                b.ToTable("Bot",TelegramBotManagerConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.Token).IsRequired();
            });

            builder.Entity<BotManager.BotUser>(b =>
            {
                b.ToTable("BotUser", TelegramBotManagerConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<BotManager.Bot>().WithMany().HasForeignKey(x => x.BotId).IsRequired();
            });

            builder.Entity<BotManager.File>(b =>
            {
                b.ToTable("File", TelegramBotManagerConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<BotManager.Bot>().WithMany().HasForeignKey(x => x.BotId).IsRequired();
            });

            builder.Entity<BotManager.UsageLog>(b =>
            {
                b.ToTable("UsageLog", TelegramBotManagerConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasOne<BotManager.File>().WithMany().HasForeignKey(x => x.FileId).IsRequired();
                b.HasOne<BotManager.BotUser>().WithMany().HasForeignKey(x => x.BotUserId).IsRequired();
            });
        }
    }
}