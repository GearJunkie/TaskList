namespace TaskList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TaskList.Models;
    //using global::Models.TaskList;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskList.DAL.TodoTaskDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskList.DAL.TodoTaskDbContext context)
        {
            var lists = new List<List> {
                new List { ListName = "Groceries", DateCreated = DateTime.Parse("2016-10-01") },
                new List { ListName = "Errands", DateCreated = DateTime.Parse("2016-10-01") },
                new List {ListName = "List1", DateCreated = DateTime.Parse("2016-10-01") },
                new List {ListName = "List2", DateCreated = DateTime.Parse("2016-09-05") },
                new List {ListName = "List3", DateCreated = DateTime.Parse("2016-09-05") },
                new List {ListName = "List4", DateCreated = DateTime.Parse("2016-09-05") },
                new List {ListName = "List5", DateCreated = DateTime.Parse("2016-11-20") },
                new List {ListName = "List6", DateCreated = DateTime.Parse("2016-11-20") },
                new List {ListName = "List7", DateCreated = DateTime.Parse("2016-11-20") }
            };
            lists.ForEach(s => context.Lists.AddOrUpdate(p => p.ListName,  s));
            context.SaveChanges();

            var TodoTasks = new List<TodoTask>
            {
                new TodoTask { Task = "Apple", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Banana", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Broccoli", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Cheese", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Mountain Dew", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Hot Sauce", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "White Rice", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Noodles", ListID = lists.Single(s => s.ListName == "Groceries").ListID},
                new TodoTask { Task = "Task4-1", ListID = lists.Single(s => s.ListName == "List4").ListID},
                new TodoTask { Task = "Task4-2", ListID = lists.Single(s => s.ListName == "List4").ListID},
                new TodoTask { Task = "Task4-3", ListID = lists.Single(s => s.ListName == "List4").ListID},
                new TodoTask { Task = "Task4-4", ListID = lists.Single(s => s.ListName == "List4").ListID},
                new TodoTask { Task = "Task4-5", ListID = lists.Single(s => s.ListName == "List4").ListID},
                new TodoTask { Task = "Task5-1", ListID = lists.Single(s => s.ListName == "List5").ListID},
                new TodoTask { Task = "Task5-2", ListID = lists.Single(s => s.ListName == "List5").ListID},
                new TodoTask { Task = "Task5-3", ListID = lists.Single(s => s.ListName == "List5").ListID},
                new TodoTask { Task = "Task5-4", ListID = lists.Single(s => s.ListName == "List5").ListID},
                new TodoTask { Task = "Task5-5", ListID = lists.Single(s => s.ListName == "List5").ListID},
                new TodoTask { Task = "Task6-1", ListID = lists.Single(s => s.ListName == "List6").ListID},
                new TodoTask { Task = "Task6-2", ListID = lists.Single(s => s.ListName == "List6").ListID},
                new TodoTask { Task = "Task6-3", ListID = lists.Single(s => s.ListName == "List6").ListID},
                new TodoTask { Task = "Task6-4", ListID = lists.Single(s => s.ListName == "List6").ListID},
                new TodoTask { Task = "Task6-5", ListID = lists.Single(s => s.ListName == "List6").ListID}
            };
            TodoTasks.ForEach(s => context.TodoTasks.AddOrUpdate(p => p.Task, s));
            context.SaveChanges();



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
        }
    }
}
