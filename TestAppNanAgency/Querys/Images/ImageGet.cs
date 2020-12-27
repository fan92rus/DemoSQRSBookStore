using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using MediatR;
using Models;

namespace TestAppNanAgency.Querys.Images
{
    public partial class ImageGet
    {
        public class Query : Entity, IRequest<Operation<Image>>
        {
        }

        public class Handler : IRequestHandler<Query, Operation<Image>>
        {
            public GenericRepository<Image> ImagesRepository { get; }

            public Handler(GenericRepository<Image> imagesRepository)
            {
                ImagesRepository = imagesRepository;
            }
            public async Task<Operation<Image>> Handle(Query request, CancellationToken cancellationToken) => new Operation<Image>(true, "", ImagesRepository.GetById(request.Id));
        }
    }
}