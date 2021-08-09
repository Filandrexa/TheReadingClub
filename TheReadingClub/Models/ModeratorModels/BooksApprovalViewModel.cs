using System.Collections.Generic;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Models.ModeratorModels
{
    public class BooksApprovalViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int ReleaseYear { get; set; }
    }
}
