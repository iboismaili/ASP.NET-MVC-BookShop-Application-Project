using BookShop1.Models;

namespace BookShop1.ViewModels
{
    public class BookTitle
    {

   
            public IList<Book>? Book { get; set; }

            public string SearchTitle { get; set; }
            public string SearchAuthor { get; set; }
       
    }
}
