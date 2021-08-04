using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Services.GenreServices;

namespace TheReadingClub.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreServices genreServices;

        public GenreController(IGenreServices genreServices)
        {
            this.genreServices = genreServices;
        }

        public IActionResult All()
        {
            var model = genreServices.ViewAllGenres();

            return View(model);
        }

        public IActionResult ById(int id)
        {
            var model = genreServices.GenreByIdView(id);

            return View(model);
        }
    }
}
