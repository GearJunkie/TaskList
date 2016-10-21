using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskList
{
    public class List
    {
        public int ListID { get; set; }
        public string ListName { get; set; }

        public virtual ICollection<TodoTask> TodoTasks { get; set; }
    }
}