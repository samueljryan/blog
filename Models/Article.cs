using System;

namespace blog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;

        public string Post { get; set; } = "";

        public Article()
        {

        }

    }
}
