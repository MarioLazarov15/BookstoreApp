using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    public class ShoppingCart
    {
        [Key]
        [Comment("Shopping cart identifier")]
        public int Id { get; set; }

        [Comment("Shopping cart total")]
        public  decimal Total { get; set; }

        [Comment("List of the mapping table ShoppingcartBook")]
        public IEnumerable<ShoppingcartBook> ShoppingcartsBooks { get; set; } = new List<ShoppingcartBook>();
    }
}
