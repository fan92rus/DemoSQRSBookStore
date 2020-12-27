using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace App.Models.User
{
    public class UserDashboardModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Book> BuyedBooks { get; set; }
    }
}
