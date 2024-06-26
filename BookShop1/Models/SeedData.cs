using BookShop1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookShop1.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider, ILogger logger)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<BookShop1User>>();
            IdentityResult roleResult;

            // Add Registered Role
            var registeredRoleCheck = await RoleManager.RoleExistsAsync("Registered");
            if (!registeredRoleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Registered"));
                if (!roleResult.Succeeded)
                {
                    logger.LogError("Failed to create Registered role");
                }
            }

            // Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
                if (!roleResult.Succeeded)
                {
                    logger.LogError("Failed to create Admin role");
                }
            }

            // Create Admin User
            BookShop1User user = await UserManager.FindByEmailAsync("admin@bookshop.com");
            if (user == null)
            {
                var User = new BookShop1User
                {
                    Email = "admin@bookshop.com",
                 
                };
                string userPWD = "admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);

                if (chkUser.Succeeded)
                {
                    logger.LogInformation("Admin user created successfully");

                    // Add default User to Role Admin
                    var result1 = await UserManager.AddToRoleAsync(User, "Admin");
                    if (!result1.Succeeded)
                    {
                        logger.LogError("Failed to add Admin role to user");
                    }
                }
                else
                {
                    logger.LogError("Failed to create admin user: {Errors}", chkUser.Errors);
                }
            }
            else
            {
                logger.LogInformation("Admin user already exists");
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookShop1Context(
            serviceProvider.GetRequiredService<
            DbContextOptions<BookShop1Context>>()))
            {
               //CreateUserRoles(serviceProvider).Wait();
                // Look for any movies.
                if (context.UserBooks.Any() || context.Review.Any() || context.Genre.Any() || context.Book.Any() || context.Author.Any())
                {
                    return; // DB has been seeded
                }

                context.Author.AddRange(
                    new Author
                    {
                       // Id = 1,
                        FirstName = "Stephen",
                        LastName = "King",
                        BirthDate = DateTime.Parse("1947-09-27"),
                        Nationality = "American",
                        Gender = "Male"
                    },
                     new Author
                     {
                       //  Id = 2,
                         FirstName = "Leo",
                         LastName = "Tolstoy",
                         BirthDate = DateTime.Parse("1937-02-10"),
                         Nationality = "Russian",
                         Gender = "Male"
                     },

                     new Author
                     {
                       //  Id = 3,
                         FirstName = "Jane",
                         LastName = "Austen",
                         BirthDate = DateTime.Parse("1922-02-05"),
                         Nationality = "British",
                         Gender = "Female"
                     },

                      new Author
                      {
                        //  Id = 4,
                          FirstName = "Joanne",
                          LastName = "Rowling",
                          BirthDate = DateTime.Parse("1952-11-15"),
                          Nationality = "British",
                          Gender = "Female"
                      },
                       new Author
                       {
                         //  Id = 5,
                           FirstName = "James",
                           LastName = "Patterson",
                           BirthDate = DateTime.Parse("1922-12-12"),
                           Nationality = "American",
                           Gender = "Male"
                       },
                        new Author
                        {
                          //  Id = 6,
                            FirstName = "Kazuo",
                            LastName = "Ishiguro",
                            BirthDate = DateTime.Parse("1955-02-22"),
                            Nationality = "Japanese",
                            Gender = "Male"
                        },
                         new Author
                         {
                            // Id = 7,
                             FirstName = "Dan",
                             LastName = "Brown",
                             BirthDate = DateTime.Parse("1943-02-28"),
                             Nationality = "American",
                             Gender = "Male"
                         },
                          new Author
                          {
                              //Id = 8,
                              FirstName = "Colleen",
                              LastName = "Hoover",
                              BirthDate = DateTime.Parse("1925-04-01"),
                              Nationality = "American",
                              Gender = "Female"
                          }

                    );
                context.SaveChanges();



                context.Book.AddRange(
    new Book
    {
        // Id = 1,
        Title = "It Starts with Us",
        YearPublished = 2020,
        Numpages = 545,
        Publisher = "Atria Books",
        FrontPage = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT043HMMNY3CyT4ikGISDVDEgnCdv5QbDxhigHw9y5UbEzb1GzI",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Colleen" && d.LastName == "Hoover").Id
    },
    new Book
    {
        // Id = 2,
        Title = "It Ends with Us",
        YearPublished = 2020,
        Numpages = 455,
        Publisher = "Simon & Schuster",
        FrontPage = "/image/2.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Colleen" && d.LastName == "Hoover").Id
    },
    new Book
    {
        // Id = 3,
        Title = "The Da Vinci Code",
        YearPublished = 2003,
        Numpages = 806,
        Publisher = "Doubleday",
        FrontPage = "/image/3.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Dan" && d.LastName == "Brown").Id
    },
    new Book
    {
        // Id = 4,
        Title = "Angels and Demons",
        YearPublished = 2006,
        Numpages = 775,
        Publisher = "Pocket Books",
        FrontPage = "/image/4.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Dan" && d.LastName == "Brown").Id
    },
    new Book
    {
        // Id = 5,
        Title = "Never Let Me Go",
        YearPublished = 2005,
        Numpages = 1003,
        Publisher = "Faber & Faber",
        FrontPage = "/image/5.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Kazuo" && d.LastName == "Ishiguro").Id
    },
    new Book
    {
        // Id = 6,
        Title = "Klara and the Sun",
        YearPublished = 2021,
        Numpages = 987,
        Publisher = "Faber & Faber",
        FrontPage = "/image/6.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Kazuo" && d.LastName == "Ishiguro").Id
    },
    new Book
    {
        // Id = 7,
        Title = "Along Came a Spider",
        YearPublished = 2021,
        Numpages = 801,
        Publisher = "Little, Brown and Company",
        FrontPage = "/image/7.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "James" && d.LastName == "Patterson").Id
    },
    new Book
    {
        // Id = 8,
        Title = "The Ink Black Heart",
        YearPublished = 2022,
        Numpages = 1220,
        Publisher = "Mulholland Books",
        FrontPage = "/image/8.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Joanne" && d.LastName == "Rowling").Id
    },
    new Book
    {
        // Id = 9,
        Title = "Emma",
        YearPublished = 1815,
        Numpages = 922,
        Publisher = "John Murray",
        FrontPage = "/image/9.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Jane" && d.LastName == "Austen").Id
    },
    new Book
    {
        // Id = 10,
        Title = "War and Peace",
        YearPublished = 1867,
        Numpages = 1198,
        Publisher = "The Russian Messenger",
        FrontPage = "/image/10.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Leo" && d.LastName == "Tolstoy").Id
    },
    new Book
    {
        // Id = 11,
        Title = "The Shining",
        YearPublished = 1977,
        Numpages = 768,
        Publisher = "Doubleday",
        FrontPage = "/image/11.jpg",
        DownloadUrl = "/",
        AuthorId = context.Author.Single(d => d.FirstName == "Stephen" && d.LastName == "King").Id
    }
);

                context.SaveChanges();


                context.Genre.AddRange(
                    new Genre {// Id = 1,
                        GenreName = "Science Fiction" },
                     new Genre { //Id = 2, 
                         GenreName = "Mystery" },
                      new Genre { //Id = 3,
                       GenreName = "Action Fiction" },
                      new Genre { //Id = 4,
                          GenreName = "Romance Novel" }

                    );
                context.SaveChanges();

                context.BookGenre.AddRange(


                       new BookGenre { BookId = 1, GenreId = 1 },
                       new BookGenre { BookId = 2, GenreId = 1 },
                       new BookGenre { BookId = 3, GenreId = 1 },
                       new BookGenre { BookId = 4, GenreId = 2 },
                       new BookGenre { BookId = 5, GenreId = 2 },
                       new BookGenre { BookId = 6, GenreId = 3 },
                       new BookGenre { BookId = 7, GenreId = 3 },
                       new BookGenre { BookId = 8, GenreId = 3 },
                       new BookGenre { BookId = 9, GenreId = 2 }
                      


                    );
                context.SaveChanges();




                context.Review.AddRange(
                     new Review
                     {
                        // Id = 1,
                         BookId = context.Book.Single(d => d.Title == "War and Peace").Id,
                         AppUser = "selpakcomfort",
                         Comment = "Cool...",
                         Rating = 60

                     },
                      new Review
                      {
                        //  Id = 2,
                          BookId = context.Book.Single(d => d.Title == "The Shining").Id,
                          AppUser = "fort333",
                          Comment = "Great...",
                          Rating = 80

                      },
                       new Review
                       {
                          // Id = 3,
                           BookId = context.Book.Single(d => d.Title == "Emma").Id,
                           AppUser = "catchme21",
                           Comment = "Wonderfull...",
                           Rating = 77

                       },

                         new Review
                         {
                            // Id = 4,
                             BookId = context.Book.Single(d => d.Title == "Angels and Demons").Id,
                             AppUser = "passion1",
                             Comment = "Amazing...",
                             Rating = 84

                         },
                           new Review
                           {
                             //  Id = 5,
                               BookId = context.Book.Single(d => d.Title == "The Ink Black Heart").Id,
                               AppUser = "catchme21",
                               Comment = "Wonderfull...",
                               Rating = 77

                           },
                           new Review
                           {
                            //   Id = 6,
                               BookId = context.Book.Single(d => d.Title == "The Ink Black Heart").Id,
                               AppUser = "catchme21",
                               Comment = "Wonderfull...",
                               Rating = 81

                           },

                            new Review
                            {
                               // Id = 7,
                                BookId = context.Book.Single(d => d.Title == "Emma").Id,
                                AppUser = "catchme21",
                                Comment = "Wonderfull...",
                                Rating = 91

                            }

                    );

                context.SaveChanges();

                context.UserBooks.AddRange(

                    new UserBooks
                    {

                       // Id = 1,
                        BookId = context.Book.Single(d => d.Title == "It starts with us").Id,
                        AppUser = "catchme21",
                    },

                     new UserBooks
                     {

                        // Id = 2,
                         BookId = context.Book.Single(d => d.Title == "It ends with us").Id,
                         AppUser = "freelance21",
                     },

                      new UserBooks
                      {

                         // Id = 3,
                          BookId = context.Book.Single(d => d.Title == "The Da Vinci Code").Id,
                          AppUser = "robert5",
                      },
                       new UserBooks
                       {

                         //  Id = 4,
                           BookId = context.Book.Single(d => d.Title == "Angels and Demons").Id,
                           AppUser = "aweb111",
                       },
                        new UserBooks
                        {

                           // Id = 5,
                            BookId = context.Book.Single(d => d.Title == "Never Let Me Go").Id,
                            AppUser = "aweb111",
                        },
                         new UserBooks
                         {

                            // Id = 6,
                             BookId = context.Book.Single(d => d.Title == "Klara and the Sun").Id,
                             AppUser = "aweb111",
                         },

                          new UserBooks
                          {

                             // Id = 7,
                              BookId = context.Book.Single(d => d.Title == "Along Came a Spider").Id,
                              AppUser = "selpakcomfort",
                          },

                            new UserBooks
                            {

                               // Id = 8,
                                BookId = context.Book.Single(d => d.Title == "The Ink Black Heart").Id,
                                AppUser = "selpakcomfort",
                            },

                             new UserBooks
                             {

                                // Id = 9,
                                 BookId = context.Book.Single(d => d.Title == "Emma").Id,
                                 AppUser = "passion1",
                             }



                    );

                context.SaveChanges();


            }
        }
    }

}