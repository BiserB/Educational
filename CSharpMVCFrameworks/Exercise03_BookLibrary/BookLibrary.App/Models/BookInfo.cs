﻿namespace BookLibrary.App.Models
{
    public class BookInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public string Status { get; set; }
    }
}