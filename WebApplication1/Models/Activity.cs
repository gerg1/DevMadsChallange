using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class Activity {
        [Required]
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public virtual List<Task> Tasks { get; set; }

    }
}