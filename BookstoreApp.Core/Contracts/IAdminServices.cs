using BookstoreApp.Core.Models.Category;
using BookstoreApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
    public interface IAdminServices
    {
        Task<Book> AddNewBook(string title, decimal price, string imageUrl, string description, int categoryId);
        Task ModifyBook(int id, string title, decimal price, string imageUrl, string description, int categoryId);

        Task<Book> GetBookById(int id);
        Task<IEnumerable<CategoriesViewModel>> GetAllCategories();
    }
}
