using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookShop1.Models;
using BookShop1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookShop1.Models
{
    public class BookShop1Context : IdentityDbContext<BookShop1User>
    {
        public BookShop1Context (DbContextOptions<BookShop1Context> options)
            : base(options)
        {
        }

        public DbSet<BookShop1.Models.Author> Author { get; set; } = default!;

        public DbSet<BookShop1.Models.Book>? Book { get; set; }

        public DbSet<BookShop1.Models.Genre>? Genre { get; set; }

        public DbSet<BookShop1.Models.Review>? Review { get; set; }

        public DbSet<BookShop1.Models.UserBooks>? UserBooks { get; set; }

        public  DbSet<BookShop1.Models.BookGenre>? BookGenre { get; set;}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
