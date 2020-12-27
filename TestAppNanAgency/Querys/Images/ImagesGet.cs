using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using App.Storage.Repository;
using MediatR;
using Models;

namespace TestAppNanAgency.Querys.Images
{
    public partial class ImagesGet
    {
        public class Query : IRequest<Operation<IEnumerable<Image>>>, IPaginationQuery
        {
            public int Take { get; set; } = 20;
            public int Skip { get; set; } = 0;
        }

        public class Handler : IRequestHandler<Query, Operation<IEnumerable<Image>>>
        {
            public GenericRepository<Image> ImagesRepository { get; }

            public Handler(GenericRepository<Image> imagesRepository)
            {
                ImagesRepository = imagesRepository;
            }
            public async Task<Operation<IEnumerable<Image>>> Handle(Query request, CancellationToken cancellationToken) => new Operation<IEnumerable<Image>>(true, "", ImagesRepository.Get(x => true).Skip(request.Skip).Take(request.Take));
        }
    }
}