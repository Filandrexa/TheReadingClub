using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Models.AuthorModels;
using TheReadingClub.Models.AuthorViewModels;

namespace TheReadingClub.Services.FormModelServices
{
    public class Author : IAuthor
    {
        private readonly TheReadingClubDbContext data;

        public Author(TheReadingClubDbContext data)
        {
            this.data = data;
        }

        public void AddAuthorToDB(AddAuthorFormModel author)
        {
            var authorToAdd = new Data.DBModels.Author
            {
                FullName = author.FullName,
                ImageURL = author.ImageURL,
            };

            data.Authors.Add(authorToAdd);
            data.SaveChanges();
        }

        public ICollection<AuthorsViewModel> PopulateAuthorsViewModel()
        {
            var authors = data.Authors.Select(x => new AuthorsViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                ImageURL = x.ImageURL,
                Books = x.Books.Select(b=> new AuthorBookViewModel 
                    {
                      Id = b.Id,
                      Title = b.Title,
                    }).ToList()
            }
            ).ToList();

            return authors;
        }
    }
}
