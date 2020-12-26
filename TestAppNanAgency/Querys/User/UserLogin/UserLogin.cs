using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using App.Models.User;
using MediatR;

namespace App.WebApi.Comands.UserLogin
{
    public partial class UserLogin
    {
        public class Command : IRequest<bool>
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
