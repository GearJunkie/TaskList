using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskList.Models;

namespace TaskList.DAL
{
    public class TodoTaskDbContext : DbContext
    {

        public DbSet<List> Lists { get; set; }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}