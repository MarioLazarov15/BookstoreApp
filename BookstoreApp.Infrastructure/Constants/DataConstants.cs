﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Constants
{
    public class DataConstants
    {
        public static class User
        {
            public const int FirstNameMaxLength = 25;
            public const int LastNameMaxLength = 25;
        }
        public static class Category
        {
            public const int NameMaxLength = 50;
        }

        public static class Country
        {
            public const int NameMaxLength = 57;
        }
        public static class Book
        {
            public const int TitleMaxLength = 150;
            public const int DescriptionMaxLength = 750;
            public const double PriceMaxValue = 999.9;
            public const double PriceMinValue = 0.9;
        }
        public static class Order
        {
            public const int FirstNameMaxLength = 25;
            public const int FirstNameMinLength = 2;
            public const int LastNameMaxLength = 25;
            public const int LastNameMinLength = 2;
            public const int CityNameMaxLength = 85;
            public const int CityNameMinLength = 4;
            public const int ZipCodeMaxLength = 10;
            public const int ZipCodeMinLength = 3;
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7;
            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 5;
            public const int AdditionalInfoMaxLength = 750;
        }
    }
}
