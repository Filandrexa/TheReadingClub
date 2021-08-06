using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class Story
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public string StoryDescription { get; set; }
    }
}
