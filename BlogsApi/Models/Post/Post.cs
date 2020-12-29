using System;

namespace BlogsApi.Models
{
    public class Post
    {
        public int Id {get;set;}

        public DateTime CreateDate {get;set;}

        public string PostContent {get;set;}

        public virtual User User { get; set; }

        public virtual PostType PostType { get; set; }
    }
}