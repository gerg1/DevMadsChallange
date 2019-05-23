namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.UserStories",
                c => new
                    {
                        UserStoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaskId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserStoryId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStories", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.UserStories", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Tasks", "ActivityId", "dbo.Activities");
            DropIndex("dbo.UserStories", new[] { "GroupId" });
            DropIndex("dbo.UserStories", new[] { "TaskId" });
            DropIndex("dbo.Tasks", new[] { "ActivityId" });
            DropTable("dbo.Groups");
            DropTable("dbo.UserStories");
            DropTable("dbo.Tasks");
            DropTable("dbo.Activities");
        }
    }
}
