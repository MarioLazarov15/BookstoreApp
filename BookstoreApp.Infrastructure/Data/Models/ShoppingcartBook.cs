using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Mapping table of Shopping cart and Book")]
    public class ShoppingcartBook
    {
        [ForeignKey(nameof(ShoppingcartId))]
        [Comment("Shopping cart identifier")]
        public string ShoppingcartId { get; set; } = null!;
        public ShoppingCart Shoppingcart { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        [Comment("Product identifier")]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        [Comment("Amount of certain book")]
        public int ProductAmount { get; set; }
    }
}
