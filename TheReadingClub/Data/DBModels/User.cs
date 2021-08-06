using Microsoft.AspNetCore.Identity;

namespace TheReadingClub.Data.DBModels
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
