using System;
using System.Collections.Generic;

namespace TheReadingClub.Models.BookViewModels
{
    public class HomePageBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }

        public int ReleaseYear { get; set; }
    }
}
