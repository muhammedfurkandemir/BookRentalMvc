using BookRentalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookRentalApp.Controllers
{
    public class RentalController : Controller
    {
        private IRentalRepository _rentalRepository;
        private IBookRepository _bookRepository;

        public RentalController(IRentalRepository rentalRepository,IBookRepository bookRepository)
        {
            _rentalRepository = rentalRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            List<RentalDetailDto> rentalDetails=_rentalRepository.GetRentalDetails();
            
            return View(rentalDetails);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> books = _bookRepository.GetAll().Select(b =>
            new SelectListItem
            {
                Text = b.BookName,
                Value = b.Id.ToString()
            });
            ViewBag.Books = books;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _rentalRepository.Add(rental);
                _rentalRepository.Save();
                TempData["Success"] = "Yeni Kayıt Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "Rental");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            IEnumerable<SelectListItem> books = _bookRepository.GetAll().Select(b =>
           new SelectListItem
           {
               Text = b.BookName,
               Value = b.Id.ToString()
           });
            ViewBag.Books = books;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Rental? rental = _rentalRepository.Get(b => b.Id == id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        [HttpPost]
        public IActionResult Update(Rental rental)
        {
            //var errors=ModelState.Values.Select(x => x.Errors).ToList();
            if (ModelState.IsValid)
            {
               
                _rentalRepository.Update(rental);
                _rentalRepository.Save();
                TempData["Success"] = "Kayıt Başarıyla Güncellendi!";
                return RedirectToAction("Index", "Rental");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> books = _bookRepository.GetAll().Select(b =>
            new SelectListItem
            {
                Text = b.BookName,
                Value = b.Id.ToString()
            });
            ViewBag.Books = books;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Rental? rental = _rentalRepository.Get(b => b.Id == id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        [HttpPost]
        public IActionResult Delete(Rental rental)
        {
            if (rental == null)
            {
                return NotFound();
            }
            _rentalRepository.Delete(rental);
            _rentalRepository.Save();
            TempData["Success"] = "Kayıt Başarıyla Silindi!";
            return RedirectToAction("Index", "Rental");
        }
    }
}
