using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.RequestMerchAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.RequestEmailAggregate
{
    public interface IRequestEmailRepository : IRepository<RequestEmail>
    {
        Task<RequestEmail> FindByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}