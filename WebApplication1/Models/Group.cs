using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class Group {
        [Required]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public virtual List<UserStory> UserStories { get; set; }
    }
}