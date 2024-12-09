using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Core.Models.ReadList
{
    public class ReadListViewModel
    {

        public IEnumerable<BooksReadListViewModel> Books { get; set; } = new List<BooksReadListViewModel>();
        public IdentityUser IdentityUser { get; set; } = new IdentityUser();
    }
}
