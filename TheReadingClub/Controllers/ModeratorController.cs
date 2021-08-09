using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Services.ModeratorServices;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Authorize(Roles = ModeratorRole)]
    public class ModeratorController : Controller
    {
        private readonly IModeratorServices moderatorServices;

        public ModeratorController(IModeratorServices moderatorServices)
        {
            this.moderatorServices = moderatorServices;
        }

        public IActionResult AuthorApproval()
        {
            var model = moderatorServices.PopulateAuthorApprovalView();

            return View(model);
        }

        public IActionResult ApproveAuthor(int id)
        {
            moderatorServices.ApproveAuthor(id);

            return RedirectToAction("AuthorApproval", "Moderator");
        }

        public IActionResult DeclineAuthor(int id)
        {
            moderatorServices.DeclineAuthor(id);

            return RedirectToAction("AuthorApproval", "Moderator");
        }

        public IActionResult BookApproval()
        {
            var model = moderatorServices.PopulateBookApprovalView();

            return View(model);
        }

        public IActionResult ApproveBook(int id)
        {
            moderatorServices.ApproveBook(id);

            return RedirectToAction("BookApproval", "Moderator");
        }

        public IActionResult DeclineBook(int id)
        {
            moderatorServices.DeclineBook(id);

            return RedirectToAction("BookApproval", "Moderator");
        }
    }
}
