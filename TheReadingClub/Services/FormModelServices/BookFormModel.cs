using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Data.DBModels;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public class BookFormModel : IBookFormModel
    {
        private readonly TheReadingClubDbContext data;

        public BookFormModel(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public bool AddBook(AddBookFormModel book)
        {
            var author = data.Authors.Where(x => x.FullName == book.Author).FirstOrDefault();

            if (author == null)
            {
                return false;
            }

            var bookToAdd = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Author = author,
                ImageURL = book.ImageURL,
                ReleaseYear = book.ReleaseYear
            };

            foreach (var genre in book.Genres)
            {
                var genreToAdd = data.Genres.Where(x => x.Name == genre.Name).FirstOrDefault();
                bookToAdd.Genres.Add(genreToAdd);
            }

            data.Books.Add(bookToAdd);
            data.SaveChanges();

            return true;
        }
    }
}
