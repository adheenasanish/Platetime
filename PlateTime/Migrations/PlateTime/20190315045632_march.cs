using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlateTimeApp.Migrations.PlateTime
{
    public partial class march : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "food_category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(unicode: false, maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restaurant",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<string>(maxLength: 450, nullable: true),
                    name = table.Column<string>(unicode: false, maxLength: 450, nullable: true),
                    price_category = table.Column<int>(nullable: true),
                    url = table.Column<string>(unicode: false, maxLength: 450, nullable: true),
                    street_address = table.Column<string>(unicode: false, maxLength: 450, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 450, nullable: true),
                    postal_code = table.Column<string>(unicode: false, maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant", x => x.id);
                    table.ForeignKey(
                        name: "FK__restauran__user___6D0D32F4",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_goer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<string>(maxLength: 450, nullable: true),
                    name = table.Column<string>(unicode: false, maxLength: 450, nullable: true),
                    price_category = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_goer", x => x.id);
                    table.ForeignKey(
                        name: "FK__restauran__user___6FE99F9F",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_food_category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    restaurant_id = table.Column<int>(nullable: true),
                    food_category_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_food_category", x => x.id);
                    table.ForeignKey(
                        name: "FK__restauran__food___7D439ABD",
                        column: x => x.food_category_id,
                        principalTable: "food_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__restauran__resta__7C4F7684",
                        column: x => x.restaurant_id,
                        principalTable: "restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "plate_time",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    restaurant_goer_id = table.Column<int>(nullable: true),
                    restaurant_id = table.Column<int>(nullable: true),
                    time = table.Column<DateTime>(type: "datetime", nullable: false),
                    max_members = table.Column<int>(nullable: false),
                    isopen = table.Column<bool>(nullable: true),
                    all_committed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plate_time", x => x.id);
                    table.ForeignKey(
                        name: "FK__plate_tim__resta__72C60C4A",
                        column: x => x.restaurant_goer_id,
                        principalTable: "restaurant_goer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__plate_tim__resta__73BA3083",
                        column: x => x.restaurant_id,
                        principalTable: "restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_goer_food_category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    restaurant_goer_id = table.Column<int>(nullable: true),
                    food_category_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_goer_food_category", x => x.id);
                    table.ForeignKey(
                        name: "FK__restauran__food___797309D9",
                        column: x => x.food_category_id,
                        principalTable: "food_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__restauran__resta__787EE5A0",
                        column: x => x.restaurant_goer_id,
                        principalTable: "restaurant_goer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_goer_restaurant",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    restaurant_goer_id = table.Column<int>(nullable: true),
                    restaurant_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_goer_restaurant", x => x.id);
                    table.ForeignKey(
                        name: "FK__restauran__resta__00200768",
                        column: x => x.restaurant_goer_id,
                        principalTable: "restaurant_goer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__restauran__resta__01142BA1",
                        column: x => x.restaurant_id,
                        principalTable: "restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "plate_time_restaurant_goer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    plate_time_id = table.Column<int>(nullable: true),
                    restaurant_goer_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plate_time_restaurant_goer", x => x.id);
                    table.ForeignKey(
                        name: "FK__plate_tim__plate__03F0984C",
                        column: x => x.plate_time_id,
                        principalTable: "plate_time",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__plate_tim__resta__04E4BC85",
                        column: x => x.restaurant_goer_id,
                        principalTable: "restaurant_goer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_plate_time_restaurant_goer_id",
                table: "plate_time",
                column: "restaurant_goer_id");

            migrationBuilder.CreateIndex(
                name: "IX_plate_time_restaurant_id",
                table: "plate_time",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_plate_time_restaurant_goer_plate_time_id",
                table: "plate_time_restaurant_goer",
                column: "plate_time_id");

            migrationBuilder.CreateIndex(
                name: "IX_plate_time_restaurant_goer_restaurant_goer_id",
                table: "plate_time_restaurant_goer",
                column: "restaurant_goer_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_user_id",
                table: "restaurant",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_food_category_food_category_id",
                table: "restaurant_food_category",
                column: "food_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_food_category_restaurant_id",
                table: "restaurant_food_category",
                column: "restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_goer_user_id",
                table: "restaurant_goer",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_goer_food_category_food_category_id",
                table: "restaurant_goer_food_category",
                column: "food_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_goer_food_category_restaurant_goer_id",
                table: "restaurant_goer_food_category",
                column: "restaurant_goer_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_goer_restaurant_restaurant_goer_id",
                table: "restaurant_goer_restaurant",
                column: "restaurant_goer_id");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_goer_restaurant_restaurant_id",
                table: "restaurant_goer_restaurant",
                column: "restaurant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "plate_time_restaurant_goer");

            migrationBuilder.DropTable(
                name: "restaurant_food_category");

            migrationBuilder.DropTable(
                name: "restaurant_goer_food_category");

            migrationBuilder.DropTable(
                name: "restaurant_goer_restaurant");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "plate_time");

            migrationBuilder.DropTable(
                name: "food_category");

            migrationBuilder.DropTable(
                name: "restaurant_goer");

            migrationBuilder.DropTable(
                name: "restaurant");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
