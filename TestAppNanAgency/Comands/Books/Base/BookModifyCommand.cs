using System;
using System.Collections.Generic;
using Models;

namespace App.WebApi.Comands.Books.Base
{
    public abstract class BookModifyCommand
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Author { get; set; }
        public IEnumerable<int> Images { get; set; }
    }
}