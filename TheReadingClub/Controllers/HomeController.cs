using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Services.ViewModelServices;

namespace TheReadingClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookViewModel bookServices;

        public HomeController(IBookViewModel bookServices)
        {
            this.bookServices = bookServices;
        }

        public IActionResult Index()
        {
            var books = bookServices.homePageBooks();
            return View(books);
        }

    }
}
