using BookRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRentalApp.Utility
{
    public class RentalBookContext : DbContext
    {
        public RentalBookContext(DbContextOptions<RentalBookContext> dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}
