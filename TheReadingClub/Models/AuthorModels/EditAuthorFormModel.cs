using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Models.AuthorModels
{
    public class EditAuthorFormModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [RegularExpression("[A-Za-z ']*")]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        public string ImageURL { get; set; }
    }
}
