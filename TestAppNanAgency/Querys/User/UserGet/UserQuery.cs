using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using App.Models.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models;

namespace App.WebApi.Comands.UserGet
{
    public class UserQuery
    {
        public class Command : IRequest<User>
        {
            public Command(ClaimsPrincipal principal)
            {
                this.Principal = principal;
            }
            public ClaimsPrincipal Principal { get; set; }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            public UserManager<User> UserManager { get; }

            public Handler(UserManager<User> userManager)
            {
                UserManager = userManager;
            }
            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await UserManager.GetUserAsync(request.Principal);
                return user;
            }
        }

    }
}
