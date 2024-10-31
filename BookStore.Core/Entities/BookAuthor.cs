namespace BookStore.Core.Entities
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public byte DisplayOrder { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}