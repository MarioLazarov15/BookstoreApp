using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Core.Models.Admin;
using BookstoreApp.Core.Models.Category;
using BookstoreApp.Core.Models.Country;
using BookstoreApp.Infrastructure.Constants;
using BookstoreApp.Infrastructure.Data.Models;

namespace BookstoreApp.Core.Models.Checkout
{
	public class CheckoutFormModel
	{
		public string OrderId { get; set; } = string.Empty;

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(DataConstants.Order.FirstNameMaxLength, MinimumLength = DataConstants.Order.FirstNameMinLength,
			ErrorMessage = "{0} must be between {2} and {1} characters.")]
		public string FirstName { get; set; } = null!;

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(DataConstants.Order.LastNameMaxLength, MinimumLength = DataConstants.Order.LastNameMinLength,
			ErrorMessage = "{0} must be between {2} and {1} characters.")]
		public string LastName { get; set; } = null!;

		[StringLength(DataConstants.Order.AdditionalInfoMaxLength,ErrorMessage = "{0} must be no more than {1} long.")]
		public string? AdditionalInfo { get; set; }

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(DataConstants.Order.CityNameMaxLength, MinimumLength = DataConstants.Order.CityNameMinLength,
			ErrorMessage = "{0} must be between {2} and {1} characters.")]
		public string City { get; set; } = null!;

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(DataConstants.Order.ZipCodeMaxLength, MinimumLength = DataConstants.Order.ZipCodeMinLength,
			ErrorMessage = "{0} must be exactly {1} characters.")]
		public string Postcode { get; set; } = null!;

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(DataConstants.Order.PhoneNumberMaxLength, MinimumLength = DataConstants.Order.PhoneNumberMinLength,
			ErrorMessage = "{0} must be exactly {1} characters.")]
		public string Phone { get; set; } = null!;

		[Required(ErrorMessage = "{0} is required.")]
		[StringLength(DataConstants.Order.EmailMaxLength, MinimumLength = DataConstants.Order.EmailMinLength,
			ErrorMessage = "{0} must be between {2} and {1} characters.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;


		[Display(Name = "Country")]
		public int CountryId { get; set; }
		public IEnumerable<CountryViewModel>? Countries { get; set; }
          = new List<CountryViewModel>();

    }
}
