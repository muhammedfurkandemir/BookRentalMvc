using BookRentalApp.Utility;

namespace BookRentalApp.Models
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private RentalBookContext _rentalBookContext;
        public BookRepository(RentalBookContext rentalBookContext) : base(rentalBookContext)
        {
            _rentalBookContext = rentalBookContext;
        }

        public List<BookDetailDto> GetBookDetails()
        {
            var result = from book in _rentalBookContext.Books
                         join bookType in _rentalBookContext.BookTypes
                         on book.BookTypeId equals bookType.Id
                         select new BookDetailDto
                         {
                             Id = book.Id,
                             BookName = book.BookName,
                             BookTypeName = bookType.Name,
                             Writer = book.Writer,
                             Contributor = book.Contributor,
                             Description = book.Description,
                             Price = book.Price,
                             ImageUrl = book.ImageUrl
                         };
            return result.ToList();
        }

        public void Save()
        {
            _rentalBookContext.SaveChanges();
        }

        public void Update(Book book)
        {
            _rentalBookContext.Update(book);
        }
    }
}
