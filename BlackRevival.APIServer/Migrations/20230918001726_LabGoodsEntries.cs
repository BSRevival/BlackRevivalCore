using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class LabGoodsEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDtm",
                table: "InventoryGoods",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "InventoryGoods",
                table: "InventoryGoods",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LabGoodsEntries",
                columns: table => new
                {
                    labNum = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userNum = table.Column<long>(type: "bigint", nullable: false),
                    labType = table.Column<int>(type: "int", nullable: false),
                    bgSubType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isActivated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    components = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabGoodsEntries", x => x.labNum);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryGoods_InventoryGoods",
                table: "InventoryGoods",
                column: "InventoryGoods");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryGoods_LabGoodsEntries_InventoryGoods",
                table: "InventoryGoods",
                column: "InventoryGoods",
                principalTable: "LabGoodsEntries",
                principalColumn: "labNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryGoods_LabGoodsEntries_InventoryGoods",
                table: "InventoryGoods");

            migrationBuilder.DropTable(
                name: "LabGoodsEntries");

            migrationBuilder.DropIndex(
                name: "IX_InventoryGoods_InventoryGoods",
                table: "InventoryGoods");

            migrationBuilder.DropColumn(
                name: "InventoryGoods",
                table: "InventoryGoods");

            migrationBuilder.AlterColumn<long>(
                name: "ExpireDtm",
                table: "InventoryGoods",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
