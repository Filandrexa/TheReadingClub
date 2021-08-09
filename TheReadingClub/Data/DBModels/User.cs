using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Data.DBModels
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Stories = new HashSet<Story>();
        }

        [Required]
        [MaxLength(UserFullNameMaxLenght)]
        public string FullName { get; set; }

        public int StoryId { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}
