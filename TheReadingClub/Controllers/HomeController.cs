using Microsoft.AspNetCore.Mvc;

namespace TheReadingClub.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            
            return View();
        }

    }
}
