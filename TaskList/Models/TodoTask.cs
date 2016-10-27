using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class TodoTask
    {
        public int TodoTaskID { get; set; }

        [Required]
        [StringLength(200)]
        public string Task { get; set; }
        public int ListID { get; set; }
        public Boolean completed { get; set; }

        public virtual List Lists { get; set; }
    }
}