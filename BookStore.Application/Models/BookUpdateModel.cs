namespace BookStore.Application.Models
{
    public class BookUpdateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> AuthorsName { get; set; }
    }
}