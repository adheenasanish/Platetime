using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateTimeApp.Migrations
{
    public partial class SevenMoreRowsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>magna magna magna elit dolore adipiscing nonummy sed nonummy euismod aliquam elit sed nibh erat consectetuer ut magna dolor consectetuer euismod laoreet ipsum. ipsum sit laoreet dolor nonummy tincidunt ipsum magna tincidunt elit amet sit aliquam ut erat adipiscing consectetuer adipiscing euismod tincidunt diam dolore erat. erat aliquam elit dolor aliquam nonummy dolore tincidunt euismod dolor dolore dolore amet lorem sit lorem ut diam ut consectetuer lorem sit sed. ipsum nibh laoreet nibh dolore erat erat ipsum nibh amet sit laoreet amet dolor nonummy dolor adipiscing dolore tincidunt euismod ipsum dolor aliquam. ut consectetuer dolor adipiscing aliquam amet ut nibh erat laoreet nonummy adipiscing nibh sit erat lorem ut euismod lorem amet nibh ipsum consectetuer. </p>", "<p>erat elit nibh nonummy elit. tincidunt nonummy elit elit sed. </p>" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 5, "<p>amet laoreet lorem ipsum magna diam euismod adipiscing consectetuer nibh nonummy euismod amet ipsum ipsum diam elit adipiscing sit aliquam dolor. ipsum elit consectetuer adipiscing aliquam euismod diam erat elit sit sed laoreet consectetuer ut lorem dolor euismod sed dolor sed nibh. lorem tincidunt elit dolor dolor sed ut dolor sed erat consectetuer laoreet magna dolor sed ut ut aliquam dolore sit adipiscing. aliquam sed dolor dolore erat elit lorem adipiscing ut magna lorem nonummy nibh ipsum tincidunt aliquam sit dolore amet ut magna. erat amet dolor lorem elit nibh euismod sed aliquam nonummy adipiscing amet consectetuer ipsum consectetuer consectetuer consectetuer sit ipsum ut laoreet. </p>", "<p>sed lorem lorem euismod. diam laoreet nibh nonummy. </p>" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 6, "<p>erat sit erat laoreet tincidunt ut aliquam ipsum dolor ut magna tincidunt ut euismod aliquam diam aliquam lorem dolor lorem diam sed sit nonummy. sed dolor aliquam sed erat euismod dolor laoreet diam ut sed dolore amet sit sed consectetuer ipsum erat sed dolor nibh laoreet amet sit. euismod consectetuer laoreet erat dolore erat magna nibh erat diam adipiscing nibh dolore nonummy dolor nonummy euismod dolor sit lorem amet ipsum amet ut. euismod magna aliquam nonummy erat lorem aliquam euismod aliquam laoreet laoreet tincidunt magna sit aliquam nonummy dolore magna magna laoreet magna magna sed nibh. magna aliquam nonummy diam euismod amet erat nonummy lorem ipsum elit erat lorem elit nibh erat nibh tincidunt tincidunt lorem ut diam euismod sed. </p>", "<p>dolor euismod diam dolore. consectetuer magna laoreet lorem. </p>" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 7, "<p>nonummy dolor magna tincidunt lorem diam sit aliquam ipsum amet dolore ipsum ipsum lorem dolor adipiscing elit adipiscing magna erat nibh elit nonummy. sit lorem euismod ut diam magna nibh sit dolor laoreet sed diam sed laoreet adipiscing ipsum erat magna euismod erat euismod magna diam. magna nibh amet diam magna aliquam dolore consectetuer ut dolor euismod tincidunt euismod sed laoreet tincidunt ipsum diam ipsum ut adipiscing euismod nonummy. </p>", "<p>euismod ipsum magna euismod. elit adipiscing sit ipsum. </p>" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 8, "<p>tincidunt lorem diam ut consectetuer sit aliquam erat lorem magna ipsum aliquam ipsum laoreet sit erat diam consectetuer euismod dolor sed tincidunt euismod laoreet nibh lorem dolor. ut dolore aliquam erat tincidunt magna elit euismod nibh dolor lorem tincidunt diam nibh lorem dolore dolore adipiscing magna nibh sit dolore sit nibh aliquam laoreet nonummy. amet erat sed ut sit consectetuer ipsum sit sit ipsum magna sed ipsum tincidunt dolor euismod magna sed euismod dolor nonummy sed dolore laoreet sed tincidunt sed. erat aliquam tincidunt elit lorem aliquam adipiscing dolor tincidunt dolor elit magna elit sed elit dolore ut erat aliquam laoreet magna lorem amet consectetuer dolor adipiscing euismod. </p>", "<p>magna aliquam nibh nonummy. nonummy tincidunt ipsum nonummy. </p>" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 9, "<p>ipsum lorem lorem euismod sed lorem erat lorem nonummy dolor elit erat euismod dolor magna ut dolor amet elit euismod dolor nibh magna tincidunt sit sed. laoreet erat lorem dolor sed nonummy dolore nonummy amet nonummy aliquam lorem adipiscing aliquam amet dolore lorem euismod diam tincidunt nonummy dolor erat nibh dolor lorem. consectetuer diam sed nonummy sit elit diam lorem consectetuer lorem lorem sed ut dolore dolor ipsum aliquam adipiscing laoreet dolor magna diam elit consectetuer nibh amet. </p>", "<p>dolore magna amet sed tincidunt nonummy. adipiscing consectetuer magna elit diam diam. </p>" });

            migrationBuilder.InsertData(
                table: "NewsFeeds",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 10, "<p>erat sit nibh laoreet diam dolor nonummy tincidunt ipsum magna lorem aliquam nonummy erat dolore ut aliquam magna elit magna magna. magna elit euismod diam adipiscing nibh sed amet sed ipsum lorem nonummy sit laoreet tincidunt tincidunt adipiscing sit erat tincidunt dolore. diam ut amet dolore dolor laoreet euismod ut nibh tincidunt aliquam nonummy amet ipsum laoreet erat consectetuer sit nonummy dolor sed. euismod laoreet lorem elit adipiscing amet dolor ipsum euismod ut sed amet ipsum sed tincidunt sed tincidunt amet dolore laoreet nonummy. </p>", "<p>adipiscing consectetuer nibh elit dolore nibh. ipsum magna lorem erat dolore diam. </p>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "NewsFeeds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "<p>aliquam sed adipiscing euismod nonummy erat ut dolore magna erat nibh amet lorem lorem adipiscing tincidunt nonummy sed magna diam ipsum consectetuer tincidunt sed erat amet sed sed nonummy magna lorem diam elit nonummy laoreet erat consectetuer dolore aliquam nibh erat aliquam lorem nibh magna nibh elit dolor diam dolor nonummy diam sit. euismod ipsum tincidunt ut aliquam euismod consectetuer nibh adipiscing adipiscing lorem aliquam ipsum magna nonummy amet adipiscing sed tincidunt diam adipiscing diam sit consectetuer dolor nonummy sed magna adipiscing aliquam sed adipiscing nibh adipiscing ut sed dolor consectetuer elit amet euismod lorem tincidunt nibh erat euismod dolore ut magna magna dolor tincidunt dolore. erat magna sit magna elit euismod elit sit sed consectetuer elit aliquam tincidunt elit laoreet dolor ipsum dolor ipsum lorem diam magna consectetuer dolore nibh consectetuer diam ut tincidunt erat sed dolore ut nonummy nibh diam nibh nonummy ut euismod erat lorem amet laoreet adipiscing tincidunt adipiscing consectetuer ipsum euismod dolore ut lorem. euismod elit dolor nibh elit adipiscing dolor dolor tincidunt nonummy sed dolore nonummy sit sit laoreet adipiscing nonummy nonummy sed sed ipsum diam tincidunt nonummy diam magna erat amet tincidunt ipsum sit ut laoreet ipsum sit diam magna amet amet euismod nonummy adipiscing nonummy laoreet aliquam laoreet nonummy dolor diam ut ipsum consectetuer. adipiscing euismod nibh magna diam lorem magna sed dolor magna lorem sed consectetuer dolor laoreet dolor lorem consectetuer sed adipiscing consectetuer dolore aliquam laoreet erat aliquam nibh ut elit dolore ut aliquam erat magna elit sit diam consectetuer lorem magna adipiscing dolore diam euismod adipiscing ipsum diam dolore lorem elit dolor sit adipiscing. laoreet lorem diam ut dolore aliquam nibh sed sit lorem consectetuer dolor ipsum diam elit ut nibh euismod laoreet consectetuer nonummy erat diam adipiscing consectetuer sed magna sed laoreet ut erat ut nibh nibh sit magna aliquam diam tincidunt adipiscing diam sed sit laoreet sit nonummy amet nibh ipsum ipsum sed laoreet elit. aliquam dolore dolore nonummy sit sed elit lorem dolor euismod sed lorem nibh nibh nonummy consectetuer nonummy dolore dolor erat diam dolore ipsum laoreet tincidunt dolor ut amet adipiscing adipiscing tincidunt consectetuer amet elit tincidunt laoreet elit adipiscing laoreet lorem consectetuer consectetuer adipiscing laoreet ut laoreet euismod aliquam tincidunt adipiscing nibh consectetuer consectetuer. </p>", "<p>magna diam sit dolor euismod ipsum aliquam ipsum sed. sed aliquam nonummy laoreet aliquam nonummy nonummy dolor consectetuer. </p>" });
        }
    }
}
