using System.ComponentModel.DataAnnotations;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Models.AuthorModels
{
    public class EditAuthorFormModel
    {
        [Required]
        public int Id { get; set; }

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
