using BookRentalApp.Models;
using BookRentalApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalApp.Controllers
{
    public class BookTypeController : Controller
    {
        private IBookTypeRepository _bookTypeRepository;

        public BookTypeController(IBookTypeRepository bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
        }
        public IActionResult Index()
        {
            List<BookType> bookTypes= _bookTypeRepository.GetAll().ToList();
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
                _bookTypeRepository.Add(bookType);
                _bookTypeRepository.Save();
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
            BookType? bookType = _bookTypeRepository.Get(b => b.Id == id);
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
                _bookTypeRepository.Update(bookType);
                _bookTypeRepository.Save();
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
            BookType? bookType = _bookTypeRepository.Get(b => b.Id == id);
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
            _bookTypeRepository.Delete(bookType);
            _bookTypeRepository.Save();
            TempData["Success"] = "Kayıt Türü Başarıyla Silindi!";
            return RedirectToAction("Index", "BookType");
        }
    }
}
