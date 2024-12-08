using BookstoreApp.Core.Models.Category;
using BookstoreApp.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Models.Admin
{
    public class AdminViewModel
    {

        [Required]
        [Display(Name = "Title")]
        [StringLength(DataConstants.Book.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;


        [StringLength(DataConstants.Book.DescriptionMaxLength)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

		[Required]
		[Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;


		[Required]
        [Display(Name = "Price")]
		[Range(DataConstants.Book.PriceMinValue, DataConstants.Book.PriceMaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]

		public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        public IEnumerable<CategoriesViewModel>? Categories { get; set; }
          = new List<CategoriesViewModel>();
    }
}
