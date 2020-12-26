using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using MediatR;
using Models;

namespace App.WebApi.Querys.Books.BooksGet
{
    public partial class BooksGet
    {
        public class Command : IRequest<Operation<IEnumerable<Book>>>
        {

        }
    }
}
