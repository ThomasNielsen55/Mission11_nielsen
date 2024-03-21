namespace Mission11_nielsen.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
        
    }
}
