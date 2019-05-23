using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class Task {
        [Required]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        //public virtual Activity Activity { get; set; }
        public virtual List<UserStory> UserStories { get; set; }
    }
}