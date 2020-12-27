using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.Pagination
{
    public class Page<T>
    {
        public Page(int fullCount, IEnumerable<T> collection)
        {
            FullCount = fullCount;
            Collection = collection;
        }

        public int FullCount { get; set; }
        public IEnumerable<T> Collection { get; set; }
    }
}
