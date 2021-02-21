using Microsoft.EntityFrameworkCore.Migrations;

namespace Nikia.TelegramBotManager.Migrations
{
    public partial class changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "telegram",
                table: "BotUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "telegram",
                table: "BotUser");
        }
    }
}
