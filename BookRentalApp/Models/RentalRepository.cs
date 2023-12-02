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
