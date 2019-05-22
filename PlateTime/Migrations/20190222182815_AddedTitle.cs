using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateTimeApp.Migrations
{
    public partial class AddedTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NewsFeeds",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Random Title 1");

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Random Title 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "NewsFeeds");
        }
    }
}
