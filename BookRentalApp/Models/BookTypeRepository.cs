using BookRentalApp.Utility;

namespace BookRentalApp.Models
{
    public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
    {
        private RentalBookContext _rentalBookContext;
        public BookTypeRepository(RentalBookContext rentalBookContext) : base(rentalBookContext)
        {
            _rentalBookContext=rentalBookContext;
        }

        public void Save()
        {
           _rentalBookContext.SaveChanges();
        }

        public void Update(BookType bookType)
        {
           _rentalBookContext.Update(bookType);
        }
    }
}
