using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.ViewModelServices
{
    public class BookViewModel : IBookViewModel
    {
        private readonly TheReadingClubDbContext data;

        public BookViewModel(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public ICollection<HomePageBookViewModel> homePageBooks()
        {
            var model = data.Books.Select(x => new HomePageBookViewModel
            {
                Id = x.Id,
                Title = x.Title,
                AuthorId = x.AuthorId,
                Author = x.Autor.FullName,
                Description = x.Description,
                ImageURL = x.ImageURL,
                ReleaseYear = x.ReleaseYear,
                Genres = x.Genres.Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                }).ToList()
            })
            .OrderBy(d => d.ReleaseYear)
            .Take(3)
            .ToList();

            return model;
        }
    }
}
