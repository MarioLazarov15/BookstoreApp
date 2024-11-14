using BookstoreApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        public Category AutobiographyCategory { get; set; }
        public Category FantasyCategory { get; set; }
        public Category HistoryCategory { get; set; }
        public Category ChildrenCategory { get; set; }
        public Category RomanceCategory { get; set; }
        public Category ScienceFictionCategory { get; set; }
        public Category AdventureCategory { get; set; }

        public Book BarackObama { get; set; }
        public Book MichelleObama { get; set; }
        public Book TheElementsOfTheCrown { get; set; }
        public Book TheQueenOfNothing { get; set; }
        public Book USHistory { get; set; }
        public Book WorldHistory { get; set; }
        public Book JustTryOneBite { get; set; }
        public Book IfYouGiveAMouseACookie { get; set; }
        public Book TheLoveHypothesis { get; set; }
        public Book HappyPlace { get; set; }
        public Book AllSystemsRed { get; set; }
        public Book TheSoundOfStars { get; set; }
        public Book IntoTheWild { get; set; }
        public Book TheGirlWhoStoleAnElephant { get; set; }

        private void SeedCategories()
        {
            AutobiographyCategory = new Category()
            {
                Id = 1,
                Name = "Autobiography"
            };

            FantasyCategory = new Category()
            {
                Id = 2,
                Name = "Fantasy"
            };

            HistoryCategory = new Category()
            {
                Id = 3,
                Name = "History"
            };

            ChildrenCategory = new Category()
            {
                Id = 4,
                Name = "Children's Books"
            };

            RomanceCategory = new Category()
            {
                Id = 5,
                Name = "Romance"
            };

            ScienceFictionCategory = new Category()
            {
                Id = 6,
                Name = "Science Fiction"
            };

            AdventureCategory = new Category()
            {
                Id = 7,
                Name = "Adventure"
            };
        }

        private void SeedProducts()
        {
            BarackObama = new Book
            {
                Id = 1,
                Title = "Barack Obama",
                Description = "“My identity might begin with the fact of my race, but it didn’t, couldn't end there. At least that’s what I would choose to believe”\r\nDreams From My Father by Barack Obama (Paperback ISBN 9781782119258) book cover\r\nAvailable as\tPaperback, eBook, Downloadable audio\r\n\r\nThis #1 New York Times bestselling",
                Price = 7.99M,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNigBtJfs3f0sARUdACCC44A_QF7Vh0k_BGQ&s",
                CategoryId = 1
            };

            MichelleObama = new Book
            {
                Id = 2,
                Title = "Michelle Obama",
                Description = "In a life filled with meaning and accomplishment, Michelle Obama has emerged as one of the most iconic and compelling women of our era.",
                Price = 4.99M,
                ImageUrl = "https://m.media-amazon.com/images/I/81cJTmFpG-L._AC_UF1000,1000_QL80_.jpg",
                CategoryId = 1
            };

            TheElementsOfTheCrown = new Book
            {
                Id = 3,
                Title = "The Elements of The Crown",
                Description = "In an empire divided into three rings, seventeen-year-old Talise is from the outer ring. This dangerous and crime-laden land has one constant… death.",
                Price = 19.99M,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1623351257i/58310267.jpg",
                CategoryId = 2
            };

            TheQueenOfNothing = new Book()
            {
                Id = 4,
                Title = "The Queen of Nothing",
                Description = "A powerful curse forces the exiled Queen of Faerie to choose between ambition and humanity in this highly anticipated and jaw-dropping finale to The Folk of the Air trilogy from a #1 New York Times bestselling author.",
                Price = 12.99M,
                ImageUrl = "https://m.media-amazon.com/images/I/91nGoCptgmL._AC_UF1000,1000_QL80_.jpg",
                CategoryId = 2
            };

            USHistory = new Book()
            {
                Id = 5,
                Title = "U.S. History",
                Description = "Covering the most important material taught in high school American history class, this essential review book breaks need-to-know content into accessible, easily understood lessons.",
                Price = 30.99M,
                ImageUrl = "https://images.penguinrandomhouse.com/cover/9780525570127",
                CategoryId = 3
            };

            WorldHistory = new Book()
            {
                Id = 6,
                Title = "World History",
                Description = "Glencoe World History is a full-survey world history program authored by a world-renowned historian, Jackson Spielvogel, and the National Geographic Society. ",
                Price = 1.99M,
                ImageUrl = "https://m.media-amazon.com/images/I/A1BUSpcfSWL._AC_UF1000,1000_QL80_.jpg",
                CategoryId = 3
            };

            JustTryOneBite = new Book()
            {
                Id = 7,
                Title = "Just try one bite",
                Description = "These three kids are determined to get their parents to put down the ice cream, cake, and chicken fried steak to just try one bite of healthy whole foods.",
                Price = 12.99M,
                ImageUrl = "https://m.media-amazon.com/images/I/81L4z-NZt2L._AC_UF1000,1000_QL80_.jpg",
                CategoryId = 4
            };

            IfYouGiveAMouseACookie = new Book()
            {
                Id = 8,
                Title = "If you give a Mouse a Cookie",
                Description = "If a hungry little mouse shows up on your doorstep, you might want to give him a cookie. And if you give him a cookie, he'll ask for a glass of milk.",
                Price = 1.49M,
                ImageUrl = "https://m.media-amazon.com/images/I/813csV5cPqL.jpg",
                CategoryId = 4
            };

            TheLoveHypothesis = new Book()
            {
                Id = 9,
                Title = "The Love Hypothesis",
                Description = "As a third-year Ph.D. candidate, Olive Smith doesn't believe in lasting romantic relationships--but her best friend does, and that's what got her into this situation.",
                Price = 3.29M,
                ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1611937942l/56732449.jpg",
                CategoryId = 5
            };

            HappyPlace = new Book()
            {
                Id = 10,
                Title = "Happy Place",
                Description = "Harriet and Wyn have been the perfect couple since they met in college—they go together like salt and pepper, honey and tea, lobster and rolls. Except, now—for reasons they’re still not discussing—they don’t.",
                Price = 8.99M,
                ImageUrl = "https://m.media-amazon.com/images/I/81jTZJQB4WL._AC_UF894,1000_QL80_.jpg",
                CategoryId = 5
            };

            AllSystemsRed = new Book()
            {
                Id = 11,
                Title = "All Systems Red",
                Description = "A murderous android discovers itself in All Systems Red, a tense science fiction adventure by Martha Wells that interrogates the roots of consciousness through Artificial Intelligence.",
                Price = 21.80M,
                ImageUrl = "https://m.media-amazon.com/images/I/81thdg0KmZL.jpg",
                CategoryId = 6
            };

            TheSoundOfStars = new Book()
            {
                Id = 12,
                Title = "The Sound of Stars",
                Description = "This book has everything! Aliens set on conquering earth! A determined heroine with a hidden stash of books! And the power of music and stories to give those with every reason to hate the power to love.",
                Price = 3.49M,
                ImageUrl = "https://m.media-amazon.com/images/I/81yhKr0TzXL.jpg",
                CategoryId = 6
            };

            IntoTheWild = new Book
            {
                Id = 13,
                Title = "Into The Wild",
                Description = " In April 1992 a young man from a well-to-do family hitchhiked to Alaska and walked alone into the wilderness north of Mt. McKinley. Four months later, his decomposed body was found by a moose hunter. This is the unforgettable story of how Christopher Johnson McCandless came to die.",
                Price = 5.49M,
                ImageUrl = "https://m.media-amazon.com/images/I/61A+LdmTESL._AC_UF1000,1000_QL80_.jpg",
                CategoryId = 7
            };

            TheGirlWhoStoleAnElephant = new Book
            {
                Id = 14,
                Title = "The Girl Who Stole an Elephant",
                Description = "Chaya, outspoken hero, leads her friends and a gorgeous elephant on a noisy, fraught, joyous adventure through the jungle where revolution is stirring and leeches lurk. Will stealing the queen’s jewels be the beginning or the end of everything for the intrepid gang?",
                Price = 5.49M,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1563136258i/44906685.jpg",
                CategoryId = 7
            };
        }
    }
}
