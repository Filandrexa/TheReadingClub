using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.AuthorViewModels;
using TheReadingClub.Services.FormModelServices;

namespace TheReadingClub.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorFormModel authorFormModel;

        public AuthorController(IAuthorFormModel authorFormModel)
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

            this.authorFormModel.AddAuthor(author);

            return RedirectToAction("Index", "Home");
        }
    }
}
