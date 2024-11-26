using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Mapping table of Book and Order")]
    public class OrderBook
    {
        [ForeignKey(nameof(Book))]
        [Comment("Book identifier")]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        [Comment("Book amount")]
        public int Amount { get; set; }

        [ForeignKey(nameof(Order))]
        [Comment("Order identifier")]
        public string OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
