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
            return View(bookTypes);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _rentalBookContext.BookTypes.Add(bookType);
                _rentalBookContext.SaveChanges();
                TempData["Success"] ="Yeni Kayıt Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "BookType");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            BookType? bookType=_rentalBookContext.BookTypes.Find(id);
            if (bookType==null)
            {
                return NotFound();
            }
            return View(bookType);
        }

        [HttpPost]
        public IActionResult Update(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _rentalBookContext.BookTypes.Update(bookType);
                _rentalBookContext.SaveChanges();
                TempData["Success"] ="Kayıt Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "BookType");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookType? bookType = _rentalBookContext.BookTypes.Find(id);
            if (bookType == null)
            {
                return NotFound();
            }
            return View(bookType);
        }

        [HttpPost]
        public IActionResult Delete(BookType bookType)
        {
            if (bookType == null)
            {
                return NotFound();
            }
            _rentalBookContext.BookTypes.Remove(bookType);
            _rentalBookContext.SaveChanges();
            TempData["Success"] = "Kayıt Türü Başarıyla Silindi!";
            return RedirectToAction("Index", "BookType");
        }
    }
}
