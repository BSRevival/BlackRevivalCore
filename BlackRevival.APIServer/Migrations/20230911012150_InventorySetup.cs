using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class InventorySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryGoods",
                columns: table => new
                {
                    Num = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserNum = table.Column<long>(type: "bigint", nullable: false),
                    IsActivated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Activated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpireDtm = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryGoods", x => x.Num);
                    table.ForeignKey(
                        name: "FK_InventoryGoods_Users_UserNum",
                        column: x => x.UserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuestProgresses",
                columns: table => new
                {
                    QuestProgressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserNum = table.Column<long>(type: "bigint", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Cleared = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Rewarded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RenewalType = table.Column<int>(type: "int", nullable: false),
                    ExpireDtm = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestProgresses", x => x.QuestProgressId);
                    table.ForeignKey(
                        name: "FK_QuestProgresses_Users_UserNum",
                        column: x => x.UserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryGoods_UserNum",
                table: "InventoryGoods",
                column: "UserNum");

            migrationBuilder.CreateIndex(
                name: "IX_QuestProgresses_UserNum",
                table: "QuestProgresses",
                column: "UserNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryGoods");

            migrationBuilder.DropTable(
                name: "QuestProgresses");
        }
    }
}
