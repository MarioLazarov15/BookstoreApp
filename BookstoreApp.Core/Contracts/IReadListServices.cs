using BookstoreApp.Core.Models.ReadList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
    public interface IReadListServices
    {
        Task AddBookToReadListAsync(int bookId, string userId);
        Task RemoveBookFromReadListAsync(int bookId, string userId);
        Task<List<BooksReadListViewModel>> GetReadListAsync(string userId);
    }
}
