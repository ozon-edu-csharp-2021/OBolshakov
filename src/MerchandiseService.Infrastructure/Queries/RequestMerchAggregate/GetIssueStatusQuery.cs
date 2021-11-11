using MediatR;

namespace MerchandiseService.Infrastructure.Queries.RequestMerchAggregate
{
    public class GetIssueStatusQuery : IRequest<string>
    {
        public long RequestNumber { get; set; }
    }
}