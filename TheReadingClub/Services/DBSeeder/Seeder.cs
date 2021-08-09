using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheReadingClub.Data;
using TheReadingClub.Data.DBModels;
using static TheReadingClub.ProjectConstants;

namespace TheReadingClub.Services.DBSeeder
{
    public static class Seeder
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            var data = services.GetRequiredService<TheReadingClubDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            data.Database.Migrate();

            if (!data.Genres.Any())
            {
                var listOfGenres = AddGenresToDb();
                data.Genres.AddRange(listOfGenres);
                data.SaveChanges();
            }

            if (!data.Authors.Any())
            {
                var listOfAuthors = AddAuthorsToDb();
                data.Authors.AddRange(listOfAuthors);
                data.SaveChanges();
            }

            if (!data.Books.Any())
            {
                var listOfBooks = AddBooksToDb(data);
                foreach (var book in listOfBooks)
                {
                    data.Books.Add(book);
                }
                data.SaveChanges();
            }

            AddAdministrator(roleManager, userManager);

            return app;
        }

        private static List<Genre> AddGenresToDb()
        {
            var genres = new List<Genre>();

            var names = new List<string>
            {
            "Mystery",
            "Fantasy",
            "Horror",
            "Science fiction",
            "Romance",
            "Crime",
            "Comedy",
            "Action",
            "Adventure",
            "Children's",
            "Classic",
            "Historical",
            "Thriller",
            "Parody",
            "Satire",
            "Tragedy",
            };

            foreach (var genre in names)
            {
                var newGenre = new Genre { Name = genre };
                genres.Add(newGenre);
            }

            return genres;
        }

        private static List<Author> AddAuthorsToDb()
        {
            var authors = new List<Author>();

            var names = new List<string>
            {
                "William Shakespeare",
                "Agatha Christie",
                "Barbara Cartland",
                "Harold Robbins",
                "J. K. Rowling",
                "Alexander Pushkin",
                "Stephen King",
                "Paulo Coelho",
                "J. R. R. Tolkien",
                "Gosho Aoyama",
            };

            var pictures = new List<string>
            {
                "https://upload.wikimedia.org/wikipedia/commons/a/a2/Shakespeare.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/c/cf/Agatha_Christie.png",
                "https://upload.wikimedia.org/wikipedia/commons/e/ee/Dame_Barbara_Cartland_Allan_Warren.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/4/46/Harold_Robbins_%281979%29.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/5/5d/J._K._Rowling_2010.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/5/56/Kiprensky_Pushkin.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/e/e3/Stephen_King%2C_Comicon.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/c/c0/Coelhopaulo26012007-1.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/6/66/J._R._R._Tolkien%2C_1940s.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/e/e2/Gosho_Aoyama.jpg",
            };

            for (int i = 0; i < 10; i++)
            {
                var newAuthor = new Author { FullName = names[i], ImageURL = pictures[i] };
                authors.Add(newAuthor);
            }

            return authors;
        }

        private static List<Book> AddBooksToDb(TheReadingClubDbContext data)
        {
            var books = new List<Book>
            {
                new Book
                {
                Title = "Hamlet", ReleaseYear = 1599, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/6/6a/Edwin_Booth_Hamlet_1870.jpg",
                Description = "The protagonist of Hamlet is Prince Hamlet of Denmark, son of the recently deceased King Hamlet, and nephew of King Claudius, his father's brother and successor. Claudius hastily married King Hamlet's widow, Gertrude, Hamlet's mother, and took the throne for himself. Denmark has a long-standing feud with neighbouring Norway, in which King Hamlet slew King Fortinbras of Norway in a battle some years ago. Although Denmark defeated Norway and the Norwegian throne fell to King Fortinbras's infirm brother, Denmark fears that an invasion led by the dead Norwegian king's son, Prince Fortinbras, is imminent.",
                Author = data.Authors.Where(x=> x.FullName == "William Shakespeare").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Tragedy").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Romeo and Juliet", ReleaseYear = 1591, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/5/55/Romeo_and_juliet_brown.jpg",
                Description = "The play, set in Verona, Italy, begins with a street brawl between Montague and Capulet servants who, like their masters, are sworn enemies. Prince Escalus of Verona intervenes and declares that further breach of the peace will be punishable by death. Later, Count Paris talks to Capulet about marrying his daughter Juliet, but Capulet asks Paris to wait another two years and invites him to attend a planned Capulet ball. Lady Capulet and Juliet's Nurse try to persuade Juliet to accept Paris's courtship.",
                Author = data.Authors.Where(x=> x.FullName == "William Shakespeare").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Romance").FirstOrDefault(),
                            data.Genres.Where(x=> x.Name == "Tragedy").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Curtain", ReleaseYear = 1975, ImageURL = "https://upload.wikimedia.org/wikipedia/en/a/a0/Curtain_First_Edition_Cover_1975.jpg",
                Description = "A specific person is unsuspected of involvement in five murders by both the police and family of the victims. In all cases, there was a clear suspect. Four of these suspects have since died (one of them hanged); in the case of Freda Clay, who gave her aunt an overdose of morphine, there was too little evidence to prosecute. Poirot calls the recently widowed Hastings to join him in solving this case. Poirot alone sees the pattern of involvement. Poirot, using a wheelchair due to arthritis, and attended by his new valet Curtiss, will not share the name of the previously unsuspected person, using X instead. X is among the guests at Styles Court with them. The old house is a guest hotel under new owners, Colonel and Mrs Luttrell. The guests know each other, with this gathering initiated when Sir William Boyd-Carrington invites the Franklins to join him for a summer holiday stay. The five prior murders took place in the area, among people known to this group.",
                Author = data.Authors.Where(x=> x.FullName == "Agatha Christie").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Crime").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Sleeping Murder", ReleaseYear = 1976, ImageURL = "https://upload.wikimedia.org/wikipedia/en/3/36/Sleeping_Murder_First_Edition_Cover_1976.jpg",
                Description = "Newlywed Gwenda Reed travels ahead of her husband to find a home for them on the south coast of England. In a short time, she finds and buys Hillside, a large old house that feels just like home. She supervises workers in a renovation, staying in a one-time nursery room while the work progresses. She forms a definite idea for the little nursery. When the workmen open a long sealed door, she sees the very wallpaper that was in her mind. Further, a place that seems logical to her for a doorway between two rooms proves to have been one years earlier. She goes to London for a visit with relatives, the author Raymond West, his wife, and his aunt, Miss Jane Marple. During the play, The Duchess of Malfi, when the line \"Cover her face; mine eyes dazzle; she died young\" is spoken, Gwenda screams out; she saw an image of herself viewing a man saying those words strangling a blonde-haired woman named Helen",
                Author = data.Authors.Where(x=> x.FullName == "Agatha Christie").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Crime").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "A Ghost in Monte Carlo", ReleaseYear = 1951, ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/bd/Book_Cover_of_A_Ghost_in_Monte_Carlo.jpg",
                Description = "Eighteen-year-old Mistral is an innocent abroad in the sophisticated Côte D'Azur, where princes and millionaires mingle in the casinos and sumptuous hotels. Accompanied only by her embittered and domineering Aunt Emilie and kindly servant Jeanne, Mistral appears dressed all in grey like a ghost in the salons and ballrooms of Monte Carlo and sets Society's tongues wagging. It's not long before the whole of Monte Carlo are trying to find out who she really is her waif-like beauty has men bewitched and falling in love – gentlemen such as Sir Robert Stanford. But on her aunt's bewildering but strict instructions, she must not converse with any but the Russian Prince Nikolai. Something about Mistral touches Sir Robert's heart – and he cannot understand why Mistral appears afraid to be with him. Yet both of them crave love. Only if Mistral's innocent eyes are finally opened to the truth – that Aunt Emilie's motives are borne not of concern for her niece but of bitterness and a hatred for men.",
                Author = data.Authors.Where(x=> x.FullName == "Barbara Cartland").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Romance").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "The Carpetbaggers", ReleaseYear = 1961, ImageURL = "https://upload.wikimedia.org/wikipedia/en/a/ae/Carpetbaggers.jpg",
                Description = "bestselling novel by Harold Robbins",
                Author = data.Authors.Where(x=> x.FullName == "Harold Robbins").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Romance").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Harry Potter and the Philosopher's Stone", ReleaseYear = 1997, ImageURL = "https://upload.wikimedia.org/wikipedia/en/6/6b/Harry_Potter_and_the_Philosopher%27s_Stone_Book_Cover.jpg",
                Description = "Harry Potter has been treated abusively by his aunt and uncle, Vernon and Petunia Dursley and bullied by their son Dudley since the death of his parents ten years prior. This changes on his eleventh birthday, when a half-giant named Rubeus Hagrid delivers a letter of acceptance into Hogwarts School of Witchcraft and Wizardry, after Vernon and Petunia destroyed previous ones.",
                Author = data.Authors.Where(x=> x.FullName == "J. K. Rowling").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Fantasy").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Ruslan and Ludmila", ReleaseYear = 1820, ImageURL = "https://upload.wikimedia.org/wikipedia/commons/3/36/Ruslan_and_Ludmila_front_page_1820.jpg",
                Description = "Русла́н и Людми́ла, tr. Ruslán i Lyudmíla) is a poem by Alexander Pushkin, published in 1820. It is written as an epic fairy tale consisting of a dedication.",
                Author = data.Authors.Where(x=> x.FullName == "Alexander Pushkin").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Classic").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "The Alchemist", ReleaseYear = 1988, ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/c4/TheAlchemist.jpg",
                Description = "The Alchemist follows the journey of an Andalusian shepherd boy. Believing a recurring dream to be prophetic, he asks a Gypsy fortune teller in the nearby town about its meaning. The woman interprets the dream as a prophecy telling the boy that he will discover a treasure at the Egyptian pyramids.",
                Author = data.Authors.Where(x=> x.FullName == "Paulo Coelho").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Adventure").FirstOrDefault(),
                            data.Genres.Where(x=> x.Name == "Fantasy").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "The Lord of the Rings", ReleaseYear = 1949, ImageURL = "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
                Description = "The prologue explains that the book is \"largely concerned with hobbits\", telling of their origins in a migration from the east, their habits such as smoking \"pipe-weed\", and of how their homeland the Shire is organised. It explains how the narrative follows on from The Hobbit, in which the hobbit Bilbo Baggins finds the One Ring, which had been in the possession of Gollum.",
                Author = data.Authors.Where(x=> x.FullName == "J. R. R. Tolkien").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Fantasy").FirstOrDefault(),
                            data.Genres.Where(x=> x.Name == "Adventure").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Cujo", ReleaseYear = 1981, ImageURL = "https://upload.wikimedia.org/wikipedia/en/8/81/Cujo_%28book_cover%29.jpg",
                Description = "The story takes place in the setting for many King stories: the fictional town of Castle Rock, Maine. Revolving around two local families, the narrative is interspersed with vignettes from the seemingly mundane lives of various other residents. There are no chapter headings, but breaks between passages indicate when the narration switches to a different perspective.",
                Author = data.Authors.Where(x=> x.FullName == "Stephen King").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Horror").FirstOrDefault(),
                        },
                },

                new Book
                {
                Title = "Under the Dome", ReleaseYear = 2009, ImageURL = "https://upload.wikimedia.org/wikipedia/en/0/09/Under_the_Dome_Final.jpg",
                Description = "Under the Dome is a 2009 science fiction novel by the American author, Stephen King. Under the Dome is the 58th book published by Stephen King, and it is his 48th novel. The novel focuses on a small Maine town, and tells an intricate, multi-character, alternating perspective story of how the town's inhabitants contend with the calamity of being suddenly cut off from the outside world by an impassable, invisible glass dome-like barrier that seemingly falls out of the sky, transforming the community into a domed city.",
                Author = data.Authors.Where(x=> x.FullName == "Stephen King").FirstOrDefault(),
                Genres = new List<Genre>
                        {
                            data.Genres.Where(x=> x.Name == "Science fiction").FirstOrDefault(),
                        },
                },
            };

            return books;
        }

        private static void AddAdministrator(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            Task
                .Run(async () =>
                {
                    if (!await roleManager.RoleExistsAsync(AdminRole))
                    {
                        var role = new IdentityRole { Name = AdminRole };

                        await roleManager.CreateAsync(role);
                    }

                    if (!await roleManager.RoleExistsAsync(ModeratorRole))
                    {
                        var role = new IdentityRole { Name = ModeratorRole };

                        await roleManager.CreateAsync(role);
                    }

                    if (!userManager.Users.Any(x=> x.UserName == AdminFullName))
                    {
                        var user = new User
                        {
                            UserName = AdminName,
                            Email = AdminEmail,
                            FullName = AdminFullName,
                        };

                        await userManager.CreateAsync(user, AdminPassword);
                        await userManager.AddToRoleAsync(user, AdminRole);
                    }
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
