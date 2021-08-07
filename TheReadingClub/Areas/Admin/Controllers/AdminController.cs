using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReadingClub.Models.AdminModels;
using TheReadingClub.Services.AdminServices;

namespace TheReadingClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminServices adminServices;

        public AdminController(IAdminServices adminServices)
        {
            this.adminServices = adminServices;
        }

        public IActionResult PromoteUser(string id = "A")
        {
            var model = adminServices.AllUsers(id);
            return View(model);
        }

        public IActionResult ById(string id)
        {
            var model = adminServices.UserById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult ById(UserByIdViewModel user)
        {
            var succes = adminServices.PromoteUserToModerator(user.Id);

            if (!succes)
            {
                return View(user.Id);
            }

            return RedirectToAction("PromoteUser", "Admin");
        }
    }
}