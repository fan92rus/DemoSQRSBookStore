using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.WebApi.Comands.Books.Base;
using MediatR;

namespace App.WebApi.Comands.Books.BookCreate
{
    public partial class BookCreate
    {
        public class Command : BookModifyCommand, IRequest<Operation<int>>
        {

        }
    }
}
