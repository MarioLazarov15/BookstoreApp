using BookstoreApp.Core.Models.Book;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Models.Shoppingcart
{
    public class ShoppingcartViewModel
    {
        public string ShoppingcartId { get; set; } = null!;
        public List<BookExtendedViewModel> Products { get; set; } = new List<BookExtendedViewModel>();
        public decimal Total { get; set; }
        public IdentityUser IdentityUser { get; set; } = new IdentityUser();
    }
}
