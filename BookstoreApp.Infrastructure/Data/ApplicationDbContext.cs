using BookstoreApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

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

            builder.Entity<ShoppingcartBook>()
                .HasOne(scb => scb.Shoppingcart)
                .WithMany(sc => sc.ShoppingcartsBooks)
                .HasForeignKey(scb => scb.ShoppingcartId);

            builder.Entity<ShoppingcartBook>()
                .HasOne(scb => scb.Book)
                .WithMany()
                .HasForeignKey(p => p.BookId);

            builder.Entity<OrderBook>()
                .HasKey(bo => new
                {
                    bo.OrderId,
                    bo.BookId
                });

            builder.Entity<OrderBook>()
                .HasOne(bo => bo.Book)
                .WithMany()
                .HasForeignKey(po => po.BookId);

            builder.Entity<OrderBook>()
                .HasOne(bo => bo.Order)
                .WithMany(o => o.OrdersBooks)
                .HasForeignKey(bo => bo.OrderId);

            builder.Entity<UserOrder>()
                .HasKey(uo => new
                {
                    uo.OrderId,
                    uo.UserId
                });

            builder.Entity<UserOrder>()
                .HasOne(uo => uo.ApplicationUser)
                .WithMany()
                .HasForeignKey(uo => uo.UserId);

            builder.Entity<UserOrder>()
                .HasOne(uo => uo.Order)
                .WithMany(o => o.UsersOrders)
                .HasForeignKey(uo => uo.OrderId);

            base.OnModelCreating(builder);
        }
    }
}
