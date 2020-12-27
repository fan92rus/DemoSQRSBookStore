using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using TestAppNanAgency.Comands.Images.Add;
using TestAppNanAgency.Querys.Images;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImagesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        private IMediator Mediator { get; }
        
        [Authorize(Roles = "Manager")]
        [HttpPost("add")]
        public async Task<Operation<int>> Add(ImageAdd.Command command) => await Mediator.Send(command);


        [Authorize(Roles = "Manager")]
        [HttpPost("remove")]
        public async Task<Operation> Remove(ImageRemove.Command command) => await Mediator.Send(command);

        [HttpPost("get")] 
        public async Task<Operation<Image>> Get(ImageGet.Query query) => await Mediator.Send(query);

        [HttpPost("getByIds")]
        public async Task<Operation<IEnumerable<Image>>> Get(ImagesGetbyIds.Query query) => await Mediator.Send(query);

        [HttpPost("getMany")]
        public async Task<Operation<IEnumerable<Image>>> Get(ImagesGet.Query query) => await Mediator.Send(query);
    }
}
