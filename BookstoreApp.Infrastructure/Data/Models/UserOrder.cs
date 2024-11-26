using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Mapping table of ApplicationUser and Order")]
    public class UserOrder
    {
        [ForeignKey(nameof(IdentityUser))]
        [Comment("User identifier")]
        public string UserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;

        [ForeignKey(nameof(Order))]
        [Comment("Order identifier")]
        public string OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
