using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.AuthorViewModels;
using TheReadingClub.Services.FormModelServices;

namespace TheReadingClub.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices author;

        public AuthorController(IAuthorServices authorFormModel)
        {
            this.author = authorFormModel;
        }

        public IActionResult Add()
        {
            return View(new AddAuthorFormModel());
        }

        [HttpPost]
        public IActionResult Add(AddAuthorFormModel author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            this.author.AddAuthorToDB(author);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            var model = this.author.PopulateAuthorsViewModel();

            return View(model);
        }

        public IActionResult ById(int id)
        {
            var model = this.author.PopulateAuthorViewModel(id);

            return View(model);
        }
    }
}
