using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Models.User;
using App.WebApi.Comands.UserGet;
using App.WebApi.Comands.UserLogin;
using App.WebApi.Features.CreateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator Mediator { get; }
        public IMapper Mapper { get; }

        public UserController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<Operation> Register(UserCreate.Command command) => await Mediator.Send(command);

        [HttpPost("login")]
        public async Task<bool> Login(UserLogin.Command command) => await Mediator.Send(command);

        [HttpGet("get")]
        public async Task<UserDashboardModel> GetUser()
        {
            var user = await Mediator.Send(new UserQuery.Command(this.HttpContext.User));
            return Mapper.Map<UserDashboardModel>(user);
        }
    }
}
