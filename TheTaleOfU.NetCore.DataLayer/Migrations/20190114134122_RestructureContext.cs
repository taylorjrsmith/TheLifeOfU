using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTaleOfU.NetCore.DataLayer.Migrations
{
    public partial class RestructureContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GainItemEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IsEndOfScenarioRoute",
                table: "Scenarios");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Scenarios",
                newName: "ScenarioId");

            migrationBuilder.RenameColumn(
                name: "ScenarioDescription",
                table: "Scenarios",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EndOfEventMethodName",
                table: "Scenarios",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Options",
                newName: "OptionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Effect",
                table: "Items",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Damage",
                table: "Items",
                newName: "Rarity");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Options",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginScenarioId",
                table: "Options",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "Options",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateTable(
                name: "GainItemEvents",
                columns: table => new
                {
                    GainItemEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomText = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainItemEvents", x => x.GainItemEventId);
                    table.ForeignKey(
                        name: "FK_GainItemEvents_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GainItemEvents_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerGuid = table.Column<Guid>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PlayerType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerGuid);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    PlayerGuid = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.PlayerGuid);
                    table.ForeignKey(
                        name: "FK_Inventories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Player_PlayerGuid",
                        column: x => x.PlayerGuid,
                        principalTable: "Player",
                        principalColumn: "PlayerGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_OriginScenarioId",
                table: "Options",
                column: "OriginScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ScenarioId",
                table: "Options",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GainItemEvents_ItemId",
                table: "GainItemEvents",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GainItemEvents_OptionId",
                table: "GainItemEvents",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Scenarios_OriginScenarioId",
                table: "Options",
                column: "OriginScenarioId",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Scenarios_ScenarioId",
                table: "Options",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "ScenarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Scenarios_OriginScenarioId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Scenarios_ScenarioId",
                table: "Options");

            migrationBuilder.DropTable(
                name: "GainItemEvents");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Options_OriginScenarioId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_ScenarioId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "OriginScenarioId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameColumn(
                name: "ScenarioId",
                table: "Scenarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Scenarios",
                newName: "ScenarioDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Scenarios",
                newName: "EndOfEventMethodName");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "Options",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Item",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Rarity",
                table: "Item",
                newName: "Damage");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Item",
                newName: "Effect");

            migrationBuilder.AddColumn<bool>(
                name: "IsEndOfScenarioRoute",
                table: "Scenarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GainItemEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomText = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainItemEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GainItemEvent_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GainItemEvent_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GainItemEvent_ItemId",
                table: "GainItemEvent",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GainItemEvent_OptionId",
                table: "GainItemEvent",
                column: "OptionId");
        }
    }
}
