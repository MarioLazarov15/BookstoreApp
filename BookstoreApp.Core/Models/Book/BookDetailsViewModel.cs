using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Models.Book
{
	public class BookDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string? Description { get; set; }

		public string? ImageUrl { get; set; }

		public decimal Price { get; set; }

		public string Category { get; set; } = string.Empty;
	}
}
