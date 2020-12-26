using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App.Models;
using FluentValidation;
using MediatR;

namespace App.WebApi.Features.CreateUser
{
    public partial class UserCreate
    {
        public enum Role
        {
            User,
            Manager
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Balance).Must(x => x > 0).WithMessage("Баланс должен быть больше 0");
                RuleFor(x => x.Email).NotNull().Matches("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$").WithMessage("Email не соответсвует шаблону");
                RuleFor(x => x.Password).MinimumLength(8);
                RuleFor(x => x.UserName).MinimumLength(8);
            }
        }
        public class Command : IRequest<Operation>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public float Balance { get; set; }
            public Role Role { get; set; }
        }
    }
}
