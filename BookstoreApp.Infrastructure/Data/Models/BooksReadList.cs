using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    [Comment("Mapping table of Read List and Book")]
    public class BooksReadList
    {
        [ForeignKey(nameof(ReadListId))]
        [Comment("Read list identifier")]
        public string ReadListId { get; set; } = null!;
        public ReadList ReadList { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        [Comment("Book identifier")]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
