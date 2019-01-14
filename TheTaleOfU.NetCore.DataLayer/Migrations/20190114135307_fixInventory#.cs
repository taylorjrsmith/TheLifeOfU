using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTaleOfU.NetCore.DataLayer.Migrations
{
    public partial class fixInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Inventories_PlayerGuid",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "PlayerInventoryId",
                table: "Inventories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "PlayerInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PlayerGuid",
                table: "Inventories",
                column: "PlayerGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_PlayerGuid",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PlayerInventoryId",
                table: "Inventories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "ItemId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Inventories_PlayerGuid",
                table: "Inventories",
                column: "PlayerGuid");
        }
    }
}
