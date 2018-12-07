namespace TheTaleOfU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "NextScenarioId", "dbo.Scenarios");
            AddColumn("dbo.Items", "Durability", c => c.Int(nullable: false));
            AddColumn("dbo.Options", "OriginScenarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Options", "Scenario_Id", c => c.Int());
            AddColumn("dbo.Scenarios", "LinkedItem_Id", c => c.Int());
            CreateIndex("dbo.Options", "OriginScenarioId");
            CreateIndex("dbo.Options", "Scenario_Id");
            CreateIndex("dbo.Scenarios", "LinkedItem_Id");
            AddForeignKey("dbo.Scenarios", "LinkedItem_Id", "dbo.Items", "Id");
            AddForeignKey("dbo.Options", "OriginScenarioId", "dbo.Scenarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Options", "Scenario_Id", "dbo.Scenarios", "Id");
            DropColumn("dbo.Scenarios", "hasEvent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scenarios", "hasEvent", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Options", "Scenario_Id", "dbo.Scenarios");
            DropForeignKey("dbo.Options", "OriginScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.Scenarios", "LinkedItem_Id", "dbo.Items");
            DropIndex("dbo.Scenarios", new[] { "LinkedItem_Id" });
            DropIndex("dbo.Options", new[] { "Scenario_Id" });
            DropIndex("dbo.Options", new[] { "OriginScenarioId" });
            DropColumn("dbo.Scenarios", "LinkedItem_Id");
            DropColumn("dbo.Options", "Scenario_Id");
            DropColumn("dbo.Options", "OriginScenarioId");
            DropColumn("dbo.Items", "Durability");
            AddForeignKey("dbo.Options", "NextScenarioId", "dbo.Scenarios", "Id");
        }
    }
}
