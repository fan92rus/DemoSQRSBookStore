using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models;

namespace App.WebApi.Comands.Books.Buy
{
    public partial class BookBuy
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Book).NotNull().WithMessage("Книги не существует");
                RuleFor(x => x.User).NotNull().WithMessage("Пользователя не существует либо нету авторизации");
            }
        }
        public class Command : IRequest
        {
            public Command(Book book, User user)
            {
                this.Book = book;
                this.User = user;
            }
            public User User { get; set; }
            public Book Book { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            public UserManager<User> UserManager { get; }

            public Handler(UserManager<User> userManager)
            {
                UserManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = request.User;
                user.BuyedBooks ??= new List<Book>();

                user.BuyedBooks.Add(request.Book);
                user.Rating++;
                user.Balance -= request.Book.Price;

                await UserManager.UpdateAsync(user);
                return new Unit();
            }
        }
    }
}
