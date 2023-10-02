using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveListFromDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryGoods_LabGoodsEntries_InventoryGoods",
                table: "InventoryGoods");

            migrationBuilder.DropIndex(
                name: "IX_InventoryGoods_InventoryGoods",
                table: "InventoryGoods");

            migrationBuilder.DropColumn(
                name: "InventoryGoods",
                table: "InventoryGoods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InventoryGoods",
                table: "InventoryGoods",
                type: "bigint",
                nullable: true);

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
    }
}
