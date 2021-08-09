using System.Collections.Generic;
using TheReadingClub.Models.ModeratorModels;

namespace TheReadingClub.Services.ModeratorServices
{
    public interface IModeratorServices
    {
        public ICollection<AuthorsApprovalViewModel> PopulateApprovalView();

        public void ApproveAuthor(int id);

        public void DeclineAuthor(int id);
    }
}
