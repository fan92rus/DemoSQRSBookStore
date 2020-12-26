using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public ICollection<Uri> Images { get; set; }
        public string Author { get; set; }
    }

}
