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
    public interface IPaginationQuery
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }

    public partial class ImagesGetbyIds
    {
        public class Query : IRequest<Operation<IEnumerable<Image>>>
        {
            public Query(IEnumerable<int> ids)
            {
                Ids = ids;
            }
            public Query()
            { }

            public IEnumerable<int> Ids { get; }
        }

        public class Handler : IRequestHandler<Query, Operation<IEnumerable<Image>>>
        {
            public GenericRepository<Image> ImagesRepository { get; }

            public Handler(GenericRepository<Image> imagesRepository)
            {
                ImagesRepository = imagesRepository;
            }
            public async Task<Operation<IEnumerable<Image>>> Handle(Query request, CancellationToken cancellationToken) => new Operation<IEnumerable<Image>>(true, "", ImagesRepository.Get(x => request.Ids.Contains(x.Id)));
        }
    }
}