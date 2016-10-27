using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class List
    {
        public int ListID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "List Name")]
        public string ListName { get; set; }
        [Required]
        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<TodoTask> TodoTasks { get; set; }
    }
}