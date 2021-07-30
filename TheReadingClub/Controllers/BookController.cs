using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.BookViewModels;
using TheReadingClub.Services.BookServices;

namespace TheReadingClub.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices service;
        private readonly TheReadingClubDbContext data;

        public BookController(IBookServices service, TheReadingClubDbContext data)
        {
            this.service = service;
            this.data = data;
        }

        public IActionResult Add()
        {
            var model = new AddBookFormModel();
            model.Genres = data.Genres.Select(x => new GenreViewModel { Id = x.Id, Name = x.Name }).ToList();
            model.Author = data.Authors.Select(x => new AuthorBookSelectFormModel { Id = x.Id, FullName = x.FullName }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddBookFormModel model)
        {
            var addBook = service.AddBook(model);

            if (!ModelState.IsValid && !addBook)
            {
                model.Genres = data.Genres.Select(x => new GenreViewModel { Id = x.Id, Name = x.Name }).ToList();
                model.Author = data.Authors.Select(x => new AuthorBookSelectFormModel { Id = x.Id, FullName = x.FullName }).ToList();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
