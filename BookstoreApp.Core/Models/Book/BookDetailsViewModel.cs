using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookstoreApp.Infrastructure.Constants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Models.Book
{
	public class BookDetailsViewModel
	{
		public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Book.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;


        [StringLength(DataConstants.Book.DescriptionMaxLength)]
        public string? Description { get; set; }

		public string? ImageUrl { get; set; }


        [Required]
        public decimal Price { get; set; }


        [Required]
        public string Category { get; set; } = string.Empty;
	}
}
