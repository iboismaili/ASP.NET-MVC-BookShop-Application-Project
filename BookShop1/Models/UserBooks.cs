
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop1.Models
{
    public class UserBooks
    {
        public int Id { get; set; }
        public string AppUser { get; set; } = string.Empty;
        public int BookId { get; set; }
        public Book? Book { get; set; }

    }
}
