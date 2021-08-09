using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.BookModels;
using TheReadingClub.Models.BookViewModels;
using TheReadingClub.Services.BookServices;

namespace TheReadingClub.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices bookServices;
        private readonly TheReadingClubDbContext data;

        public BookController(IBookServices bookServices, TheReadingClubDbContext data)
        {
            this.bookServices = bookServices;
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
            var addBook = bookServices.AddBook(model);

            if (!ModelState.IsValid && !addBook)
            {
                model.Genres = data.Genres.Select(x => new GenreViewModel { Id = x.Id, Name = x.Name }).ToList();
                model.Author = data.Authors.Select(x => new AuthorBookSelectFormModel { Id = x.Id, FullName = x.FullName }).ToList();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ById(int id)
        {
            var model = bookServices.BookById(id);

            return View(model);
        }

        public IActionResult All()
        {
            var model = bookServices.AllBooks();

            return View(model);
        }

        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Edit(int id)
        {
            var model = bookServices.PopulateEditBookFormModel(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Edit(EditBookFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Author = data.Authors.Select(a => new AuthorBookSelectFormModel { Id = a.Id, FullName = a.FullName }).ToList();
                model.Genres = data.Genres.Select(g => new GenreViewModel { Id = g.Id, Name = g.Name }).ToList();
                return View(model);
            }

            var success = bookServices.EditBook(model);

            if (!success)
            {
                model.Author = data.Authors.Select(a => new AuthorBookSelectFormModel { Id = a.Id, FullName = a.FullName }).ToList();
                model.Genres = data.Genres.Select(g => new GenreViewModel { Id = g.Id, Name = g.Name }).ToList();
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
