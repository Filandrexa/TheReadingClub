using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Services.BookServices;

namespace TheReadingClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookServices bookService;

        public HomeController(IBookServices bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var model = bookService.PopulateIndexBooks();

            return View(model);
        }

    }
}
