namespace TheTaleOfU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalDeploy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Damage = c.Int(nullable: false),
                        Effect = c.String(),
                        Durability = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        OriginScenarioId = c.Int(nullable: false),
                        NextScenarioId = c.Int(),
                        OptionIdentifier = c.Int(nullable: false),
                        Scenario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scenarios", t => t.Scenario_Id)
                .ForeignKey("dbo.Scenarios", t => t.NextScenarioId)
                .ForeignKey("dbo.Scenarios", t => t.OriginScenarioId, cascadeDelete: true)
                .Index(t => t.OriginScenarioId)
                .Index(t => t.NextScenarioId)
                .Index(t => t.Scenario_Id);
            
            CreateTable(
                "dbo.Scenarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScenarioDescription = c.String(),
                        AllowedPlayerTypes = c.Int(nullable: false),
                        IsEndOfScenarioRoute = c.Boolean(nullable: false),
                        EndOfEventMethodName = c.String(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScenarioEvents", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.ScenarioEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        OriginScenarioId = c.Int(nullable: false),
                        LinkedItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.LinkedItem_Id)
                .Index(t => t.LinkedItem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "OriginScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.Options", "NextScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.Options", "Scenario_Id", "dbo.Scenarios");
            DropForeignKey("dbo.Scenarios", "Event_Id", "dbo.ScenarioEvents");
            DropForeignKey("dbo.ScenarioEvents", "LinkedItem_Id", "dbo.Items");
            DropIndex("dbo.ScenarioEvents", new[] { "LinkedItem_Id" });
            DropIndex("dbo.Scenarios", new[] { "Event_Id" });
            DropIndex("dbo.Options", new[] { "Scenario_Id" });
            DropIndex("dbo.Options", new[] { "NextScenarioId" });
            DropIndex("dbo.Options", new[] { "OriginScenarioId" });
            DropTable("dbo.ScenarioEvents");
            DropTable("dbo.Scenarios");
            DropTable("dbo.Options");
            DropTable("dbo.Items");
        }
    }
}
