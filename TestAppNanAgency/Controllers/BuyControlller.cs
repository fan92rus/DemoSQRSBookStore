using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.WebApi.Comands.Books.Buy;
using App.WebApi.Comands.UserGet;
using App.WebApi.Querys.Books.BookGet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        public IMediator Mediator { get; }

        public BuyController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [Authorize]
        [HttpGet("buy")]
        public async Task<Operation> Buy(int id)
        {
            var book = await Mediator.Send(new BookGet.Command(id));
            var user = await Mediator.Send(new UserQuery.Command(this.HttpContext.User));
            await Mediator.Send(new BookBuy.Command(book.Value, user));
            return new Operation(true);
        }
    }
}
