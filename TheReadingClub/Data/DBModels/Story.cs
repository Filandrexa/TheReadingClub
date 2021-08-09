using System;
using System.ComponentModel.DataAnnotations;

namespace TheReadingClub.Data.DBModels
{
    public class Story
    {
        public Story()
        {
            this.Id = new Guid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public string StoryDescription { get; set; }

        public bool IsPublic { get; set; }
    }
}
