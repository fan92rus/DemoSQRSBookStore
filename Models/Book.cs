using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models.Filters;

namespace Models
{
    public class BookFilter : IFilter<Book>
    {
        public RangeFilter? PriceRangeFilter { get; set; }
        public string TitleFilter { get; set; }
        public string AuthorFilter { get; set; }
        public bool HaveImages { get; set; }


        public bool Check(Book value)
        {
            var @checked = true;

            if (TitleFilter != null)
                @checked = ((TextFilter)TitleFilter).Check(value.Title);
            if (AuthorFilter != null)
                @checked = ((TextFilter)AuthorFilter).Check(value.Author);
            if (PriceRangeFilter != null)
                @checked = PriceRangeFilter.Check(value.Price);
            if (HaveImages)
                @checked = value?.Images?.Any() ?? false;

            return @checked;
        }
    }

    public class Book : Entity
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public string Author { get; set; }
    }

    public class Image : Entity
    {
        public string Title { get; set; }
        public Uri Uri { get; set; }
    }
}
