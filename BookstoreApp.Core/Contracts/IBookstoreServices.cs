using BookstoreApp.Core.Models.Bookstore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
    public interface IBookstoreServices
    {
         Task<IEnumerable<BooksViewModel>> GetAllBooksAsync();
    }
}
