namespace BookRentalApp.Models
{
    public interface IBookRepository:IRepository<Book>
    {

        List<BookDetailDto> GetBookDetails();
        void Update(Book book);

        void Save();
    }
}
