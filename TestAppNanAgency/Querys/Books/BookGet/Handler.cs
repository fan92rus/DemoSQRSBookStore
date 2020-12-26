using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using App.WebApi.Comands.Books.Base;
using MediatR;
using Models;

namespace App.WebApi.Querys.Books.BookGet
{
    public partial class BookGet
    {
        public class Handler : BookHandler, IRequestHandler<Command, Operation<Book>>
        {
            public Handler(GenericRepository<Book> bookRepository) : base(bookRepository)
            {
            }

            public async Task<Operation<Book>> Handle(Command request, CancellationToken cancellationToken) => new Operation<Book>(true, "", this.BookRepository.GetById(request.Id));
        }
    }
}