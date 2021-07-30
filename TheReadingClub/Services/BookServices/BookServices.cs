using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.BookViewModels;

namespace TheReadingClub.Services.BookServices
{
    public class BookServices : IBookServices
    {
        private readonly TheReadingClubDbContext data;

        public BookServices(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public bool AddBook(AddBookFormModel book)
        {
            var author = data.Authors.Where(x => x.Id == book.AuthorId).FirstOrDefault();

            if (author == null)
            {
                return false;
            }

            var bookToAdd = new Data.DBModels.Book
            {
                Title = book.Title,
                Author = author,
                Description = book.Description,
                ImageURL = book.ImageURL,
                ReleaseYear = book.ReleaseYear,
            };

            foreach (var genre in book.Genres)
            {
                var confirmGenre = data.Genres.Where(x => x.Name == genre.Name).FirstOrDefault();

                if (confirmGenre == null)
                {
                    return false;
                }

                bookToAdd.Genres.Add(confirmGenre);
            }

            data.Books.Add(bookToAdd);
            data.SaveChanges();
            return true;
        }
    }
}
