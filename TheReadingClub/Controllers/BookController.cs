using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Controllers
{
    public class BookController : Controller
    {
        private readonly TheReadingClubDbContext data;

        public BookController(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            var genres = data.Genres.Select(x => x.Name).ToList();
            var book = new AddBookFormModel { Genres = new List<GenreViewModel>() };

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookFormModel book)
        {
            return null;
        }
    }
}
