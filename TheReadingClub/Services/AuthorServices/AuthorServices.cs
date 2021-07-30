using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.AuthorViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public class AuthorServices : IAuthorServices
    {
        private readonly TheReadingClubDbContext data;

        public AuthorServices(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public bool AddAuthorToDB(AddAuthorFormModel author)
        {
            var authorToAdd = new Data.DBModels.Author
            {
                FullName = author.FullName,
                ImageURL = author.ImageURL,
            };

            data.Authors.Add(authorToAdd);
            data.SaveChanges();
            return true;
        }

        public ICollection<AuthorsViewModel> PopulateAuthorsViewModel()
        {
            var authors = data.Authors
            .Select(x => new AuthorsViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Books = x.Books.Count(),
            }
            )
            .OrderBy(n=> n.FullName)
            .ToList();

            return authors;
        }

        public AuthorViewModel PopulateAuthorViewModel(int id)
        {
            var author = data.Authors.Where(x => x.Id == id)
                .Select(x => new AuthorViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageURL = x.ImageURL,
                    Books = x.Books.Select(b => new AuthorBookViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Genre = b.Genres.Select(g=> g.Name).ToList(),
                    }).ToList(),
                }
                ).FirstOrDefault();

            return author;
        }
    }
}
