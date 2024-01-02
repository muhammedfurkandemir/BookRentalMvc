using BookRentalApp.Models;
using BookRentalApp.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookRentalApp.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;
        private IBookTypeRepository _bookTypeRepository;
        private IWebHostEnvironment _webHostEnvironment;//bu sınıf üzerinden wwwroot alanına erişiriz ve sistem bu sınıfı otomatik constructor a gönderir.
        private IFileHelper _fileHelper;

        public BookController(IBookRepository bookRepository,IBookTypeRepository bookTypeRepository,
            IWebHostEnvironment webHostEnvironment, IFileHelper fileHelper)
        {
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            List<BookDetailDto> bookDetails=_bookRepository.GetBookDetails();
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            Console.WriteLine(wwwRootPath+"ben yazdım");
            return View(bookDetails);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> bookTypes = _bookTypeRepository.GetAll().Select(b =>
            new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
            });
            ViewBag.BookTypes = bookTypes;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file!=null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string imagePath = Path.Combine(wwwRootPath, @"img");

                    book.ImageUrl = _fileHelper.Upload(file, imagePath);
                }
                _bookRepository.Add(book);
                _bookRepository.Save();
                TempData["Success"] = "Yeni Kayıt Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "Book");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? book = _bookRepository.Get(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> bookTypes = _bookTypeRepository.GetAll().Select(b =>
            new SelectListItem
            {
                Text = b.Name,
                Value = b.Id.ToString()
            });
            ViewBag.BookTypes = bookTypes;
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book,IFormFile file)
        {
            //var errors=ModelState.Values.Select(x => x.Errors).ToList();
            if (ModelState.IsValid)
            {
                if (file!=null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string imagePath = Path.Combine(wwwRootPath, @"img");

                    book.ImageUrl = _fileHelper.Update(file, wwwRootPath + file.FileName, imagePath);
                }
                _bookRepository.Update(book);
                _bookRepository.Save();
                TempData["Success"] = "Kayıt Başarıyla Güncellendi!";
                return RedirectToAction("Index", "Book");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? book = _bookRepository.Get(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.Delete(book);
            _bookRepository.Save();
            TempData["Success"] = "Kayıt Başarıyla Silindi!";
            return RedirectToAction("Index", "Book");
        }
    }
}
