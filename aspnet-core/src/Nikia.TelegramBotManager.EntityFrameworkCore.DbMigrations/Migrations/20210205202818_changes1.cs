using Microsoft.EntityFrameworkCore.Migrations;

namespace Nikia.TelegramBotManager.Migrations
{
    public partial class changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServerPathId",
                schema: "telegram",
                table: "Bot",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerPathId",
                schema: "telegram",
                table: "Bot");
        }
    }
}
