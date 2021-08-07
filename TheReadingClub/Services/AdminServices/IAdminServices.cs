using System.Collections.Generic;
using TheReadingClub.Models.AdminModels;

namespace TheReadingClub.Services.AdminServices
{
    public interface IAdminServices
    {
        public ICollection<AllUsersViewModel> AllUsers(string id);

        public UserByIdViewModel UserById(string id);

        public bool PromoteUserToModerator(string id);
    }
}
