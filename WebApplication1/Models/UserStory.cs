using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class UserStory {
        [Required]
        public int UserStoryId { get; set; }
        public string Name { get; set; }
        public int TaskId { get; set; }
        //public virtual Task Task { get; set; }
        public int GroupId { get; set; }

    }
}