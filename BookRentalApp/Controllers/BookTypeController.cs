using BookRentalApp.Models;
using BookRentalApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalApp.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly RentalBookContext _rentalBookContext;

        public BookTypeController(RentalBookContext context)
        {
            _rentalBookContext = context;
        }
        public IActionResult Index()
        {
            List<BookType> bookTypes= _rentalBookContext.BookTypes.ToList();
            return View();
        }
    }
}
