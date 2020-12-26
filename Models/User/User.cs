using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public float Balance { get; set; }
        public virtual ICollection<Book> BuyedBooks { get; set; }
        public virtual ICollection<Book> Cart { get; set; }
    }
}
