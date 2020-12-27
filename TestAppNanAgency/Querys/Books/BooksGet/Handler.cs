using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Models.Pagination;
using App.Storage.Repository;
using App.WebApi.Comands.Books.Base;
using MediatR;
using Models;

namespace App.WebApi.Querys.Books.BooksGet
{
    public partial class BooksGet
    {
        public class Handler : BookHandler, IRequestHandler<Query, Operation<Page<Book>>>
        {
            public Handler(GenericRepository<Book> bookRepository) : base(bookRepository)
            {
            }

            public async Task<Operation<Page<Book>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = this.BookRepository.Get(x => true);
                if (request.BookFilter != null) books = books.Where(x => request.BookFilter.Check(x));
                return new Operation<Page<Book>>(true, "", new Page<Book>(books.Count(), books.Skip(request.Skip).Take(request.Take)));
            }
        }
    }
}