using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using App.WebApi.Comands.Books.Base;
using MediatR;
using Models;
using TestAppNanAgency.Querys.Images;

namespace App.WebApi.Comands.Books.BookEdit
{
    public partial class BookEdit
    {
        public class Handler : BookHandler, IRequestHandler<Command, Operation>
        {
            public IMediator Mediator { get; }

            public Handler(GenericRepository<Book> bookRepository, IMediator mediator) : base(bookRepository)
            {
                Mediator = mediator;
            }

            public async Task<Operation> Handle(Command request, CancellationToken cancellationToken)
            {
                var images = await Mediator.Send(new ImagesGetbyIds.Query(request.Images), cancellationToken);

                var book = this.BookRepository.GetById(request.id);
                book.Author = request.Author;
                book.Price = request.Price;
                book.Title = request.Title;
                book.Images = images.Value.ToList();

                this.BookRepository.Update(book);
                
                return new Operation(true);
            }
        }
    }
}