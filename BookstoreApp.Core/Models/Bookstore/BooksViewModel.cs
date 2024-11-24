using BookstoreApp.Core.Models.Book;
using BookstoreApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Models.Bookstore
{
    public class BooksViewModel
    {
		public BooksViewModel(List<BookDetailsViewModel> books)
		{
			Books = books;
		}
		public List<BookDetailsViewModel> Books { get; set; }
		public string SearchTerm { get; set; }
		public BookSorting Sorting { get; set; }
	}
}
