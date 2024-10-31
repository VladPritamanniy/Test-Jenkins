namespace BookStore.Core.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(int id) : base($"Unable to find book by id: {id}.")
        {
        }
    }
}
