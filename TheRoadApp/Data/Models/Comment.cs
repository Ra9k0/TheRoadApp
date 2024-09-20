﻿namespace TheRoadApp.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorFullName { get; set; }

        public string Email { get; set; }
    }
}
