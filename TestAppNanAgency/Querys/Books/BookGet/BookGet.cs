using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using MediatR;
using Models;

namespace App.WebApi.Querys.Books.BookGet
{
    public partial class BookGet
    {
        public class Command : IRequest<Operation<Book>>
        {
            public Command(int id)
            {
                this.Id = id;
            }
            public int Id { get; set; }
        }
    }
}
