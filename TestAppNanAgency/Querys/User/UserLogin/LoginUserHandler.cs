using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Models;

namespace App.WebApi.Comands.UserLogin
{
    public partial class UserLogin
    {
        public class Handler : IRequestHandler<Command, bool>
        {
            public UserManager<User> UserManager { get; }
            public SignInManager<User> SignInManager { get; }

            public Handler(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                UserManager = userManager;
                SignInManager = signInManager;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await SignInManager.PasswordSignInAsync(request.Login, request.Password, true, false);
                return result.Succeeded;
            }
        }
    }
}