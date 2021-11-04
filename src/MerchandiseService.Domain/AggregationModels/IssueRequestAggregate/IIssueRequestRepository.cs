using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.IssueRequestAggregate
{
    public interface IIssueRequestRepository : IRepository<IssueRequest>
    {
        Task<IssueRequest> CreateAsync(IssueRequest issueRequest, CancellationToken cancellationToken = default);
        Task<IssueRequest> FindByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}