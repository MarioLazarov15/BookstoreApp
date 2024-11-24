using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace BookstoreApp.Infrastructure.Data.Models
{
	public enum BookSorting
	{
		AscendingByName = 0,
        DescendingByName = 1,
        AscendingByPrice = 2,
        DescendingByPrice = 3
	}
}