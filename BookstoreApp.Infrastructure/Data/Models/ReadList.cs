using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Read list model")]
    public class ReadList
    {
        [Key]
        [Comment("Read list identifier")]
        public string Id { get; set; } = null!;

        [Comment("List of the mapping table BooksReadList")]
        public IEnumerable<BooksReadList> BooksReadList { get; set; } = new List<BooksReadList>();
    }
}
