using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class AuthorPendingApproval
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
