using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookShop1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public int Numpages { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string FrontPage { get; set; } = string.Empty;
        public string DownloadUrl { get; set; } = string.Empty;
        public int AuthorId { get; set; }

        public Author? Author { get; set; }
        public Review? Review { get; set; }

        public ICollection<BookGenre>? Genres { get; set; }
        [NotMapped]
        public ICollection<Review>? Reviews { get; set; }

        public ICollection<UserBooks>? Users { get; set; }

    }
}
