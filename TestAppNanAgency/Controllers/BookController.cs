using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Models.Pagination;
using App.WebApi.Comands.Books.BookCreate;
using App.WebApi.Comands.Books.BookDelete;
using App.WebApi.Comands.Books.BookEdit;
using App.WebApi.Features.CreateUser;
using App.WebApi.Querys.Books.BookGet;
using App.WebApi.Querys.Books.BooksGet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IMediator Mediator { get; }

        public BookController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<Operation<Book>> Get(int id) => await Mediator.Send(new BookGet.Command(id));

        /// <summary>
        /// Возвращает книги с пагинацией
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("GetAll")]
        public async Task<Operation<Page<Book>>> GetAll(BooksGet.Query query) => await Mediator.Send(query);

        [Authorize(Roles = "Manager")]
        [HttpPost("Add")]
        public async Task<Operation<int>> Add(BookCreate.Command command) => await Mediator.Send(command);

        [Authorize(Roles = "Manager")]
        [HttpDelete("Delete")]
        public async Task<Operation> Delete([FromQuery]BookDelete.Command command) => await Mediator.Send(command);

        [Authorize(Roles = "Manager")]
        [HttpPatch("Edit")]
        public async Task<Operation> Edit(BookEdit.Command command) => await Mediator.Send(command);
    }
}
