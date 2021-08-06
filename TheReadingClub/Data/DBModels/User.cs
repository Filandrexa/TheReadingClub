using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Stories = new HashSet<Story>();
        }

        [Required]
        public string FullName { get; set; }

        public int StoryId { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
