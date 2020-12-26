using App.Storage.Repository;
using Models;

namespace App.WebApi.Comands.Books.Base
{
    public abstract class BookHandler
    {
        protected GenericRepository<Book> BookRepository { get; set; }

        protected BookHandler(GenericRepository<Book> bookRepository)
        {
            this.BookRepository = bookRepository;
        }
    }
}