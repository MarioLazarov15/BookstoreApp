﻿// <auto-generated />
using System;
using BookstoreApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookstoreApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Book identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category of the book");

                    b.Property<string>("Description")
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)")
                        .HasComment("Description of the book");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image of the book");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Book price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Book title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books", t =>
                        {
                            t.HasComment("Book model");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "“My identity might begin with the fact of my race, but it didn’t, couldn't end there. At least that’s what I would choose to believe”\r\nDreams From My Father by Barack Obama (Paperback ISBN 9781782119258) book cover\r\nAvailable as	Paperback, eBook, Downloadable audio\r\n\r\nThis #1 New York Times bestselling",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNigBtJfs3f0sARUdACCC44A_QF7Vh0k_BGQ&s",
                            Price = 19.99m,
                            Title = "Barack Obama"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "In a life filled with meaning and accomplishment, Michelle Obama has emerged as one of the most iconic and compelling women of our era.",
                            ImageUrl = "https://m.media-amazon.com/images/I/81cJTmFpG-L._AC_UF1000,1000_QL80_.jpg",
                            Price = 19.99m,
                            Title = "Michelle Obama"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "In an empire divided into three rings, seventeen-year-old Talise is from the outer ring. This dangerous and crime-laden land has one constant… death.",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1623351257i/58310267.jpg",
                            Price = 22.99m,
                            Title = "The Elements of The Crown"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "A powerful curse forces the exiled Queen of Faerie to choose between ambition and humanity in this highly anticipated and jaw-dropping finale to The Folk of the Air trilogy from a #1 New York Times bestselling author.",
                            ImageUrl = "https://m.media-amazon.com/images/I/91nGoCptgmL._AC_UF1000,1000_QL80_.jpg",
                            Price = 23.99m,
                            Title = "The Queen of Nothing"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Covering the most important material taught in high school American history class, this essential review book breaks need-to-know content into accessible, easily understood lessons.",
                            ImageUrl = "https://images.penguinrandomhouse.com/cover/9780525570127",
                            Price = 29.99m,
                            Title = "U.S. History"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Glencoe World History is a full-survey world history program authored by a world-renowned historian, Jackson Spielvogel, and the National Geographic Society. ",
                            ImageUrl = "https://m.media-amazon.com/images/I/A1BUSpcfSWL._AC_UF1000,1000_QL80_.jpg",
                            Price = 29.99m,
                            Title = "World History"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Description = "These three kids are determined to get their parents to put down the ice cream, cake, and chicken fried steak to just try one bite of healthy whole foods.",
                            ImageUrl = "https://m.media-amazon.com/images/I/81L4z-NZt2L._AC_UF1000,1000_QL80_.jpg",
                            Price = 9.99m,
                            Title = "Just try one bite"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Description = "If a hungry little mouse shows up on your doorstep, you might want to give him a cookie. And if you give him a cookie, he'll ask for a glass of milk.",
                            ImageUrl = "https://m.media-amazon.com/images/I/813csV5cPqL.jpg",
                            Price = 7.49m,
                            Title = "If you give a Mouse a Cookie"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 5,
                            Description = "As a third-year Ph.D. candidate, Olive Smith doesn't believe in lasting romantic relationships--but her best friend does, and that's what got her into this situation.",
                            ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1611937942l/56732449.jpg",
                            Price = 3.29m,
                            Title = "The Love Hypothesis"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 5,
                            Description = "Harriet and Wyn have been the perfect couple since they met in college—they go together like salt and pepper, honey and tea, lobster and rolls. Except, now—for reasons they’re still not discussing—they don’t.",
                            ImageUrl = "https://m.media-amazon.com/images/I/81jTZJQB4WL._AC_UF894,1000_QL80_.jpg",
                            Price = 8.99m,
                            Title = "Happy Place"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 6,
                            Description = "A murderous android discovers itself in All Systems Red, a tense science fiction adventure by Martha Wells that interrogates the roots of consciousness through Artificial Intelligence.",
                            ImageUrl = "https://m.media-amazon.com/images/I/81thdg0KmZL.jpg",
                            Price = 15.80m,
                            Title = "All Systems Red"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 6,
                            Description = "This book has everything! Aliens set on conquering earth! A determined heroine with a hidden stash of books! And the power of music and stories to give those with every reason to hate the power to love.",
                            ImageUrl = "https://m.media-amazon.com/images/I/81yhKr0TzXL.jpg",
                            Price = 16.49m,
                            Title = "The Sound of Stars"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 7,
                            Description = " In April 1992 a young man from a well-to-do family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later, his decomposed body was found by a moose hunter. This is the unforgettable story of how Christopher Johnson McCandless came to die.",
                            ImageUrl = "https://m.media-amazon.com/images/I/61A+LdmTESL._AC_UF1000,1000_QL80_.jpg",
                            Price = 20.49m,
                            Title = "Into The Wild"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 7,
                            Description = "Chaya, outspoken hero, leads her friends and a gorgeous elephant on a noisy, fraught, joyous adventure through the jungle where revolution is stirring and leeches lurk. Will stealing the queen’s jewels be the beginning or the end of everything for the intrepid gang?",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1563136258i/44906685.jpg",
                            Price = 8.49m,
                            Title = "The Girl Who Stole an Elephant"
                        });
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories", t =>
                        {
                            t.HasComment("Book category");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Autobiography"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "History"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Children's Books"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Adventure"
                        });
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Country identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(57)
                        .HasColumnType("nvarchar(57)")
                        .HasComment("Country name");

                    b.HasKey("Id");

                    b.ToTable("Countries", t =>
                        {
                            t.HasComment("Country");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Croatia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Romania"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Albania"
                        });
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Order identifier");

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(750)
                        .HasColumnType("nvarchar(750)")
                        .HasComment("Additional Information about adress");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)")
                        .HasComment("City of the buyer");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasComment("Country of the buyer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Email of the buyer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("First name of the buyer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Last name of the buyer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Phone number of the buyer");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Zip code of the buyer");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.OrderBook", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Order identifier");

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasComment("Book identifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasComment("Book amount");

                    b.HasKey("OrderId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("OrdersBooks", t =>
                        {
                            t.HasComment("Mapping table of Book and Order");
                        });
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.ShoppingCart", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Shopping cart identifier");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Shopping cart total");

                    b.HasKey("Id");

                    b.ToTable("Shoppingcarts");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.ShoppingcartBook", b =>
                {
                    b.Property<string>("ShoppingcartId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Shopping cart identifier");

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasComment("Product identifier");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int")
                        .HasComment("Amount of certain book");

                    b.HasKey("ShoppingcartId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("ShoppingcartsBooks", t =>
                        {
                            t.HasComment("Mapping table of Shopping cart and Book");
                        });
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.UserOrder", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Order identifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User identifier");

                    b.HasKey("OrderId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersOrders", t =>
                        {
                            t.HasComment("Mapping table of ApplicationUser and Order");
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Book", b =>
                {
                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.Country", "Country")
                        .WithMany("Orders")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.OrderBook", b =>
                {
                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.Book", "Book")
                        .WithMany("OrdersBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.Order", "Order")
                        .WithMany("OrdersBooks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.ShoppingcartBook", b =>
                {
                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.Book", "Book")
                        .WithMany("ShoppingcartsBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.ShoppingCart", "Shoppingcart")
                        .WithMany("ShoppingcartsBooks")
                        .HasForeignKey("ShoppingcartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Shoppingcart");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.UserOrder", b =>
                {
                    b.HasOne("BookstoreApp.Infrastructure.Data.Models.Order", "Order")
                        .WithMany("UsersOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Book", b =>
                {
                    b.Navigation("OrdersBooks");

                    b.Navigation("ShoppingcartsBooks");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Country", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.Order", b =>
                {
                    b.Navigation("OrdersBooks");

                    b.Navigation("UsersOrders");
                });

            modelBuilder.Entity("BookstoreApp.Infrastructure.Data.Models.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingcartsBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
