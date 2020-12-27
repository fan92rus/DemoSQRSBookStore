#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.Models.Pagination;
using MediatR;
using Models;
using TestAppNanAgency.Querys.Images;

namespace App.WebApi.Querys.Books.BooksGet
{
    public partial class BooksGet
    {
        public class Query : IRequest<Operation<Page<Book>>>, IPaginationQuery
        {
            public int Take { get; set; } = 20;
            public int Skip { get; set; } = 0;
            public BookFilter? BookFilter { get; set; }
        }
    }
}
