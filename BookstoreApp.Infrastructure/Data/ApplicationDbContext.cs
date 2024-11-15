using BookstoreApp.Infrastructure.Data.Models;
using BookstoreApp.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ShoppingCart> Shoppingcarts { get; set; }
        public DbSet<ShoppingcartBook> ShoppingcartsBooks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserOrder> UsersOrders { get; set; }
        public DbSet<OrderBook> OrdersBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new ShoppingcartConfiguration());

            builder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            builder.Entity<ShoppingCart>()
                .Property(sb => sb.Total)
                .HasPrecision(18, 2);

            builder.Entity<ShoppingcartBook>()
                .HasKey(scb => new
                {
                    scb.ShoppingcartId,
                    scb.BookId
                });

            builder.Entity<OrderBook>()
                .HasKey(bo => new
                {
                    bo.OrderId,
                    bo.BookId
                });

            builder.Entity<UserOrder>()
                .HasKey(uo => new
                {
                    uo.OrderId,
                    uo.UserId
                });

            base.OnModelCreating(builder);
        }
    }
}
