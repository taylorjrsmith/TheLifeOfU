using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTaleOfU.NetCore.DataLayer.Migrations
{
    public partial class RestructureContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Scenarios_ScenarioId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_ScenarioId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "Options");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "ItemId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Inventories_PlayerGuid",
                table: "Inventories",
                column: "PlayerGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Inventories_PlayerGuid",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "Options",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "PlayerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ScenarioId",
                table: "Options",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Scenarios_ScenarioId",
                table: "Options",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
