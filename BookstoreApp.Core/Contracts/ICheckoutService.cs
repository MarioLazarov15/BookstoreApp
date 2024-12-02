using BookstoreApp.Core.Models.Checkout;
using BookstoreApp.Core.Models.Country;
using BookstoreApp.Core.Models.Shoppingcart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Contracts
{
	public interface ICheckoutService
	{
		Task<ShoppingcartViewModel> Index(string shoppingcartId);
		Task ProcessCheckout(string shoppingcartId, CheckoutFormModel checkoutFormModel);
		void OrderDone(string shoppingcartId);
		Task<IEnumerable<CountryViewModel>> GetAllCountries();

    }
}
