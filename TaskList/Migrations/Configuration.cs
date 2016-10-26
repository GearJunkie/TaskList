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
                new List { ListName = "Groceries" },
                new List { ListName = "Errands" },
                new List {ListName = "List1" },
                new List {ListName = "List2" },
                new List {ListName = "List3" },
                new List {ListName = "List4" },
                new List {ListName = "List5" },
                new List {ListName = "List6" },
                new List {ListName = "List7" }
            };
            lists.ForEach(s => context.Lists.AddOrUpdate(p => p.ListName, s));
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
                new TodoTask { Task = "Task1", ListID = lists.Single(s => s.ListName == "List1").ListID},
                new TodoTask { Task = "Task2", ListID = lists.Single(s => s.ListName == "List1").ListID},
                new TodoTask { Task = "Task3", ListID = lists.Single(s => s.ListName == "List1").ListID},
                new TodoTask { Task = "Task4", ListID = lists.Single(s => s.ListName == "List1").ListID},
                new TodoTask { Task = "Task5", ListID = lists.Single(s => s.ListName == "List1").ListID},
                new TodoTask { Task = "Task1", ListID = lists.Single(s => s.ListName == "List2").ListID},
                new TodoTask { Task = "Task2", ListID = lists.Single(s => s.ListName == "List2").ListID},
                new TodoTask { Task = "Task3", ListID = lists.Single(s => s.ListName == "List2").ListID},
                new TodoTask { Task = "Task4", ListID = lists.Single(s => s.ListName == "List2").ListID},
                new TodoTask { Task = "Task5", ListID = lists.Single(s => s.ListName == "List2").ListID},
                new TodoTask { Task = "Task1", ListID = lists.Single(s => s.ListName == "List3").ListID},
                new TodoTask { Task = "Task2", ListID = lists.Single(s => s.ListName == "List3").ListID},
                new TodoTask { Task = "Task3", ListID = lists.Single(s => s.ListName == "List3").ListID},
                new TodoTask { Task = "Task4", ListID = lists.Single(s => s.ListName == "List3").ListID},
                new TodoTask { Task = "Task5", ListID = lists.Single(s => s.ListName == "List3").ListID}
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
