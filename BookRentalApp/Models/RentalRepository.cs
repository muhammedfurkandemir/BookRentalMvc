using BookRentalApp.Utility;
using System.Linq.Expressions;

namespace BookRentalApp.Models
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private RentalBookContext _rentalBookContext;
        public RentalRepository(RentalBookContext rentalBookContext) : base(rentalBookContext)
        {
            _rentalBookContext = rentalBookContext;
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            var result = from rental in _rentalBookContext.Rentals
                         join book in _rentalBookContext.Books
                         on rental.BookId equals book.Id
                         select new RentalDetailDto
                         {
                             Id = rental.Id,
                             BookName = book.BookName,
                             StudentId = rental.StudentId,
                         };
            return result.ToList();
        }

        public void Save()
        {
            _rentalBookContext.SaveChanges();
        }

        public void Update(Rental rental)
        {
            _rentalBookContext.Update(rental);
        }
    }
}
