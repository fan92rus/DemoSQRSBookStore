using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using MediatR;
using Npgsql.PostgresTypes;
using Npgsql.TypeHandlers;

namespace App.WebApi.Comands.Books.BookDelete
{
    public partial class BookDelete
    {
        public class Command : IRequest<Operation>
        {
            public int id { get; set; }
        }
    }
}
