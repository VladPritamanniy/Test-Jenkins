namespace BookStore.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool SoftDeleted { get; set; }

        public List<BookAuthor> AuthorsLink { get; set; } = new List<BookAuthor>();
    }
}