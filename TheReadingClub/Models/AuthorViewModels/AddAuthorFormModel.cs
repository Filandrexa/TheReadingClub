using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Models.AuthorViewModels
{
    public class AddAuthorFormModel
    {
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression("[А-Яа-яA-Za-z.]*")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [RegularExpression("[А-Яа-яA-Za-z.]*")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression("[А-Яа-яA-Za-z.]*")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageURL { get; set; }
    }
}
