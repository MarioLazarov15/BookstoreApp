using BookstoreApp.Core.Models.Book;
using BookstoreApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
	public interface IBookServices
	{
		Task<BookDetailsViewModel?> GetBookDetailsAsync(int id);
		Task RemoveBookAsync(int id);

    }
}
