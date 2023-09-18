using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImpropernaminginInventoryGoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "InventoryGoods",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "InventoryGoods",
                newName: "Type");
        }
    }
}
