using System;
using System.Collections.Generic;
using App.Models;
using App.WebApi.Comands.Books.Base;
using MediatR;

namespace App.WebApi.Comands.Books.BookEdit
{
    public partial class BookEdit
    {
        public class Command : BookModifyCommand, IRequest<Operation>
        {
            public int id { get; set; }
        }
    }
}
