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
    [Comment("Book model")]
    public class Book
    {
        [Key]
        [Comment("Book identifier")]
        public int Id { get; set; }

        [Comment("Book title")]
        [MaxLength(Constants.DataConstants.Book.TitleMaxLength)]
        [Required]
        public string Title { get; set; } = null!;

        [Comment("Image of the book")]
        public string? ImageUrl { get; set; }

        [Comment("Description of the book")]
        [MaxLength(Constants.DataConstants.Book.DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [Comment("Book price")]
        public decimal Price { get; set; }

        [Comment("Category of the book")]
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;


        [Comment("List of the mapping table OrderBook")]
        public IEnumerable<OrderBook> OrdersBooks { get; set; } = new List<OrderBook>();

        [Comment("List of the mapping table ShoppingcartBook")]
        public IEnumerable<ShoppingcartBook> ShoppingcartsBooks { get; set; } = new List<ShoppingcartBook>();
    }
}
