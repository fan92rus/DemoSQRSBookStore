using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using App.WebApi.Comands.Books.Base;
using MediatR;
using Models;

namespace App.WebApi.Comands.Books.BookCreate
{
    public partial class BookCreate
    {
        public class Handler : BookHandler, IRequestHandler<Command, Operation<int>>
        {

            public async Task<Operation<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = this.BookRepository.Add(new Book()
                {
                    Author = request.Author,
                    Images = request.Images.ToList(),
                    Price = request.Price,
                    Title = request.Title
                });
                return new Operation<int>(true, "", result);
            }

            public Handler(GenericRepository<Book> bookRepository) : base(bookRepository)
            {
            }
        }
    }
}
