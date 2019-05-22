using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateTimeApp.Migrations
{
    public partial class AddedNewsDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NewsDate",
                table: "NewsFeeds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 1,
                column: "NewsDate",
                value: new DateTime(2018, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 2,
                column: "NewsDate",
                value: new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 3,
                column: "NewsDate",
                value: new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>ut dolore laoreet tincidunt ut tincidunt erat magna ipsum aliquam sed aliquam erat ut diam nonummy amet laoreet lorem laoreet consectetuer nonummy. consectetuer consectetuer ut lorem ut ipsum dolor sit dolor euismod tincidunt amet sed sit sit nonummy ipsum euismod adipiscing ipsum amet ipsum. tincidunt sed consectetuer elit erat nonummy sit euismod sed ipsum magna amet nibh diam aliquam ut erat aliquam laoreet magna laoreet laoreet. consectetuer ut consectetuer consectetuer adipiscing ut tincidunt elit diam amet consectetuer sit euismod adipiscing ut adipiscing dolor euismod lorem diam sit nibh. elit amet euismod tincidunt nibh elit tincidunt elit consectetuer elit consectetuer magna sit nonummy dolor tincidunt sit diam erat lorem euismod tincidunt. </p>", new DateTime(2019, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>euismod nonummy aliquam nonummy ut euismod. ut ut nonummy euismod ipsum nibh. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>magna magna amet consectetuer sit magna lorem elit euismod diam aliquam laoreet diam nibh ipsum aliquam euismod ipsum tincidunt euismod amet amet sit erat. euismod adipiscing nibh diam euismod lorem laoreet sed euismod magna aliquam elit nonummy amet dolore dolor adipiscing adipiscing euismod elit amet sed nibh dolor. nonummy laoreet aliquam consectetuer consectetuer dolore dolor euismod tincidunt amet tincidunt magna adipiscing nonummy laoreet euismod ut diam sit nibh tincidunt ut sed elit. consectetuer nibh consectetuer aliquam euismod dolore laoreet sit ut sed aliquam magna ipsum nonummy dolor laoreet laoreet consectetuer tincidunt consectetuer nibh aliquam dolore dolore. </p>", new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>euismod laoreet dolor euismod. ut ipsum lorem ut. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>nibh sed adipiscing laoreet aliquam tincidunt ipsum consectetuer lorem erat consectetuer erat nonummy magna euismod dolore euismod lorem erat magna sit aliquam sit sit sed magna nonummy dolor. adipiscing adipiscing magna ipsum erat sed sed dolore nibh sed sed sed aliquam adipiscing diam erat laoreet erat nonummy ut dolor elit elit adipiscing nibh ipsum nibh tincidunt. consectetuer dolor adipiscing ipsum dolor erat erat ut ipsum amet erat dolor diam dolore consectetuer sit euismod nibh aliquam dolore sed sit sed sed adipiscing laoreet erat erat. aliquam nibh diam aliquam dolore laoreet nonummy sed ipsum elit consectetuer erat elit ut aliquam nibh erat sed consectetuer adipiscing dolor sit tincidunt lorem dolor laoreet amet dolor. ut aliquam ut elit erat erat dolore nonummy ut ipsum consectetuer ut consectetuer dolore ipsum consectetuer consectetuer erat sed ut amet magna sed magna diam tincidunt dolore laoreet. </p>", new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>tincidunt tincidunt ut dolor. consectetuer lorem euismod sit. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>ut euismod amet diam sit ipsum diam erat sed adipiscing sit amet aliquam sed nonummy elit dolor adipiscing erat lorem euismod dolor consectetuer sit nonummy tincidunt. magna diam adipiscing nibh nonummy laoreet elit euismod ut adipiscing amet nonummy diam sit sit ut dolore ut sit euismod magna nibh sit adipiscing diam amet. adipiscing dolore magna nibh elit lorem erat diam sit lorem euismod dolore dolore elit magna consectetuer tincidunt amet sit nibh magna laoreet dolore aliquam adipiscing nonummy. lorem magna dolore adipiscing adipiscing lorem dolor adipiscing sed nonummy laoreet dolor erat sit nibh erat lorem sit ipsum lorem aliquam laoreet laoreet nibh magna erat. dolor magna adipiscing nibh lorem aliquam consectetuer dolore lorem ipsum tincidunt magna ut nibh tincidunt diam aliquam adipiscing diam nonummy amet lorem erat aliquam laoreet tincidunt. </p>", new DateTime(2018, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>erat adipiscing consectetuer laoreet. adipiscing adipiscing laoreet lorem. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>euismod dolor dolore sed sit nibh consectetuer sed ut magna ipsum laoreet lorem sit erat dolor dolor amet dolore dolor dolore aliquam adipiscing sed adipiscing adipiscing tincidunt dolore dolor. aliquam sit dolore magna euismod dolor dolore erat diam ut adipiscing sed lorem consectetuer consectetuer consectetuer sed aliquam amet dolore ut adipiscing nibh sit nibh lorem tincidunt laoreet sed. ipsum magna magna diam adipiscing laoreet ut amet magna elit ipsum dolor sit euismod diam nonummy tincidunt laoreet tincidunt ipsum dolor aliquam sed sed erat elit euismod nibh tincidunt. consectetuer euismod sed lorem nonummy sed magna sed erat ut diam nibh lorem nonummy nonummy dolor tincidunt nibh tincidunt ipsum euismod aliquam amet lorem ut consectetuer sit diam diam. diam aliquam sit dolor nonummy euismod ut euismod dolor euismod amet euismod dolor ut lorem sit nonummy ipsum elit magna adipiscing adipiscing laoreet aliquam diam ipsum elit sed sed. </p>", new DateTime(2019, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>erat nibh nibh diam. euismod euismod elit elit. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>ipsum nonummy adipiscing ipsum ut lorem nibh nibh erat laoreet dolore tincidunt ipsum ipsum nonummy diam euismod lorem elit dolor elit tincidunt ipsum amet laoreet lorem dolor nonummy. dolor tincidunt laoreet consectetuer elit erat magna dolore ut ut sed nonummy amet amet ut erat nonummy erat nibh sed sit ut nibh sed euismod elit sed sed. diam ipsum consectetuer tincidunt magna lorem sed consectetuer lorem nonummy consectetuer ipsum amet ut ut magna euismod dolore magna sit erat ipsum tincidunt laoreet diam ut elit elit. dolor adipiscing euismod erat nibh diam adipiscing euismod diam ut tincidunt amet laoreet sed erat erat ut diam amet sed erat ut dolore dolore nonummy consectetuer diam elit. </p>", new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>laoreet sit dolor nonummy magna magna sed. dolor magna amet euismod diam dolore elit. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "NewsDate", "Title" },
                values: new object[] { "<p>ut nibh dolore amet consectetuer lorem adipiscing lorem lorem amet dolor consectetuer ipsum nibh elit erat sed ipsum erat aliquam nonummy tincidunt laoreet aliquam ut nibh magna nibh ipsum. nibh amet diam amet amet nibh nibh nonummy laoreet magna dolore aliquam laoreet magna amet laoreet amet dolor sed lorem dolore euismod tincidunt euismod nonummy adipiscing lorem laoreet aliquam. nonummy ut sit laoreet aliquam sed erat euismod lorem magna erat laoreet sed tincidunt sit dolor erat laoreet laoreet nibh dolor diam sed sed nonummy amet erat nonummy magna. ut aliquam nonummy dolore euismod amet sit tincidunt sit dolore sed amet sit amet consectetuer diam amet sed aliquam nonummy nonummy nibh nibh consectetuer sit laoreet lorem consectetuer ut. </p>", new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "<p>erat dolor laoreet ut. dolor nonummy consectetuer aliquam. </p>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsDate",
                table: "NewsFeeds");

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>magna magna magna elit dolore adipiscing nonummy sed nonummy euismod aliquam elit sed nibh erat consectetuer ut magna dolor consectetuer euismod laoreet ipsum. ipsum sit laoreet dolor nonummy tincidunt ipsum magna tincidunt elit amet sit aliquam ut erat adipiscing consectetuer adipiscing euismod tincidunt diam dolore erat. erat aliquam elit dolor aliquam nonummy dolore tincidunt euismod dolor dolore dolore amet lorem sit lorem ut diam ut consectetuer lorem sit sed. ipsum nibh laoreet nibh dolore erat erat ipsum nibh amet sit laoreet amet dolor nonummy dolor adipiscing dolore tincidunt euismod ipsum dolor aliquam. ut consectetuer dolor adipiscing aliquam amet ut nibh erat laoreet nonummy adipiscing nibh sit erat lorem ut euismod lorem amet nibh ipsum consectetuer. </p>", "<p>erat elit nibh nonummy elit. tincidunt nonummy elit elit sed. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>amet laoreet lorem ipsum magna diam euismod adipiscing consectetuer nibh nonummy euismod amet ipsum ipsum diam elit adipiscing sit aliquam dolor. ipsum elit consectetuer adipiscing aliquam euismod diam erat elit sit sed laoreet consectetuer ut lorem dolor euismod sed dolor sed nibh. lorem tincidunt elit dolor dolor sed ut dolor sed erat consectetuer laoreet magna dolor sed ut ut aliquam dolore sit adipiscing. aliquam sed dolor dolore erat elit lorem adipiscing ut magna lorem nonummy nibh ipsum tincidunt aliquam sit dolore amet ut magna. erat amet dolor lorem elit nibh euismod sed aliquam nonummy adipiscing amet consectetuer ipsum consectetuer consectetuer consectetuer sit ipsum ut laoreet. </p>", "<p>sed lorem lorem euismod. diam laoreet nibh nonummy. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>erat sit erat laoreet tincidunt ut aliquam ipsum dolor ut magna tincidunt ut euismod aliquam diam aliquam lorem dolor lorem diam sed sit nonummy. sed dolor aliquam sed erat euismod dolor laoreet diam ut sed dolore amet sit sed consectetuer ipsum erat sed dolor nibh laoreet amet sit. euismod consectetuer laoreet erat dolore erat magna nibh erat diam adipiscing nibh dolore nonummy dolor nonummy euismod dolor sit lorem amet ipsum amet ut. euismod magna aliquam nonummy erat lorem aliquam euismod aliquam laoreet laoreet tincidunt magna sit aliquam nonummy dolore magna magna laoreet magna magna sed nibh. magna aliquam nonummy diam euismod amet erat nonummy lorem ipsum elit erat lorem elit nibh erat nibh tincidunt tincidunt lorem ut diam euismod sed. </p>", "<p>dolor euismod diam dolore. consectetuer magna laoreet lorem. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>nonummy dolor magna tincidunt lorem diam sit aliquam ipsum amet dolore ipsum ipsum lorem dolor adipiscing elit adipiscing magna erat nibh elit nonummy. sit lorem euismod ut diam magna nibh sit dolor laoreet sed diam sed laoreet adipiscing ipsum erat magna euismod erat euismod magna diam. magna nibh amet diam magna aliquam dolore consectetuer ut dolor euismod tincidunt euismod sed laoreet tincidunt ipsum diam ipsum ut adipiscing euismod nonummy. </p>", "<p>euismod ipsum magna euismod. elit adipiscing sit ipsum. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>tincidunt lorem diam ut consectetuer sit aliquam erat lorem magna ipsum aliquam ipsum laoreet sit erat diam consectetuer euismod dolor sed tincidunt euismod laoreet nibh lorem dolor. ut dolore aliquam erat tincidunt magna elit euismod nibh dolor lorem tincidunt diam nibh lorem dolore dolore adipiscing magna nibh sit dolore sit nibh aliquam laoreet nonummy. amet erat sed ut sit consectetuer ipsum sit sit ipsum magna sed ipsum tincidunt dolor euismod magna sed euismod dolor nonummy sed dolore laoreet sed tincidunt sed. erat aliquam tincidunt elit lorem aliquam adipiscing dolor tincidunt dolor elit magna elit sed elit dolore ut erat aliquam laoreet magna lorem amet consectetuer dolor adipiscing euismod. </p>", "<p>magna aliquam nibh nonummy. nonummy tincidunt ipsum nonummy. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>ipsum lorem lorem euismod sed lorem erat lorem nonummy dolor elit erat euismod dolor magna ut dolor amet elit euismod dolor nibh magna tincidunt sit sed. laoreet erat lorem dolor sed nonummy dolore nonummy amet nonummy aliquam lorem adipiscing aliquam amet dolore lorem euismod diam tincidunt nonummy dolor erat nibh dolor lorem. consectetuer diam sed nonummy sit elit diam lorem consectetuer lorem lorem sed ut dolore dolor ipsum aliquam adipiscing laoreet dolor magna diam elit consectetuer nibh amet. </p>", "<p>dolore magna amet sed tincidunt nonummy. adipiscing consectetuer magna elit diam diam. </p>" });

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>erat sit nibh laoreet diam dolor nonummy tincidunt ipsum magna lorem aliquam nonummy erat dolore ut aliquam magna elit magna magna. magna elit euismod diam adipiscing nibh sed amet sed ipsum lorem nonummy sit laoreet tincidunt tincidunt adipiscing sit erat tincidunt dolore. diam ut amet dolore dolor laoreet euismod ut nibh tincidunt aliquam nonummy amet ipsum laoreet erat consectetuer sit nonummy dolor sed. euismod laoreet lorem elit adipiscing amet dolor ipsum euismod ut sed amet ipsum sed tincidunt sed tincidunt amet dolore laoreet nonummy. </p>", "<p>adipiscing consectetuer nibh elit dolore nibh. ipsum magna lorem erat dolore diam. </p>" });
        }
    }
}
