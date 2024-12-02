using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IniticialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Book category");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Country identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(57)", maxLength: 57, nullable: false, comment: "Country name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                },
                comment: "Country");

            migrationBuilder.CreateTable(
                name: "Shoppingcarts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Shopping cart identifier"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Shopping cart total")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoppingcarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Book identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Book title"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image of the book"),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true, comment: "Description of the book"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Book price"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category of the book")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Book model");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Order identifier"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "First name of the buyer"),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Last name of the buyer"),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false, comment: "City of the buyer"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Country of the buyer"),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Zip code of the buyer"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Phone number of the buyer"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Email of the buyer"),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true, comment: "Additional Information about adress")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingcartsBooks",
                columns: table => new
                {
                    ShoppingcartId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Shopping cart identifier"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    ProductAmount = table.Column<int>(type: "int", nullable: false, comment: "Amount of certain book")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingcartsBooks", x => new { x.ShoppingcartId, x.BookId });
                    table.ForeignKey(
                        name: "FK_ShoppingcartsBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingcartsBooks_Shoppingcarts_ShoppingcartId",
                        column: x => x.ShoppingcartId,
                        principalTable: "Shoppingcarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping table of Shopping cart and Book");

            migrationBuilder.CreateTable(
                name: "OrdersBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "Book identifier"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Order identifier"),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "Book amount")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersBooks", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersBooks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping table of Book and Order");

            migrationBuilder.CreateTable(
                name: "UsersOrders",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Order identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOrders", x => new { x.OrderId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping table of ApplicationUser and Order");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Autobiography" },
                    { 2, "Fantasy" },
                    { 3, "History" },
                    { 4, "Children's Books" },
                    { 5, "Romance" },
                    { 6, "Science Fiction" },
                    { 7, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria" },
                    { 2, "Greece" },
                    { 3, "Serbia" },
                    { 4, "Romania" },
                    { 5, "Croatia" },
                    { 6, "Albania" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "“My identity might begin with the fact of my race, but it didn’t, couldn't end there. At least that’s what I would choose to believe”\r\nDreams From My Father by Barack Obama (Paperback ISBN 9781782119258) book cover\r\nAvailable as	Paperback, eBook, Downloadable audio\r\n\r\nThis #1 New York Times bestselling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNigBtJfs3f0sARUdACCC44A_QF7Vh0k_BGQ&s", 19.99m, "Barack Obama" },
                    { 2, 1, "In a life filled with meaning and accomplishment, Michelle Obama has emerged as one of the most iconic and compelling women of our era.", "https://m.media-amazon.com/images/I/81cJTmFpG-L._AC_UF1000,1000_QL80_.jpg", 19.99m, "Michelle Obama" },
                    { 3, 2, "In an empire divided into three rings, seventeen-year-old Talise is from the outer ring. This dangerous and crime-laden land has one constant… death.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1623351257i/58310267.jpg", 22.99m, "The Elements of The Crown" },
                    { 4, 2, "A powerful curse forces the exiled Queen of Faerie to choose between ambition and humanity in this highly anticipated and jaw-dropping finale to The Folk of the Air trilogy from a #1 New York Times bestselling author.", "https://m.media-amazon.com/images/I/91nGoCptgmL._AC_UF1000,1000_QL80_.jpg", 23.99m, "The Queen of Nothing" },
                    { 5, 3, "Covering the most important material taught in high school American history class, this essential review book breaks need-to-know content into accessible, easily understood lessons.", "https://images.penguinrandomhouse.com/cover/9780525570127", 29.99m, "U.S. History" },
                    { 6, 3, "Glencoe World History is a full-survey world history program authored by a world-renowned historian, Jackson Spielvogel, and the National Geographic Society. ", "https://m.media-amazon.com/images/I/A1BUSpcfSWL._AC_UF1000,1000_QL80_.jpg", 29.99m, "World History" },
                    { 7, 4, "These three kids are determined to get their parents to put down the ice cream, cake, and chicken fried steak to just try one bite of healthy whole foods.", "https://m.media-amazon.com/images/I/81L4z-NZt2L._AC_UF1000,1000_QL80_.jpg", 9.99m, "Just try one bite" },
                    { 8, 4, "If a hungry little mouse shows up on your doorstep, you might want to give him a cookie. And if you give him a cookie, he'll ask for a glass of milk.", "https://m.media-amazon.com/images/I/813csV5cPqL.jpg", 7.49m, "If you give a Mouse a Cookie" },
                    { 9, 5, "As a third-year Ph.D. candidate, Olive Smith doesn't believe in lasting romantic relationships--but her best friend does, and that's what got her into this situation.", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1611937942l/56732449.jpg", 3.29m, "The Love Hypothesis" },
                    { 10, 5, "Harriet and Wyn have been the perfect couple since they met in college—they go together like salt and pepper, honey and tea, lobster and rolls. Except, now—for reasons they’re still not discussing—they don’t.", "https://m.media-amazon.com/images/I/81jTZJQB4WL._AC_UF894,1000_QL80_.jpg", 8.99m, "Happy Place" },
                    { 11, 6, "A murderous android discovers itself in All Systems Red, a tense science fiction adventure by Martha Wells that interrogates the roots of consciousness through Artificial Intelligence.", "https://m.media-amazon.com/images/I/81thdg0KmZL.jpg", 15.80m, "All Systems Red" },
                    { 12, 6, "This book has everything! Aliens set on conquering earth! A determined heroine with a hidden stash of books! And the power of music and stories to give those with every reason to hate the power to love.", "https://m.media-amazon.com/images/I/81yhKr0TzXL.jpg", 16.49m, "The Sound of Stars" },
                    { 13, 7, " In April 1992 a young man from a well-to-do family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later, his decomposed body was found by a moose hunter. This is the unforgettable story of how Christopher Johnson McCandless came to die.", "https://m.media-amazon.com/images/I/61A+LdmTESL._AC_UF1000,1000_QL80_.jpg", 20.49m, "Into The Wild" },
                    { 14, 7, "Chaya, outspoken hero, leads her friends and a gorgeous elephant on a noisy, fraught, joyous adventure through the jungle where revolution is stirring and leeches lurk. Will stealing the queen’s jewels be the beginning or the end of everything for the intrepid gang?", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1563136258i/44906685.jpg", 8.49m, "The Girl Who Stole an Elephant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CountryId",
                table: "Orders",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersBooks_BookId",
                table: "OrdersBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingcartsBooks_BookId",
                table: "ShoppingcartsBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_UserId",
                table: "UsersOrders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrdersBooks");

            migrationBuilder.DropTable(
                name: "ShoppingcartsBooks");

            migrationBuilder.DropTable(
                name: "UsersOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Shoppingcarts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
