using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.BookModels;
using TheReadingClub.Models.BookViewModels;
using TheReadingClub.Models.GenreModels;

namespace TheReadingClub.Services.GenreServices
{
    public class GenreServices : IGenreServices
    {
        private readonly TheReadingClubDbContext data;

        public GenreServices(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public GenreByIdViewModel GenreByIdView(int id)
        {
            var model = data.Genres
                 .Where(x => x.Id == id)
                 .Select(x => new GenreByIdViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Books = x.Books.Select(b => new AllBooksViewModel
                     {
                         Id = b.Id,
                         Title = b.Title,
                         ReleaseYear = b.ReleaseYear,
                         ImageURL = b.ImageURL,
                     }).OrderBy(x => x.Title).ToList(),
                 }).FirstOrDefault();

            return model;
        }

        public ICollection<GenreViewModel> ViewAllGenres()
        {
            var model = data.Genres
                .Select(x => new GenreViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    BooksCount = x.Books.Count(),
                }).ToList();

            return model;
        }
    }
}
