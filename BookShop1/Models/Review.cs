using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop1.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string AppUser { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        [NotMapped]
        public Book? Book { get; set; }


    }
}
