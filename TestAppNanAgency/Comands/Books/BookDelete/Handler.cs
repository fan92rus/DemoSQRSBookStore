using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using App.WebApi.Comands.Books.Base;
using MediatR;
using Models;

namespace App.WebApi.Comands.Books.BookDelete
{
    public partial class BookDelete
    {
        public class Handler : BookHandler, IRequestHandler<Command, Operation>
        {

            public async Task<Operation> Handle(Command request, CancellationToken cancellationToken)
            {
                var book = this.BookRepository.GetById(request.id);
                if (book == null)
                    return new Operation(false, "Книга не найдена");
                
                this.BookRepository.Remove(book);

                return new Operation(true);
            }

            public Handler(GenericRepository<Book> bookRepository) : base(bookRepository)
            {
            }
        }
    }
}