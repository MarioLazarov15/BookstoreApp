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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
                var data = new SeedData();

            builder.HasData(new Category[]
            {
                data.AutobiographyCategory,
                data.FantasyCategory,
                data.HistoryCategory ,
                data.ChildrenCategory,
                data.RomanceCategory,
                data.ScienceFictionCategory,
                data.AdventureCategory,
            });
        }
    }
}
