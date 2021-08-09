using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.BookViewModels;
using TheReadingClub.Models.ModeratorModels;

namespace TheReadingClub.Services.ModeratorServices
{
    public class ModeratorServices : IModeratorServices
    {
        private readonly TheReadingClubDbContext data;

        public ModeratorServices(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public void ApproveAuthor(int id)
        {
            var author = data.AuthorPendingApprovals
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (author == null)
            {
                return;
            }

            var newAuthor = new Data.DBModels.Author { FullName = author.FullName, ImageURL = author.ImageURL };
            data.Authors.Add(newAuthor);
            data.AuthorPendingApprovals.Remove(author);
            data.SaveChanges();
        }

        public void ApproveBook(int id)
        {
            var book = data.BookPendingApprovals
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (book == null)
            {
                return;
            }

            var newBook = new Data.DBModels.Book
            {
                Author = book.Author,
                Description = book.Description,
                ImageURL = book.ImageURL,
                ReleaseYear = book.ReleaseYear,
                Title = book.Title,
                Genres = book.Genres,
            };

            data.Books.Add(newBook);
            data.BookPendingApprovals.Remove(book);
            data.SaveChanges();
        }

        public void DeclineAuthor(int id)
        {
            var author = data.AuthorPendingApprovals
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (author == null)
            {
                return;
            }

            data.AuthorPendingApprovals.Remove(author);
            data.SaveChanges();
        }

        public void DeclineBook(int id)
        {
            var book = data.BookPendingApprovals
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (book == null)
            {
                return;
            }

            data.BookPendingApprovals.Remove(book);
            data.SaveChanges();
        }

        public ICollection<AuthorsApprovalViewModel> PopulateAuthorApprovalView()
        {
            var model = data.AuthorPendingApprovals
                .Select(x => new AuthorsApprovalViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageURL = x.ImageURL,
                }).ToList();

            return model;
        }

        public ICollection<BooksApprovalViewModel> PopulateBookApprovalView()
        {
            var model = data.BookPendingApprovals
                .Select(x => new BooksApprovalViewModel
                {
                    Id = x.Id,
                    Author = x.Author.FullName,
                    Description = x.Description,
                    Genres = x.Genres.Select(g=> new GenreViewModel { Id = g.Id, Name = g.Name}).ToList(),
                    ImageURL = x.ImageURL,
                    ReleaseYear = x.ReleaseYear,
                    Title = x.Title,
                })
                .ToList();

            return model;
        }
    }
}
