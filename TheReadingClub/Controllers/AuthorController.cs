using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.AuthorViewModels;
using TheReadingClub.Services.FormModelServices;

namespace TheReadingClub.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthor authorFormModel;

        public AuthorController(IAuthor authorFormModel)
        {
            this.authorFormModel = authorFormModel;
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

            this.authorFormModel.AddAuthorToDB(author);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            var model = this.authorFormModel.PopulateAuthorsViewModel();

            return View(model);
        }
    }
}
