using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.RequestMerchAggregate
{
    public interface IRequestMerchRepository : IRepository<RequestMerch>
    {
        Task<RequestMerch> CreateAsync(RequestMerch requestMerch, CancellationToken cancellationToken = default);
        Task<RequestMerch> UpdateAsync(RequestMerch requestMerch, CancellationToken cancellationToken = default);
        Task<RequestMerch> FindByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<RequestMerch>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}