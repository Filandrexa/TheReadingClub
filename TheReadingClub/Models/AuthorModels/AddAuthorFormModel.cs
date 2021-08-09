using System.ComponentModel.DataAnnotations;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Models.AuthorViewModels
{
    public class AddAuthorFormModel
    {
        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression(AuthorNameRegex)]
        [StringLength(AuthorNameMaxLenght, MinimumLength = AuthorNameMinLenght)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageURL { get; set; }
    }
}
