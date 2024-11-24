using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Models.Bookstore;
using BookstoreApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
    public interface IBookstoreServices
    {
		Task<List<BookDetailsViewModel>> GetAllBooksAsync(string searchTerm,
		   BookSorting sorting);
	}
}
