using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop1.Models
{
    public class Author
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public ICollection<Book>? Books { get; set; }


    }
}
