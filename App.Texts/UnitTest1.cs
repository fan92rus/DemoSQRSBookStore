using System.Collections.Generic;
using System.Linq;
using App.Models.Filters;
using Models;
using NUnit.Framework;

namespace App.Texts
{
    public class FilterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RangeFilterTest()
        {
            List<Book> books = new List<Book>()
            {
                new Book(){Price = 200},
                new Book(){Price = 2450},
                new Book(){Price = 1350},
                new Book(){Price = 5900},
                new Book(){Price = 900},
            };
            BookFilter filter = new BookFilter()
            {
                PriceRangeFilter = new RangeFilter()
                {
                    Max = 3000,
                    Min = 1000
                }
            };
            var filtered = books.Where(filter.Check).ToList();
            Assert.IsTrue(filtered.All(x => x.Price >= 1000 && x.Price <= 3000), "Не работает фильтр диапазона числовых значений");
            Assert.IsFalse(filtered.Except(books).Any(x => x.Price >= 1000 && x.Price <= 3000), "Фильтр числовых значений отсеил не все подходящие значения");

            Assert.Pass();
        }
    }
}