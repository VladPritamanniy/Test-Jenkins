﻿namespace BookStore.Application.Models
{
    public class BookCreateModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> AuthorsName { get; set; }
    }
}