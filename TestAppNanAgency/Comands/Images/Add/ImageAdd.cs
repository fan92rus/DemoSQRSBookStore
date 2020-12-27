using System;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using MediatR;
using Models;

namespace TestAppNanAgency.Comands.Images.Add
{
    public partial class ImageAdd
    {
        public class Command : Image, IRequest<Operation<int>>
        {
        }

        public class Handler : IRequestHandler<Command, Operation<int>>
        {
            public GenericRepository<Image> ImagesRepository { get; }

            public Handler(GenericRepository<Image> imagesRepository)
            {
                ImagesRepository = imagesRepository;
            }
            public async Task<Operation<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                return new Operation<int>(true, "", ImagesRepository.Add(request));
            }
        }
    }
    public partial class ImageRemove
    {
        public class Command : Entity, IRequest<Operation>
        {
            
        }

        public class Handler : IRequestHandler<Command, Operation>
        {
            public GenericRepository<Image> Repository { get; }

            public Handler(GenericRepository<Image> repository)
            {
                this.Repository = repository;
            }
            public async Task<Operation> Handle(Command request, CancellationToken cancellationToken)
            {
                Repository.Remove(this.Repository.GetById(request.Id));
                return new Operation(true);
            }
        }
    }
}