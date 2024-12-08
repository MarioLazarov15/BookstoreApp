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
        private const int DEFAULT_PAGE = 1;
        private const int DEFAULT_PRODUCTS_PER_PAGE = 8;

        public BooksViewModel(List<BookDetailsViewModel> books,
            int totalBooksCount)
        {
            Books = books;
            TotalProductsCount = totalBooksCount;
            CurrentPage = DEFAULT_PAGE;
            ProductsPerPage = DEFAULT_PRODUCTS_PER_PAGE;
        }
		public List<BookDetailsViewModel> Books { get; set; }
		public string SearchTerm { get; set; }
		public BookSorting Sorting { get; set; }
        public int TotalProductsCount { get; set; }
        public int ProductsPerPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
