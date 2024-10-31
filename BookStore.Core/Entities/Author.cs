namespace BookStore.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookAuthor>? BooksLink { get; set; }
    }
}