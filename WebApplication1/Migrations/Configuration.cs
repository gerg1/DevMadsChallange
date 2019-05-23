namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.WebApplication1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.WebApplication1Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Activities.AddOrUpdate(
                x => x.ActivityId,
                new Activity() { ActivityId = 1, Name = "Activity1" },
                new Activity() { ActivityId = 2, Name = "Activity2" });

            context.Tasks.AddOrUpdate(
                x => x.TaskId,
                new Task() { TaskId = 1, Name = "Task1", ActivityId = context.Activities.Find(1).ActivityId },
                new Task() { TaskId = 2, Name = "Task2", ActivityId = context.Activities.Find(1).ActivityId },
                new Task() { TaskId = 3, Name = "Task3", ActivityId = context.Activities.Find(2).ActivityId },
                new Task() { TaskId = 4, Name = "Task4", ActivityId = context.Activities.Find(2).ActivityId });


            context.Groups.AddOrUpdate(
                x => x.GroupId,
                new Group() { GroupId = 1, Name = "Release1" },
                new Group() { GroupId = 2, Name = "Release2" },
                new Group() { GroupId = 3, Name = "Release3" });

            context.UserStories.AddOrUpdate(
                x => x.UserStoryId,
                new UserStory() { UserStoryId = 1, Name = "UserStory1", TaskId = context.Tasks.Find(1).TaskId, GroupId = context.Groups.Find(1).GroupId },
                new UserStory() { UserStoryId = 2, Name = "UserStory2", TaskId = context.Tasks.Find(1).TaskId, GroupId = context.Groups.Find(1).GroupId },
                new UserStory() { UserStoryId = 3, Name = "UserStory3", TaskId = context.Tasks.Find(2).TaskId, GroupId = context.Groups.Find(2).GroupId },
                new UserStory() { UserStoryId = 4, Name = "UserStory4", TaskId = context.Tasks.Find(3).TaskId, GroupId = context.Groups.Find(2).GroupId },
                new UserStory() { UserStoryId = 5, Name = "UserStory5", TaskId = context.Tasks.Find(3).TaskId, GroupId = context.Groups.Find(3).GroupId },
                new UserStory() { UserStoryId = 6, Name = "UserStory6", TaskId = context.Tasks.Find(4).TaskId, GroupId = context.Groups.Find(3).GroupId });

        }
    }
}
