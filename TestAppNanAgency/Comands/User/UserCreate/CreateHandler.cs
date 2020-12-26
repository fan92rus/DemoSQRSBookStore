using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models;

namespace App.WebApi.Features.CreateUser
{
    public partial class UserCreate
    {
        public class Handler : IRequestHandler<Command, Operation>
        {
            public UserManager<User> UserManager { get; }
            public RoleManager<IdentityRole> RoleManager { get; }

            public Handler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            {
                UserManager = userManager;
                RoleManager = roleManager;
            }

            public async Task<Operation> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    Email = request.Email,
                    UserName = request.UserName,
                };
                var result = await UserManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                    return new Operation(false, result.Errors.Select(x => x.Description));
                var role = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(request.Role.ToString());
                
                await UserManager.AddToRoleAsync(user, role);
                
                return new Operation(true);
            }
        }
    }
}
