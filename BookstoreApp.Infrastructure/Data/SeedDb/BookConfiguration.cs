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
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
                var data = new SeedData();

                builder.HasData(new Book[]
                {
                data.BarackObama,
                data.MichelleObama,
                data.TheElementsOfTheCrown ,
                data.TheQueenOfNothing,
                data.USHistory,
                data.WorldHistory,
                data.JustTryOneBite,
                data.IfYouGiveAMouseACookie,
                data.TheLoveHypothesis,
                data.HappyPlace,
                data.AllSystemsRed,
                data.TheSoundOfStars,
                data.IntoTheWild,
                data.TheGirlWhoStoleAnElephant,
                });
        }
       
    }
    
}
