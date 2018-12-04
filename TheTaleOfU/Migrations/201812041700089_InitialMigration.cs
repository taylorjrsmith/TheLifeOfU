namespace TheTaleOfU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        OriginScenarioId = c.Int(nullable: false),
                        NextScenarioId = c.Int(nullable: false),
                        OptionIdentifier = c.Int(nullable: false),
                        Scenario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scenarios", t => t.Scenario_Id)
                .ForeignKey("dbo.Scenarios", t => t.NextScenarioId, cascadeDelete: true)
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
                        hasEvent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "OriginScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.Options", "NextScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.Options", "Scenario_Id", "dbo.Scenarios");
            DropIndex("dbo.Options", new[] { "Scenario_Id" });
            DropIndex("dbo.Options", new[] { "NextScenarioId" });
            DropIndex("dbo.Options", new[] { "OriginScenarioId" });
            DropTable("dbo.Scenarios");
            DropTable("dbo.Options");
            DropTable("dbo.Items");
        }
    }
}
