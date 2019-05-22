using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateTimeApp.Migrations
{
    public partial class NewsInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsFeeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeeds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "News API has been initialized" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "User Profile page has been initialized" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsFeeds");
        }
    }
}
