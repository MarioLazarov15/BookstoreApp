using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("First name of the buyer")]
        [MaxLength(Constants.DataConstants.Order.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Comment("Last name of the buyer")]
        [MaxLength(Constants.DataConstants.Order.FirstNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Country))]
        [Comment("Country of the buyer")]
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        [Required]
        [Comment("City of the buyer")]
        [MaxLength(Constants.DataConstants.Order.CityNameMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [Comment("Zip code of the buyer")]
        [MaxLength(Constants.DataConstants.Order.ZipCodeMaxLength)]
        public string ZipCode { get; set; } = null!;

        [Required]
        [Comment("Phone number of the buyer")]
        [MaxLength(Constants.DataConstants.Order.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Comment("Email of the buyer")]
        [MaxLength(Constants.DataConstants.Order.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Comment("Additional Information about adress")]
        [MaxLength(Constants.DataConstants.Order.AdditionalInfoMaxLength)]
        public string? AdditionalInfo { get; set; }

        [Comment("List of the mapping table OrderBook")]
        public IEnumerable<OrderBook> OrdersBooks { get; set; } = new List<OrderBook>();
    }
}
