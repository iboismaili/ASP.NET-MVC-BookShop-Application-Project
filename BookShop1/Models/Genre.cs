using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop1.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; } = string.Empty;

        public ICollection<BookGenre>? Books { get; set; }

    }
}
