using System;

namespace BlogsApi.Models
{
    public class Post
    {
        public int Id {get;set;}

        public DateTime CreateDate {get;set;}

        public string PostContent {get;set;}

        public PostType PostType { get; set; }
        
        public Blog Blog {get;set;}
    }
}