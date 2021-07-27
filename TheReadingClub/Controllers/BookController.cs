using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Add()
        {
            return View(new AddBookFormModel());
        }

        [HttpPost]
        public IActionResult Add(AddBookFormModel book)
        {
            return null;
        }
    }
}
