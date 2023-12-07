using BookRentalApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookRentalApp.Utility
{
    public class RentalBookContext : IdentityDbContext
    {
        public RentalBookContext(DbContextOptions<RentalBookContext> dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
