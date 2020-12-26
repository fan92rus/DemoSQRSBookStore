using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using App.WebApi.Comands.Books.Base;
using MediatR;
using Models;

namespace App.WebApi.Querys.Books.BooksGet
{
    public partial class BooksGet
    {
        public class Handler : BookHandler, IRequestHandler<Command, Operation<IEnumerable<Book>>>
        {
            public Handler(GenericRepository<Book> bookRepository) : base(bookRepository)
            {
            }

            public async Task<Operation<IEnumerable<Book>>> Handle(Command request, CancellationToken cancellationToken)
            {
                return new Operation<IEnumerable<Book>>(true, "", this.BookRepository.Get(x => true));
            }
        }
    }
}