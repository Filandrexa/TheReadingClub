using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheReadingClub.Data.DBModels;

namespace TheReadingClub.Data
{
    public class TheReadingClubDbContext : IdentityDbContext<User>
    {
        public TheReadingClubDbContext(DbContextOptions<TheReadingClubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
