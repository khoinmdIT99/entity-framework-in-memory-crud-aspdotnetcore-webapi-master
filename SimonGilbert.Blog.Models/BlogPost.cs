using System;

namespace SimonGilbert.Blog.Models
{
    public class BlogPost
    {
        public string Id { get; set; }

        public string UserAccountId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdatedDateTimeUtc { get; set; }
    }
}
