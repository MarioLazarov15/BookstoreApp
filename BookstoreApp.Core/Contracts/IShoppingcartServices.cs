using BookstoreApp.Core.Models.Book;
using BookstoreApp.Core.Models.Shoppingcart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
	public interface IShoppingcartServices
	{
		Task<ShoppingcartViewModel?> GetAllBooksFromCartAsync(string userId);
		Task AddBookToCartAsync(int id, string userId);
		Task RemoveBookFromCartAsync(int id, string userId);
	}
}
