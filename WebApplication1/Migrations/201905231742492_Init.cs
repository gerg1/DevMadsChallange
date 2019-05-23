namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserStories", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Task_TaskId", "dbo.Tasks");
            DropIndex("dbo.Groups", new[] { "Task_TaskId" });
            DropIndex("dbo.UserStories", new[] { "GroupId" });
            DropColumn("dbo.Groups", "Task_TaskId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Task_TaskId", c => c.Int());
            CreateIndex("dbo.UserStories", "GroupId");
            CreateIndex("dbo.Groups", "Task_TaskId");
            AddForeignKey("dbo.Groups", "Task_TaskId", "dbo.Tasks", "TaskId");
            AddForeignKey("dbo.UserStories", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
    }
}
