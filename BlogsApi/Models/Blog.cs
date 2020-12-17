using System;

namespace BlogsApi.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string ThemaBlogs { get; set; }

        public string TextBlogs { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
