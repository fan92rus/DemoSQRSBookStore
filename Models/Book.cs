using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
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
