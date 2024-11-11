using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Country")]
    public class Country
    {
        [Key]
        [Comment("Country identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.DataConstants.Country.NameMaxLength)]
        [Comment("Country name")]
        public string Name { get; set; } = null!;
    }
}
