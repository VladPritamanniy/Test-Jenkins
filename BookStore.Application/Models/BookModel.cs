namespace BookStore.Application.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public List<string> AuthorsName { get; set; } = new List<string>();
    }
}