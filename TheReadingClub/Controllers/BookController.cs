using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Controllers
{
    public class BookController : Controller
    {

        public BookController()
        {
            
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookFormModel book)
        {
            return null;
        }
    }
}
