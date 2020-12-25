using System;
using System.Collections.Generic;

namespace BlogsApi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
