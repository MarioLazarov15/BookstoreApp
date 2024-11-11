using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Book category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.DataConstants.Category.NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        [Comment("List of all books in the category")]
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
