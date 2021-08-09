using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Models.ModeratorModels
{
    public class AuthorsApprovalViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
