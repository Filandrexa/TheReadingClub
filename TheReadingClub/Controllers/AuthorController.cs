using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.AuthorModels;
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

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddAuthorFormModel());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddAuthorFormModel author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            this.authorServices.AddAuthorToBeApproved(author);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All(string id = "A")
        {
            var model = this.authorServices.PopulateAuthorsViewModel(id);

            return View(model);
        }

        public IActionResult ById(int id)
        {
            var model = this.authorServices.PopulateAuthorViewModel(id);

            return View(model);
        }

        [Authorize(Roles ="Admin, Moderator")]
        public IActionResult Edit(int id)
        {
            var model = authorServices.GetAuthorFromDb(id);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Edit(EditAuthorFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = authorServices.EditAuthor(model);

            if (!success)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
