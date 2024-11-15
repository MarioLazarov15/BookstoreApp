using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Infrastructure.Data.Models;

namespace BookstoreApp.Infrastructure.Data.SeedDb
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
         public void Configure(EntityTypeBuilder<Country> builder)
         {
                var data = new SeedData();

                builder.HasData(new Country[]
                {
                data.Bulgaria,
                data.Greece,
                data.Serbia ,
                data.Croatia,
                data.Romania,
                data.Albania,
                });
         }
        
    }
}
