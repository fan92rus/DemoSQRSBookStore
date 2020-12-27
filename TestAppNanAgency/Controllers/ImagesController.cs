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
        [HttpPost("Add")]
        public async Task<Operation<int>> Add(ImageAdd.Command command) => await Mediator.Send(command);

        [Authorize(Roles = "Manager")]
        [HttpDelete("Remove")]
        public async Task<Operation> Remove(ImageRemove.Command command) => await Mediator.Send(command);

        [HttpGet("Get")] 
        public async Task<Operation<Image>> Get(ImageGet.Query query) => await Mediator.Send(query);

        [HttpPost("GetByIds")]
        public async Task<Operation<IEnumerable<Image>>> Get(ImagesGetbyIds.Query query) => await Mediator.Send(query);

        [HttpGet("GetMany")]
        public async Task<Operation<IEnumerable<Image>>> Get([FromQuery]ImagesGet.Query query) => await Mediator.Send(query);
    }
}
