using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.AuthorViewModels;
using TheReadingClub.Services.FormModelServices;

namespace TheReadingClub.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices authorServices;

        public AuthorController(IAuthorServices authorServices)
        {
            this.authorServices = authorServices;
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

            this.authorServices.AddAuthorToDB(author);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            var model = this.authorServices.PopulateAuthorsViewModel();

            return View(model);
        }

        public IActionResult ById(int id)
        {
            var model = this.authorServices.PopulateAuthorViewModel(id);

            return View(model);
        }
    }
}
