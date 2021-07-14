using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using TheReadingClub.Data;
using TheReadingClub.Data.DBModels;

namespace TheReadingClub.Services.DBSeeder
{
    public static class Seeder
    {
        private static readonly List<string> Genres = new List<string>
        {
            "Класическа",
            "Научна",
            "Романтика",
            "Фентъзи",
        };

        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();

            var data = scopedService.ServiceProvider.GetService<TheReadingClubDbContext>();

            data.Database.Migrate();

            if (!data.Genres.Any())
            {
                foreach (var genre in Genres)
                {
                    data.Genres.Add(new Genre { Name = genre });
                }

                data.SaveChanges();
            }

            return app;
        }
    }
}
