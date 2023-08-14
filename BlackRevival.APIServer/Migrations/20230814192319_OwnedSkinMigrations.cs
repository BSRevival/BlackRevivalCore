using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class OwnedSkinMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnedSkins",
                columns: table => new
                {
                    OwnedSkinId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserNum = table.Column<long>(type: "bigint", nullable: false),
                    CharacterClass = table.Column<int>(type: "int", nullable: false),
                    CharacterSkinType = table.Column<int>(type: "int", nullable: false),
                    Owned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ActiveLive2D = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SkinEnableType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedSkins", x => x.OwnedSkinId);
                    table.ForeignKey(
                        name: "FK_OwnedSkins_Users_UserNum",
                        column: x => x.UserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedSkins_UserNum",
                table: "OwnedSkins",
                column: "UserNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedSkins");
        }
    }
}
