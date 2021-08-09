using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
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

        public ICollection<AuthorsApprovalViewModel> PopulateApprovalView()
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
    }
}
