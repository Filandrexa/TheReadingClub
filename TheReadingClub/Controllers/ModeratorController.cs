using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Services.ModeratorServices;

namespace TheReadingClub.Controllers
{
    [Authorize(Roles ="Moderator, Admin")]
    public class ModeratorController : Controller
    {
        private readonly IModeratorServices moderatorServices;

        public ModeratorController(IModeratorServices moderatorServices)
        {
            this.moderatorServices = moderatorServices;
        }

        public IActionResult AuthorApproval()
        {
            var model = moderatorServices.PopulateApprovalView();

            return View(model);
        }

        public IActionResult ApproveAuthor(int id)
        {
            moderatorServices.ApproveAuthor(id);

            return RedirectToAction("All", "Moderator");
        }

        public IActionResult DeclineAuthor(int id)
        {
            moderatorServices.DeclineAuthor(id);

            return RedirectToAction("All", "Moderator");
        }
    }
}
